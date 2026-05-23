namespace QuanLySinhVien
{
    partial class GuiThongBaoForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.grpThietLap = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiDot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnTimSV = new System.Windows.Forms.Button();
            this.btnGuiEmail = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNamTotNghiep = new System.Windows.Forms.ComboBox();

            this.dgvSinhVienThongBao = new System.Windows.Forms.DataGridView();
            this.colChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNienKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.grpThietLap.SuspendLayout();
            this.grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienThongBao)).BeginInit();
            this.SuspendLayout();

            // 
            // grpThietLap
            // 
            this.grpThietLap.Controls.Add(this.btnDong);
            this.grpThietLap.Controls.Add(this.btnGuiEmail);
            this.grpThietLap.Controls.Add(this.btnTimSV);
            this.grpThietLap.Controls.Add(this.txtNoiDung);
            this.grpThietLap.Controls.Add(this.label3);
            this.grpThietLap.Controls.Add(this.txtTieuDe);
            this.grpThietLap.Controls.Add(this.label2);
            this.grpThietLap.Controls.Add(this.cboLoaiDot);
            this.grpThietLap.Controls.Add(this.label1);
            this.grpThietLap.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThietLap.Location = new System.Drawing.Point(0, 0);
            this.grpThietLap.Name = "grpThietLap";
            this.grpThietLap.Size = new System.Drawing.Size(900, 200);
            this.grpThietLap.TabIndex = 0;
            this.grpThietLap.TabStop = false;
            this.grpThietLap.Text = "Thiết lập đợt gửi";

            // label1 - Loai Dot
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Text = "Loại đợt:";
            // cboLoaiDot
            this.cboLoaiDot.Location = new System.Drawing.Point(100, 27);
            this.cboLoaiDot.Size = new System.Drawing.Size(150, 24);
            this.cboLoaiDot.Items.AddRange(new object[] { "Tháng", "Quý", "Năm" });
            this.cboLoaiDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDot.SelectedIndex = 0;

            // label2 - Tieu De
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 30);
            this.label2.Name = "label2";
            this.label2.Text = "Tiêu đề:";
            // txtTieuDe
            this.txtTieuDe.Location = new System.Drawing.Point(360, 27);
            this.txtTieuDe.Size = new System.Drawing.Size(400, 22);
            this.txtTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // label3 - Noi Dung
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Text = "Nội dung:";
            // txtNoiDung
            this.txtNoiDung.Location = new System.Drawing.Point(100, 70);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Size = new System.Drawing.Size(660, 80);
            this.txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Buttons
            this.btnTimSV.Location = new System.Drawing.Point(100, 160);
            this.btnTimSV.Size = new System.Drawing.Size(120, 30);
            this.btnTimSV.Text = "Lọc danh sách";
            this.btnTimSV.Click += new System.EventHandler(this.btnTimSV_Click);

            this.btnGuiEmail.Location = new System.Drawing.Point(240, 160);
            this.btnGuiEmail.Size = new System.Drawing.Size(120, 30);
            this.btnGuiEmail.Text = "Gửi thông báo";
            this.btnGuiEmail.Click += new System.EventHandler(this.btnGuiEmail_Click);


            this.btnDong.Location = new System.Drawing.Point(520, 160);
            this.btnDong.Size = new System.Drawing.Size(160, 30);
            this.btnDong.Text = "← Quay về Dashboard";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // 
            // grpLoc
            // 
            this.grpLoc.Controls.Add(this.cboNamTotNghiep);
            this.grpLoc.Controls.Add(this.label6);
            this.grpLoc.Controls.Add(this.cboNganh);
            this.grpLoc.Controls.Add(this.label5);
            this.grpLoc.Controls.Add(this.cboKhoa);
            this.grpLoc.Controls.Add(this.label4);
            this.grpLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoc.Location = new System.Drawing.Point(0, 200);
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Size = new System.Drawing.Size(900, 70);
            this.grpLoc.TabIndex = 1;
            this.grpLoc.TabStop = false;
            this.grpLoc.Text = "Tiêu chí lọc sinh viên";

            // Filters
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Text = "Khóa:";
            this.cboKhoa.Location = new System.Drawing.Point(70, 27);
            this.cboKhoa.Size = new System.Drawing.Size(150, 24);
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 30);
            this.label5.Text = "Ngành:";
            this.cboNganh.Location = new System.Drawing.Point(310, 27);
            this.cboNganh.Size = new System.Drawing.Size(200, 24);
            this.cboNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 30);
            this.label6.Text = "Năm TN:";
            this.cboNamTotNghiep.Location = new System.Drawing.Point(610, 27);
            this.cboNamTotNghiep.Size = new System.Drawing.Size(120, 24);
            this.cboNamTotNghiep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // dgvSinhVienThongBao
            // 
            this.dgvSinhVienThongBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSinhVienThongBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienThongBao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colChon, this.colMaSV, this.colHoTen, this.colEmail, 
                this.colNienKhoa, this.colNganh
            });
            this.dgvSinhVienThongBao.Location = new System.Drawing.Point(0, 270);
            this.dgvSinhVienThongBao.Size = new System.Drawing.Size(900, 330);
            this.dgvSinhVienThongBao.AllowUserToAddRows = false;

            // Columns
            this.colChon.Name = "colChon";
            this.colChon.HeaderText = "Chọn";
            this.colChon.Width = 50;

            this.colMaSV.Name = "colMaSV";
            this.colMaSV.HeaderText = "Mã SV";
            this.colMaSV.DataPropertyName = "MaSV";

            this.colHoTen.Name = "colHoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.Width = 150;

            this.colEmail.Name = "colEmail";
            this.colEmail.HeaderText = "Email";
            this.colEmail.DataPropertyName = "EmailCaNhan";
            this.colEmail.Width = 150;

            this.colNienKhoa.HeaderText = "Niên khóa";
            this.colNienKhoa.DataPropertyName = "NienKhoa";

            this.colNganh.HeaderText = "Ngành";
            this.colNganh.DataPropertyName = "TenNganh";
            this.colNganh.Width = 150;



            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgvSinhVienThongBao);
            this.Controls.Add(this.grpLoc);
            this.Controls.Add(this.grpThietLap);
            this.Text = "Gửi thông báo định kỳ cho sinh viên";
            this.Load += new System.EventHandler(this.GuiThongBaoForm_Load);

            this.grpThietLap.ResumeLayout(false);
            this.grpThietLap.PerformLayout();
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienThongBao)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpThietLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoaiDot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnTimSV;
        private System.Windows.Forms.Button btnGuiEmail;
        private System.Windows.Forms.Button btnDong;

        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboNamTotNghiep;

        private System.Windows.Forms.DataGridView dgvSinhVienThongBao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNienKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNganh;
    }
}
