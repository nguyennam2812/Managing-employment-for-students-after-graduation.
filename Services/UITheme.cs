using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    /// <summary>
    /// Shared UI theme and styling utilities for consistent look across forms
    /// </summary>
    public static class UITheme
    {
        // ============ Colors ============
        // Primary palette (Indigo)
        public static readonly Color Primary = Color.FromArgb(99, 102, 241);      // Indigo-500
        public static readonly Color PrimaryDark = Color.FromArgb(79, 70, 229);   // Indigo-600
        public static readonly Color PrimaryLight = Color.FromArgb(238, 242, 255); // Indigo-50

        // Accent colors
        public static readonly Color Success = Color.FromArgb(34, 197, 94);       // Green-500
        public static readonly Color Warning = Color.FromArgb(249, 115, 22);      // Orange-500
        public static readonly Color Danger = Color.FromArgb(239, 68, 68);        // Red-500
        public static readonly Color Info = Color.FromArgb(59, 130, 246);         // Blue-500

        // Neutral colors (Slate)
        public static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);    // Slate-800
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139); // Slate-500
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);   // Slate-400
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240); // Slate-200
        public static readonly Color BackgroundLight = Color.FromArgb(248, 250, 252); // Slate-50
        public static readonly Color BackgroundMedium = Color.FromArgb(241, 245, 249); // Slate-100

        // ============ Fonts ============
        public static readonly Font HeaderFont = new Font("Segoe UI", 18, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static readonly Font SmallFont = new Font("Segoe UI", 9, FontStyle.Regular);

        // ============ Methods ============

        /// <summary>
        /// Style a button with primary theme
        /// </summary>
        public static void StylePrimaryButton(Button btn)
        {
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Hover effect
            btn.MouseEnter += (s, e) => btn.BackColor = PrimaryDark;
            btn.MouseLeave += (s, e) => btn.BackColor = Primary;
        }

        /// <summary>
        /// Style a neutral outline button (good for secondary or back actions)
        /// </summary>
        public static void StyleGhostButton(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = BorderColor;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = BodyFont;
            btn.Cursor = Cursors.Hand;
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            btn.MouseEnter += (s, e) => btn.BackColor = BackgroundMedium;
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
        }

        /// <summary>
        /// Style a button with secondary (gray) theme
        /// </summary>
        public static void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(100, 116, 139); // Slate-500
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(71, 85, 105); // Slate-600
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(100, 116, 139);
        }

        /// <summary>
        /// Style a DataGridView with modern appearance
        /// </summary>
        public static void StyleDataGridView(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.GridColor = BorderColor;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            
            // Header style
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Slate-100
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Row style
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.Font = BodyFont;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255); // Indigo-100
            grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
            grid.DefaultCellStyle.Padding = new Padding(5);
            grid.RowTemplate.Height = 35;

            // Alternating rows
            grid.AlternatingRowsDefaultCellStyle.BackColor = BackgroundLight;

            // Selection
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Style a TextBox with modern appearance
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = BodyFont;
            txt.BackColor = Color.White;
            txt.ForeColor = TextPrimary;
            txt.Margin = new Padding(0, 0, 8, 0);
        }

        /// <summary>
        /// Style a Panel as a card with shadow effect
        /// </summary>
        public static void StyleCard(Panel panel)
        {
            panel.BackColor = Color.White;
            panel.Padding = new Padding(15);
            
            panel.Paint += (s, e) =>
            {
                // Draw border
                using (Pen pen = new Pen(BorderColor, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            };
        }

        /// <summary>
        /// Apply base form defaults for consistent spacing and typography
        /// </summary>
        public static void ApplyFormDefaults(Form form)
        {
            form.BackColor = BackgroundLight;
            form.Font = BodyFont;
            form.Padding = new Padding(12);
        }

        /// <summary>
        /// Draw a gradient background on a form
        /// </summary>
        public static void DrawGradientBackground(Graphics g, Rectangle rect, Color color1, Color color2)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(brush, rect);
            }
        }

        /// <summary>
        /// Create a styled header panel with icon, title, and subtitle for forms
        /// </summary>
        public static Panel CreateFormHeader(string icon, string title, string subtitle = null, int height = 80)
        {
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = height;
            headerPanel.BackColor = Color.Transparent;
            headerPanel.Padding = new Padding(20, 15, 20, 15);

            // Icon + Title row
            Label lblTitle = new Label();
            lblTitle.Text = $"{icon}  {title}";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = TextPrimary;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.BackColor = Color.Transparent;
            headerPanel.Controls.Add(lblTitle);

            // Subtitle
            if (!string.IsNullOrEmpty(subtitle))
            {
                Label lblSub = new Label();
                lblSub.Text = subtitle;
                lblSub.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblSub.ForeColor = TextSecondary;
                lblSub.AutoSize = true;
                lblSub.Location = new Point(20, 50);
                lblSub.BackColor = Color.Transparent;
                headerPanel.Controls.Add(lblSub);
            }

            return headerPanel;
        }


        /// <summary>
        /// Style a ComboBox with modern appearance
        /// </summary>
        public static void StyleComboBox(ComboBox cbo)
        {
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.Font = BodyFont;
            cbo.BackColor = Color.White;
            cbo.ForeColor = TextPrimary;
        }

        /// <summary>
        /// Style a DateTimePicker with consistent appearance
        /// </summary>
        public static void StyleDateTimePicker(DateTimePicker dtp)
        {
            dtp.Font = BodyFont;
            dtp.CalendarForeColor = TextPrimary;
        }

        /// <summary>
        /// Style a TabControl with modern appearance
        /// </summary>
        public static void StyleTabControl(TabControl tab)
        {
            tab.Font = BodyFont;
            foreach (TabPage page in tab.TabPages)
            {
                page.BackColor = BackgroundLight;
            }
        }
    }
}
