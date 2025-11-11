using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // CLASS THỐNG KÊ HỒ SƠ (BLL)
    // Kiến thức: Counting, Dictionary (hoặc tự code)
    public class ChucNangThongKeThongTinHoSo
    {
        public Dictionary<string, int> ThongKeTheoLoai(List<ThongTinHoSo> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinHoSo hs in danhSach)
            {
                if (thongKe.ContainsKey(hs.LoaiHoSo))
                    thongKe[hs.LoaiHoSo]++;
                else
                    thongKe[hs.LoaiHoSo] = 1;
            }

            return thongKe;
        }

        public Dictionary<string, int> ThongKeTheoTrangThai(List<ThongTinHoSo> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinHoSo hs in danhSach)
            {
                if (thongKe.ContainsKey(hs.TrangThai))
                    thongKe[hs.TrangThai]++;
                else
                    thongKe[hs.TrangThai] = 1;
            }

            return thongKe;
        }

        public int DemHoSoTheoLoai(List<ThongTinHoSo> danhSach, string loaiHoSo)
        {
            if (danhSach == null) return 0;

            int dem = 0;
            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.LoaiHoSo.ToLower() == loaiHoSo.ToLower())
                    dem++;
            }

            return dem;
        }
    }
}
