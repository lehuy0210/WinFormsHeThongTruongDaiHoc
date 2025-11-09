using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN SINH VIÊN (DTO) ====================
    // Data Transfer Object for Student Information
    // Sử dụng: Classes and Objects (Chapter 2 - OOP)
    /*
GIẢI THÍCH CHO SINH VIÊN:
    
    DTO (Data Transfer Object) là gì?
- Object dùng để CHUYỂN DỮ LIỆU giữa các lớp
    - Chỉ chứa PROPERTIES (thuộc tính), KHÔNG chứa logic
    - Giống như "tờ giấy" để ghi thông tin sinh viên
    
Tại sao cần DTO?
    - Tách biệt dữ liệu và logic
    - Dễ truyền dữ liệu giữa các form
    - Dễ lưu vào database
    */
    public class ThongTinSinhVien
    { 
   // ===== THUỘC TÍNH ID =====
        // ID tự động tăng trong database
        public int ID { get; set; }
        
        // ===== THUỘC TÍNH MÃ SINH VIÊN =====
   // Mã sinh viên (primary key), bắt buộc có giá trị
        // Khởi tạo = "" để tránh lỗi nullable reference
  public string MaSV { get; set; } = "";
        
      // ===== THUỘC TÍNH HỌ =====
  // Họ của sinh viên, bắt buộc
        public string HoSV { get; set; } = "";
        
    // ===== THUỘC TÍNH TÊN LÓT =====
 // Tên lót của sinh viên, KHÔNG bắt buộc
        public string TenLotSV { get; set; } = "";
        
        // ===== THUỘC TÍNH TÊN =====
 // Tên của sinh viên, bắt buộc
        public string TenSV { get; set; } = "";
        
        // ===== THUỘC TÍNH NGÀY SINH =====
      // Ngày sinh của sinh viên
        // DateTime là value type nên không cần khởi tạo
   public DateTime NgaySinhSV { get; set; }
        
 // ===== THUỘC TÍNH GIỚI TÍNH =====
        // Giới tính: "Nam" hoặc "Nữ"
        public string GioiTinhSV { get; set; } = "";
        
   // ===== THUỘC TÍNH CCCD =====
    // Căn cước công dân (12 số)
        public string CCCDSV { get; set; } = "";

        // ===== THUỘC TÍNH ĐỊA CHỈ =====
        // Địa chỉ của sinh viên
      public string DiaChiSV { get; set; } = "";
 
        // ===== THUỘC TÍNH EMAIL =====
        // Email của sinh viên
      public string EmailSV { get; set; } = "";
        
        // ===== THUỘC TÍNH LỚP =====
        // Lớp học của sinh viên
        public string LopSV { get; set; } = "";
        
    // ===== THUỘC TÍNH TRẠNG THÁI =====
        // Trạng thái: "Đang học", "Tốt nghiệp", "Nghỉ học", ...
      public string TrangThaiSV { get; set; } = "";

        // ===== THUỘC TÍNH HÌNH ẢNH =====
        // Đường dẫn đến file hình ảnh của sinh viên
        // Lưu đường dẫn (path) thay vì byte[] để dễ xử lý
        public string HinhAnhSV { get; set; } = "";
        
        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================
        
     1. DTO CHỈ CHỨA PROPERTIES:
     - Không có methods
 - Không có logic xử lý
- Chỉ lưu trữ dữ liệu
        
        2. KHỞI TẠO GIÁ TRỊ MẶC ĐỊNH:
           - string properties = "" (chuỗi rỗng)
           - Tránh lỗi nullable reference trong C# 12.0
        - DateTime không cần khởi tạo (value type)
        
        3. AUTO-PROPERTIES:
   - { get; set; } tự động tạo getter/setter
       - Compiler tự tạo backing field
        - Code ngắn gọn, dễ đọc
        
4. CÁCH SỬ DỤNG:
  // Tạo object mới
   ThongTinSinhVien sv = new ThongTinSinhVien();
    
           // Set giá trị
           sv.MaSV = "SV001";
 sv.HoSV = "Nguyễn";
           sv.TenSV = "An";
   
           // Get giá trị
           string ma = sv.MaSV; // "SV001"
        
        5. KIẾN THỨC ÁP DỤNG:
           - OOP: Classes, Properties, Auto-properties
   - C# 12.0: Nullable reference types
   - Design pattern: Data Transfer Object (DTO)
  
        ==================== END TÓM TẮT ====================
        */
    }   
}
