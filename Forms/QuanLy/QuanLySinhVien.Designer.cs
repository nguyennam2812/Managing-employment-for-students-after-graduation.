namespace QuanLySinhVien
{
    partial class QuanLySinhVien
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSinhVien = new System.Windows.Forms.TabPage();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.btnEditSV = new System.Windows.Forms.Button();

            this.btnAddSV = new System.Windows.Forms.Button();
            this.btnReloadSV = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gridSinhVien = new System.Windows.Forms.DataGridView();
            // Removed: tabBaoCao, tabThongBao, and related controls
            this.tabMain.SuspendLayout();
            this.tabSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSinhVien);
            // tabBaoCao and tabThongBao removed per user request
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(889, 480);
            this.tabMain.TabIndex = 0;
            // 
            // tabSinhVien
            // 
            this.tabSinhVien.Controls.Add(this.btnViewLog);
            this.tabSinhVien.Controls.Add(this.btnEditSV);

            this.tabSinhVien.Controls.Add(this.btnAddSV);
            this.tabSinhVien.Controls.Add(this.btnReloadSV);
            this.tabSinhVien.Controls.Add(this.btnThoat);
            this.tabSinhVien.Controls.Add(this.txtSearch);
            this.tabSinhVien.Controls.Add(this.btnSearch);
            this.tabSinhVien.Controls.Add(this.gridSinhVien);
            this.tabSinhVien.Location = new System.Drawing.Point(4, 25);
            this.tabSinhVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSinhVien.Name = "tabSinhVien";
            this.tabSinhVien.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSinhVien.Size = new System.Drawing.Size(881, 451);
            this.tabSinhVien.TabIndex = 0;
            this.tabSinhVien.Text = "Sinh viên";
            this.tabSinhVien.UseVisualStyleBackColor = true;
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(339, 5);
            this.btnViewLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(133, 27);
            this.btnViewLog.TabIndex = 10;
            this.btnViewLog.Text = "Lịch sử thay đổi";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // btnEditSV
            // 
            this.btnEditSV.Location = new System.Drawing.Point(107, 5);
            this.btnEditSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditSV.Name = "btnEditSV";
            this.btnEditSV.Size = new System.Drawing.Size(96, 27);
            this.btnEditSV.TabIndex = 8;
            this.btnEditSV.Text = "Chỉnh sửa";
            this.btnEditSV.UseVisualStyleBackColor = true;
            this.btnEditSV.Click += new System.EventHandler(this.btnEditSV_Click);

            // 
            // btnAddSV
            // 
            this.btnAddSV.Location = new System.Drawing.Point(5, 5);
            this.btnAddSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSV.Name = "btnAddSV";
            this.btnAddSV.Size = new System.Drawing.Size(96, 27);
            this.btnAddSV.TabIndex = 6;
            this.btnAddSV.Text = "Thêm";
            this.btnAddSV.UseVisualStyleBackColor = true;
            this.btnAddSV.Click += new System.EventHandler(this.btnAddSV_Click);
            // 
            // btnReloadSV
            // 
            this.btnReloadSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadSV.Location = new System.Drawing.Point(780, 5);
            this.btnReloadSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReloadSV.Name = "btnReloadSV";
            this.btnReloadSV.Size = new System.Drawing.Size(96, 27);
            this.btnReloadSV.TabIndex = 2;
            this.btnReloadSV.Text = "Tải lại";
            this.btnReloadSV.UseVisualStyleBackColor = true;
            this.btnReloadSV.Click += new System.EventHandler(this.btnReloadSV_Click);
            // 
            // 
            // btnSaveSV removed
            //
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(209, 5);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(124, 27);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(493, 8);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 22);
            this.txtSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(681, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 27);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridSinhVien
            // 
            this.gridSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSinhVien.Location = new System.Drawing.Point(5, 37);
            this.gridSinhVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSinhVien.Name = "gridSinhVien";
            this.gridSinhVien.RowHeadersWidth = 62;
            this.gridSinhVien.RowTemplate.Height = 28;
            this.gridSinhVien.Size = new System.Drawing.Size(871, 412);
            this.gridSinhVien.TabIndex = 0;
            // 
            // 
            // QuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 480);
            this.Controls.Add(this.tabMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLySinhVien";
            this.Text = "Quản lý việc làm sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabMain.ResumeLayout(false);
            this.tabSinhVien.ResumeLayout(false);
            this.tabSinhVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSinhVien)).EndInit();
            // Removed: tabBaoCao and tabThongBao layout calls
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSinhVien;
        private System.Windows.Forms.DataGridView gridSinhVien;
        // btnSaveSV removed
        private System.Windows.Forms.Button btnReloadSV;
        // Removed: tabBaoCao, gridReport, numFrom, numTo, cboReportType, btnGenReport, lblDungChuyenNganh
        // Removed: tabThongBao, gridThongBao
        private System.Windows.Forms.Button btnAddSV;

        private System.Windows.Forms.Button btnEditSV;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
