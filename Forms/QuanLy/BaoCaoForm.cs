using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLySinhVien.Data;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class BaoCaoForm : Form
    {
        private readonly SurveyDbContext _db = new SurveyDbContext();
        private readonly ReportService _report;

        public BaoCaoForm()
        {
            InitializeComponent();
            _report = new ReportService(_db);
        }

        private void BaoCaoForm_Load(object sender, EventArgs e)
        {
            // Báo cáo: ADMIN (Xem tất cả), GIÁO VIÊN (Xem của Khoa mình), SINH VIÊN (Không được xem)
            if (Security.AuthContext.IsStudent)
            {
                MessageBox.Show("Sinh viên không có quyền xem báo cáo.", 
                    "Truy cập bị từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            
            // Years (last 5)
            var year = DateTime.Now.Year;
            cboNam.Items.Clear();
            for (int i = 0; i < 5; i++) cboNam.Items.Add((year - i).ToString());
            if (cboNam.Items.Count > 0) cboNam.SelectedIndex = 0;
            RefreshCharts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCharts();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Quay về Dashboard
            var mainForm = this.Parent?.Parent as MainForm;
            if (mainForm != null)
            {
                mainForm.OpenChildInternal(new DashboardForm(mainForm));
            }
        }

        private void RefreshCharts()
        {
            try
            {
                int nam = DateTime.Now.Year;
                if (int.TryParse(cboNam.SelectedItem?.ToString(), out var selYear)) nam = selYear;

                // Line chart - Số sinh viên có việc theo tháng
                var perMonth = _report.DemSoLuongCoViecTheoThang(nam).ToList();
                chartLine.Series.Clear();
                var sLine = new Series("CoViec") { ChartType = SeriesChartType.Line, BorderWidth = 3 };
                foreach (var x in perMonth) sLine.Points.AddXY(x.Key, x.Count);
                chartLine.Series.Add(sLine);

                // Pie chart - Thống kê theo trạng thái xác thực
                var trangThai = _report.ThongKeTheoTrangThaiXacThuc().ToList();
                chartPie.Series.Clear();
                var sPie = new Series("TrangThai") { ChartType = SeriesChartType.Pie };
                foreach (var x in trangThai) sPie.Points.AddXY(x.Key, x.Count);
                chartPie.Series.Add(sPie);

                // Bar chart - Thống kê theo doanh nghiệp
                var doanhNghiep = _report.ThongKeTheoDoanhNghiep().Take(10).ToList(); // Top 10
                chartBar.Series.Clear();
                var sBar = new Series("DoanhNghiep") { ChartType = SeriesChartType.Column };
                foreach (var x in doanhNghiep) sBar.Points.AddXY(x.Key, x.Count);
                chartBar.Series.Add(sBar);
            }
            catch (Exception ex)
            {
                var root = ex; while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi tạo biểu đồ: " + root.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
