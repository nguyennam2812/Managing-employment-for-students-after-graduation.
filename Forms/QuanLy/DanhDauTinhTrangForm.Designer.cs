namespace QuanLySinhVien
{
    partial class DanhDauTinhTrangForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDanhDau;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDanhDau = new System.Windows.Forms.Button();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 60);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1000, 540);
            this.grid.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnThoat);
            this.panelTop.Controls.Add(this.lblTinhTrang);
            this.panelTop.Controls.Add(this.cboTinhTrang);
            this.panelTop.Controls.Add(this.btnDanhDau);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 14);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(180, 32);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(260, 20);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(85, 20);
            this.lblTinhTrang.TabIndex = 1;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(360, 16);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(200, 28);
            this.cboTinhTrang.TabIndex = 2;
            // 
            // btnDanhDau
            // 
            this.btnDanhDau.Location = new System.Drawing.Point(580, 14);
            this.btnDanhDau.Name = "btnDanhDau";
            this.btnDanhDau.Size = new System.Drawing.Size(120, 32);
            this.btnDanhDau.TabIndex = 3;
            this.btnDanhDau.Text = "Đánh dấu";
            this.btnDanhDau.UseVisualStyleBackColor = true;
            this.btnDanhDau.Click += new System.EventHandler(this.btnDanhDau_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(676, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(224, 26);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(906, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 32);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DanhDauTinhTrangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelTop);
            this.Name = "DanhDauTinhTrangForm";
            this.Text = "Đánh dấu tình trạng dữ liệu";
            this.Load += new System.EventHandler(this.DanhDauTinhTrangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
