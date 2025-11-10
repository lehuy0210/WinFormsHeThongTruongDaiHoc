using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH LỊCH THI (DTO) ====================
    public class QuanLyLichThi
    {
        private List<ThongTinLichThi> danhSachLichThi;

        public QuanLyLichThi()
        {
            danhSachLichThi = new List<ThongTinLichThi>();
        }

        public List<ThongTinLichThi> LayDanhSachLichThi()
        {
            return danhSachLichThi;
        }

        public int LaySoLuongLichThi()
        {
            return danhSachLichThi.Count;
        }

        public void CapNhatDanhSach(List<ThongTinLichThi> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachLichThi = danhSachMoi;
            }
        }
    }
}
