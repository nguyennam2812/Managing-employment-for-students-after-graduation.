namespace QuanLySinhVien
{
    partial class QuanLyKetQuaKhaoSatForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.ComboBox cboPhieu;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label lblNganh;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.lblNganh = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboPhieu = new System.Windows.Forms.ComboBox();
            this.lblPhieu = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();

            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnThoat);
            this.pnlFilter.Controls.Add(this.btnLoc);
            this.pnlFilter.Controls.Add(this.cboNganh);
            this.pnlFilter.Controls.Add(this.lblNganh);
            this.pnlFilter.Controls.Add(this.cboKhoaHoc);
            this.pnlFilter.Controls.Add(this.lblKhoa);
            this.pnlFilter.Controls.Add(this.cboPhieu);
            this.pnlFilter.Controls.Add(this.lblPhieu);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1000, 100);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "← Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(580, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(850, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 32);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Location = new System.Drawing.Point(850, 52);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(120, 32);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc kết quả";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboNganh
            // 
            this.cboNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(580, 55);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(250, 28);
            this.cboNganh.TabIndex = 5;
            // 
            // lblNganh
            // 
            this.lblNganh.AutoSize = true;
            this.lblNganh.Location = new System.Drawing.Point(510, 59);
            this.lblNganh.Name = "lblNganh";
            this.lblNganh.Size = new System.Drawing.Size(60, 20);
            this.lblNganh.TabIndex = 4;
            this.lblNganh.Text = "Ngành:";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(340, 55);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(150, 28);
            this.cboKhoaHoc.TabIndex = 3;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(280, 59);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(50, 20);
            this.lblKhoa.TabIndex = 2;
            this.lblKhoa.Text = "Khóa:";
            // 
            // cboPhieu
            // 
            this.cboPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieu.FormattingEnabled = true;
            this.cboPhieu.Location = new System.Drawing.Point(70, 55);
            this.cboPhieu.Name = "cboPhieu";
            this.cboPhieu.Size = new System.Drawing.Size(200, 28);
            this.cboPhieu.TabIndex = 1;
            // 
            // lblPhieu
            // 
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Location = new System.Drawing.Point(12, 59);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(52, 20);
            this.lblPhieu.TabIndex = 0;
            this.lblPhieu.Text = "Phiếu:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvKetQua);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpChiTiet);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 500);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 0);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(650, 500);
            this.dgvKetQua.TabIndex = 0;
            this.dgvKetQua.SelectionChanged += new System.EventHandler(this.dgvKetQua_SelectionChanged);
            // 
            // grpChiTiet
            // 

            this.grpChiTiet.Controls.Add(this.btnXemChiTiet);
            this.grpChiTiet.Controls.Add(this.txtNoiDung);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Location = new System.Drawing.Point(0, 0);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(346, 500);
            this.grpChiTiet.TabIndex = 0;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết trả lời";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDung.Location = new System.Drawing.Point(6, 25);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(334, 420);
            this.txtNoiDung.TabIndex = 0;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemChiTiet.Location = new System.Drawing.Point(50, 455);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(140, 36);
            this.btnXemChiTiet.TabIndex = 1;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);

            // 
            // QuanLyKetQuaKhaoSatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "QuanLyKetQuaKhaoSatForm";
            this.Text = "Quản Lý Kết Quả Khảo Sát";
            this.Load += new System.EventHandler(this.QuanLyKetQuaKhaoSatForm_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
