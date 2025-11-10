using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ THỜI KHÓA BIỂU (DTO) ====================
    public class QuanLyThoiKhoaBieu
    {
        private List<ThongTinThoiKhoaBieu> danhSachTKB;

        public QuanLyThoiKhoaBieu()
        {
            danhSachTKB = new List<ThongTinThoiKhoaBieu>();
        }

        public List<ThongTinThoiKhoaBieu> LayDanhSachTKB()
        {
            return danhSachTKB;
        }

        public int LaySoLuongTKB()
        {
            return danhSachTKB.Count;
        }

        public void CapNhatDanhSach(List<ThongTinThoiKhoaBieu> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachTKB = danhSachMoi;
            }
        }
    }
}
