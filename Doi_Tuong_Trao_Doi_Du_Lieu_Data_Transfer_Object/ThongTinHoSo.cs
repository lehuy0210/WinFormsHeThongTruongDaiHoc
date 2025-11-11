using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN HỒ SƠ (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class ThongTinHoSo
    //      • 2.1.2: Properties - Các thuộc tính hồ sơ
    //      • 2.1.2.1: Auto-implemented Properties - { get; set; }
    //      • 2.2: Object - Tạo instance hồ sơ
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
    // ThongTinHoSo là DTO chứa THÔNG TIN HỒ SƠ (Tuyển sinh & Nhân sự):
    // - LƯU TRỮ: Tất cả thuộc tính của 1 hồ sơ
    // - TRUYỀN DỮ LIỆU: Giữa UI Layer ↔ BLL Layer ↔ DAL Layer
    // - KHÔNG CHỨA LOGIC: Chỉ có properties, không có methods xử lý
    // - ĐA NĂNG: Dùng cho cả hồ sơ tuyển sinh và nhân sự
    //
    // 💡 VÍ DỤ THỰC TẾ:
    //
    // ** HỒ SƠ TUYỂN SINH **
    // Giống như HỒ SƠ XÉT TUYỂN đại học:
    // - Mã hồ sơ: HS-TS-2024-001
    // - Loại: Tuyển sinh
    // - Thí sinh: TS001 - Nguyễn Văn An
    // - Ngày nộp: 15/06/2024
    // - Trạng thái: Đầy đủ
    // - Giấy tờ: Bản sao CMND, Bằng TN THPT, Giấy khai sinh
    // - Người xử lý: Phòng Tuyển sinh
    //
    // ** HỒ SƠ NHÂN SỰ **
    // Giống như HỒ SƠ TUYỂN DỤNG:
    // - Mã hồ sơ: HS-NS-2024-001
    // - Loại: Nhân sự
    // - Ứng viên: CB001 - Trần Thị Bình
    // - Ngày nộp: 01/07/2024
    // - Trạng thái: Đã duyệt
    // - Giấy tờ: CV, Bằng cấp, Chứng chỉ ngoại ngữ
    // - Người xử lý: Phòng Nhân sự
    //
    // 📊 CẤU TRÚC DỮ LIỆU:
    //
    // ThongTinHoSo {
    //     ID: int                      → ID tự động (database)
    //     MaHoSo: string              → HS-TS-2024-001, HS-NS-2024-001
    //     LoaiHoSo: string            → Tuyển sinh, Nhân sự, Khen thưởng
    //     MaDoiTuong: string          → TS001 (thí sinh) hoặc CB001 (cán bộ)
    //     TenDoiTuong: string         → Nguyễn Văn An
    //     NgayNop: DateTime           → Ngày nộp hồ sơ
    //     TrangThai: string           → Đầy đủ, Thiếu giấy tờ, Đã duyệt, Từ chối
    //     DanhSachGiayTo: string      → Danh sách giấy tờ (ngăn cách bởi ;)
    //     FileDinhKem: string         → Đường dẫn file PDF/Image
    //     NguoiXuLy: string           → Tên nhân viên xử lý
    //     NgayXuLy: DateTime          → Ngày xử lý
    //     KetQuaXuLy: string          → Đạt, Không đạt, Chờ bổ sung
    //     GhiChu: string              → Ghi chú bổ sung
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Tại sao kết hợp 2 loại hồ sơ?
    - Cấu trúc giống nhau: Mã, Ngày nộp, Trạng thái, Giấy tờ, Người xử lý
    - Tái sử dụng code: Không cần tạo 2 class riêng
    - Dễ mở rộng: Thêm loại hồ sơ mới (Khen thưởng, Kỷ luật) chỉ cần thêm giá trị LoaiHoSo
    - Quản lý tập trung: 1 form quản lý tất cả loại hồ sơ

    LoaiHoSo có những giá trị gì?
    - "Tuyển sinh": Hồ sơ xét tuyển sinh viên mới
    - "Nhân sự": Hồ sơ tuyển dụng, thăng tiến, nghỉ việc
    - "Khen thưởng": Hồ sơ khen thưởng, giấy khen
    - "Kỷ luật": Hồ sơ kỷ luật sinh viên/cán bộ

    TrangThai của hồ sơ:
    - "Đầy đủ": Đã có đủ giấy tờ
    - "Thiếu giấy tờ": Cần bổ sung thêm
    - "Đã duyệt": Đã được phê duyệt
    - "Từ chối": Không đạt yêu cầu
    - "Chờ xử lý": Chưa được xem xét

    DanhSachGiayTo format:
    - Chuỗi ngăn cách bởi dấu chấm phẩy (;)
    - VD: "Bản sao CMND;Bằng TN THPT;Giấy khai sinh;Học bạ"
    - Khi hiển thị: Split bởi ';' thành List<string>

    FileDinhKem:
    - Đường dẫn đến file scan/photo hồ sơ
    - Format: PDF (tốt nhất), JPG, PNG
    - VD: "D:\HoSo\TS2024\HS-TS-2024-001.pdf"
    - Có thể lưu nhiều file bằng cách ngăn cách: "file1.pdf;file2.jpg"

    Workflow xử lý hồ sơ:
    1. Tiếp nhận: TrangThai = "Chờ xử lý"
    2. Kiểm tra: TrangThai = "Đầy đủ" hoặc "Thiếu giấy tờ"
    3. Xử lý: NguoiXuLy điền tên, NgayXuLy ghi ngày
    4. Kết quả: TrangThai = "Đã duyệt" hoặc "Từ chối"
    */
    public class ThongTinHoSo
    {
        // ===== THUỘC TÍNH ID =====
        // ID tự động tăng trong database
        public int ID { get; set; }

        // ===== THUỘC TÍNH MÃ HỒ SƠ =====
        // Format: HS-[LoaiHS]-[Nam]-[SoThuTu]
        // VD: HS-TS-2024-001 (Hồ sơ tuyển sinh 2024 số 1)
        public string MaHoSo { get; set; } = "";

        // ===== THUỘC TÍNH LOẠI HỒ SƠ =====
        // Tuyển sinh, Nhân sự, Khen thưởng, Kỷ luật
        public string LoaiHoSo { get; set; } = "";

        // ===== THUỘC TÍNH MÃ ĐỐI TƯỢNG =====
        // Mã thí sinh (TS001) hoặc Mã cán bộ (CB001)
        public string MaDoiTuong { get; set; } = "";

        // ===== THUỘC TÍNH TÊN ĐỐI TƯỢNG =====
        // Tên thí sinh hoặc cán bộ
        public string TenDoiTuong { get; set; } = "";

        // ===== THUỘC TÍNH NGÀY NỘP =====
        // Ngày nộp hồ sơ
        public DateTime NgayNop { get; set; }

        // ===== THUỘC TÍNH TRẠNG THÁI =====
        // Đầy đủ, Thiếu giấy tờ, Đã duyệt, Từ chối, Chờ xử lý
        public string TrangThai { get; set; } = "";

        // ===== THUỘC TÍNH DANH SÁCH GIẤY TỜ =====
        // Danh sách giấy tờ ngăn cách bởi dấu ;
        // VD: "Bản sao CMND;Bằng TN THPT;Giấy khai sinh"
        public string DanhSachGiayTo { get; set; } = "";

        // ===== THUỘC TÍNH FILE ĐÍNH KÈM =====
        // Đường dẫn đến file scan hồ sơ (PDF, JPG, PNG)
        public string FileDinhKem { get; set; } = "";

        // ===== THUỘC TÍNH NGƯỜI XỬ LÝ =====
        // Tên nhân viên xử lý hồ sơ
        public string NguoiXuLy { get; set; } = "";

        // ===== THUỘC TÍNH NGÀY XỬ LÝ =====
        // Ngày xử lý hồ sơ
        public DateTime NgayXuLy { get; set; }

        // ===== THUỘC TÍNH KẾT QUẢ XỬ LÝ =====
        // Đạt, Không đạt, Chờ bổ sung
        public string KetQuaXuLy { get; set; } = "";

        // ===== THUỘC TÍNH GHI CHÚ =====
        // Ghi chú bổ sung
        public string GhiChu { get; set; } = "";

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================

        1. ĐA NĂNG (Polymorphism ý tưởng):
           - 1 class cho nhiều loại hồ sơ
           - Phân biệt bằng property LoaiHoSo
           - Tiết kiệm code, dễ bảo trì

        2. WORKFLOW HỒ SƠ:
           Nộp → Kiểm tra → Xử lý → Kết quả

        3. FILE ĐÍNH KÈM:
           - Lưu đường dẫn (path) thay vì binary
           - Dễ quản lý, dễ mở file

        4. TRẠNG THÁI:
           - Theo dõi tiến trình xử lý
           - Đầy đủ → Đã duyệt (OK)
           - Thiếu → Chờ bổ sung → Đầy đủ → Đã duyệt

        5. SO SÁNH VỚI SINH VIÊN:
           - ThongTinSinhVien: Thông tin cá nhân (tĩnh)
           - ThongTinHoSo: Thông tin quy trình (động)
           - SV có nhiều hồ sơ (tuyển sinh, khen thưởng,...)

        ==================== END TÓM TẮT ====================
        */
    }
}
