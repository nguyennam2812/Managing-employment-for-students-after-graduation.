namespace QuanLySinhVien
{
    partial class StudentDashboardForm
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
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabKhaiBao = new System.Windows.Forms.TabPage();
            this.tabSurvey = new System.Windows.Forms.TabPage();
            
            // Khai bao Components
            this.pnlKhaiBao = new System.Windows.Forms.Panel();
            this.btnKhaiBaoThongTin = new System.Windows.Forms.Button();
            this.lblKhaiBaoHuongDan = new System.Windows.Forms.Label();
            
            // Info Components
            this.grpInfo = new System.Windows.Forms.GroupBox();
            
            // Column 1
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();

            // Column 2
            this.lblNamTotNghiep = new System.Windows.Forms.Label();
            this.txtNamTotNghiep = new System.Windows.Forms.TextBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lblMaNganh = new System.Windows.Forms.Label();
            this.txtMaNganh = new System.Windows.Forms.TextBox();
            this.lblMaKhoaHoc = new System.Windows.Forms.Label();
            this.txtMaKhoaHoc = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            
            // Survey Components
            this.pnlSurveyContainer = new System.Windows.Forms.Panel();
            this.btnSubmitSurvey = new System.Windows.Forms.Button();
            this.lblSurveyTitle = new System.Windows.Forms.Label();
            this.pnlQuestions = new System.Windows.Forms.Panel();
            this.lblNoSurvey = new System.Windows.Forms.Label();

            this.pnlUserInfo.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabKhaiBao.SuspendLayout();
            this.tabSurvey.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.pnlSurveyContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlUserInfo.Controls.Add(this.btnLogout);
            this.pnlUserInfo.Controls.Add(this.lblWelcome);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(984, 60);
            this.pnlUserInfo.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(20, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin chào, [Student Name]";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(880, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabInfo);
            this.tabControlMain.Controls.Add(this.tabKhaiBao);
            this.tabControlMain.Controls.Add(this.tabSurvey);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlMain.Location = new System.Drawing.Point(0, 60);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(984, 501);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.grpInfo);
            this.tabInfo.Location = new System.Drawing.Point(4, 26);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tabInfo.Size = new System.Drawing.Size(976, 471);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Thông tin cá nhân";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtMaLop);
            this.grpInfo.Controls.Add(this.lblMaLop);
            this.grpInfo.Controls.Add(this.txtMaKhoaHoc);
            this.grpInfo.Controls.Add(this.lblMaKhoaHoc);
            this.grpInfo.Controls.Add(this.txtMaNganh);
            this.grpInfo.Controls.Add(this.lblMaNganh);
            this.grpInfo.Controls.Add(this.txtTinhTrang);
            this.grpInfo.Controls.Add(this.lblTinhTrang);
            this.grpInfo.Controls.Add(this.txtNamTotNghiep);
            this.grpInfo.Controls.Add(this.lblNamTotNghiep);
            this.grpInfo.Controls.Add(this.txtPhone);
            this.grpInfo.Controls.Add(this.lblPhone);
            this.grpInfo.Controls.Add(this.txtEmail);
            this.grpInfo.Controls.Add(this.lblEmail);
            this.grpInfo.Controls.Add(this.txtNgaySinh);
            this.grpInfo.Controls.Add(this.lblNgaySinh);
            this.grpInfo.Controls.Add(this.txtHoTen);
            this.grpInfo.Controls.Add(this.lblHoTen);
            this.grpInfo.Controls.Add(this.txtMaSV);
            this.grpInfo.Controls.Add(this.lblMaSV);
            
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(20, 20);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(936, 300);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin sinh viên (Chỉ xem)";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(30, 40);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(50, 19);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã SV:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(130, 37);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(250, 25);
            this.txtMaSV.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(30, 80);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(73, 19);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(130, 77);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(250, 25);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 120);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(73, 19);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(130, 117);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.ReadOnly = true;
            this.txtNgaySinh.Size = new System.Drawing.Size(250, 25);
            this.txtNgaySinh.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 160);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(130, 157);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 7;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(30, 200);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(92, 19);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(130, 197);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(250, 25);
            this.txtPhone.TabIndex = 9;
            // 
            // lblNamTotNghiep
            // 
            this.lblNamTotNghiep.AutoSize = true;
            this.lblNamTotNghiep.Location = new System.Drawing.Point(450, 40);
            this.lblNamTotNghiep.Name = "lblNamTotNghiep";
            this.lblNamTotNghiep.Size = new System.Drawing.Size(110, 19);
            this.lblNamTotNghiep.TabIndex = 10;
            this.lblNamTotNghiep.Text = "Năm tốt nghiệp:";
            // 
            // txtNamTotNghiep
            // 
            this.txtNamTotNghiep.Location = new System.Drawing.Point(560, 37);
            this.txtNamTotNghiep.Name = "txtNamTotNghiep";
            this.txtNamTotNghiep.ReadOnly = true;
            this.txtNamTotNghiep.Size = new System.Drawing.Size(250, 25);
            this.txtNamTotNghiep.TabIndex = 11;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(450, 80);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(72, 19);
            this.lblTinhTrang.TabIndex = 12;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(560, 77);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.ReadOnly = true;
            this.txtTinhTrang.Size = new System.Drawing.Size(250, 25);
            this.txtTinhTrang.TabIndex = 13;
            // 
            // lblMaNganh
            // 
            this.lblMaNganh.AutoSize = true;
            this.lblMaNganh.Location = new System.Drawing.Point(450, 120);
            this.lblMaNganh.Name = "lblMaNganh";
            this.lblMaNganh.Size = new System.Drawing.Size(75, 19);
            this.lblMaNganh.TabIndex = 14;
            this.lblMaNganh.Text = "Mã Ngành:";
            // 
            // txtMaNganh
            // 
            this.txtMaNganh.Location = new System.Drawing.Point(560, 117);
            this.txtMaNganh.Name = "txtMaNganh";
            this.txtMaNganh.ReadOnly = true;
            this.txtMaNganh.Size = new System.Drawing.Size(250, 25);
            this.txtMaNganh.TabIndex = 15;
            // 
            // lblMaKhoaHoc
            // 
            this.lblMaKhoaHoc.AutoSize = true;
            this.lblMaKhoaHoc.Location = new System.Drawing.Point(450, 160);
            this.lblMaKhoaHoc.Name = "lblMaKhoaHoc";
            this.lblMaKhoaHoc.Size = new System.Drawing.Size(95, 19);
            this.lblMaKhoaHoc.TabIndex = 16;
            this.lblMaKhoaHoc.Text = "Mã Khóa học:";
            // 
            // txtMaKhoaHoc
            // 
            this.txtMaKhoaHoc.Location = new System.Drawing.Point(560, 157);
            this.txtMaKhoaHoc.Name = "txtMaKhoaHoc";
            this.txtMaKhoaHoc.ReadOnly = true;
            this.txtMaKhoaHoc.Size = new System.Drawing.Size(250, 25);
            this.txtMaKhoaHoc.TabIndex = 17;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(450, 200);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(57, 19);
            this.lblMaLop.TabIndex = 18;
            this.lblMaLop.Text = "Mã Lớp:";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(560, 197);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(250, 25);
            this.txtMaLop.TabIndex = 19;
            // 
            // tabKhaiBao
            // 
            this.tabKhaiBao.Controls.Add(this.pnlKhaiBao);
            this.tabKhaiBao.Location = new System.Drawing.Point(4, 26);
            this.tabKhaiBao.Name = "tabKhaiBao";
            this.tabKhaiBao.Padding = new System.Windows.Forms.Padding(20);
            this.tabKhaiBao.Size = new System.Drawing.Size(976, 471);
            this.tabKhaiBao.TabIndex = 2;
            this.tabKhaiBao.Text = "Khai báo thông tin";
            this.tabKhaiBao.UseVisualStyleBackColor = true;
            // 
            // pnlKhaiBao
            // 
            this.pnlKhaiBao.Controls.Add(this.lblKhaiBaoHuongDan);
            this.pnlKhaiBao.Controls.Add(this.btnKhaiBaoThongTin);
            this.pnlKhaiBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhaiBao.Location = new System.Drawing.Point(20, 20);
            this.pnlKhaiBao.Name = "pnlKhaiBao";
            this.pnlKhaiBao.Size = new System.Drawing.Size(936, 431);
            this.pnlKhaiBao.TabIndex = 0;
            // 
            // lblKhaiBaoHuongDan
            // 
            this.lblKhaiBaoHuongDan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblKhaiBaoHuongDan.Location = new System.Drawing.Point(50, 50);
            this.lblKhaiBaoHuongDan.Name = "lblKhaiBaoHuongDan";
            this.lblKhaiBaoHuongDan.Size = new System.Drawing.Size(800, 100);
            this.lblKhaiBaoHuongDan.TabIndex = 0;
            this.lblKhaiBaoHuongDan.Text = "Chức năng này cho phép bạn tự khai báo thông tin việc làm hiện tại của mình.\\n\\nNhấn nút bên dưới để mở form khai báo thông tin. Thông tin sẽ được lưu và chờ xác thực.";
            // 
            // btnKhaiBaoThongTin
            // 
            this.btnKhaiBaoThongTin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnKhaiBaoThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhaiBaoThongTin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKhaiBaoThongTin.ForeColor = System.Drawing.Color.White;
            this.btnKhaiBaoThongTin.Location = new System.Drawing.Point(50, 180);
            this.btnKhaiBaoThongTin.Name = "btnKhaiBaoThongTin";
            this.btnKhaiBaoThongTin.Size = new System.Drawing.Size(250, 50);
            this.btnKhaiBaoThongTin.TabIndex = 1;
            this.btnKhaiBaoThongTin.Text = "📝 Khai báo thông tin";
            this.btnKhaiBaoThongTin.UseVisualStyleBackColor = false;
            this.btnKhaiBaoThongTin.Click += new System.EventHandler(this.btnKhaiBaoThongTin_Click);
            // 
            // tabSurvey
            // 
            this.tabSurvey.Controls.Add(this.pnlSurveyContainer);
            this.tabSurvey.Controls.Add(this.lblNoSurvey);
            this.tabSurvey.Location = new System.Drawing.Point(4, 26);
            this.tabSurvey.Name = "tabSurvey";
            this.tabSurvey.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurvey.Size = new System.Drawing.Size(976, 471);
            this.tabSurvey.TabIndex = 1;
            this.tabSurvey.Text = "Khảo sát";
            this.tabSurvey.UseVisualStyleBackColor = true;
            // 
            // lblNoSurvey
            // 
            this.lblNoSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoSurvey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblNoSurvey.ForeColor = System.Drawing.Color.Gray;
            this.lblNoSurvey.Location = new System.Drawing.Point(3, 3);
            this.lblNoSurvey.Name = "lblNoSurvey";
            this.lblNoSurvey.Size = new System.Drawing.Size(970, 465);
            this.lblNoSurvey.TabIndex = 0;
            this.lblNoSurvey.Text = "Hiện không có bài khảo sát nào cần làm.";
            this.lblNoSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoSurvey.Visible = false;
            // 
            // pnlSurveyContainer
            // 
            this.pnlSurveyContainer.Controls.Add(this.pnlQuestions);
            this.pnlSurveyContainer.Controls.Add(this.lblSurveyTitle);
            this.pnlSurveyContainer.Controls.Add(this.btnSubmitSurvey);
            this.pnlSurveyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSurveyContainer.Location = new System.Drawing.Point(3, 3);
            this.pnlSurveyContainer.Name = "pnlSurveyContainer";
            this.pnlSurveyContainer.Size = new System.Drawing.Size(970, 465);
            this.pnlSurveyContainer.TabIndex = 1;
            // 
            // lblSurveyTitle
            // 
            this.lblSurveyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSurveyTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSurveyTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblSurveyTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSurveyTitle.Name = "lblSurveyTitle";
            this.lblSurveyTitle.Size = new System.Drawing.Size(970, 50);
            this.lblSurveyTitle.TabIndex = 0;
            this.lblSurveyTitle.Text = "TIÊU ĐỀ KHẢO SÁT";
            this.lblSurveyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlQuestions
            // 
            this.pnlQuestions.AutoScroll = true;
            this.pnlQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestions.Location = new System.Drawing.Point(0, 50);
            this.pnlQuestions.Name = "pnlQuestions";
            this.pnlQuestions.Size = new System.Drawing.Size(970, 365);
            this.pnlQuestions.TabIndex = 1;
            // 
            // btnSubmitSurvey
            // 
            this.btnSubmitSurvey.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmitSurvey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmitSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitSurvey.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmitSurvey.ForeColor = System.Drawing.Color.White;
            this.btnSubmitSurvey.Location = new System.Drawing.Point(0, 415);
            this.btnSubmitSurvey.Name = "btnSubmitSurvey";
            this.btnSubmitSurvey.Size = new System.Drawing.Size(970, 50);
            this.btnSubmitSurvey.TabIndex = 2;
            this.btnSubmitSurvey.Text = "NỘP BÀI KHẢO SÁT";
            this.btnSubmitSurvey.UseVisualStyleBackColor = false;
            this.btnSubmitSurvey.Click += new System.EventHandler(this.btnSubmitSurvey_Click);
            // 
            // StudentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.pnlUserInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StudentDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh viên Dashboard";
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabKhaiBao.ResumeLayout(false);
            this.tabSurvey.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlSurveyContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabSurvey;
        private System.Windows.Forms.GroupBox grpInfo;
        
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        
        private System.Windows.Forms.Label lblNamTotNghiep;
        private System.Windows.Forms.TextBox txtNamTotNghiep;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lblMaNganh;
        private System.Windows.Forms.TextBox txtMaNganh;
        private System.Windows.Forms.Label lblMaKhoaHoc;
        private System.Windows.Forms.TextBox txtMaKhoaHoc;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtMaLop;
        
        private System.Windows.Forms.Panel pnlSurveyContainer;
        private System.Windows.Forms.Label lblSurveyTitle;
        private System.Windows.Forms.Panel pnlQuestions;
        private System.Windows.Forms.Button btnSubmitSurvey;
        private System.Windows.Forms.Label lblNoSurvey;
        
        // Khai bao thong tin components
        private System.Windows.Forms.TabPage tabKhaiBao;
        private System.Windows.Forms.Panel pnlKhaiBao;
        private System.Windows.Forms.Label lblKhaiBaoHuongDan;
        private System.Windows.Forms.Button btnKhaiBaoThongTin;
    }
}
