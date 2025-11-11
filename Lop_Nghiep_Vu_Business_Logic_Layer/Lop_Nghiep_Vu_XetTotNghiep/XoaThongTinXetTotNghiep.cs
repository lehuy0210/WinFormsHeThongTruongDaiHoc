using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    public class ChucNangXoaThongTinXetTotNghiep
    {
        public bool XoaKetQuaXet(List<ThongTinXetTotNghiep> danhSach, string maSinhVien, string hocKy)
        {
            if (danhSach == null || string.IsNullOrWhiteSpace(maSinhVien)) return false;

            ThongTinXetTotNghiep kqCanXoa = null;
            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.MaSinhVien.ToLower() == maSinhVien.ToLower() &&
                    kq.HocKyTotNghiep == hocKy)
                {
                    kqCanXoa = kq;
                    break;
                }
            }

            if (kqCanXoa != null)
            {
                danhSach.Remove(kqCanXoa);
                return true;
            }
            return false;
        }
    }
}
