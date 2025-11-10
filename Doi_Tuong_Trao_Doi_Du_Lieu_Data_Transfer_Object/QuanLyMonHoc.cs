using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH MÔN HỌC (DTO) ====================
    public class QuanLyMonHoc
    {
        private List<ThongTinMonHoc> danhSachMonHoc;

        public QuanLyMonHoc()
        {
            danhSachMonHoc = new List<ThongTinMonHoc>();
        }

        public List<ThongTinMonHoc> LayDanhSachMonHoc()
        {
            return danhSachMonHoc;
        }

        public int LaySoLuongMonHoc()
        {
            return danhSachMonHoc.Count;
        }

        public void CapNhatDanhSach(List<ThongTinMonHoc> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachMonHoc = danhSachMoi;
            }
        }
    }
}
