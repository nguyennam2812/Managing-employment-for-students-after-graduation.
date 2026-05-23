using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien.Dialogs
{
    public static class InputBox
    {
        public static string Show(string prompt, string title, string defaultValue = "")
        {
            Form promptForm = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 200, Width = 70, Top = 90, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Hủy", Left = 280, Width = 70, Top = 90, DialogResult = DialogResult.Cancel };

            confirmation.Click += (sender, e) => { promptForm.Close(); };
            cancel.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmation);
            promptForm.Controls.Add(cancel);
            promptForm.AcceptButton = confirmation;
            promptForm.CancelButton = cancel;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
