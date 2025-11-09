// ==================== TÓM TẮT REFACTORING ====================
/*
  CÁC THAY ĐỔI CHÍNH:
  
  1. THÊM USING:
     using WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer;
  
  2. KHAI BÁO BLL CLASSES:
     - chucNangThem, chucNangXoa, chucNangSua, chucNangTimKiem, ...
  
  3. SỬA CÁC PHƯƠNG THỨC:
     - buttonThemThongTinSV_Click: Dùng chucNangThem
     - buttonXoaThongTinSV_Click: Dùng chucNangXoa
     - buttonSuaThongTinSV_Click: Dùng chucNangSua + chucNangTimKiem
     - buttonTimKiemSV_Click: Dùng chucNangTimKiem
  
  PATTERN SỬ DỤNG:
     bllObject.Method(quanLy.LayDanhSachSinhVien(), parameters...)
  
   - quanLy.LayDanhSachSinhVien(): Lấy data từ DTO
   - bllObject.Method(...): BLL xử lý logic
   - List là reference type → Thay đổi trực tiếp trên list gốc
  
  LỢI ÍCH:
  ✅ Tuân thủ kiến trúc N-Layer
  ✅ Dễ bảo trì và mở rộng
  ✅ Tái sử dụng BLL cho các UI khác
  ✅ Dễ test từng layer riêng
*/
// ==================== END TÓM TẮT ====================

