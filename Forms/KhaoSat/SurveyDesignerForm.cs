using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class SurveyDesignerForm : Form
    {
        public string JsonResult { get; private set; }
        private List<QuestionItem> _questions = new List<QuestionItem>();
        private QuestionItem _currentQuestion;

        public SurveyDesignerForm(string currentJson = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(currentJson))
            {
                try
                {
                    _questions = Deserialize(currentJson);
                }
                catch { _questions = new List<QuestionItem>(); }
            }
            RefreshList();
        }

        private void RefreshList()
        {
            lstQuestions.Items.Clear();
            foreach (var q in _questions)
            {
                lstQuestions.Items.Add($"[{q.Type}] {q.Question}");
            }
            if (_questions.Count > 0)
                lstQuestions.SelectedIndex = 0;
            else
                ClearDetail();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _currentQuestion = new QuestionItem
            {
                Id = _questions.Count + 1,
                Type = "Text",
                Question = "Câu hỏi mới",
                Options = new List<string>()
            };
            _questions.Add(_currentQuestion);
            RefreshList();
            lstQuestions.SelectedIndex = _questions.Count - 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex >= 0)
            {
                _questions.RemoveAt(lstQuestions.SelectedIndex);
                RefreshList();
            }
        }

        private void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex == -1) return;
            
            _currentQuestion = _questions[lstQuestions.SelectedIndex];
            
            txtQuestion.Text = _currentQuestion.Question;
            cboType.SelectedItem = _currentQuestion.Type;
            txtOptions.Text = string.Join("\r\n", _currentQuestion.Options);

            UpdateTypeState();
        }

        private void btnSaveQ_Click(object sender, EventArgs e)
        {
            if (_currentQuestion == null) return;

            _currentQuestion.Question = txtQuestion.Text;
            _currentQuestion.Type = cboType.SelectedItem?.ToString() ?? "Text";
            
            if (_currentQuestion.Type == "Radio" || _currentQuestion.Type == "Checkbox")
            {
                _currentQuestion.Options = txtOptions.Text
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();
            }
            else
            {
                _currentQuestion.Options.Clear();
            }

            // Update ListBox Text without full refresh if possible, or simple refresh
            int idx = lstQuestions.SelectedIndex;
            lstQuestions.Items[idx] = $"[{_currentQuestion.Type}] {_currentQuestion.Question}";
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            JsonResult = Serialize(_questions);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateTypeState()
        {
            string type = cboType.SelectedItem?.ToString();
            bool hasOptions = (type == "Radio" || type == "Checkbox");
            txtOptions.Enabled = hasOptions;
            lblOptions.Enabled = hasOptions;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTypeState();
        }
        
        // --- Serialization Helper ---
        private static string Serialize(List<QuestionItem> list)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<QuestionItem>));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, list);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        private static List<QuestionItem> Deserialize(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(List<QuestionItem>));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return (List<QuestionItem>)serializer.ReadObject(stream);
            }
        }
    }
}
