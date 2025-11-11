using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    public class ChucNangSuaThongTinDaoTao
    {
        public bool SuaChuongTrinh(List<ThongTinDaoTao> danhSach, string maCu, ThongTinDaoTao ctMoi)
        {
            if (danhSach == null || ctMoi == null) return false;

            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].MaChuongTrinh.ToLower() == maCu.ToLower())
                {
                    danhSach[i] = ctMoi;
                    return true;
                }
            }
            return false;
        }
    }
}
