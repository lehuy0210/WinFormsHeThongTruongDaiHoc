using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN MÔN HỌC (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class ThongTinMonHoc
    //      • 2.1.2: Properties - Thuộc tính môn học
    //      • 2.1.2.1: Auto-implemented Properties
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 3: Data Types
    //      • 3.1: int - ID, SoTinChi, SoTietLyThuyet, SoTietThucHanh, HocKy
    //      • 3.2: string - MaMonHoc, TenMonHoc, Khoa, NamHoc, MoTa
    //
    // 3️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: DTO Pattern - Truyền thông tin môn học
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ThongTinMonHoc chứa THÔNG TIN MÔN HỌC:
    // - MÔ TẢ: Thông tin chi tiết về 1 môn học
    // - TÍN CHỈ: Số tín chỉ, số tiết lý thuyết, thực hành
    // - PHÂN BỔ: Khoa quản lý, học kỳ, năm học
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như MÔ TẢ MÔN HỌC trong đề cương:
    // - Mã môn: CNTT101
    // - Tên: Nhập môn lập trình
    // - Tín chỉ: 3 (45 tiết lý thuyết + 30 tiết thực hành)
    // - Khoa: Công nghệ thông tin
    // - Học kỳ 1, năm học 2024-2025
    //
    // 📊 CẤU TRÚC DỮ LIỆU:
    //
    // ThongTinMonHoc {
    //     ID: int                    → ID tự động
    //     MaMonHoc: string          → CNTT101, TOAN201
    //     TenMonHoc: string         → Lập trình C#, Toán cao cấp
    //     SoTinChi: int             → 2, 3, 4 tín chỉ
    //     SoTietLyThuyet: int       → 30, 45 tiết
    //     SoTietThucHanh: int       → 15, 30 tiết
    //     Khoa: string              → CNTT, Kinh tế, Luật
    //     HocKy: int                → 1, 2, 3 (học kỳ)
    //     NamHoc: string            → 2024-2025
    //     MoTa: string              → Mô tả nội dung môn học
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Tín chỉ là gì?
    - 1 tín chỉ = 15 tiết (1 tiết = 50 phút)
    - VD: 3 tín chỉ = 45 tiết lý thuyết + 30 tiết thực hành
    - Sinh viên cần đủ tín chỉ mới được tốt nghiệp

    Tại sao tách SoTietLyThuyet và SoTietThucHanh?
    - Lý thuyết: Giảng dạy trên lớp
    - Thực hành: Lab, bài tập thực hành
    - Một số môn chỉ lý thuyết (Triết học), một số chỉ thực hành (Thực tập)

    Khoa quản lý môn học:
    - Mỗi môn thuộc 1 khoa quản lý
    - VD: Lập trình C# → Khoa CNTT
         Toán cao cấp → Khoa Toán - Tin
         Luật kinh tế → Khoa Luật

    NamHoc format:
    - "2024-2025" (năm bắt đầu - năm kết thúc)
    - Một năm học có 3 học kỳ (HK1, HK2, HK3-hè)
    */
    public class ThongTinMonHoc
    {
        public int ID { get; set; }

        // Mã môn học (VD: CNTT101, TOAN201)
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Số tín chỉ
        public int SoTinChi { get; set; }

        // Số tiết lý thuyết
        public int SoTietLyThuyet { get; set; }

        // Số tiết thực hành
        public int SoTietThucHanh { get; set; }

        // Khoa quản lý
        public string Khoa { get; set; } = "";

        // Học kỳ (1, 2, 3...)
        public int HocKy { get; set; }

        // Năm học (VD: 2024-2025)
        public string NamHoc { get; set; } = "";

        // Mô tả môn học
        public string MoTa { get; set; } = "";
    }
}
