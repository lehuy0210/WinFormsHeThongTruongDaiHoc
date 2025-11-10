using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH GIẢNG VIÊN (DTO) ====================
    public class QuanLyGiangVien
    {
        // ==================== THUỘC TÍNH ====================
        private List<ThongTinGiangVien> danhSachGiangVien;

        // ==================== CONSTRUCTOR ====================
        public QuanLyGiangVien()
        {
            danhSachGiangVien = new List<ThongTinGiangVien>();
        }

        // ==================== GETTER METHODS ====================

        /// <summary>
        /// Lấy danh sách giảng viên
        /// </summary>
        public List<ThongTinGiangVien> LayDanhSachGiangVien()
        {
            return danhSachGiangVien;
        }

        /// <summary>
        /// Lấy số lượng giảng viên
        /// </summary>
        public int LaySoLuongGiangVien()
        {
            return danhSachGiangVien.Count;
        }

        // ==================== SETTER METHOD ====================

        /// <summary>
        /// Cập nhật toàn bộ danh sách giảng viên
        /// </summary>
        public void CapNhatDanhSach(List<ThongTinGiangVien> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachGiangVien = danhSachMoi;
            }
        }
    }
}
