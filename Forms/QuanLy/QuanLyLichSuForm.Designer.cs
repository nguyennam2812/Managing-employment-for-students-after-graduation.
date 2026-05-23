 namespace QuanLySinhVien
{
    partial class QuanLyLichSuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 60);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 28;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1000, 540);
            this.grid.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnThoat);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(12, 14);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(180, 32);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "← Quay về Dashboard";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(200, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 32);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(676, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(224, 26);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(906, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // QuanLyLichSuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyLichSuForm";
            this.Text = "Quản lý Lịch sử công tác";
            this.Load += new System.EventHandler(this.QuanLyLichSuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

