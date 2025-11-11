using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH HỒ SƠ (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class QuanLyHoSo
    //      • 2.1.3: Constructor - Khởi tạo danh sách
    //      • 2.1.4: Methods - Getter methods
    //      • 2.3: Encapsulation - Private field, Public methods
    //
    // 2️⃣ DATA STRUCTURES AND ALGORITHMS 1:
    //    - Chapter 1: Lists
    //      • 1.1: Array-based Lists - List<T>
    //      • 1.1.1: Dynamic array - Tự động tăng kích thước
    //
    // 3️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: DTO Pattern - Quản lý danh sách
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // QuanLyHoSo quản lý DANH SÁCH HỒ SƠ:
    // - LƯU TRỮ: Danh sách các hồ sơ (tuyển sinh, nhân sự)
    // - ENCAPSULATION: Che giấu List bên trong
    // - GETTER METHODS: Cung cấp truy cập an toàn
    // - DTO THUẦN TÚY: KHÔNG chứa business logic
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như TỦ HỒ SƠ trong phòng hành chính:
    // - Tủ chứa nhiều hồ sơ (List<ThongTinHoSo>)
    // - Có thể lấy ra xem (LayDanhSachHoSo)
    // - Có thể đếm số lượng (LaySoLuongHoSo)
    // - Có thể thay toàn bộ (CapNhatDanhSach)
    // - KHÔNG có chức năng thêm/xóa/sửa (để BLL xử lý)
    //
    // 📊 CẤU TRÚC:
    //
    // QuanLyHoSo {
    //     private List<ThongTinHoSo> danhSachHoSo;  → Danh sách (private)
    //
    //     + QuanLyHoSo()                             → Constructor
    //     + LayDanhSachHoSo(): List                  → Getter
    //     + LaySoLuongHoSo(): int                    → Getter
    //     + CapNhatDanhSach(List): void              → Setter
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Tại sao cần class QuanLyHoSo?
    - Encapsulation: Che giấu List bên trong
    - Dễ mở rộng: Sau này thêm validation, logging
    - Consistent API: Giao diện thống nhất

    Tại sao KHÔNG có Them/Xoa/Sua?
    - SAI: quanLy.ThemHoSo(hs);  ❌ DTO không nên có logic
    - ĐÚNG:
      List<ThongTinHoSo> ds = quanLy.LayDanhSachHoSo();
      chucNangThem.ThemHoSo(ds, hs);  ✅ Logic ở BLL

    List là Reference Type:
    - LayDanhSachHoSo() trả về REFERENCE (địa chỉ)
    - BLL thay đổi List → DTO cũng thay đổi
    - Không cần return List mới

    Constructor:
    - Tự động chạy khi tạo object
    - Khởi tạo danhSachHoSo = new List<>()
    - Tránh lỗi NullReferenceException

    Count vs LaySoLuongHoSo:
    - List.Count: Trực tiếp truy cập (vi phạm encapsulation)
    - LaySoLuongHoSo(): Qua method (tuân thủ encapsulation)
    */
    public class QuanLyHoSo
    {
        // ==================== THUỘC TÍNH ====================
        // Danh sách hồ sơ (PRIVATE - Encapsulation)
        // Sử dụng: List - Array-based List (Chapter 1.1 - DSA1)
        private List<ThongTinHoSo> danhSachHoSo;

        /*
        Nguyên tắc Encapsulation (Đóng gói):
        - Che giấu dữ liệu bên trong
        - Chỉ truy cập qua các phương thức public
        - Bảo vệ tính toàn vẹn dữ liệu

        NOTE: Class này chỉ quản lý danh sách, KHÔNG chứa logic nghiệp vụ
        */

        // ==================== CONSTRUCTOR ====================
        // Sử dụng: Constructor Methods (Chapter 2.1.7 - OOP)

        /// <summary>
        /// Constructor - Khởi tạo đối tượng QuanLyHoSo
        /// Constructor - Initialize QuanLyHoSo object
        /// </summary>
        /*
        VÍ DỤ SỬ DỤNG:

        QuanLyHoSo qlhs = new QuanLyHoSo();

        Khi chạy dòng trên:
        Bước 1: Compiler tạo object mới trong memory
        Bước 2: Gọi constructor QuanLyHoSo()
        Bước 3: Khởi tạo danhSachHoSo = new List<ThongTinHoSo>()
        Bước 4: Trả về reference (địa chỉ) object cho biến qlhs

        GIẢI THÍCH:
        - Constructor là hàm đặc biệt chạy khi tạo đối tượng
        - Tên trùng với tên class
        - Không có kiểu trả về (không có void, int, string,...)
        - Dùng để khởi tạo thuộc tính
        */
        public QuanLyHoSo()
        {
            // Khởi tạo danh sách rỗng
            // Count = 0, Capacity = 0 (tự động tăng khi Add)
            danhSachHoSo = new List<ThongTinHoSo>();
        }

        // ==================== GETTER METHODS ====================
        // Sử dụng: Getter Methods (Chapter 2.1.6 - OOP)

        /// <summary>
        /// Lấy danh sách hồ sơ
        /// Get records list
        /// </summary>
        /// <returns>Danh sách hồ sơ (Reference)</returns>
        /*
        VÍ DỤ SỬ DỤNG:

        QuanLyHoSo qlhs = new QuanLyHoSo();
        List<ThongTinHoSo> ds = qlhs.LayDanhSachHoSo();

        // Thêm hồ sơ vào danh sách
        ThongTinHoSo hs = new ThongTinHoSo();
        ds.Add(hs);

        // Kiểm tra
        Console.WriteLine(qlhs.LaySoLuongHoSo()); // Output: 1

        GIẢI THÍCH:
        - Trả về REFERENCE (địa chỉ) của List, không phải copy
        - Thay đổi ds → danhSachHoSo cũng thay đổi
        - Đây là cách BLL thao tác với dữ liệu DTO
        */
        public List<ThongTinHoSo> LayDanhSachHoSo()
        {
            return danhSachHoSo;
        }

        /// <summary>
        /// Lấy số lượng hồ sơ
        /// Get number of records
        /// </summary>
        /// <returns>Số lượng hồ sơ trong danh sách</returns>
        /*
        VÍ DỤ SỬ DỤNG:

        QuanLyHoSo qlhs = new QuanLyHoSo();
        int soLuong = qlhs.LaySoLuongHoSo(); // 0 (danh sách rỗng)

        qlhs.LayDanhSachHoSo().Add(new ThongTinHoSo());
        soLuong = qlhs.LaySoLuongHoSo(); // 1

        GIẢI THÍCH:
        - Wrapper method cho List.Count
        - Tuân thủ Encapsulation
        - Dễ thêm logic (log, validation) sau này
        */
        public int LaySoLuongHoSo()
        {
            return danhSachHoSo.Count;
        }

        // ==================== SETTER METHOD ====================

        /// <summary>
        /// Cập nhật toàn bộ danh sách hồ sơ
        /// Update entire records list
        /// </summary>
        /// <param name="danhSachMoi">Danh sách hồ sơ mới</param>
        /*
        VÍ DỤ SỬ DỤNG:

        // Tạo danh sách mới
        List<ThongTinHoSo> dsMoi = new List<ThongTinHoSo>();
        dsMoi.Add(new ThongTinHoSo { MaHoSo = "HS001" });
        dsMoi.Add(new ThongTinHoSo { MaHoSo = "HS002" });

        // Cập nhật
        QuanLyHoSo qlhs = new QuanLyHoSo();
        qlhs.CapNhatDanhSach(dsMoi);

        Console.WriteLine(qlhs.LaySoLuongHoSo()); // Output: 2

        GIẢI THÍCH:
        - Thay thế toàn bộ danh sách cũ bằng danh sách mới
        - Kiểm tra null để tránh lỗi
        - Dùng khi load từ database hoặc file
        */
        public void CapNhatDanhSach(List<ThongTinHoSo> danhSachMoi)
        {
            // Kiểm tra null
            if (danhSachMoi != null)
            {
                // Thay thế danh sách cũ
                this.danhSachHoSo = danhSachMoi;
            }
        }

        /*
        ==================== BUSINESS LOGIC ĐÃ ĐƯỢC DI CHUYỂN ====================

        ❌ ĐÃ XÓA - Các phương thức sau đã được di chuyển sang BLL:

        1. ThemHoSo()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\ThemThongTinHoSo.cs

        2. XoaHoSo()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\XoaThongTinHoSo.cs

        3. SuaThongTinHoSo()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\SuaThongTinHoSo.cs

        4. TimKiemHoSo()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\TimKiemThongTinHoSo.cs

        5. SapXepTheoMa(), SapXepTheoNgay()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\SapXepThongTinHoSo.cs

        6. ThongKeTheoLoai(), ThongKeTheoTrangThai()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyHoSo\ThongKeThongTinHoSo.cs

        ==================== CÁCH SỬ DỤNG SAU KHI REFACTOR ====================

        // Trước (SAI - vi phạm kiến trúc):
        QuanLyHoSo qlhs = new QuanLyHoSo();
        qlhs.ThemHoSo(hs);  // ❌ DTO không nên có logic

        // Sau (ĐÚNG - theo kiến trúc N-Layer):
        QuanLyHoSo qlhs = new QuanLyHoSo();
        ChucNangThemThongTinHoSo themHS = new ChucNangThemThongTinHoSo();
        themHS.ThemHoSo(qlhs.LayDanhSachHoSo(), hs);  // ✅ Logic ở BLL

        ==================== END OF REFACTORING NOTES ====================
        */

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================

        1. ROLE CỦA DTO:
           - Chỉ chứa dữ liệu (data container)
           - KHÔNG chứa logic nghiệp vụ
           - Getter/Setter đơn giản

        2. ENCAPSULATION:
           - private List → Ẩn dữ liệu
           - public methods → Truy cập có kiểm soát
           - Bảo vệ dữ liệu khỏi thay đổi trái phép

        3. CONSTRUCTOR:
           - Khởi tạo List rỗng
           - Tránh NullReferenceException
           - Chạy tự động khi new object

        4. REFERENCE TYPE:
           - LayDanhSachHoSo() trả về reference
           - BLL thao tác trực tiếp List gốc
           - Không cần return List mới

        5. SO SÁNH:
           - QuanLySinhVien: Quản lý danh sách SV
           - QuanLyHoSo: Quản lý danh sách hồ sơ
           - Cấu trúc giống nhau, DTO pattern

        ==================== END TÓM TẮT ====================
        */
    }
}
