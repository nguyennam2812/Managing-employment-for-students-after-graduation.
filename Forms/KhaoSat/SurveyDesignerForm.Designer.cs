namespace QuanLySinhVien
{
    partial class SurveyDesignerForm
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
            this.lstQuestions = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.btnSaveQ = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            
            this.panel1.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();
            
            // lstQuestions
            this.lstQuestions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstQuestions.FormattingEnabled = true;
            this.lstQuestions.ItemHeight = 16;
            this.lstQuestions.Location = new System.Drawing.Point(0, 0);
            this.lstQuestions.Name = "lstQuestions";
            this.lstQuestions.Size = new System.Drawing.Size(250, 450);
            this.lstQuestions.TabIndex = 0;
            this.lstQuestions.SelectedIndexChanged += new System.EventHandler(this.lstQuestions_SelectedIndexChanged);
            
            // panel1 (Bottom Buttons)
            this.panel1.Controls.Add(this.btnSaveAll);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(250, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 50);
            this.panel1.TabIndex = 1;
            
            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Thêm câu hỏi";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(120, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 30);
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // btnSaveAll
            this.btnSaveAll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveAll.BackColor = System.Drawing.Color.LightGreen;
            this.btnSaveAll.Location = new System.Drawing.Point(430, 10);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(100, 30);
            this.btnSaveAll.Text = "Hoàn tất";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);

            // grpDetail
            this.grpDetail.Controls.Add(this.btnSaveQ);
            this.grpDetail.Controls.Add(this.txtOptions);
            this.grpDetail.Controls.Add(this.lblOptions);
            this.grpDetail.Controls.Add(this.cboType);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.txtQuestion);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Location = new System.Drawing.Point(250, 0);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(550, 400);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.Text = "Chi tiết câu hỏi";
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Text = "Nội dung câu hỏi:";
            // txtQuestion
            this.txtQuestion.Location = new System.Drawing.Point(20, 50);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(500, 60);
            
            // label2Type
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 120);
            this.label2.Name = "label2";
            this.label2.Text = "Loại câu hỏi:";
            // cboType
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Items.AddRange(new object[] { "Text", "Radio", "Checkbox", "Number" });
            this.cboType.Location = new System.Drawing.Point(120, 117);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(150, 24);
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            
            // lblOptions
            this.lblOptions.AutoSize = true;
            this.lblOptions.Location = new System.Drawing.Point(20, 160);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Text = "Các lựa chọn (Mỗi dòng 1 cái):";
            // txtOptions
            this.txtOptions.Location = new System.Drawing.Point(20, 180);
            this.txtOptions.Multiline = true;
            this.txtOptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(500, 150);
            
            // btnSaveQ
            this.btnSaveQ.Location = new System.Drawing.Point(420, 340);
            this.btnSaveQ.Name = "btnSaveQ";
            this.btnSaveQ.Size = new System.Drawing.Size(100, 30);
            this.btnSaveQ.Text = "Cập nhật";
            this.btnSaveQ.Click += new System.EventHandler(this.btnSaveQ_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstQuestions);
            this.Name = "SurveyDesignerForm";
            this.Text = "Thiết kế phiếu khảo sát";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            
            this.panel1.ResumeLayout(false);
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox lstQuestions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.TextBox txtOptions;
        private System.Windows.Forms.Button btnSaveQ;

        private void ClearDetail() 
        {
            txtQuestion.Clear();
            txtOptions.Clear();
            cboType.SelectedIndex = -1;
            _currentQuestion = null;
        }
    }
}
