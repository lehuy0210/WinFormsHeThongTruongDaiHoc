using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG THỐNG KÊ THÔNG TIN XÉT THI ĐUA (BLL) ====================
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
    //      • 1.1.3: Basic operations - Counting, Summing
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
    //      • Aggregation Functions - Các hàm tập hợp
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ChucNangThongKeThongTinXetThiDua chứa TẤT CẢ logic để THỐNG KÊ thông tin xét thi đua:
    // - COUNT: Đếm số lượng
    // - SUM: Tính tổng
    // - AVERAGE: Tính trung bình
    // - GROUP: Nhóm dữ liệu
    // - FILTER & COUNT: Lọc và đếm
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như BÁO CÁO THỐNG KÊ KẾT QUẢ XÉT THI ĐUA:
    // Bước 1: Đếm tổng số đối tượng được đánh giá
    // Bước 2: Đếm số lượng theo xếp loại (Xuất sắc, Tốt, Khá,...)
    // Bước 3: Đếm số lượng theo loại đối tượng (Sinh viên, Giảng viên)
    // Bước 4: Đếm số lượng theo khoa
    // Bước 5: Tính trung bình điểm chung
    //
    // 🔍 QUY TRÌNH THỐNG KÊ (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
    //    • Danh sách không null
    //    • Danh sách có ít nhất 1 phần tử
    //
    // Bước 2: THỰC HIỆN THỐNG KÊ
    //    • Duyệt qua danh sách: O(n)
    //    • Đếm, cộng, so sánh: O(1)
    //    • Lưu kết quả
    //
    // Bước 3: TRẢ VỀ KẾT QUẢ
    //    • Trả về các con số thống kê
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Thống kê: O(n) - Duyệt toàn bộ danh sách
    // → Tổng: O(n)
    //
    public class ChucNangThongKeThongTinXetThiDua
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

        // ==================== PHƯƠNG THỨC THỐNG KÊ CHÍNH ====================

        /// <summary>
        /// Thống kê tổng số xét thi đua
        /// </summary>
        public int ThongKeTongSoXetThiDua(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return 0;

            return danhSach.Count;
        }

        /// <summary>
        /// Thống kê số xét thi đua theo xếp loại
        /// </summary>
        public int ThongKeTheoXepLoai(List<ThongTinXetThiDua> danhSach, string xepLoai)
        {
            if (danhSach == null) return 0;

            bool xepRong = KiemTraChuoiRong(xepLoai);
            if (xepRong) return 0;

            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.XepLoaiThiDua, xepLoai);

                if (khop)
                {
                    soLuong++;
                }
            }

            return soLuong;
        }

        /// <summary>
        /// Thống kê số xét thi đua xuất sắc
        /// </summary>
        public int ThongKeSoXuatSac(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoXepLoai(danhSach, "Xuất sắc");
        }

        /// <summary>
        /// Thống kê số xét thi đua tốt
        /// </summary>
        public int ThongKeSoTot(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoXepLoai(danhSach, "Tốt");
        }

        /// <summary>
        /// Thống kê số xét thi đua khá
        /// </summary>
        public int ThongKeSoKha(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoXepLoai(danhSach, "Khá");
        }

        /// <summary>
        /// Thống kê số xét thi đua trung bình
        /// </summary>
        public int ThongKeSoTrungBinh(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoXepLoai(danhSach, "Trung bình");
        }

        /// <summary>
        /// Thống kê số xét thi đua yếu
        /// </summary>
        public int ThongKeSoYeu(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoXepLoai(danhSach, "Yếu");
        }

        /// <summary>
        /// Thống kê số xét thi đua theo loại đối tượng
        /// </summary>
        public int ThongKeTheoLoaiDoiTuong(List<ThongTinXetThiDua> danhSach, string loaiDoiTuong)
        {
            if (danhSach == null) return 0;

            bool loaiRong = KiemTraChuoiRong(loaiDoiTuong);
            if (loaiRong) return 0;

            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.LoaiDoiTuong, loaiDoiTuong);

                if (khop)
                {
                    soLuong++;
                }
            }

            return soLuong;
        }

        /// <summary>
        /// Thống kê số sinh viên được đánh giá
        /// </summary>
        public int ThongKeSoSinhVien(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoLoaiDoiTuong(danhSach, "Sinh viên");
        }

        /// <summary>
        /// Thống kê số giảng viên được đánh giá
        /// </summary>
        public int ThongKeSoGiangVien(List<ThongTinXetThiDua> danhSach)
        {
            return ThongKeTheoLoaiDoiTuong(danhSach, "Giảng viên");
        }

        /// <summary>
        /// Thống kê số xét thi đua theo khoa
        /// </summary>
        public int ThongKeTheoKhoa(List<ThongTinXetThiDua> danhSach, string khoa)
        {
            if (danhSach == null) return 0;

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong) return 0;

            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.Khoa, khoa);

                if (khop)
                {
                    soLuong++;
                }
            }

            return soLuong;
        }

        /// <summary>
        /// Thống kê số xét thi đua theo học kỳ
        /// </summary>
        public int ThongKeTheoHocKy(List<ThongTinXetThiDua> danhSach, string hocKy)
        {
            if (danhSach == null) return 0;

            bool kyRong = KiemTraChuoiRong(hocKy);
            if (kyRong) return 0;

            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.HocKy, hocKy);

                if (khop)
                {
                    soLuong++;
                }
            }

            return soLuong;
        }

        // ==================== PHƯƠNG THỨC TÍNH TRUNG BÌNH ====================

        /// <summary>
        /// Tính trung bình điểm chung của tất cả
        /// </summary>
        public double TinhTrungBinhDiemChung(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return 0;
            if (danhSach.Count == 0) return 0;

            int tongDiem = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                tongDiem += xetThiDua.TongDiem;
            }

            double trungBinh = (double)tongDiem / danhSach.Count;

            return trungBinh;
        }

        /// <summary>
        /// Tính trung bình điểm theo xếp loại
        /// </summary>
        public double TinhTrungBinhDiemTheoXepLoai(List<ThongTinXetThiDua> danhSach, string xepLoai)
        {
            if (danhSach == null) return 0;

            bool xepRong = KiemTraChuoiRong(xepLoai);
            if (xepRong) return 0;

            int tongDiem = 0;
            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.XepLoaiThiDua, xepLoai);

                if (khop)
                {
                    tongDiem += xetThiDua.TongDiem;
                    soLuong++;
                }
            }

            if (soLuong == 0) return 0;

            double trungBinh = (double)tongDiem / soLuong;

            return trungBinh;
        }

        /// <summary>
        /// Tính trung bình điểm theo loại đối tượng
        /// </summary>
        public double TinhTrungBinhDiemTheoLoaiDoiTuong(List<ThongTinXetThiDua> danhSach, string loaiDoiTuong)
        {
            if (danhSach == null) return 0;

            bool loaiRong = KiemTraChuoiRong(loaiDoiTuong);
            if (loaiRong) return 0;

            int tongDiem = 0;
            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.LoaiDoiTuong, loaiDoiTuong);

                if (khop)
                {
                    tongDiem += xetThiDua.TongDiem;
                    soLuong++;
                }
            }

            if (soLuong == 0) return 0;

            double trungBinh = (double)tongDiem / soLuong;

            return trungBinh;
        }

        /// <summary>
        /// Tính trung bình điểm theo khoa
        /// </summary>
        public double TinhTrungBinhDiemTheoKhoa(List<ThongTinXetThiDua> danhSach, string khoa)
        {
            if (danhSach == null) return 0;

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong) return 0;

            int tongDiem = 0;
            int soLuong = 0;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(xetThiDua.Khoa, khoa);

                if (khop)
                {
                    tongDiem += xetThiDua.TongDiem;
                    soLuong++;
                }
            }

            if (soLuong == 0) return 0;

            double trungBinh = (double)tongDiem / soLuong;

            return trungBinh;
        }

        // ==================== PHƯƠNG THỨC TÌM CỰC TRỊ ====================

        /// <summary>
        /// Tìm điểm cao nhất
        /// </summary>
        public int TimDiemCaoNhat(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0) return 0;

            int diemCaoNhat = danhSach[0].TongDiem;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                if (xetThiDua.TongDiem > diemCaoNhat)
                {
                    diemCaoNhat = xetThiDua.TongDiem;
                }
            }

            return diemCaoNhat;
        }

        /// <summary>
        /// Tìm điểm thấp nhất
        /// </summary>
        public int TimDiemThapNhat(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0) return 0;

            int diemThapNhat = danhSach[0].TongDiem;

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                if (xetThiDua.TongDiem < diemThapNhat)
                {
                    diemThapNhat = xetThiDua.TongDiem;
                }
            }

            return diemThapNhat;
        }

        /// <summary>
        /// Lấy tổng số khoa
        /// </summary>
        public int DemTongSoKhoa(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0) return 0;

            List<string> cacKhoa = new List<string>();

            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                string khoa = XoaKhoangTrangThua(xetThiDua.Khoa);

                // Kiểm tra khoa đã có trong danh sách chưa
                bool daCo = false;
                foreach (string k in cacKhoa)
                {
                    if (SoSanhChuoiKhongPhanBietHoaThuong(k, khoa))
                    {
                        daCo = true;
                        break;
                    }
                }

                if (!daCo && !KiemTraChuoiRong(khoa))
                {
                    cacKhoa.Add(khoa);
                }
            }

            return cacKhoa.Count;
        }
    }
}
