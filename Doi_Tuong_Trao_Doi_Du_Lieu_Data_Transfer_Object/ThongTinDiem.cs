using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN ĐIỂM (DTO) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class ThongTinDiem
    //      • 2.1.2: Properties - Thuộc tính điểm
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 3: Data Types
    //      • 3.1: float - Lưu điểm số (có phần thập phân)
    //      • 3.2: int - ID, HocKy
    //      • 3.3: string - Mã SV, môn học, điểm chữ
    //
    // 3️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.3: DTO Pattern - Truyền thông tin điểm
    //
    // 4️⃣ MATHEMATICS:
    //    - Weighted Average - Trung bình có trọng số
    //      • DiemTongKet = DiemCC*0.1 + DiemGK*0.2 + DiemTH*0.2 + DiemCK*0.5
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ThongTinDiem chứa THÔNG TIN ĐIỂM của sinh viên:
    // - ĐIỂM THÀNH PHẦN: Chuyên cần, giữa kỳ, thực hành, cuối kỳ
    // - ĐIỂM TỔNG KẾT: Tính theo trọng số (10% + 20% + 20% + 50%)
    // - ĐIỂM CHỮ: A, B+, B, C+, C, D, F
    // - KẾT QUẢ: Đạt/Không đạt (>= 4.0 là đạt)
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như PHIẾU ĐIỂM của sinh viên:
    // - Sinh viên: SV001 - Nguyễn Văn An
    // - Môn học: CNTT101 - Lập trình C#
    // - Lớp: CNTT1_2024, HK1, 2024-2025
    // - Điểm CC: 9.0, GK: 8.5, TH: 9.0, CK: 8.0
    // - Điểm tổng kết: 8.35
    // - Điểm chữ: B+
    // - Kết quả: Đạt
    //
    // 📊 CÔNG THỨC TÍNH ĐIỂM:
    //
    // DiemTongKet = DiemChuyenCan * 10%
    //             + DiemGiuaKy * 20%
    //             + DiemThucHanh * 20%
    //             + DiemCuoiKy * 50%
    //
    // VÍ DỤ: CC=9, GK=8.5, TH=9, CK=8
    // DiemTongKet = 9*0.1 + 8.5*0.2 + 9*0.2 + 8*0.5
    //             = 0.9 + 1.7 + 1.8 + 4.0
    //             = 8.4
    //
    // BẢNG QUY ĐỔI ĐIỂM CHỮ:
    // - A:  8.5 - 10.0 (Xuất sắc)
    // - B+: 7.5 - 8.4  (Giỏi)
    // - B:  7.0 - 7.4  (Khá)
    // - C+: 6.0 - 6.9  (Trung bình khá)
    // - C:  5.0 - 5.9  (Trung bình)
    // - D:  4.0 - 4.9  (Trung bình yếu - Đạt)
    // - F:  0.0 - 3.9  (Yếu - Không đạt)
    //
    // KẾT QUẢ:
    // - Đạt: DiemTongKet >= 4.0 (D trở lên)
    // - Không đạt: DiemTongKet < 4.0 (F)
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Tại sao điểm cuối kỳ chiếm 50%?
    - Cuối kỳ là bài thi tổng hợp kiến thức
    - Quan trọng nhất trong quá trình học
    - Chuyên cần chỉ 10% (khuyến khích đi học)
    - Giữa kỳ + Thực hành mỗi cái 20% (đánh giá quá trình)

    Tại sao dùng float cho điểm?
    - Điểm có thể có phần thập phân: 8.5, 7.25, 9.75
    - float: 32-bit, đủ độ chính xác cho điểm (0-10)
    - double: 64-bit, quá dư thừa cho điểm số
    - int: Chỉ lưu số nguyên (8, 9, 10) - không đủ chính xác

    Tại sao lưu cả MaSinhVien và TenSinhVien?
    - Dễ hiển thị trên DataGridView (không cần JOIN)
    - Tăng tốc độ truy vấn (denormalization)
    - Nhược điểm: Dữ liệu trùng lặp (trade-off)

    DiemTongKet có tính tự động không?
    - BLL Layer sẽ tính và gán vào property này
    - UI chỉ hiển thị, không cho sửa DiemTongKet
    - Công thức: Weighted Average (trung bình có trọng số)
    */
    public class ThongTinDiem
    {
        public int ID { get; set; }

        // Mã sinh viên
        public string MaSinhVien { get; set; } = "";

        // Tên sinh viên
        public string TenSinhVien { get; set; } = "";

        // Mã môn học
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Mã lớp học
        public string MaLopHoc { get; set; } = "";

        // Học kỳ
        public int HocKy { get; set; }

        // Năm học
        public string NamHoc { get; set; } = "";

        // Điểm chuyên cần (10%)
        public float DiemChuyenCan { get; set; }

        // Điểm kiểm tra giữa kỳ (20%)
        public float DiemGiuaKy { get; set; }

        // Điểm thực hành/bài tập (20%)
        public float DiemThucHanh { get; set; }

        // Điểm cuối kỳ (50%)
        public float DiemCuoiKy { get; set; }

        // Điểm tổng kết (tính tự động)
        public float DiemTongKet { get; set; }

        // Điểm chữ (A, B+, B, C+, C, D, F)
        public string DiemChu { get; set; } = "";

        // Kết quả (Đạt/Không đạt)
        public string KetQua { get; set; } = "";

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
