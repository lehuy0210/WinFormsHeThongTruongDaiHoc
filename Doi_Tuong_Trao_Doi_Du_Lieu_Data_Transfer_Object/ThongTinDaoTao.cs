using System;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN ĐÀO TẠO (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class ThongTinDaoTao
    //      • 2.1.2: Properties - Các thuộc tính chương trình đào tạo
    //      • 2.1.2.1: Auto-implemented Properties - { get; set; }
    //      • 2.3: Encapsulation - Đóng gói dữ liệu
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 3: Data Types
    //      • 3.1: Built-in types - int, string
    //      • 3.2: Reference types - string
    //      • 3.3: Value types - int
    //
    // 3️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: Data Transfer Object (DTO) - Lớp truyền dữ liệu
    //      • DTO Pattern: Chuyển dữ liệu giữa các layer
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ThongTinDaoTao là DTO chứa THÔNG TIN CHƯƠNG TRÌNH ĐÀO TẠO:
    // - LƯU TRỮ: Tất cả thuộc tính của 1 chương trình đào tạo
    // - TRUYỀN DỮ LIỆU: Giữa UI Layer ↔ BLL Layer ↔ DAL Layer
    // - KHÔNG CHỨA LOGIC: Chỉ có properties, không có methods xử lý
    // - QUẢN LÝ: Chương trình đào tạo (Curriculum/Training Program)
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như ĐỀ ÁN/CHƯƠNG TRÌNH ĐÀO TẠO:
    // - Mã: CNTT2024 
    // - Tên: Cử nhân Công nghệ thông tin
    // - Bậc: Cử nhân (Bachelor)
    // - Khoa: Công nghệ thông tin
    // - Thời gian: 4 năm
    // - Tổng tín chỉ: 120 tín chỉ
    // - Năm bắt đầu: 2024
    // - Điều kiện tốt nghiệp: Hoàn thành 120 TC + Đồ án + TOEIC 450
    //
    // 📊 CẤU TRÚC DỮ LIỆU:
    //
    // ThongTinDaoTao {
    //     ID: int                      → ID tự động (database)
    //     MaChuongTrinh: string       → CNTT2024, KT2024, LUAT2024
    //     TenChuongTrinh: string      → Cử nhân CNTT, Thạc sĩ Kinh tế
    //     BacDaoTao: string           → Cử nhân, Thạc sĩ, Tiến sĩ
    //     Khoa: string                → CNTT, Kinh tế, Luật
    //     SoNamDaoTao: int            → 4, 2, 3 năm
    //     TongTinChi: int             → 120, 60, 90 tín chỉ
    //     NamBatDau: int              → 2024, 2023
    //     MoTa: string                → Mô tả chương trình
    //     DieuKienTotNghiep: string   → Điều kiện để tốt nghiệp
    //     TrangThai: string           → Đang áp dụng, Ngừng tuyển
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Chương trình Đào tạo là gì?
    - Là kế hoạch học tập cho một ngành/chuyên ngành
    - Quy định: Môn học nào, bao nhiêu tín chỉ, học kỳ nào
    - VD: Chương trình CNTT cần 120 TC, gồm 40 môn, học trong 4 năm

    Bậc Đào tạo:
    - Cử nhân (Bachelor): 4 năm, 120-140 TC
    - Thạc sĩ (Master): 2 năm, 60 TC
    - Tiến sĩ (PhD): 3-4 năm, 90 TC + Luận án

    Tại sao cần Mã Chương trình?
    - Mỗi chương trình có mã riêng: CNTT2024, KT2024
    - Năm khác nhau có thể có chương trình khác (cập nhật đề cương)
    - VD: CNTT2024 khác CNTT2020 (môn học mới, cập nhật nội dung)

    Tổng Tín chỉ:
    - Là tổng số tín chỉ sinh viên phải hoàn thành
    - VD: Cử nhân CNTT = 120 TC
      • 60 TC đại cương (Toán, Lý, Anh văn,...)
      • 50 TC chuyên ngành (Lập trình, CSDL, Mạng,...)
      • 10 TC tự chọn

    Điều kiện Tốt nghiệp:
    - Hoàn thành đủ tín chỉ
    - Điểm trung bình >= 2.0
    - Đồ án tốt nghiệp >= 5.0  
    - Chứng chỉ ngoại ngữ (TOEIC 450)
    - Không vi phạm kỷ luật

    Trạng thái:
    - "Đang áp dụng": Đang tuyển sinh, đang đào tạo
    - "Ngừng tuyển": Không tuyển mới (nhưng vẫn đào tạo SV cũ)
    - "Đã kết thúc": Không còn SV nào theo chương trình này
    */
    public class ThongTinDaoTao
    {
        // ===== THUỘC TÍNH ID =====
        // ID tự động tăng trong database
        public int ID { get; set; }

        // ===== THUỘC TÍNH MÃ CHƯƠNG TRÌNH =====
        // Mã chương trình đào tạo (VD: CNTT2024, KT2024)
        public string MaChuongTrinh { get; set; } = "";

        // ===== THUỘC TÍNH TÊN CHƯƠNG TRÌNH =====
        // Tên đầy đủ (VD: Cử nhân Công nghệ thông tin)
        public string TenChuongTrinh { get; set; } = "";

        // ===== THUỘC TÍNH BẬC ĐÀO TẠO =====
        // Cử nhân, Thạc sĩ, Tiến sĩ
        public string BacDaoTao { get; set; } = "";

        // ===== THUỘC TÍNH KHOA =====
        // Khoa quản lý chương trình
        public string Khoa { get; set; } = "";

        // ===== THUỘC TÍNH SỐ NĂM ĐÀO TẠO =====
        // Thời gian đào tạo (4, 2, 3 năm)
        public int SoNamDaoTao { get; set; }

        // ===== THUỘC TÍNH TỔNG TÍN CHỈ =====
        // Tổng số tín chỉ yêu cầu (120, 60, 90)
        public int TongTinChi { get; set; }

        // ===== THUỘC TÍNH NĂM BẮT ĐẦU =====
        // Năm bắt đầu áp dụng chương trình
        public int NamBatDau { get; set; }

        // ===== THUỘC TÍNH MÔ TẢ =====
        // Mô tả ngắn về chương trình
        public string MoTa { get; set; } = "";

        // ===== THUỘC TÍNH ĐIỀU KIỆN TốT NGHIỆP =====
        // Các điều kiện để được cấp bằng
        public string DieuKienTotNghiep { get; set; } = "";

        // ===== THUỘC TÍNH TRẠNG THÁI =====
        // Đang áp dụng, Ngừng tuyển, Đã kết thúc
        public string TrangThai { get; set; } = "";

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================

        1. DTO THUẦN TÚY:
           - Chỉ chứa properties (11 thuộc tính)
           - Không có methods xử lý
           - Dùng để truyền dữ liệu

        2. AUTO-PROPERTIES:
           - { get; set; } tự động tạo getter/setter
           - Khởi tạo mặc định = "" cho string

        3. SO SÁNH:
           - ThongTinSinhVien: Thông tin CÁ NHÂN sinh viên
           - ThongTinDaoTao: Thông tin CHƯƠNG TRÌNH đào tạo
           - 1 chương trình có nhiều sinh viên

        4. QUAN HỆ:
           - 1 Khoa → Nhiều Chương trình đào tạo
           - 1 Chương trình → Nhiều Sinh viên
           - 1 Chương trình → Nhiều Môn học

        5. KIẾN TRÚC:
           - DTO Layer: ThongTinDaoTao (data)
           - BLL Layer: Validation, Business rules
           - DAL Layer: Database operations
           - UI Layer: FormQuanLyDaoTao (hiển thị)

        ==================== END TÓM TẮT ====================
        */
    }
}
