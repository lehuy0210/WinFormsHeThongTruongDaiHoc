using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS QUẢN LÝ DANH SÁCH ĐIỂM (DTO) ====================
    public class QuanLyDiem
    {
        private List<ThongTinDiem> danhSachDiem;

        public QuanLyDiem()
        {
            danhSachDiem = new List<ThongTinDiem>();
        }

        public List<ThongTinDiem> LayDanhSachDiem()
        {
            return danhSachDiem;
        }

        public int LaySoLuongDiem()
        {
            return danhSachDiem.Count;
        }

        public void CapNhatDanhSach(List<ThongTinDiem> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachDiem = danhSachMoi;
            }
        }
    }
}
