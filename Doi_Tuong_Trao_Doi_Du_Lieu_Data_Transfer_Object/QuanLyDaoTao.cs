using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH ĐÀO TẠO (DTO) ====================
    // Tương tự QuanLySinhVien, QuanLyGiangVien
    // Sử dụng: Classes and Objects (Chapter 2 - OOP)
    //          Encapsulation (Chapter 2.3 - OOP)
    //          List<T> (Chapter 1.1 - DSA1)
    public class QuanLyDaoTao
    {
        // ==================== THUỘC TÍNH ====================
        // Danh sách chương trình đào tạo (PRIVATE - Encapsulation)
        private List<ThongTinDaoTao> danhSachChuongTrinh;

        /*
        Nguyên tắc Encapsulation (Đóng gói):
        - Che giấu dữ liệu bên trong
        - Chỉ truy cập qua các phương thức public
        - Bảo vệ tính toàn vẹn dữ liệu
        
        NOTE: Class này chỉ quản lý danh sách, KHÔNG chứa logic nghiệp vụ
        */

        // ==================== CONSTRUCTOR ====================
        /// <summary>
        /// Constructor - Khởi tạo đối tượng QuanLyDaoTao
        /// </summary>
        public QuanLyDaoTao()
        {
            // Khởi tạo danh sách rỗng
            danhSachChuongTrinh = new List<ThongTinDaoTao>();
        }

        // ==================== GETTER METHODS ====================
        /// <summary>
        /// Lấy danh sách chương trình đào tạo
        /// </summary>
        /// <returns>Danh sách chương trình (Reference)</returns>
        public List<ThongTinDaoTao> LayDanhSachChuongTrinh()
        {
            return danhSachChuongTrinh;
        }

        /// <summary>
        /// Lấy số lượng chương trình đào tạo
        /// </summary>
        /// <returns>Số lượng chương trình trong danh sách</returns>
        public int LaySoLuongChuongTrinh()
        {
            return danhSachChuongTrinh.Count;
        }

        // ==================== SETTER METHOD ====================
        /// <summary>
        /// Cập nhật toàn bộ danh sách chương trình đào tạo
        /// </summary>
        /// <param name="danhSachMoi">Danh sách chương trình mới</param>
        public void CapNhatDanhSach(List<ThongTinDaoTao> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachChuongTrinh = danhSachMoi;
            }
        }

        /*
        ==================== BUSINESS LOGIC ĐÃ ĐƯỢC DI CHUYỂN ====================
        
        ❌ ĐÃ XÓA - Các phương thức sau đã được di chuyển sang BLL:
        
        1. ThemChuongTrinh()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\ThemThongTinDaoTao.cs
           
        2. XoaChuongTrinh()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\XoaThongTinDaoTao.cs
           
        3. SuaThongTinChuongTrinh()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\SuaThongTinDaoTao.cs
           
        4. TimKiemChuongTrinh()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\TimKiemThongTinDaoTao.cs
           
        5. SapXepTheoMa(), SapXepTheoNam()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\SapXepThongTinDaoTao.cs
           
        6. ThongKeTheoBac(), ThongKeTheoKhoa()
           → Di chuyển sang: Lop_Nghiep_Vu_QuanLyDaoTao\ThongKeThongTinDaoTao.cs
        
        ==================== CÁCH SỬ DỤNG SAU KHI REFACTOR ====================
        
        // Trước (SAI - vi phạm kiến trúc):
        QuanLyDaoTao qldt = new QuanLyDaoTao();
        qldt.ThemChuongTrinh(ct);  // ❌ DTO không nên có logic
        
        // Sau (ĐÚNG - theo kiến trúc N-Layer):
        QuanLyDaoTao qldt = new QuanLyDaoTao();
        ChucNangThemThongTinDaoTao themDT = new ChucNangThemThongTinDaoTao();
        themDT.ThemChuongTrinh(qldt.LayDanhSachChuongTrinh(), ct);  // ✅ Logic ở BLL
        
        ==================== END OF REFACTORING NOTES ====================
        */
    }
}
