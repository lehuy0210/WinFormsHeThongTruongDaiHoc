using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN GIẢNG VIÊN (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class ThongTinGiangVien
    //      • 2.1.2: Properties - Các thuộc tính của giảng viên
    //      • 2.1.2.1: Auto-implemented Properties - { get; set; }
    //      • 2.2: Object - Tạo instance của giảng viên
    //      • 2.3: Encapsulation - Đóng gói dữ liệu
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 3: Data Types
    //      • 3.1: Built-in types - int, string, DateTime
    //      • 3.2: Reference types - string
    //      • 3.3: Value types - int, DateTime
    //
    // 3️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: Data Transfer Object (DTO) - Lớp truyền dữ liệu
    //      • DTO Pattern: Chuyển dữ liệu giữa các layer
    //
    // 4️⃣ SOFTWARE DESIGN:
    //    - Design Patterns
    //      • Data Transfer Object (DTO) Pattern
    //      • Separation of Concerns - Tách dữ liệu và logic
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ThongTinGiangVien là DTO chứa THÔNG TIN GIẢNG VIÊN:
    // - LƯU TRỮ: Tất cả thuộc tính của 1 giảng viên
    // - TRUYỀN DỮ LIỆU: Giữa UI Layer ↔ BLL Layer ↔ DAL Layer
    // - KHÔNG CHỨA LOGIC: Chỉ có properties, không có methods xử lý
    // - ENCAPSULATION: Đóng gói dữ liệu liên quan đến giảng viên
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như PHIẾU THÔNG TIN CÁ NHÂN của giảng viên:
    // - Có 16 ô thông tin: Mã GV, Họ tên, Ngày sinh, CCCD,...
    // - Chỉ ghi thông tin, KHÔNG có hướng dẫn xử lý
    // - Dùng để chuyển giữa các phòng ban (Nhân sự, Đào tạo,...)
    // - Giống form đăng ký thông tin giảng viên mới
    //
    // 📊 CẤU TRÚC DỮ LIỆU:
    //
    // ThongTinGiangVien {
    //     ID: int                    → ID tự động (database)
    //     MaGV: string              → Mã giảng viên (GV001, GV002,...)
    //     HoGV: string              → Họ
    //     TenLotGV: string          → Tên lót
    //     TenGV: string             → Tên
    //     NgaySinhGV: DateTime      → Ngày sinh
    //     GioiTinhGV: string        → Nam/Nữ
    //     CCCDGV: string            → Căn cước công dân (12 số)
    //     DiaChiGV: string          → Địa chỉ
    //     EmailGV: string           → Email (@university.edu.vn)
    //     SDTGV: string             → Số điện thoại (10 số)
    //     KhoaGV: string            → Khoa (CNTT, Kinh tế, Luật,...)
    //     ChuyenNganhGV: string     → Chuyên ngành
    //     HocViGV: string           → Cử nhân, Thạc sĩ, Tiến sĩ, Giáo sư
    //     TrangThaiGV: string       → Đang làm việc, Nghỉ việc, Nghỉ hưu
    //     HinhAnhGV: string         → Đường dẫn file ảnh
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    DTO (Data Transfer Object) là gì?
    - Object dùng để CHUYỂN DỮ LIỆU giữa các lớp
    - Chỉ chứa PROPERTIES (thuộc tính), KHÔNG chứa logic
    - Giống như "phiếu thông tin" giảng viên

    Tại sao cần DTO?
    - Tách biệt dữ liệu và logic (Separation of Concerns)
    - Dễ truyền dữ liệu giữa các form
    - Dễ lưu vào database
    - Dễ bảo trì và mở rộng

    So sánh với Sinh viên:
    - ThongTinSinhVien: 12 properties (dành cho sinh viên)
    - ThongTinGiangVien: 16 properties (nhiều hơn - thêm SDT, Khoa, Chuyên ngành, Học vị)
    - Giảng viên cần nhiều thông tin hơn để quản lý

    Auto-implemented Properties là gì?
    - { get; set; } = Compiler tự tạo getter và setter
    - VD: public string MaGV { get; set; } = "";
    - Tương đương với:
      private string _maGV = "";
      public string MaGV {
          get { return _maGV; }
          set { _maGV = value; }
      }
    */
    public class ThongTinGiangVien
    {
        // ===== THUỘC TÍNH ID =====
        public int ID { get; set; }

        // ===== THUỘC TÍNH MÃ GIẢNG VIÊN =====
        public string MaGV { get; set; } = "";

        // ===== THUỘC TÍNH HỌ =====
        public string HoGV { get; set; } = "";

        // ===== THUỘC TÍNH TÊN LÓT =====
        public string TenLotGV { get; set; } = "";

        // ===== THUỘC TÍNH TÊN =====
        public string TenGV { get; set; } = "";

        // ===== THUỘC TÍNH NGÀY SINH =====
        public DateTime NgaySinhGV { get; set; }

        // ===== THUỘC TÍNH GIỚI TÍNH =====
        public string GioiTinhGV { get; set; } = "";

        // ===== THUỘC TÍNH CCCD =====
        public string CCCDGV { get; set; } = "";

        // ===== THUỘC TÍNH ĐỊA CHỈ =====
        public string DiaChiGV { get; set; } = "";

        // ===== THUỘC TÍNH EMAIL =====
        public string EmailGV { get; set; } = "";

        // ===== THUỘC TÍNH SỐ ĐIỆN THOẠI =====
        public string SDTGV { get; set; } = "";

        // ===== THUỘC TÍNH KHOA =====
        public string KhoaGV { get; set; } = "";

        // ===== THUỘC TÍNH CHUYÊN NGÀNH =====
        public string ChuyenNganhGV { get; set; } = "";

        // ===== THUỘC TÍNH HỌC VỊ =====
        // VD: Cử nhân, Thạc sĩ, Tiến sĩ, Giáo sư
        public string HocViGV { get; set; } = "";

        // ===== THUỘC TÍNH TRẠNG THÁI =====
        // VD: Đang làm việc, Nghỉ việc, Nghỉ hưu
        public string TrangThaiGV { get; set; } = "";

        // ===== THUỘC TÍNH HÌNH ẢNH =====
        public string HinhAnhGV { get; set; } = "";
    }
}
