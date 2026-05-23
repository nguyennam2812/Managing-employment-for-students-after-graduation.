using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Security;

namespace QuanLySinhVien.Dialogs
{
    public class LamKhaoSatForm : Form
    {
        private readonly PhieuKhaoSat _phieu;
        private readonly SurveyDbContext _db;
        private readonly Panel _pnlQuestions;
        private readonly Button _btnSubmit;
        
        public bool Completed { get; private set; }

        public LamKhaoSatForm(PhieuKhaoSat phieu, SurveyDbContext dbContext)
        {
            _phieu = phieu;
            _db = dbContext;

            Text = "Phiếu Khảo Sát Bắt Buộc: " + phieu.TenDotKhaoSat;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(600, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false; // Prevent closing via X

            var lblTitle = new Label
            {
                Text = phieu.TenDotKhaoSat,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            var lblInstruct = new Label
            {
                Text = "Vui lòng hoàn thành khảo sát này để tiếp tục truy cập hệ thống.",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Red,
                Height = 30
            };

            _pnlQuestions = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            _btnSubmit = new Button
            {
                Text = "Gửi bài khảo sát",
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            _btnSubmit.Click += OnSubmit;

            Controls.Add(_pnlQuestions);
            Controls.Add(_btnSubmit);
            Controls.Add(lblInstruct);
            Controls.Add(lblTitle);

            GenerateQuestions();
        }

        private void GenerateQuestions()
        {
            var content = _phieu.NoiDungCauHoi ?? "";
            var questions = content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int y = 10;
            int idx = 1;
            foreach (var q in questions)
            {
                if (string.IsNullOrWhiteSpace(q)) continue;

                var lbl = new Label
                {
                    Text = $"{idx}. {q}",
                    AutoSize = true,
                    MaximumSize = new Size(520, 0),
                    Location = new Point(10, y),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                _pnlQuestions.Controls.Add(lbl);
                y += lbl.Height + 5;

                var txt = new TextBox
                {
                    Multiline = true,
                    Height = 60,
                    Width = 520,
                    Location = new Point(10, y),
                    ScrollBars = ScrollBars.Vertical,
                    Tag = q // Store question text in Tag
                };
                _pnlQuestions.Controls.Add(txt);
                y += txt.Height + 20;

                idx++;
            }
        }

        private void OnSubmit(object sender, EventArgs e)
        {
            var answers = "";
            bool allFilled = true;

            foreach (Control c in _pnlQuestions.Controls)
            {
                if (c is TextBox txt)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        allFilled = false;
                        txt.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        txt.BackColor = Color.White;
                        var q = txt.Tag as string;
                        answers += $"Q: {q}\nA: {txt.Text.Trim()}\n-----------------\n";
                    }
                }
            }

            if (!allFilled)
            {
                MessageBox.Show("Vui lòng trả lời đầy đủ các câu hỏi.", "Chưa hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var currentStudentId = AuthContext.MaSinhVien;
                if (string.IsNullOrEmpty(currentStudentId))
                {
                    MessageBox.Show("Không xác định được sinh viên hiện tại. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                var kq = new KetQuaKhaoSat
                {
                    MaPhieu = _phieu.MaPhieu,
                    MaSV = currentStudentId,
                    NgayTraLoi = DateTime.Now,
                    NoiDungChiTiet = answers
                };

                _db.KetQuaKhaoSats.Add(kq);
                _db.SaveChanges();

                MessageBox.Show("Cảm ơn bạn đã hoàn thành khảo sát!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Completed = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu kết quả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
