using System.Windows.Forms;

namespace QuanLySinhVien
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip1;
        
        // Menu 1: Thu thập và cập nhật thông tin
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuGuiPhieuKhaoSat;
        private ToolStripMenuItem mnuTiepNhanThongTin;
        private ToolStripMenuItem mnuCapNhatLichSuLamViec;
        
        // Menu 2: Quản lý và theo dõi hồ sơ
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuQLSinhVien;
        private ToolStripMenuItem mnuQLDoanhNghiep;
        private ToolStripMenuItem mnuQLLichSu;
        private ToolStripMenuItem mnuQLPhieuKhaoSat;
        private ToolStripMenuItem mnuQLTaiKhoan;
        
        // Menu 3: Xử lý xác thực (NEW)
        private ToolStripMenuItem mnuXuLyXacThuc2;
        private ToolStripMenuItem mnuGuiYeuCauXacThuc;
        private ToolStripMenuItem mnuXuLyPhanHoiXacThuc;

        
        // Menu 4: Thống kê và báo cáo
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        
        // Menu 5: Tài khoản
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuLogout;
        private ToolStripMenuItem mnuExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            
            // Menu 1: Thu thập và cập nhật thông tin
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuiPhieuKhaoSat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTiepNhanThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCapNhatLichSuLamViec = new System.Windows.Forms.ToolStripMenuItem();
            
            // Menu 2: Quản lý và theo dõi hồ sơ
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLDoanhNghiep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLLichSu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLPhieuKhaoSat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            
            // Menu 3: Xử lý xác thực (NEW)
            this.mnuXuLyXacThuc2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuiYeuCauXacThuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXuLyPhanHoiXacThuc = new System.Windows.Forms.ToolStripMenuItem();

            
            // Menu 4: Thống kê và báo cáo
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCaoThongKe = new System.Windows.Forms.ToolStripMenuItem();
            
            // Menu 5: Tài khoản
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanLy,
            this.mnuXuLyXacThuc2,
            this.mnuNghiepVu,
            this.mnuBaoCao});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong - Thu thập và cập nhật thông tin
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuiPhieuKhaoSat,
            this.mnuTiepNhanThongTin,
            this.mnuCapNhatLichSuLamViec});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(220, 29);
            this.mnuHeThong.Text = "Thu thập và cập nhật thông tin";
            // 
            // mnuGuiPhieuKhaoSat
            // 
            this.mnuGuiPhieuKhaoSat.Name = "mnuGuiPhieuKhaoSat";
            this.mnuGuiPhieuKhaoSat.Size = new System.Drawing.Size(350, 34);
            this.mnuGuiPhieuKhaoSat.Text = "Gửi phiếu khảo sát việc làm...";
            this.mnuGuiPhieuKhaoSat.Click += new System.EventHandler(this.mnuGuiPhieuKhaoSat_Click);
            // 
            // mnuTiepNhanThongTin
            // 
            this.mnuTiepNhanThongTin.Name = "mnuTiepNhanThongTin";
            this.mnuTiepNhanThongTin.Size = new System.Drawing.Size(350, 34);
            this.mnuTiepNhanThongTin.Text = "Tiếp nhận thông tin sinh viên tự khai báo...";
            this.mnuTiepNhanThongTin.Click += new System.EventHandler(this.mnuTiepNhanThongTin_Click);
            // 
            // mnuCapNhatLichSuLamViec
            // 
            this.mnuCapNhatLichSuLamViec.Name = "mnuCapNhatLichSuLamViec";
            this.mnuCapNhatLichSuLamViec.Size = new System.Drawing.Size(350, 34);
            this.mnuCapNhatLichSuLamViec.Text = "Cập nhật lịch sử làm việc...";
            this.mnuCapNhatLichSuLamViec.Click += new System.EventHandler(this.mnuCapNhatLichSuLamViec_Click);
            // 
            // mnuQuanLy - Quản lý và theo dõi hồ sơ
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQLSinhVien,
            this.mnuQLDoanhNghiep,
            this.mnuQLLichSu,
            this.mnuQLPhieuKhaoSat,
            this.mnuQLTaiKhoan});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(180, 29);
            this.mnuQuanLy.Text = "Quản lý và theo dõi hồ sơ";
            // 
            // mnuQLSinhVien
            // 
            this.mnuQLSinhVien.Name = "mnuQLSinhVien";
            this.mnuQLSinhVien.Size = new System.Drawing.Size(323, 34);
            this.mnuQLSinhVien.Text = "Quản lý hồ sơ cựu sinh viên";
            this.mnuQLSinhVien.Click += new System.EventHandler(this.mnuQLSinhVien_Click);
            // 
            // mnuQLDoanhNghiep
            // 
            this.mnuQLDoanhNghiep.Name = "mnuQLDoanhNghiep";
            this.mnuQLDoanhNghiep.Size = new System.Drawing.Size(323, 34);
            this.mnuQLDoanhNghiep.Text = "Quản lý hồ sơ doanh nghiệp";
            this.mnuQLDoanhNghiep.Click += new System.EventHandler(this.mnuQLDoanhNghiep_Click);
            // 
            // mnuQLLichSu
            // 
            this.mnuQLLichSu.Name = "mnuQLLichSu";
            this.mnuQLLichSu.Size = new System.Drawing.Size(323, 34);
            this.mnuQLLichSu.Text = "Quản lý lịch sử công tác của sinh viên";
            this.mnuQLLichSu.Click += new System.EventHandler(this.mnuQLLichSu_Click);
            // 
            // mnuQLPhieuKhaoSat
            // 
            this.mnuQLPhieuKhaoSat.Name = "mnuQLPhieuKhaoSat";
            this.mnuQLPhieuKhaoSat.Size = new System.Drawing.Size(323, 34);
            this.mnuQLPhieuKhaoSat.Text = "Quản lý mẫu phiếu khảo sát";
            this.mnuQLPhieuKhaoSat.Click += new System.EventHandler(this.mnuQLPhieuKhaoSat_Click);
            // 
            // mnuQLTaiKhoan
            // 
            this.mnuQLTaiKhoan.Name = "mnuQLTaiKhoan";
            this.mnuQLTaiKhoan.Size = new System.Drawing.Size(323, 34);
            this.mnuQLTaiKhoan.Text = "Quản trị hệ thống";
            this.mnuQLTaiKhoan.Click += new System.EventHandler(this.mnuQLTaiKhoan_Click);
            // 
            // mnuXuLyXacThuc2 - Xử lý xác thực (NEW MENU)
            // 
            this.mnuXuLyXacThuc2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuiYeuCauXacThuc,
            this.mnuXuLyPhanHoiXacThuc});
            this.mnuXuLyXacThuc2.Name = "mnuXuLyXacThuc2";
            this.mnuXuLyXacThuc2.Size = new System.Drawing.Size(120, 29);
            this.mnuXuLyXacThuc2.Text = "Xử lý xác thực";
            // 
            // mnuGuiYeuCauXacThuc
            // 
            this.mnuGuiYeuCauXacThuc.Name = "mnuGuiYeuCauXacThuc";
            this.mnuGuiYeuCauXacThuc.Size = new System.Drawing.Size(280, 34);
            this.mnuGuiYeuCauXacThuc.Text = "Gửi yêu cầu xác thực...";
            this.mnuGuiYeuCauXacThuc.Click += new System.EventHandler(this.mnuGuiYeuCauXacThuc_Click);
            // 
            // mnuXuLyPhanHoiXacThuc
            // 
            this.mnuXuLyPhanHoiXacThuc.Name = "mnuXuLyPhanHoiXacThuc";
            this.mnuXuLyPhanHoiXacThuc.Size = new System.Drawing.Size(280, 34);
            this.mnuXuLyPhanHoiXacThuc.Text = "Xử lý phản hồi xác thực...";
            this.mnuXuLyPhanHoiXacThuc.Click += new System.EventHandler(this.mnuXuLyPhanHoiXacThuc_Click);
            // 

            // 
            // mnuNghiepVu - Thống kê và báo cáo
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBaoCaoThongKe});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new System.Drawing.Size(150, 29);
            this.mnuNghiepVu.Text = "Thống kê và báo cáo";
            // 
            // mnuBaoCaoThongKe
            // 
            this.mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            this.mnuBaoCaoThongKe.Size = new System.Drawing.Size(353, 34);
            this.mnuBaoCaoThongKe.Text = "Báo cáo thống kê...";
            this.mnuBaoCaoThongKe.Click += new System.EventHandler(this.mnuBaoCaoThongKe_Click);
            // 
            // mnuBaoCao - Tài khoản
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogout,
            this.mnuExit});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(90, 29);
            this.mnuBaoCao.Text = "Tài khoản";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(201, 34);
            this.mnuLogout.Text = "Đăng xuất...";
            this.mnuLogout.Click += new System.EventHandler(this.mnuLogout_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(201, 34);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý việc làm Sinh viên";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
