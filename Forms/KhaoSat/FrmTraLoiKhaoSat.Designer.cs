namespace QuanLySinhVien
{
    partial class FrmTraLoiKhaoSat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblChonMau;
        private System.Windows.Forms.ComboBox cboMauKhaoSat;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.lblChonMau = new System.Windows.Forms.Label();
            this.cboMauKhaoSat = new System.Windows.Forms.ComboBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(280, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Khảo sát việc làm";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(22, 65);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(80, 20);
            this.lblMaSV.TabIndex = 1;
            this.lblMaSV.Text = "Mã SV: ...";
            // 
            // lblChonMau
            // 
            this.lblChonMau.AutoSize = true;
            this.lblChonMau.Location = new System.Drawing.Point(22, 110);
            this.lblChonMau.Name = "lblChonMau";
            this.lblChonMau.Size = new System.Drawing.Size(149, 20);
            this.lblChonMau.TabIndex = 2;
            this.lblChonMau.Text = "Chọn phiếu khảo sát:";
            // 
            // cboMauKhaoSat
            // 
            this.cboMauKhaoSat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauKhaoSat.FormattingEnabled = true;
            this.cboMauKhaoSat.Location = new System.Drawing.Point(26, 140);
            this.cboMauKhaoSat.Name = "cboMauKhaoSat";
            this.cboMauKhaoSat.Size = new System.Drawing.Size(350, 28);
            this.cboMauKhaoSat.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(380, 139);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 30);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "↻";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Location = new System.Drawing.Point(22, 185);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(101, 20);
            this.lblThongBao.TabIndex = 4;
            this.lblThongBao.Text = "Đang tải...";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.DimGray;
            this.lblTrangThai.Location = new System.Drawing.Point(22, 185);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(200, 22);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái: Đang kiểm tra...";
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(26, 230);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(180, 40);
            this.btnBatDau.TabIndex = 5;
            this.btnBatDau.Text = "▶ Bắt đầu khảo sát";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(230, 230);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmTraLoiKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblMaSV);
            this.Controls.Add(this.lblChonMau);
            this.Controls.Add(this.cboMauKhaoSat);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTraLoiKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn phiếu khảo sát";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
