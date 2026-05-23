namespace QuanLySinhVien
{
    partial class BaoCaoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label lblNganh;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblNganh = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            this.SuspendLayout();
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(70, 14);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(200, 28);
            this.cboKhoa.TabIndex = 0;
            // 
            // cboNganh
            // 
            this.cboNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(368, 14);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(200, 28);
            this.cboNganh.TabIndex = 1;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(642, 14);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(120, 28);
            this.cboNam.TabIndex = 2;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(19, 17);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(45, 20);
            this.lblKhoa.TabIndex = 3;
            this.lblKhoa.Text = "Khoa";
            // 
            // lblNganh
            // 
            this.lblNganh.AutoSize = true;
            this.lblNganh.Location = new System.Drawing.Point(292, 17);
            this.lblNganh.Name = "lblNganh";
            this.lblNganh.Size = new System.Drawing.Size(57, 20);
            this.lblNganh.TabIndex = 4;
            this.lblNganh.Text = "Ngành";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(602, 17);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(41, 20);
            this.lblNam.TabIndex = 5;
            this.lblNam.Text = "Năm";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(786, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 32);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Lọc/Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(920, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 32);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartLine, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartPie, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartBar, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1120, 620);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // chartLine
            // 
            this.chartLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLine.Location = new System.Drawing.Point(3, 3);
            this.chartLine.Name = "chartLine";
            this.chartLine.Size = new System.Drawing.Size(554, 304);
            this.chartLine.TabIndex = 0;
            this.chartLine.Text = "chart1";
            // 
            // chartPie
            // 
            this.chartPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPie.Location = new System.Drawing.Point(563, 3);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(554, 304);
            this.chartPie.TabIndex = 1;
            this.chartPie.Text = "chart2";
            // 
            // chartBar
            // 
            this.chartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBar.Location = new System.Drawing.Point(3, 313);
            this.chartBar.Name = "chartBar";
            this.chartBar.Size = new System.Drawing.Size(554, 304);
            this.chartBar.TabIndex = 2;
            this.chartBar.Text = "chart3";
            // 
            // BaoCaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.lblNganh);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.cboNganh);
            this.Controls.Add(this.cboKhoa);
            this.Name = "BaoCaoForm";
            this.Text = "Báo cáo & Thống kê";
            this.Load += new System.EventHandler(this.BaoCaoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

