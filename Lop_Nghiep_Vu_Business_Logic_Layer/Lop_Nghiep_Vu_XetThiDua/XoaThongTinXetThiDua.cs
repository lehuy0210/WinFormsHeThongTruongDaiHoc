using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG XÓA THÔNG TIN XÉT THI ĐUA (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures
    //      • 4.2: Selection Structures (if/else) - Kiểm tra điều kiện
    //      • 4.3: Loop Structures (for, foreach) - Duyệt danh sách
    //    - Chapter 5: Functions
    //      • 5.2: Function Definition - Định nghĩa hàm
    //
    // 2️⃣ DATA STRUCTURES AND ALGORITHMS:
    //    - Chapter 1: Lists
    //      • 1.1.4: Basic operations - Remove (Xóa phần tử)
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
    // ChucNangXoaThongTinXetThiDua chứa TẤT CẢ logic để XÓA thông tin xét thi đua:
    // - FIND: Tìm kiếm bản ghi cần xóa
    // - DELETE: Xóa khỏi danh sách
    // - VALIDATION: Kiểm tra xóa thành công
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như XÓA HỒ SƠ XÉT THI ĐUA ở phòng Đào tạo:
    // Bước 1: Tìm hồ sơ cần xóa (Find)
    // Bước 2: Xác nhận xóa (Confirmation)
    // Bước 3: Xóa khỏi hệ thống (Delete)
    // Bước 4: Xác nhận kết quả (Return status)
    //
    // 🔍 QUY TRÌNH XÓA XÉT THI ĐUA (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
    //    • Danh sách không null
    //    • Mã đối tượng không rỗng
    //    • Học kỳ không rỗng
    //
    // Bước 2: TÌM KIẾM THÔNG TIN CẦN XÓA
    //    • Sequential Search: O(n)
    //    • Duyệt qua danh sách
    //    • So sánh MaDoiTuong + HocKy
    //
    // Bước 3: XÓA KHỎI DANH SÁCH
    //    • List.RemoveAt(index)
    //    • List.Count giảm 1
    //    • Độ phức tạp: O(n) vì phải dịch chuyển phần tử
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Tìm kiếm: O(n) - Sequential Search
    // - Xóa: O(n) - Dịch chuyển các phần tử sau
    // → Tổng: O(n)
    //
    public class ChucNangXoaThongTinXetThiDua
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
        /// Xóa thông tin xét thi đua theo MaDoiTuong và HocKy
        /// </summary>
        public bool XoaXetThiDua(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (danhSach == null)
            {
                return false;
            }

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong)
            {
                return false;
            }

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong)
            {
                return false;
            }

            // ===== BƯỚC 2: TÌM VỊ TRÍ THÔNG TIN CẦN XÓA =====

            int viTriXoa = TimViTriXetThiDua(danhSach, maDoiTuong, hocKy);

            if (viTriXoa < 0)
            {
                return false;
            }

            // ===== BƯỚC 3: XÓA KHỎI DANH SÁCH =====

            danhSach.RemoveAt(viTriXoa);

            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return true;
        }

        /// <summary>
        /// Xóa tất cả xét thi đua của một đối tượng (tất cả học kỳ)
        /// </summary>
        public bool XoaTatCaXetThiDuaCuaDoiTuong(List<ThongTinXetThiDua> danhSach, string maDoiTuong)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (danhSach == null)
            {
                return false;
            }

            bool maRong = KiemTraChuoiRong(maDoiTuong);
            if (maRong)
            {
                return false;
            }

            // ===== BƯỚC 2: XÓA TOÀN BỘ BẢN GHI CÓ CÙNG MÃ ĐỐI TƯỢNG =====

            int soXoa = 0;

            // Duyệt ngược để tránh lỗi khi remove
            for (int i = danhSach.Count - 1; i >= 0; i--)
            {
                ThongTinXetThiDua xetThiDua = danhSach[i];

                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                if (khopMa)
                {
                    danhSach.RemoveAt(i);
                    soXoa++;
                }
            }

            // ===== BƯỚC 3: TRẢ VỀ KẾT QUẢ =====
            return (soXoa > 0);
        }

        /// <summary>
        /// Xóa tất cả xét thi đua của một học kỳ
        /// </summary>
        public bool XoaTatCaXetThiDuaCuaHocKy(List<ThongTinXetThiDua> danhSach, string hocKy)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (danhSach == null)
            {
                return false;
            }

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong)
            {
                return false;
            }

            // ===== BƯỚC 2: XÓA TOÀN BỘ BẢN GHI CÓ CÙNG HỌC KỲ =====

            int soXoa = 0;

            // Duyệt ngược để tránh lỗi khi remove
            for (int i = danhSach.Count - 1; i >= 0; i--)
            {
                ThongTinXetThiDua xetThiDua = danhSach[i];

                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                if (khopKy)
                {
                    danhSach.RemoveAt(i);
                    soXoa++;
                }
            }

            // ===== BƯỚC 3: TRẢ VỀ KẾT QUẢ =====
            return (soXoa > 0);
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ ====================

        /// <summary>
        /// Tìm vị trí xét thi đua theo MaDoiTuong và HocKy
        /// Trả về index hoặc -1 nếu không tìm thấy
        /// </summary>
        private int TimViTriXetThiDua(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return -1;
            }

            // Duyệt qua danh sách
            for (int i = 0; i < danhSach.Count; i++)
            {
                ThongTinXetThiDua xetThiDua = danhSach[i];

                // So sánh mã đối tượng
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                // So sánh học kỳ
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                // Nếu cả hai trùng thì return vị trí
                if (khopMa && khopKy)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Tìm xét thi đua theo MaDoiTuong và HocKy
        /// Trả về object hoặc null nếu không tìm thấy
        /// </summary>
        private ThongTinXetThiDua TimXetThiDua(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return null;
            }

            // Duyệt qua danh sách
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                // So sánh mã đối tượng
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.MaDoiTuong, maDoiTuong);

                // So sánh học kỳ
                bool khopKy = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                // Nếu cả hai trùng thì return object
                if (khopMa && khopKy)
                {
                    return xetThiDua;
                }
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra xét thi đua có tồn tại không
        /// </summary>
        public bool KiemTraTonTai(List<ThongTinXetThiDua> danhSach, string maDoiTuong, string hocKy)
        {
            ThongTinXetThiDua xetThiDua = TimXetThiDua(danhSach, maDoiTuong, hocKy);
            return (xetThiDua != null);
        }
    }
}
