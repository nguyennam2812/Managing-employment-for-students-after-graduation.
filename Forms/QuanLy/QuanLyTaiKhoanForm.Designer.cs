namespace QuanLySinhVien
{
    partial class QuanLyTaiKhoanForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTaiKhoan;
        private System.Windows.Forms.TabPage tabDotKhaoSat;
        
        // Tab 1: Quản lý tài khoản
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnThoat;
        
        // Tab 2: Quản lý đợt khảo sát
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Panel pnlFilterPhieu;
        private System.Windows.Forms.Panel pnlButtonsPhieu;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchPhieu;
        private System.Windows.Forms.Button btnThemPhieu;
        private System.Windows.Forms.Button btnSuaPhieu;
        private System.Windows.Forms.Button btnXoaPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnDesignPhieu;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();
            this.tabDotKhaoSat = new System.Windows.Forms.TabPage();
            
            // Tab 1 controls
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            
            // Tab 2 controls
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.pnlFilterPhieu = new System.Windows.Forms.Panel();
            this.pnlButtonsPhieu = new System.Windows.Forms.Panel();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchPhieu = new System.Windows.Forms.Button();
            this.btnThemPhieu = new System.Windows.Forms.Button();
            this.btnSuaPhieu = new System.Windows.Forms.Button();
            this.btnXoaPhieu = new System.Windows.Forms.Button();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnDesignPhieu = new System.Windows.Forms.Button();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtTenDot = new System.Windows.Forms.TextBox();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblTenDot = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            
            this.tabControl.SuspendLayout();
            this.tabTaiKhoan.SuspendLayout();
            this.tabDotKhaoSat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.panelTop.SuspendLayout();
            this.pnlFilterPhieu.SuspendLayout();
            this.pnlButtonsPhieu.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTaiKhoan);
            this.tabControl.Controls.Add(this.tabDotKhaoSat);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 0;
            
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.grid);
            this.tabTaiKhoan.Controls.Add(this.panelTop);
            this.tabTaiKhoan.Location = new System.Drawing.Point(4, 29);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaiKhoan.Size = new System.Drawing.Size(992, 567);
            this.tabTaiKhoan.TabIndex = 0;
            this.tabTaiKhoan.Text = "Quản lý tài khoản";
            this.tabTaiKhoan.UseVisualStyleBackColor = true;
            
            // 
            // tabDotKhaoSat
            // 
            this.tabDotKhaoSat.Controls.Add(this.grpChiTiet);
            this.tabDotKhaoSat.Controls.Add(this.dgvPhieu);
            this.tabDotKhaoSat.Controls.Add(this.pnlFilterPhieu);
            this.tabDotKhaoSat.Controls.Add(this.pnlButtonsPhieu);
            this.tabDotKhaoSat.Location = new System.Drawing.Point(4, 29);
            this.tabDotKhaoSat.Name = "tabDotKhaoSat";
            this.tabDotKhaoSat.Padding = new System.Windows.Forms.Padding(3);
            this.tabDotKhaoSat.Size = new System.Drawing.Size(992, 567);
            this.tabDotKhaoSat.TabIndex = 1;
            this.tabDotKhaoSat.Text = "Quản lý đợt khảo sát";
            this.tabDotKhaoSat.UseVisualStyleBackColor = true;
            
            // 
            // grid (Tab 1)
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 63);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(986, 501);
            this.grid.TabIndex = 0;
            
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnThoat);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(986, 60);
            this.panelTop.TabIndex = 1;
            
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(108, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(189, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(280, 14);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 32);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            
            // 
            // pnlFilterPhieu (Tab 2)
            // 
            this.pnlFilterPhieu.Controls.Add(this.txtSearch);
            this.pnlFilterPhieu.Controls.Add(this.btnSearchPhieu);
            this.pnlFilterPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterPhieu.Location = new System.Drawing.Point(3, 3);
            this.pnlFilterPhieu.Name = "pnlFilterPhieu";
            this.pnlFilterPhieu.Size = new System.Drawing.Size(986, 50);
            this.pnlFilterPhieu.TabIndex = 0;
            
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 0;
            
            // 
            // btnSearchPhieu
            // 
            this.btnSearchPhieu.Location = new System.Drawing.Point(270, 10);
            this.btnSearchPhieu.Name = "btnSearchPhieu";
            this.btnSearchPhieu.Size = new System.Drawing.Size(90, 30);
            this.btnSearchPhieu.TabIndex = 1;
            this.btnSearchPhieu.Text = "Tìm kiếm";
            this.btnSearchPhieu.UseVisualStyleBackColor = true;
            this.btnSearchPhieu.Click += new System.EventHandler(this.btnSearchPhieu_Click);
            
            // 
            // dgvPhieu (Tab 2)
            // 
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPhieu.Location = new System.Drawing.Point(3, 53);
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.RowTemplate.Height = 28;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Size = new System.Drawing.Size(986, 200);
            this.dgvPhieu.TabIndex = 1;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            
            // 
            // grpChiTiet (Tab 2)
            // 
            this.grpChiTiet.Controls.Add(this.lblMaPhieu);
            this.grpChiTiet.Controls.Add(this.txtMaPhieu);
            this.grpChiTiet.Controls.Add(this.lblTenDot);
            this.grpChiTiet.Controls.Add(this.txtTenDot);
            this.grpChiTiet.Controls.Add(this.lblNgayTao);
            this.grpChiTiet.Controls.Add(this.dtpNgayTao);
            this.grpChiTiet.Controls.Add(this.lblNgayHetHan);
            this.grpChiTiet.Controls.Add(this.dtpNgayHetHan);
            this.grpChiTiet.Controls.Add(this.lblTrangThai);
            this.grpChiTiet.Controls.Add(this.cboTrangThai);
            this.grpChiTiet.Controls.Add(this.btnDesignPhieu);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Location = new System.Drawing.Point(3, 253);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(986, 251);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết phiếu khảo sát";
            
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(15, 30);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(67, 20);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "Mã phiếu:";
            
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Location = new System.Drawing.Point(140, 27);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(100, 26);
            this.txtMaPhieu.TabIndex = 1;
            
            // 
            // lblTenDot
            // 
            this.lblTenDot.AutoSize = true;
            this.lblTenDot.Location = new System.Drawing.Point(15, 65);
            this.lblTenDot.Name = "lblTenDot";
            this.lblTenDot.Size = new System.Drawing.Size(107, 20);
            this.lblTenDot.TabIndex = 2;
            this.lblTenDot.Text = "Tên đợt khảo sát:";
            
            // 
            // txtTenDot
            // 
            this.txtTenDot.Location = new System.Drawing.Point(140, 62);
            this.txtTenDot.Name = "txtTenDot";
            this.txtTenDot.Size = new System.Drawing.Size(500, 26);
            this.txtTenDot.TabIndex = 3;
            
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(15, 100);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(68, 20);
            this.lblNgayTao.TabIndex = 4;
            this.lblNgayTao.Text = "Ngày tạo:";
            
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTao.Location = new System.Drawing.Point(140, 97);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(120, 26);
            this.dtpNgayTao.TabIndex = 5;
            
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.Location = new System.Drawing.Point(290, 100);
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Size = new System.Drawing.Size(94, 20);
            this.lblNgayHetHan.TabIndex = 6;
            this.lblNgayHetHan.Text = "Ngày hết hạn:";
            
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(400, 97);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.Size = new System.Drawing.Size(120, 26);
            this.dtpNgayHetHan.TabIndex = 7;
            
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(15, 135);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(78, 20);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái:";
            
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(140, 132);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(120, 28);
            this.cboTrangThai.TabIndex = 9;
            
            // 
            // btnDesignPhieu
            // 
            this.btnDesignPhieu.Location = new System.Drawing.Point(290, 130);
            this.btnDesignPhieu.Name = "btnDesignPhieu";
            this.btnDesignPhieu.Size = new System.Drawing.Size(150, 32);
            this.btnDesignPhieu.TabIndex = 10;
            this.btnDesignPhieu.Text = "Thiết kế câu hỏi...";
            this.btnDesignPhieu.UseVisualStyleBackColor = true;
            this.btnDesignPhieu.Click += new System.EventHandler(this.btnDesignPhieu_Click);
            
            // 
            // pnlButtonsPhieu (Tab 2)
            // 
            this.pnlButtonsPhieu.Controls.Add(this.btnThemPhieu);
            this.pnlButtonsPhieu.Controls.Add(this.btnSuaPhieu);
            this.pnlButtonsPhieu.Controls.Add(this.btnXoaPhieu);
            this.pnlButtonsPhieu.Controls.Add(this.btnLuuPhieu);
            this.pnlButtonsPhieu.Controls.Add(this.btnHuyPhieu);
            this.pnlButtonsPhieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonsPhieu.Location = new System.Drawing.Point(3, 504);
            this.pnlButtonsPhieu.Name = "pnlButtonsPhieu";
            this.pnlButtonsPhieu.Size = new System.Drawing.Size(986, 60);
            this.pnlButtonsPhieu.TabIndex = 3;
            
            // 
            // btnThemPhieu
            // 
            this.btnThemPhieu.Location = new System.Drawing.Point(12, 14);
            this.btnThemPhieu.Name = "btnThemPhieu";
            this.btnThemPhieu.Size = new System.Drawing.Size(90, 32);
            this.btnThemPhieu.TabIndex = 0;
            this.btnThemPhieu.Text = "Thêm";
            this.btnThemPhieu.UseVisualStyleBackColor = true;
            this.btnThemPhieu.Click += new System.EventHandler(this.btnThemPhieu_Click);
            
            // 
            // btnSuaPhieu
            // 
            this.btnSuaPhieu.Location = new System.Drawing.Point(108, 14);
            this.btnSuaPhieu.Name = "btnSuaPhieu";
            this.btnSuaPhieu.Size = new System.Drawing.Size(90, 32);
            this.btnSuaPhieu.TabIndex = 1;
            this.btnSuaPhieu.Text = "Sửa";
            this.btnSuaPhieu.UseVisualStyleBackColor = true;
            this.btnSuaPhieu.Click += new System.EventHandler(this.btnSuaPhieu_Click);
            
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Location = new System.Drawing.Point(204, 14);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.Size = new System.Drawing.Size(90, 32);
            this.btnXoaPhieu.TabIndex = 2;
            this.btnXoaPhieu.Text = "Xóa";
            this.btnXoaPhieu.UseVisualStyleBackColor = true;
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Location = new System.Drawing.Point(320, 14);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(90, 32);
            this.btnLuuPhieu.TabIndex = 3;
            this.btnLuuPhieu.Text = "Lưu";
            this.btnLuuPhieu.UseVisualStyleBackColor = true;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.Location = new System.Drawing.Point(416, 14);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(90, 32);
            this.btnHuyPhieu.TabIndex = 4;
            this.btnHuyPhieu.Text = "Hủy";
            this.btnHuyPhieu.UseVisualStyleBackColor = true;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            
            // 
            // QuanLyTaiKhoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "QuanLyTaiKhoanForm";
            this.Text = "Quản trị hệ thống";
            this.Load += new System.EventHandler(this.QuanLyTaiKhoanForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTaiKhoan.ResumeLayout(false);
            this.tabDotKhaoSat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.pnlFilterPhieu.ResumeLayout(false);
            this.pnlFilterPhieu.PerformLayout();
            this.pnlButtonsPhieu.ResumeLayout(false);
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

