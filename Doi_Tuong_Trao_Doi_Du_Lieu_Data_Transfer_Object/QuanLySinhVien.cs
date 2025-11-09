using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH SINH VIÊN (DTO) ====================
    // Sử dụng: Classes and Objects (Chapter 2 - OOP)
    // Sử dụng: Attributes (Chapter 2.1.3 - OOP)
    // Sử dụng: Access Modifiers - private (Chapter 2.1.5 - OOP)
    // 
    // REFACTORED: Class này giờ chỉ là DTO thuần túy - chỉ chứa dữ liệu
    // Tất cả Business Logic đã được di chuyển sang BLL (Business Logic Layer)
    public class QuanLySinhVien
    {
        // ==================== THUỘC TÍNH ====================
        // Danh sách sinh viên
        // Sử dụng: List - Array-based List (Chapter 1.1 - DSA1)
        private List<ThongTinSinhVien> danhSachSinhVien;
        
        /*
         Nguyên tắc Encapsulation (Đóng gói):
           - Che giấu dữ liệu bên trong
           - Chỉ truy cập qua các phương thức public
         - Bảo vệ tính toàn vẹn dữ liệu
         
       NOTE: Class này chỉ quản lý danh sách, KHÔNG chứa logic nghiệp vụ
        */

        // ==================== CONSTRUCTOR ====================
     // Sử dụng: Constructor Methods (Chapter 2.1.7 - OOP)
        public QuanLySinhVien()
    {
            // Khởi tạo danh sách rỗng
   danhSachSinhVien = new List<ThongTinSinhVien>();
    }
        
        /*
  Giải thích:
            - Constructor là hàm đặc biệt chạy khi tạo đối tượng
       - Tên trùng với tên class
            - Không có kiểu trả về
            - Dùng để khởi tạo thuộc tính
         */

        // ==================== GETTER METHODS ====================
        // Sử dụng: Getter Methods (Chapter 2.1.6 - OOP)

        /// <summary>
        /// Lấy danh sách sinh viên
        /// Get student list
    /// </summary>
        /// <returns>Danh sách sinh viên</returns>
        public List<ThongTinSinhVien> LayDanhSachSinhVien()
        {
 return danhSachSinhVien;
        }

  /// <summary>
     /// Lấy số lượng sinh viên
        /// Get number of students
        /// </summary>
        /// <returns>Số lượng sinh viên trong danh sách</returns>
public int LaySoLuongSinhVien()
        {
  return danhSachSinhVien.Count;
        }

   // ==================== SETTER METHOD ====================
        
        /// <summary>
        /// Cập nhật toàn bộ danh sách sinh viên
        /// Update entire student list
   /// </summary>
        /// <param name="danhSachMoi">Danh sách sinh viên mới</param>
  public void CapNhatDanhSach(List<ThongTinSinhVien> danhSachMoi)
        {
         if (danhSachMoi != null)
            {
      this.danhSachSinhVien = danhSachMoi;
            }
     }

  /*
         ==================== BUSINESS LOGIC ĐÃ ĐƯỢC DI CHUYỂN ====================
 
         ❌ ĐÃ XÓA - Các phương thức sau đã được di chuyển sang BLL:
         
         1. ThemSinhVien() 
       → Di chuyển sang: Lớp Nghiệp Vụ\ThemThongTinSinhVien.cs
       
         2. XoaSinhVien()
            → Di chuyển sang: Lớp Nghiệp Vụ\XoaThongTinSinhVien.cs
            
         3. SuaThongTinSinhVien()
 → Di chuyển sang: Lớp Nghiệp Vụ\SuaThongTinSinhVien.cs
            
         4. TimKiemSinhVien()
            → Di chuyển sang: Lớp Nghiệp Vụ\TimKiemThongTinSinhVien.cs
    
         5. SapXepTheoTen(), SapXepTheoMaSV()
  → Di chuyển sang: Lớp Nghiệp Vụ\SapXepThongTinSinhVien.cs
            
   6. DemSinhVienTheoGioiTinh(), DemSinhVienTheoLop()
            → Cần tạo class mới: Lớp Nghiệp Vụ\ThongKeThongTinSinhVien.cs
    
         ==================== CÁCH SỬ DỤNG SAU KHI REFACTOR ====================
     
         // Trước (SAI - vi phạm kiến trúc):
      QuanLySinhVien qlsv = new QuanLySinhVien();
   qlsv.ThemSinhVien(sv);  // ❌ DTO không nên có logic
         
         // Sau (ĐÚNG - theo kiến trúc N-Layer):
         QuanLySinhVien qlsv = new QuanLySinhVien();
         ChucNangThemSV themSV = new ChucNangThemSV();
         themSV.Them(qlsv.LayDanhSachSinhVien(), sv);  // ✅ Logic ở BLL
 
         ==================== END OF REFACTORING NOTES ====================
        */
    }
}