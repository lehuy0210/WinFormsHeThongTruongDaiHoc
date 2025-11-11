using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export
{
    // ==================== BUSINESS LOGIC LAYER - XUẤT DỮ LIỆU SANG CSV ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ FILE I/O: Writing text files, File streams, StreamWriter
    // 2️⃣ STRING MANIPULATION: StringBuilder, String concatenation, Escape characters
    // 3️⃣ DATA FORMATTING: CSV format (Comma-Separated Values)
    // 4️⃣ CHARACTER ENCODING: UTF-8, BOM (Byte Order Mark)
    //
    // 💡 MỤC ĐÍCH:
    // Xuất dữ liệu từ danh sách objects sang file CSV (Excel có thể mở được)
    // Không sử dụng thư viện bên ngoài, tự implement CSV writer
    //
    // 📖 CSV FORMAT:
    // Header1,Header2,Header3
    // Value1,"Value with, comma",Value3
    // "Value with ""quotes""",Value2,Value3

    public class ChucNangXuatCSV
    {
        // ==================== XUẤT SINH VIÊN SANG CSV ====================
        public bool XuatDanhSachSinhVien(List<ThongTinSinhVien> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder csv = new StringBuilder();

                // BƯỚC 1: Tạo header row (UTF-8 BOM để Excel hiển thị tiếng Việt đúng)
                csv.Append("\uFEFF"); // UTF-8 BOM
                csv.AppendLine("Mã SV,Họ tên,Ngày sinh,Giới tính,Địa chỉ,SĐT,Email,Khoa,Ngành,Khóa học");

                // BƯỚC 2: Thêm data rows
                foreach (ThongTinSinhVien sv in danhSach)
                {
                    csv.Append(EscapeCSV(sv.MaSinhVien));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.HoTen));
                    csv.Append(",");
                    csv.Append(sv.NgaySinh.ToString("dd/MM/yyyy"));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.GioiTinh));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.DiaChi));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.SoDienThoai));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.Email));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.Khoa));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.Nganh));
                    csv.Append(",");
                    csv.Append(EscapeCSV(sv.KhoaHoc));
                    csv.AppendLine();
                }

                // BƯỚC 3: Ghi vào file
                System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT XÉT TỐT NGHIỆP SANG CSV ====================
        public bool XuatDanhSachXetTotNghiep(List<ThongTinXetTotNghiep> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder csv = new StringBuilder();
                csv.Append("\uFEFF");
                csv.AppendLine("Mã SV,Họ tên,Khoa,Ngành,Khóa học,Tín chỉ,GPA,Điểm RL,Môn nợ,TOEIC,Khóa luận,Kết quả,Xếp loại,Học kỳ TN");

                foreach (ThongTinXetTotNghiep xtn in danhSach)
                {
                    csv.Append(EscapeCSV(xtn.MaSinhVien));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.HoTen));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.Khoa));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.Nganh));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.KhoaHoc));
                    csv.Append(",");
                    csv.Append(xtn.TongTinChiTichLuy.ToString());
                    csv.Append(",");
                    csv.Append(xtn.DiemTrungBinhTichLuy.ToString("F2"));
                    csv.Append(",");
                    csv.Append(xtn.DiemRenLuyen.ToString());
                    csv.Append(",");
                    csv.Append(xtn.SoMonNo.ToString());
                    csv.Append(",");
                    csv.Append(xtn.DiemNgoaiNgu.ToString());
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.TrangThaiKhoaLuan));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.KetQuaXet));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.XepLoaiTotNghiep));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtn.HocKyTotNghiep));
                    csv.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT XÉT THI ĐUA SANG CSV ====================
        public bool XuatDanhSachXetThiDua(List<ThongTinXetThiDua> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder csv = new StringBuilder();
                csv.Append("\uFEFF");
                csv.AppendLine("Loại,Mã,Họ tên,Khoa,Học kỳ,Tổng điểm,Xếp loại,Danh hiệu,Ngày đánh giá,Người đánh giá");

                foreach (ThongTinXetThiDua xtd in danhSach)
                {
                    csv.Append(EscapeCSV(xtd.LoaiDoiTuong));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.MaDoiTuong));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.HoTen));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.Khoa));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.HocKy));
                    csv.Append(",");
                    csv.Append(xtd.TongDiem.ToString());
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.XepLoaiThiDua));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.DanhHieuThiDua));
                    csv.Append(",");
                    csv.Append(xtd.NgayDanhGia.ToString("dd/MM/yyyy"));
                    csv.Append(",");
                    csv.Append(EscapeCSV(xtd.NguoiDanhGia));
                    csv.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT HỒ SƠ SANG CSV ====================
        public bool XuatDanhSachHoSo(List<ThongTinHoSo> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder csv = new StringBuilder();
                csv.Append("\uFEFF");
                csv.AppendLine("Mã hồ sơ,Loại,Mã đối tượng,Tên đối tượng,Ngày nộp,Trạng thái,Danh sách giấy tờ,Người xử lý,Ngày xử lý,Kết quả,Ghi chú");

                foreach (ThongTinHoSo hs in danhSach)
                {
                    csv.Append(EscapeCSV(hs.MaHoSo));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.LoaiHoSo));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.MaDoiTuong));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.TenDoiTuong));
                    csv.Append(",");
                    csv.Append(hs.NgayNop.ToString("dd/MM/yyyy"));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.TrangThai));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.DanhSachGiayTo));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.NguoiXuLy));
                    csv.Append(",");
                    csv.Append(hs.NgayXuLy.ToString("dd/MM/yyyy"));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.KetQuaXuLy));
                    csv.Append(",");
                    csv.Append(EscapeCSV(hs.GhiChu));
                    csv.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT ĐÀO TẠO SANG CSV ====================
        public bool XuatDanhSachDaoTao(List<ThongTinDaoTao> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder csv = new StringBuilder();
                csv.Append("\uFEFF");
                csv.AppendLine("Mã CT,Tên CT,Bậc đào tạo,Khoa,Số tín chỉ,Thời gian,Năm bắt đầu,Trạng thái,Mô tả");

                foreach (ThongTinDaoTao dt in danhSach)
                {
                    csv.Append(EscapeCSV(dt.MaChuongTrinh));
                    csv.Append(",");
                    csv.Append(EscapeCSV(dt.TenChuongTrinh));
                    csv.Append(",");
                    csv.Append(EscapeCSV(dt.BacDaoTao));
                    csv.Append(",");
                    csv.Append(EscapeCSV(dt.Khoa));
                    csv.Append(",");
                    csv.Append(dt.SoTinChi.ToString());
                    csv.Append(",");
                    csv.Append(dt.ThoiGianDaoTao.ToString());
                    csv.Append(",");
                    csv.Append(dt.NamBatDau.ToString());
                    csv.Append(",");
                    csv.Append(EscapeCSV(dt.TrangThai));
                    csv.Append(",");
                    csv.Append(EscapeCSV(dt.MoTa));
                    csv.AppendLine();
                }

                System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== ESCAPE CSV VALUE ====================
        // 🔍 MỤC ĐÍCH: Xử lý các ký tự đặc biệt trong CSV
        // 📝 QUY TẮC:
        // - Nếu value chứa dấu phẩy (,) → Bọc trong dấu nháy kép
        // - Nếu value chứa dấu nháy kép (") → Escape thành ""
        // - Nếu value chứa newline → Bọc trong dấu nháy kép
        //
        // VÍ DỤ:
        // - "Hello, World" → "\"Hello, World\""
        // - "Say \"Hi\"" → "\"Say \"\"Hi\"\"\""
        private string EscapeCSV(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            bool needsQuotes = false;

            // Kiểm tra xem có cần quotes không
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c == ',' || c == '"' || c == '\n' || c == '\r')
                {
                    needsQuotes = true;
                    break;
                }
            }

            if (!needsQuotes)
                return value;

            // Escape dấu nháy kép (double them)
            StringBuilder escaped = new StringBuilder();
            escaped.Append('"');
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (c == '"')
                    escaped.Append("\"\""); // Escape " thành ""
                else
                    escaped.Append(c);
            }
            escaped.Append('"');

            return escaped.ToString();
        }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 CSV FORMAT (COMMA-SEPARATED VALUES):
        //
        // CSV là định dạng file text đơn giản để lưu trữ dữ liệu dạng bảng
        // Mỗi dòng là 1 row, các cột phân cách bởi dấu phẩy
        //
        // CÁCH HOẠT ĐỘNG:
        // 1. Dòng đầu tiên: Header (tên các cột)
        // 2. Các dòng tiếp theo: Data rows
        // 3. Mỗi field cách nhau bởi dấu phẩy
        //
        // ⚠️ VẤN ĐỀ VỚI CÁC KÝ TỰ ĐẶC BIỆT:
        //
        // PROBLEM 1: Value chứa dấu phẩy
        // - Input: "Nguyen Van A, Son La"
        // - Sai: Nguyen Van A, Son La → Excel hiểu thành 2 columns
        // - Đúng: "Nguyen Van A, Son La" → Excel hiểu thành 1 column
        //
        // PROBLEM 2: Value chứa dấu nháy kép
        // - Input: Say "Hello"
        // - Sai: "Say "Hello"" → Lỗi parse
        // - Đúng: "Say ""Hello""" → Escape bằng cách double quotes
        //
        // PROBLEM 3: Tiếng Việt hiển thị lỗi trong Excel
        // - Nguyên nhân: Excel mặc định dùng encoding hệ thống (không phải UTF-8)
        // - Giải pháp: Thêm UTF-8 BOM (Byte Order Mark) \uFEFF ở đầu file
        //
        // 📊 UTF-8 BOM:
        // - BOM = Byte Order Mark = EF BB BF (3 bytes)
        // - \uFEFF là Unicode character cho BOM
        // - Khi Excel thấy BOM → Tự động nhận biết file là UTF-8
        // - Không có BOM → Excel dùng encoding mặc định → Tiếng Việt bị lỗi
        //
        // 🎓 VÍ DỤ CỤ THỂ:
        //
        // INPUT DATA:
        // MaSV = "SV2024001"
        // HoTen = "Nguyen Van A, Son La"
        // Email = "test@gmail.com"
        //
        // OUTPUT CSV:
        // SV2024001,"Nguyen Van A, Son La",test@gmail.com
        //
        // Khi mở trong Excel:
        // | Column A    | Column B               | Column C         |
        // |-------------|------------------------|------------------|
        // | SV2024001   | Nguyen Van A, Son La   | test@gmail.com   |
        //
        // 📝 THUẬT TOÁN ESCAPE:
        //
        // function EscapeCSV(value):
        //     if value is empty:
        //         return ""
        //
        //     needsQuotes = false
        //     for each char in value:
        //         if char is ',' or '"' or newline:
        //             needsQuotes = true
        //             break
        //
        //     if not needsQuotes:
        //         return value
        //
        //     result = "\""
        //     for each char in value:
        //         if char is '"':
        //             result += "\"\""  // Double the quote
        //         else:
        //             result += char
        //     result += "\""
        //     return result
        //
        // ⏱️ TIME COMPLEXITY:
        // - O(n) where n = length of value
        // - Mỗi character được scan tối đa 2 lần
        //
        // 💾 SPACE COMPLEXITY:
        // - O(n) for StringBuilder
        // - Worst case: value toàn dấu " → output = 2n characters
    }
}
