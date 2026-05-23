using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QuanLySinhVien.Security;
using QuanLySinhVien.Data;
using QuanLySinhVien.Dialogs;
using System.Linq;

namespace QuanLySinhVien
{
    public class DashboardForm : Form
    {
        private MainForm _mainForm;
        private FlowLayoutPanel flowPanel;
        private Label lblStats;

        public DashboardForm(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Dashboard";
            this.DoubleBuffered = true;
            
            // Enable custom painting for gradient background
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Main container
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F)); // Header section
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // Stats bar
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Cards area
            mainLayout.Padding = new Padding(30);
            
            this.Controls.Add(mainLayout);

            // ========== Header Section ==========
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Fill;
            headerPanel.BackColor = Color.Transparent;
            mainLayout.Controls.Add(headerPanel, 0, 0);

            // Welcome title
            Label lblWelcome = new Label();
            lblWelcome.Text = $"👋 Xin chào, {AuthContext.Username}!";
            lblWelcome.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblWelcome.AutoSize = true;
            lblWelcome.ForeColor = Color.FromArgb(30, 41, 59); // Slate-800
            lblWelcome.Location = new Point(0, 10);
            headerPanel.Controls.Add(lblWelcome);

            // Role badge
            Label lblRole = new Label();
            lblRole.Text = AuthContext.Role;
            lblRole.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRole.AutoSize = true;
            lblRole.BackColor = AuthContext.IsAdmin ? Color.FromArgb(99, 102, 241) : Color.FromArgb(16, 185, 129); // Indigo or Emerald
            lblRole.ForeColor = Color.White;
            lblRole.Padding = new Padding(10, 5, 10, 5);
            lblRole.Location = new Point(0, 60);
            headerPanel.Controls.Add(lblRole);

            // Subtitle
            Label lblSub = new Label();
            lblSub.Text = "Chọn chức năng bên dưới để bắt đầu làm việc";
            lblSub.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblSub.AutoSize = true;
            lblSub.ForeColor = Color.FromArgb(100, 116, 139); // Slate-500
            lblSub.Location = new Point(0, 100);
            headerPanel.Controls.Add(lblSub);

            // ========== Stats Bar ==========
            Panel statsPanel = new Panel();
            statsPanel.Dock = DockStyle.Fill;
            statsPanel.BackColor = Color.Transparent;
            mainLayout.Controls.Add(statsPanel, 0, 1);

            lblStats = new Label();
            lblStats.Text = "📊 Đang tải thống kê...";
            lblStats.Font = new Font("Segoe UI", 11, FontStyle.Italic);
            lblStats.AutoSize = true;
            lblStats.ForeColor = Color.FromArgb(71, 85, 105); // Slate-600
            lblStats.Location = new Point(0, 10);
            statsPanel.Controls.Add(lblStats);

            // ========== Cards Area ==========
            flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.AutoScroll = true;
            flowPanel.WrapContents = true;
            flowPanel.BackColor = Color.Transparent;
            flowPanel.Padding = new Padding(0, 10, 0, 0);
            
            mainLayout.Controls.Add(flowPanel, 0, 2);

