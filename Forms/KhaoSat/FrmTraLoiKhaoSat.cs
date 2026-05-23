using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;

namespace QuanLySinhVien
{
    public partial class FrmTraLoiKhaoSat : Form
    {
        private string _maSV;
        private List<PhieuKhaoSat> _danhSachPhieu;

        public FrmTraLoiKhaoSat(string maSV)
        {
            InitializeComponent();
            _maSV = maSV;
            this.Load += FrmTraLoiKhaoSat_Load;
            
            // Đăng ký sự kiện
            this.cboMauKhaoSat.SelectedIndexChanged += CboMauKhaoSat_SelectedIndexChanged;
            this.btnRefresh.Click += (s, e) => LoadDanhSachPhieuKhaoSat();
        }

        private void FrmTraLoiKhaoSat_Load(object sender, EventArgs e)
        {
            lblMaSV.Text = "Mã SV: " + _maSV;
            LoadDanhSachPhieuKhaoSat();
        }

        private void LoadDanhSachPhieuKhaoSat()
        {
            try
            {
                using (var db = new SurveyDbContext())
                {
                    // Lấy các phiếu khảo sát đang hoạt động (TrangThaiPhieu = 'Đang mở' hoặc null)
                    _danhSachPhieu = db.PhieuKhaoSats
                        .Where(p => p.TrangThaiPhieu == "Đang mở" || p.TrangThaiPhieu == null || p.TrangThaiPhieu == "")
                        .Where(p => p.NgayHetHan == null || p.NgayHetHan >= DateTime.Today)
                        .OrderByDescending(p => p.NgayTao)
                        .ToList();

                    cboMauKhaoSat.DisplayMember = "TenDotKhaoSat";
                    cboMauKhaoSat.ValueMember = "MaPhieu";
                    cboMauKhaoSat.DataSource = _danhSachPhieu;

                    if (_danhSachPhieu.Count == 0)
                    {
                        lblThongBao.Text = "Hiện tại không có phiếu khảo sát nào.";
                        lblThongBao.ForeColor = Color.Orange;
                        btnBatDau.Enabled = false;
                        lblTrangThai.Text = "";
                    }
                    else
                    {
                        lblThongBao.Text = $"Có {_danhSachPhieu.Count} phiếu khảo sát đang hoạt động.";
                        lblThongBao.ForeColor = Color.Green;
                        btnBatDau.Enabled = true;
                        
                        // Trigger check status for first item
                        if (cboMauKhaoSat.SelectedValue is int maPhieu)
                        {
                            CheckTrangThaiKhaoSat(maPhieu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi tải danh sách khảo sát: " + root.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboMauKhaoSat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMauKhaoSat.SelectedValue is int maPhieu)
            {
                CheckTrangThaiKhaoSat(maPhieu);
            }
        }

        private void CheckTrangThaiKhaoSat(int maPhieu)
        {
            try
            {
                using (var db = new SurveyDbContext())
                {
                    var ketQua = db.KetQuaKhaoSats
                        .FirstOrDefault(k => k.MaSV == _maSV && k.MaPhieu == maPhieu);

                    if (ketQua != null)
                    {
                        lblTrangThai.Text = $"✅ Đã hoàn thành (Ngày: {ketQua.NgayTraLoi:dd/MM/yyyy})";
                        lblTrangThai.ForeColor = Color.Green;
                        btnBatDau.Text = "Xem lại / Cập nhật";
                    }
                    else
                    {
                        lblTrangThai.Text = "⚠️ Chưa thực hiện";
                        lblTrangThai.ForeColor = Color.OrangeRed;
                        btnBatDau.Text = "▶ Bắt đầu khảo sát";
                    }
                }
            }
            catch
            {
                lblTrangThai.Text = "Trạng thái: Không rõ";
                lblTrangThai.ForeColor = Color.Gray;
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (cboMauKhaoSat.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu khảo sát.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maPhieu = (int)cboMauKhaoSat.SelectedValue;
            
            try
            {
                using (var db = new SurveyDbContext())
                {
                    // Kiểm tra xem sinh viên đã làm khảo sát này chưa
                    var daLam = db.KetQuaKhaoSats
                        .Any(k => k.MaSV == _maSV && k.MaPhieu == maPhieu);

                    if (daLam)
                    {
                        var result = MessageBox.Show(
                            "Bạn đã làm khảo sát này rồi. Bạn có muốn làm lại không?",
                            "Đã có kết quả",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                            return;
                    }

                    // Mở form điền khảo sát chi tiết
                    using (var frmDien = new FrmDienKhaoSat(maPhieu, _maSV))
                    {
                        frmDien.ShowDialog();
                        // Reload lại danh sách sau khi hoàn thành
                        LoadDanhSachPhieuKhaoSat();
                    }
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi: " + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
