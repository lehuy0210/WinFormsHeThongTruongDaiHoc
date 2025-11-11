using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG SỬA THÔNG TIN XÉT THI ĐUA (BLL) ====================
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
    // 2️⃣ DATA STRUCTURES AND ALGORITHMS:
    //    - Chapter 1: Lists
    //      • 1.1.3: Basic operations - Update (Sửa phần tử)
    //    - Chapter 2: Sorting - Searching
    //      • 2.2.1: Sequential Search - Tìm kiếm tuần tự
    //
    // 3️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1.4: Methods - Phương thức
    //
    // 4️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.2: Business Logic Layer (BLL) - Lớp nghiệp vụ
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ChucNangSuaThongTinXetThiDua chứa TẤT CẢ logic để SỬA thông tin xét thi đua:
    // - FIND: Tìm bản ghi cần sửa
    // - VALIDATION: Kiểm tra dữ liệu mới hợp lệ
    // - UPDATE: Cập nhật thông tin
    // - RE-EVALUATE: Tính lại điểm và xếp loại
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như CHỈNH SỬA HỒ SƠ XÉT THI ĐUA:
    // Bước 1: Tìm hồ sơ cần sửa (Find)
    // Bước 2: Kiểm tra dữ liệu mới (Validation)
    // Bước 3: Cập nhật thông tin (Update)
    // Bước 4: Tính lại điểm và xếp loại (Re-evaluate)
    //
    // 🔍 QUY TRÌNH SỬA XÉT THI ĐUA (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
    //    • Danh sách không null
    //    • Mã đối tượng không rỗng
    //    • Học kỳ không rỗng
    //
    // Bước 2: TÌM THÔNG TIN CẦN SỬA
    //    • Sequential Search: O(n)
    //    • So sánh MaDoiTuong + HocKy
    //
    // Bước 3: KIỂM TRA DỮ LIỆU MỚI HỢP LỆ
    //    • Kiểm tra các constraint
    //    • Kiểm tra loại đối tượng
    //
    // Bước 4: CẬP NHẬT THÔNG TIN
    //    • Gán giá trị mới
    //    • Đổi reference object
    //
    // Bước 5: TÍNH LẠI ĐIỂM VÀ XẾP LOẠI
    //    • Gọi DanhGiaThiDua từ ThemThongTinXetThiDua
    //    • Cập nhật TongDiem, XepLoai, DanhHieu
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Tìm kiếm: O(n)
    // - Cập nhật: O(1)
    // - Tính lại: O(1)
    // → Tổng: O(n)
    //
    public class ChucNangSuaThongTinXetThiDua
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

        // ==================== PHƯƠNG THỨC CHÍNH ====================

        /// <summary>
        /// Sửa toàn bộ thông tin xét thi đua
        /// </summary>
        public bool SuaThongTinXetThiDua(List<ThongTinXetThiDua> danhSach,
                                        string maDoiTuong,
                                        string hocKy,
                                        ThongTinXetThiDua thongTinMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (danhSach == null) return false;

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong) return false;

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong) return false;

            if (thongTinMoi == null) return false;

            // ===== BƯỚC 2: TÌM THÔNG TIN CẦN SỬA =====

            ThongTinXetThiDua xetThiDuaCuChan = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDuaCuChan == null) return false;

            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU MỚI HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(thongTinMoi);

            if (!duLieuHopLe) return false;

            // ===== BƯỚC 4: CẬP NHẬT THÔNG TIN =====

            xetThiDuaCuChan.HoTen = thongTinMoi.HoTen;
            xetThiDuaCuChan.Khoa = thongTinMoi.Khoa;
            xetThiDuaCuChan.DiemYThucHocTap = thongTinMoi.DiemYThucHocTap;
            xetThiDuaCuChan.DiemThamGiaHoatDong = thongTinMoi.DiemThamGiaHoatDong;
            xetThiDuaCuChan.DiemYThucCongDan = thongTinMoi.DiemYThucCongDan;
            xetThiDuaCuChan.DiemQuanHeCongDong = thongTinMoi.DiemQuanHeCongDong;
            xetThiDuaCuChan.SoLanViPham = thongTinMoi.SoLanViPham;
            xetThiDuaCuChan.DiemNangLucChuyenMon = thongTinMoi.DiemNangLucChuyenMon;
            xetThiDuaCuChan.DiemPhuongPhapGiangDay = thongTinMoi.DiemPhuongPhapGiangDay;
            xetThiDuaCuChan.DiemThaiDoVoiSinhVien = thongTinMoi.DiemThaiDoVoiSinhVien;
            xetThiDuaCuChan.DiemNghienCuuKhoaHoc = thongTinMoi.DiemNghienCuuKhoaHoc;
            xetThiDuaCuChan.NguoiDanhGia = thongTinMoi.NguoiDanhGia;
            xetThiDuaCuChan.GhiChu = thongTinMoi.GhiChu;

            // ===== BƯỚC 5: TÍNH LẠI ĐIỂM VÀ XẾP LOẠI =====

            DanhGiaLaiThiDua(xetThiDuaCuChan);

            // ===== BƯỚC 6: TRẢ VỀ KẾT QUẢ =====
            return true;
        }

        /// <summary>
        /// Sửa điểm ý thức học tập
        /// </summary>
        public bool SuaDiemYThucHocTap(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 20) return false;

            xetThiDua.DiemYThucHocTap = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm tham gia hoạt động
        /// </summary>
        public bool SuaDiemThamGiaHoatDong(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 30) return false;

            xetThiDua.DiemThamGiaHoatDong = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm ý thức công dân
        /// </summary>
        public bool SuaDiemYThucCongDan(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 20) return false;

            xetThiDua.DiemYThucCongDan = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm quan hệ cộng đồng
        /// </summary>
        public bool SuaDiemQuanHeCongDong(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 20) return false;

            xetThiDua.DiemQuanHeCongDong = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa số lần vi phạm
        /// </summary>
        public bool SuaSoLanViPham(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int soViPhamMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (soViPhamMoi < 0) return false;

            xetThiDua.SoLanViPham = soViPhamMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm năng lực chuyên môn
        /// </summary>
        public bool SuaDiemNangLucChuyenMon(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 30) return false;

            xetThiDua.DiemNangLucChuyenMon = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm phương pháp giảng dạy
        /// </summary>
        public bool SuaDiemPhuongPhapGiangDay(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 30) return false;

            xetThiDua.DiemPhuongPhapGiangDay = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm thái độ với sinh viên
        /// </summary>
        public bool SuaDiemThaiDoVoiSinhVien(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 20) return false;

            xetThiDua.DiemThaiDoVoiSinhVien = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa điểm nghiên cứu khoa học
        /// </summary>
        public bool SuaDiemNghienCuuKhoaHoc(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, int diemMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            if (diemMoi < 0 || diemMoi > 20) return false;

            xetThiDua.DiemNghienCuuKhoaHoc = diemMoi;
            DanhGiaLaiThiDua(xetThiDua);
            return true;
        }

        /// <summary>
        /// Sửa họ tên
        /// </summary>
        public bool SuaHoTen(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, string tenMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            bool tenRong = KiemTraChuoiRong(tenMoi);
            if (tenRong) return false;

            xetThiDua.HoTen = XoaKhoangTrangThua(tenMoi);
            return true;
        }

        /// <summary>
        /// Sửa khoa
        /// </summary>
        public bool SuaKhoa(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy, string khoaMoi)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);

            if (xetThiDua == null) return false;

            bool khoaRong = KiemTraChuoiRong(khoaMoi);
            if (khoaRong) return false;

            xetThiDua.Khoa = XoaKhoangTrangThua(khoaMoi);
            return true;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ ====================

        /// <summary>
        /// Kiểm tra dữ liệu hợp lệ
        /// </summary>
        private bool KiemTraDuLieuHopLe(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null) return false;

            // Kiểm tra các chuỗi
            bool tenRong = KiemTraChuoiRong(xetThiDua.HoTen);
            if (tenRong) return false;

            // Kiểm tra các điểm
            if (xetThiDua.DiemYThucHocTap < 0 || xetThiDua.DiemYThucHocTap > 20) return false;
            if (xetThiDua.DiemThamGiaHoatDong < 0 || xetThiDua.DiemThamGiaHoatDong > 30) return false;
            if (xetThiDua.DiemYThucCongDan < 0 || xetThiDua.DiemYThucCongDan > 20) return false;
            if (xetThiDua.DiemQuanHeCongDong < 0 || xetThiDua.DiemQuanHeCongDong > 20) return false;
            if (xetThiDua.DiemNangLucChuyenMon < 0 || xetThiDua.DiemNangLucChuyenMon > 30) return false;
            if (xetThiDua.DiemPhuongPhapGiangDay < 0 || xetThiDua.DiemPhuongPhapGiangDay > 30) return false;
            if (xetThiDua.DiemThaiDoVoiSinhVien < 0 || xetThiDua.DiemThaiDoVoiSinhVien > 20) return false;
            if (xetThiDua.DiemNghienCuuKhoaHoc < 0 || xetThiDua.DiemNghienCuuKhoaHoc > 20) return false;
            if (xetThiDua.SoLanViPham < 0) return false;

            return true;
        }

        /// <summary>
        /// Tìm xét thi đua theo MaDoiTuong và HocKy
        /// </summary>
        private ThongTinXetThiDua TimXetThiDua(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            if (danhSach == null) return null;

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong) return null;

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong) return null;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                if (khopMa && khopKy)
                {
                    return xetThiDua;
                }
            }

            return null;
        }

        /// <summary>
        /// Tính lại điểm và xếp loại cho xét thi đua
        /// </summary>
        private void DanhGiaLaiThiDua(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null)
            {
                return;
            }

            // Tính tổng điểm
            string loai = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);

            if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên"))
            {
                int diemSinhVien = xetThiDua.DiemYThucHocTap +
                                   xetThiDua.DiemThamGiaHoatDong +
                                   xetThiDua.DiemYThucCongDan +
                                   xetThiDua.DiemQuanHeCongDong -
                                   (xetThiDua.SoLanViPham * 10);

                if (diemSinhVien < 0) diemSinhVien = 0;
                if (diemSinhVien > 100) diemSinhVien = 100;

                xetThiDua.TongDiem = diemSinhVien;
            }
            else if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"))
            {
                int diemGiangVien = xetThiDua.DiemNangLucChuyenMon +
                                    xetThiDua.DiemPhuongPhapGiangDay +
                                    xetThiDua.DiemThaiDoVoiSinhVien +
                                    xetThiDua.DiemNghienCuuKhoaHoc;

                if (diemGiangVien > 100) diemGiangVien = 100;

                xetThiDua.TongDiem = diemGiangVien;
            }

            // Xếp loại
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

            // Gán danh hiệu
            GanDanhHieu(xetThiDua);
        }

        /// <summary>
        /// Gán danh hiệu dựa trên xếp loại
        /// </summary>
        private void GanDanhHieu(ThongTinXetThiDua xetThiDua)
        {
            if (xetThiDua == null) return;

            string loai = XoaKhoangTrangThua(xetThiDua.LoaiDoiTuong);
            string xepLoai = XoaKhoangTrangThua(xetThiDua.XepLoaiThiDua);

            if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Sinh viên"))
            {
                if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Xuất sắc"))
                    xetThiDua.DanhHieuThiDua = "Sinh viên 5 tốt";
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Tốt"))
                    xetThiDua.DanhHieuThiDua = "Sinh viên tiên tiến";
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Khá"))
                    xetThiDua.DanhHieuThiDua = "Sinh viên tích cực";
                else
                    xetThiDua.DanhHieuThiDua = "";
            }
            else if (SoSanhChuoiKhongPhanBietHoaThuong(loai, "Giảng viên"))
            {
                if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Xuất sắc"))
                    xetThiDua.DanhHieuThiDua = "Chiến sĩ thi đua cấp trên";
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Tốt"))
                    xetThiDua.DanhHieuThiDua = "Chiến sĩ thi đua cơ sở";
                else if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Khá"))
                    xetThiDua.DanhHieuThiDua = "Giảng viên tiên tiến";
                else
                    xetThiDua.DanhHieuThiDua = "";
            }
        }
    }
}
