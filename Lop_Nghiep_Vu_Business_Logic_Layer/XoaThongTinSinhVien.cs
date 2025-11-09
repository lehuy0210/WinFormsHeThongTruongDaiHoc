using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG XÓA SINH VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures (if/else, for, foreach)
    //    - Chapter 5: Functions (Methods, Return values, Parameters)
    //    - Chapter 6: Arrays (Array operations)
    //
    // 2️⃣ OBJECT-ORIENTED PROGRAMMING:
    //    - Chapter 2: Classes and Objects (Methods, Passing Objects)
    //
    // 3️⃣ DATA STRUCTURES AND ALGORITHMS 1:
    //    - Chapter 1: Lists
    //      • 1.1.3: Delete operation - Xóa phần tử khỏi danh sách
    //    - Chapter 2: Searching
    //      • 2.2.1: Sequential Search - Tìm sinh viên cần xóa
    //
    // 4️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture (Business Logic Layer)
    //
    // 🎯 MỤC ĐÍCH:
    // - XÓA sinh viên theo mã
    // - XÓA NHIỀU sinh viên cùng lúc
    // - XÓA CÓ SAO LƯU (backup) để khôi phục nếu nhầm
    // - XÓA THEO ĐIỀU KIỆN (lớp, giới tính,...)
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Như xóa tên sinh viên khỏi sổ danh sách lớp:
    // - Tìm tên cần xóa (Sequential Search)
    // - Gạch bỏ hoặc xóa khỏi danh sách (Remove)
    // - Có thể sao chép trước khi xóa (Backup)
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - XoaSinhVien(mã): O(n) - Tìm + Xóa
    // - XoaNhieuSinhVien(list mã): O(n*m)
    // - XoaTheoLop(lớp): O(n)
    /*
    GIẢI THÍCH CHO SINH VIÊN:
    
    Chức năng XÓA hoạt động như thế nào?
    
    Bước 1: TÌM sinh viên cần xóa (Sequential Search - O(n))
    Bước 2: XÓA khỏi List (Remove - O(n) vì phải dịch chuyển)
    Bước 3: (Optional) SAO LƯU trước khi xóa để có thể UNDO
    
    Tại sao xóa lại ảnh hưởng List gốc?
    - List.Remove() xóa object khỏi List
    - Các phần tử phía sau tự động dịch lên
    - Count giảm 1
    */
    // Sử dụng: Delete operation (Chapter 1.1.3 - DSA1)

    /// <summary>
    /// Xóa sinh viên theo mã
    /// Delete student by ID
    /// </summary>
    /// <param name="danhSach">Danh sách sinh viên</param>
    /// <param name="maSV">Mã sinh viên cần xóa</param>
    /// <returns>true nếu xóa thành công, false nếu thất bại</returns>
    /*
       VÍ DỤ SỬ DỤNG:

 List<ThongTinSinhVien> ds = quanLy.LayDanhSachSinhVien();
       bool ketQua = chucNangXoa.XoaSinhVien(ds, "SV001");

       if (ketQua)
       {
MessageBox.Show("Xóa thành công!");
       }

       VÍ DỤ CHẠY TAY:

Trước khi xóa:
    ds = [SV001, SV002, SV003]

    Gọi: XoaSinhVien(ds, "SV002")

       Bước 1: Tìm SV002 trong list → Tìm thấy tại index 1
       Bước 2: Xóa object tại index 1
     Bước 3: List tự động dịch chuyển các phần tử phía sau lên

Sau khi xóa:
   ds = [SV001, SV003]

       Độ phức tạp: O(n)
   - Tìm kiếm: O(n)
       - Xóa: O(n) - Do phải dịch chuyển phần tử
*/
    public class ChucNangXoaThongTinSinhVien
    {
        // ==================== PHƯƠNG THỨC XÓA THEO MÃ ====================
        // Sử dụng: Delete operation (Chapter 1.1.3 - DSA1)
        /// <summary>
        /// Xóa sinh viên theo mã
        /// Delete student by ID
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần xóa</param>
        /// <returns>true nếu xóa thành công, false nếu thất bại</returns>
        /*
        VÍ DỤ SỬ DỤNG:
       
        List<ThongTinSinhVien> ds = quanLy.LayDanhSachSinhVien();
        bool ketQua = chucNangXoa.XoaSinhVien(ds, "SV001");
     
        if (ketQua)
        {
            MessageBox.Show("Xóa thành công!");
        }
  
        VÍ DỤ CHẠY TAY:
       
        Trước khi xóa:
        ds = [SV001, SV002, SV003]
       
        Gọi: XoaSinhVien(ds, "SV002")
       
        Bước 1: Tìm SV002 trong list → Tìm thấy tại index 1
        Bước 2: Xóa object tại index 1
        Bước 3: List tự động dịch chuyển các phần tử phía sau lên
       
        Sau khi xóa:
        ds = [SV001, SV003]
 
        Độ phức tạp: O(n)
        - Tìm kiếm: O(n)
        - Xóa: O(n) - Do phải dịch chuyển phần tử
        */
        public bool XoaSinhVien(List<ThongTinSinhVien> danhSach, string maSV)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return false; // Danh sách không tồn tại
            }
            // Kiểm tra mã sinh viên rỗng
            bool maRong = KiemTraChuoiRong(maSV);
            if (maRong)
            {
                return false; // Mã sinh viên không hợp lệ
            }
            // ===== BƯỚC 2: TÌM SINH VIÊN CẦN XÓA =====
            // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)

            ThongTinSinhVien svCanXoa = TimSinhVienTheoMa(danhSach, maSV);
            // Kiểm tra có tìm thấy không
            if (svCanXoa == null)
            {
                return false; // Không tìm thấy sinh viên với mã này
            }
            // ===== BƯỚC 3: XÓA SINH VIÊN KHỎI DANH SÁCH =====
            // Sử dụng: Delete operation (Chapter 1.1.3 - DSA1)
            /*
            GIẢI THÍCH: List.Remove() hoạt động như thế nào?
        
            List trước: [SV001, SV002, SV003]
            Index: [0] [1] [2]
     
            Gọi: Remove(SV002)
     
            Bước 1: Tìm SV002 trong list → index 1
            Bước 2: Xóa phần tử tại index 1
            Bước 3: Dịch chuyển các phần tử sau lên
            - SV003 từ index 2 → index 1
           
            List sau: [SV001, SV003]
            Index: [0] [1]
   
            Kết quả: List.Count giảm từ 3 → 2
            */
            bool daXoa = danhSach.Remove(svCanXoa);
            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return daXoa; // true nếu xóa thành công
        }

        // ==================== PHƯƠNG THỨC XÓA NHIỀU SINH VIÊN ====================
        /// <summary>
        /// Xóa nhiều sinh viên cùng lúc
        /// Delete multiple students at once
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="danhSachMaSV">Danh sách mã sinh viên cần xóa</param>
        /// <returns>Số lượng sinh viên đã xóa thành công</returns>
        /*
        VÍ DỤ:
     
        List<string> dsXoa = new List<string> { "SV001", "SV002", "SV003" };
        int soLuongDaXoa = chucNangXoa.XoaNhieuSinhVien(ds, dsXoa);
       
        MessageBox.Show($"Đã xóa {soLuongDaXoa} sinh viên");
       
        VÍ DỤ CHẠY TAY:
       
        ds = [SV001, SV002, SV003, SV004]
        dsXoa = ["SV001", "SV003", "SV999"]
   
        Lần 1: Xóa "SV001" → Thành công → soLuongDaXoa = 1
        ds = [SV002, SV003, SV004]
   
        Lần 2: Xóa "SV003" → Thành công → soLuongDaXoa = 2
        ds = [SV002, SV004]
     
        Lần 3: Xóa "SV999" → Không tìm thấy → soLuongDaXoa = 2
        ds = [SV002, SV004]
       
        Kết quả: soLuongDaXoa = 2
        */
        public int XoaNhieuSinhVien(List<ThongTinSinhVien> danhSach, List<string> danhSachMaSV)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return 0;
            }

            if (danhSachMaSV == null)
            {
                return 0;
            }
            // Đếm số lượng đã xóa
            int soLuongDaXoa = 0;
            // Xóa từng sinh viên
            foreach (string maSV in danhSachMaSV)
            {
                // Gọi method XoaSinhVien
                bool ketQua = XoaSinhVien(danhSach, maSV);

                if (ketQua)
                {
                    soLuongDaXoa++; // Tăng biến đếm
                }
            }
            return soLuongDaXoa;
        }

        // ==================== PHƯƠNG THỨC XÓA THEO ĐIỀU KIỆN ====================
        /// <summary>
        /// Xóa sinh viên theo lớp
        /// Delete students by class
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="lop">Lớp cần xóa</param>
        /// <returns>Số lượng sinh viên đã xóa</returns>
        /*
        VÍ DỤ:
       
        int soLuong = chucNangXoa.XoaTheoLop(ds, "22IT1");
        MessageBox.Show($"Đã xóa {soLuong} sinh viên lớp 22IT1");
       
        CẢNH BÁO: Không được xóa trực tiếp trong foreach!
       
        ❌ SAI:
        foreach (var sv in danhSach)
        {
            if (sv.LopSV == "22IT1")
            {
                danhSach.Remove(sv); // LỖI: Không thể sửa list đang duyệt!
            }
        }
       
        ✅ ĐÚNG:
        - Bước 1: Tìm tất cả sinh viên cần xóa → Lưu vào list tạm
        - Bước 2: Duyệt list tạm và xóa từng sinh viên
        */
        public int XoaTheoLop(List<ThongTinSinhVien> danhSach, string lop)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return 0;
            }

            bool lopRong = KiemTraChuoiRong(lop);
            if (lopRong)
            {
                return 0;
            }
            // ===== BƯỚC 1: TÌM TẤT CẢ SINH VIÊN THUỘC LỚP =====
            // Tạo danh sách tạm để lưu sinh viên cần xóa
            List<ThongTinSinhVien> danhSachXoa = new List<ThongTinSinhVien>();
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // So sánh lớp (không phân biệt hoa/thường)
                bool lopKhop = SoSanhChuoiKhongPhanBietHoaThuong(sv.LopSV, lop);

                if (lopKhop)
                {
                    danhSachXoa.Add(sv); // Thêm vào danh sách cần xóa
                }
            }
            // ===== BƯỚC 2: XÓA CÁC SINH VIÊN ĐÃ TÌM THẤY =====
            int soLuongDaXoa = 0;

            foreach (ThongTinSinhVien sv in danhSachXoa)
            {
                bool daXoa = danhSach.Remove(sv);

                if (daXoa)
                {
                    soLuongDaXoa++;
                }
            }
            return soLuongDaXoa;
        }

        // ==================== PHƯƠNG THỨC TÌM SINH VIÊN ====================
        // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)
        /// <summary>
        /// Tìm sinh viên theo mã
        /// Find student by ID
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần tìm</param>
        /// <returns>Object sinh viên nếu tìm thấy, null nếu không</returns>
        /*
        VÍ DỤ CHẠY TAY:
       
        ds = [SV001, SV002, SV003]
        Tìm: "SV002"
       
        Lần 1: So sánh "SV001" với "SV002" → Không khớp
        Lần 2: So sánh "SV002" với "SV002" → Khớp! → return SV002
       
        Độ phức tạp: O(n)
        */
        private ThongTinSinhVien? TimSinhVienTheoMa(List<ThongTinSinhVien> danhSach, string maSV)
        {
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return null;
            }
            // Kiểm tra mã rỗng
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
                    return sv; // Tìm thấy! Trả về object
                }
            }
            // Duyệt hết mà không thấy
            return null;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA TRƯỚC KHI XÓA ====================
        /// <summary>
        /// Kiểm tra xem sinh viên có thể xóa được không
        /// Check if student can be deleted
        /// </summary>
        /// <param name="sv">Sinh viên cần kiểm tra</param>
        /// <returns>true nếu có thể xóa, false nếu không</returns>
        /*
        GIẢI THÍCH:
       
        Một số trường hợp KHÔNG NÊN xóa sinh viên:
        - Sinh viên đang học (TrangThaiSV = "Đang học")
        - Sinh viên có điểm thi
        - Sinh viên có học phí chưa đóng
        - ...
       
        VÍ DỤ:
       
        if (!chucNangXoa.KiemTraCoTheXoa(sv))
        {
            MessageBox.Show("Không thể xóa sinh viên đang học!");
            return;
        }
        */
        public bool KiemTraCoTheXoa(ThongTinSinhVien sv)
        {
            // Kiểm tra null
            if (sv == null)
            {
                return false;
            }
            // ===== THÊM CÁC ĐIỀU KIỆN KIỂM TRA Ở ĐÂY =====

            // Ví dụ: Không cho xóa sinh viên đang học
            // bool dangHoc = SoSanhChuoiKhongPhanBietHoaThuong(sv.TrangThaiSV, "Đang học");
            // if (dangHoc)
            // {
            //     return false; // Không cho xóa
            // }
            // Hiện tại cho phép xóa tất cả
            return true;
        }

        // ==================== PHƯƠNG THỨC SAO LƯU TRƯỚC KHI XÓA ====================
        /// <summary>
        /// Sao lưu thông tin sinh viên trước khi xóa
        /// Backup student information before deleting
        /// </summary>
        /// <param name="sv">Sinh viên cần sao lưu</param>
        /// <returns>Bản sao của sinh viên</returns>
        /*
        GIẢI THÍCH:
       
        Tại sao cần sao lưu?
        - Để có thể KHÔI PHỤC nếu xóa nhầm
        - Để lưu lịch sử (audit trail)
       
        Cách hoạt động:
        - Tạo object MỚI
        - Copy TẤT CẢ thuộc tính từ object cũ sang object mới
        - Trả về object mới
       
        VÍ DỤ:
    
        ThongTinSinhVien banSao = chucNangXoa.SaoLuuSinhVien(sv);
        chucNangXoa.XoaSinhVien(ds, sv.MaSV);
        // Nếu muốn khôi phục:
        chucNangXoa.KhoiPhucSinhVien(ds, banSao);
        */
        public ThongTinSinhVien? SaoLuuSinhVien(ThongTinSinhVien sv)
        {
            // Kiểm tra null
            if (sv == null)
            {
                return null;
            }
            // Tạo bản sao MỚI
            // LƯU Ý: Đây là DEEP COPY (sao chép giá trị, không phải reference)
            ThongTinSinhVien banSao = new ThongTinSinhVien();

            // Sao chép từng thuộc tính
            banSao.ID = sv.ID;
            banSao.MaSV = sv.MaSV;
            banSao.HoSV = sv.HoSV;
            banSao.TenLotSV = sv.TenLotSV;
            banSao.TenSV = sv.TenSV;
            banSao.NgaySinhSV = sv.NgaySinhSV;
            banSao.GioiTinhSV = sv.GioiTinhSV;
            banSao.CCCDSV = sv.CCCDSV;
            banSao.DiaChiSV = sv.DiaChiSV;
            banSao.EmailSV = sv.EmailSV;
            banSao.LopSV = sv.LopSV;
            banSao.TrangThaiSV = sv.TrangThaiSV;
            return banSao;
        }

        // ==================== PHƯƠNG THỨC XÓA AN TOÀN ====================
        /// <summary>
        /// Xóa sinh viên an toàn (có sao lưu)
        /// Safe delete with backup
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần xóa</param>
        /// <param name="banSao">Bản sao sinh viên bị xóa (để khôi phục)</param>
        /// <returns>true nếu xóa thành công, false nếu thất bại</returns>
        /*
        VÍ DỤ SỬ DỤNG:
       
        ThongTinSinhVien banSao;
        bool ketQua = chucNangXoa.XoaAnToan(ds, "SV001", out banSao);
   
        if (ketQua)
        {
            MessageBox.Show("Xóa thành công!");
    
            // Lưu bản sao để có thể khôi phục sau
            // ...
        }
       
        VÍ DỤ CHẠY TAY:
     
        ds = [SV001, SV002, SV003]
        Xóa: "SV001"
       
        Bước 1: Tìm SV001 → Tìm thấy
        Bước 2: Kiểm tra có thể xóa → true
        Bước 3: Sao lưu SV001 → banSao
        Bước 4: Xóa SV001 khỏi list
       
        Kết quả:
        - ds = [SV002, SV003]
        - banSao = {MaSV="SV001", HoSV="Nguyễn", ...}
        */
        public bool XoaAnToan(List<ThongTinSinhVien> danhSach,
            string maSV,
            out ThongTinSinhVien? banSao)
        {
            // Khởi tạo biến out
            banSao = null;
            // ===== BƯỚC 1: TÌM SINH VIÊN =====
            ThongTinSinhVien? svCanXoa = TimSinhVienTheoMa(danhSach, maSV);
            if (svCanXoa == null)
            {
                return false; // Không tìm thấy
            }
            // ===== BƯỚC 2: KIỂM TRA CÓ THỂ XÓA KHÔNG =====
            bool coTheXoa = KiemTraCoTheXoa(svCanXoa);

            if (!coTheXoa)
            {
                return false; // Không được phép xóa
            }
            // ===== BƯỚC 3: SAO LƯU TRƯỚC KHI XÓA =====
            banSao = SaoLuuSinhVien(svCanXoa);
            // ===== BƯỚC 4: XÓA SINH VIÊN =====
            bool ketQua = danhSach.Remove(svCanXoa);
            return ketQua;
        }

        // ==================== PHƯƠNG THỨC KHÔI PHỤC SINH VIÊN ====================
        /// <summary>
        /// Khôi phục sinh viên đã xóa
        /// Restore deleted student
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="svKhoiPhuc">Sinh viên cần khôi phục</param>
        /// <returns>true nếu khôi phục thành công, false nếu thất bại</returns>
        /*
        VÍ DỤ:
       
        // Xóa và lưu bản sao
        ThongTinSinhVien banSao;
        chucNangXoa.XoaAnToan(ds, "SV001", out banSao);
 
        // Sau đó muốn khôi phục
        bool ketQua = chucNangXoa.KhoiPhucSinhVien(ds, banSao);
       
        if (ketQua)
        {
            MessageBox.Show("Khôi phục thành công!");
        }
       
        VÍ DỤ CHẠY TAY:
       
        ds = [SV002, SV003]
        svKhoiPhuc = {MaSV="SV001", HoSV="Nguyễn", ...}
       
        Bước 1: Kiểm tra mã "SV001" đã tồn tại chưa → Chưa
        Bước 2: Thêm svKhoiPhuc vào list
        Kết quả:
        ds = [SV002, SV003, SV001]
        */
        public bool KhoiPhucSinhVien(List<ThongTinSinhVien> danhSach,
            ThongTinSinhVien svKhoiPhuc)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return false;
            }
            if (svKhoiPhuc == null)
            {
                return false;
            }
            // ===== BƯỚC 1: KIỂM TRA MÃ ĐÃ TỒN TẠI CHƯA =====
            ThongTinSinhVien? svTonTai = TimSinhVienTheoMa(danhSach, svKhoiPhuc.MaSV);
            if (svTonTai != null)
            {
                return false; // Mã đã tồn tại → Không thể khôi phục
            }
            // ===== BƯỚC 2: THÊM LẠI SINH VIÊN VÀO DANH SÁCH =====
            danhSach.Add(svKhoiPhuc);
            return true;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================
        // Sử dụng: String operations (Chapter 4 - Programming Techniques)
        /// <summary>
        /// Kiểm tra chuỗi có rỗng không (null hoặc chỉ chứa khoảng trắng)
        /// Check if string is empty (null or whitespace only)
        /// </summary>
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

        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================
       
        1. CHỨC NĂNG CHÍNH: XoaSinhVien()
        - Tìm sinh viên theo mã
        - Xóa sinh viên khỏi List
        - Độ phức tạp: O(n)
  
        2. TẠI SAO XÓA LẠI ẢNH HƯỞNG LIST?
        - List chứa reference (địa chỉ) đến object
        - Remove(object) → Xóa địa chỉ đó khỏi List
        - List tự động dịch chuyển các phần tử sau lên
       
        3. CÁC PHƯƠNG THỨC XÓA:
        - XoaSinhVien(): Xóa 1 sinh viên theo mã
        - XoaNhieuSinhVien(): Xóa nhiều sinh viên
        - XoaTheoLop(): Xóa tất cả sinh viên của 1 lớp
        - XoaAnToan(): Xóa và sao lưu để khôi phục
    
        4. CẢNH BÁO QUAN TRỌNG:
        ❌ KHÔNG được xóa trong foreach đang duyệt list đó!
        ✅ Phải tạo list tạm → Xóa sau
       
        5. SAO LƯU VÀ KHÔI PHỤC:
        - SaoLuuSinhVien(): Tạo bản sao (deep copy)
        - KhoiPhucSinhVien(): Thêm lại vào list
        - Dùng để UNDO khi xóa nhầm
       
        6. CÁC METHOD HỖ TRỢ TỰ CODE:
        - KiemTraChuoiRong(): Check null/empty
        - SoSanhChuoiKhongPhanBietHoaThuong(): Compare case-insensitive
        - ChuyenVeChuThuong(): Lowercase (ASCII + 32)
       
        7. KIẾN THỨC ÁP DỤNG:
        - OOP: Classes, Objects, Methods
        - DSA1: Delete operation, Sequential Search
        - List operations: Remove, Add
        - Deep copy vs Shallow copy
       
        8. ĐỘ PHỨC TẠP:
        - XoaSinhVien(): O(n) - Tìm + Xóa + Dịch chuyển
        - XoaNhieuSinhVien(): O(n*m) - n = số SV, m = số cần xóa
        - XoaTheoLop(): O(n) - Duyệt + Xóa
        ==================== END TÓM TẮT ====================
        */
    }
}