namespace QuanLySinhVien
{
    partial class QuanLyPhieuKhaoSatForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtTenDot;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label lblTenDot;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblNgayHetHan;
        private System.Windows.Forms.Label lblTrangThai;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnDesign; // Design button
        private System.Windows.Forms.Panel pnlButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.lblTenDot = new System.Windows.Forms.Label();
            this.txtTenDot = new System.Windows.Forms.TextBox();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();

            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(900, 50);
            this.pnlFilter.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(320, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // dgvPhieu
            // 
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.Dock = System.Windows.Forms.DockStyle.Top; // Will likely dock below pnlFilter if added after, or we need to manage Z-order
            this.dgvPhieu.Location = new System.Drawing.Point(0, 50); // Offset Y manually or let Dock handle it
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Size = new System.Drawing.Size(900, 220);
            this.dgvPhieu.TabIndex = 0;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.cboTrangThai);
            this.grpChiTiet.Controls.Add(this.lblTrangThai);
            this.grpChiTiet.Controls.Add(this.dtpNgayHetHan);
            this.grpChiTiet.Controls.Add(this.lblNgayHetHan);
            this.grpChiTiet.Controls.Add(this.dtpNgayTao);
            this.grpChiTiet.Controls.Add(this.lblNgayTao);
            this.grpChiTiet.Controls.Add(this.txtTenDot);
            this.grpChiTiet.Controls.Add(this.lblTenDot);
            this.grpChiTiet.Controls.Add(this.txtMaPhieu);
            this.grpChiTiet.Controls.Add(this.lblMaPhieu);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Location = new System.Drawing.Point(0, 220);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(900, 250);
            this.grpChiTiet.TabIndex = 1;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết phiếu khảo sát";
            
            // lblMaPhieu
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(20, 35);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Text = "Mã phiếu:";
            
            // txtMaPhieu
            this.txtMaPhieu.Location = new System.Drawing.Point(150, 32);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.ReadOnly = true;
            this.txtMaPhieu.Size = new System.Drawing.Size(120, 22);
            this.txtMaPhieu.TabIndex = 0;
            
            // lblTenDot
            this.lblTenDot.AutoSize = true;
            this.lblTenDot.Location = new System.Drawing.Point(20, 70);
            this.lblTenDot.Name = "lblTenDot";
            this.lblTenDot.Text = "Tên đợt khảo sát:";
            
            // txtTenDot
            this.txtTenDot.Location = new System.Drawing.Point(150, 67);
            this.txtTenDot.Name = "txtTenDot";
            this.txtTenDot.Size = new System.Drawing.Size(500, 22);
            this.txtTenDot.TabIndex = 1;
            
            // lblNgayTao
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(20, 105);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Text = "Ngày tạo:";
            
            // dtpNgayTao
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(150, 102);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(130, 22);
            this.dtpNgayTao.TabIndex = 2;
            
            // lblNgayHetHan
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Location = new System.Drawing.Point(310, 105);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Text = "Ngày hết hạn:";
            
            // dtpNgayHetHan
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(420, 102);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(130, 22);
            this.dtpNgayHetHan.TabIndex = 3;
            
            // lblTrangThai
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 140);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái:";
            
            // cboTrangThai
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] { "DANG_MO", "DONG", "HET_HAN", "Đang mở" });
            this.cboTrangThai.Location = new System.Drawing.Point(150, 137);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(130, 24);
            this.cboTrangThai.TabIndex = 4;

            // btnDesign
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnDesign.Location = new System.Drawing.Point(310, 135);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(140, 28);
            this.btnDesign.Text = "Thiết kế câu hỏi...";
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            this.grpChiTiet.Controls.Add(this.btnDesign);

            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDong);
            this.pnlButtons.Controls.Add(this.btnHuy);
            this.pnlButtons.Controls.Add(this.btnLuu);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 470);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(900, 60);
            this.pnlButtons.TabIndex = 2;
            
            // btnThem
            this.btnThem.Location = new System.Drawing.Point(20, 15);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            // btnSua
            this.btnSua.Location = new System.Drawing.Point(110, 15);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            
            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(200, 15);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLuu
            this.btnLuu.Location = new System.Drawing.Point(320, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Enabled = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            
            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(410, 15);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Enabled = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // btnDong
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(720, 15);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 30);
            this.btnDong.Text = "← Quay về Dashboard";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            
            // WinForms Docking: Controls added LAST dock FIRST
            // So we add in reverse order of visual appearance:
            // 1. grpChiTiet (Fill) - added first, fills remaining space
            // 2. dgvPhieu (Top) - added second, docks to top after pnlFilter
            // 3. pnlFilter (Top) - added third, docks to very top
            // 4. pnlButtons (Bottom) - added last, docks to bottom
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.dgvPhieu);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlButtons);
            
            this.Name = "QuanLyPhieuKhaoSatForm";
            this.Text = "Quản lý Phiếu Khảo Sát";
            this.Load += new System.EventHandler(this.QuanLyPhieuKhaoSatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

