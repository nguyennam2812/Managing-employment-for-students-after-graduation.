using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using QuanLySinhVien.Data;
using QuanLySinhVien.Security;
using QuanLySinhVien.Services;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien
{
    public partial class StudentDashboardForm : Form
    {
        private readonly SurveyDbContext _db;
        private readonly StudentJobService _studentService;
        private SV _currentStudent;
        private PhieuKhaoSat _currentSurvey;
        private List<TextBox> _listAnswerInputs = new List<TextBox>();

        public StudentDashboardForm()
        {
            InitializeComponent();
            _db = new SurveyDbContext();
            _studentService = new StudentJobService(_db);
            
            this.Load += StudentDashboardForm_Load;
        }

        // Constructor overloading in case we want to pass parent or context
        public StudentDashboardForm(Form parent) : this()
        {
            // If needed to handle parent logic
        }

        private void StudentDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                var maSV = AuthContext.MaSinhVien;
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                LoadStudentInfo(maSV);
                LoadPendingSurvey(maSV);
                ApplyVisualStyle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dashboard: " + ex.Message);
            }
        }

        private void ApplyVisualStyle()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            UITheme.ApplyFormDefaults(this);
            UITheme.StylePrimaryButton(btnSubmitSurvey);
            UITheme.StylePrimaryButton(btnKhaiBaoThongTin);
            UITheme.StyleGhostButton(btnLogout);
            UITheme.StyleTextBox(txtMaSV);
            UITheme.StyleTextBox(txtHoTen);
            UITheme.StyleTextBox(txtNgaySinh);
            UITheme.StyleTextBox(txtEmail);
            UITheme.StyleTextBox(txtPhone);
            UITheme.StyleTextBox(txtMaNganh);
            UITheme.StyleTextBox(txtMaKhoaHoc);
            UITheme.StyleTextBox(txtMaLop);

            // Fix Layout position
            btnLogout.Top = 15;
            btnLogout.Left = pnlUserInfo.Width - btnLogout.Width - 20;

            // Center Title
            lblWelcome.Left = 20;
            lblWelcome.Top = (pnlUserInfo.Height - lblWelcome.Height) / 2;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            UITheme.DrawGradientBackground(e.Graphics, this.ClientRectangle, 
                UITheme.PrimaryLight, System.Drawing.Color.FromArgb(224, 231, 255));
        }

        private void LoadStudentInfo(string maSV)
        {
            // Use existing service or direct DB if needed for includes
            // StudentJobService.GetSinhVien usually includes basic info, but let's check if we need specialized include
            // For safety, re-implementing specific query here or trusting service. 
            // Previous code used direct DB context in FrmKhaoSatSinhVien, so let's stick to that for consistency with "Include" needs
            
            // Table Lop is deleted, so avoid Includes that might reference it.
            // Just load the raw student entity.
            _currentStudent = _db.SinhViens
                .FirstOrDefault(s => s.MaSV == maSV);

            if (_currentStudent != null)
            {
                lblWelcome.Text = $"Xin chào, {_currentStudent.HoTen}";
                
                txtMaSV.Text = _currentStudent.MaSV;
                txtHoTen.Text = _currentStudent.HoTen;
                txtNgaySinh.Text = _currentStudent.NgaySinh?.ToString("dd/MM/yyyy") ?? "";
                txtEmail.Text = _currentStudent.EmailCaNhan;
                txtPhone.Text = _currentStudent.SoDienThoai;
                

                // txtTinhTrang removed - TinhTrangViecLam not part of thesis requirements
                txtMaNganh.Text = _currentStudent.MaNganh;
                txtMaKhoaHoc.Text = _currentStudent.MaKhoaHoc;
                txtMaLop.Text = _currentStudent.MaLop;
            }
        }

        private void LoadPendingSurvey(string maSV)
        {
            var today = DateTime.Today;
            
            // Logic: Must be Open AND Not Expired
            // Accept multiple status formats: "Đang mở", "DANG_MO", etc.
            var openStatuses = new[] { "Đang mở", "DANG_MO", "Dang mo", "đang mở" };
            
            var pendingSurvey = _db.PhieuKhaoSats
                .Where(p => openStatuses.Contains(p.TrangThaiPhieu) || p.TrangThaiPhieu.ToLower().Contains("mở") || p.TrangThaiPhieu.ToUpper().Contains("MO"))
                .Where(p => p.NgayHetHan == null || p.NgayHetHan >= today)
                // Removed strict PhanCongKhaoSat check - show all open surveys to all students
                .Where(p => !_db.KetQuaKhaoSats.Any(k => k.MaPhieu == p.MaPhieu && k.MaSV == maSV))
                .OrderByDescending(p => p.NgayTao)
                .FirstOrDefault();

            if (pendingSurvey != null && string.IsNullOrEmpty(pendingSurvey.NoiDungCauHoi))
            {
                 // Fallback content if empty (legacy data)
                 pendingSurvey.NoiDungCauHoi = "Câu hỏi mặc định: Bạn có hài lòng với chất lượng đào tạo không?\n(Phiếu này chưa có nội dung chi tiết)"; 
            }

            if (pendingSurvey != null)
            {
                _currentSurvey = pendingSurvey;
                lblSurveyTitle.Text = pendingSurvey.TenDotKhaoSat ?? "BÀI KHẢO SÁT";
                RenderDynamicSurvey(pendingSurvey.NoiDungCauHoi); // Use dynamic form
                
                pnlSurveyContainer.Visible = true;
                lblNoSurvey.Visible = false;
            }
            else
            {
                pnlSurveyContainer.Visible = false;
                lblNoSurvey.Visible = true;
            }
        }
        
        // Dynamic Survey Controls REMOVED
        // private List<(int QId, Control InputCtrl, string Type)> _dynamicInputs = new List<(int, Control, string)>();

        private void RenderDynamicSurvey(string json)
        {
            pnlQuestions.Controls.Clear();
            // Show simple instruction
            var lbl = new Label 
            { 
                Text = "Vui lòng nhấn nút 'Thực hiện khảo sát' bên dưới để bắt đầu điền phiếu.", 
                AutoSize = true, 
                Location = new Point(10, 10),
                Font = new Font(this.Font, FontStyle.Italic)
            };
            pnlQuestions.Controls.Add(lbl);
            
            // Rename button
            btnSubmitSurvey.Text = "Thực hiện khảo sát";
        }

        private void btnSubmitSurvey_Click(object sender, EventArgs e)
        {
            if (_currentSurvey == null) return;

            // Open the separate form logic
            var form = new FrmDienKhaoSat(_currentSurvey.MaPhieu, _currentStudent.MaSV);
            if (form.ShowDialog() == DialogResult.OK)
            {
                 LoadPendingSurvey(_currentStudent.MaSV);
                 MessageBox.Show("Cảm ơn bạn đã hoàn thành khảo sát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // Deserialize helper removed as it's no longer needed here
        /*
        private static List<QuestionItem> Deserialize(string json)
        {
            // ...
        }
        */

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Signal to Program.cs loop
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void btnKhaiBaoThongTin_Click(object sender, EventArgs e)
        {
            if (_currentStudent == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form khai báo thông tin (dùng chung form với khảo sát, MaPhieu = 0 cho chế độ tự khai báo)
            var form = new FrmDienKhaoSat(0, _currentStudent.MaSV);
            form.Text = "Khai báo thông tin việc làm";
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã lưu thông tin khai báo thành công!\nThông tin sẽ được xác thực sau.", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
