namespace QuanLySinhVien
{
    partial class FrmDienKhaoSat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenPhieu;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel pnlBottom;
        
        // Các control mới cho thống kê việc làm
        private System.Windows.Forms.GroupBox grpViecLam;
        private System.Windows.Forms.Label lblMucLuong;
        private System.Windows.Forms.TextBox txtMucLuong;
        private System.Windows.Forms.Label lblDonViTien;
        private System.Windows.Forms.CheckBox chkDungChuyenNganh;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblDoanhNghiep;
        private System.Windows.Forms.TextBox txtDoanhNghiep;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.TextBox txtViTri;
        // Panel cho câu hỏi động
        private System.Windows.Forms.FlowLayoutPanel pnlQuestions;

        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblLinhVuc;
        private System.Windows.Forms.TextBox txtLinhVuc;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button btnTimDN;

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenPhieu = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.grpViecLam = new System.Windows.Forms.GroupBox();
            this.lblDoanhNghiep = new System.Windows.Forms.Label();
            this.txtDoanhNghiep = new System.Windows.Forms.TextBox();
            this.btnTimDN = new System.Windows.Forms.Button(); // Init
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblLinhVuc = new System.Windows.Forms.Label();
            this.txtLinhVuc = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblViTri = new System.Windows.Forms.Label();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.lblMucLuong = new System.Windows.Forms.Label();
            this.txtMucLuong = new System.Windows.Forms.TextBox();
            this.lblDonViTien = new System.Windows.Forms.Label();
            this.chkDungChuyenNganh = new System.Windows.Forms.CheckBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.grpViecLam.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(239, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "📋 Điền khảo sát";
            // 
            // lblTenPhieu
            // 
            this.lblTenPhieu.AutoSize = true;
            this.lblTenPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular);
            this.lblTenPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTenPhieu.Location = new System.Drawing.Point(22, 50);
            this.lblTenPhieu.Name = "lblTenPhieu";
            this.lblTenPhieu.Size = new System.Drawing.Size(150, 26);
            this.lblTenPhieu.TabIndex = 1;
            this.lblTenPhieu.Text = "Tên phiếu khảo sát";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Location = new System.Drawing.Point(22, 80);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(650, 35);
            this.lblHuongDan.TabIndex = 2;
            this.lblHuongDan.Text = "Vui lòng cung cấp thông tin về tình trạng việc làm hiện tại của bạn.";
            // 
            // grpViecLam
            // 
            this.grpViecLam.Controls.Add(this.btnTimDN); // Add Button
            this.grpViecLam.Controls.Add(this.lblDoanhNghiep);
            this.grpViecLam.Controls.Add(this.txtDoanhNghiep);
            this.grpViecLam.Controls.Add(this.lblDiaChi);
            this.grpViecLam.Controls.Add(this.txtDiaChi);
            this.grpViecLam.Controls.Add(this.lblLinhVuc);
            this.grpViecLam.Controls.Add(this.txtLinhVuc);
            this.grpViecLam.Controls.Add(this.lblEmail);
            this.grpViecLam.Controls.Add(this.txtEmail);
            this.grpViecLam.Controls.Add(this.lblSoDienThoai);
            this.grpViecLam.Controls.Add(this.txtSoDienThoai);
            this.grpViecLam.Controls.Add(this.lblViTri);
            this.grpViecLam.Controls.Add(this.txtViTri);
            this.grpViecLam.Controls.Add(this.lblMucLuong);
            this.grpViecLam.Controls.Add(this.txtMucLuong);
            this.grpViecLam.Controls.Add(this.lblDonViTien);
            this.grpViecLam.Controls.Add(this.chkDungChuyenNganh);
            this.grpViecLam.Controls.Add(this.lblTrangThai);
            this.grpViecLam.Controls.Add(this.cboTrangThai);
            this.grpViecLam.Location = new System.Drawing.Point(20, 120);
            this.grpViecLam.Name = "grpViecLam";
            this.grpViecLam.Size = new System.Drawing.Size(660, 320);
            this.grpViecLam.TabIndex = 3;
            this.grpViecLam.TabStop = false;
            this.grpViecLam.Text = "Thông tin việc làm";
            // 
            // lblDoanhNghiep
            // 
            this.lblDoanhNghiep.AutoSize = true;
            this.lblDoanhNghiep.Location = new System.Drawing.Point(15, 30);
            this.lblDoanhNghiep.Name = "lblDoanhNghiep";
            this.lblDoanhNghiep.Size = new System.Drawing.Size(103, 20);
            this.lblDoanhNghiep.TabIndex = 0;
            this.lblDoanhNghiep.Text = "Doanh nghiệp:";
            // 
            // txtDoanhNghiep
            // 
            this.txtDoanhNghiep.Location = new System.Drawing.Point(140, 27);
            this.txtDoanhNghiep.Name = "txtDoanhNghiep";
            this.txtDoanhNghiep.Size = new System.Drawing.Size(300, 26); // Reduced Width
            this.txtDoanhNghiep.TabIndex = 1;
            // 
            // btnTimDN
            // 
            this.btnTimDN.Location = new System.Drawing.Point(450, 25);
            this.btnTimDN.Name = "btnTimDN";
            this.btnTimDN.Size = new System.Drawing.Size(60, 30);
            this.btnTimDN.TabIndex = 100;
            this.btnTimDN.Text = "🔍";
            this.btnTimDN.Click += new System.EventHandler(this.btnTimDN_Click);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 70);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(61, 20);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(140, 67);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(350, 26);
            this.txtDiaChi.TabIndex = 3;
            // 
            // lblLinhVuc
            // 
            this.lblLinhVuc.AutoSize = true;
            this.lblLinhVuc.Location = new System.Drawing.Point(15, 110);
            this.lblLinhVuc.Name = "lblLinhVuc";
            this.lblLinhVuc.Size = new System.Drawing.Size(74, 20);
            this.lblLinhVuc.TabIndex = 4;
            this.lblLinhVuc.Text = "Lĩnh vực:";
            // 
            // txtLinhVuc
            // 
            this.txtLinhVuc.Location = new System.Drawing.Point(140, 107);
            this.txtLinhVuc.Name = "txtLinhVuc";
            this.txtLinhVuc.Size = new System.Drawing.Size(350, 26);
            this.txtLinhVuc.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 147);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 26);
            this.txtEmail.TabIndex = 7;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(340, 150);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(46, 20);
            this.lblSoDienThoai.TabIndex = 8;
            this.lblSoDienThoai.Text = "SĐT:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(390, 147);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(100, 26);
            this.txtSoDienThoai.TabIndex = 9;
            // 
            // lblViTri
            // 
            this.lblViTri.AutoSize = true;
            this.lblViTri.Location = new System.Drawing.Point(15, 190);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(112, 20);
            this.lblViTri.TabIndex = 10;
            this.lblViTri.Text = "Vị trí công việc:";
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(140, 187);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(350, 26);
            this.txtViTri.TabIndex = 11;
            // 
            // lblMucLuong
            // 
            this.lblMucLuong.AutoSize = true;
            this.lblMucLuong.Location = new System.Drawing.Point(15, 230);
            this.lblMucLuong.Name = "lblMucLuong";
            this.lblMucLuong.Size = new System.Drawing.Size(81, 20);
            this.lblMucLuong.TabIndex = 12;
            this.lblMucLuong.Text = "Mức lương:";
            // 
            // txtMucLuong
            // 
            this.txtMucLuong.Location = new System.Drawing.Point(140, 227);
            this.txtMucLuong.Name = "txtMucLuong";
            this.txtMucLuong.Size = new System.Drawing.Size(180, 26);
            this.txtMucLuong.TabIndex = 13;
            // 
            // lblDonViTien
            // 
            this.lblDonViTien.AutoSize = true;
            this.lblDonViTien.Location = new System.Drawing.Point(330, 230);
            this.lblDonViTien.Name = "lblDonViTien";
            this.lblDonViTien.Size = new System.Drawing.Size(69, 20);
            this.lblDonViTien.TabIndex = 14;
            this.lblDonViTien.Text = "VNĐ/tháng";
            // 
            // chkDungChuyenNganh
            // 
            this.chkDungChuyenNganh.AutoSize = true;
            this.chkDungChuyenNganh.Location = new System.Drawing.Point(140, 270);
            this.chkDungChuyenNganh.Name = "chkDungChuyenNganh";
            this.chkDungChuyenNganh.Size = new System.Drawing.Size(180, 24);
            this.chkDungChuyenNganh.TabIndex = 15;
            this.chkDungChuyenNganh.Text = "Làm đúng chuyên ngành";
            this.chkDungChuyenNganh.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(420, 270);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(78, 20);
            this.lblTrangThai.TabIndex = 16;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Đang làm",
            "Đã nghỉ"});
            this.cboTrangThai.Location = new System.Drawing.Point(510, 267);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(130, 28);
            this.cboTrangThai.TabIndex = 17;
            // 
            // pnlQuestions
            // 
            this.pnlQuestions.AutoScroll = true;
            this.pnlQuestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuestions.Location = new System.Drawing.Point(20, 450); // Shifted down
            this.pnlQuestions.Name = "pnlQuestions";
            this.pnlQuestions.Size = new System.Drawing.Size(660, 200);
            this.pnlQuestions.TabIndex = 4;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(20, 660); // Shifted down
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(170, 20);
            this.lblNoiDung.TabIndex = 5;
            this.lblNoiDung.Text = "Ghi chú / Nhận xét thêm:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(20, 685); // Shifted down
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(660, 80);
            this.txtNoiDung.TabIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 780); // Increased Height
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(700, 60);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(26, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 40);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "✓ Lưu kết quả";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(230, 10);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FrmDienKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 840); // Increased Total Height
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblTenPhieu);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.grpViecLam);
            this.Controls.Add(this.pnlQuestions);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDienKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Điền phiếu khảo sát việc làm";
            this.grpViecLam.ResumeLayout(false);
            this.grpViecLam.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
