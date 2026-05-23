using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLySinhVien.Security;
using QuanLySinhVien.Data;

namespace QuanLySinhVien
{
    public partial class MainForm : Form
    {
        private Panel pnlContent;

        public MainForm()
        {
            InitializeComponent();
            
            // Set icon từ file PNG
            SetAppIcon();

            // Setup giao diện SPA (Single Page Application) thay vì MDI
            this.IsMdiContainer = false;
            pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            this.Controls.Add(pnlContent);
            pnlContent.BringToFront(); // Đảm bảo đè lên background nhưng cần kiểm tra menu
            
            // MenuStrip thường dock Top, để đảm bảo nó hiển thị:
            foreach (Control c in this.Controls)
            {
                if (c is MenuStrip) 
                {
                    c.Dock = DockStyle.Top;
                    c.SendToBack(); // Trong Dock layout, send to back = ưu tiên dock trước (outermost)
                }
            }
            pnlContent.BringToFront(); // Panel fill phần còn lại

            // Delay phân quyền đến khi form load xong
            this.Load += MainForm_Load;
        }

        private void SetAppIcon()
        {
            try
            {
                var iconPath = Path.Combine(Application.StartupPath, "Images", "image.png");
                if (File.Exists(iconPath))
                {
                    using (var bmp = new Bitmap(iconPath))
                    {
                        this.Icon = Icon.FromHandle(bmp.GetHicon());
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi nếu không load được icon
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyRolePermissions();
                StyleMenu();
                
                // Mở Dashboard mặc định
                OpenChildInternal(new DashboardForm(this));
            }
            catch
            {
                // Bỏ qua lỗi phân quyền
            }
        }

        private void StyleMenu()
        {
            // Style the menu strip with modern colors
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); // Slate-800
            menuStrip1.ForeColor = System.Drawing.Color.White;
            menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 10, System.Drawing.FontStyle.Bold);
            menuStrip1.Padding = new Padding(5, 5, 5, 5);
            
            // Use custom renderer for proper dark theme
            menuStrip1.Renderer = new DarkMenuRenderer();
            
            // Style each top-level menu item
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = System.Drawing.Color.White;
                item.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
                item.Padding = new Padding(10, 5, 10, 5);
                
                // Style dropdown items
                foreach (ToolStripItem dropItem in item.DropDownItems)
                {
                    if (dropItem is ToolStripMenuItem menuItem)
                    {
                        menuItem.BackColor = System.Drawing.Color.White;
                        menuItem.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
                        menuItem.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                        menuItem.Padding = new Padding(5, 5, 5, 5);
                    }
                }
            }
            
            // Style pnlContent background
            if (pnlContent != null)
            {
                pnlContent.BackColor = System.Drawing.Color.FromArgb(241, 245, 249); // Slate-100
            }
        }
        
        /// <summary>
        /// Custom renderer for dark themed menu
        /// </summary>
        private class DarkMenuRenderer : ToolStripProfessionalRenderer
        {
            private static readonly Color DarkBg = Color.FromArgb(30, 41, 59);
            private static readonly Color HoverBg = Color.FromArgb(51, 65, 85); // Slate-700
            private static readonly Color SelectedBg = Color.FromArgb(71, 85, 105); // Slate-600
            
            public DarkMenuRenderer() : base(new DarkColorTable()) { }
            
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                var item = e.Item;
                var g = e.Graphics;
                var rect = new Rectangle(Point.Empty, item.Size);
                
                // Check if this is a top-level menu item
                bool isTopLevel = item.OwnerItem == null;
                
                Color backColor;
                if (isTopLevel)
                {
                    // Top-level: dark background
                    if (item.Selected || item.Pressed)
                        backColor = HoverBg;
                    else
                        backColor = DarkBg;
                }
                else
                {
                    // Dropdown: light background
                    if (item.Selected)
                        backColor = Color.FromArgb(224, 231, 255); // Indigo-100
                    else
                        backColor = Color.White;
                }
                
                using (var brush = new SolidBrush(backColor))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                bool isTopLevel = e.Item.OwnerItem == null;
                
                if (isTopLevel)
                {
                    e.TextColor = Color.White;
                }
                else
                {
                    e.TextColor = Color.FromArgb(30, 41, 59); // Slate-800
                }
                
