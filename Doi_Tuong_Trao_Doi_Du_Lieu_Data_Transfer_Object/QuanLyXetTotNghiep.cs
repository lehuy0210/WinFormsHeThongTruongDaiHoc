using System.Collections.Generic;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== DATA TRANSFER OBJECT - QUẢN LÝ XÉT TỐT NGHIỆP ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATA STRUCTURES: List<T> - Generic collection
    // 2️⃣ OBJECT-ORIENTED PROGRAMMING: Encapsulation, Information hiding
    // 3️⃣ DESIGN PATTERNS: Data Access Object (DAO) pattern
    //
    // 💡 MỤC ĐÍCH:
    // Class này quản lý danh sách các đợt xét tốt nghiệp
    // Đóng gói (encapsulate) List<ThongTinXetTotNghiep> và cung cấp methods truy xuất an toàn

    public class QuanLyXetTotNghiep
    {
        // ==================== PRIVATE FIELD ====================
        // 🔒 ENCAPSULATION: Private field để bảo vệ dữ liệu
        // Chỉ có thể truy cập thông qua public methods
        private List<ThongTinXetTotNghiep> danhSachXetTotNghiep;

        // ==================== CONSTRUCTOR ====================
        // 📝 GIẢI THÍCH:
        // Constructor khởi tạo List rỗng khi tạo object QuanLyXetTotNghiep
        // Đảm bảo danhSachXetTotNghiep không bao giờ null → Tránh NullReferenceException
        public QuanLyXetTotNghiep()
        {
            danhSachXetTotNghiep = new List<ThongTinXetTotNghiep>();
        }

        // ==================== PUBLIC METHODS ====================

        // 🔍 GETTER: Trả về danh sách xét tốt nghiệp
        // 📝 LƯU Ý: Trả về reference của List, không phải bản copy
        // → Nếu cần bảo mật cao hơn, nên return new List<>(danhSachXetTotNghiep)
        public List<ThongTinXetTotNghiep> LayDanhSachXetTotNghiep()
        {
            return danhSachXetTotNghiep;
        }

        // 📊 Lấy số lượng sinh viên đã xét tốt nghiệp
        public int LaySoLuongSinhVien()
        {
            return danhSachXetTotNghiep.Count;
        }

        // 🔄 Cập nhật toàn bộ danh sách
        // VD: Sau khi load từ database
        public void CapNhatDanhSach(List<ThongTinXetTotNghiep> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                danhSachXetTotNghiep = danhSachMoi;
            }
        }

        // ==================== GIẢI THÍCH ENCAPSULATION ====================
        //
        // 🔒 TẠI SAO DÙNG PRIVATE + PUBLIC METHODS?
        //
        // ❌ CÁCH SAI (Không dùng encapsulation):
        // public List<ThongTinXetTotNghiep> danhSachXetTotNghiep;
        // → Ai cũng có thể gán danhSachXetTotNghiep = null → Lỗi NullReferenceException
        // → Không kiểm soát được dữ liệu
        //
        // ✅ CÁCH ĐÚNG (Dùng encapsulation):
        // private List<ThongTinXetTotNghiep> danhSachXetTotNghiep;
        // public List<ThongTinXetTotNghiep> LayDanhSachXetTotNghiep() { return danhSachXetTotNghiep; }
        // → Kiểm soát được cách truy xuất dữ liệu
        // → Có thể thêm validation, logging trong methods
        //
        // 📊 LỢI ÍCH:
        // 1. Data Protection: Bảo vệ dữ liệu khỏi truy cập trái phép
        // 2. Flexibility: Dễ dàng thay đổi implementation mà không ảnh hưởng code bên ngoài
        // 3. Maintainability: Dễ bảo trì và debug
        // 4. Validation: Có thể thêm validation logic trong setter methods
        //
        // 🎓 VÍ DỤ THỰC TÊ:
        // QuanLyXetTotNghiep quanLy = new QuanLyXetTotNghiep();
        // List<ThongTinXetTotNghiep> ds = quanLy.LayDanhSachXetTotNghiep(); // OK
        // int soLuong = quanLy.LaySoLuongSinhVien(); // OK
        // quanLy.CapNhatDanhSach(danhSachMoi); // OK
        //
        // // quanLy.danhSachXetTotNghiep = null; // COMPILE ERROR - private field
    }
}
