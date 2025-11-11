using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    public class ChucNangXoaThongTinDaoTao
    {
        public bool XoaChuongTrinh(List<ThongTinDaoTao> danhSach, string maChuongTrinh)
        {
            if (danhSach == null || string.IsNullOrWhiteSpace(maChuongTrinh)) return false;

            ThongTinDaoTao ctCanXoa = null;
            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.MaChuongTrinh.ToLower() == maChuongTrinh.ToLower())
                {
                    ctCanXoa = ct;
                    break;
                }
            }

            if (ctCanXoa != null)
            {
                danhSach.Remove(ctCanXoa);
                return true;
            }
            return false;
        }
    }
}
