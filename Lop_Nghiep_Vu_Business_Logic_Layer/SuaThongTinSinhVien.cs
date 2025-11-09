using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG SỬA SINH VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS: Chapter 4 (Control Structures), Chapter 5 (Functions)
    // 2️⃣ OOP: Chapter 2 (Classes, Objects, Methods)
    // 3️⃣ DSA1: 
    //    - Chapter 1.1.3: Modify operation - Sửa giá trị phần tử
    //    - Chapter 2.2.1: Sequential Search - Tìm sinh viên cần sửa
    // 4️⃣ DATABASE PROGRAMMING: Chapter 3 (N-Layer - BLL)
    //
    // 🎯 MỤC ĐÍCH:
    // - SỬA TOÀN BỘ thông tin sinh viên
    // - SỬA TỪNG TRƯỜNG riêng lẻ (họ, tên, email,...)
    // - SO SÁNH thay đổi (old vs new)
    // - SAO CHÉP thông tin giữa 2 sinh viên
    //
    // 💡 VÍ DỤ:
    // Như sửa thông tin trong sổ danh sách:
    // - Tìm dòng cần sửa (Search)
    // - Gạch bỏ thông tin cũ, ghi thông tin mới (Modify)
    // - Danh sách tự động cập nhật (vì List chứa reference)
    //
    // 📊 ĐỘ PHỨC TẠP: O(n) - Sequential Search
    /*
    Tại sao sửa object lại ảnh hưởng List?
    - List chứa REFERENCE (địa chỉ) đến object
    - Sửa object = sửa trực tiếp tại địa chỉ đó
    - List tự động có data mới!
    */
    public class ChucNangSuaThongTinSinhVien
    {
        // ==================== PHƯƠNG THỨC SỬA THÔNG TIN CHÍNH ====================
        // Sử dụng: Modifying an element's value (Chapter 1.1.3 - DSA1)
        /// <summary>
        /// Sửa thông tin sinh viên
        /// Update student information
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần sửa</param>
        /// <param name="thongTinMoi">Thông tin mới</param>
        /// <returns>true nếu sửa thành công, false nếu thất bại</returns>
        /*
      VÍ DỤ SỬ DỤNG:
       
        List<ThongTinSinhVien> ds = quanLy.LayDanhSachSinhVien();
        ThongTinSinhVien ttMoi = new ThongTinSinhVien { HoSV="Trần", TenSV="Bình", ... };
    
        bool ketQua = chucNangSua.SuaThongTinSinhVien(ds, "SV001", ttMoi);
 if (ketQua) { MessageBox.Show("Sửa thành công!"); }
        */
        public bool SuaThongTinSinhVien(List<ThongTinSinhVien> danhSach,
     string maSV,
  ThongTinSinhVien thongTinMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra danh sách có null không
            if (danhSach == null)
            {
                return false; // Danh sách không tồn tại
            }
            // Kiểm tra mã sinh viên có rỗng không
            bool maSVRong = KiemTraChuoiRong(maSV);
            if (maSVRong)
            {
                return false; // Mã sinh viên không hợp lệ
            }
            // Kiểm tra thông tin mới có null không
            if (thongTinMoi == null)
            {
                return false; // Thông tin mới không tồn tại
            }
            // ===== BƯỚC 2: TÌM SINH VIÊN CẦN SỬA =====
            // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)
            ThongTinSinhVien svCanSua = TimSinhVienTheoMa(danhSach, maSV);
            // Kiểm tra có tìm thấy không
            if (svCanSua == null)
            {
                return false; // Không tìm thấy sinh viên với mã này
            }
            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU MỚI HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(thongTinMoi);

            if (!duLieuHopLe)
            {
                return false; // Dữ liệu mới không hợp lệ
            }
            // ===== BƯỚC 4: CẬP NHẬT THÔNG TIN =====
            // LƯU Ý: GIỮ NGUYÊN mã sinh viên (không cho sửa mã)
            /*
     GIẢI THÍCH: Tại sao cập nhật lại ảnh hưởng List?

           Stack (Bộ nhớ tạm):
                 danhSach → [0x1234] ← Địa chỉ List
         Heap (Bộ nhớ chính):
                 0x1234: List chứa các địa chỉ object
            ├─ [0] → 0xAAAA (SV001)
                 ├─ [1] → 0xBBBB (SV002)
          └─ [2] → 0xCCCC (SV003)

                 0xAAAA: Object ThongTinSinhVien
         {
           MaSV = "SV001",
     HoSV = "Nguyễn", ← Sửa ở đây
         TenSV = "An" ← Sửa ở đây
             }
         Khi gọi: svCanSua.HoSV = "Trần"
            → Sửa trực tiếp object tại 0xAAAA
               → List[0] vẫn trỏ đến 0xAAAA
                 → List tự động có data mới!
                 */
            // Cập nhật họ
            svCanSua.HoSV = thongTinMoi.HoSV;

            // Cập nhật tên lót
            svCanSua.TenLotSV = thongTinMoi.TenLotSV;

            // Cập nhật tên
            svCanSua.TenSV = thongTinMoi.TenSV;

            // Cập nhật ngày sinh
            svCanSua.NgaySinhSV = thongTinMoi.NgaySinhSV;

            // Cập nhật giới tính
            svCanSua.GioiTinhSV = thongTinMoi.GioiTinhSV;

            // Cập nhật CCCD
            svCanSua.CCCDSV = thongTinMoi.CCCDSV;

            // Cập nhật địa chỉ
            svCanSua.DiaChiSV = thongTinMoi.DiaChiSV;

            // Cập nhật email
            svCanSua.EmailSV = thongTinMoi.EmailSV;
            // Cập nhật lớp
            svCanSua.LopSV = thongTinMoi.LopSV;

            // Cập nhật trạng thái
            svCanSua.TrangThaiSV = thongTinMoi.TrangThaiSV;
            // ===== BƯỚC 5: TRẢ VỀ KẾT QUẢ =====
            return true; // Sửa thành công!
        }
        // ==================== PHƯƠNG THỨC SỬA TỪNG TRƯỜNG ====================
        /*
        GIẢI THÍCH: Tại sao có các method sửa từng trường?
       
        Đôi khi chỉ cần sửa 1 trường (ví dụ: chỉ đổi email)
   → Không cần tạo object ThongTinSinhVien mới
        → Gọi method SuaEmail() cho nhanh!
   
        VÍ DỤ:
chucNangSua.SuaEmail(ds, "SV001", "newemail@gmail.com");
      */
        /// <summary>
        /// Sửa họ của sinh viên
        /// Update student's last name
        /// </summary>
        public bool SuaHo(List<ThongTinSinhVien> danhSach, string maSV, string hoMoi)
        {
            // Bước 1: Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            // Bước 2: Kiểm tra tìm thấy
            if (sv == null)
            {
                return false; // Không tìm thấy
            }

            // Bước 3: Kiểm tra họ mới hợp lệ
            bool hoRong = KiemTraChuoiRong(hoMoi);
            if (hoRong)
            {
                return false; // Họ mới rỗng
            }
            // Bước 4: Cập nhật họ (xóa khoảng trắng thừa)
            sv.HoSV = XoaKhoangTrangThua(hoMoi);
            return true;
        }
        /// <summary>
        /// Sửa tên lót của sinh viên
        /// Update student's middle name
        /// </summary>
        public bool SuaTenLot(List<ThongTinSinhVien> danhSach, string maSV, string tenLotMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            if (sv == null)
            {
                return false;
            }
            // Cập nhật tên lót (cho phép null/rỗng vì tên lót không bắt buộc)
            if (tenLotMoi == null)
            {
                sv.TenLotSV = "";
            }
            else
            {
                sv.TenLotSV = XoaKhoangTrangThua(tenLotMoi);
            }

            return true;
        }
        /// <summary>
        /// Sửa tên của sinh viên
        /// Update student's first name
        /// </summary>
        public bool SuaTen(List<ThongTinSinhVien> danhSach, string maSV, string tenMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            // Kiểm tra tìm thấy
            if (sv == null)
            {
                return false;
            }

            // Kiểm tra tên mới hợp lệ
            bool tenRong = KiemTraChuoiRong(tenMoi);
            if (tenRong)
            {
                return false; // Tên bắt buộc phải có
            }
            // Cập nhật tên
            sv.TenSV = XoaKhoangTrangThua(tenMoi);

            return true;
        }
        /// <summary>
        /// Sửa ngày sinh của sinh viên
        /// Update student's birth date
        /// </summary>
        public bool SuaNgaySinh(List<ThongTinSinhVien> danhSach, string maSV, DateTime ngaySinhMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            if (sv == null)
            {
                return false;
            }
            // Tính tuổi
            int namHienTai = DateTime.Now.Year;
            int namSinh = ngaySinhMoi.Year;
            int tuoi = namHienTai - namSinh;

            // Kiểm tra tuổi hợp lệ (phải >= 18 tuổi)
            bool tuoiHopLe = (tuoi >= 18);

            if (!tuoiHopLe)
            {
                return false; // Tuổi không hợp lệ (chưa đủ 18)
            }
            // Cập nhật ngày sinh
            sv.NgaySinhSV = ngaySinhMoi;

            return true;
        }
        /// <summary>
        /// Sửa giới tính của sinh viên
        /// Update student's gender
        /// </summary>
        public bool SuaGioiTinh(List<ThongTinSinhVien> danhSach, string maSV, string gioiTinhMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            // Kiểm tra tìm thấy
            if (sv == null)
            {
                return false;
            }

            // Kiểm tra giới tính không rỗng
            bool gioiTinhRong = KiemTraChuoiRong(gioiTinhMoi);
            if (gioiTinhRong)
            {
                return false;
            }
            // Kiểm tra giới tính hợp lệ (chỉ cho phép "Nam" hoặc "Nữ")
            bool laNam = SoSanhChuoiKhongPhanBietHoaThuong(gioiTinhMoi, "Nam");
            bool laNu = SoSanhChuoiKhongPhanBietHoaThuong(gioiTinhMoi, "Nữ");
            bool gioiTinhHopLe = laNam || laNu;

            if (!gioiTinhHopLe)
            {
                return false; // Giới tính không hợp lệ
            }
            // Cập nhật giới tính
            sv.GioiTinhSV = gioiTinhMoi;

            return true;
        }
        /// <summary>
        /// Sửa email của sinh viên
        /// Update student's email
        /// </summary>
        public bool SuaEmail(List<ThongTinSinhVien> danhSach, string maSV, string emailMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            if (sv == null)
            {
                return false;
            }
            // Kiểm tra định dạng email (đơn giản: phải có @)
            bool emailRong = KiemTraChuoiRong(emailMoi);

            if (!emailRong)
            {
                // Email không rỗng → Kiểm tra có @ không
                bool coKyTuAt = KiemTraChuaChuoiCon(emailMoi, "@");

                if (!coKyTuAt)
                {
                    return false; // Email không hợp lệ (thiếu @)
                }
            }
            // Cập nhật email
            if (emailMoi == null)
            {
                sv.EmailSV = "";
            }
            else
            {
                sv.EmailSV = XoaKhoangTrangThua(emailMoi);
            }

            return true;
        }
        /// <summary>
        /// Sửa lớp của sinh viên
        /// Update student's class
        /// </summary>
        public bool SuaLop(List<ThongTinSinhVien> danhSach, string maSV, string lopMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            // Kiểm tra tìm thấy
            if (sv == null)
            {
                return false;
            }

            // Kiểm tra lớp mới hợp lệ
            bool lopRong = KiemTraChuoiRong(lopMoi);
            if (lopRong)
            {
                return false; // Lớp bắt buộc phải có
            }
            // Cập nhật lớp
            sv.LopSV = XoaKhoangTrangThua(lopMoi);

            return true;
        }
        /// <summary>
        /// Sửa trạng thái của sinh viên
        /// Update student's status
        /// </summary>
        public bool SuaTrangThai(List<ThongTinSinhVien> danhSach, string maSV, string trangThaiMoi)
        {
            // Tìm sinh viên
            ThongTinSinhVien sv = TimSinhVienTheoMa(danhSach, maSV);

            if (sv == null)
            {
                return false;
            }
            // Cập nhật trạng thái (cho phép rỗng)
            if (trangThaiMoi == null)
            {
                sv.TrangThaiSV = "";
            }
            else
            {
                sv.TrangThaiSV = XoaKhoangTrangThua(trangThaiMoi);
            }

            return true;
        }
        // ==================== PHƯƠNG THỨC TÌM SINH VIÊN ====================
        // Sử dụng: Sequential Search (Chapter 2.2.1 - DSA1)
        /// <summary>
        /// Tìm sinh viên theo mã
        /// Find student by ID
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="maSV">Mã sinh viên cần tìm</param>
        /// <returns>Object sinh viên nếu tìm thấy, null nếu không tìm thấy</returns>
        /*
            GIẢI THÍCH THUẬT TOÁN TÌM KIẾM TUẦN TỰ:

      Bước 1: Duyệt từng phần tử trong danh sách (từ đầu đến cuối)
       Bước 2: So sánh mã sinh viên của phần tử đó với mã cần tìm
        Bước 3: Nếu khớp → Trả về object sinh viên
            Bước 4: Nếu hết danh sách mà chưa thấy → Trả về null

            Độ phức tạp: O(n) - Worst case phải duyệt hết n phần tử

         VÍ DỤ CHẠY TAY:
            Danh sách: [SV001, SV002, SV003]
            Tìm: "SV002"

            Lần 1: So sánh "SV001" với "SV002" → Không khớp → Tiếp tục
            Lần 2: So sánh "SV002" với "SV002" → Khớp! → Trả về object SV002
            */
        private ThongTinSinhVien TimSinhVienTheoMa(List<ThongTinSinhVien> danhSach, string maSV)
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
            // Duyệt qua từng sinh viên trong danh sách
            foreach (ThongTinSinhVien sv in danhSach)
            {
                // Lấy mã sinh viên của sinh viên hiện tại
                string maSVHienTai = sv.MaSV;

                // So sánh mã (không phân biệt hoa/thường)
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maSVHienTai, maSV);

                if (khopMa)
                {
                    return sv; // Tìm thấy! Trả về object
                }
            }
            // Duyệt hết mà không thấy
            return null; // Không tìm thấy
        }
        // ==================== PHƯƠNG THỨC KIỂM TRA DỮ LIỆU ====================
        /// <summary>
        /// Kiểm tra dữ liệu sinh viên có hợp lệ không
        /// Validate student data
        /// </summary>
        /// <param name="sv">Sinh viên cần kiểm tra</param>
        /// <returns>true nếu hợp lệ, false nếu không hợp lệ</returns>
        /*
      DANH SÁCH KIỂM TRA:
        1. Họ: Bắt buộc (không rỗng)
        2. Tên: Bắt buộc (không rỗng)
        3. Ngày sinh: Phải hợp lệ (không phải MinValue)
        4. Tuổi: Phải >= 18
        5. Giới tính: Chỉ cho phép "Nam" hoặc "Nữ"
  */
        private bool KiemTraDuLieuHopLe(ThongTinSinhVien sv)
        {
            // ===== KIỂM TRA 1: HỌ (BẮT BUỘC) =====
            bool hoRong = KiemTraChuoiRong(sv.HoSV);

            if (hoRong)
            {
                return false; // Họ rỗng → Không hợp lệ
            }
            // ===== KIỂM TRA 2: TÊN (BẮT BUỘC) =====
            bool tenRong = KiemTraChuoiRong(sv.TenSV);

            if (tenRong)
            {
                return false; // Tên rỗng → Không hợp lệ
            }
            // ===== KIỂM TRA 3: NGÀY SINH (PHẢI HỢP LỆ) =====
            bool ngaySinhHopLe = (sv.NgaySinhSV != DateTime.MinValue);

            if (!ngaySinhHopLe)
            {
                return false; // Ngày sinh không hợp lệ
            }
            // ===== KIỂM TRA 4: TUỔI (>= 18) =====
            int namHienTai = DateTime.Now.Year;
            int namSinh = sv.NgaySinhSV.Year;
            int tuoi = namHienTai - namSinh;
            bool tuoiHopLe = (tuoi >= 18);

            if (!tuoiHopLe)
            {
                return false; // Tuổi không hợp lệ (chưa đủ 18)
            }
            // ===== KIỂM TRA 5: GIỚI TÍNH (NAM HOẶC NỮ) =====
            bool laNam = SoSanhChuoiKhongPhanBietHoaThuong(sv.GioiTinhSV, "Nam");
            bool laNu = SoSanhChuoiKhongPhanBietHoaThuong(sv.GioiTinhSV, "Nữ");
            bool gioiTinhHopLe = laNam || laNu;
            if (!gioiTinhHopLe)
            {
                return false; // Giới tính không hợp lệ
            }
            // Tất cả đều hợp lệ
            return true;
        }
        // ==================== PHƯƠNG THỨC SO SÁNH THAY ĐỔI ====================
        /// <summary>
        /// So sánh thông tin cũ và mới, trả về danh sách các trường đã thay đổi
        /// Compare old and new information, return list of changed fields
        /// </summary>
        /// <param name="svCu">Thông tin cũ</param>
        /// <param name="svMoi">Thông tin mới</param>
        /// <returns>Danh sách tên các trường đã thay đổi</returns>
        /*
         VÍ DỤ:
         svCu: { HoSV="Nguyễn", TenSV="An", EmailSV="an@old.com" }
          svMoi: { HoSV="Trần", TenSV="An", EmailSV="an@new.com" }

          Kết quả: ["Họ", "Email"]
            */
        public List<string> LayDanhSachThayDoi(ThongTinSinhVien svCu, ThongTinSinhVien svMoi)
        {
            // Khởi tạo danh sách kết quả
            List<string> danhSachThayDoi = new List<string>();
            // Kiểm tra null
            if (svCu == null || svMoi == null)
            {
                return danhSachThayDoi; // Trả về list rỗng
            }
            // So sánh từng trường
            // Kiểm tra Họ
            bool hoThayDoi = !SoSanhChuoiChinhXac(svCu.HoSV, svMoi.HoSV);
            if (hoThayDoi)
            {
                danhSachThayDoi.Add("Họ");
            }
            // Kiểm tra Tên lót
            bool tenLotThayDoi = !SoSanhChuoiChinhXac(svCu.TenLotSV, svMoi.TenLotSV);
            if (tenLotThayDoi)
            {
                danhSachThayDoi.Add("Tên lót");
            }
            // Kiểm tra Tên
            bool tenThayDoi = !SoSanhChuoiChinhXac(svCu.TenSV, svMoi.TenSV);
            if (tenThayDoi)
            {
                danhSachThayDoi.Add("Tên");
            }
            // Kiểm tra Ngày sinh
            bool ngaySinhThayDoi = (svCu.NgaySinhSV != svMoi.NgaySinhSV);
            if (ngaySinhThayDoi)
            {
                danhSachThayDoi.Add("Ngày sinh");
            }
            // Kiểm tra Giới tính
            bool gioiTinhThayDoi = !SoSanhChuoiChinhXac(svCu.GioiTinhSV, svMoi.GioiTinhSV);
            if (gioiTinhThayDoi)
            {
                danhSachThayDoi.Add("Giới tính");
            }
            // Kiểm tra CCCD
            bool cccdThayDoi = (svCu.CCCDSV != svMoi.CCCDSV);
            if (cccdThayDoi)
            {
                danhSachThayDoi.Add("CCCD");
            }
            // Kiểm tra Địa chỉ
            bool diaChiThayDoi = !SoSanhChuoiChinhXac(svCu.DiaChiSV, svMoi.DiaChiSV);
            if (diaChiThayDoi)
            {
                danhSachThayDoi.Add("Địa chỉ");
            }
            // Kiểm tra Email
            bool emailThayDoi = !SoSanhChuoiChinhXac(svCu.EmailSV, svMoi.EmailSV);
            if (emailThayDoi)
            {
                danhSachThayDoi.Add("Email");
            }
            // Kiểm tra Lớp
            bool lopThayDoi = !SoSanhChuoiChinhXac(svCu.LopSV, svMoi.LopSV);
            if (lopThayDoi)
            {
                danhSachThayDoi.Add("Lớp");
            }
            // Kiểm tra Trạng thái
            bool trangThaiThayDoi = !SoSanhChuoiChinhXac(svCu.TrangThaiSV, svMoi.TrangThaiSV);
            if (trangThaiThayDoi)
            {
                danhSachThayDoi.Add("Trạng thái");
            }
            return danhSachThayDoi;
        }
        // ==================== PHƯƠNG THỨC SAO CHÉP THÔNG TIN ====================
        /// <summary>
        /// Sao chép thông tin từ sinh viên nguồn sang sinh viên đích
        /// Copy information from source student to destination student
        /// </summary>
        /// <param name="nguon">Sinh viên nguồn (copy từ đây)</param>
        /// <param name="dich">Sinh viên đích (paste vào đây)</param>
        /*
        VÍ DỤ:
        ThongTinSinhVien svA = { HoSV="Nguyễn", TenSV="An" };
        ThongTinSinhVien svB = { HoSV="Trần", TenSV="Bình" };
       
        SaoChepThongTin(svA, svB);
     
        Kết quả: svB = { HoSV="Nguyễn", TenSV="An" }
        */
        public void SaoChepThongTin(ThongTinSinhVien nguon, ThongTinSinhVien dich)
        {
            // Kiểm tra null
            if (nguon == null || dich == null)
            {
                return; // Không làm gì cả
            }
            // Sao chép từng trường từ nguồn sang đích

            dich.HoSV = nguon.HoSV;
            dich.TenLotSV = nguon.TenLotSV;
            dich.TenSV = nguon.TenSV;
            dich.NgaySinhSV = nguon.NgaySinhSV;
            dich.GioiTinhSV = nguon.GioiTinhSV;
            dich.CCCDSV = nguon.CCCDSV;
            dich.DiaChiSV = nguon.DiaChiSV;
            dich.EmailSV = nguon.EmailSV;
            dich.LopSV = nguon.LopSV;
            dich.TrangThaiSV = nguon.TrangThaiSV;
        }
        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================
        // Sử dụng: String operations (Chapter 4 - Programming Techniques)
        /// <summary>
        /// Kiểm tra chuỗi có rỗng không (null hoặc chỉ chứa khoảng trắng)
        /// Check if string is empty (null or whitespace only)
        /// </summary>
        /// <param name="chuoi">Chuỗi cần kiểm tra</param>
        /// <returns>true nếu rỗng, false nếu có nội dung</returns>
        /*
  GIẢI THÍCH:
        - null: Chuỗi không tồn tại
     - "": Chuỗi rỗng
      - " ": Chuỗi chỉ có khoảng trắng
       
        VÍ DỤ:
        KiemTraChuoiRong(null) → true
        KiemTraChuoiRong("") → true
        KiemTraChuoiRong(" ") → true
        KiemTraChuoiRong("An") → false
        */
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
        /// Xóa khoảng trắng thừa ở đầu và cuối chuỗi
        /// Remove leading and trailing whitespace
        /// </summary>
        /// <param name="chuoi">Chuỗi cần xử lý</param>
        /// <returns>Chuỗi đã xóa khoảng trắng thừa</returns>
        /*
        VÍ DỤ:
        XoaKhoangTrangThua(" Nguyễn ") → "Nguyễn"
        XoaKhoangTrangThua("An") → "An"
   */
        private string XoaKhoangTrangThua(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }
            if (chuoi.Length == 0)
            {
                return "";
            }
            // Tìm vị trí ký tự đầu tiên không phải khoảng trắng
            int viTriDau = 0;
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriDau = i;
                    break;
                }
            }
            // Tìm vị trí ký tự cuối cùng không phải khoảng trắng
            int viTriCuoi = chuoi.Length - 1;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriCuoi = i;
                    break;
                }
            }
            // Nếu tất cả đều là khoảng trắng
            if (viTriDau > viTriCuoi)
            {
                return "";
            }
            // Lấy chuỗi con từ viTriDau đến viTriCuoi
            int doDai = viTriCuoi - viTriDau + 1;
            string ketQua = chuoi.Substring(viTriDau, doDai);
            return ketQua;
        }
        /// <summary>
        /// So sánh 2 chuỗi chính xác (phân biệt hoa/thường)
        /// Compare two strings exactly (case-sensitive)
        /// </summary>
        /// <param name="chuoi1">Chuỗi thứ nhất</param>
        /// <param name="chuoi2">Chuỗi thứ hai</param>
        /// <returns>true nếu giống nhau, false nếu khác nhau</returns>
        /*
           VÍ DỤ:
           SoSanhChuoiChinhXac("An", "An") → true
      SoSanhChuoiChinhXac("An", "an") → false
           */
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            // Kiểm tra null
            if (chuoi1 == null && chuoi2 == null)
            {
                return true; // Cả 2 đều null → Giống nhau
            }
            if (chuoi1 == null || chuoi2 == null)
            {
                return false; // 1 cái null, 1 cái không null → Khác nhau
            }
            // Kiểm tra độ dài
            if (chuoi1.Length != chuoi2.Length)
            {
                return false; // Khác độ dài → Khác nhau
            }
            // So sánh từng ký tự
            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                {
                    return false; // Có ký tự khác nhau
                }
            }
            // Tất cả ký tự giống nhau
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
        GIẢI THÍCH:
        - Chuyển cả 2 chuỗi về chữ thường
        - So sánh 2 chuỗi đã chuyển
       
      VÍ DỤ:
        SoSanhChuoiKhongPhanBietHoaThuong("An", "AN") → true
  SoSanhChuoiKhongPhanBietHoaThuong("Nam", "Nữ") → false
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
            // So sánh chính xác
            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }
        /// <summary>
        /// Chuyển chuỗi về chữ thường
        /// Convert string to lowercase
        /// </summary>
        /// <param name="chuoi">Chuỗi cần chuyển</param>
        /// <returns>Chuỗi chữ thường</returns>
        /*
        VÍ DỤ CHẠY TAY:
      ChuyenVeChuThuong("NgUyEn") → "nguyen"
       
    Cách hoạt động:
  - Duyệt từng ký tự
        - Nếu là chữ HOA (A-Z) → Chuyển thành chữ thường
        - Các ký tự khác giữ nguyên
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
                if (kyTu >= 'A' && kyTu <= 'Z')
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
        /// Kiểm tra chuỗi có chứa chuỗi con không
        /// Check if string contains substring
        /// </summary>
        /// <param name="chuoiGoc">Chuỗi gốc</param>
        /// <param name="chuoiCon">Chuỗi con cần tìm</param>
        /// <returns>true nếu chứa, false nếu không chứa</returns>
        /*
        VÍ DỤ:
        KiemTraChuaChuoiCon("nguyenvanan@gmail.com", "@") → true
        KiemTraChuaChuoiCon("nguyenvanan", "@") → false
        */
        private bool KiemTraChuaChuoiCon(string chuoiGoc, string chuoiCon)
        {
            if (chuoiGoc == null || chuoiCon == null)
            {
                return false;
            }
            if (chuoiCon.Length > chuoiGoc.Length)
            {
                return false; // Chuỗi con dài hơn chuỗi gốc → Không thể chứa
            }
            // Duyệt qua từng vị trí có thể bắt đầu chuỗi con
            for (int i = 0; i <= chuoiGoc.Length - chuoiCon.Length; i++)
            {
                bool khop = true;
                // Kiểm tra chuỗi con từ vị trí i
                for (int j = 0; j < chuoiCon.Length; j++)
                {
                    if (chuoiGoc[i + j] != chuoiCon[j])
                    {
                        khop = false;
                        break;
                    }
                }
                if (khop)
                {
                    return true; // Tìm thấy chuỗi con
                }
            }
            return false; // Không tìm thấy
        }
        /*
        ==================== TÓM TẮT CHO SINH VIÊN ====================
     
        1. CHỨC NĂNG CHÍNH: SuaThongTinSinhVien()
           - Tìm sinh viên theo mã
- Kiểm tra dữ liệu mới
           - Cập nhật thông tin
       
   2. TẠI SAO CẬP NHẬT LẠI ẢNH HƯỞNG LIST?
  - List chứa reference (địa chỉ) đến object
     - Sửa object = sửa trực tiếp ở địa chỉ đó
      - List tự động có data mới!
       
        3. CÁC METHOD BỔ TRỢ:
   - SuaHo(), SuaTen(), ... : Sửa từng trường
       - TimSinhVienTheoMa(): Sequential Search
 - KiemTraDuLieuHopLe(): Validation
- LayDanhSachThayDoi(): So sánh old vs new
        - SaoChepThongTin(): Copy data
        4. CÁC METHOD XỬ LÝ CHUỖI TỰ CODE:
   - KiemTraChuoiRong(): Kiểm tra null/empty/whitespace
   - XoaKhoangTrangThua(): Trim thủ công
     - SoSanhChuoiChinhXac(): So sánh phân biệt hoa/thường
     - SoSanhChuoiKhongPhanBietHoaThuong(): So sánh không phân biệt
      - ChuyenVeChuThuong(): Lowercase thủ công
     - KiemTraChuaChuoiCon(): Contains thủ công
   
        5. KIẾN THỨC ÁP DỤNG:
  - OOP: Classes, Objects, Methods
           - DSA1: Sequential Search, Modify Element
   - String operations: Tự code toàn bộ
           - Character manipulation: ASCII code
       
        ==================== END TÓM TẮT ====================
        */
    }
}