namespace QuanLySinhVien
{
    partial class BaoCaoThongKeForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabViecLam = new System.Windows.Forms.TabPage();
            this.dgvVL = new System.Windows.Forms.DataGridView();
            this.panelViecLam = new System.Windows.Forms.Panel();
            this.btnVL_ThongKe = new System.Windows.Forms.Button();
            this.dtpVL_From = new System.Windows.Forms.DateTimePicker();
            this.dtpVL_To = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            this.tabDungNganh = new System.Windows.Forms.TabPage();
            this.dgvDN = new System.Windows.Forms.DataGridView();
            this.panelDungNganh = new System.Windows.Forms.Panel();
            this.btnDN_ThongKe = new System.Windows.Forms.Button();
            this.cboNganh_DN = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabLuong = new System.Windows.Forms.TabPage();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.panelLuong = new System.Windows.Forms.Panel();
            this.btnThongKeLuong = new System.Windows.Forms.Button(); // Legacy
            // New controls instantiation
            this.btnVL_Luu = new System.Windows.Forms.Button();
            this.btnDN_Luu = new System.Windows.Forms.Button();
            this.cboKhoa_DN = new System.Windows.Forms.ComboBox();
            this.lblKhoa_DN = new System.Windows.Forms.Label();
            this.lblTiLeDungNganh = new System.Windows.Forms.Label();

            this.btnLuong_ThongKe = new System.Windows.Forms.Button();
            this.btnLuong_Luu = new System.Windows.Forms.Button();

            // Detail grids for drill-down
            this.dgvVL_Detail = new System.Windows.Forms.DataGridView();
            this.dgvDN_Detail = new System.Windows.Forms.DataGridView();
            this.dgvLuong_Detail = new System.Windows.Forms.DataGridView();
            this.splitterVL = new System.Windows.Forms.SplitContainer();
            this.splitterDN = new System.Windows.Forms.SplitContainer();
            this.splitterLuong = new System.Windows.Forms.SplitContainer();

