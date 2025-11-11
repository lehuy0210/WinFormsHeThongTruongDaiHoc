using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsHeThongTruongDaiHoc.Form_Quan_Ly_Dao_Tao
{
    // ==================== PRESENTATION LAYER - FORM QUẢN LÝ ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ GUI PROGRAMMING: Windows Forms, Controls (DataGridView, Button, ComboBox, TextBox)
    // 2️⃣ EVENT-DRIVEN PROGRAMMING: Event handlers, Click events, SelectionChanged events
    // 3️⃣ DATA BINDING: Binding List<T> to DataGridView, Auto-refresh UI
    // 4️⃣ OBJECT-ORIENTED PROGRAMMING: Classes, Objects, Method calls
    // 5️⃣ N-LAYER ARCHITECTURE: UI → BLL → DTO interaction
    //
    // 📖 TÀI LIỆU THAM KHẢO:
    // Chương 5: Windows Forms Programming - Controls and Event Handling
    // Chương 6: Data Binding và DataGridView
    //
    // 💡 MỤC ĐÍCH:
    // Form này quản lý các chương trình đào tạo của trường (Bachelor, Master, PhD programs)
    // Cho phép: Thêm, Xóa, Sửa, Tìm kiếm, Sắp xếp, Thống kê chương trình đào tạo
    //
    // 🎯 WORKFLOW:
    // User Click Button → Event Handler → BLL Method → DTO Update → Refresh DataGridView

    public partial class FormQuanLyDaoTao : Form
    {
        // ==================== PRIVATE FIELDS ====================
        // Quản lý danh sách chương trình đào tạo trong memory
        private QuanLyDaoTao quanLy;

        // 6 BLL classes cho các chức năng CRUD + Search + Sort + Statistics
        private ChucNangThemThongTinDaoTao chucNangThem;
        private ChucNangXoaThongTinDaoTao chucNangXoa;
        private ChucNangSuaThongTinDaoTao chucNangSua;
        private ChucNangTimKiemThongTinDaoTao chucNangTimKiem;
        private ChucNangSapXepThongTinDaoTao chucNangSapXep;
        private ChucNangThongKeThongTinDaoTao chucNangThongKe;

        // UI Controls
        private DataGridView dataGridView;
        private Button btnThem, btnXoa, btnSua, btnTimKiem, btnLamMoi, btnThongKe;
        private Button btnXuatExcel;
        private TextBox txtTimKiem;
        private ComboBox cboKhoa, cboBacDaoTao, cboTrangThai;
        private Label lblTimKiem, lblKhoa, lblBacDaoTao, lblTrangThai;

        // ==================== CONSTRUCTOR ====================
        public FormQuanLyDaoTao()
        {
            InitializeComponent();

            // Khởi tạo QuanLyDaoTao object (DTO layer)
            quanLy = new QuanLyDaoTao();

            // Khởi tạo 6 BLL objects
            chucNangThem = new ChucNangThemThongTinDaoTao();
            chucNangXoa = new ChucNangXoaThongTinDaoTao();
            chucNangSua = new ChucNangSuaThongTinDaoTao();
            chucNangTimKiem = new ChucNangTimKiemThongTinDaoTao();
            chucNangSapXep = new ChucNangSapXepThongTinDaoTao();
            chucNangThongKe = new ChucNangThongKeThongTinDaoTao();

            // Load dữ liệu mẫu (sample data)
            LoadDuLieuMau();

            // Refresh DataGridView
            HienThiDanhSach();
        }

        // ==================== HIỂN THỊ DANH SÁCH ====================
        // 🔍 MỤC ĐÍCH: Bind List<ThongTinDaoTao> vào DataGridView
        // 📝 CÁC BƯỚC:
        // 1. Lấy danh sách từ QuanLyDaoTao
        // 2. Set DataSource = null (clear old data)
        // 3. Set DataSource = danh sách mới
        // 4. Auto-resize columns
        private void HienThiDanhSach()
        {
            try
            {
                List<ThongTinDaoTao> danhSach = quanLy.LayDanhSachChuongTrinh();
                dataGridView.DataSource = null;
                dataGridView.DataSource = danhSach;

                // Tùy chỉnh hiển thị columns
                if (dataGridView.Columns.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false; // Ẩn ID column
                    dataGridView.Columns["MaChuongTrinh"].HeaderText = "Mã chương trình";
                    dataGridView.Columns["TenChuongTrinh"].HeaderText = "Tên chương trình";
                    dataGridView.Columns["BacDaoTao"].HeaderText = "Bậc đào tạo";
                    dataGridView.Columns["Khoa"].HeaderText = "Khoa";
                    dataGridView.Columns["SoNamDaoTao"].HeaderText = "Số năm";
                    dataGridView.Columns["TongTinChi"].HeaderText = "Tổng tín chỉ";
                    dataGridView.Columns["NamBatDau"].HeaderText = "Năm bắt đầu";
                    dataGridView.Columns["MoTa"].HeaderText = "Mô tả";
                    dataGridView.Columns["DieuKienTotNghiep"].HeaderText = "Điều kiện tốt nghiệp";
                    dataGridView.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dataGridView.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị danh sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON THÊM - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Thêm chương trình đào tạo mới
        // 📝 WORKFLOW:
        // 1. Hiển thị dialog để nhập thông tin
        // 2. Validate input
        // 3. Gọi BLL.ThemChuongTrinh()
        // 4. Refresh DataGridView
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo object mới
                ThongTinDaoTao ctMoi = new ThongTinDaoTao();

                // TODO: Hiển thị dialog form để nhập thông tin
                // Tạm thời dùng dữ liệu mẫu để demo
                ctMoi.MaChuongTrinh = chucNangThem.TaoMaChuongTrinhTuDong(
                    quanLy.LayDanhSachChuongTrinh(), "DEMO", DateTime.Now.Year);
                ctMoi.TenChuongTrinh = "Chương trình mẫu";
                ctMoi.BacDaoTao = "Cử nhân";
                ctMoi.Khoa = "Khoa Demo";
                ctMoi.SoNamDaoTao = 4;
                ctMoi.TongTinChi = 120;
                ctMoi.NamBatDau = DateTime.Now.Year;
                ctMoi.MoTa = "Đây là chương trình mẫu";
                ctMoi.DieuKienTotNghiep = "Hoàn thành 120 tín chỉ";
                ctMoi.TrangThai = "Đang áp dụng";

                // Gọi BLL để thêm
                bool ketQua = chucNangThem.ThemChuongTrinh(quanLy.LayDanhSachChuongTrinh(), ctMoi);

                if (ketQua)
                {
                    MessageBox.Show("Thêm chương trình đào tạo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach(); // Refresh UI
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo thất bại! Mã đã tồn tại hoặc dữ liệu không hợp lệ.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON XÓA - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Xóa chương trình đào tạo đã chọn
        // 📝 WORKFLOW:
        // 1. Lấy row được chọn trong DataGridView
        // 2. Confirm xóa (MessageBox Yes/No)
        // 3. Gọi BLL.XoaChuongTrinh()
        // 4. Refresh DataGridView
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chương trình đào tạo cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã chương trình từ row được chọn
                string maChuongTrinh = dataGridView.SelectedRows[0].Cells["MaChuongTrinh"].Value.ToString();

                // Confirm xóa
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa chương trình {maChuongTrinh}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool ketQua = chucNangXoa.XoaChuongTrinh(quanLy.LayDanhSachChuongTrinh(), maChuongTrinh);

                    if (ketQua)
                    {
                        MessageBox.Show("Xóa chương trình đào tạo thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach(); // Refresh UI
                    }
                    else
                    {
                        MessageBox.Show("Xóa chương trình đào tạo thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON SỬA - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Sửa thông tin chương trình đào tạo
        // 📝 WORKFLOW:
        // 1. Lấy chương trình được chọn
        // 2. Hiển thị dialog với thông tin hiện tại
        // 3. User sửa thông tin
        // 4. Gọi BLL.SuaChuongTrinh()
        // 5. Refresh DataGridView
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chương trình đào tạo cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maCu = dataGridView.SelectedRows[0].Cells["MaChuongTrinh"].Value.ToString();

                // TODO: Hiển thị dialog form để sửa thông tin
                // Tạm thời dùng dữ liệu mẫu
                ThongTinDaoTao ctMoi = new ThongTinDaoTao
                {
                    MaChuongTrinh = maCu,
                    TenChuongTrinh = "Chương trình đã cập nhật",
                    BacDaoTao = "Cử nhân",
                    Khoa = "Khoa CNTT",
                    SoNamDaoTao = 4,
                    TongTinChi = 130,
                    NamBatDau = DateTime.Now.Year,
                    MoTa = "Đã cập nhật mô tả",
                    DieuKienTotNghiep = "Hoàn thành 130 tín chỉ",
                    TrangThai = "Đang áp dụng"
                };

                bool ketQua = chucNangSua.SuaChuongTrinh(quanLy.LayDanhSachChuongTrinh(), maCu, ctMoi);

                if (ketQua)
                {
                    MessageBox.Show("Sửa chương trình đào tạo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach(); // Refresh UI
                }
                else
                {
                    MessageBox.Show("Sửa chương trình đào tạo thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON TÌM KIẾM - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Tìm kiếm chương trình theo nhiều tiêu chí
        // 📝 WORKFLOW:
        // 1. Lấy giá trị từ TextBox và ComboBoxes
        // 2. Gọi BLL.TimKiem() với các filters
        // 3. Hiển thị kết quả trong DataGridView
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinDaoTao> ketQua = quanLy.LayDanhSachChuongTrinh();

                // Tìm theo mã chương trình
                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    ketQua = chucNangTimKiem.TimKiemTheoMa(ketQua, txtTimKiem.Text);
                }

                // Lọc theo Khoa
                if (cboKhoa.SelectedIndex > 0)
                {
                    string khoa = cboKhoa.SelectedItem.ToString();
                    ketQua = chucNangTimKiem.TimKiemTheoKhoa(ketQua, khoa);
                }

                // Lọc theo Bậc đào tạo
                if (cboBacDaoTao.SelectedIndex > 0)
                {
                    string bac = cboBacDaoTao.SelectedItem.ToString();
                    ketQua = chucNangTimKiem.TimKiemTheoBac(ketQua, bac);
                }

                // Lọc theo Trạng thái
                if (cboTrangThai.SelectedIndex > 0)
                {
                    string trangThai = cboTrangThai.SelectedItem.ToString();
                    ketQua = ketQua.Where(ct => ct.TrangThai == trangThai).ToList();
                }

                // Hiển thị kết quả
                dataGridView.DataSource = null;
                dataGridView.DataSource = ketQua;

                MessageBox.Show($"Tìm thấy {ketQua.Count} kết quả!", "Kết quả tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON LÀM MỚI - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Reset filters và hiển thị toàn bộ danh sách
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.Clear();
                cboKhoa.SelectedIndex = 0;
                cboBacDaoTao.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== BUTTON THỐNG KÊ - EVENT HANDLER ====================
        // 🔍 MỤC ĐÍCH: Hiển thị thống kê chương trình đào tạo theo Khoa và Bậc
        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinDaoTao> danhSach = quanLy.LayDanhSachChuongTrinh();

                // Thống kê theo Khoa
                Dictionary<string, int> thongKeKhoa = chucNangThongKe.ThongKeTheoKhoa(danhSach);

                // Thống kê theo Bậc đào tạo
                Dictionary<string, int> thongKeBac = chucNangThongKe.ThongKeTheoBac(danhSach);

                // Hiển thị kết quả
                string thongBao = "===== THỐNG KÊ CHƯƠNG TRÌNH ĐÀO TẠO =====\n\n";
                thongBao += "THEO KHOA:\n";
                foreach (var item in thongKeKhoa)
                {
                    thongBao += $"- {item.Key}: {item.Value} chương trình\n";
                }

                thongBao += "\nTHEO BẬC ĐÀO TẠO:\n";
                foreach (var item in thongKeBac)
                {
                    thongBao += $"- {item.Key}: {item.Value} chương trình\n";
                }

                MessageBox.Show(thongBao, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EXPORT FUNCTIONALITY ====================

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Xuất dữ liệu sang CSV (Excel)",
                    FileName = $"DaoTao_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ChucNangXuatCSV xuatCSV = new ChucNangXuatCSV();
                    bool ketQua = xuatCSV.XuatDanhSachDaoTao(
                        quanLy.LayDanhSachChuongTrinh(),
                        saveDialog.FileName);

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất file CSV thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nFile có thể mở bằng Microsoft Excel.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{saveDialog.FileName}\"");
                    }
                    else
                    {
                        MessageBox.Show("Xuất file thất bại! Không có dữ liệu để xuất.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DỮ LIỆU MẪU ====================
        // 🔍 MỤC ĐÍCH: Tạo 5 chương trình đào tạo mẫu để demo
        private void LoadDuLieuMau()
        {
            List<ThongTinDaoTao> danhSach = quanLy.LayDanhSachChuongTrinh();

            // Chương trình 1: Cử nhân CNTT
            chucNangThem.ThemChuongTrinh(danhSach, new ThongTinDaoTao
            {
                MaChuongTrinh = "CNTT2024",
                TenChuongTrinh = "Cử nhân Công nghệ thông tin",
                BacDaoTao = "Cử nhân",
                Khoa = "Khoa CNTT",
                SoNamDaoTao = 4,
                TongTinChi = 120,
                NamBatDau = 2024,
                MoTa = "Chương trình đào tạo chuyên sâu về lập trình, cơ sở dữ liệu, mạng máy tính",
                DieuKienTotNghiep = "Hoàn thành 120 tín chỉ, TOEIC 450+, Khóa luận tốt nghiệp",
                TrangThai = "Đang áp dụng"
            });

            // Chương trình 2: Thạc sĩ CNTT
            chucNangThem.ThemChuongTrinh(danhSach, new ThongTinDaoTao
            {
                MaChuongTrinh = "CNTT-TH2024",
                TenChuongTrinh = "Thạc sĩ Công nghệ thông tin",
                BacDaoTao = "Thạc sĩ",
                Khoa = "Khoa CNTT",
                SoNamDaoTao = 2,
                TongTinChi = 60,
                NamBatDau = 2024,
                MoTa = "Nghiên cứu sâu về AI, Machine Learning, Big Data",
                DieuKienTotNghiep = "Hoàn thành 60 tín chỉ, Luận văn thạc sĩ, Công bố 1 bài báo",
                TrangThai = "Đang áp dụng"
            });

            // Chương trình 3: Cử nhân Kinh tế
            chucNangThem.ThemChuongTrinh(danhSach, new ThongTinDaoTao
            {
                MaChuongTrinh = "KT2024",
                TenChuongTrinh = "Cử nhân Kinh tế",
                BacDaoTao = "Cử nhân",
                Khoa = "Khoa Kinh tế",
                SoNamDaoTao = 4,
                TongTinChi = 120,
                NamBatDau = 2024,
                MoTa = "Đào tạo về quản trị kinh doanh, tài chính, marketing",
                DieuKienTotNghiep = "Hoàn thành 120 tín chỉ, Thực tập 3 tháng",
                TrangThai = "Đang áp dụng"
            });

            // Chương trình 4: Tiến sĩ CNTT
            chucNangThem.ThemChuongTrinh(danhSach, new ThongTinDaoTao
            {
                MaChuongTrinh = "CNTT-TS2023",
                TenChuongTrinh = "Tiến sĩ Công nghệ thông tin",
                BacDaoTao = "Tiến sĩ",
                Khoa = "Khoa CNTT",
                SoNamDaoTao = 4,
                TongTinChi = 90,
                NamBatDau = 2023,
                MoTa = "Nghiên cứu độc lập về các chủ đề tiên tiến trong CNTT",
                DieuKienTotNghiep = "90 tín chỉ, Luận án tiến sĩ, Công bố 3 bài báo ISI/Scopus",
                TrangThai = "Đang áp dụng"
            });

            // Chương trình 5: Cử nhân Y khoa (Ngừng tuyển)
            chucNangThem.ThemChuongTrinh(danhSach, new ThongTinDaoTao
            {
                MaChuongTrinh = "YK2020",
                TenChuongTrinh = "Cử nhân Y khoa",
                BacDaoTao = "Cử nhân",
                Khoa = "Khoa Y",
                SoNamDaoTao = 6,
                TongTinChi = 180,
                NamBatDau = 2020,
                MoTa = "Đào tạo bác sĩ đa khoa",
                DieuKienTotNghiep = "Hoàn thành 180 tín chỉ, Thực hành lâm sàng 1 năm",
                TrangThai = "Ngừng tuyển"
            });
        }

        // ==================== GIẢI THÍCH KIẾN TRÚC N-LAYER ====================
        //
        // 📊 KIẾN TRÚC 3 TẦNG (N-LAYER ARCHITECTURE):
        //
        // ┌─────────────────────────────────────────────────────────────────┐
        // │  PRESENTATION LAYER (UI Layer) - FormQuanLyDaoTao.cs           │
        // │  - Hiển thị giao diện cho user                                 │
        // │  - Xử lý events (Button clicks, ComboBox selection)            │
        // │  - Gọi methods từ BLL layer                                    │
        // │  - Không chứa business logic                                   │
        // ├─────────────────────────────────────────────────────────────────┤
        // │  BUSINESS LOGIC LAYER (BLL Layer) - 6 BLL Classes              │
        // │  - ChucNangThemThongTinDaoTao: Validation + Auto-generate code │
        // │  - ChucNangXoaThongTinDaoTao: Delete logic                     │
        // │  - ChucNangSuaThongTinDaoTao: Update logic                     │
        // │  - ChucNangTimKiemThongTinDaoTao: Search algorithms            │
        // │  - ChucNangSapXepThongTinDaoTao: Sorting algorithms            │
        // │  - ChucNangThongKeThongTinDaoTao: Statistics logic             │
        // ├─────────────────────────────────────────────────────────────────┤
        // │  DATA TRANSFER OBJECT (DTO Layer)                              │
        // │  - ThongTinDaoTao: 11 properties (data model)                  │
        // │  - QuanLyDaoTao: List<ThongTinDaoTao> management               │
        // ├─────────────────────────────────────────────────────────────────┤
        // │  DATA ACCESS LAYER (DAL Layer) - Future                        │
        // │  - SQL Server database operations                              │
        // │  - ADO.NET, SqlConnection, SqlCommand                          │
        // └─────────────────────────────────────────────────────────────────┘
        //
        // 🎯 LỢI ÍCH CỦA N-LAYER:
        // 1. Separation of Concerns: Mỗi layer có trách nhiệm riêng
        // 2. Maintainability: Dễ bảo trì, sửa lỗi
        // 3. Testability: Test từng layer độc lập
        // 4. Reusability: BLL có thể dùng cho WinForms, WPF, Web API
        // 5. Scalability: Dễ dàng nâng cấp từ in-memory sang database
    }
}
