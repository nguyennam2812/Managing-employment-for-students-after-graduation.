using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    partial class QuanLyLichSuThayDoiForm
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
            this.gridLog = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // gridLog
            // 
            this.gridLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLog.Location = new System.Drawing.Point(12, 12);
            this.gridLog.Name = "gridLog";
            this.gridLog.RowHeadersWidth = 62;
            this.gridLog.RowTemplate.Height = 28;
            this.gridLog.Size = new System.Drawing.Size(950, 500);
            this.gridLog.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(862, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // QuanLyLichSuThayDoiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 565);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridLog);
            this.Name = "QuanLyLichSuThayDoiForm";
            this.Text = "Lịch sử thay đổi thông tin";
            this.Load += new System.EventHandler(this.QuanLyLichSuThayDoiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLog)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView gridLog;
        private System.Windows.Forms.Button btnClose;
    }
}
