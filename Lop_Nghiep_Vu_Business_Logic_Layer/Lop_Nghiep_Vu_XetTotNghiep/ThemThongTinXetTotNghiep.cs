using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    // ==================== BUSINESS LOGIC LAYER - THÊM THÔNG TIN XÉT TỐT NGHIỆP ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ ALGORITHMS: Sequential Search O(n), Validation algorithms
    // 2️⃣ CONDITIONAL LOGIC: if-else, nested conditions, boolean operators (AND, OR)
    // 3️⃣ BUSINESS RULES: Graduation requirements, GPA classification
    // 4️⃣ STRING MANIPULATION: String concatenation, formatting
    //
    // 💡 MỤC ĐÍCH:
    // Class này thực hiện logic xét tốt nghiệp cho sinh viên
    // Kiểm tra đầy đủ các điều kiện và tự động phân loại kết quả

    public class ChucNangThemThongTinXetTotNghiep
    {
        // ==================== THÊM THÔNG TIN XÉT TỐT NGHIỆP ====================
        // 🔍 MỤC ĐÍCH: Thêm kết quả xét tốt nghiệp vào danh sách
        // 📝 INPUT: Danh sách hiện tại + Thông tin xét mới
        // 📝 OUTPUT: true nếu thêm thành công, false nếu thất bại
        public bool ThemKetQuaXet(List<ThongTinXetTotNghiep> danhSach, ThongTinXetTotNghiep ketQuaMoi)
        {
            // BƯỚC 1: Validate input
            if (danhSach == null || ketQuaMoi == null)
                return false;

            if (string.IsNullOrWhiteSpace(ketQuaMoi.MaSinhVien))
                return false;

            // BƯỚC 2: Kiểm tra trùng lặp (1 sinh viên chỉ xét 1 lần trong 1 học kỳ)
            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.MaSinhVien.ToLower() == ketQuaMoi.MaSinhVien.ToLower() &&
                    kq.HocKyTotNghiep == ketQuaMoi.HocKyTotNghiep)
                {
                    return false; // Đã xét trong học kỳ này rồi
                }
            }

            // BƯỚC 3: Tự động đánh giá điều kiện tốt nghiệp
            ketQuaMoi = DanhGiaDieuKienTotNghiep(ketQuaMoi);

            // BƯỚC 4: Thêm vào danh sách
            danhSach.Add(ketQuaMoi);
            return true;
        }

        // ==================== ĐÁNH GIÁ ĐIỀU KIỆN TỐT NGHIỆP ====================
        // 🔍 MỤC ĐÍCH: Tự động đánh giá sinh viên có đủ điều kiện tốt nghiệp không
        // 📝 THUẬT TOÁN:
        //
        // STEP 1: Kiểm tra từng điều kiện bắt buộc
        // STEP 2: Liệt kê các điều kiện chưa đạt
        // STEP 3: Xác định kết quả xét (Đủ/Không đủ/Có điều kiện)
        // STEP 4: Phân loại tốt nghiệp (Xuất sắc/Giỏi/Khá/Trung bình)
        public ThongTinXetTotNghiep DanhGiaDieuKienTotNghiep(ThongTinXetTotNghiep sv)
        {
            List<string> dieuKienChuaDat = new List<string>();

            // ==================== KIỂM TRA CÁC ĐIỀU KIỆN BẮT BUỘC ====================

            // Điều kiện 1: Tín chỉ tích lũy >= 120 (cử nhân)
            const int TIN_CHI_TOI_THIEU = 120;
            if (sv.TongTinChiTichLuy < TIN_CHI_TOI_THIEU)
            {
                int soTinChiThieu = TIN_CHI_TOI_THIEU - sv.TongTinChiTichLuy;
                dieuKienChuaDat.Add($"Thiếu {soTinChiThieu} tín chỉ (hiện có {sv.TongTinChiTichLuy}/120)");
            }

            // Điều kiện 2: GPA >= 2.0 (thang điểm 4.0)
            const double GPA_TOI_THIEU = 2.0;
            if (sv.DiemTrungBinhTichLuy < GPA_TOI_THIEU)
            {
                dieuKienChuaDat.Add($"GPA chưa đạt (hiện có {sv.DiemTrungBinhTichLuy:F2}/4.0, yêu cầu >= 2.0)");
            }

            // Điều kiện 3: Điểm rèn luyện >= 50 (thang điểm 100)
            const int DIEM_REN_LUYEN_TOI_THIEU = 50;
            if (sv.DiemRenLuyen < DIEM_REN_LUYEN_TOI_THIEU)
            {
                dieuKienChuaDat.Add($"Điểm rèn luyện yếu (hiện có {sv.DiemRenLuyen}/100, yêu cầu >= 50)");
            }

            // Điều kiện 4: Không còn môn nợ
            if (sv.SoMonNo > 0)
            {
                dieuKienChuaDat.Add($"Còn {sv.SoMonNo} môn nợ");
            }

            // Điều kiện 5: Điểm ngoại ngữ >= 450 TOEIC (hoặc tương đương)
            const int DIEM_NGOAI_NGU_TOI_THIEU = 450;
            bool duDieuKienNgoaiNgu = sv.DiemNgoaiNgu >= DIEM_NGOAI_NGU_TOI_THIEU;
            if (!duDieuKienNgoaiNgu)
            {
                int soDiemThieu = DIEM_NGOAI_NGU_TOI_THIEU - sv.DiemNgoaiNgu;
                dieuKienChuaDat.Add($"TOEIC chưa đạt (hiện có {sv.DiemNgoaiNgu}/990, yêu cầu >= 450)");
            }

            // Điều kiện 6: Hoàn thành khóa luận/thực tập
            bool daHoanThanhKhoaLuan = sv.TrangThaiKhoaLuan == "Đã hoàn thành";
            if (!daHoanThanhKhoaLuan)
            {
                dieuKienChuaDat.Add($"Khóa luận tốt nghiệp chưa hoàn thành (trạng thái: {sv.TrangThaiKhoaLuan})");
            }

            // ==================== XÁC ĐỊNH KẾT QUẢ XÉT TỐT NGHIỆP ====================

            if (dieuKienChuaDat.Count == 0)
            {
                // ✅ CASE 1: ĐỦ ĐIỀU KIỆN TỐT NGHIỆP
                sv.KetQuaXet = "Đủ điều kiện";
                sv.DieuKienTotNghiep = "Đủ tất cả điều kiện tốt nghiệp";

                // Phân loại tốt nghiệp dựa trên GPA
                sv.XepLoaiTotNghiep = XepLoaiTotNghiepTheoGPA(sv.DiemTrungBinhTichLuy);
            }
            else if (dieuKienChuaDat.Count == 1 && !duDieuKienNgoaiNgu)
            {
                // ⚠️ CASE 2: TỐT NGHIỆP CÓ ĐIỀU KIỆN (chỉ thiếu ngoại ngữ)
                sv.KetQuaXet = "Tốt nghiệp có điều kiện";
                sv.DieuKienTotNghiep = "Phải đạt TOEIC 450 trong vòng 1 năm sau tốt nghiệp";
                sv.XepLoaiTotNghiep = XepLoaiTotNghiepTheoGPA(sv.DiemTrungBinhTichLuy);
            }
            else
            {
                // ❌ CASE 3: KHÔNG ĐỦ ĐIỀU KIỆN TỐT NGHIỆP
                sv.KetQuaXet = "Không đủ điều kiện";
                sv.DieuKienTotNghiep = string.Join("; ", dieuKienChuaDat);
                sv.XepLoaiTotNghiep = "Chưa xếp loại";
            }

            // Set ngày xét
            if (sv.NgayXet == DateTime.MinValue)
            {
                sv.NgayXet = DateTime.Now;
            }

            return sv;
        }

        // ==================== PHÂN LOẠI TỐT NGHIỆP THEO GPA ====================
        // 🔍 MỤC ĐÍCH: Xác định xếp loại tốt nghiệp dựa trên GPA
        // 📝 QUY ĐỊNH:
        // - GPA >= 3.6: Xuất sắc
        // - GPA >= 3.2: Giỏi
        // - GPA >= 2.5: Khá
        // - GPA >= 2.0: Trung bình
        // - GPA < 2.0: Không đủ điều kiện
        private string XepLoaiTotNghiepTheoGPA(double gpa)
        {
            if (gpa >= 3.6)
                return "Xuất sắc";
            else if (gpa >= 3.2)
                return "Giỏi";
            else if (gpa >= 2.5)
                return "Khá";
            else if (gpa >= 2.0)
                return "Trung bình";
            else
                return "Không đủ điều kiện";
        }

        // ==================== GIẢI THÍCH THUẬT TOÁN ====================
        //
        // 🔍 THUẬT TOÁN XÉT TỐT NGHIỆP:
        //
        // INPUT:
        // - Thông tin sinh viên (GPA, tín chỉ, điểm rèn luyện, môn nợ, TOEIC, khóa luận)
        //
        // PROCESSING:
        // BƯỚC 1: Tạo danh sách rỗng: dieuKienChuaDat = []
        //
        // BƯỚC 2: Kiểm tra từng điều kiện
        //   if (TinChiTichLuy < 120)
        //       dieuKienChuaDat.Add("Thiếu X tín chỉ")
        //   if (GPA < 2.0)
        //       dieuKienChuaDat.Add("GPA chưa đạt")
        //   if (DiemRenLuyen < 50)
        //       dieuKienChuaDat.Add("Điểm rèn luyện yếu")
        //   if (SoMonNo > 0)
        //       dieuKienChuaDat.Add("Còn X môn nợ")
        //   if (TOEIC < 450)
        //       dieuKienChuaDat.Add("TOEIC chưa đạt")
        //   if (KhoaLuan != "Đã hoàn thành")
        //       dieuKienChuaDat.Add("Khóa luận chưa hoàn thành")
        //
        // BƯỚC 3: Phân loại kết quả
        //   if (dieuKienChuaDat.Count == 0)
        //       → KetQuaXet = "Đủ điều kiện"
        //       → XepLoaiTotNghiep = XepLoaiTheoGPA(gpa)
        //   else if (dieuKienChuaDat.Count == 1 && chỉ thiếu TOEIC)
        //       → KetQuaXet = "Tốt nghiệp có điều kiện"
        //       → XepLoaiTotNghiep = XepLoaiTheoGPA(gpa)
        //   else
        //       → KetQuaXet = "Không đủ điều kiện"
        //       → XepLoaiTotNghiep = "Chưa xếp loại"
        //
        // OUTPUT:
        // - KetQuaXet: Đủ điều kiện / Có điều kiện / Không đủ điều kiện
        // - XepLoaiTotNghiep: Xuất sắc / Giỏi / Khá / Trung bình
        // - DieuKienTotNghiep: Mô tả chi tiết
        //
        // 📊 ĐỘ PHỨC TẠP:
        // - Time Complexity: O(1) - Chỉ kiểm tra 6 điều kiện cố định
        // - Space Complexity: O(k) - k là số điều kiện chưa đạt (tối đa 6)
        //
        // 🎓 VÍ DỤ MINH HỌA:
        //
        // INPUT: Sinh viên A
        // - TinChiTichLuy = 128
        // - GPA = 3.65
        // - DiemRenLuyen = 85
        // - SoMonNo = 0
        // - TOEIC = 600
        // - KhoaLuan = "Đã hoàn thành"
        //
        // PROCESSING:
        // - Kiểm tra tín chỉ: 128 >= 120 ✅
        // - Kiểm tra GPA: 3.65 >= 2.0 ✅
        // - Kiểm tra điểm rèn luyện: 85 >= 50 ✅
        // - Kiểm tra môn nợ: 0 == 0 ✅
        // - Kiểm tra TOEIC: 600 >= 450 ✅
        // - Kiểm tra khóa luận: "Đã hoàn thành" ✅
        // → dieuKienChuaDat = [] (rỗng)
        //
        // OUTPUT:
        // - KetQuaXet = "Đủ điều kiện"
        // - XepLoaiTotNghiep = "Xuất sắc" (GPA 3.65 >= 3.6)
        // - DieuKienTotNghiep = "Đủ tất cả điều kiện tốt nghiệp"
    }
}
