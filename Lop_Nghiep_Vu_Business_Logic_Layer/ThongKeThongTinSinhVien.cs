using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG THỐNG KÊ SINH VIÊN ====================
    // Business Logic for Student Statistics
    // Sử dụng: Classes and Objects (Chapter 2 - OOP)
    // Sử dụng: Traverse operation (Chapter 1.1.3 - DSA1)
    /*
    GIẢI THÍCH CHO SINH VIÊN:
   
    Chức năng THỐNG KÊ hoạt động như thế nào?
   
    Bước 1: DUYỆT qua từng sinh viên trong danh sách
    Bước 2: KIỂM TRA sinh viên đó có khớp tiêu chí không
    Bước 3: Nếu KHỚP → Tăng biến đếm lên 1
    Bước 4: Trả về tổng số đã đếm
   
    Thuật toán: Counting (Đếm)
    - Độ phức tạp: O(n) - Phải duyệt hết n phần tử
    - Đơn giản, dễ hiểu
    - Sử dụng biến đếm
    */
    public class ChucNangThongKeSV
    {
        // ==================== ĐẾM THEO GIỚI TÍNH ====================
        // Sử dụng: Traverse + Counting (Chapter 1.1.3 - DSA1)
        /// <summary>
        /// Đếm sinh viên theo giới tính
        /// Count students by gender
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="gioiTinh">Giới tính cần đếm (Nam/Nữ)</param>
        /// <returns>Số lượng sinh viên có giới tính tương ứng</returns>
        /*
        VÍ DỤ SỬ DỤNG:
  
        int soSVNam = thongKe.DemTheoGioiTinh(ds, "Nam");
        int soSVNu = thongKe.DemTheoGioiTinh(ds, "Nữ");
       
        MessageBox.Show($"Có {soSVNam} sinh viên nam và {soSVNu} sinh viên nữ");
       
        VÍ DỤ CHẠY TAY:
 
        ds = [
            {HoSV="Nguyễn", TenSV="An", GioiTinhSV="Nam"},
            {HoSV="Trần", TenSV="Bình", GioiTinhSV="Nam"},
            {HoSV="Lê", TenSV="Chi", GioiTinhSV="Nữ"},
            {HoSV="Phạm", TenSV="Dũng", GioiTinhSV="Nam"}
        ]
       
        Gọi: DemTheoGioiTinh(ds, "Nam")
       
        Bước 1: dem = 0
        Bước 2: Duyệt từng sinh viên
        - SV1: GioiTinhSV="Nam" == "Nam" → dem = 1
        - SV2: GioiTinhSV="Nam" == "Nam" → dem = 2
        - SV3: GioiTinhSV="Nữ" != "Nam" → dem = 2
        - SV4: GioiTinhSV="Nam" == "Nam" → dem = 3
        Bước 3: return dem = 3
       
        Độ phức tạp: O(n)
        */
        public int DemTheoGioiTinh(List<ThongTinSinhVien> danhSach, string gioiTinh)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return 0; // Danh sách không tồn tại
            }
            // Kiểm tra giới tính rỗng
            bool gioiTinhRong = KiemTraChuoiRong(gioiTinh);
            if (gioiTinhRong)
            {
                return 0; // Giới tính không hợp lệ
            }
            // ===== BƯỚC 2: KHỞI TẠO BIẾN ĐẾM =====
            int dem = 0;
            // ===== BƯỚC 3: DUYỆT QUA TỪNG SINH VIÊN (TRAVERSE) =====
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy giới tính của sinh viên hiện tại
                string gioiTinhSV = sv.GioiTinhSV;

                // So sánh giới tính (không phân biệt hoa/thường)
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(gioiTinhSV, gioiTinh);

                if (khop)
                {
                    dem++; // Tăng biến đếm
                }
            }
            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return dem;
        }

        // ==================== ĐẾM THEO LỚP ====================
        /// <summary>
        /// Đếm sinh viên theo lớp
        /// Count students by class
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="lop">Tên lớp cần đếm</param>
        /// <returns>Số lượng sinh viên trong lớp</returns>
        /*
        VÍ DỤ:
       
        int soSV22IT1 = thongKe.DemTheoLop(ds, "22IT1");
        MessageBox.Show($"Lớp 22IT1 có {soSV22IT1} sinh viên");
        */
        public int DemTheoLop(List<ThongTinSinhVien> danhSach, string lop)
        {
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return 0;
            }
            // Kiểm tra lớp rỗng
            bool lopRong = KiemTraChuoiRong(lop);
            if (lopRong)
            {
                return 0;
            }
            // Đếm sinh viên có lớp khớp
            int dem = 0;
            // Duyệt qua từng sinh viên (Traverse)
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy lớp của sinh viên hiện tại
                string lopSV = sv.LopSV;

                // So sánh lớp (không phân biệt hoa/thường)
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(lopSV, lop);

                if (khop)
                {
                    dem++; // Tăng biến đếm
                }
            }
            return dem;
        }

        // ==================== ĐẾM THEO TRẠNG THÁI ====================
        /// <summary>
        /// Đếm sinh viên theo trạng thái
        /// Count students by status
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="trangThai">Trạng thái cần đếm</param>
        /// <returns>Số lượng sinh viên có trạng thái tương ứng</returns>
        /*
        VÍ DỤ:
    
        int soDangHoc = thongKe.DemTheoTrangThai(ds, "Đang học");
        int daTotNghiep = thongKe.DemTheoTrangThai(ds, "Tốt nghiệp");
        int daNghiHoc = thongKe.DemTheoTrangThai(ds, "Nghỉ học");
        */
        public int DemTheoTrangThai(List<ThongTinSinhVien> danhSach, string trangThai)
        {
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return 0;
            }
            // Kiểm tra trạng thái rỗng
            bool trangThaiRong = KiemTraChuoiRong(trangThai);
            if (trangThaiRong)
            {
                return 0;
            }
            // Đếm sinh viên có trạng thái khớp
            int dem = 0;
            // Duyệt qua từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy trạng thái của sinh viên hiện tại
                string trangThaiSV = sv.TrangThaiSV;

                // So sánh trạng thái (không phân biệt hoa/thường)
                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(trangThaiSV, trangThai);

                if (khop)
                {
                    dem++; // Tăng biến đếm
                }
            }
            return dem;
        }

        // ==================== THỐNG KÊ TỔNG QUAN ====================
        /// <summary>
        /// Lấy thống kê tổng quan về sinh viên
        /// Get overall student statistics
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <returns>Dictionary chứa các thống kê</returns>
        /*
        VÍ DỤ SỬ DỤNG:
       
        Dictionary<string, int> thongKe = thongKeSV.LayThongKeTongQuan(ds);
       
        int tongSo = thongKe["TongSoSV"];
        int soNam = thongKe["SoSVNam"];
        int soNu = thongKe["SoSVNu"];
       
        MessageBox.Show($"Tổng: {tongSo}, Nam: {soNam}, Nữ: {soNu}");
    
        VÍ DỤ KẾT QUẢ:
        {
            "TongSoSV": 100,
            "SoSVNam": 60,
            "SoSVNu": 40
        }
        */
        public Dictionary<string, int> LayThongKeTongQuan(List<ThongTinSinhVien> danhSach)
        {
            // Khởi tạo Dictionary kết quả
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return thongKe; // Trả về Dictionary rỗng
            }
            // ===== THỐNG KÊ 1: TỔNG SỐ SINH VIÊN =====
            thongKe["TongSoSV"] = danhSach.Count;
            // ===== THỐNG KÊ 2: SỐ SINH VIÊN NAM =====
            int soSVNam = DemTheoGioiTinh(danhSach, "Nam");
            thongKe["SoSVNam"] = soSVNam;
            // ===== THỐNG KÊ 3: SỐ SINH VIÊN NỮ =====
            int soSVNu = DemTheoGioiTinh(danhSach, "Nữ");
            thongKe["SoSVNu"] = soSVNu;
            return thongKe;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================
        /// <summary>
        /// Kiểm tra chuỗi có rỗng không
        /// </summary>
        private bool KiemTraChuoiRong(string chuoi)
        {
            // Kiểm tra null
            if (chuoi == null)
            {
                return true;
            }
            // Kiểm tra độ dài = 0
            if (chuoi.Length == 0)
            {
                return true;
            }
            // Kiểm tra tất cả ký tự có phải khoảng trắng không
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                // Nếu có ít nhất 1 ký tự không phải khoảng trắng
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    return false; // Chuỗi có nội dung
                }
            }
            // Tất cả ký tự đều là khoảng trắng
            return true;
        }

        /// <summary>
        /// So sánh 2 chuỗi không phân biệt hoa/thường
        /// </summary>
        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            // Kiểm tra null
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }
            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }
            // Chuyển về chữ thường
            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);
            // So sánh
            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        /// <summary>
        /// So sánh 2 chuỗi chính xác
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            // Kiểm tra null
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }
            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }
            // Kiểm tra độ dài
            if (chuoi1.Length != chuoi2.Length)
            {
                return false;
            }
            // So sánh từng ký tự
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
                // Kiểm tra có phải chữ HOA không (A-Z)
                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
                    // Chuyển thành chữ thường (ASCII + 32)
                    char kyTuThuong = (char)(kyTu + 32);
                    ketQua += kyTuThuong;
                }
                else
                {
                    // Giữ nguyên
                    ketQua += kyTu;
                }
            }
            return ketQua;
        }

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================
 
        1. CHỨC NĂNG CHÍNH: Đếm sinh viên theo tiêu chí
        - DemTheoGioiTinh(): Đếm theo nam/nữ
        - DemTheoLop(): Đếm theo lớp
        - DemTheoTrangThai(): Đếm theo trạng thái
        - LayThongKeTongQuan(): Thống kê tổng quan
       
        2. THUẬT TOÁN: Counting (Đếm)
        - Khởi tạo biến đếm = 0
        - Duyệt qua từng phần tử
        - Nếu khớp tiêu chí → Tăng biến đếm
        - Trả về biến đếm
       
        3. ĐỘ PHỨC TẠP:
        - Tất cả: O(n)
        - Phải duyệt hết danh sách
        - Đơn giản, hiệu quả
     
        4. CÁC METHOD HỖ TRỢ TỰ CODE:
        - KiemTraChuoiRong(): Check null/empty
        - SoSanhChuoiKhongPhanBietHoaThuong(): Compare case-insensitive
        - ChuyenVeChuThuong(): Lowercase (ASCII + 32)
       
        5. KIẾN THỨC ÁP DỤNG:
        - OOP: Classes, Objects, Methods
        - DSA1: Traverse operation, Counting
        - String operations: Tự code toàn bộ
        - Dictionary: Lưu kết quả thống kê
   
        6. VÍ DỤ SỬ DỤNG:
        ChucNangThongKeSV thongKe = new ChucNangThongKeSV();
        int soSVNam = thongKe.DemTheoGioiTinh(ds, "Nam");
        int soSV22IT1 = thongKe.DemTheoLop(ds, "22IT1");
        Dictionary<string, int> tongQuan = thongKe.LayThongKeTongQuan(ds);
    
        ==================== END TÓM TẮT ====================
        */
    }
}