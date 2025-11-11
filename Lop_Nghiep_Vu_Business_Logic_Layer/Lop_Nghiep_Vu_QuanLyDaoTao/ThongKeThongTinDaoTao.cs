using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    public class ChucNangThongKeThongTinDaoTao
    {
        public Dictionary<string, int> ThongKeTheoKhoa(List<ThongTinDaoTao> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (thongKe.ContainsKey(ct.Khoa))
                    thongKe[ct.Khoa]++;
                else
                    thongKe[ct.Khoa] = 1;
            }
            return thongKe;
        }

        public Dictionary<string, int> ThongKeTheoBac(List<ThongTinDaoTao> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (thongKe.ContainsKey(ct.BacDaoTao))
                    thongKe[ct.BacDaoTao]++;
                else
                    thongKe[ct.BacDaoTao] = 1;
            }
            return thongKe;
        }

        public int DemChuongTrinhTheoKhoa(List<ThongTinDaoTao> danhSach, string khoa)
        {
            if (danhSach == null) return 0;
            int dem = 0;
            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.Khoa.ToLower() == khoa.ToLower())
                    dem++;
            }
            return dem;
        }
    }
}
