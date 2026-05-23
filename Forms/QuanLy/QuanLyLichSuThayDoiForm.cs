using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Models;

namespace QuanLySinhVien
{
    public partial class QuanLyLichSuThayDoiForm : Form
    {
        private readonly SurveyDbContext _db;
        private readonly string _filterRecordId;

        public QuanLyLichSuThayDoiForm(string filterRecordId = null)
        {
            InitializeComponent();
            _db = new SurveyDbContext(); 
            _filterRecordId = filterRecordId;

            if (!string.IsNullOrEmpty(_filterRecordId))
            {
                this.Text = $"Lịch sử thay đổi - {_filterRecordId}";
            }
        }

        private void QuanLyLichSuThayDoiForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var query = _db.AuditLogs.AsQueryable();

                if (!string.IsNullOrEmpty(_filterRecordId))
                {
                    query = query.Where(x => x.RecordId == _filterRecordId);
                }

                var data = query
                    .OrderByDescending(x => x.ChangedDate)
                    .ToList() // Execute query first before projecting to anonymous type if needed, or project directly
                    .Select(x => new
                    {
                        x.Id,
                        ThoiGian = x.ChangedDate,
                        NguoiThucHien = x.ChangedBy,
                        MaSinhVien = x.RecordId,
                        HanhDong = x.Action,
                        NoiDungCu = x.OldValue,
                        NoiDungMoi = x.NewValue
                    })
                    .ToList();

                gridLog.DataSource = data;

                // Format Grid
                if (gridLog.Columns["Id"] != null) gridLog.Columns["Id"].Visible = false;
                
                if (gridLog.Columns["ThoiGian"] != null) 
                {
                    gridLog.Columns["ThoiGian"].HeaderText = "Thời gian";
                    gridLog.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    gridLog.Columns["ThoiGian"].Width = 150;
                }

                if (gridLog.Columns["NguoiThucHien"] != null) gridLog.Columns["NguoiThucHien"].HeaderText = "Người thực hiện";
                if (gridLog.Columns["MaSinhVien"] != null) gridLog.Columns["MaSinhVien"].HeaderText = "Mã SV";
                if (gridLog.Columns["HanhDong"] != null) gridLog.Columns["HanhDong"].HeaderText = "Hành động";
                
                if (gridLog.Columns["NoiDungCu"] != null) 
                {
                    gridLog.Columns["NoiDungCu"].HeaderText = "Nội dung cũ";
                    gridLog.Columns["NoiDungCu"].Width = 200;
                }
                
                if (gridLog.Columns["NoiDungMoi"] != null) 
                {
                    gridLog.Columns["NoiDungMoi"].HeaderText = "Nội dung mới";
                    gridLog.Columns["NoiDungMoi"].Width = 200;
                }

                gridLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