using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien;
using WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer; // THÊM MỚI: Import BLL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He_Thong_Truong_Dai_Hoc
{
    // ==================== MAIN FORM - HỆ THỐNG TRƯỜNG ĐẠI HỌC (OPTIMIZED) ====================
    // REFACTORED: Áp dụng kiến trúc N-Layer (3-Tier Architecture)
    // CẢI TIẾN:
    // 1. Thêm constants cho column names
    // 2. Thêm error handling
    // 3. Implement button state management
    // 4. Cải thiện UX
    public partial class HeThongTruongDaiHoc : Form
    {
        // =========================================================
        // I. CONSTANTS - COLUMN NAMES
        // =========================================================
        // Định nghĩa tên cột như constants để tránh hardcode và dễ bảo trì
        private const string COL_HINH_ANH = "colHinhAnh";
        private const string COL_MA_SV = "colMaSV";
        private const string COL_HO_SV = "colHoSV";
        private const string COL_TEN_LOT_SV = "colTenLotSV";
        private const string COL_TEN_SV = "colTenSV";
        private const string COL_NGAY_SINH_SV = "colNgaySinhSV";
        private const string COL_GIOI_TINH_SV = "colGioiTinhSV";
        private const string COL_CCCD_SV = "colCCCDSV";
        private const string COL_DIA_CHI_SV = "colDiaChiSV";
        private const string COL_EMAIL_SV = "colEmailSV";
        private const string COL_LOP_SV = "colLopSV";
        private const string COL_TRANG_THAI_SV = "colTrangThaiSV";

        // =========================================================
        // II. LỚP LOGIC NGHIỆP VỤ (BLL) & LỚP DỮ LIỆU (DTO)
        // =========================================================

        // DTO (Data Transfer Object) - Lớp chứa dữ liệu
        private QuanLySinhVien quanLy;

        // BLL (Business Logic Layer) - Các lớp xử lý nghiệp vụ
        private ChucNangThemThongTinSV chucNangThem;
        private ChucNangXoaThongTinSinhVien chucNangXoa;
        private ChucNangSuaThongTinSinhVien chucNangSua;
        private ChucNangTimKiemThongTinSinhVien chucNangTimKiem;
        private ChucNangSapXepSV chucNangSapXep;
        private ChucNangThongKeSV chucNangThongKe;

        // =========================================================
        // III. KHỞI TẠO FORM (CONSTRUCTOR)
        // =========================================================
        public HeThongTruongDaiHoc()
        {
            InitializeComponent();

            // BƯỚC 1: Khởi tạo DTO (Data Transfer Object)
            quanLy = new QuanLySinhVien();

            // BƯỚC 2: Khởi tạo BLL (Business Logic Layer)
            chucNangThem = new ChucNangThemThongTinSV();
            chucNangXoa = new ChucNangXoaThongTinSinhVien();
            chucNangSua = new ChucNangSuaThongTinSinhVien();
            chucNangTimKiem = new ChucNangTimKiemThongTinSinhVien();
            chucNangSapXep = new ChucNangSapXepSV();
            chucNangThongKe = new ChucNangThongKeSV();

            // BƯỚC 3: Thiết lập giao diện (UI)
            ThietLapGiaoDien();

            // BƯỚC 4: Cài đặt cột cho DataGridView
            ThietLapDataGridView();

            // BƯỚC 5: Cập nhật trạng thái buttons
            CapNhatTrangThaiButtons();

            // BƯỚC 6: Đăng ký event handler cho DataGridView
            dataGridViewThongTinSinhVien.SelectionChanged += DataGridViewThongTinSinhVien_SelectionChanged;
        }

        // ===== THIẾT LẬP GIAO DIỆN =====
        private void ThietLapGiaoDien()
        {
            tabControlHeThong.Dock = DockStyle.Fill;
            buttonThemThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTimKiemSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonXoaThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSuaThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLamMoiThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonThongKeSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridViewThongTinSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        // ===== THIẾT LẬP DATAGRIDVIEW =====
        private void ThietLapDataGridView()
        {
            // BƯỚC 1: Thêm cột hình ảnh (DataGridViewImageColumn)
            DataGridViewImageColumn colImage = new DataGridViewImageColumn();
            colImage.Name = COL_HINH_ANH;
            colImage.HeaderText = "Ảnh";
            colImage.ImageLayout = DataGridViewImageCellLayout.Zoom; // Zoom để ảnh vừa khít
            colImage.Width = 60; // Chiều rộng cố định
            colImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewThongTinSinhVien.Columns.Add(colImage);

            // BƯỚC 2: Thêm các cột text (sử dụng constants)
            dataGridViewThongTinSinhVien.Columns.Add(COL_MA_SV, "Mã Sinh Viên");
            dataGridViewThongTinSinhVien.Columns.Add(COL_HO_SV, "Họ");
            dataGridViewThongTinSinhVien.Columns.Add(COL_TEN_LOT_SV, "Tên Lót");
            dataGridViewThongTinSinhVien.Columns.Add(COL_TEN_SV, "Tên");
            dataGridViewThongTinSinhVien.Columns.Add(COL_NGAY_SINH_SV, "Ngày Sinh");
            dataGridViewThongTinSinhVien.Columns.Add(COL_GIOI_TINH_SV, "Giới Tính");
            dataGridViewThongTinSinhVien.Columns.Add(COL_CCCD_SV, "Căn Cước Công Dân");
            dataGridViewThongTinSinhVien.Columns.Add(COL_DIA_CHI_SV, "Địa Chỉ");
            dataGridViewThongTinSinhVien.Columns.Add(COL_EMAIL_SV, "Email");
            dataGridViewThongTinSinhVien.Columns.Add(COL_LOP_SV, "Lớp");
            dataGridViewThongTinSinhVien.Columns.Add(COL_TRANG_THAI_SV, "Trạng Thái");

            // BƯỚC 3: Tự động co dãn các cột (mặc định Fill)
            dataGridViewThongTinSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // BƯỚC 4: Tối ưu riêng cho từng cột
            // Cột Mã SV: AllCells để vừa với nội dung
            dataGridViewThongTinSinhVien.Columns[COL_MA_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_MA_SV].MinimumWidth = 100;

            // Cột Họ, Tên Lót, Tên: AllCells
            dataGridViewThongTinSinhVien.Columns[COL_HO_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_HO_SV].MinimumWidth = 80;
            dataGridViewThongTinSinhVien.Columns[COL_TEN_LOT_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_TEN_LOT_SV].MinimumWidth = 80;
            dataGridViewThongTinSinhVien.Columns[COL_TEN_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_TEN_SV].MinimumWidth = 80;

            // Cột Ngày Sinh: AllCells + Format ngắn
            dataGridViewThongTinSinhVien.Columns[COL_NGAY_SINH_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_NGAY_SINH_SV].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewThongTinSinhVien.Columns[COL_NGAY_SINH_SV].MinimumWidth = 100;

            // Cột Giới Tính: AllCells
            dataGridViewThongTinSinhVien.Columns[COL_GIOI_TINH_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_GIOI_TINH_SV].MinimumWidth = 80;

            // Cột CCCD: AllCells
            dataGridViewThongTinSinhVien.Columns[COL_CCCD_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_CCCD_SV].MinimumWidth = 120;

            // Cột Địa Chỉ: Fill (để chiếm hết không gian còn lại)
            dataGridViewThongTinSinhVien.Columns[COL_DIA_CHI_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewThongTinSinhVien.Columns[COL_DIA_CHI_SV].MinimumWidth = 150;

            // Cột Email: Fill
            dataGridViewThongTinSinhVien.Columns[COL_EMAIL_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewThongTinSinhVien.Columns[COL_EMAIL_SV].MinimumWidth = 150;

            // Cột Lớp: AllCells
            dataGridViewThongTinSinhVien.Columns[COL_LOP_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_LOP_SV].MinimumWidth = 80;

            // Cột Trạng Thái: AllCells
            dataGridViewThongTinSinhVien.Columns[COL_TRANG_THAI_SV].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns[COL_TRANG_THAI_SV].MinimumWidth = 100;

            // BƯỚC 5: Cấu hình hành vi
            dataGridViewThongTinSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThongTinSinhVien.MultiSelect = false;
            dataGridViewThongTinSinhVien.ReadOnly = true;
            dataGridViewThongTinSinhVien.AllowUserToAddRows = false;
        }

        // ===== CẬP NHẬT TRẠNG THÁI BUTTONS =====
        /*
         * OPTIMIZED: Tất cả buttons luôn enabled
         * Thay vì disable, sẽ hiện thông báo khi click vào button mà chưa có dữ liệu
         * Cải thiện UX: User biết rõ lý do tại sao không thể thực hiện thao tác
         */
        private void CapNhatTrangThaiButtons()
        {
            // TẤT CẢ BUTTONS LUÔN ENABLED
            // Khi click sẽ có thông báo hướng dẫn nếu chưa đủ điều kiện
            buttonThemThongTinSV.Enabled = true;
            buttonTimKiemSV.Enabled = true;
            buttonSuaThongTinSV.Enabled = true;
            buttonXoaThongTinSV.Enabled = true;
            buttonLamMoiThongTinSV.Enabled = true;
            buttonThongKeSV.Enabled = true;
        }

        // ===== EVENT: SELECTION CHANGED =====
        private void DataGridViewThongTinSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            // Cập nhật trạng thái buttons mỗi khi selection thay đổi
            CapNhatTrangThaiButtons();
        }

        // =========================================================
        // IV. SỰ KIỆN GIAO DIỆN (EVENT HANDLERS) - WITH ERROR HANDLING
        // =========================================================

        // === SỰ KIỆN THÊM SINH VIÊN (OPTIMIZED) ===
        private void buttonThemThongTinSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormThongTinSV MenuThemThongTinSV = new FormThongTinSV(null))
                {
                    DialogResult ketQuaMenuThem = MenuThemThongTinSV.ShowDialog();

                    if (ketQuaMenuThem == DialogResult.OK)
                    {
                        ThongTinSinhVien svMoi = MenuThemThongTinSV.SinhVienMoi;

                        if (svMoi != null)
                        {
                            // REFACTORED: Gọi BLL
                            bool ketQua = chucNangThem.ThemSinhVien(
                                quanLy.LayDanhSachSinhVien(), // Lấy danh sách từ DTO
                                svMoi  // Sinh viên mới
                            );

                            if (ketQua)
                            {
                                // THAY ĐỔI: Gọi hàm HienThiDanhSach để đồng bộ
                                HienThiDanhSach(quanLy.LayDanhSachSinhVien());

                                // Cập nhật trạng thái buttons
                                CapNhatTrangThaiButtons();

                                MessageBox.Show(
                                    "Thêm sinh viên thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            else
                            {
                                // Thêm thất bại (mã sinh viên trùng hoặc dữ liệu không hợp lệ)
                                MessageBox.Show(
                                    "Thêm sinh viên thất bại!\n" +
                                    "Nguyên nhân có thể:\n" +
                                    "- Mã sinh viên đã tồn tại\n" +
                                    "- Dữ liệu không hợp lệ",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi thêm sinh viên!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // === SỰ KIỆN SỬA SINH VIÊN (OPTIMIZED) ===
        private void buttonSuaThongTinSV_Click(object sender, EventArgs e)
        {
            try
            {
                // BƯỚC 1: Kiểm tra có dữ liệu không
                if (quanLy.LaySoLuongSinhVien() == 0)
                {
                    MessageBox.Show(
                        "⚠️ Chưa có dữ liệu sinh viên!\n\n" +
                        "Vui lòng thêm thông tin sinh viên trước khi sử dụng chức năng sửa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // BƯỚC 2: Kiểm tra có dòng nào được chọn không
                if (dataGridViewThongTinSinhVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Vui lòng chọn sinh viên cần sửa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Lấy mã sinh viên từ dòng được chọn - SỬ DỤNG CONSTANT
                DataGridViewRow dongDuocChon = dataGridViewThongTinSinhVien.SelectedRows[0];
                string maSV = dongDuocChon.Cells[COL_MA_SV].Value?.ToString() ?? "";

                // REFACTORED: Dùng BLL để tìm sinh viên
                ThongTinSinhVien svCanSua = chucNangTimKiem.TimTheoMaSV(
                    quanLy.LayDanhSachSinhVien(), // Danh sách từ DTO
                    maSV  // Mã sinh viên cần tìm
                );

                if (svCanSua == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy sinh viên trong hệ thống!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                // Mở Form Sửa và "truyền" sinh viên cần sửa vào
                using (FormThongTinSV formSua = new FormThongTinSV(svCanSua))
                {
                    DialogResult ketQua = formSua.ShowDialog();

                    if (ketQua == DialogResult.OK)
                    {
                        ThongTinSinhVien thongTinMoi = formSua.SinhVienMoi;

                        if (thongTinMoi != null)
                        {
                            // REFACTORED: Dùng BLL để sửa thông tin
                            bool capNhatThanhCong = chucNangSua.SuaThongTinSinhVien(
                                quanLy.LayDanhSachSinhVien(), // Danh sách từ DTO
                                maSV,   // Mã sinh viên cần sửa
                                thongTinMoi // Thông tin mới
                            );

                            if (capNhatThanhCong)
                            {
                                // Làm mới DataGridView
                                HienThiDanhSach(quanLy.LayDanhSachSinhVien());

                                MessageBox.Show(
                                    "Sửa thông tin sinh viên thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Sửa thông tin thất bại!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi sửa thông tin sinh viên!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // === SỰ KIỆN XÓA SINH VIÊN (OPTIMIZED) ===
        private void buttonXoaThongTinSV_Click(object sender, EventArgs e)
        {
            try
            {
                // BƯỚC 1: Kiểm tra có dữ liệu không
                if (quanLy.LaySoLuongSinhVien() == 0)
                {
                    MessageBox.Show(
                        "⚠️ Chưa có dữ liệu sinh viên!\n\n" +
                        "Vui lòng thêm thông tin sinh viên trước khi sử dụng chức năng xóa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // BƯỚC 2: Kiểm tra có dòng nào được chọn không
                if (dataGridViewThongTinSinhVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Vui lòng chọn sinh viên cần xóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Lấy mã sinh viên từ dòng được chọn - SỬ DỤNG CONSTANT
                DataGridViewRow dongDuocChon = dataGridViewThongTinSinhVien.SelectedRows[0];
                string maSV = dongDuocChon.Cells[COL_MA_SV].Value?.ToString() ?? "";

                // Xác nhận trước khi xóa
                DialogResult xacNhan = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sinh viên có mã: {maSV}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (xacNhan == DialogResult.Yes)
                {
                    // REFACTORED: Gọi BLL thay vì DTO
                    bool ketQua = chucNangXoa.XoaSinhVien(
                        quanLy.LayDanhSachSinhVien(), // Danh sách từ DTO
                        maSV  // Mã sinh viên cần xóa
                    );

                    if (ketQua)
                    {
                        // THAY ĐỔI: Gọi hàm HienThiDanhSach để đồng bộ
                        HienThiDanhSach(quanLy.LayDanhSachSinhVien());

                        // Cập nhật trạng thái buttons
                        CapNhatTrangThaiButtons();

                        MessageBox.Show(
                            "Xóa sinh viên thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Xóa sinh viên thất bại!",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi xóa sinh viên!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // === SỰ KIỆN TÌM KIẾM (OPTIMIZED) ===
        private void buttonTimKiemSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (quanLy.LaySoLuongSinhVien() == 0)
                {
                    MessageBox.Show(
                        "⚠️ Chưa có dữ liệu sinh viên!\n\n" +
                        "Vui lòng thêm thông tin sinh viên trước khi sử dụng chức năng tìm kiếm.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                using (FormTimKiemThongTinSV MenuTimKiemThongTinSV = new FormTimKiemThongTinSV())
                {
                    DialogResult ketQuaMenuTimKiem = MenuTimKiemThongTinSV.ShowDialog();

                    if (ketQuaMenuTimKiem == DialogResult.OK)
                    {
                        ThongTinSinhVien svTieuChi = MenuTimKiemThongTinSV.TieuChiTimKiem;

                        if (svTieuChi == null)
                        {
                            MessageBox.Show(
                                "Vui lòng nhập ít nhất một tiêu chí tìm kiếm!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        dataGridViewThongTinSinhVien.SuspendLayout();
                        try
                        {
                            // REFACTORED: Gọi BLL thay vì DTO
                            List<ThongTinSinhVien> ketQuaTimKiem = chucNangTimKiem.TimKiemSinhVien(
                                quanLy.LayDanhSachSinhVien(), // Danh sách từ DTO
                                svTieuChi  // Tiêu chí tìm kiếm
                            );

                            // Kiểm tra kết quả
                            if (ketQuaTimKiem.Count == 0)
                            {
                                MessageBox.Show(
                                    "Không tìm thấy sinh viên nào phù hợp với tiêu chí tìm kiếm!",
                                    "Kết quả tìm kiếm",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            else
                            {
                                // Hiển thị kết quả (đã lọc) lên DataGridView
                                HienThiDanhSach(ketQuaTimKiem);

                                MessageBox.Show(
                                    $"Tìm thấy {ketQuaTimKiem.Count} sinh viên!",
                                    "Kết quả tìm kiếm",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                        }
                        finally
                        {
                            dataGridViewThongTinSinhVien.ResumeLayout();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi tìm kiếm sinh viên!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // === SỰ KIỆN LÀM MỚI (OPTIMIZED) ===
        private void buttonLamMoiThongTinSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (quanLy.LaySoLuongSinhVien() == 0)
                {
                    MessageBox.Show(
                        "⚠️ Chưa có dữ liệu sinh viên!\n\n" +
                        "Vui lòng thêm thông tin sinh viên trước khi sử dụng chức năng làm mới.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Hiển thị lại toàn bộ danh sách
                List<ThongTinSinhVien> danhSachDayDu = quanLy.LayDanhSachSinhVien();
                HienThiDanhSach(danhSachDayDu);

                MessageBox.Show(
                    "Đã làm mới danh sách sinh viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi làm mới danh sách!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // === SỰ KIỆN THỐNG KÊ (NEW) ===
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Chức năng: Hiển thị form thống kê sinh viên
         * - Thống kê tổng quan (Tổng số, Nam, Nữ)
         * - Thống kê theo lớp
         * - Thống kê theo trạng thái (Đang học, Tốt nghiệp, ...)
         *
         * Sử dụng FormThongKeSV:
         * - Truyền danh sách sinh viên từ DTO vào form
         * - Form sử dụng ChucNangThongKeSV từ BLL để tính toán
         */
        private void buttonThongKeSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dữ liệu không
                if (quanLy.LaySoLuongSinhVien() == 0)
                {
                    MessageBox.Show(
                        "Chưa có dữ liệu sinh viên để thống kê!\nVui lòng thêm sinh viên trước.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Mở Form Thống Kê và truyền danh sách sinh viên
                using (FormThongKeSV formThongKe = new FormThongKeSV(quanLy.LayDanhSachSinhVien()))
                {
                    formThongKe.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // ERROR HANDLING: Bắt tất cả exceptions
                MessageBox.Show(
                    $"Đã xảy ra lỗi khi mở form thống kê!\n\nChi tiết lỗi:\n{ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // V. PHƯƠNG THỨC HỖ TRỢ (HELPER METHODS)
        // =========================================================

        // === PHƯƠNG THỨC HIỂN THỊ DANH SÁCH (OPTIMIZED) ===
        /*
         * REFACTORED: Đây là phương thức TỔNG
         * Xóa tất cả dòng hiện tại
         * Duyệt qua danh sách (List) và thêm từng sinh viên
         * SỬ DỤNG CONSTANTS cho column order
         * THÊM: Hỗ trợ hiển thị hình ảnh
         */
        private void HienThiDanhSach(List<ThongTinSinhVien> danhSach)
        {
            // Tắt vẽ để tăng tốc độ
            dataGridViewThongTinSinhVien.SuspendLayout();

            try
            {
                // Xóa tất cả dòng hiện tại
                dataGridViewThongTinSinhVien.Rows.Clear();

                // Duyệt qua danh sách và hiển thị từng sinh viên
                foreach (ThongTinSinhVien sv in danhSach)
                {
                    // Load hình ảnh từ file path
                    Image hinhAnh = LoadHinhAnh(sv.HinhAnhSV);

                    // Thêm dòng mới vào DataGridView
                    // Thứ tự cột phải khớp với thứ tự trong ThietLapDataGridView()
                    dataGridViewThongTinSinhVien.Rows.Add(
                        hinhAnh,        // Cột hình ảnh (ĐẦU TIÊN)
                        sv.MaSV,
                        sv.HoSV,
                        sv.TenLotSV,
                        sv.TenSV,
                        sv.NgaySinhSV,
                        sv.GioiTinhSV,
                        sv.CCCDSV,
                        sv.DiaChiSV,
                        sv.EmailSV,
                        sv.LopSV,
                        sv.TrangThaiSV
                    );
                }
            }
            finally
            {
                // Bật vẽ trở lại (luôn chạy dù có exception hay không)
                dataGridViewThongTinSinhVien.ResumeLayout();
            }
        }

        // === PHƯƠNG THỨC LOAD HÌNH ẢNH ===
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Chức năng: Load hình ảnh từ file path
         * - Nếu có path và file tồn tại → Load ảnh
         * - Nếu không có path hoặc file không tồn tại → Trả về ảnh mặc định
         *
         * Tại sao cần method này?
         * - Tránh lỗi FileNotFoundException khi file không tồn tại
         * - Hiển thị ảnh mặc định thay vì ô trống
         * - Code gọn gàng, dễ bảo trì
         */
        private Image LoadHinhAnh(string duongDan)
        {
            // BƯỚC 1: Kiểm tra đường dẫn có rỗng không
            if (string.IsNullOrWhiteSpace(duongDan))
            {
                return TaoAnhMacDinh();
            }

            // BƯỚC 2: Kiểm tra file có tồn tại không
            if (!System.IO.File.Exists(duongDan))
            {
                return TaoAnhMacDinh();
            }

            // BƯỚC 3: Load ảnh từ file
            try
            {
                // Tạo một copy của ảnh để tránh lock file
                using (Image anhGoc = Image.FromFile(duongDan))
                {
                    return new Bitmap(anhGoc);
                }
            }
            catch
            {
                // Nếu có lỗi khi load (file hỏng, format không hỗ trợ...)
                return TaoAnhMacDinh();
            }
        }

        // === PHƯƠNG THỨC TẠO ẢNH MẶC ĐỊNH ===
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Chức năng: Tạo ảnh mặc định khi không có ảnh
         * - Tạo một hình vuông màu xám nhạt
         * - Vẽ text "No Image" ở giữa
         *
         * Sử dụng:
         * - System.Drawing.Bitmap: Tạo ảnh mới
         * - System.Drawing.Graphics: Vẽ lên ảnh
         * - Không cần file, tạo trực tiếp trong code
         */
        private Image TaoAnhMacDinh()
        {
            // Tạo bitmap 60x60 (khớp với width của cột)
            Bitmap bmp = new Bitmap(60, 60);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Vẽ background màu xám nhạt
                g.FillRectangle(Brushes.LightGray, 0, 0, 60, 60);

                // Vẽ text "No Image" ở giữa (tùy chọn)
                // Font nhỏ để vừa với 60x60
                Font font = new Font("Segoe UI", 7);
                g.DrawString("No\nImage", font, Brushes.Gray, new PointF(12, 20));
            }

            return bmp;
        }

        /*
         * ==================== TÓM TẮT CẢI TIẾN MAIN FORM ====================
         *
         * 1. CONSTANTS:
         *    - Định nghĩa column names như constants
         *    - Tránh hardcode, dễ bảo trì
         *    - Tránh lỗi typo khi reference columns
         *
         * 2. ERROR HANDLING:
         *    - Bọc tất cả event handlers trong try-catch
         *    - Hiển thị thông báo lỗi chi tiết cho developer
         *    - Ngăn chặn crash application
         *
         * 3. BUTTON STATE MANAGEMENT:
         *    - Enable/Disable buttons dựa trên trạng thái
         *    - Xóa/Sửa chỉ enable khi có selection
         *    - Tìm kiếm/Làm mới chỉ enable khi có dữ liệu
         *    - Cải thiện UX
         *
         * 4. CODE ORGANIZATION:
         *    - Tách setup logic thành methods riêng:
         *      + ThietLapGiaoDien()
         *      + ThietLapDataGridView()
         *      + CapNhatTrangThaiButtons()
         *    - Dễ đọc, dễ maintain
         *
         * 5. NULL SAFETY:
         *    - Sử dụng null-coalescing operator (??)
         *    - Tránh NullReferenceException
         *
         * 6. DATAGRIDVIEW CONFIGURATION:
         *    - SelectionMode = FullRowSelect
         *    - MultiSelect = false
         *    - ReadOnly = true
         *    - AllowUserToAddRows = false
         *    - Cải thiện UX và tránh lỗi
         *
         * ==================== END TÓM TẮT ====================
         */

    } // Kết thúc Class HeThongTruongDaiHoc
} // Kết thúc Namespace