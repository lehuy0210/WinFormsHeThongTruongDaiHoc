using System.Collections.Generic;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    public class QuanLyXetThiDua
    {
        private List<ThongTinXetThiDua> danhSachXetThiDua;

        public QuanLyXetThiDua()
        {
            danhSachXetThiDua = new List<ThongTinXetThiDua>();
        }

        public List<ThongTinXetThiDua> LayDanhSachXetThiDua()
        {
            return danhSachXetThiDua;
        }

        public int LaySoLuongDanhGia()
        {
            return danhSachXetThiDua.Count;
        }

        public void CapNhatDanhSach(List<ThongTinXetThiDua> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                danhSachXetThiDua = danhSachMoi;
            }
        }
    }
}
