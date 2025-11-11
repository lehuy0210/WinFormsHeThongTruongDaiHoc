using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua
{
    // ==================== CLASS CHỨC NĂNG SẮP XẾP THÔNG TIN XÉT THI ĐUA (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures
    //      • 4.2: Selection Structures (if/else) - So sánh
    //      • 4.3: Loop Structures (for, foreach) - Duyệt danh sách
    //    - Chapter 5: Functions
    //      • 5.2: Function Definition - Định nghĩa hàm
    //      • 5.4: Value-Returning Functions - Hàm trả về giá trị
    //
    // 2️⃣ DATA STRUCTURES AND ALGORITHMS:
    //    - Chapter 3: Sorting Algorithms
    //      • 3.1: Bubble Sort - Sắp xếp nổi bọt
    //      • 3.2: Insertion Sort - Sắp xếp chèn
    //      • 3.3: Selection Sort - Sắp xếp lựa chọn
    //      • Sắp xếp tăng dần / giảm dần
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
    // ChucNangSapXepThongTinXetThiDua chứa TẤT CẢ logic để SẮP XẾP thông tin xét thi đua:
    // - SORT BY SCORE: Sắp xếp theo tổng điểm
    // - SORT BY DATE: Sắp xếp theo ngày đánh giá
    // - SORT BY NAME: Sắp xếp theo tên
    // - ASCENDING / DESCENDING: Tăng/giảm dần
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như SẮP XẾP BẢNG CÔNG BỐ KẾT QUẢ XÉT THI ĐUA:
    // Bước 1: Sắp xếp theo điểm cao nhất trước (Descending)
    // Bước 2: Sắp xếp theo ngày đánh giá (Ascending)
    // Bước 3: Hiển thị lên bảng tin (Display)
    //
    // 🔍 QUY TRÌNH SẮP XẾP (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
    //    • Danh sách không null
    //    • Danh sách có ít nhất 1 phần tử
    //
    // Bước 2: SẮP XẾP DỮ LIỆU
    //    • Bubble Sort: O(n²) - Simple, dễ hiểu
    //    • So sánh từng cặp phần tử
    //    • Đổi chỗ nếu cần
    //
    // Bước 3: TRẢ VỀ DANH SÁCH ĐÃ SẮP XẾP
    //    • Trả về List<ThongTinXetThiDua>
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Bubble Sort: O(n²)
    // - Comparisons: O(n²)
    // → Tổng: O(n²)
    //
    public class ChucNangSapXepThongTinXetThiDua
    {
        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================

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

        // ==================== PHƯƠNG THỨC CHÍNH ====================

        /// <summary>
        /// Sắp xếp theo tổng điểm (tăng dần)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoTongDiemTangDan(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Tăng dần
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (ketQua[j].TongDiem > ketQua[j + 1].TongDiem)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo tổng điểm (giảm dần)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoTongDiemGiamDan(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Giảm dần
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (ketQua[j].TongDiem < ketQua[j + 1].TongDiem)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo ngày đánh giá (tăng dần - cũ trước)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoNgayDanhGiaTangDan(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Tăng dần (cũ trước)
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (ketQua[j].NgayDanhGia.CompareTo(ketQua[j + 1].NgayDanhGia) > 0)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo ngày đánh giá (giảm dần - mới trước)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoNgayDanhGiaGiamDan(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Giảm dần (mới trước)
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (ketQua[j].NgayDanhGia.CompareTo(ketQua[j + 1].NgayDanhGia) < 0)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo tên (A-Z)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoTenAZ(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - A-Z
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (SoSanhTenAZ(ketQua[j].HoTen, ketQua[j + 1].HoTen) > 0)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo tên (Z-A)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoTenZA(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Z-A
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    if (SoSanhTenAZ(ketQua[j].HoTen, ketQua[j + 1].HoTen) < 0)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Sắp xếp theo xếp loại (Xuất sắc -> Yếu)
        /// </summary>
        public List<ThongTinXetThiDua> SapXepTheoXepLoai(List<ThongTinXetThiDua> danhSach)
        {
            if (danhSach == null) return null;

            // Tạo bản sao
            List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
            foreach (ThongTinXetThiDua xetThiDua in danhSach)
            {
                ketQua.Add(xetThiDua);
            }

            // Bubble Sort - Theo thứ tự xếp loại
            for (int i = 0; i < ketQua.Count - 1; i++)
            {
                for (int j = 0; j < ketQua.Count - 1 - i; j++)
                {
                    int thutubj = LayTheTuXepLoai(ketQua[j].XepLoaiThiDua);
                    int thutubjp1 = LayTheTuXepLoai(ketQua[j + 1].XepLoaiThiDua);

                    if (thutubj > thutubjp1)
                    {
                        // Đổi chỗ
                        ThongTinXetThiDua temp = ketQua[j];
                        ketQua[j] = ketQua[j + 1];
                        ketQua[j + 1] = temp;
                    }
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ ====================

        /// <summary>
        /// So sánh 2 tên theo alphabetical order
        /// Trả về: < 0 nếu chuoi1 < chuoi2, > 0 nếu chuoi1 > chuoi2, 0 nếu bằng
        /// </summary>
        private int SoSanhTenAZ(string ten1, string ten2)
        {
            if (ten1 == null && ten2 == null) return 0;
            if (ten1 == null) return -1;
            if (ten2 == null) return 1;

            string ten1Thuong = ChuyenVeChuThuong(ten1);
            string ten2Thuong = ChuyenVeChuThuong(ten2);

            for (int i = 0; i < ten1Thuong.Length && i < ten2Thuong.Length; i++)
            {
                if (ten1Thuong[i] < ten2Thuong[i]) return -1;
                if (ten1Thuong[i] > ten2Thuong[i]) return 1;
            }

            if (ten1Thuong.Length < ten2Thuong.Length) return -1;
            if (ten1Thuong.Length > ten2Thuong.Length) return 1;

            return 0;
        }

        /// <summary>
        /// Lấy thứ tự xếp loại (để sắp xếp)
        /// Xuất sắc=1, Tốt=2, Khá=3, Trung bình=4, Yếu=5
        /// </summary>
        private int LayTheTuXepLoai(string xepLoai)
        {
            if (xepLoai == null) return 6;

            if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Xuất sắc")) return 1;
            if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Tốt")) return 2;
            if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Khá")) return 3;
            if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Trung bình")) return 4;
            if (SoSanhChuoiKhongPhanBietHoaThuong(xepLoai, "Yếu")) return 5;

            return 6;
        }
    }
}