                base.OnRenderItemText(e);
            }
        }
        
        private class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.FromArgb(30, 41, 59);
            public override Color MenuStripGradientEnd => Color.FromArgb(30, 41, 59);
            public override Color MenuItemSelected => Color.FromArgb(51, 65, 85);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(51, 65, 85);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(51, 65, 85);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuBorder => Color.FromArgb(226, 232, 240);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }

        public void OpenChildInternal(Form child)
        {
            // Đóng form hiện tại trong panel (nếu có)
            if (pnlContent.Controls.Count > 0)
            {
                // Lấy control đầu tiên (thường là form)
                var oldForm = pnlContent.Controls[0] as Form;
                if (oldForm != null)
                {
                    oldForm.Close();
                    oldForm.Dispose();
                }
                pnlContent.Controls.Clear();
            }

            // Cấu hình form con để nhúng vào Panel
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            
            // Thêm vào container và hiển thị
            pnlContent.Controls.Add(child);
            pnlContent.Tag = child;
            child.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                // Đóng tất cả child forms trước
                // Đóng form con hiện tại (nếu có)
                if (pnlContent.Controls.Count > 0)
                {
                    var child = pnlContent.Controls[0] as Form;
                    if (child != null) child.Close();
                    pnlContent.Controls.Clear();
                }
                
                // Đóng MainForm và quay về vòng lặp đăng nhập trong Program.cs
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }

        private void mnuQLSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildInternal(new QuanLySinhVien());
        }

        private void mnuQLDoanhNghiep_Click(object sender, EventArgs e)
        {
            OpenChildInternal(new QuanLyDoanhNghiepForm());
        }

        private void mnuQLLichSu_Click(object sender, EventArgs e)
        {
            // Quản lý lịch sử: Xem tất cả
            OpenChildInternal(new QuanLyLichSuForm(false));
        }

        private void mnuQLPhieuKhaoSat_Click(object sender, EventArgs e)
        {
            // REMOVED: Feature consolidated into QuanLyTaiKhoanForm (Tab 2)
            // OpenChildInternal(new QuanLyPhieuKhaoSatForm());
            MessageBox.Show("Tính năng này đã được chuyển sang mục 'Quản trị hệ thống' -> Tab 'Quản lý đợt khảo sát'.", "Thông báo");
        }

        private void mnuQLTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildInternal(new QuanLyTaiKhoanForm());
        }

        private void mnuBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            OpenChildInternal(new BaoCaoThongKeForm());
        }

        // Menu Thu thập và cập nhật thông tin
        private void mnuGuiPhieuKhaoSat_Click(object sender, EventArgs e)
        {
            // Gửi phiếu khảo sát việc làm - sử dụng GuiKhaoSatForm
            OpenChildInternal(new GuiKhaoSatForm());
        }

        private void mnuTiepNhanThongTin_Click(object sender, EventArgs e)
        {
            // Tiếp nhận thông tin sinh viên tự khai báo - sử dụng form riêng
            OpenChildInternal(new TiepNhanTuKhaiBaoForm());
        }

        private void mnuCapNhatLichSuLamViec_Click(object sender, EventArgs e)
        {
            // Cập nhật lịch sử làm việc: Chỉ xem Pending
            OpenChildInternal(new QuanLyLichSuForm(true));
        }

        // Menu Xử lý xác thực (NEW)
        private void mnuGuiYeuCauXacThuc_Click(object sender, EventArgs e)
        {
            // Gửi yêu cầu xác thực - sử dụng XuLyXacThucForm
            OpenChildInternal(new XuLyXacThucForm());
        }

        private void mnuXuLyPhanHoiXacThuc_Click(object sender, EventArgs e)
        {
            // Xử lý phản hồi xác thực - sử dụng XacThucThongTinForm
            OpenChildInternal(new XacThucThongTinForm());
        }




        private void ApplyRolePermissions()
        {
            var isAdmin = AuthContext.IsAdmin;
            var isStudent = AuthContext.IsStudent;

            // Reset Defaults - tất cả menu đều hiện
            if (mnuHeThong != null) mnuHeThong.Visible = true;
            if (mnuQuanLy != null) mnuQuanLy.Visible = true;
            if (mnuXuLyXacThuc2 != null) mnuXuLyXacThuc2.Visible = true;
            if (mnuNghiepVu != null) mnuNghiepVu.Visible = true;
            if (mnuBaoCao != null) mnuBaoCao.Visible = true; // Tài khoản - luôn hiện

            // --- THU THẬP VÀ CẬP NHẬT THÔNG TIN ---
            if (mnuGuiPhieuKhaoSat != null) mnuGuiPhieuKhaoSat.Visible = isAdmin;
            if (mnuTiepNhanThongTin != null) mnuTiepNhanThongTin.Visible = isAdmin;
            if (mnuCapNhatLichSuLamViec != null) mnuCapNhatLichSuLamViec.Visible = isAdmin;

            // --- QUẢN LÝ VÀ THEO DÕI HỒ SƠ ---
            if (mnuQLSinhVien != null) mnuQLSinhVien.Visible = isAdmin;
            if (mnuQLDoanhNghiep != null) mnuQLDoanhNghiep.Visible = isAdmin;
            if (mnuQLLichSu != null) mnuQLLichSu.Visible = isAdmin;
            if (mnuQLPhieuKhaoSat != null) mnuQLPhieuKhaoSat.Visible = false; // MOVED TO SYS ADMIN
            if (mnuQLTaiKhoan != null) mnuQLTaiKhoan.Visible = isAdmin; // Chỉ Admin mới quản lý tài khoản

            // --- XỬ LÝ XÁC THỰC ---
            if (mnuGuiYeuCauXacThuc != null) mnuGuiYeuCauXacThuc.Visible = isAdmin;
            if (mnuXuLyPhanHoiXacThuc != null) mnuXuLyPhanHoiXacThuc.Visible = isAdmin;


            // --- THỐNG KÊ VÀ BÁO CÁO ---
            if (mnuBaoCaoThongKe != null) mnuBaoCaoThongKe.Visible = isAdmin;

            // Nếu là Sinh viên thì ẩn các nhóm quản lý/thống kê
            if (isStudent)
            {
                if (mnuHeThong != null) mnuHeThong.Visible = false;
                if (mnuQuanLy != null) mnuQuanLy.Visible = false;
                if (mnuXuLyXacThuc2 != null) mnuXuLyXacThuc2.Visible = false;
                if (mnuNghiepVu != null) mnuNghiepVu.Visible = false;
            }
        }


        private bool CheckLegacySchema()
        {
            try
            {
                using (var conn = SqlConnectionFactory.CreateDefault())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SinhVien') AND type = 'U') SELECT 1 ELSE SELECT 0";
                        var val = cmd.ExecuteScalar();
                        return val != null && Convert.ToInt32(val) == 1;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
