using System;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== DATA TRANSFER OBJECT - THÔNG TIN XÉT TỐT NGHIỆP ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ OBJECT-ORIENTED PROGRAMMING: Classes, Properties, Auto-properties, Encapsulation
    // 2️⃣ DATA MODELING: Entity design, Business domain modeling
    // 3️⃣ FUNDAMENTALS OF PROGRAMMING: Data types (int, double, string, DateTime, bool)
    //
    // 📖 TÀI LIỆU THAM KHẢO:
    // Chương 3: Object-Oriented Programming - Classes and Objects
    // Chương 2: Data Types and Variables
    //
    // 💡 MỤC ĐÍCH:
    // Class này đại diện cho thông tin xét tốt nghiệp của sinh viên
    // Chứa các tiêu chí đánh giá: điểm GPA, tín chỉ, điểm rèn luyện, môn nợ
    //
    // 🎯 WORKFLOW XÉT TỐT NGHIỆP:
    // 1. Thu thập dữ liệu sinh viên (GPA, tín chỉ, điểm rèn luyện)
    // 2. Kiểm tra điều kiện tốt nghiệp:
    //    - Đủ tín chỉ yêu cầu (120 tín chỉ cho cử nhân)
    //    - GPA >= 2.0 (thang điểm 4.0)
    //    - Điểm rèn luyện >= 50/100
    //    - Không còn môn nợ
    //    - TOEIC >= 450 (hoặc tương đương)
    //    - Hoàn thành khóa luận/thực tập
    // 3. Phân loại tốt nghiệp: Xuất sắc, Giỏi, Khá, Trung bình
    // 4. Cấp bằng tốt nghiệp

    public class ThongTinXetTotNghiep
    {
        // ==================== THÔNG TIN SINH VIÊN ====================

        // ID tự động tăng trong database (Primary Key)
        public int ID { get; set; }

        // Mã sinh viên (Foreign Key liên kết với bảng ThongTinSinhVien)
        // VD: "SV2024001", "SV2024002"
        public string MaSinhVien { get; set; } = "";

        // Họ tên sinh viên
        public string HoTen { get; set; } = "";

        // Khoa sinh viên thuộc về
        // VD: "Khoa CNTT", "Khoa Kinh tế"
        public string Khoa { get; set; } = "";

        // Ngành học
        // VD: "Công nghệ thông tin", "Kế toán"
        public string Nganh { get; set; } = "";

        // Khóa học (năm nhập học - năm tốt nghiệp)
        // VD: "2020-2024", "2021-2025"
        public string KhoaHoc { get; set; } = "";

        // ==================== ĐIỀU KIỆN TỐT NGHIỆP ====================

        // Tổng số tín chỉ tích lũy (phải >= 120 cho cử nhân)
        // 📝 GIẢI THÍCH:
        // - 1 tín chỉ = 15 tiết lý thuyết hoặc 30-45 tiết thực hành
        // - Cử nhân: 120-140 tín chỉ
        // - Thạc sĩ: 60 tín chỉ
        // - Tiến sĩ: 90 tín chỉ
        public int TongTinChiTichLuy { get; set; }

        // Điểm trung bình tích lũy (GPA - Grade Point Average)
        // Thang điểm 4.0:
        // - 3.6 - 4.0: Xuất sắc
        // - 3.2 - 3.59: Giỏi
        // - 2.5 - 3.19: Khá
        // - 2.0 - 2.49: Trung bình
        // - < 2.0: Không đủ điều kiện tốt nghiệp
        public double DiemTrungBinhTichLuy { get; set; }

        // Điểm rèn luyện (thang điểm 100)
        // 📝 GIẢI THÍCH:
        // - 90-100: Xuất sắc
        // - 80-89: Tốt
        // - 65-79: Khá
        // - 50-64: Trung bình
        // - < 50: Yếu (không đủ điều kiện tốt nghiệp)
        // Đánh giá dựa trên: ý thức học tập, tham gia hoạt động, vi phạm kỷ luật
        public int DiemRenLuyen { get; set; }

        // Số môn nợ (môn thi chưa đạt/chưa thi)
        // Phải = 0 mới được xét tốt nghiệp
        public int SoMonNo { get; set; }

        // Điểm ngoại ngữ (TOEIC hoặc tương đương)
        // Yêu cầu tối thiểu: 450 TOEIC
        public int DiemNgoaiNgu { get; set; }

        // Trạng thái khóa luận/thực tập tốt nghiệp
        // VD: "Đã hoàn thành", "Đang thực hiện", "Chưa đăng ký"
        public string TrangThaiKhoaLuan { get; set; } = "";

        // ==================== KẾT QUẢ XÉT TỐT NGHIỆP ====================

        // Điều kiện tốt nghiệp chi tiết
        // VD: "Đủ điều kiện", "Thiếu 5 tín chỉ", "GPA chưa đạt", "Còn 2 môn nợ"
        public string DieuKienTotNghiep { get; set; } = "";

        // Kết quả xét tốt nghiệp
        // VD: "Đủ điều kiện", "Không đủ điều kiện", "Tốt nghiệp có điều kiện"
        public string KetQuaXet { get; set; } = "";

        // Xếp loại tốt nghiệp (dựa trên GPA)
        // VD: "Xuất sắc", "Giỏi", "Khá", "Trung bình"
        public string XepLoaiTotNghiep { get; set; } = "";

        // Ngày xét tốt nghiệp
        public DateTime NgayXet { get; set; }

        // Học kỳ tốt nghiệp
        // VD: "HK1 2023-2024", "HK2 2023-2024"
        public string HocKyTotNghiep { get; set; } = "";

        // Ghi chú
        // VD: "Được miễn TOEIC do có chứng chỉ IELTS 6.5"
        public string GhiChu { get; set; } = "";

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 PHÂN TÍCH BÀI TOÁN XÉT TỐT NGHIỆP:
        //
        // INPUT (Dữ liệu đầu vào):
        // - Thông tin sinh viên: Mã SV, Họ tên, Khoa, Ngành, Khóa học
        // - Kết quả học tập: Tổng tín chỉ, GPA, Số môn nợ
        // - Đánh giá khác: Điểm rèn luyện, Điểm ngoại ngữ, Trạng thái khóa luận
        //
        // PROCESSING (Xử lý):
        // BƯỚC 1: Kiểm tra điều kiện bắt buộc (AND logic - tất cả phải đạt)
        //   - TongTinChiTichLuy >= 120
        //   - DiemTrungBinhTichLuy >= 2.0
        //   - DiemRenLuyen >= 50
        //   - SoMonNo == 0
        //   - DiemNgoaiNgu >= 450
        //   - TrangThaiKhoaLuan == "Đã hoàn thành"
        //
        // BƯỚC 2: Nếu tất cả điều kiện đạt → Xác định xếp loại
        //   if (GPA >= 3.6) → "Xuất sắc"
        //   else if (GPA >= 3.2) → "Giỏi"
        //   else if (GPA >= 2.5) → "Khá"
        //   else → "Trung bình"
        //
        // BƯỚC 3: Nếu có điều kiện không đạt → Liệt kê lý do
        //   - "Thiếu X tín chỉ"
        //   - "GPA chưa đạt (hiện tại: Y)"
        //   - "Còn Z môn nợ"
        //   - etc.
        //
        // OUTPUT (Kết quả):
        // - KetQuaXet: "Đủ điều kiện" / "Không đủ điều kiện" / "Có điều kiện"
        // - XepLoaiTotNghiep: "Xuất sắc" / "Giỏi" / "Khá" / "Trung bình"
        // - DieuKienTotNghiep: Thông báo chi tiết
        //
        // 📊 VÍ DỤ CỤ THỂ:
        //
        // CASE 1: Sinh viên đủ điều kiện tốt nghiệp loại Giỏi
        // - TongTinChiTichLuy = 128
        // - DiemTrungBinhTichLuy = 3.45
        // - DiemRenLuyen = 85
        // - SoMonNo = 0
        // - DiemNgoaiNgu = 550
        // - TrangThaiKhoaLuan = "Đã hoàn thành"
        // → KetQuaXet = "Đủ điều kiện"
        // → XepLoaiTotNghiep = "Giỏi"
        //
        // CASE 2: Sinh viên không đủ điều kiện
        // - TongTinChiTichLuy = 115 (thiếu 5 tín chỉ)
        // - DiemTrungBinhTichLuy = 1.95 (GPA thấp)
        // - DiemRenLuyen = 45 (yếu)
        // - SoMonNo = 2 (còn nợ 2 môn)
        // → KetQuaXet = "Không đủ điều kiện"
        // → DieuKienTotNghiep = "Thiếu 5 tín chỉ, GPA < 2.0, Điểm rèn luyện < 50, Còn 2 môn nợ"
        //
        // CASE 3: Tốt nghiệp có điều kiện
        // - Đủ tất cả điều kiện NHƯNG DiemNgoaiNgu = 400 (thiếu 50 điểm)
        // → KetQuaXet = "Tốt nghiệp có điều kiện"
        // → DieuKienTotNghiep = "Phải đạt TOEIC 450 trong vòng 1 năm"
        //
        // 🎓 Ý NGHĨA GIÁO DỤC:
        // - Xét tốt nghiệp là công việc quan trọng, quyết định sinh viên có được cấp bằng không
        // - Phải công bằng, minh bạch, tuân thủ quy chế đào tạo
        // - Hệ thống tự động giúp giảm sai sót, tăng tốc độ xử lý
        // - Sinh viên có thể tự tra cứu tiến độ tốt nghiệp
    }
}
