using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.Data;
using QuanLySinhVien.Schema;
using QuanLySinhVien.Services;

namespace QuanLySinhVien
{
    public partial class FrmDienKhaoSat : Form
    {
        private int _maPhieu;
        private string _maSV;
        private int? _targetLichSuId; // ID lịch sử cần sửa (nếu có)
        private PhieuKhaoSat _phieu;
        private LichSuCongTac _lichSuHienTai;

        public FrmDienKhaoSat(int maPhieu, string maSV, int? maLichSu = null)
        {
            InitializeComponent();
            _maPhieu = maPhieu;
            _maSV = maSV;
            _targetLichSuId = maLichSu;
            this.Load += FrmDienKhaoSat_Load;
        }

        private void FrmDienKhaoSat_Load(object sender, EventArgs e)
        {
            LoadDoanhNghiepSuggestions();
            LoadPhieuKhaoSat();
            LoadLichSuCongTacHienTai();
        }

        private void LoadDoanhNghiepSuggestions()
        {
            // TextBox thay vì ComboBox - không cần load danh sách nữa
            // Người dùng tự nhập tay tên doanh nghiệp
        }

        private List<(int QId, Control InputCtrl, string Type)> _dynamicInputs = new List<(int, Control, string)>();

        private void LoadPhieuKhaoSat()
        {
            try
            {
                using (var db = new SurveyDbContext())
                {
                    if (_maPhieu == 0)
                    {
                        // Chế độ Edit: Ẩn thông tin phiếu, đổi tiêu đề
                        this.Text = "Cập nhật lịch sử công tác";
                        lblTieuDe.Text = "📝 Cập nhật lịch sử công tác";
                        lblTenPhieu.Visible = false;
                        lblHuongDan.Visible = false;
                        pnlQuestions.Visible = false;
                        lblNoiDung.Visible = false;
                        txtNoiDung.Visible = false;
                        
                        // Resize form cho gọn
                        this.Height = 450;
                        pnlBottom.Top = 380;
                        
                        return;
                    }

                    _phieu = db.PhieuKhaoSats.Find(_maPhieu);
                    if (_phieu == null)
                    {
                        MessageBox.Show("Không tìm thấy phiếu khảo sát.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }

                    lblTenPhieu.Text = _phieu.TenDotKhaoSat;
                    
                    // Render câu hỏi động
                    RenderDynamicQuestions(_phieu.NoiDungCauHoi);

                    // Load kết quả đã có (nếu có) để điền sẵn
                    var ketQua = db.KetQuaKhaoSats
                        .FirstOrDefault(k => k.MaPhieu == _maPhieu && k.MaSV == _maSV);
                    
                    if (ketQua != null)
                    {
                        // Logic load lại câu trả lời cũ sẽ phức tạp (cần parse JSON/String để fill control)
                        // Tạm thời chỉ load ghi chú. 
                        // TODO: Implement parsing old answers if needed
                        txtNoiDung.Text = "Ghi chú từ lần trước: " + (ketQua.NoiDungChiTiet ?? "");
                    }
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi tải phiếu: " + root.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLichSuCongTacHienTai()
        {
            try
            {
                using (var db = new SurveyDbContext())
                {
                    // Nếu có ID cụ thể, load theo ID. Nếu không, lấy mới nhất.
                    if (_targetLichSuId.HasValue)
                    {
                        _lichSuHienTai = db.LichSuCongTacs.Find(_targetLichSuId.Value);
                    }
                    else
                    {
                        _lichSuHienTai = db.LichSuCongTacs
                            .Where(l => l.MaSV == _maSV)
                            .OrderByDescending(l => l.NgayBatDau)
                            .FirstOrDefault();
                    }

                    if (_lichSuHienTai != null)
                    {
                        // Điền sẵn thông tin
                        if (_lichSuHienTai.MaDN > 0)
                        {
                            // Lấy tên doanh nghiệp để hiển thị
                            var dn = db.DoanhNghieps.Find(_lichSuHienTai.MaDN);
                            if (dn != null)
                                txtDoanhNghiep.Text = dn.TenDN;
                        }
                        
                        txtViTri.Text = _lichSuHienTai.ViTriCongViec ?? "";
                        txtMucLuong.Text = _lichSuHienTai.MucLuong?.ToString("N0") ?? "";
                        chkDungChuyenNganh.Checked = _lichSuHienTai.DungChuyenNganh ?? false;
                        
                        if (!string.IsNullOrEmpty(_lichSuHienTai.TrangThai))
                        {
                            cboTrangThai.Text = _lichSuHienTai.TrangThai;
                        }
                        else
                        {
                            cboTrangThai.SelectedIndex = 0; // Đang làm
                        }
                    }
                    else
                    {
                        cboTrangThai.SelectedIndex = 0; // Đang làm
                    }
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                // Không hiển thị lỗi, chỉ log
                System.Diagnostics.Debug.WriteLine("Lỗi load lịch sử: " + root.Message);
            }
        }

        private void RenderDynamicQuestions(string json)
        {
            pnlQuestions.Controls.Clear();
            _dynamicInputs.Clear();
            
            if (string.IsNullOrEmpty(json)) return;

            List<QuestionItem> questions;
            try 
            {
                questions = Deserialize(json);
            }
            catch 
            {
                return;
            }

            foreach (var q in questions)
            {
                // Container for each question
                var pnlItem = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    Width = pnlQuestions.Width - 30, // Padding
                    Margin = new Padding(0, 0, 0, 15)
                };

                // Label
                var lblQ = new Label
                {
                    Text = $"{q.Id}. {q.Question}",
                    AutoSize = true,
                    Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold),
                    MaximumSize = new System.Drawing.Size(pnlItem.Width, 0)
                };
                pnlItem.Controls.Add(lblQ);

                Control inputCtrl = null;

                if (q.Type == "Text")
                {
                    var txt = new TextBox { Width = 400, Multiline = true, Height = 60 };
                    pnlItem.Controls.Add(txt);
                    inputCtrl = txt;
                }
                else if (q.Type == "Number")
                {
                    var num = new NumericUpDown { Width = 150, Maximum = 1000000000 };
                    pnlItem.Controls.Add(num);
                    inputCtrl = num;
                }
                else if (q.Type == "Radio")
                {
                    var pnlOpts = new Panel { AutoSize = true };
                    int innerY = 0;
                    foreach (var opt in q.Options)
                    {
                        var radio = new RadioButton { Text = opt, Location = new System.Drawing.Point(0, innerY), AutoSize = true };
                        pnlOpts.Controls.Add(radio);
                        innerY += 25;
                    }
                    pnlItem.Controls.Add(pnlOpts);
                    inputCtrl = pnlOpts;
                }
                else if (q.Type == "Checkbox")
                {
                    var pnlOpts = new Panel { AutoSize = true };
                    int innerY = 0;
                    foreach (var opt in q.Options)
                    {
                        var chk = new CheckBox { Text = opt, Location = new System.Drawing.Point(0, innerY), AutoSize = true };
                        pnlOpts.Controls.Add(chk);
                        innerY += 25;
                    }
                    pnlItem.Controls.Add(pnlOpts);
                    inputCtrl = pnlOpts;
                }

                if (inputCtrl != null)
                {
                    _dynamicInputs.Add((q.Id, inputCtrl, q.Type));
                }

                pnlQuestions.Controls.Add(pnlItem);
            }
        }

        private static List<QuestionItem> Deserialize(string json)
        {
            try
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<QuestionItem>));
                using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
                {
                    return (List<QuestionItem>)serializer.ReadObject(stream);
                }
            }
            catch
            {
                return new List<QuestionItem>();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate doanh nghiệp
            string tenDoanhNghiep = txtDoanhNghiep.Text?.Trim();
            if (string.IsNullOrWhiteSpace(tenDoanhNghiep))
            {
                MessageBox.Show("Vui lòng nhập tên doanh nghiệp.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate mức lương
            decimal? mucLuong = null;
            if (!string.IsNullOrWhiteSpace(txtMucLuong.Text))
            {
                var luongText = txtMucLuong.Text.Replace(",", "").Replace(".", "").Trim();
                if (decimal.TryParse(luongText, out decimal parsedLuong))
                {
                    mucLuong = parsedLuong;
                }
                else
                {
                    MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var db = new SurveyDbContext())
                {
                    // ========== Tìm hoặc tạo DoanhNghiep ==========
                    var existingDN = db.DoanhNghieps.FirstOrDefault(d => d.TenDN.ToLower() == tenDoanhNghiep.ToLower());
                    int maDN;
                    
                    if (existingDN != null)
                    {
                        maDN = existingDN.MaDN;
                    }
                    else
                    {
                        // Tạo doanh nghiệp mới
                        var newDN = new DoanhNghiep
                        {
                            TenDN = tenDoanhNghiep,
                            DiaChi = txtDiaChi.Text?.Trim() ?? "",
                            LinhVucHoatDong = txtLinhVuc.Text?.Trim() ?? "",
                            EmailLienHe = txtEmail.Text?.Trim() ?? "",
                            SoDienThoai = txtSoDienThoai.Text?.Trim() ?? ""
                        };
                        db.DoanhNghieps.Add(newDN);
                        db.SaveChanges();
                        maDN = newDN.MaDN;
                    }

                    // ========== Lưu/Cập nhật LichSuCongTac ==========
                    LichSuCongTac lichSu = null;
                    
                    if (_targetLichSuId.HasValue)
                    {
                         // Chế độ Sửa: Tìm theo ID
                        lichSu = db.LichSuCongTacs.Find(_targetLichSuId.Value);
                        if (lichSu != null)
                        {
                            // Cập nhật doanh nghiệp mới (nếu thay đổi)
                            lichSu.MaDN = maDN;
                        }
                    }
                    else
                    {
                         // Chế độ Khai báo mới: Tìm theo (MaSV, MaDN) hoặc tạo mới
                        lichSu = db.LichSuCongTacs
                            .FirstOrDefault(l => l.MaSV == _maSV && l.MaDN == maDN);
                    }

                    if (lichSu == null)
                    {
                        // Tạo mới
                        lichSu = new LichSuCongTac
                        {
                            MaSV = _maSV,
                            MaDN = maDN,
                            NgayBatDau = DateTime.Now
                        };
                        db.LichSuCongTacs.Add(lichSu);
                    }

                    // Cập nhật thông tin
                    lichSu.ViTriCongViec = txtViTri.Text?.Trim();
                    lichSu.MucLuong = mucLuong;
                    lichSu.DungChuyenNganh = chkDungChuyenNganh.Checked;
                    lichSu.TrangThai = cboTrangThai.Text;
                    lichSu.TrangThaiXacThuc = "Chưa xác thực"; // YÊU CẦU: Mặc định là "Chưa xác thực" khi sinh viên tự khai báo qua khảo sát

                    // ========== Lưu/Cập nhật KetQuaKhaoSat ==========
                    
                    if (_maPhieu > 0)
                    {
                        // 1. Collect Dynamic Answers
                        var answers = new List<string>();
                        foreach(var item in _dynamicInputs)
                        {
                            string ans = "";
                            if (item.Type == "Text")
                                ans = ((TextBox)item.InputCtrl).Text;
                            else if (item.Type == "Number")
                                ans = ((NumericUpDown)item.InputCtrl).Value.ToString();
                            else if (item.Type == "Radio")
                            {
                                 foreach(Control c in item.InputCtrl.Controls)
                                 {
                                     if (c is RadioButton rb && rb.Checked)
                                     {
                                         ans = rb.Text;
                                         break;
                                     }
                                 }
                            }
                            else if (item.Type == "Checkbox")
                            {
                                var list = new List<string>();
                                foreach (Control c in item.InputCtrl.Controls)
                                {
                                    if (c is CheckBox chk && chk.Checked)
                                    {
                                        list.Add(chk.Text);
                                    }
                                }
                                ans = string.Join(", ", list);
                            }
                            answers.Add($"Q{item.QId}: {ans}");
                        }

                        // 2. Append Note
                        if (!string.IsNullOrWhiteSpace(txtNoiDung.Text))
                        {
                            answers.Add($"[Ghi chú]: {txtNoiDung.Text}");
                        }
                        
                        string finalContent = string.Join("\n", answers);


                        var ketQua = db.KetQuaKhaoSats
                            .FirstOrDefault(k => k.MaPhieu == _maPhieu && k.MaSV == _maSV);
                        
                        if (ketQua != null)
                        {
                            ketQua.NoiDungChiTiet = finalContent;
                            ketQua.NgayTraLoi = DateTime.Now;
                        }
                        else
                        {
                            ketQua = new KetQuaKhaoSat
                            {
                                MaPhieu = _maPhieu,
                                MaSV = _maSV,
                                NgayTraLoi = DateTime.Now,
                                NoiDungChiTiet = finalContent
                            };
                            db.KetQuaKhaoSats.Add(ketQua);
                        }
                    }

                    db.SaveChanges();
                    
                    MessageBox.Show("Đã lưu kết quả khảo sát thành công!\nCảm ơn bạn đã tham gia khảo sát.", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                var root = ex;
                while (root.InnerException != null) root = root.InnerException;
                MessageBox.Show("Lỗi lưu kết quả: " + root.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn hủy khảo sát không? Dữ liệu chưa lưu sẽ bị mất.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnTimDN_Click(object sender, EventArgs e)
        {
            var tenDN = txtDoanhNghiep.Text?.Trim();
            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng nhập tên doanh nghiệp để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var db = new SurveyDbContext())
                {
                    // Find first matching company by name (case-insensitiveish)
                    var dn = db.DoanhNghieps
                               .FirstOrDefault(d => d.TenDN.ToLower().Contains(tenDN.ToLower()));

                    if (dn != null)
                    {
                        txtDoanhNghiep.Text = dn.TenDN; // Auto correct casing
                        txtDiaChi.Text = dn.DiaChi;
                        txtLinhVuc.Text = dn.LinhVucHoatDong;
                        txtEmail.Text = dn.EmailLienHe;
                        txtSoDienThoai.Text = dn.SoDienThoai;
                        
                        MessageBox.Show("Đã tìm thấy doanh nghiệp: " + dn.TenDN, "Tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy doanh nghiệp nào có tên chứa: " + tenDN + "\nBạn có thể tự nhập thông tin mới.", 
                            "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
