namespace QuanLySinhVien
{
    partial class XuLyXacThucForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChuaXacThuc;
        private System.Windows.Forms.TabPage tabDangCho;
        private System.Windows.Forms.TabPage tabDaXuLy;
        private System.Windows.Forms.DataGridView gridChuaXacThuc;
        private System.Windows.Forms.DataGridView gridDangCho;
        private System.Windows.Forms.DataGridView gridDaXuLy;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnGuiXacThuc;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblSelectedCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabChuaXacThuc = new System.Windows.Forms.TabPage();
            this.tabDangCho = new System.Windows.Forms.TabPage();
            this.tabDaXuLy = new System.Windows.Forms.TabPage();
            this.gridChuaXacThuc = new System.Windows.Forms.DataGridView();
            this.gridDangCho = new System.Windows.Forms.DataGridView();
            this.gridDaXuLy = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnGuiXacThuc = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            
            this.tabControl.SuspendLayout();
            this.tabChuaXacThuc.SuspendLayout();
            this.tabDangCho.SuspendLayout();
            this.tabDaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChuaXacThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDangCho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDaXuLy)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnThoat);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnTimKiem);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            this.panelTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(200, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(510, 10);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 32);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(160, 32);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabChuaXacThuc);
            this.tabControl.Controls.Add(this.tabDangCho);
            this.tabControl.Controls.Add(this.tabDaXuLy);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 550);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabChuaXacThuc
            // 
            this.tabChuaXacThuc.Controls.Add(this.gridChuaXacThuc);
            this.tabChuaXacThuc.Controls.Add(this.panelBottom);
            this.tabChuaXacThuc.Location = new System.Drawing.Point(4, 32);
            this.tabChuaXacThuc.Name = "tabChuaXacThuc";
            this.tabChuaXacThuc.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuaXacThuc.Size = new System.Drawing.Size(992, 514);
            this.tabChuaXacThuc.TabIndex = 0;
            this.tabChuaXacThuc.Text = "Chua xac thuc";
            this.tabChuaXacThuc.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.chkSelectAll);
            this.panelBottom.Controls.Add(this.lblSelectedCount);
            this.panelBottom.Controls.Add(this.btnGuiXacThuc);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 459);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(986, 52);
            this.panelBottom.TabIndex = 1;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkSelectAll.Location = new System.Drawing.Point(10, 15);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(120, 27);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Chon tat ca";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSelectedCount.Location = new System.Drawing.Point(160, 17);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedCount.TabIndex = 1;
            this.lblSelectedCount.Text = "Da chon: 0";
            // 
            // btnGuiXacThuc
            // 
            this.btnGuiXacThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuiXacThuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiXacThuc.Location = new System.Drawing.Point(800, 8);
            this.btnGuiXacThuc.Name = "btnGuiXacThuc";
            this.btnGuiXacThuc.Size = new System.Drawing.Size(180, 38);
            this.btnGuiXacThuc.TabIndex = 2;
            this.btnGuiXacThuc.Text = "Gui xac thuc";
            this.btnGuiXacThuc.UseVisualStyleBackColor = true;
            this.btnGuiXacThuc.Click += new System.EventHandler(this.btnGuiXacThuc_Click);
            // 
            // gridChuaXacThuc
            // 
            this.gridChuaXacThuc.AllowUserToAddRows = false;
            this.gridChuaXacThuc.AllowUserToDeleteRows = false;
            this.gridChuaXacThuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridChuaXacThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridChuaXacThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChuaXacThuc.Location = new System.Drawing.Point(3, 3);
            this.gridChuaXacThuc.MultiSelect = true;
            this.gridChuaXacThuc.Name = "gridChuaXacThuc";
            this.gridChuaXacThuc.RowHeadersVisible = false;
            this.gridChuaXacThuc.RowTemplate.Height = 32;
            this.gridChuaXacThuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChuaXacThuc.Size = new System.Drawing.Size(986, 456);
            this.gridChuaXacThuc.TabIndex = 0;
            this.gridChuaXacThuc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChuaXacThuc_CellValueChanged);
            this.gridChuaXacThuc.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridChuaXacThuc_CurrentCellDirtyStateChanged);
            // 
            // tabDangCho
            // 
            this.tabDangCho.Controls.Add(this.gridDangCho);
            this.tabDangCho.Location = new System.Drawing.Point(4, 32);
            this.tabDangCho.Name = "tabDangCho";
            this.tabDangCho.Padding = new System.Windows.Forms.Padding(3);
            this.tabDangCho.Size = new System.Drawing.Size(992, 514);
            this.tabDangCho.TabIndex = 1;
            this.tabDangCho.Text = "Dang cho phan hoi";
            this.tabDangCho.UseVisualStyleBackColor = true;
            // 
            // gridDangCho
            // 
            this.gridDangCho.AllowUserToAddRows = false;
            this.gridDangCho.AllowUserToDeleteRows = false;
            this.gridDangCho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDangCho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDangCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDangCho.Location = new System.Drawing.Point(3, 3);
            this.gridDangCho.Name = "gridDangCho";
            this.gridDangCho.ReadOnly = true;
            this.gridDangCho.RowHeadersVisible = false;
            this.gridDangCho.RowTemplate.Height = 32;
            this.gridDangCho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDangCho.Size = new System.Drawing.Size(986, 508);
            this.gridDangCho.TabIndex = 0;
            // 
            // tabDaXuLy
            // 
            this.tabDaXuLy.Controls.Add(this.gridDaXuLy);
            this.tabDaXuLy.Location = new System.Drawing.Point(4, 32);
            this.tabDaXuLy.Name = "tabDaXuLy";
            this.tabDaXuLy.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaXuLy.Size = new System.Drawing.Size(992, 514);
            this.tabDaXuLy.TabIndex = 2;
            this.tabDaXuLy.Text = "Da xu ly";
            this.tabDaXuLy.UseVisualStyleBackColor = true;
            // 
            // gridDaXuLy
            // 
            this.gridDaXuLy.AllowUserToAddRows = false;
            this.gridDaXuLy.AllowUserToDeleteRows = false;
            this.gridDaXuLy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDaXuLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDaXuLy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDaXuLy.Location = new System.Drawing.Point(3, 3);
            this.gridDaXuLy.Name = "gridDaXuLy";
            this.gridDaXuLy.ReadOnly = true;
            this.gridDaXuLy.RowHeadersVisible = false;
            this.gridDaXuLy.RowTemplate.Height = 32;
            this.gridDaXuLy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDaXuLy.Size = new System.Drawing.Size(986, 508);
            this.gridDaXuLy.TabIndex = 0;
            // 
            // XuLyXacThucForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Name = "XuLyXacThucForm";
            this.Text = "Quan ly Gui Yeu Cau Xac Thuc";
            this.Load += new System.EventHandler(this.XuLyXacThucForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabChuaXacThuc.ResumeLayout(false);
            this.tabDangCho.ResumeLayout(false);
            this.tabDaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChuaXacThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDangCho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDaXuLy)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
