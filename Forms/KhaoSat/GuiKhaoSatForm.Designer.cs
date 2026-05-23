namespace QuanLySinhVien
{
    partial class GuiKhaoSatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPhieu = new System.Windows.Forms.Label();
            this.cboNamTN = new System.Windows.Forms.ComboBox();
            this.cboPhieu = new System.Windows.Forms.ComboBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.lblNganh = new System.Windows.Forms.Label();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.btnTaiDS = new System.Windows.Forms.Button();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhieu
            // 
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Location = new System.Drawing.Point(20, 20);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(102, 20);
            this.lblPhieu.TabIndex = 0;
            this.lblPhieu.Text = "Đợt khảo sát:";
            // 
            // cboPhieu
            // 
            this.cboPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieu.FormattingEnabled = true;
            this.cboPhieu.Location = new System.Drawing.Point(130, 16);
            this.cboPhieu.Name = "cboPhieu";
            this.cboPhieu.Size = new System.Drawing.Size(400, 28);
            this.cboPhieu.TabIndex = 1;
            // 
            // grpFilter
            // 
            this.grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilter.Controls.Add(this.cboNamTN);
            this.grpFilter.Controls.Add(this.lblNamTN);
            this.grpFilter.Controls.Add(this.cboNganh);
            this.grpFilter.Controls.Add(this.lblNganh);
            this.grpFilter.Controls.Add(this.cboKhoaHoc);
            this.grpFilter.Controls.Add(this.lblKhoa);
            this.grpFilter.Location = new System.Drawing.Point(24, 60);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(950, 80);
            this.grpFilter.TabIndex = 2;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Lọc sinh viên";
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(15, 30);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(50, 20);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Khoa:";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(70, 26);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(160, 28);
            this.cboKhoaHoc.TabIndex = 1;
            // 
            // lblNganh
            // 
            this.lblNganh.AutoSize = true;
            this.lblNganh.Location = new System.Drawing.Point(245, 30);
            this.lblNganh.Name = "lblNganh";
            this.lblNganh.Size = new System.Drawing.Size(60, 20);
            this.lblNganh.TabIndex = 2;
            this.lblNganh.Text = "Ngành:";
            // 
            // cboNganh
            // 
            this.cboNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(310, 26);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(200, 28);
            this.cboNganh.TabIndex = 3;
            // 
            // btnTaiDS
            // 
            this.btnTaiDS.Location = new System.Drawing.Point(830, 24);
            this.btnTaiDS.Name = "btnTaiDS";
            this.btnTaiDS.Size = new System.Drawing.Size(110, 32);
            this.btnTaiDS.TabIndex = 6;
            this.btnTaiDS.Text = "Lọc / Tải lại";
            this.btnTaiDS.UseVisualStyleBackColor = true;
            this.btnTaiDS.Click += new System.EventHandler(this.btnTaiDS_Click);
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSinhVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(24, 190);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = false;
            this.dgvSinhVien.RowTemplate.Height = 28;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(950, 300);
            this.dgvSinhVien.TabIndex = 3;
            this.dgvSinhVien.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellValueChanged);
            this.dgvSinhVien.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSinhVien_CurrentCellDirtyStateChanged);
            // 
            // lblNamTN
            // 
            this.lblNamTN = new System.Windows.Forms.Label();
            this.lblNamTN.AutoSize = true;
            this.lblNamTN.Location = new System.Drawing.Point(520, 30);
            this.lblNamTN.Name = "lblNamTN";
            this.lblNamTN.Size = new System.Drawing.Size(70, 20);
            this.lblNamTN.TabIndex = 4;
            this.lblNamTN.Text = "Năm TN:";
            // 
            // cboNamTN
            // 
            this.cboNamTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamTN.FormattingEnabled = true;
            this.cboNamTN.Location = new System.Drawing.Point(600, 26);
            this.cboNamTN.Name = "cboNamTN";
            this.cboNamTN.Size = new System.Drawing.Size(120, 28);
            this.cboNamTN.TabIndex = 5;
            // 
            // grpFilter Controls Update
            // 
            this.grpFilter.Controls.Add(this.cboNamTN);
            this.grpFilter.Controls.Add(this.lblNamTN);
            // 
            // btnGui
            // 
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.Location = new System.Drawing.Point(834, 506);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(140, 40);
            this.btnGui.TabIndex = 4;
            this.btnGui.Text = "Gửi khảo sát";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(648, 506);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(180, 40);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "← Quay về Dashboard";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(24, 150);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(280, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(400, 152);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(100, 24);
            this.chkSelectAll.TabIndex = 8;
            this.chkSelectAll.Text = "Chọn tất cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSelectedCount.Location = new System.Drawing.Point(520, 152);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(120, 23);
            this.lblSelectedCount.TabIndex = 9;
            this.lblSelectedCount.Text = "Đã chọn: 0";
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Chọn";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // GuiKhaoSatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.btnTaiDS);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.cboPhieu);
            this.Controls.Add(this.lblPhieu);
            this.Name = "GuiKhaoSatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gửi Phiếu Khảo Sát";
            this.Load += new System.EventHandler(this.GuiKhaoSatForm_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.ComboBox cboPhieu;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label lblNganh;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Button btnTaiDS;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.Label lblNamTN;
        private System.Windows.Forms.ComboBox cboNamTN;
    }
}
