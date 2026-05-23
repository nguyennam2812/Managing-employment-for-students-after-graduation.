namespace QuanLySinhVien
{
    partial class LoginForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(580, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(580, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng nhập hệ thống Quản lý Sinh viên";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlLeft.Controls.Add(this.lblIcon);
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(160, 200);
            this.pnlLeft.TabIndex = 1;
            // 
            // lblIcon
            // 
            this.lblIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(0, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(160, 200);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "🔐";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.grpLogin);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.btnCancel);
            this.pnlRight.Location = new System.Drawing.Point(160, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(420, 200);
            this.pnlRight.TabIndex = 2;
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.lblUser);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.lblPass);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.grpLogin.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.grpLogin.Location = new System.Drawing.Point(15, 10);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(380, 120);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Thông tin đăng nhập";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(15, 35);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(75, 20);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(120, 32);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(15, 75);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(70, 20);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(120, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(240, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(90, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(230, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 250);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.pnlHeader.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
    }
}
