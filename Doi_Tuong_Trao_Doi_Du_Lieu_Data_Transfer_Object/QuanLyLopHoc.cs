using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH LỚP HỌC (DTO) ====================
    public class QuanLyLopHoc
    {
        private List<ThongTinLopHoc> danhSachLopHoc;

        public QuanLyLopHoc()
        {
            danhSachLopHoc = new List<ThongTinLopHoc>();
        }

        public List<ThongTinLopHoc> LayDanhSachLopHoc()
        {
            return danhSachLopHoc;
        }

        public int LaySoLuongLopHoc()
        {
            return danhSachLopHoc.Count;
        }

        public void CapNhatDanhSach(List<ThongTinLopHoc> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachLopHoc = danhSachMoi;
            }
        }
    }
}
