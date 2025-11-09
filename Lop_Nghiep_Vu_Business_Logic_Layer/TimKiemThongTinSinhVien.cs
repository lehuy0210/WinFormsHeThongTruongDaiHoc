using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG TÌM KIẾM SINH VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS: Chapter 4 (Loops - for/foreach), Chapter 5 (Functions)
    // 2️⃣ PROGRAMMING TECHNIQUES: Chapter 4 (String operations)
    // 3️⃣ OOP: Chapter 2 (Classes, Objects, Methods)
    // 4️⃣ DSA1: 
    //    - Chapter 1.1.3: Traverse - Duyệt qua danh sách
    //    - Chapter 2.2.1: Sequential Search - Tìm kiếm tuần tự
    // 5️⃣ DATABASE PROGRAMMING: Chapter 3 (N-Layer - BLL)
    //
    // 🎯 MỤC ĐÍCH:
    // - TÌM theo MÃ (exact match)
    // - TÌM theo HỌ TÊN (partial match)
    // - TÌM theo LỚP, GIỚI TÍNH
    // - TÌM KIẾM NÂNG CAO (nhiều bộ lọc)
    // - LỌC theo KHOẢNG NGÀY SINH
    //
    // 💡 THUẬT TOÁN: Sequential Search O(n)
    // - Duyệt từng phần tử
    // - So sánh với tiêu chí tìm kiếm
    // - Nếu khớp → thêm vào kết quả
    //
    // 📊 ĐỘ PHỨC TẠP: O(n) - Phải duyệt hết danh sách
    /*
    Tìm kiếm hoạt động như thế nào?
    - Giống như tìm tên trong sổ danh sách
    - Đọc từng dòng, so sánh với tên cần tìm
    - Tìm thấy → ghi lại, tiếp tục tìm (có thể nhiều kết quả)
    */
    public class ChucNangTimKiemThongTinSinhVien
    {
        // ==================== PHƯƠNG THỨC TÌM KIẾM TỔNG QUÁT ====================
        // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)
        // Sử dụng: Traverse operation (Chapter 1.1.3 - DSA1)

        /// <summary>
        /// Tìm kiếm sinh viên theo nhiều tiêu chí
        /// Search students by multiple criteria
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tieuChi">Tiêu chí tìm kiếm</param>
        /// <returns>Danh sách sinh viên thỏa mãn tiêu chí</returns>
        /*
             VÍ DỤ SỬ DỤNG:

          List<ThongTinSinhVien> ds = quanLy.LayDanhSachSinhVien();
             ThongTinSinhVien tieuChi = new ThongTinSinhVien { 
                 TenSV = "An", 
           LopSV = "22IT" 
             };

             List<ThongTinSinhVien> ketQua = chucNangTimKiem.TimKiemSinhVien(ds, tieuChi);
             // Tìm tất cả sinh viên có tên chứa "An" và lớp chứa "22IT"
             */
        public List<ThongTinSinhVien> TimKiemSinhVien(List<ThongTinSinhVien> danhSach,
                     ThongTinSinhVien tieuChi)
        {
            // ===== BƯỚC 1: KHỞI TẠO DANH SÁCH KẾT QUẢ =====
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            // ===== BƯỚC 2: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====
            if (danhSach == null)
            {
                return ketQua; // Danh sách null → Trả về list rỗng
            }

            if (tieuChi == null)
            {
                return ketQua; // Tiêu chí null → Trả về list rỗng
            }

            // ===== BƯỚC 3: DUYỆT QUA TỪNG SINH VIÊN (TRAVERSE) =====
            // Sử dụng: Traverse operation (Chapter 1.1.3 - DSA1)
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Kiểm tra sinh viên có khớp tiêu chí không
                bool khopTieuChi = KiemTraKhopTieuChi(sv, tieuChi);

                if (khopTieuChi)
                {
                    // Khớp → Thêm vào kết quả
                    ketQua.Add(sv);
                }
            }

            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return ketQua;
        }

        // ==================== PHƯƠNG THỨC TÌM THEO MÃ ====================
        // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)

        /// <summary>
        /// Tìm sinh viên theo mã (chính xác)
        /// Find student by ID (exact match)
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần tìm</param>
        /// <returns>Sinh viên nếu tìm thấy, null nếu không</returns>
        /*
        VÍ DỤ CHẠY TAY:
        
        Danh sách: [SV001, SV002, SV003]
        Tìm: "SV002"
        
        Lần 1: So sánh "SV001" với "SV002" → Không khớp
      Lần 2: So sánh "SV002" với "SV002" → Khớp! → return SV002
        
        Độ phức tạp:
        - Best case: O(1) - Tìm thấy ngay ở đầu
        - Worst case: O(n) - Tìm thấy ở cuối hoặc không tìm thấy
        */
        public ThongTinSinhVien TimTheoMaSV(List<ThongTinSinhVien> danhSach, string maSV)
        {
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return null;
            }

            // Kiểm tra mã sinh viên rỗng
            bool maRong = KiemTraChuoiRong(maSV);
            if (maRong)
            {
                return null;
            }

            // Tìm kiếm tuần tự (Sequential Search)
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy mã sinh viên hiện tại
                string maSVHienTai = sv.MaSV;

                // So sánh mã (không phân biệt hoa/thường)
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maSVHienTai, maSV);

                if (khopMa)
                {
                    return sv; // Tìm thấy! Trả về ngay
                }
            }

            // Duyệt hết mà không thấy
            return null;
        }

        // ==================== PHƯƠNG THỨC TÌM THEO HỌ TÊN ====================

        /// <summary>
        /// Tìm sinh viên theo họ và tên
        /// Find students by name
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="ho">Họ cần tìm (có thể null)</param>
        /// <param name="tenLot">Tên lót cần tìm (có thể null)</param>
        /// <param name="ten">Tên cần tìm (có thể null)</param>
        /// <returns>Danh sách sinh viên thỏa mãn</returns>
        /*
            VÍ DỤ:
            TimTheoHoTen(ds, "Nguyễn", null, "An")
            → Tìm tất cả sinh viên họ chứa "Nguyễn" và tên chứa "An"
            → Không quan tâm tên lót
            */
        public List<ThongTinSinhVien> TimTheoHoTen(List<ThongTinSinhVien> danhSach,
    string ho,
           string tenLot,
        string ten)
        {
            // Khởi tạo kết quả
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return ketQua;
            }

            // Duyệt qua từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                bool khop = true; // Giả sử khớp

                // Kiểm tra họ (nếu có truyền vào)
                bool coHo = !KiemTraChuoiRong(ho);
                if (coHo)
                {
                    bool hoKhop = KiemTraChuaChuoiCon(sv.HoSV, ho);
                    if (!hoKhop)
                    {
                        khop = false; // Họ không khớp
                    }
                }

                // Kiểm tra tên lót (nếu có truyền vào)
                bool coTenLot = !KiemTraChuoiRong(tenLot);
                if (khop && coTenLot)
                {
                    bool tenLotKhop = KiemTraChuaChuoiCon(sv.TenLotSV, tenLot);
                    if (!tenLotKhop)
                    {
                        khop = false; // Tên lót không khớp
                    }
                }

                // Kiểm tra tên (nếu có truyền vào)
                bool coTen = !KiemTraChuoiRong(ten);
                if (khop && coTen)
                {
                    bool tenKhop = KiemTraChuaChuoiCon(sv.TenSV, ten);
                    if (!tenKhop)
                    {
                        khop = false; // Tên không khớp
                    }
                }

                // Nếu tất cả đều khớp → Thêm vào kết quả
                if (khop)
                {
                    ketQua.Add(sv);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC TÌM THEO LỚP ====================

        /// <summary>
        /// Tìm sinh viên theo lớp
        /// Find students by class
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="lop">Lớp cần tìm</param>
        /// <returns>Danh sách sinh viên trong lớp đó</returns>
        /*
        VÍ DỤ:
        TimTheoLop(ds, "22IT") 
        → Tìm tất cả sinh viên có lớp chứa "22IT"
        → Kết quả: 22IT1, 22IT2, 22IT3, ...
        */
        public List<ThongTinSinhVien> TimTheoLop(List<ThongTinSinhVien> danhSach, string lop)
        {
            // Khởi tạo kết quả
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return ketQua;
            }

            bool lopRong = KiemTraChuoiRong(lop);
            if (lopRong)
            {
                return ketQua;
            }

            // Duyệt qua từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Kiểm tra lớp của sinh viên có chứa chuỗi tìm kiếm không
                bool lopKhop = KiemTraChuaChuoiCon(sv.LopSV, lop);

                if (lopKhop)
                {
                    ketQua.Add(sv);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC TÌM THEO GIỚI TÍNH ====================

        /// <summary>
        /// Tìm sinh viên theo giới tính
        /// Find students by gender
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="gioiTinh">Giới tính ("Nam" hoặc "Nữ")</param>
        /// <returns>Danh sách sinh viên có giới tính đó</returns>
        public List<ThongTinSinhVien> TimTheoGioiTinh(List<ThongTinSinhVien> danhSach,
                string gioiTinh)
        {
            // Khởi tạo kết quả
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return ketQua;
            }

            bool gioiTinhRong = KiemTraChuoiRong(gioiTinh);
            if (gioiTinhRong)
            {
                return ketQua;
            }

            // Duyệt qua từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // So sánh giới tính (không phân biệt hoa/thường)
                bool gioiTinhKhop = SoSanhChuoiKhongPhanBietHoaThuong(sv.GioiTinhSV, gioiTinh);

                if (gioiTinhKhop)
                {
                    ketQua.Add(sv);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA KHỚP TIÊU CHÍ ====================

        /// <summary>
        /// Kiểm tra sinh viên có khớp với tiêu chí tìm kiếm không
        /// Check if student matches search criteria
        /// </summary>
        /// <param name="sv">Sinh viên cần kiểm tra</param>
        /// <param name="tieuChi">Tiêu chí tìm kiếm</param>
        /// <returns>true nếu khớp, false nếu không khớp</returns>
        /*
GIẢI THÍCH:
  - Kiểm tra TỪNG trường của tiêu chí
        - Nếu tiêu chí có giá trị → Phải khớp
     - Nếu tiêu chí rỗng → Bỏ qua (không kiểm tra)
        
        VÍ DỤ CHẠY TAY:

        sv = { MaSV="SV001", HoSV="Nguyễn", TenSV="An", LopSV="22IT1" }
        tieuChi = { TenSV="An", LopSV="22IT" }
      
        Bước 1: Kiểm tra MaSV
        - tieuChi.MaSV rỗng → Bỏ qua
        
        Bước 2: Kiểm tra HoSV
                - tieuChi.HoSV rỗng → Bỏ qua
        
        Bước 3: Kiểm tra TenSV
        - tieuChi.TenSV = "An"
        - sv.TenSV = "An"
            - "An" chứa "An" → Khớp ✓
        
        Bước 4: Kiểm tra LopSV
- tieuChi.LopSV = "22IT"
    - sv.LopSV = "22IT1"
              - "22IT1" chứa "22IT" → Khớp ✓
    
        Kết quả: Tất cả đều khớp → return true
        */
        private bool KiemTraKhopTieuChi(ThongTinSinhVien sv, ThongTinSinhVien tieuChi)
        {
            // ===== KIỂM TRA MÃ SINH VIÊN =====
            bool coMa = !KiemTraChuoiRong(tieuChi.MaSV);
            if (coMa)
            {
                bool maKhop = KiemTraChuaChuoiCon(sv.MaSV, tieuChi.MaSV);
                if (!maKhop)
                {
                    return false; // Mã không khớp → Loại
                }
            }

            // ===== KIỂM TRA HỌ =====
            bool coHo = !KiemTraChuoiRong(tieuChi.HoSV);
            if (coHo)
            {
                bool hoKhop = KiemTraChuaChuoiCon(sv.HoSV, tieuChi.HoSV);
                if (!hoKhop)
                {
                    return false; // Họ không khớp → Loại
                }
            }

            // ===== KIỂM TRA TÊN LÓT =====
            bool coTenLot = !KiemTraChuoiRong(tieuChi.TenLotSV);
            if (coTenLot)
            {
                bool tenLotKhop = KiemTraChuaChuoiCon(sv.TenLotSV, tieuChi.TenLotSV);
                if (!tenLotKhop)
                {
                    return false; // Tên lót không khớp → Loại
                }
            }

            // ===== KIỂM TRA TÊN =====
            bool coTen = !KiemTraChuoiRong(tieuChi.TenSV);
            if (coTen)
            {
                bool tenKhop = KiemTraChuaChuoiCon(sv.TenSV, tieuChi.TenSV);
                if (!tenKhop)
                {
                    return false; // Tên không khớp → Loại
                }
            }

            // ===== KIỂM TRA LỚP =====
            bool coLop = !KiemTraChuoiRong(tieuChi.LopSV);
            if (coLop)
            {
                bool lopKhop = KiemTraChuaChuoiCon(sv.LopSV, tieuChi.LopSV);
                if (!lopKhop)
                {
                    return false; // Lớp không khớp → Loại
                }
            }

            // ===== KIỂM TRA EMAIL =====
            bool coEmail = !KiemTraChuoiRong(tieuChi.EmailSV);
            if (coEmail)
            {
                bool emailKhop = KiemTraChuaChuoiCon(sv.EmailSV, tieuChi.EmailSV);
                if (!emailKhop)
                {
                    return false; // Email không khớp → Loại
                }
            }

            // ===== KIỂM TRA GIỚI TÍNH =====
            // Giới tính so sánh chính xác (không dùng Contains)
            bool coGioiTinh = !KiemTraChuoiRong(tieuChi.GioiTinhSV);
            if (coGioiTinh)
            {
                bool gioiTinhKhop = SoSanhChuoiKhongPhanBietHoaThuong(sv.GioiTinhSV, tieuChi.GioiTinhSV);
                if (!gioiTinhKhop)
                {
                    return false; // Giới tính không khớp → Loại
                }
            }

            // Tất cả tiêu chí đều khớp
            return true;
        }

        // ==================== PHƯƠNG THỨC LỌC THEO KHOẢNG NGÀY SINH ====================

        /// <summary>
        /// Lọc sinh viên theo khoảng ngày sinh
        /// Filter students by birth date range
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tuNgay">Từ ngày (bao gồm)</param>
        /// <param name="denNgay">Đến ngày (bao gồm)</param>
        /// <returns>Danh sách sinh viên sinh trong khoảng đó</returns>
        /*
        VÍ DỤ:
        LocTheoKhoangNgaySinh(ds, 01/01/2000, 31/12/2005)
   → Tìm sinh viên sinh từ 2000 đến 2005
        */
        public List<ThongTinSinhVien> LocTheoKhoangNgaySinh(List<ThongTinSinhVien> danhSach,
  DateTime tuNgay,
          DateTime denNgay)
        {
            // Khởi tạo kết quả
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return ketQua;
            }

            // Duyệt qua từng sinh viên
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy ngày sinh
                DateTime ngaySinh = sv.NgaySinhSV;

                // Kiểm tra nằm trong khoảng không
                bool trongKhoang = (ngaySinh >= tuNgay) && (ngaySinh <= denNgay);

                if (trongKhoang)
                {
                    ketQua.Add(sv);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC TÌM KIẾM NÂNG CAO ====================

        /// <summary>
        /// Tìm kiếm nâng cao với nhiều bộ lọc
        /// Advanced search with multiple filters
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tuKhoa">Từ khóa tìm trong tất cả các trường</param>
        /// <param name="gioiTinh">Giới tính lọc</param>
        /// <param name="lop">Lớp lọc</param>
        /// <param name="tuNgay">Từ ngày sinh</param>
        /// <param name="denNgay">Đến ngày sinh</param>
        /// <returns>Danh sách sinh viên thỏa mãn TẤT CẢ bộ lọc</returns>
        /*
        GIẢI THÍCH:
    - Lọc lần lượt qua từng bộ lọc
        - Kết quả của lọc trước là đầu vào của lọc sau
        - Cuối cùng còn lại sinh viên thỏa mãn TẤT CẢ
        
  VÍ DỤ:
        Ban đầu: 100 sinh viên
        → Lọc từ khóa "An": Còn 20 sinh viên
        → Lọc giới tính "Nam": Còn 15 sinh viên
   → Lọc lớp "22IT": Còn 10 sinh viên
     → Kết quả: 10 sinh viên
    */
        public List<ThongTinSinhVien> TimKiemNangCao(List<ThongTinSinhVien> danhSach,
           string tuKhoa,
          string gioiTinh,
            string lop,
                   DateTime? tuNgay,
             DateTime? denNgay)
        {
            // Bắt đầu với toàn bộ danh sách
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            if (danhSach == null)
            {
                return ketQua;
            }

            // Copy danh sách gốc vào kết quả
            foreach (ThongTinSinhVien sv in danhSach)
            {
                ketQua.Add(sv);
            }

            // ===== LỌC 1: THEO TỪ KHÓA =====
            bool coTuKhoa = !KiemTraChuoiRong(tuKhoa);
            if (coTuKhoa)
            {
                ketQua = TimTheoTuKhoa(ketQua, tuKhoa);
            }

            // ===== LỌC 2: THEO GIỚI TÍNH =====
            bool coGioiTinh = !KiemTraChuoiRong(gioiTinh);
            if (coGioiTinh)
            {
                ketQua = TimTheoGioiTinh(ketQua, gioiTinh);
            }

            // ===== LỌC 3: THEO LỚP =====
            bool coLop = !KiemTraChuoiRong(lop);
            if (coLop)
            {
                ketQua = TimTheoLop(ketQua, lop);
            }

            // ===== LỌC 4: THEO KHOẢNG NGÀY SINH =====
            bool coKhoangNgay = (tuNgay != null) && (denNgay != null);
            if (coKhoangNgay)
            {
                ketQua = LocTheoKhoangNgaySinh(ketQua, tuNgay.Value, denNgay.Value);
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC TÌM THEO TỪ KHÓA ====================

        /// <summary>
        /// Tìm kiếm theo từ khóa (tìm trong tất cả các trường)
        /// Search by keyword (search in all fields)
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tuKhoa">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách sinh viên có ít nhất 1 trường chứa từ khóa</returns>
        /*
        VÍ DỤ:
   TimTheoTuKhoa(ds, "An")
    → Tìm trong: Mã SV, Họ, Tên lót, Tên, Email, Lớp
        → Nếu có 1 trường chứa "An" → Thêm vào kết quả
      */
        private List<ThongTinSinhVien> TimTheoTuKhoa(List<ThongTinSinhVien> danhSach,
                string tuKhoa)
        {
            List<ThongTinSinhVien> ketQua = new List<ThongTinSinhVien>();

            foreach (ThongTinSinhVien sv in danhSach)
            {
                bool timThay = false; // Chưa tìm thấy

                // Tìm trong mã sinh viên
                if (KiemTraChuaChuoiCon(sv.MaSV, tuKhoa))
                {
                    timThay = true;
                }

                // Tìm trong họ
                if (!timThay && KiemTraChuaChuoiCon(sv.HoSV, tuKhoa))
                {
                    timThay = true;
                }

                // Tìm trong tên lót
                if (!timThay && KiemTraChuaChuoiCon(sv.TenLotSV, tuKhoa))
                {
                    timThay = true;
                }

                // Tìm trong tên
                if (!timThay && KiemTraChuaChuoiCon(sv.TenSV, tuKhoa))
                {
                    timThay = true;
                }

                // Tìm trong email
                if (!timThay && KiemTraChuaChuoiCon(sv.EmailSV, tuKhoa))
                {
                    timThay = true;
                }

                // Tìm trong lớp
                if (!timThay && KiemTraChuaChuoiCon(sv.LopSV, tuKhoa))
                {
                    timThay = true;
                }

                // Nếu tìm thấy ở bất kỳ trường nào → Thêm vào kết quả
                if (timThay)
                {
                    ketQua.Add(sv);
                }
            }

            return ketQua;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================
        // Sử dụng: String operations (Chapter 4 - Programming Techniques)

        /// <summary>
        /// Kiểm tra chuỗi có rỗng không (null hoặc chỉ chứa khoảng trắng)
        /// Check if string is empty (null or whitespace only)
        /// </summary>
        /// <param name="chuoi">Chuỗi cần kiểm tra</param>
        /// <returns>true nếu rỗng, false nếu có nội dung</returns>
        private bool KiemTraChuoiRong(string chuoi)
        {
            // Kiểm tra null
            if (chuoi == null)
            {
                return true;
            }

            // Kiểm tra độ dài = 0
            if (chuoi.Length == 0)
            {
                return true;
            }

            // Kiểm tra tất cả ký tự có phải khoảng trắng không
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                // Nếu có ít nhất 1 ký tự không phải khoảng trắng
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    return false; // Chuỗi có nội dung
                }
            }

            // Tất cả ký tự đều là khoảng trắng
            return true;
        }

        /// <summary>
        /// So sánh 2 chuỗi không phân biệt hoa/thường
        /// Compare two strings case-insensitively
        /// </summary>
        /// <param name="chuoi1">Chuỗi thứ nhất</param>
        /// <param name="chuoi2">Chuỗi thứ hai</param>
        /// <returns>true nếu giống nhau, false nếu khác nhau</returns>
        /*
            VÍ DỤ:
            SoSanhChuoiKhongPhanBietHoaThuong("An", "AN") → true
        SoSanhChuoiKhongPhanBietHoaThuong("An", "Bình") → false
            */
        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            // Kiểm tra null
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

            // Chuyển về chữ thường
            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            // So sánh
            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        /// <summary>
        /// So sánh 2 chuỗi chính xác (phân biệt hoa/thường)
        /// Compare two strings exactly (case-sensitive)
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            // Kiểm tra null
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

            // Kiểm tra độ dài
            if (chuoi1.Length != chuoi2.Length)
            {
                return false;
            }

            // So sánh từng ký tự
            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi về chữ thường
        /// Convert string to lowercase
        /// </summary>
        /// <param name="chuoi">Chuỗi cần chuyển</param>
        /// <returns>Chuỗi chữ thường</returns>
        /*
        GIẢI THÍCH:
        - Duyệt từng ký tự
        - Nếu là chữ HOA (A-Z) → Chuyển thành chữ thường
        - Khoảng cách giữa 'A' và 'a' trong bảng ASCII = 32
        
        VÍ DỤ CHẠY TAY:
        ChuyenVeChuThuong("NgUyEn")
        
        N (78) → n (110) = 78 + 32
        g (103) → g (103) = giữ nguyên
        U (85) → u (117) = 85 + 32
      y (121) → y (121) = giữ nguyên
        E (69) → e (101) = 69 + 32
     n (110) → n (110) = giữ nguyên
      
        Kết quả: "nguyen"
        */
        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                // Kiểm tra có phải chữ HOA không (A-Z)
                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
                    // Chuyển thành chữ thường
                    // Khoảng cách giữa 'A' và 'a' = 32
                    char kyTuThuong = (char)(kyTu + 32);
                    ketQua += kyTuThuong;
                }
                else
                {
                    // Giữ nguyên
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Kiểm tra chuỗi gốc có chứa chuỗi con không (không phân biệt hoa/thường)
        /// Check if string contains substring (case-insensitive)
        /// </summary>
        /// <param name="chuoiGoc">Chuỗi gốc</param>
        /// <param name="chuoiCon">Chuỗi con cần tìm</param>
        /// <returns>true nếu chứa, false nếu không</returns>
        /*
        GIẢI THÍCH THUẬT TOÁN:
        
Bước 1: Chuyển cả 2 chuỗi về chữ thường
        Bước 2: Duyệt qua từng vị trí có thể bắt đầu chuỗi con
        Bước 3: Tại mỗi vị trí, kiểm tra chuỗi con có khớp không
 Bước 4: Nếu khớp → return true
        Bước 5: Nếu duyệt hết mà không khớp → return false
   
        VÍ DỤ CHẠY TAY:
        
        KiemTraChuaChuoiCon("Nguyễn Văn An", "văn")
        
     Bước 1: Chuyển về thường
           - chuoiGoc = "nguyễn văn an"
                - chuoiCon = "văn"
   
        Bước 2: Duyệt
     - Vị trí 0: "ngu" != "văn" → Không khớp
      - Vị trí 1: "guy" != "văn" → Không khớp
      - ...
      - Vị trí 8: "văn" == "văn" → Khớp! → return true
  
      Độ phức tạp: O(n*m)
        - n = độ dài chuỗi gốc
        - m = độ dài chuỗi con
  */
        private bool KiemTraChuaChuoiCon(string chuoiGoc, string chuoiCon)
        {
            // Kiểm tra null
            if (chuoiGoc == null)
            {
                return false;
            }

            if (chuoiCon == null)
            {
                return true; // Chuỗi con null = rỗng → Luôn chứa
            }

            // Kiểm tra độ dài
            if (chuoiCon.Length > chuoiGoc.Length)
            {
                return false; // Chuỗi con dài hơn → Không thể chứa
            }

            // Chuyển về chữ thường
            string gocThuong = ChuyenVeChuThuong(chuoiGoc);
            string conThuong = ChuyenVeChuThuong(chuoiCon);

            // Duyệt qua từng vị trí có thể bắt đầu chuỗi con
            for (int i = 0; i <= gocThuong.Length - conThuong.Length; i++)
            {
                bool khop = true; // Giả sử khớp

                // Kiểm tra chuỗi con từ vị trí i
                for (int j = 0; j < conThuong.Length; j++)
                {
                    if (gocThuong[i + j] != conThuong[j])
                    {
                        khop = false; // Có ký tự khác nhau
                        break;
                    }
                }

                if (khop)
                {
                    return true; // Tìm thấy chuỗi con
                }
            }

            // Duyệt hết mà không tìm thấy
            return false;
        }
        /*
            ==================== TÓM TẮT CHO SINH VIÊN ====================

        1. CHỨC NĂNG CHÍNH: TimKiemSinhVien()
       - Duyệt qua từng sinh viên
            - Kiểm tra khớp tiêu chí
               - Thêm vào kết quả nếu khớp

            2. CÁC PHƯƠNG THỨC TÌM KIẾM:
               - TimTheoMaSV(): Tìm chính xác theo mã
      - TimTheoHoTen(): Tìm theo họ tên (contains)
    - TimTheoLop(): Tìm theo lớp (contains)
               - TimTheoGioiTinh(): Tìm theo giới tính (exact)
             - LocTheoKhoangNgaySinh(): Lọc theo khoảng ngày
         - TimKiemNangCao(): Kết hợp nhiều bộ lọc

            3. THUẬT TOÁN SỬ DỤNG:
        - Sequential Search: O(n)
               - String matching: O(n*m)
     - Traverse: O(n)

            4. CÁC METHOD HỎ TRỢ TỰ CODE:
               - KiemTraChuoiRong(): Check null/empty
          - SoSanhChuoiKhongPhanBietHoaThuong(): Compare case-insensitive
             - SoSanhChuoiChinhXac(): Compare case-sensitive
             - ChuyenVeChuThuong(): Lowercase (ASCII + 32)
               - KiemTraChuaChuoiCon(): Contains substring

            5. KIẾN THỨC ÁP DỤNG:
               - OOP: Classes, Objects, Methods
               - DSA1: Sequential Search, Traverse
               - String operations: Tự code toàn bộ
               - ASCII manipulation: Chuyển hoa/thường

       6. ĐỘ PHỨC TẠP:
               - TimTheoMaSV(): O(n)
         - TimKiemSinhVien(): O(n)
               - KiemTraChuaChuoiCon(): O(n*m)
               - TimKiemNangCao(): O(n * số bộ lọc)

            ==================== END TÓM TẮT ====================
            */
    }
}