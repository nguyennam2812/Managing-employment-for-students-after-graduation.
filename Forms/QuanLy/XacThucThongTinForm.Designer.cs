namespace QuanLySinhVien
{
    partial class XacThucThongTinForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvPhanHoi;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCapNhatKetQua;
        private System.Windows.Forms.Label lblInfo;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvPhanHoi = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCapNhatKetQua = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnThoat);
            this.panelTop.Controls.Add(this.lblInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 15);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(160, 32);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblInfo.Location = new System.Drawing.Point(250, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(400, 28);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Ghi nh\u1EADn ph\u1EA3n h\u1ED3i x\u00E1c th\u1EF1c t\u1EEB doanh nghi\u1EC7p";
            // 
            // dgvPhanHoi
            // 
            this.dgvPhanHoi.AllowUserToAddRows = false;
            this.dgvPhanHoi.AllowUserToDeleteRows = false;
            this.dgvPhanHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanHoi.Location = new System.Drawing.Point(0, 60);
            this.dgvPhanHoi.MultiSelect = false;
            this.dgvPhanHoi.Name = "dgvPhanHoi";
            this.dgvPhanHoi.RowHeadersVisible = false;
            this.dgvPhanHoi.RowTemplate.Height = 35;
            this.dgvPhanHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanHoi.Size = new System.Drawing.Size(1000, 480);
            this.dgvPhanHoi.TabIndex = 1;
            this.dgvPhanHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhanHoi_CellContentClick);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCapNhatKetQua);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 540);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 60);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCapNhatKetQua
            // 
            this.btnCapNhatKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatKetQua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatKetQua.Location = new System.Drawing.Point(800, 12);
            this.btnCapNhatKetQua.Name = "btnCapNhatKetQua";
            this.btnCapNhatKetQua.Size = new System.Drawing.Size(180, 38);
            this.btnCapNhatKetQua.TabIndex = 0;
            this.btnCapNhatKetQua.Text = "✅ Cập nhật kết quả";
            this.btnCapNhatKetQua.UseVisualStyleBackColor = true;
            this.btnCapNhatKetQua.Click += new System.EventHandler(this.btnCapNhatKetQua_Click);
            // 
            // XacThucThongTinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvPhanHoi);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "XacThucThongTinForm";
            this.Text = "Ghi nhận phản hồi xác thực";
            this.Load += new System.EventHandler(this.XacThucThongTinForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanHoi)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
