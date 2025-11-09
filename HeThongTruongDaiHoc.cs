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
    // ==================== MAIN FORM - HỆ THỐNG TRƯỜNG ĐẠI HỌC ====================
    // REFACTORED: Áp dụng kiến trúc N-Layer (3-Tier Architecture)
    public partial class HeThongTruongDaiHoc : Form
    {
        // =========================================================
        // I. LỚP LOGIC NGHIỆP VỤ (BLL) & LỚP DỮ LIỆU (DTO)
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
        // II. KHỞI TẠO FORM (CONSTRUCTOR)
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
            tabControlHeThong.Dock = DockStyle.Fill;
            buttonThemThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTimKiemSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonXoaThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSuaThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLamMoiThongTinSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridViewThongTinSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // BƯỚC 4: Cài đặt cột cho DataGridView
            dataGridViewThongTinSinhVien.Columns.Add("colMaSV", "Mã Sinh Viên");
            dataGridViewThongTinSinhVien.Columns.Add("colHoSV", "Họ");
            dataGridViewThongTinSinhVien.Columns.Add("colTenLotSV", "Tên Lót");
            dataGridViewThongTinSinhVien.Columns.Add("colTenSV", "Tên");
            dataGridViewThongTinSinhVien.Columns.Add("colNgaySinhSV", "Ngày Sinh");
            dataGridViewThongTinSinhVien.Columns.Add("colGioiTinhSV", "Giới Tính");
            dataGridViewThongTinSinhVien.Columns.Add("colCCCDSV", "Căn Cước Công Dân");
            dataGridViewThongTinSinhVien.Columns.Add("colDiaChiSV", "Địa Chỉ");
            dataGridViewThongTinSinhVien.Columns.Add("colEmailSV", "Email");
            dataGridViewThongTinSinhVien.Columns.Add("colLopSV", "Lớp");
            dataGridViewThongTinSinhVien.Columns.Add("colTrangThaiSV", "Trạng Thái");

            // Tự động co dãn các cột
            dataGridViewThongTinSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Tối ưu riêng cho cột Ngày Sinh
            dataGridViewThongTinSinhVien.Columns["colNgaySinhSV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewThongTinSinhVien.Columns["colNgaySinhSV"].DefaultCellStyle.Format = "d";
        }

        // =========================================================
        // III. SỰ KIỆN GIAO DIỆN (EVENT HANDLERS)
        // =========================================================

        // === SỰ KIỆN THÊM SINH VIÊN (REFACTORED) ===
        private void buttonThemThongTinSV_Click(object sender, EventArgs e)
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

        // === SỰ KIỆN SỬA SINH VIÊN (REFACTORED) ===
        private void buttonSuaThongTinSV_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
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

            // Lấy mã sinh viên từ dòng được chọn
            DataGridViewRow dongDuocChon = dataGridViewThongTinSinhVien.SelectedRows[0];
            string maSV = dongDuocChon.Cells["colMaSV"].Value.ToString();

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

        // === SỰ KIỆN XÓA SINH VIÊN (REFACTORED) ===
        private void buttonXoaThongTinSV_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
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

            // Lấy mã sinh viên từ dòng được chọn
            DataGridViewRow dongDuocChon = dataGridViewThongTinSinhVien.SelectedRows[0];
            string maSV = dongDuocChon.Cells["colMaSV"].Value.ToString();

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
                    // (Xóa code: dataGridViewThongTinSinhVien.Rows.Remove(dongDuocChon);)
                    HienThiDanhSach(quanLy.LayDanhSachSinhVien());

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

        // === SỰ KIỆN TÌM KIẾM (REFACTORED) ===
        private void buttonTimKiemSV_Click(object sender, EventArgs e)
        {
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

        // === SỰ KIỆN LÀM MỚI (YOUR ORIGINAL CODE) ===
        private void buttonLamMoiThongTinSV_Click(object sender, EventArgs e)
        {
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

        // =========================================================
        // IV. PHƯƠNG THỨC HỖ TRỢ (HELPER METHODS)
        // =========================================================

        // === PHƯƠNG THỨC HIỂN THỊ DANH SÁCH (ĐÃ GỘP) ===
        /*
         * REFACTORED: Đây là phương thức TỔNG
         * Xóa tất cả dòng hiện tại
         * Duyệt qua danh sách (List) và thêm từng sinh viên
         */
        private void HienThiDanhSach(List<ThongTinSinhVien> danhSach)
        {
            // Tắt vẽ để tăng tốc độ
            dataGridViewThongTinSinhVien.SuspendLayout();

            // Xóa tất cả dòng hiện tại
            dataGridViewThongTinSinhVien.Rows.Clear();

            // Duyệt qua danh sách và hiển thị từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Logic của hàm LoadDataGridView(sv) cũ được gộp vào đây
                dataGridViewThongTinSinhVien.Rows.Add(
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

            // Bật vẽ trở lại
            dataGridViewThongTinSinhVien.ResumeLayout();
        }

    } // Kết thúc Class HeThongTruongDaiHoc
} // Kết thúc Namespace