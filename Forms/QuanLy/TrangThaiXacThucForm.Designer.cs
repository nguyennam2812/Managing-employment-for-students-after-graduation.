namespace QuanLySinhVien
{
    partial class TrangThaiXacThucForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblStatsDung;
        private System.Windows.Forms.Label lblStatsSai;
        private System.Windows.Forms.Label lblStatsTotal;

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
            this.lblInfo = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblStatsDung = new System.Windows.Forms.Label();
            this.lblStatsSai = new System.Windows.Forms.Label();
            this.lblStatsTotal = new System.Windows.Forms.Label();
            
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
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
            this.lblInfo.Size = new System.Drawing.Size(350, 28);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Tình trạng dữ liệu xác thực (Chỉ xem)";
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelStats.Controls.Add(this.lblStatsTotal);
            this.panelStats.Controls.Add(this.lblStatsDung);
            this.panelStats.Controls.Add(this.lblStatsSai);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStats.Location = new System.Drawing.Point(0, 540);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1000, 60);
            this.panelStats.TabIndex = 2;
            // 
            // lblStatsTotal
            // 
            this.lblStatsTotal.AutoSize = true;
            this.lblStatsTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatsTotal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblStatsTotal.Location = new System.Drawing.Point(20, 18);
            this.lblStatsTotal.Name = "lblStatsTotal";
            this.lblStatsTotal.Size = new System.Drawing.Size(100, 25);
            this.lblStatsTotal.TabIndex = 0;
            this.lblStatsTotal.Text = "Tong: 0";
            // 
            // lblStatsDung
            // 
            this.lblStatsDung.AutoSize = true;
            this.lblStatsDung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatsDung.ForeColor = System.Drawing.Color.Green;
            this.lblStatsDung.Location = new System.Drawing.Point(200, 18);
            this.lblStatsDung.Name = "lblStatsDung";
            this.lblStatsDung.Size = new System.Drawing.Size(120, 25);
            this.lblStatsDung.TabIndex = 1;
            this.lblStatsDung.Text = "Dung: 0";
            // 
            // lblStatsSai
            // 
            this.lblStatsSai.AutoSize = true;
            this.lblStatsSai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatsSai.ForeColor = System.Drawing.Color.Red;
            this.lblStatsSai.Location = new System.Drawing.Point(400, 18);
            this.lblStatsSai.Name = "lblStatsSai";
            this.lblStatsSai.Size = new System.Drawing.Size(100, 25);
            this.lblStatsSai.TabIndex = 2;
            this.lblStatsSai.Text = "Sai: 0";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 60);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowTemplate.Height = 35;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1000, 480);
            this.dgvKetQua.TabIndex = 1;
            // 
            // TrangThaiXacThucForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.Name = "TrangThaiXacThucForm";
            this.Text = "Danh dau tinh trang du lieu";
            this.Load += new System.EventHandler(this.TrangThaiXacThucForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
