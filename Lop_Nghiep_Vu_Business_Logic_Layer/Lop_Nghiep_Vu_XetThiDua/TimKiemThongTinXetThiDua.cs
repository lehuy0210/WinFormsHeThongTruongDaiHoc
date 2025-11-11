using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG TÌM KIẾM THÔNG TIN XÉT THI ĐUA (BLL) ====================
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
    //      • 1.1.3: Basic operations - Retrieve (Lấy phần tử)
    //    - Chapter 2: Sorting - Searching
    //      • 2.2.1: Sequential Search - Tìm kiếm tuần tự
    //      • 2.2.2: Binary Search - Tìm kiếm nhị phân (nếu danh sách có sắp xếp)
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
    // ChucNangTimKiemThongTinXetThiDua chứa TẤT CẢ logic để TÌM KIẾM thông tin xét thi đua:
    // - SEARCH BY ID: Tìm theo mã đối tượng + học kỳ
    // - SEARCH BY CRITERIA: Tìm theo tiêu chí
    // - FILTER: Lọc theo các điều kiện
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như TÌM KIẾM HỒ SƠ XÉT THI ĐUA:
    // Bước 1: Tìm theo mã sinh viên/giảng viên (Fast search)
    // Bước 2: Tìm theo khoa (Filter)
    // Bước 3: Tìm theo xếp loại (Filter)
    // Bước 4: Tìm theo loại đối tượng (Filter)
    //
    // 🔍 QUY TRÌNH TÌM KIẾM XÉT THI ĐUA (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
    //    • Danh sách không null
    //    • Tiêu chí tìm kiếm hợp lệ
    //
    // Bước 2: TÌM KIẾM
    //    • Sequential Search: O(n)
    //    • Duyệt qua từng phần tử
    //    • Kiểm tra điều kiện match
    //    • Thêm vào kết quả nếu khớp
    //
    // Bước 3: TRẢ VỀ DANH SÁCH KẾT QUẢ
    //    • Trả về List<ThongTinXetThiDua>
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Tìm kiếm: O(n) - Sequential Search
    // - Lọc: O(n)
    // → Tổng: O(n)
    //
    public class ChucNangTimKiemThongTinXetThiDua
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

        /// <summary>
        /// Kiểm tra chuỗi con có nằm trong chuỗi không (không phân biệt hoa/thường)
        /// </summary>
        private bool CoChucChuoiTrongChuoi(string chuoi, string chuoiCon)
        {
            if (chuoi == null || chuoiCon == null)
            {
                return false;
            }

            string chuoiThuong = ChuyenVeChuThuong(chuoi);
            string chuoiConThuong = ChuyenVeChuThuong(chuoiCon);

            if (chuoiConThuong.Length > chuoiThuong.Length)
            {
                return false;
            }

            for (int i = 0; i <= chuoiThuong.Length - chuoiConThuong.Length; i++)
            {
                bool khop = true;

                for (int j = 0; j < chuoiConThuong.Length; j++)
                {
                    if (chuoiThuong[i + j] != chuoiConThuong[j])
                    {
                        khop = false;
                        break;
                    }
                }

                if (khop)
                {
                    return true;
                }
            }

            return false;
        }

        // ==================== PHƯƠNG THỨC CHÍNH ====================

        /// <summary>
        /// Tìm kiếm xét thi đua theo các tiêu chí
        /// </summary>
        public List<ThongTinXetThiDua> TimKiemXetThiDua(List<ThongTinXetThiDua> danhSach,
                                                       ThongTinXetThiDua tieuChi)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;
            if (tieuChi == null) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopTieuChi = KiemTraKhopTieuChi(xetThiDua, tieuChi);

                if (khopTieuChi)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo MaDoiTuong
        /// </summary>
        public ThongTinXetThiDua TimTheoMaDoiTuong(List<ThongTinXetThiDua> danhSach, string maDoiTuong)
        {
            if (danhSach == null) return null;

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong) return null;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                if (khopMa)
                {
                    return xetThiDua;
                }
            }

            return null;
        }

        /// <summary>
        /// Tìm tất cả xét thi đua của một đối tượng (theo mã)
        /// </summary>
        public List<ThongTinXetThiDua> TimTatCaTheoMaDoiTuong(List<ThongTinXetThiDua> danhSach, string maDoiTuong)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                if (khopMa)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo MaDoiTuong và HocKy
        /// </summary>
        public ThongTinXetThiDua TimTheoMaVaHocKy(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
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
        /// Tìm xét thi đua theo Khoa
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoKhoa(List<ThongTinXetThiDua> danhSach, string khoa)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopKhoa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.Khoa, khoa);

                if (khopKhoa)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo LoaiDoiTuong
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoLoaiDoiTuong(List<ThongTinXetThiDua> danhSach, string loaiDoiTuong)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool loaiRong = KiemTraChuoiRong(loaiDoiTuong);
            if (loaiRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopLoai = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.LoaiDoiTuong, loaiDoiTuong);

                if (khopLoai)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo XepLoai
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoXepLoai(List<ThongTinXetThiDua> danhSach, string xepLoai)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool xepRong = KiemTraChuoiRong(xepLoai);
            if (xepRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopXep = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.XepLoaiThiDua, xepLoai);

                if (khopXep)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo HocKy
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoHocKy(List<ThongTinXetThiDua> danhSach, string hocKy)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                if (khopKy)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo khoảng điểm
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoKhoangDiem(List<ThongTinXetThiDua> danhSach, int diemMin, int diemMax)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            if (diemMin > diemMax) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                if (xetThiDua.TongDiem >= diemMin && xetThiDua.TongDiem <= diemMax)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tìm xét thi đua theo tên (có chứa chuỗi con)
        /// </summary>
        public List<ThongTinXetThiDua> TimTheoHoTen(List<ThongTinXetThiDua> danhSach, string hoTen)
        {
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();

            if (danhSach == null) return ketQua;

            bool tenRong = KiemTraChuoiRong(hoTen);
            if (tenRong) return ketQua;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool coTen = CoChucChuoiTrongChuoi(xetThiDua.HoTen, hoTen);

                if (coTen)
                {
                    ketQua.Add(xetThiDua);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ ====================

        /// <summary>
        /// Kiểm tra xét thi đua có khớp với tiêu chí tìm kiếm
        /// </summary>
        private bool KiemTraKhopTieuChi(ThongTinXetThiDua xetThiDua, ThongTinXetThiDua tieuChi)
        {
            if (xetThiDua == null || tieuChi == null)
            {
                return false;
            }

            // Kiểm tra mã đối tượng
            bool maRong = KiemTraChuoiRong(tieuChi.MaDoiTuong);
            if (!maRong)
            {
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, tieuChi.MaDoiTuong);
                if (!khopMa) return false;
            }

            // Kiểm tra loại đối tượng
            bool loaiRong = KiemTraChuoiRong(tieuChi.LoaiDoiTuong);
            if (!loaiRong)
            {
                bool khopLoai = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.LoaiDoiTuong, tieuChi.LoaiDoiTuong);
                if (!khopLoai) return false;
            }

            // Kiểm tra khoa
            bool khoaRong = KiemTraChuoiRong(tieuChi.Khoa);
            if (!khoaRong)
            {
                bool khopKhoa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.Khoa, tieuChi.Khoa);
                if (!khopKhoa) return false;
            }

            // Kiểm tra xếp loại
            bool xepRong = KiemTraChuoiRong(tieuChi.XepLoaiThiDua);
            if (!xepRong)
            {
                bool khopXep = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.XepLoaiThiDua, tieuChi.XepLoaiThiDua);
                if (!khopXep) return false;
            }

            // Kiểm tra học kỳ
            bool kyRong = KiemTraChuoiRong(tieuChi.HocKy);
            if (!kyRong)
            {
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, tieuChi.HocKy);
                if (!khopKy) return false;
            }

            return true;
        }
    }
}
