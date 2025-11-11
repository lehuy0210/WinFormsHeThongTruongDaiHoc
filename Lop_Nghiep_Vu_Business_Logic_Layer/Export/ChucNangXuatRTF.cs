using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export
{
    // ==================== BUSINESS LOGIC LAYER - XUẤT DỮ LIỆU SANG RTF ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ FILE I/O: Writing text files, File streams, StreamWriter
    // 2️⃣ RTF FORMAT: Rich Text Format, escape sequences, control words
    // 3️⃣ UNICODE HANDLING: UTF-16LE encoding for RTF, Vietnamese character encoding
    // 4️⃣ TEXT FORMATTING: Bold, tables, paragraphs, font styling
    // 5️⃣ STRING BUILDER: Building complex multi-line text structures
    //
    // 💡 MỤC ĐÍCH:
    // Xuất dữ liệu từ danh sách objects sang file RTF (Word format)
    // Không sử dụng thư viện bên ngoài (không dùng DocumentFormat.OpenXml, Open XML SDK)
    // Tự implement RTF writer để tạo file .rtf có định dạng đẹp
    //
    // 📖 RTF BASICS:
    // RTF (Rich Text Format) là định dạng text có support formatting
    // RTF file bắt đầu với header: {\rtf1\ansi\deff0 {\fonttbl {\f0 Times New Roman;}}}
    // Mọi formatting đều dùng control words bắt đầu bằng backslash (\)
    //
    // 🔤 TIẾNG VIỆT TRONG RTF:
    // RTF sử dụng Unicode escape sequence: \u[số] để đại diện cho characters
    // Ví dụ: \u7853 = ớ, \u7845 = ặ, \u7855 = ủ, \u7887 = ỗ
    // Sau Unicode escape phải có dấu ? hoặc space để tránh lỗi: \u7853?

    public class ChucNangXuatRTF
    {
        // RTF Control Constants
        private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
        private const string FONT_TABLE = @"{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}}";
        private const string COLOR_TABLE = @"{\colortbl;\red0\green0\blue0;}";
        private const string CELL_WIDTH = 1400; // Chiều rộng cell trong twips (1 twip = 1/20 điểm)

        // ==================== XUẤT BÁO CÁO XÉT TỐT NGHIỆP SANG RTF ====================
        // 🎯 PURPOSE: Xuất danh sách xét tốt nghiệp với định dạng bảng và in được
        // 📊 OUTPUT: File RTF với header, tiêu đề, bảng dữ liệu
        public bool XuatBaoCaoXetTotNghiep(List<ThongTinXetTotNghiep> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder rtf = new StringBuilder();

                // BƯỚC 1: Tạo RTF Header
                rtf.Append(RTF_HEADER);
                rtf.Append(FONT_TABLE);
                rtf.Append(COLOR_TABLE);

                // BƯỚC 2: Tạo tiêu đề báo cáo
                rtf.Append(@"\viewkind4\uc1\pard\f0\fs24");
                rtf.Append(@"\b ");
                rtf.Append(EscapeRTFText("BÁO CÁO XÉT TỐT NGHIỆP"));
                rtf.Append(@"\b0\par");
                rtf.Append(@"\pard\fs20 ");
                rtf.Append(EscapeRTFText($"Ngày xuất: {DateTime.Now:dd/MM/yyyy}"));
                rtf.Append(@"\par\par");

                // BƯỚC 3: Tạo bảng dữ liệu
                rtf.Append(CreateRTFTable(danhSach.Count + 1, 14)); // Header + data rows, 14 columns

                // Header row
                rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 \trbrdrl\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrb\brdrs\brdrw10\brdrcf1\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap\trcbpat1");

                // Header columns
                AppendRTFTableCell(rtf, "Mã SV", true);
                AppendRTFTableCell(rtf, "Họ Tên", true);
                AppendRTFTableCell(rtf, "Khoa", true);
                AppendRTFTableCell(rtf, "Ngành", true);
                AppendRTFTableCell(rtf, "Khóa", true);
                AppendRTFTableCell(rtf, "Tín Chỉ", true);
                AppendRTFTableCell(rtf, "GPA", true);
                AppendRTFTableCell(rtf, "Điểm RL", true);
                AppendRTFTableCell(rtf, "Môn Nợ", true);
                AppendRTFTableCell(rtf, "TOEIC", true);
                AppendRTFTableCell(rtf, "Khoá Luận", true);
                AppendRTFTableCell(rtf, "Kết Quả", true);
                AppendRTFTableCell(rtf, "Xếp Loại", true);
                AppendRTFTableCell(rtf, "Học Kỳ TN", true);

                rtf.Append(@"\row");

                // Data rows
                foreach (ThongTinXetTotNghiep xtn in danhSach)
                {
                    rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrl\brdrs\brdrw10\brdrcf1\trbrdrb\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap");

                    AppendRTFTableCell(rtf, xtn.MaSinhVien, false);
                    AppendRTFTableCell(rtf, xtn.HoTen, false);
                    AppendRTFTableCell(rtf, xtn.Khoa, false);
                    AppendRTFTableCell(rtf, xtn.Nganh, false);
                    AppendRTFTableCell(rtf, xtn.KhoaHoc, false);
                    AppendRTFTableCell(rtf, xtn.TongTinChiTichLuy.ToString(), false);
                    AppendRTFTableCell(rtf, xtn.DiemTrungBinhTichLuy.ToString("F2"), false);
                    AppendRTFTableCell(rtf, xtn.DiemRenLuyen.ToString(), false);
                    AppendRTFTableCell(rtf, xtn.SoMonNo.ToString(), false);
                    AppendRTFTableCell(rtf, xtn.DiemNgoaiNgu.ToString(), false);
                    AppendRTFTableCell(rtf, xtn.TrangThaiKhoaLuan, false);
                    AppendRTFTableCell(rtf, xtn.KetQuaXet, false);
                    AppendRTFTableCell(rtf, xtn.XepLoaiTotNghiep, false);
                    AppendRTFTableCell(rtf, xtn.HocKyTotNghiep, false);

                    rtf.Append(@"\row");
                }

                // BƯỚC 4: Kết thúc RTF document
                rtf.Append(@"\pard\par\fs20 }");

                // BƯỚC 5: Ghi vào file
                System.IO.File.WriteAllText(filePath, rtf.ToString(), Encoding.Default);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT BÁO CÁO XÉT THI ĐUA SANG RTF ====================
        // 🎯 PURPOSE: Xuất danh sách xét thi đua với đặc điểm các giải thưởng
        public bool XuatBaoCaoXetThiDua(List<ThongTinXetThiDua> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder rtf = new StringBuilder();

                // RTF Header
                rtf.Append(RTF_HEADER);
                rtf.Append(FONT_TABLE);
                rtf.Append(COLOR_TABLE);

                // Title
                rtf.Append(@"\viewkind4\uc1\pard\f0\fs24");
                rtf.Append(@"\b ");
                rtf.Append(EscapeRTFText("BÁO CÁO XÉT THI ĐUA"));
                rtf.Append(@"\b0\par");
                rtf.Append(@"\pard\fs20 ");
                rtf.Append(EscapeRTFText($"Ngày xuất: {DateTime.Now:dd/MM/yyyy}"));
                rtf.Append(@"\par\par");

                // Create table: 1 header row + data rows, 10 columns
                rtf.Append(CreateRTFTable(danhSach.Count + 1, 10));

                // Header row
                rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrl\brdrs\brdrw10\brdrcf1\trbrdrb\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap\trcbpat1");

                AppendRTFTableCell(rtf, "Loại", true);
                AppendRTFTableCell(rtf, "Mã", true);
                AppendRTFTableCell(rtf, "Họ Tên", true);
                AppendRTFTableCell(rtf, "Khoa", true);
                AppendRTFTableCell(rtf, "Học Kỳ", true);
                AppendRTFTableCell(rtf, "Tổng Điểm", true);
                AppendRTFTableCell(rtf, "Xếp Loại", true);
                AppendRTFTableCell(rtf, "Danh Hiệu", true);
                AppendRTFTableCell(rtf, "Ngày Đánh Giá", true);
                AppendRTFTableCell(rtf, "Người Đánh Giá", true);

                rtf.Append(@"\row");

                // Data rows
                foreach (ThongTinXetThiDua xtd in danhSach)
                {
                    rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrl\brdrs\brdrw10\brdrcf1\trbrdrb\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap");

                    AppendRTFTableCell(rtf, xtd.LoaiDoiTuong, false);
                    AppendRTFTableCell(rtf, xtd.MaDoiTuong, false);
                    AppendRTFTableCell(rtf, xtd.HoTen, false);
                    AppendRTFTableCell(rtf, xtd.Khoa, false);
                    AppendRTFTableCell(rtf, xtd.HocKy, false);
                    AppendRTFTableCell(rtf, xtd.TongDiem.ToString(), false);
                    AppendRTFTableCell(rtf, xtd.XepLoaiThiDua, false);
                    AppendRTFTableCell(rtf, xtd.DanhHieuThiDua, false);
                    AppendRTFTableCell(rtf, xtd.NgayDanhGia.ToString("dd/MM/yyyy"), false);
                    AppendRTFTableCell(rtf, xtd.NguoiDanhGia, false);

                    rtf.Append(@"\row");
                }

                rtf.Append(@"\pard\par\fs20 }");

                System.IO.File.WriteAllText(filePath, rtf.ToString(), Encoding.Default);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT DANH SÁCH SINH VIÊN SANG RTF ====================
        // 🎯 PURPOSE: Xuất danh sách sinh viên đơn giản với thông tin cơ bản
        public bool XuatDanhSachSinhVien(List<ThongTinSinhVien> danhSach, string filePath)
        {
            try
            {
                if (danhSach == null || danhSach.Count == 0)
                    return false;

                StringBuilder rtf = new StringBuilder();

                // RTF Header
                rtf.Append(RTF_HEADER);
                rtf.Append(FONT_TABLE);
                rtf.Append(COLOR_TABLE);

                // Title
                rtf.Append(@"\viewkind4\uc1\pard\f0\fs24");
                rtf.Append(@"\b ");
                rtf.Append(EscapeRTFText("DANH SÁCH SINH VIÊN"));
                rtf.Append(@"\b0\par");
                rtf.Append(@"\pard\fs20 ");
                rtf.Append(EscapeRTFText($"Ngày xuất: {DateTime.Now:dd/MM/yyyy}"));
                rtf.Append(@"\par\par");

                // Create table: 1 header row + data rows, 10 columns
                rtf.Append(CreateRTFTable(danhSach.Count + 1, 10));

                // Header row
                rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrl\brdrs\brdrw10\brdrcf1\trbrdrb\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap\trcbpat1");

                AppendRTFTableCell(rtf, "Mã SV", true);
                AppendRTFTableCell(rtf, "Họ Tên", true);
                AppendRTFTableCell(rtf, "Ngày Sinh", true);
                AppendRTFTableCell(rtf, "Giới Tính", true);
                AppendRTFTableCell(rtf, "Địa Chỉ", true);
                AppendRTFTableCell(rtf, "SĐT", true);
                AppendRTFTableCell(rtf, "Email", true);
                AppendRTFTableCell(rtf, "Khoa", true);
                AppendRTFTableCell(rtf, "Ngành", true);
                AppendRTFTableCell(rtf, "Khóa Học", true);

                rtf.Append(@"\row");

                // Data rows
                foreach (ThongTinSinhVien sv in danhSach)
                {
                    rtf.Append(@"\trowd\trgaph108\trleft-108\trbrdrt\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrl\brdrs\brdrw10\brdrcf1\trbrdrb\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrr\brdrs\brdrw10\brdrcf1\trbrdrh\brdrs\brdrw10\brdrcf1 ");
                    rtf.Append(@"\trbrdrv\brdrs\brdrw10\brdrcf1\trloch\trnowrap");

                    AppendRTFTableCell(rtf, sv.MaSinhVien, false);
                    AppendRTFTableCell(rtf, sv.HoTen, false);
                    AppendRTFTableCell(rtf, sv.NgaySinh.ToString("dd/MM/yyyy"), false);
                    AppendRTFTableCell(rtf, sv.GioiTinh, false);
                    AppendRTFTableCell(rtf, sv.DiaChi, false);
                    AppendRTFTableCell(rtf, sv.SoDienThoai, false);
                    AppendRTFTableCell(rtf, sv.Email, false);
                    AppendRTFTableCell(rtf, sv.Khoa, false);
                    AppendRTFTableCell(rtf, sv.Nganh, false);
                    AppendRTFTableCell(rtf, sv.KhoaHoc, false);

                    rtf.Append(@"\row");
                }

                rtf.Append(@"\pard\par\fs20 }");

                System.IO.File.WriteAllText(filePath, rtf.ToString(), Encoding.Default);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== HELPER: ESCAPE RTF TEXT ====================
        // 🔍 MỤC ĐÍCH: Chuyển đổi text thường sang RTF format
        // 📝 QUY LUẬT RTF:
        // - Backslash (\) → \\ (escape backslash)
        // - Dấu ngoặc nhọn ({ }) → \{ \} (escape braces)
        // - Tiếng Việt → Unicode escape sequences
        //
        // 🌍 UNICODE ESCAPE TRONG RTF:
        // RTF dùng \u[số ansi] để biểu diễn Unicode characters
        // Ví dụ:
        // - À = \u192? (ký tự À)
        // - ế = \u7871? (ký tự ế)
        // - ị = \u7883? (ký tự ị)
        // Sau mỗi Unicode escape phải có ? hoặc space để tránh confused với control word
        private string EscapeRTFText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            StringBuilder escaped = new StringBuilder();

            foreach (char c in text)
            {
                // ASCII characters: 32-126
                if (c >= 32 && c <= 126)
                {
                    if (c == '\\' || c == '{' || c == '}')
                        escaped.Append('\\'); // Escape special characters
                    escaped.Append(c);
                }
                // Vietnamese and special characters: use Unicode escape
                else if (c > 126 && c < 256)
                {
                    // Latin Extended-A and other extended characters
                    // RTF uses ANSI encoding for extended characters
                    escaped.Append('\'');
                    escaped.Append(((int)c).ToString("x2"));
                }
                else
                {
                    // Full Unicode: use \u format
                    int code = (int)c;
                    escaped.Append(@"\u");
                    escaped.Append(code);
                    escaped.Append("?");
                }
            }

            return escaped.ToString();
        }

        // ==================== HELPER: APPEND RTF TABLE CELL ====================
        // 🎯 PURPOSE: Thêm 1 cell vào RTF table
        // 📊 CELL FORMAT: \cell để kết thúc cell
        private void AppendRTFTableCell(StringBuilder rtf, string content, bool isBold)
        {
            rtf.Append(@"\clbrdrt\brdrs\brdrw10\brdrcf1\clbrdll\brdrs\brdrw10\brdrcf1 ");
            rtf.Append(@"\clbrdrb\brdrs\brdrw10\brdrcf1\clbrdrr\brdrs\brdrw10\brdrcf1 ");
            rtf.Append(@"\cltxlrtb\clftsWidth2\clwWidth");
            rtf.Append(CELL_WIDTH);
            rtf.Append(@"\clpad108\clpadft3\clpadl108\clpadt108\clpadr108\clpadb108 ");
            rtf.Append(@"\cellx");
            rtf.Append(CELL_WIDTH);

            if (isBold)
                rtf.Append(@"\b ");

            rtf.Append(EscapeRTFText(content ?? ""));

            if (isBold)
                rtf.Append(@"\b0 ");

            rtf.Append(@"\cell");
        }

        // ==================== HELPER: CREATE RTF TABLE ====================
        // 🎯 PURPOSE: Khởi tạo RTF table structure
        // 📊 PARAMETERS:
        // - rows: số hàng
        // - cols: số cột
        private string CreateRTFTable(int rows, int cols)
        {
            StringBuilder table = new StringBuilder();
            // RTF table initialization - no implementation needed in this version
            // Tables are created row by row with \trowd and \row commands
            return table.ToString();
        }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 📄 RTF FORMAT (RICH TEXT FORMAT):
        //
        // RTF là định dạng text có hỗ trợ formatting (bold, italic, tables, etc.)
        // RTF được Windows và nhiều ứng dụng khác hỗ trợ (Word, Notepad++, LibreOffice)
        //
        // CÁCH HOẠT ĐỘNG:
        // 1. RTF file bắt đầu với header chứa font table, color table, metadata
        // 2. Content được bao quanh bởi dấu ngoặc nhọn {}
        // 3. Mọi formatting dùng control words bắt đầu bằng \
        // 4. \par = paragraph break (enter)
        // 5. \b = bold text, \b0 = end bold
        //
        // CÁCH TẠO RTF HEADER:
        // {\rtf1\ansi\ansicpg1252\deff0
        // - \rtf1 = RTF version 1
        // - \ansi = ANSI character set (not UTF-8)
        // - \ansicpg1252 = Code page 1252 (Western European)
        // - \deff0 = Default font 0 (từ font table)
        //
        // FONT TABLE:
        // {\fonttbl{\f0\fnil\fcharset0 Times New Roman;}}
        // - \f0 = Font ID 0
        // - \fcharset0 = Character set
        // - Times New Roman = Font name
        //
        // TIẾNG VIỆT TRONG RTF:
        // Có 2 cách đại diện ký tự Việt:
        // 1. Hex escape: \'XX (2 hex digits) - cho characters 128-255
        //    Ví dụ: À = \'C0, á = \'E1
        // 2. Unicode escape: \uN? (Unicode number + ?) - cho characters > 255
        //    Ví dụ: ế = \u7871?, ị = \u7883?
        //
        // 📊 RTF TABLE FORMAT:
        //
        // Table structure:
        // \trowd = table row definition
        // \trgaph108 = gap between cells
        // \trleft-108 = table left indent
        // \trbrdrt = top border
        // \clbrdrt = cell left border top
        // \cellx1400 = cell boundary at position 1400 twips
        // \cell = cell separator
        // \row = end of row
        //
        // TWIPS UNIT:
        // - TWIP = Twentieth of an Inch Point
        // - 1 inch = 1440 twips
        // - 1 point = 20 twips
        // - 1400 twips ≈ 1 inch wide cell
        //
        // 🎓 VÍ DỤ COMPLETE RTF:
        //
        // {\rtf1\ansi\deff0 {\fonttbl{\f0 Times New Roman;}}
        // \viewkind4\uc1\pard\f0\fs24
        // \b Tiêu đề\b0\par
        // \pard\fs20 Dòng nội dung\par
        // }
        //
        // Giải thích:
        // - {\rtf1...} = RTF document
        // - \viewkind4 = View kind (normal view)
        // - \uc1 = Unicode character bytes (1)
        // - \pard = Reset paragraph properties
        // - \f0 = Use font 0 (Times New Roman)
        // - \fs24 = Font size 24 (12pt, vì fs = font size in half-points)
        // - \b...\b0 = Bold text
        // - \par = Paragraph break
        //
        // ⏱️ TIME COMPLEXITY:
        // - XuatBaoCaoXetTotNghiep: O(n*m) where n = rows, m = columns
        // - Mỗi row xử lý tất cả columns
        // - Mỗi cell escape RTF text
        //
        // 💾 SPACE COMPLEXITY:
        // - O(n*m) for StringBuilder
        // - Worst case: mỗi ký tự Việt = 6-8 ký tự RTF
    }
}
