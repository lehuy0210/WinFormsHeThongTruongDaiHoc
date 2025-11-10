using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN LỚP HỌC (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects - Định nghĩa class ThongTinLopHoc
    //    - Chapter 2.1.2: Properties - Thuộc tính lớp học
    //
    // 2️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: DTO Pattern - Truyền thông tin lớp học
    //
    // 3️⃣ DATA STRUCTURES:
    //    - Composite Data - Kết hợp nhiều thông tin (Môn học + Giảng viên + Thời khóa biểu)
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ThongTinLopHoc chứa THÔNG TIN LỚP HỌC:
    // - LỚP HỌC = MÔN HỌC + GIẢNG VIÊN + THỜI KHÓA BIỂU + SĨ SỐ
    // - QUẢN LÝ: Lịch học, phòng học, thời gian
    // - KIỂM SOÁT: Sĩ số tối đa, sĩ số hiện tại
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như THÔNG TIN ĐĂNG KÝ LỚP HỌC:
    // - Lớp: CNTT101_01 - Lập trình C# (Lớp 1)
    // - Giảng viên: GV001 - TS. Nguyễn Văn An
    // - Thời gian: Thứ 2, tiết 1-3
    // - Phòng: A101
    // - Học kỳ 1, năm 2024-2025
    // - Sĩ số: 35/40 (còn 5 chỗ trống)
    //
    // 📊 CẤU TRÚC DỮ LIỆU:
    //
    // ThongTinLopHoc {
    //     ID: int                    → ID tự động
    //     MaLopHoc: string          → CNTT101_01, TOAN201_02
    //     TenLopHoc: string         → Lập trình C# - Lớp 1
    //     MaMonHoc: string          → CNTT101
    //     TenMonHoc: string         → Lập trình C#
    //     MaGiangVien: string       → GV001
    //     TenGiangVien: string      → TS. Nguyễn Văn An
    //     HocKy: int                → 1, 2, 3
    //     NamHoc: string            → 2024-2025
    //     PhongHoc: string          → A101, B205, Lab CNTT
    //     Thu: string               → 2, 3, 4, 5, 6, 7, CN
    //     TietBatDau: int           → 1, 4, 7, 10
    //     TietKetThuc: int          → 3, 6, 9, 12
    //     SiSoToiDa: int            → 40, 50 (tùy phòng học)
    //     SiSoHienTai: int          → 35 (số SV đã đăng ký)
    //     GhiChu: string            → Mang laptop, chuẩn bị bài trước
    // }
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Lớp học khác với Lớp hành chính như thế nào?
    - Lớp hành chính: 22IT1, 22KT2 (theo khóa, cố định 4 năm)
    - Lớp học: CNTT101_01 (theo môn học, thay đổi mỗi học kỳ)
    - 1 lớp hành chính có thể chia thành nhiều lớp học (CNTT101_01, CNTT101_02,...)

    Tại sao lưu cả Mã và Tên?
    - MaMonHoc: CNTT101 (khóa chính để liên kết)
    - TenMonHoc: "Lập trình C#" (hiển thị cho người dùng)
    - Denormalization: Tăng tốc truy vấn, giảm JOIN

    Tiết học:
    - 1 ngày có 12 tiết (sáng: 1-6, chiều: 7-12)
    - TietBatDau=1, TietKetThuc=3 → Tiết 1,2,3 (3 tiết liên tiếp)
    - VD: 7h00-9h25 (mỗi tiết 45 phút + nghỉ 5 phút)

    Sĩ số:
    - SiSoToiDa: Phụ thuộc phòng học (40, 50, 100)
    - SiSoHienTai: Số SV đã đăng ký
    - Còn chỗ = SiSoToiDa - SiSoHienTai
    - Nếu full → không cho đăng ký thêm
    */
    public class ThongTinLopHoc
    {
        public int ID { get; set; }

        // Mã lớp học (VD: CNTT1_2024)
        public string MaLopHoc { get; set; } = "";

        // Tên lớp học
        public string TenLopHoc { get; set; } = "";

        // Mã môn học
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Mã giảng viên
        public string MaGiangVien { get; set; } = "";

        // Tên giảng viên
        public string TenGiangVien { get; set; } = "";

        // Học kỳ
        public int HocKy { get; set; }

        // Năm học
        public string NamHoc { get; set; } = "";

        // Phòng học
        public string PhongHoc { get; set; } = "";

        // Thứ trong tuần (2-7, CN)
        public string Thu { get; set; } = "";

        // Tiết bắt đầu
        public int TietBatDau { get; set; }

        // Tiết kết thúc
        public int TietKetThuc { get; set; }

        // Sĩ số tối đa
        public int SiSoToiDa { get; set; }

        // Sĩ số hiện tại
        public int SiSoHienTai { get; set; }

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
