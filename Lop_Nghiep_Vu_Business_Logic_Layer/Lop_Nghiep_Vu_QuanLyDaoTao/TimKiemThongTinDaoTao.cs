using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    public class ChucNangTimKiemThongTinDaoTao
    {
        public List<ThongTinDaoTao> TimKiemTheoMa(List<ThongTinDaoTao> danhSach, string ma)
        {
            List<ThongTinDaoTao> ketQua = new List<ThongTinDaoTao>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.MaChuongTrinh.ToLower().Contains(ma.ToLower()))
                    ketQua.Add(ct);
            }
            return ketQua;
        }

        public List<ThongTinDaoTao> TimKiemTheoKhoa(List<ThongTinDaoTao> danhSach, string khoa)
        {
            List<ThongTinDaoTao> ketQua = new List<ThongTinDaoTao>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.Khoa.ToLower().Contains(khoa.ToLower()))
                    ketQua.Add(ct);
            }
            return ketQua;
        }

        public List<ThongTinDaoTao> TimKiemTheoBac(List<ThongTinDaoTao> danhSach, string bac)
        {
            List<ThongTinDaoTao> ketQua = new List<ThongTinDaoTao>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.BacDaoTao.ToLower().Contains(bac.ToLower()))
                    ketQua.Add(ct);
            }
            return ketQua;
        }
    }
}
