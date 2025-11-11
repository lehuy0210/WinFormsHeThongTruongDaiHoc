using System;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== DATA TRANSFER OBJECT - THÔNG TIN XÉT THI ĐUA ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING: Classes, Properties, Polymorphism
    // 2️⃣ DATA MODELING: Multi-purpose entity design
    // 3️⃣ BUSINESS RULES: Emulation criteria for students and teachers
    //
    // 💡 MỤC ĐÍCH:
    // Class này quản lý thông tin xét thi đua cho 2 đối tượng:
    // 1. SINH VIÊN: Điểm rèn luyện (100 điểm)
    //    - Ý thức học tập (20đ)
    //    - Tham gia hoạt động (30đ)
    //    - Ý thức công dân (20đ)
    //    - Quan hệ cộng đồng (20đ)
    //    - Vi phạm kỷ luật (-10đ/lần)
    //
    // 2. GIẢNG VIÊN: Đánh giá giảng dạy
    //    - Năng lực chuyên môn (30đ)
    //    - Phương pháp giảng dạy (30đ)
    //    - Thái độ với sinh viên (20đ)
    //    - Nghiên cứu khoa học (20đ)

    public class ThongTinXetThiDua
    {
        // ==================== THÔNG TIN CHUNG ====================

        public int ID { get; set; }

        // Loại đối tượng: "Sinh viên" hoặc "Giảng viên"
        public string LoaiDoiTuong { get; set; } = "";

        // Mã đối tượng (mã SV hoặc mã GV)
        // VD: "SV2024001" hoặc "GV001"
        public string MaDoiTuong { get; set; } = "";

        // Họ tên
        public string HoTen { get; set; } = "";

        // Khoa
        public string Khoa { get; set; } = "";

        // Học kỳ/năm học đánh giá
        // VD: "HK1 2023-2024", "Năm học 2023-2024"
        public string HocKy { get; set; } = "";

        // ==================== ĐIỂM RÈN LUYỆN SINH VIÊN (100 điểm) ====================

        // Ý thức học tập (0-20 điểm)
        // - Tham gia đầy đủ lớp học
        // - Hoàn thành bài tập đúng hạn
        // - Thi đạt kết quả tốt
        public int DiemYThucHocTap { get; set; }

        // Tham gia hoạt động (0-30 điểm)
        // - Tham gia CLB, đội nhóm
        // - Tham gia tình nguyện, công ích
        // - Tham gia các cuộc thi, sự kiện
        public int DiemThamGiaHoatDong { get; set; }

        // Ý thức công dân (0-20 điểm)
        // - Chấp hành nội quy, quy định
        // - Tôn trọng thầy cô, bạn bè
        // - Giữ gìn vệ sinh, tài sản chung
        public int DiemYThucCongDan { get; set; }

        // Quan hệ cộng đồng (0-20 điểm)
        // - Hòa đồng, giúp đỡ bạn bè
        // - Tham gia hoạt động tập thể
        // - Đóng góp cho cộng đồng
        public int DiemQuanHeCongDong { get; set; }

        // Số lần vi phạm kỷ luật (trừ 10đ/lần)
        public int SoLanViPham { get; set; }

        // ==================== ĐÁNH GIÁ GIẢNG VIÊN (100 điểm) ====================

        // Năng lực chuyên môn (0-30 điểm)
        // - Kiến thức sâu rộng
        // - Cập nhật kiến thức mới
        // - Trả lời thắc mắc tốt
        public int DiemNangLucChuyenMon { get; set; }

        // Phương pháp giảng dạy (0-30 điểm)
        // - Giảng bài dễ hiểu
        // - Sử dụng phương tiện hỗ trợ hiệu quả
        // - Kích thích tư duy, sáng tạo
        public int DiemPhuongPhapGiangDay { get; set; }

        // Thái độ với sinh viên (0-20 điểm)
        // - Nhiệt tình, tận tâm
        // - Lắng nghe, hỗ trợ sinh viên
        // - Công bằng trong đánh giá
        public int DiemThaiDoVoiSinhVien { get; set; }

        // Nghiên cứu khoa học (0-20 điểm)
        // - Số bài báo công bố
        // - Tham gia đề tài nghiên cứu
        // - Hướng dẫn nghiên cứu sinh viên
        public int DiemNghienCuuKhoaHoc { get; set; }

        // ==================== KẾT QUẢ ĐÁNH GIÁ ====================

        // Tổng điểm (0-100)
        // - Sinh viên: DiemYThucHocTap + DiemThamGiaHoatDong + DiemYThucCongDan + DiemQuanHeCongDong - (SoLanViPham * 10)
        // - Giảng viên: DiemNangLucChuyenMon + DiemPhuongPhapGiangDay + DiemThaiDoVoiSinhVien + DiemNghienCuuKhoaHoc
        public int TongDiem { get; set; }

        // Xếp loại thi đua
        // - 90-100: Xuất sắc
        // - 80-89: Tốt
        // - 65-79: Khá
        // - 50-64: Trung bình
        // - < 50: Yếu
        public string XepLoaiThiDua { get; set; } = "";

        // Danh hiệu thi đua
        // Sinh viên: "Sinh viên 5 tốt", "Sinh viên tiên tiến", "Sinh viên xuất sắc"
        // Giảng viên: "Chiến sĩ thi đua cơ sở", "Chiến sĩ thi đua cấp trên", "Giảng viên xuất sắc"
        public string DanhHieuThiDua { get; set; } = "";

        // Ngày đánh giá
        public DateTime NgayDanhGia { get; set; }

        // Người đánh giá (tên cố vấn học tập, trưởng khoa, ...)
        public string NguoiDanhGia { get; set; } = "";

        // Ghi chú
        public string GhiChu { get; set; } = "";

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 PHÂN TÍCH BÀI TOÁN XÉT THI ĐUA:
        //
        // 1. SINH VIÊN - ĐIỂM RÈN LUYỆN:
        //
        // INPUT:
        // - Điểm ý thức học tập (0-20)
        // - Điểm tham gia hoạt động (0-30)
        // - Điểm ý thức công dân (0-20)
        // - Điểm quan hệ cộng đồng (0-20)
        // - Số lần vi phạm
        //
        // PROCESSING:
        // TongDiem = DiemYThucHocTap + DiemThamGiaHoatDong +
        //            DiemYThucCongDan + DiemQuanHeCongDong - (SoLanViPham * 10)
        //
        // if (TongDiem >= 90) → "Xuất sắc", DanhHieu = "Sinh viên 5 tốt"
        // else if (TongDiem >= 80) → "Tốt", DanhHieu = "Sinh viên tiên tiến"
        // else if (TongDiem >= 65) → "Khá"
        // else if (TongDiem >= 50) → "Trung bình"
        // else → "Yếu"
        //
        // OUTPUT:
        // - TongDiem (0-100)
        // - XepLoaiThiDua
        // - DanhHieuThiDua
        //
        // 2. GIẢNG VIÊN - ĐÁNH GIÁ GIẢNG DẠY:
        //
        // INPUT:
        // - Điểm năng lực chuyên môn (0-30)
        // - Điểm phương pháp giảng dạy (0-30)
        // - Điểm thái độ với sinh viên (0-20)
        // - Điểm nghiên cứu khoa học (0-20)
        //
        // PROCESSING:
        // TongDiem = DiemNangLucChuyenMon + DiemPhuongPhapGiangDay +
        //            DiemThaiDoVoiSinhVien + DiemNghienCuuKhoaHoc
        //
        // if (TongDiem >= 90) → "Xuất sắc", DanhHieu = "Chiến sĩ thi đua cấp trên"
        // else if (TongDiem >= 80) → "Tốt", DanhHieu = "Chiến sĩ thi đua cơ sở"
        // else if (TongDiem >= 65) → "Khá", DanhHieu = "Giảng viên tiên tiến"
        // else if (TongDiem >= 50) → "Trung bình"
        // else → "Yếu"
        //
        // 📊 VÍ DỤ:
        //
        // SINH VIÊN A:
        // - DiemYThucHocTap = 18
        // - DiemThamGiaHoatDong = 28
        // - DiemYThucCongDan = 19
        // - DiemQuanHeCongDong = 18
        // - SoLanViPham = 0
        // → TongDiem = 18 + 28 + 19 + 18 - 0 = 83
        // → XepLoaiThiDua = "Tốt"
        // → DanhHieuThiDua = "Sinh viên tiên tiến"
        //
        // GIẢNG VIÊN B:
        // - DiemNangLucChuyenMon = 28
        // - DiemPhuongPhapGiangDay = 27
        // - DiemThaiDoVoiSinhVien = 19
        // - DiemNghienCuuKhoaHoc = 18
        // → TongDiem = 28 + 27 + 19 + 18 = 92
        // → XepLoaiThiDua = "Xuất sắc"
        // → DanhHieuThiDua = "Chiến sĩ thi đua cấp trên"
    }
}
