using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG THÊM SINH VIÊN (BLL) ====================
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
    //      • 5.5.1: Value Parameters - Tham số theo giá trị
    //      • 5.5.2: Reference Parameters - Tham số theo tham chiếu
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 4: Character Strings
    //      • 4.4: String Operations - Xử lý chuỗi
    //      • 4.4.1: Accessing individual elements - Truy cập từng ký tự
    //      • 4.4.2: Determining length - Lấy độ dài chuỗi
    //
    // 3️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class
    //      • 2.1.4: Methods - Phương thức
    //      • 2.2: Object - Tạo và sử dụng object
    //      • 2.2.3: Passing Objects to Methods - Truyền object vào method
    //
    // 4️⃣ GUI PROGRAMMING:
    //    - Chapter 2: The C# Programming Language
    //      • 2.7: Operators - Toán tử
    //      • 2.8: Selection Structures - Cấu trúc rẽ nhánh
    //      • 2.9: Loop Structures - Cấu trúc lặp
    //    - Chapter 3: Object-Oriented Programming in C#
    //      • 3.3: Methods - Phương thức
    //      • 3.9: Ways to pass parameters - Cách truyền tham số
    //
    // 5️⃣ DATA STRUCTURES AND ALGORITHMS 1:
    //    - Chapter 1: Lists
    //      • 1.1: Array-based Lists
    //      • 1.1.3: Basic operations - Insert (Thêm phần tử vào danh sách)
    //    - Chapter 2: Sorting - Searching
    //      • 2.2.1: Sequential Search - Tìm kiếm tuần tự (kiểm tra trùng)
    //
    // 6️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.2: Business Logic Layer (BLL) - Lớp nghiệp vụ
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ChucNangThemThongTinSV chứa TẤT CẢ logic để THÊM sinh viên mới:
    // - VALIDATION: Kiểm tra dữ liệu hợp lệ (họ, tên, tuổi, email,...)
    // - DUPLICATE CHECK: Kiểm tra mã SV không bị trùng
    // - DATA NORMALIZATION: Chuẩn hóa dữ liệu (viết hoa chữ đầu, xóa space thừa)
    // - AUTO GENERATE: Tạo mã SV tự động nếu chưa có
    // - INSERT: Thêm vào List
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như ĐĂNG KÝ SINH VIÊN MỚI ở phòng Đào tạo:
    // Bước 1: Nhân viên kiểm tra giấy tờ (Validation)
    // Bước 2: Tra cứu mã SV đã tồn tại chưa (Duplicate check)
    // Bước 3: Điền thông tin vào form chuẩn (Normalization)
    // Bước 4: Cấp mã SV (Auto generate)
    // Bước 5: Lưu hồ sơ vào tủ (Insert to List)
    //
    // 🔍 QUY TRÌNH THÊM SINH VIÊN (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU HỢP LỆ (Validation)
    //    • Họ, tên không rỗng
    //    • Ngày sinh hợp lệ, tuổi >= 18
    //    • Giới tính = "Nam" hoặc "Nữ"
    //    • Email có ký tự '@'
    //
    // Bước 2: KIỂM TRA TRÙNG MÃ SINH VIÊN
    //    • Sequential Search: O(n)
    //    • Duyệt qua toàn bộ danh sách
    //    • So sánh từng mã SV với mã mới
    //    • Nếu trùng → return false
    //
    // Bước 3: CHUẨN HÓA DỮ LIỆU (Data Normalization)
    //    • Xóa khoảng trắng thừa đầu/cuối
    //    • Viết HOA chữ cái đầu mỗi từ
    //    • VD: "  nguyễn  văn  an " → "Nguyễn Văn An"
    //
    // Bước 4: TẠO MÃ SINH VIÊN TỰ ĐỘNG (nếu chưa có)
    //    • Format: SVYYxxxx
    //    • VD: SV240001, SV240002,...
    //    • YY = 2 số cuối năm (24 = 2024)
    //    • xxxx = Số thứ tự (tìm max + 1)
    //
    // Bước 5: THÊM VÀO DANH SÁCH
    //    • danhSach.Add(sinhVienMoi)
    //    • Độ phức tạp: O(1) amortized
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Kiểm tra trùng: O(n) - Sequential Search
    // - Tìm mã lớn nhất: O(n)
    // - Add to List: O(1)
    // → Tổng: O(n)
    /*
    GIẢI THÍCH CHO SINH VIÊN:
    
    Chức năng THÊM hoạt động như thế nào?
    
    Bước 1: KIỂM TRA dữ liệu hợp lệ (Validation)
    Bước 2: KIỂM TRA mã sinh viên có bị trùng không
    Bước 3: CHUẨN HÓA dữ liệu (viết hoa chữ cái đầu, xóa khoảng trắng thừa)
    Bước 4: THÊM vào cuối List
    
    Tại sao thêm lại ảnh hưởng đến List gốc?
    - List.Add() thêm reference (địa chỉ) object vào cuối List
    - List tự động tăng Count lên 1
    - Object được quản lý bởi List!
    
    Độ phức tạp: O(n)
    - Kiểm tra trùng mã: O(n)
    - Add vào cuối: O(1)
    */
    public class ChucNangThemThongTinSV
    {
        // ==================== PHƯƠNG THỨC THÊM SINH VIÊN ====================
        // Sử dụng: Insert operation (Chapter 1.1.3 - DSA1)

        /// <summary>
        /// Thêm sinh viên mới vào danh sách
        /// Add new student to list
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên hiện tại</param>
        /// <param name="sinhVienMoi">Sinh viên cần thêm</param>
        /// <returns>true nếu thêm thành công, false nếu thất bại</returns>
        /*
        VÍ DỤ SỬ DỤNG:
        
        ThongTinSinhVien svMoi = new ThongTinSinhVien 
        {
    MaSV = "SV001",
            HoSV = "Nguyễn",
 TenSV = "An",
  NgaySinhSV = new DateTime(2005, 1, 1),
   GioiTinhSV = "Nam",
  LopSV = "22IT1"
        };
        
        bool ketQua = chucNangThem.ThemSinhVien(ds, svMoi);
  
  VÍ DỤ CHẠY TAY:
        
        Trước khi thêm:
        ds = [SV001, SV002]
        ds.Count = 2
        
        Gọi: ThemSinhVien(ds, SV003)
        
      Bước 1: Kiểm tra SV003 null → Không null ✓
    Bước 2: Kiểm tra mã "SV003" đã tồn tại → Chưa tồn tại ✓
        Bước 3: Kiểm tra dữ liệu hợp lệ → Hợp lệ ✓
        Bước 4: Add(SV003) vào cuối list
        
        Sau khi thêm:
        ds = [SV001, SV002, SV003]
        ds.Count = 3
        */
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
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r') // \t: tab khoảng trắng \r: về đầu dòng \n: xuống dòng (dòng mới)
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
            return chuoi.Substring(viTriDau, doDai); //SubString dùng để lấy một phần nhỏ của chuỗi gốc, từ vị trí đầu rồi lấy số kí tự theo độ dài
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

        /// <summary>
        /// Chuyển 1 ký tự về chữ hoa
        /// </summary>
        private char ChuyenKyTuVeChuHoa(char kyTu)
        {
            bool laThuong = (kyTu >= 'a') && (kyTu <= 'z');

            if (laThuong)
            {
                return (char)(kyTu - 32);
            }

            return kyTu;
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
        /// Tách chuỗi thành các từ
        /// </summary>
        private List<string> TachChuoiThanhCacTu(string chuoi)
        {
            List<string> cacTu = new List<string>();

            if (chuoi == null || chuoi.Length == 0)
            {
                return cacTu;
            }

            string tuHienTai = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                if (kyTu == ' ')
                {
                    if (tuHienTai.Length > 0)
                    {
                        cacTu.Add(tuHienTai);
                        tuHienTai = "";
                    }
                }
                else
                {
                    tuHienTai += kyTu;
                }
            }

            if (tuHienTai.Length > 0)
            {
                cacTu.Add(tuHienTai);
            }

            return cacTu;
        }

        /// <summary>
        /// Ghép các từ lại thành chuỗi
        /// </summary>
        private string GhepCacTu(List<string> cacTu)
        {
            if (cacTu == null || cacTu.Count == 0)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < cacTu.Count; i++)
            {
                ketQua += cacTu[i];

                if (i < cacTu.Count - 1)
                {
                    ketQua += " ";
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Kiểm tra chuỗi có bắt đầu bằng chuỗi con không
        /// </summary>
        private bool KiemTraBatDauBang(string chuoi, string chuoiCon)
        {
            if (chuoi == null || chuoiCon == null)
            {
                return false;
            }

            if (chuoiCon.Length > chuoi.Length)
            {
                return false;
            }

            for (int i = 0; i < chuoiCon.Length; i++)
            {
                if (chuoi[i] != chuoiCon[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi thành số
        /// </summary>
        private int ChuyenChuoiThanhSo(string chuoi)
        {
            if (chuoi == null || chuoi.Length == 0)
            {
                return 0;
            }

            int ketQua = 0;

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                if (kyTu >= '0' && kyTu <= '9')
                {
                    int chuSo = kyTu - '0';
                    ketQua = ketQua * 10 + chuSo;
                }
                else
                {
                    return 0; // Có ký tự không phải số
                }
            }

            return ketQua;
        }

        public bool ThemSinhVien(List<ThongTinSinhVien> danhSach, ThongTinSinhVien sinhVienMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra sinh viên mới null
            if (sinhVienMoi == null)
            {
                return false; // Không có sinh viên để thêm
            }

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return false; // Danh sách không tồn tại
            }

            // ===== BƯỚC 2: KIỂM TRA MÃ SINH VIÊN TRÙNG =====
            // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)

            bool maTonTai = KiemTraMaSVTonTai(danhSach, sinhVienMoi.MaSV);

            if (maTonTai)
            {
                return false; // Mã sinh viên đã tồn tại → Không thêm được
            }

            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(sinhVienMoi);

            if (!duLieuHopLe)
            {
                return false; // Dữ liệu không hợp lệ → Không thêm được
            }

            // ===== BƯỚC 4: THÊM SINH VIÊN VÀO CUỐI DANH SÁCH =====
            // Sử dụng: Insert at the end (Chapter 1.1.3 - DSA1)
            /*
              GIẢI THÍCH: List.Add() hoạt động như thế nào?

              List trước: [SV001, SV002]
              Index:      [0]    [1]
              Count: 2

              Gọi: Add(SV003)

       Bước 1: Tăng Count lên 1 → Count = 3
    Bước 2: Thêm reference vào cuối → index 2

   List sau: [SV001, SV002, SV003]
      Index:    [0]    [1] [2]
           Count: 3

              Độ phức tạp: O(1) - Thêm vào cuối rất nhanh
         */
            danhSach.Add(sinhVienMoi);

            // ===== BƯỚC 5: TRẢ VỀ KẾT QUẢ =====
            return true; // Thêm thành công!
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA MÃ TỒN TẠI ====================
        // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)

        /// <summary>
        /// Kiểm tra mã sinh viên đã tồn tại chưa
        /// Check if student ID exists
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần kiểm tra</param>
        /// <returns>true nếu đã tồn tại, false nếu chưa</returns>
        /*
          VÍ DỤ CHẠY TAY:

          ds = [SV001, SV002, SV003]
          Kiểm tra: "SV002"

    Lần 1: So sánh "SV001" với "SV002" → Không khớp
          Lần 2: So sánh "SV002" với "SV002" → Khớp! → return true

        Độ phức tạp: O(n)
      */
        private bool KiemTraMaSVTonTai(List<ThongTinSinhVien> danhSach, string maSV)
        {
            // Kiểm tra mã rỗng
            bool maRong = KiemTraChuoiRong(maSV);
            if (maRong)
            {
                return false;
            }

            // Tìm kiếm tuần tự (Sequential Search)
            // Duyệt qua từng sinh viên trong danh sách
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy mã sinh viên hiện tại
                string maSVHienTai = sv.MaSV;

                // So sánh mã (không phân biệt hoa/thường)
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maSVHienTai, maSV);

                if (khopMa)
                {
                    return true; // Tìm thấy → Đã tồn tại
                }
            }

            return false; // Không tìm thấy → Chưa tồn tại
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA DỮ LIỆU HỢP LỆ ====================

        /// <summary>
        /// Kiểm tra dữ liệu sinh viên có hợp lệ không
        /// Validate student data
        /// </summary>
        /// <param name="sv">Sinh viên cần kiểm tra</param>
        /// <returns>true nếu hợp lệ, false nếu không</returns>
        /*
               DANH SÁCH KIỂM TRA:
               1. Mã sinh viên: Bắt buộc (không rỗng)
               2. Họ: Bắt buộc (không rỗng)
               3. Tên: Bắt buộc (không rỗng)
               4. Ngày sinh: Phải hợp lệ (không phải MinValue)
         5. Tuổi: Phải >= 18
           */
        private bool KiemTraDuLieuHopLe(ThongTinSinhVien sv)
        {
            // ===== KIỂM TRA 1: MÃ SINH VIÊN (BẮT BUỘC) =====
            bool maRong = KiemTraChuoiRong(sv.MaSV);

            if (maRong)
            {
                return false; // Mã sinh viên rỗng → Không hợp lệ
            }

            // ===== KIỂM TRA 2: HỌ (BẮT BUỘC) =====
            bool hoRong = KiemTraChuoiRong(sv.HoSV);

            if (hoRong)
            {
                return false; // Họ rỗng → Không hợp lệ
            }

            // ===== KIỂM TRA 3: TÊN (BẮT BUỘC) =====
            bool tenRong = KiemTraChuoiRong(sv.TenSV);

            if (tenRong)
            {
                return false; // Tên rỗng → Không hợp lệ
            }

            // ===== KIỂM TRA 4: NGÀY SINH (PHẢI HỢP LỆ) =====
            bool ngaySinhHopLe = (sv.NgaySinhSV != DateTime.MinValue);

            if (!ngaySinhHopLe)
            {
                return false; // Ngày sinh không hợp lệ
            }

            // ===== KIỂM TRA 5: TUỔI (>= 18) =====
            int namHienTai = DateTime.Now.Year;
            int namSinh = sv.NgaySinhSV.Year;
            int tuoi = namHienTai - namSinh;

            bool tuoiHopLe = (tuoi >= 18);

            if (!tuoiHopLe)
            {
                return false; // Tuổi không hợp lệ (chưa đủ 18)
            }

            // Tất cả đều hợp lệ
            return true;
        }

        // ==================== PHƯƠNG THỨC CHUẨN HÓA DỮ LIỆU ====================

        /// <summary>
        /// Chuẩn hóa dữ liệu sinh viên trước khi thêm
        /// Normalize student data before adding
        /// </summary>
        /// <param name="sv">Sinh viên cần chuẩn hóa</param>
        /*
        CHUẨN HÓA BAO GỒM:
        1. Xóa khoảng trắng thừa ở đầu/cuối
        2. Viết hoa chữ cái đầu của họ, tên lót, tên
        3. Viết hoa toàn bộ mã sinh viên
        
   VÍ DỤ:
        Trước: { HoSV="nguyễn  ", TenSV="văn an", MaSV="sv001" }
        Sau:   { HoSV="Nguyễn", TenSV="Văn An", MaSV="SV001" }
  */
        public void ChuanHoaDuLieu(ThongTinSinhVien sv)
        {
            // Kiểm tra null
            if (sv == null)
            {
                return;
            }

            // ===== BƯỚC 1: XÓA KHOẢNG TRẮNG THỪA =====

            sv.MaSV = XoaKhoangTrangThua(sv.MaSV);
            sv.HoSV = XoaKhoangTrangThua(sv.HoSV);
            sv.TenLotSV = XoaKhoangTrangThua(sv.TenLotSV);
            sv.TenSV = XoaKhoangTrangThua(sv.TenSV);
            sv.EmailSV = XoaKhoangTrangThua(sv.EmailSV);
            sv.DiaChiSV = XoaKhoangTrangThua(sv.DiaChiSV);
            sv.LopSV = XoaKhoangTrangThua(sv.LopSV);
            sv.CCCDSV = XoaKhoangTrangThua(sv.CCCDSV);

            // ===== BƯỚC 2: VIẾT HOA CHỮ CÁI ĐẦU =====

            sv.HoSV = VietHoaChuCaiDau(sv.HoSV);
            sv.TenLotSV = VietHoaChuCaiDau(sv.TenLotSV);
            sv.TenSV = VietHoaChuCaiDau(sv.TenSV);

            // ===== BƯỚC 3: VIẾT HOA MÃ SINH VIÊN =====

            sv.MaSV = ChuyenVeChuHoa(sv.MaSV);
        }

        // ==================== PHƯƠNG THỨC VIẾT HOA CHỮ CÁI ĐẦU ====================
        // Sử dụng: String operations (Chapter 4 - Programming Techniques)

        /// <summary>
        /// Viết hoa chữ cái đầu mỗi từ
        /// Capitalize first letter of each word
        /// </summary>
        /// <param name="chuoi">Chuỗi cần xử lý</param>
        /// <returns>Chuỗi đã viết hoa chữ cái đầu</returns>
        /*
        VÍ DỤ CHẠY TAY:
        
      VietHoaChuCaiDau("nguyễn văn an")
        
        Bước 1: Tách thành các từ
 - cacTu = ["nguyễn", "văn", "an"]

        Bước 2: Xử lý từng từ
     - "nguyễn" → "Nguyễn" (n → N)
  - "văn" → "Văn" (v → V)
   - "an" → "An" (a → A)

        Bước 3: Ghép lại
 - Kết quả: "Nguyễn Văn An"
        */
        public string VietHoaChuCaiDau(string chuoi)
        {
            // Kiểm tra rỗng
            bool rong = KiemTraChuoiRong(chuoi);
            if (rong)
            {
                return chuoi;
            }

            // Tách chuỗi thành các từ (tách theo khoảng trắng)
            List<string> cacTu = TachChuoiThanhCacTu(chuoi);

            // Viết hoa chữ cái đầu mỗi từ
            for (int i = 0; i < cacTu.Count; i++)
            {
                string tu = cacTu[i];

                if (tu.Length > 0)
                {
                    // Lấy ký tự đầu tiên
                    char kyTuDau = tu[0];

                    // Chuyển thành chữ hoa
                    char kyTuDauHoa = ChuyenKyTuVeChuHoa(kyTuDau);

                    // Lấy phần còn lại
                    string phanConLai = "";
                    if (tu.Length > 1)
                    {
                        phanConLai = tu.Substring(1);
                        phanConLai = ChuyenVeChuThuong(phanConLai);
                    }

                    // Ghép lại
                    cacTu[i] = kyTuDauHoa + phanConLai;
                }
            }

            // Ghép các từ lại thành chuỗi
            return GhepCacTu(cacTu);
        }

        // ==================== PHƯƠNG THỨC TẠO MÃ SINH VIÊN TỰ ĐỘNG ====================

        /// <summary>
        /// Tạo mã sinh viên tự động dựa trên danh sách hiện có
        /// Auto-generate student ID based on existing list
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="namVaoHoc">Năm vào học</param>
        /// <returns>Mã sinh viên mới</returns>
        /*
                FORMAT: SV + Năm (2 số cuối) + Số thứ tự (4 số)

                VÍ DỤ:
                - Năm 2024 → SV240001, SV240002, SV240003, ...
                - Năm 2025 → SV250001, SV250002, SV250003, ...

                THUẬT TOÁN:
                1. Lấy 2 số cuối của năm (2024 → "24")
                2. Tìm số thứ tự lớn nhất trong năm đó
                3. Tăng số thứ tự lên 1
                4. Ghép thành mã: "SV" + năm + số thứ tự
                */
        public string TaoMaSinhVienTuDong(List<ThongTinSinhVien> danhSach, int namVaoHoc)
        {
            // Lấy 2 số cuối của năm
            // VD: 2024 % 100 = 24
            int namCuoi = namVaoHoc % 100;
            string namStr = namCuoi.ToString();

            // Đảm bảo luôn có 2 chữ số (09 thay vì 9)
            if (namStr.Length == 1)
            {
                namStr = "0" + namStr;
            }

            // Bắt đầu từ số thứ tự 1
            int soThuTu = 1;

            // Tìm số thứ tự lớn nhất trong năm này
            if (danhSach != null)
            {
                foreach (ThongTinSinhVien sv in danhSach)
                {
                    // Kiểm tra mã sinh viên có bắt đầu bằng "SV" + năm không
                    string dauMa = "SV" + namStr;

                    bool batDau = KiemTraBatDauBang(sv.MaSV, dauMa);

                    if (batDau)
                    {
                        // Lấy 4 số cuối (số thứ tự)
                        string soStr = sv.MaSV.Substring(4); // Bỏ "SV24", lấy phần sau

                        // Chuyển thành số
                        int so = ChuyenChuoiThanhSo(soStr);

                        // Cập nhật số thứ tự lớn nhất
                        if (so >= soThuTu)
                        {
                            soThuTu = so + 1;
                        }
                    }
                }
            }

            // Tạo mã sinh viên
            // Đảm bảo số thứ tự luôn có 4 chữ số (0001, 0002, ...)
            string soThuTuStr = soThuTu.ToString();
            while (soThuTuStr.Length < 4)
            {
                soThuTuStr = "0" + soThuTuStr;
            }

            return "SV" + namStr + soThuTuStr;
        }

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================
 
        1. CHỨC NĂNG CHÍNH: ThemSinhVien()
        - Kiểm tra trùng mã
       - Kiểm tra dữ liệu hợp lệ
       - Thêm vào cuối List
           - Độ phức tạp: O(n)
        
  2. CHUẨN HÓA DỮ LIỆU: ChuanHoaDuLieu()
           - Xóa khoảng trắng thừa
        - Viết hoa chữ cái đầu (họ, tên lót, tên)
        - Viết hoa toàn bộ mã SV
        
        3. TẠO MÃ TỰ ĐỘNG: TaoMaSinhVienTuDong()
   - Format: SV + năm (2 số) + số thứ tự (4 số)
     - VD: SV240001, SV240002, ...
        
    4. CÁC METHOD HỖ TRỢ TỰ CODE:
        - KiemTraChuoiRong()
- XoaKhoangTrangThua()
           - ChuyenVeChuThuong(), ChuyenVeChuHoa()
           - VietHoaChuCaiDau()
      - TachChuoiThanhCacTu(), GhepCacTu()
 - ChuyenChuoiThanhSo()
     
        5. KIẾN THỨC ÁP DỤNG:
           - OOP: Classes, Objects, Methods
       - DSA1: Insert operation, Sequential Search
           - String operations: Tự code toàn bộ
           - ASCII manipulation
  
        ==================== END TÓM TẮT ====================
        */
    }
}