            this.Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadQuickActions();
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                using (var db = new SurveyDbContext())
                {
                    int svCount = db.SinhViens.Count();
                    int dnCount = db.DoanhNghieps.Count();
                    int lsCount = db.LichSuCongTacs.Count();
                    int choXacThuc = db.LichSuCongTacs.Count(x => x.TrangThaiXacThuc == "Chưa xác thực");

                    lblStats.Text = $"📊 Thống kê: {svCount} sinh viên | {dnCount} doanh nghiệp | {lsCount} lịch sử việc làm | {choXacThuc} đang chờ xác thực";
                }
            }
            catch
            {
                lblStats.Text = "📊 Không thể tải thống kê";
            }
        }

        private void LoadQuickActions()
        {
            flowPanel.Controls.Clear();

            // Admin actions
            if (AuthContext.IsAdmin)
            {
                AddCard("👥", "Quản lý Sinh viên", "Xem, thêm, sửa đổi hồ sơ sinh viên", 
                    Color.FromArgb(20, 184, 166), // Teal-500
                    () => _mainForm.OpenChildInternal(new QuanLySinhVien()));

                AddCard("✅", "Gửi yêu cầu xác thực", "Gửi yêu cầu xác thực việc làm đến doanh nghiệp", 
                    Color.FromArgb(249, 115, 22), // Orange-500
                    () => _mainForm.OpenChildInternal(new XuLyXacThucForm()));

                AddCard("📋", "Gửi Khảo sát", "Gửi mẫu phiếu khảo sát cho sinh viên", 
                    Color.FromArgb(59, 130, 246), // Blue-500
                    () => _mainForm.OpenChildInternal(new GuiKhaoSatForm()));

                AddCard("📝", "Quản lý đợt khảo sát", "Tạo và quản lý các đợt khảo sát", 
                    Color.FromArgb(234, 88, 12), // Orange-600
                    () => _mainForm.OpenChildInternal(new QuanLyPhieuKhaoSatForm()));

                AddCard("🔑", "Quản lý hệ thống", "Quản lý các thông tin liên quan đến hệ thống", 
                    Color.FromArgb(168, 85, 247), // Purple-500
                    () => _mainForm.OpenChildInternal(new QuanLyTaiKhoanForm()));

                AddCard("📈", "Báo cáo Thống kê", "Xem biểu đồ tình hình việc làm", 
                    Color.FromArgb(139, 92, 246), // Violet-500
                    () => _mainForm.OpenChildInternal(new BaoCaoThongKeForm()));

                AddCard("📧", "Gửi Thông báo", "Gửi email định kỳ cho sinh viên", 
                    Color.FromArgb(6, 182, 212), // Cyan-500
                    () => _mainForm.OpenChildInternal(new GuiThongBaoForm()));
            }

            // Student actions
            if (AuthContext.IsStudent)
            {
                AddCard("💼", "Cập nhật Việc làm", "Khai báo thông tin việc làm mới nhất", 
                    Color.FromArgb(34, 197, 94), // Green-500
                    () => _mainForm.OpenChildInternal(new StudentDashboardForm()));
                
                AddCard("📝", "Trả lời Khảo sát", "Điền phiếu khảo sát nhà trường yêu cầu", 
                    Color.FromArgb(59, 130, 246), // Blue-500
                    () => _mainForm.OpenChildInternal(new GuiKhaoSatForm()));
            }
        }

        private void AddCard(string icon, string title, string desc, Color accentColor, Action action)
        {
            // Create a custom panel as a card
            Panel card = new Panel();
            card.Size = new Size(280, 160);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 20, 20);
            card.Cursor = Cursors.Hand;
            card.Tag = action;

            // Add shadow effect using Paint event
            card.Paint += (s, e) =>
            {
                // Draw subtle border
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1)) // Slate-200
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
                
                // Draw accent line at top
                using (SolidBrush brush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, card.Width, 4);
                }
            };

            // Icon label
            Label lblIcon = new Label();
            lblIcon.Text = icon;
            lblIcon.Font = new Font("Segoe UI Emoji", 32, FontStyle.Regular);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(20, 20);
            lblIcon.BackColor = Color.Transparent;
            card.Controls.Add(lblIcon);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59); // Slate-800
            lblTitle.Location = new Point(20, 75);
            lblTitle.BackColor = Color.Transparent;
            card.Controls.Add(lblTitle);

            // Description
            Label lblDesc = new Label();
            lblDesc.Text = desc;
            lblDesc.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblDesc.AutoSize = false;
            lblDesc.Size = new Size(240, 40);
            lblDesc.ForeColor = Color.FromArgb(100, 116, 139); // Slate-500
            lblDesc.Location = new Point(20, 100);
            lblDesc.BackColor = Color.Transparent;
            card.Controls.Add(lblDesc);

            // Hover effects
            card.MouseEnter += (s, e) => 
            {
                card.BackColor = Color.FromArgb(248, 250, 252); // Slate-50
            };
            card.MouseLeave += (s, e) => 
            {
                card.BackColor = Color.White;
            };

            // Propagate hover to children
            foreach (Control ctrl in card.Controls)
            {
                ctrl.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(248, 250, 252);
                ctrl.MouseLeave += (s, e) => card.BackColor = Color.White;
                ctrl.Click += (s, e) => action();
            }

            card.Click += (s, e) => action();
            
            flowPanel.Controls.Add(card);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(238, 242, 255), // Indigo-50
                Color.FromArgb(224, 231, 255), // Indigo-100
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
