using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG THÊM THÔNG TIN XÉT THI ĐUA (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures
    //      • 4.2: Selection Structures (if/else) - Kiểm tra điều kiện
    //      • 4.3: Loop Structures (for, foreach) - Duyệt danh sách
    //    - Chapter 5: Functions
    //      • 5.2: Function Definition - Định nghĩa hàm
    //      • 5.4: Value-Returning Functions - Hàm trả về giá trị
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 4: Character Strings
    //      • 4.4: String Operations - Xử lý chuỗi
    //      • 4.4.1: Accessing individual elements - Truy cập từng ký tự
    //
    // 3️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class
    //      • 2.1.4: Methods - Phương thức
    //
    // 4️⃣ DATA STRUCTURES AND ALGORITHMS:
    //    - Chapter 1: Lists - Danh sách
    //      • 1.1.3: Basic operations - Insert (Thêm phần tử)
    //    - Chapter 2: Sorting - Searching
    //      • 2.2.1: Sequential Search - Tìm kiếm tuần tự
    //
    // 5️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.2: Business Logic Layer (BLL) - Lớp nghiệp vụ
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ChucNangThemThongTinXetThiDua chứa TẤT CẢ logic để THÊM thông tin xét thi đua:
    // - VALIDATION: Kiểm tra dữ liệu hợp lệ
    // - DUPLICATE CHECK: Kiểm tra không bị trùng
    // - EVALUATION: Tính điểm và xếp loại
    // - CLASSIFICATION: Gán danh hiệu thi đua
    // - INSERT: Thêm vào List
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như QUY TRÌNH ĐÁNH GIÁ THI ĐUA ở phòng Đào tạo:
    // Bước 1: Kiểm tra thông tin đầu vào (Validation)
    // Bước 2: Tra cứu không bị trùng (Duplicate check)
    // Bước 3: Tính tổng điểm (Calculation)
    // Bước 4: Xếp loại thi đua (Classification)
    // Bước 5: Gán danh hiệu (Award)
    // Bước 6: Lưu vào hệ thống (Insert to List)
    //
    // 🔍 QUY TRÌNH THÊM XÉT THI ĐUA (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU HỢP LỆ (Validation)
    //    • Mã đối tượng không rỗng
    //    • Loại đối tượng (Sinh viên / Giảng viên)
    //    • Họ tên không rỗng
    //    • Học kỳ không rỗng
    //    • Điểm hợp lệ (0-100)
    //
    // Bước 2: KIỂM TRA TRÙNG THÔNG TIN
    //    • Sequential Search: O(n)
    //    • Duyệt qua danh sách
    //    • So sánh MaDoiTuong + HocKy
    //    • Nếu trùng → return false
    //
    // Bước 3: TÍNH ĐIỂM VÀ XẾP LOẠI (DanhGiaThiDua)
    //    • Tính TongDiem dựa trên loại đối tượng
    //    • Xếp loại theo khoảng điểm
    //    • Gán danh hiệu tương ứng
    //
    // Bước 4: THÊM VÀO DANH SÁCH
    //    • danhSach.Add(xetThiDuaMoi)
    //    • Độ phức tạp: O(1) amortized
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Kiểm tra trùng: O(n) - Sequential Search
    // - Tính điểm và xếp loại: O(1)
    // - Add to List: O(1)
    // → Tổng: O(n)
    //
    public class ChucNangThemThongTinXetThiDua
    {
        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================

        /// <summary>
        /// Kiểm tra chuỗi có rỗng không
        /// </summary>
        private bool KiemTraChuoiRong(string chuoi)
        {
            if (chuoi == null)
            {
                return true;
            }

            if (chuoi.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Xóa khoảng trắng thừa ở đầu và cuối
        /// </summary>
        private string XoaKhoangTrangThua(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            if (chuoi.Length == 0)
            {
                return "";
            }

            // Tìm vị trí đầu
            int viTriDau = 0;
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriDau = i;
                    break;
                }
            }

            // Tìm vị trí cuối
            int viTriCuoi = chuoi.Length - 1;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriCuoi = i;
                    break;
                }
            }

            if (viTriDau > viTriCuoi)
            {
                return "";
            }

            int doDai = viTriCuoi - viTriDau + 1;
            return chuoi.Substring(viTriDau, doDai);
        }

        /// <summary>
        /// So sánh 2 chuỗi không phân biệt hoa/thường
        /// </summary>
        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        /// <summary>
        /// So sánh 2 chuỗi chính xác
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

            if (chuoi1.Length != chuoi2.Length)
            {
                return false;
            }

            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi về chữ thường
        /// </summary>
        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
                    char kyTuThuong = (char)(kyTu + 32);
                    ketQua += kyTuThuong;
                }
                else
                {
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Chuyển chuỗi về chữ hoa
        /// </summary>
        private string ChuyenVeChuHoa(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                bool laThuong = (kyTu >= 'a') && (kyTu <= 'z');

                if (laThuong)
                {
                    char kyTuHoa = (char)(kyTu - 32);
                    ketQua += kyTuHoa;
                }
                else
                {
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC CHÍNH ====================

        /// <summary>
        /// Thêm thông tin xét thi đua mới vào danh sách
        /// </summary>
        public bool ThemXetThiDua(List<ThongTinXetThiDua> danhSach, ThongTinXetThiDua xetThiDuaMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return false;
            }

            // Kiểm tra object null
            if (xetThiDuaMoi == null)
            {
                return false;
            }

            // ===== BƯỚC 2: KIỂM TRA DỮ LIỆU HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(xetThiDuaMoi);

            if (!duLieuHopLe)
            {
                return false;
            }

            // ===== BƯỚC 3: KIỂM TRA TRÙNG THÔNG TIN =====

            bool daTonTai = KiemTraTonTai(danhSach, xetThiDuaMoi.MaDoiTuong, xetThiDuaMoi.HocKy);

            if (daTonTai)
            {
                return false;
            }

            // ===== BƯỚC 4: TÍNH ĐIỂM VÀ XẾP LOẠI =====

            DanhGiaThiDua(xetThiDuaMoi);

            // ===== BƯỚC 5: CHUẨN HÓA DỮ LIỆU =====

            ChuanHoaDuLieu(xetThiDuaMoi);

            // ===== BƯỚC 6: THÊM VÀO DANH SÁCH =====

            danhSach.Add(xetThiDuaMoi);

            // ===== BƯỚC 7: TRẢ VỀ KẾT QUẢ =====
            return true;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA DỮ LIỆU HỢP LỆ ====================

        /// <summary>
        /// Kiểm tra dữ liệu xét thi đua hợp lệ
        /// </summary>
        private bool KiemTraDuLieuHopLe(ThongTinXetThiDua xetThiDua)
        {
            // ===== KIỂM TRA 1: MÃ ĐỐI TƯỢNG (BẮT BUỘC) =====
            bool maRong = KiemTraChuoiRong(xetThiDua.MaDoiTuong);

            if (maRong)
            {
                return false;
            }

            // ===== KIỂM TRA 2: LOẠI ĐỐI TƯỢNG (BẮT BUỘC) =====
            bool loaiRong = KiemTraChuoiRong(xetThiDua.LoaiDoiTuong);

            if (loaiRong)
            {
                return false;
            }

            // Loại đối tượng phải là "Sinh viên" hoặc "Giảng viên"
            string loai = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);
            bool loaiHopLe = (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên") ||
                              SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"));

            if (!loaiHopLe)
            {
                return false;
            }

            // ===== KIỂM TRA 3: HỌ TÊN (BẮT BUỘC) =====
            bool tenRong = KiemTraChuoiRong(xetThiDua.HoTen);

            if (tenRong)
            {
                return false;
            }

            // ===== KIỂM TRA 4: HỌC KỲ (BẮT BUỘC) =====
            bool hocKyRong = KiemTraChuoiRong(xetThiDua.HocKy);

            if (hocKyRong)
            {
                return false;
            }

            // ===== KIỂM TRA 5: ĐIỂM SINH VIÊN =====
            if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên"))
            {
                // Kiểm tra các điểm trong khoảng 0-20, 0-30, 0-20, 0-20
                if (xetThiDua.DiemYThucHocTap < 0 || xetThiDua.DiemYThucHocTap > 20)
                    return false;

                if (xetThiDua.DiemThamGiaHoatDong < 0 || xetThiDua.DiemThamGiaHoatDong > 30)
                    return false;

                if (xetThiDua.DiemYThucCongDan < 0 || xetThiDua.DiemYThucCongDan > 20)
                    return false;

                if (xetThiDua.DiemQuanHeCongDong < 0 || xetThiDua.DiemQuanHeCongDong > 20)
                    return false;

                if (xetThiDua.SoLanViPham < 0)
                    return false;
            }

            // ===== KIỂM TRA 6: ĐIỂM GIẢNG VIÊN =====
            else if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"))
            {
                // Kiểm tra các điểm trong khoảng 0-30, 0-30, 0-20, 0-20
                if (xetThiDua.DiemNangLucChuyenMon < 0 || xetThiDua.DiemNangLucChuyenMon > 30)
                    return false;

                if (xetThiDua.DiemPhuongPhapGiangDay < 0 || xetThiDua.DiemPhuongPhapGiangDay > 30)
                    return false;

                if (xetThiDua.DiemThaiDoVoiSinhVien < 0 || xetThiDua.DiemThaiDoVoiSinhVien > 20)
                    return false;

                if (xetThiDua.DiemNghienCuuKhoaHoc < 0 || xetThiDua.DiemNghienCuuKhoaHoc > 20)
                    return false;
            }

            return true;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA TRÙNG ====================

        /// <summary>
        /// Kiểm tra xét thi đua có tồn tại chưa (cùng MaDoiTuong và HocKy)
        /// </summary>
        private bool KiemTraTonTai(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            // Kiểm tra các tham số
            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong) return false;

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong) return false;

            // Tìm kiếm tuần tự
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                // So sánh mã đối tượng
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                // So sánh học kỳ
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                // Nếu cả hai trùng thì return true
                if (khopMa && khopKy)
                {
                    return true;
                }
            }

            return false;
        }

        // ==================== PHƯƠNG THỨC TÍNH ĐIỂM VÀ XẾP LOẠI ====================

        /// <summary>
        /// PHƯƠNG THỨC CHÍNH: Đánh giá thi đua - Tính điểm, xếp loại, gán danh hiệu
        ///
        /// Logic:
        /// - Sinh viên: TongDiem = DiemYThucHocTap + DiemThamGiaHoatDong + DiemYThucCongDan + DiemQuanHeCongDong - (SoLanViPham * 10)
        /// - Giảng viên: TongDiem = DiemNangLucChuyenMon + DiemPhuongPhapGiangDay + DiemThaiDoVoiSinhVien + DiemNghienCuuKhoaHoc
        ///
        /// Xếp loại:
        /// - >= 90: Xuất sắc
        /// - >= 80: Tốt
        /// - >= 65: Khá
        /// - >= 50: Trung bình
        /// - < 50: Yếu
        /// </summary>
        public void DanhGiaThiDua(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null)
            {
                return;
            }

            // ===== BƯỚC 1: TÍNH TỔNG ĐIỂM DỰA TRÊN LOẠI ĐỐI TƯỢNG =====

            string loai = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);

            if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên"))
            {
                // ===== TÍNH ĐIỂM SINH VIÊN =====
                // TongDiem = DiemYThucHocTap + DiemThamGiaHoatDong + DiemYThucCongDan + DiemQuanHeCongDong - (SoLanViPham * 10)

                int diemSinhVien = xetThiDua.DiemYThucHocTap +
                                   xetThiDua.DiemThamGiaHoatDong +
                                   xetThiDua.DiemYThucCongDan +
                                   xetThiDua.DiemQuanHeCongDong -
                                   (xetThiDua.SoLanViPham * 10);

                // Đảm bảo điểm không âm và không vượt quá 100
                if (diemSinhVien < 0)
                {
                    diemSinhVien = 0;
                }

                if (diemSinhVien > 100)
                {
                    diemSinhVien = 100;
                }

                xetThiDua.TongDiem = diemSinhVien;
            }
            else if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"))
            {
                // ===== TÍNH ĐIỂM GIẢNG VIÊN =====
                // TongDiem = DiemNangLucChuyenMon + DiemPhuongPhapGiangDay + DiemThaiDoVoiSinhVien + DiemNghienCuuKhoaHoc

                int diemGiangVien = xetThiDua.DiemNangLucChuyenMon +
                                    xetThiDua.DiemPhuongPhapGiangDay +
                                    xetThiDua.DiemThaiDoVoiSinhVien +
                                    xetThiDua.DiemNghienCuuKhoaHoc;

                // Đảm bảo điểm không vượt quá 100
                if (diemGiangVien > 100)
                {
                    diemGiangVien = 100;
                }

                xetThiDua.TongDiem = diemGiangVien;
            }

            // ===== BƯỚC 2: XẾP LOẠI THI ĐUA DỰA TRÊN TỔNG ĐIỂM =====

            if (xetThiDua.TongDiem >= 90)
            {
                xetThiDua.XepLoaiThiDua = "Xuất sắc";
            }
            else if (xetThiDua.TongDiem >= 80)
            {
                xetThiDua.XepLoaiThiDua = "Tốt";
            }
            else if (xetThiDua.TongDiem >= 65)
            {
                xetThiDua.XepLoaiThiDua = "Khá";
            }
            else if (xetThiDua.TongDiem >= 50)
            {
                xetThiDua.XepLoaiThiDua = "Trung bình";
            }
            else
            {
                xetThiDua.XepLoaiThiDua = "Yếu";
            }

            // ===== BƯỚC 3: GÁN DANH HIỆU THI ĐUA =====

            GanDanhHieuThiDua(xetThiDua);

            // ===== BƯỚC 4: CẬP NHẬT NGÀY ĐÁNH GIÁ =====

            if (xetThiDua.NgayDanhGia == DateTime.MinValue)
            {
                xetThiDua.NgayDanhGia = DateTime.Now;
            }
        }

        // ==================== PHƯƠNG THỨC GÁN DANH HIỆU ====================

        /// <summary>
        /// Gán danh hiệu thi đua dựa trên loại đối tượng và xếp loại
        /// </summary>
        private void GanDanhHieuThiDua(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null)
            {
                return;
            }

            string loai = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);
            string xepLoai = XoaKhoangTrangThua(xetThiDua.XepLoaiThiDua);

            if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên"))
            {
                // ===== DANH HIỆU CHO SINH VIÊN =====

                if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Xuất sắc"))
                {
                    xetThiDua.DanhHieuThiDua = "Sinh viên 5 tốt";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Tốt"))
                {
                    xetThiDua.DanhHieuThiDua = "Sinh viên tiên tiến";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Khá"))
                {
                    xetThiDua.DanhHieuThiDua = "Sinh viên tích cực";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Trung bình"))
                {
                    xetThiDua.DanhHieuThiDua = "";
                }
                else
                {
                    xetThiDua.DanhHieuThiDua = "";
                }
            }
            else if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"))
            {
                // ===== DANH HIỆU CHO GIẢNG VIÊN =====

                if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Xuất sắc"))
                {
                    xetThiDua.DanhHieuThiDua = "Chiến sĩ thi đua cấp trên";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Tốt"))
                {
                    xetThiDua.DanhHieuThiDua = "Chiến sĩ thi đua cơ sở";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Khá"))
                {
                    xetThiDua.DanhHieuThiDua = "Giảng viên tiên tiến";
                }
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Trung bình"))
                {
                    xetThiDua.DanhHieuThiDua = "";
                }
                else
                {
                    xetThiDua.DanhHieuThiDua = "";
                }
            }
        }

        // ==================== PHƯƠNG THỨC CHUẨN HÓA DỮ LIỆU ====================

        /// <summary>
        /// Chuẩn hóa dữ liệu xét thi đua
        /// </summary>
        private void ChuanHoaDuLieu(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null)
            {
                return;
            }

            // Xóa khoảng trắng thừa
            xetThiDua.MaDoiTuong = XoaKhoangTrangThua(xetThiDua.MaDoiTuong);
            xetThiDua.HoTen = XoaKhoangTrangThua(xetThiDua.HoTen);
            xetThiDua.LoaiDoiTuong = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);
            xetThiDua.Khoa = XoaKhoangTrangThua(xetThiDua.Khoa);
            xetThiDua.HocKy = XoaKhoangTrangThua(xetThiDua.HocKy);
            xetThiDua.NguoiDanhGia = XoaKhoangTrangThua(xetThiDua.NguoiDanhGia);
            xetThiDua.GhiChu = XoaKhoangTrangThua(xetThiDua.GhiChu);
        }
    }
}