            this.panelHeader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabViecLam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVL)).BeginInit();
            this.panelViecLam.SuspendLayout();
            this.tabDungNganh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDN)).BeginInit();
            this.panelDungNganh.SuspendLayout();
            this.tabLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.panelLuong.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.btnThoat);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 50);
            this.panelHeader.TabIndex = 99;
            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(12, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 32);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabViecLam);
            this.tabControl1.Controls.Add(this.tabDungNganh);
            this.tabControl1.Controls.Add(this.tabLuong);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabViecLam
            // 
            this.tabViecLam.Controls.Add(this.dgvVL);
            this.tabViecLam.Controls.Add(this.panelViecLam);
            this.tabViecLam.Location = new System.Drawing.Point(4, 25);
            this.tabViecLam.Name = "tabViecLam";
            this.tabViecLam.Padding = new System.Windows.Forms.Padding(3);
            this.tabViecLam.Size = new System.Drawing.Size(892, 471);
            this.tabViecLam.TabIndex = 0;
            this.tabViecLam.Text = "Thống kê việc làm sau tốt nghiệp theo tháng/năm";
            this.tabViecLam.UseVisualStyleBackColor = true;
            // 
            // splitterVL
            // 
            this.splitterVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterVL.Location = new System.Drawing.Point(3, 53);
            this.splitterVL.Name = "splitterVL";
            this.splitterVL.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitterVL.Size = new System.Drawing.Size(886, 415);
            this.splitterVL.SplitterDistance = 180;
            this.splitterVL.Panel1.Controls.Add(this.dgvVL);
            this.splitterVL.Panel2.Controls.Add(this.dgvVL_Detail);
            this.tabViecLam.Controls.Clear();
            this.tabViecLam.Controls.Add(this.splitterVL);
            this.tabViecLam.Controls.Add(this.panelViecLam);
            // 
            // dgvVL
            // 
            this.dgvVL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVL.Location = new System.Drawing.Point(0, 0);
            this.dgvVL.Name = "dgvVL";
            this.dgvVL.RowHeadersWidth = 51;
            this.dgvVL.RowTemplate.Height = 24;
            this.dgvVL.Size = new System.Drawing.Size(886, 180);
            this.dgvVL.TabIndex = 1;
            this.dgvVL.SelectionChanged += new System.EventHandler(this.dgvVL_SelectionChanged);
            // 
            // dgvVL_Detail
            // 
            this.dgvVL_Detail.AllowUserToAddRows = false;
            this.dgvVL_Detail.AllowUserToDeleteRows = false;
            this.dgvVL_Detail.ReadOnly = true;
            this.dgvVL_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVL_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVL_Detail.Name = "dgvVL_Detail";
            this.dgvVL_Detail.RowHeadersWidth = 51;
            this.dgvVL_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // panelViecLam
            // 
            this.panelViecLam.Controls.Add(this.btnVL_Luu);

            this.panelViecLam.Controls.Add(this.label2);
            this.panelViecLam.Controls.Add(this.label1);
            this.panelViecLam.Controls.Add(this.dtpVL_To);
            this.panelViecLam.Controls.Add(this.dtpVL_From);
            this.panelViecLam.Controls.Add(this.btnVL_ThongKe);
            this.panelViecLam.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelViecLam.Location = new System.Drawing.Point(3, 3);
            this.panelViecLam.Name = "panelViecLam";
            this.panelViecLam.Size = new System.Drawing.Size(886, 50);
            this.panelViecLam.TabIndex = 0;
            // 
            // btnVL_ThongKe
            // 
            this.btnVL_ThongKe.Location = new System.Drawing.Point(580, 10);
            this.btnVL_ThongKe.Name = "btnVL_ThongKe";
            this.btnVL_ThongKe.Size = new System.Drawing.Size(90, 30);
            this.btnVL_ThongKe.TabIndex = 0;
            this.btnVL_ThongKe.Text = "Thống kê";
            this.btnVL_ThongKe.UseVisualStyleBackColor = true;
            this.btnVL_ThongKe.Click += new System.EventHandler(this.btnVL_ThongKe_Click);
            // 
            // btnVL_Luu
            // 
            this.btnVL_Luu.Location = new System.Drawing.Point(680, 10);
            this.btnVL_Luu.Name = "btnVL_Luu";
            this.btnVL_Luu.Size = new System.Drawing.Size(90, 30);
            this.btnVL_Luu.TabIndex = 6;
            this.btnVL_Luu.Text = "Lưu BC";
            this.btnVL_Luu.UseVisualStyleBackColor = true;
            this.btnVL_Luu.Click += new System.EventHandler(this.btnVL_Luu_Click);
            // 
            // dtpVL_From
            // 
            this.dtpVL_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVL_From.Location = new System.Drawing.Point(80, 14);
            this.dtpVL_From.Name = "dtpVL_From";
            this.dtpVL_From.Size = new System.Drawing.Size(120, 22);
            this.dtpVL_From.TabIndex = 1;
            // 
            // dtpVL_To
            // 
            this.dtpVL_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVL_To.Location = new System.Drawing.Point(260, 14);
            this.dtpVL_To.Name = "dtpVL_To";
            this.dtpVL_To.Size = new System.Drawing.Size(120, 22);
            this.dtpVL_To.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến:";

            // 
            // tabDungNganh
            // 
            // splitterDN
            this.splitterDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterDN.Location = new System.Drawing.Point(3, 80);
            this.splitterDN.Name = "splitterDN";
            this.splitterDN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitterDN.Size = new System.Drawing.Size(886, 388);
            this.splitterDN.SplitterDistance = 150;
            this.splitterDN.Panel1.Controls.Add(this.dgvDN);
            this.splitterDN.Panel2.Controls.Add(this.dgvDN_Detail);
            this.tabDungNganh.Controls.Clear();
            this.tabDungNganh.Controls.Add(this.splitterDN);
            this.tabDungNganh.Controls.Add(this.panelDungNganh);
            this.tabDungNganh.Location = new System.Drawing.Point(4, 25);
            this.tabDungNganh.Name = "tabDungNganh";
            this.tabDungNganh.Padding = new System.Windows.Forms.Padding(3);
            this.tabDungNganh.Size = new System.Drawing.Size(892, 471);
            this.tabDungNganh.TabIndex = 1;
            this.tabDungNganh.Text = "Thống kê việc làm đúng chuyên ngành";
            this.tabDungNganh.UseVisualStyleBackColor = true;
            // 
            // dgvDN
            // 
            this.dgvDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDN.Location = new System.Drawing.Point(0, 0);
            this.dgvDN.Name = "dgvDN";
            this.dgvDN.RowHeadersWidth = 51;
            this.dgvDN.RowTemplate.Height = 24;
            this.dgvDN.Size = new System.Drawing.Size(886, 150);
            this.dgvDN.TabIndex = 1;
            this.dgvDN.SelectionChanged += new System.EventHandler(this.dgvDN_SelectionChanged);
            // 
            // dgvDN_Detail
            // 
            this.dgvDN_Detail.AllowUserToAddRows = false;
            this.dgvDN_Detail.AllowUserToDeleteRows = false;
            this.dgvDN_Detail.ReadOnly = true;
            this.dgvDN_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDN_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDN_Detail.Name = "dgvDN_Detail";
            this.dgvDN_Detail.RowHeadersWidth = 51;
            this.dgvDN_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // panelDungNganh
            // 
            this.panelDungNganh.Controls.Add(this.lblTiLeDungNganh);
            this.panelDungNganh.Controls.Add(this.lblKhoa_DN);
            this.panelDungNganh.Controls.Add(this.cboKhoa_DN);
            this.panelDungNganh.Controls.Add(this.label3);
            this.panelDungNganh.Controls.Add(this.cboNganh_DN);
            this.panelDungNganh.Controls.Add(this.btnDN_ThongKe);
            this.panelDungNganh.Controls.Add(this.btnDN_Luu);
            this.panelDungNganh.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDungNganh.Location = new System.Drawing.Point(3, 3);
            this.panelDungNganh.Name = "panelDungNganh";
            this.panelDungNganh.Size = new System.Drawing.Size(886, 77);
            this.panelDungNganh.TabIndex = 0;
            // 
            // btnDN_ThongKe
            // 
            this.btnDN_ThongKe.Location = new System.Drawing.Point(480, 10);
            this.btnDN_ThongKe.Name = "btnDN_ThongKe";
            this.btnDN_ThongKe.Size = new System.Drawing.Size(90, 30);
            this.btnDN_ThongKe.TabIndex = 0;
            this.btnDN_ThongKe.Text = "Thống kê";
            this.btnDN_ThongKe.UseVisualStyleBackColor = true;
            this.btnDN_ThongKe.Click += new System.EventHandler(this.btnDN_ThongKe_Click);
            // 
            // btnDN_Luu
            // 
            this.btnDN_Luu.Location = new System.Drawing.Point(580, 10);
            this.btnDN_Luu.Name = "btnDN_Luu";
            this.btnDN_Luu.Size = new System.Drawing.Size(90, 30);
            this.btnDN_Luu.TabIndex = 5;
            this.btnDN_Luu.Text = "Lưu BC";
            this.btnDN_Luu.UseVisualStyleBackColor = true;
            this.btnDN_Luu.Click += new System.EventHandler(this.btnDN_Luu_Click);
            // 
            // cboNganh_DN
            // 
            this.cboNganh_DN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNganh_DN.FormattingEnabled = true;
            this.cboNganh_DN.Location = new System.Drawing.Point(70, 13);
            this.cboNganh_DN.Name = "cboNganh_DN";
            this.cboNganh_DN.Size = new System.Drawing.Size(160, 24);
            this.cboNganh_DN.TabIndex = 1;
            // 
            // cboKhoa_DN
            // 
            this.cboKhoa_DN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa_DN.FormattingEnabled = true;
            this.cboKhoa_DN.Location = new System.Drawing.Point(300, 13);
            this.cboKhoa_DN.Name = "cboKhoa_DN";
            this.cboKhoa_DN.Size = new System.Drawing.Size(160, 24);
            this.cboKhoa_DN.TabIndex = 6;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngành:";
            //
            // lblKhoa_DN
            //
            this.lblKhoa_DN.AutoSize = true;
            this.lblKhoa_DN.Location = new System.Drawing.Point(250, 17);
            this.lblKhoa_DN.Name = "lblKhoa_DN";
            this.lblKhoa_DN.Size = new System.Drawing.Size(45, 17);
            this.lblKhoa_DN.TabIndex = 7;
            this.lblKhoa_DN.Text = "Khóa:";
            //
            // lblTiLeDungNganh
            //
            this.lblTiLeDungNganh.AutoSize = true;
            this.lblTiLeDungNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiLeDungNganh.ForeColor = System.Drawing.Color.Blue;
            this.lblTiLeDungNganh.Location = new System.Drawing.Point(13, 50);
            this.lblTiLeDungNganh.Name = "lblTiLeDungNganh";
            this.lblTiLeDungNganh.Size = new System.Drawing.Size(149, 18);
            this.lblTiLeDungNganh.TabIndex = 8;
            this.lblTiLeDungNganh.Text = "Tỷ lệ đúng ngành: --";
            //
            // tabLuong
            //
            // splitterLuong
            this.splitterLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitterLuong.Location = new System.Drawing.Point(0, 50);
            this.splitterLuong.Name = "splitterLuong";
            this.splitterLuong.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitterLuong.Size = new System.Drawing.Size(892, 421);
            this.splitterLuong.SplitterDistance = 150;
            this.splitterLuong.Panel1.Controls.Add(this.dgvLuong);
            this.splitterLuong.Panel2.Controls.Add(this.dgvLuong_Detail);
            this.tabLuong.Controls.Clear();
            this.tabLuong.Controls.Add(this.splitterLuong);
            this.tabLuong.Controls.Add(this.panelLuong);
            this.tabLuong.Location = new System.Drawing.Point(4, 25);
            this.tabLuong.Name = "tabLuong";
            this.tabLuong.Size = new System.Drawing.Size(892, 471);
            this.tabLuong.TabIndex = 2;
            this.tabLuong.Text = "Thống kê việc làm theo mức lương";
            this.tabLuong.UseVisualStyleBackColor = true;
            //
            // dgvLuong
            //
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuong.Location = new System.Drawing.Point(0, 0);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.RowTemplate.Height = 24;
            this.dgvLuong.Size = new System.Drawing.Size(892, 150);
            this.dgvLuong.TabIndex = 1;
            this.dgvLuong.SelectionChanged += new System.EventHandler(this.dgvLuong_SelectionChanged);
            //
            // dgvLuong_Detail
            //
            this.dgvLuong_Detail.AllowUserToAddRows = false;
            this.dgvLuong_Detail.AllowUserToDeleteRows = false;
            this.dgvLuong_Detail.ReadOnly = true;
            this.dgvLuong_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuong_Detail.Name = "dgvLuong_Detail";
            this.dgvLuong_Detail.RowHeadersWidth = 51;
            this.dgvLuong_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //
            // panelLuong
            //
            this.panelLuong.Controls.Add(this.btnLuong_ThongKe);
            this.panelLuong.Controls.Add(this.btnLuong_Luu);
            this.panelLuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLuong.Location = new System.Drawing.Point(0, 0);
            this.panelLuong.Name = "panelLuong";
            this.panelLuong.Size = new System.Drawing.Size(892, 50);
            this.panelLuong.TabIndex = 0;
            //
            // btnLuong_ThongKe
            //
            this.btnLuong_ThongKe.Location = new System.Drawing.Point(250, 10);
            this.btnLuong_ThongKe.Name = "btnLuong_ThongKe";
            this.btnLuong_ThongKe.Size = new System.Drawing.Size(100, 30);
            this.btnLuong_ThongKe.TabIndex = 0;
            this.btnLuong_ThongKe.Text = "Thống kê";
            this.btnLuong_ThongKe.UseVisualStyleBackColor = true;
            this.btnLuong_ThongKe.Click += new System.EventHandler(this.btnLuong_ThongKe_Click);
            //
            // btnLuong_Luu
            //
            this.btnLuong_Luu.Location = new System.Drawing.Point(360, 10);
            this.btnLuong_Luu.Name = "btnLuong_Luu";
            this.btnLuong_Luu.Size = new System.Drawing.Size(100, 30);
            this.btnLuong_Luu.TabIndex = 2;
            this.btnLuong_Luu.Text = "Lưu BC";
            this.btnLuong_Luu.UseVisualStyleBackColor = true;
            this.btnLuong_Luu.Click += new System.EventHandler(this.btnLuong_Luu_Click);

            //
            // BaoCaoThongKeForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelHeader);
            this.Name = "BaoCaoThongKeForm";
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.BaoCaoThongKeForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabViecLam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVL)).EndInit();
            this.panelViecLam.ResumeLayout(false);
            this.panelViecLam.PerformLayout();
            this.tabDungNganh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDN)).EndInit();
            this.panelDungNganh.ResumeLayout(false);
            this.panelDungNganh.PerformLayout();
            this.tabLuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.panelLuong.ResumeLayout(false);
            this.panelLuong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabViecLam;
        private System.Windows.Forms.TabPage tabDungNganh;
        private System.Windows.Forms.TabPage tabLuong;
        private System.Windows.Forms.DataGridView dgvVL;
        private System.Windows.Forms.Panel panelViecLam;
        private System.Windows.Forms.DataGridView dgvDN;
        private System.Windows.Forms.Panel panelDungNganh;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Panel panelLuong;
        private System.Windows.Forms.Button btnVL_ThongKe;
        private System.Windows.Forms.Button btnDN_ThongKe;
        private System.Windows.Forms.Button btnThongKeLuong;
        private System.Windows.Forms.DateTimePicker dtpVL_To;
        private System.Windows.Forms.DateTimePicker dtpVL_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button btnVL_Luu;
        private System.Windows.Forms.Button btnDN_Luu;
        private System.Windows.Forms.ComboBox cboNganh_DN;
        private System.Windows.Forms.ComboBox cboKhoa_DN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKhoa_DN;
        private System.Windows.Forms.Label lblTiLeDungNganh;
        private System.Windows.Forms.Button btnLuong_ThongKe;
        private System.Windows.Forms.Button btnLuong_Luu;

        // Detail grids
        private System.Windows.Forms.DataGridView dgvVL_Detail;
        private System.Windows.Forms.DataGridView dgvDN_Detail;
        private System.Windows.Forms.DataGridView dgvLuong_Detail;
        private System.Windows.Forms.SplitContainer splitterVL;
        private System.Windows.Forms.SplitContainer splitterDN;
        private System.Windows.Forms.SplitContainer splitterLuong;
    }
}
