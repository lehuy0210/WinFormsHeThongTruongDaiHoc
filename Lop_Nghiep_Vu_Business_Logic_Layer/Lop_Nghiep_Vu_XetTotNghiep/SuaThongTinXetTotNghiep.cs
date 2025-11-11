using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    public class ChucNangSuaThongTinXetTotNghiep
    {
        public bool SuaKetQuaXet(List<ThongTinXetTotNghiep> danhSach, string maSinhVien, string hocKy, ThongTinXetTotNghiep kqMoi)
        {
            if (danhSach == null || kqMoi == null) return false;

            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].MaSinhVien.ToLower() == maSinhVien.ToLower() &&
                    danhSach[i].HocKyTotNghiep == hocKy)
                {
                    // Tự động đánh giá lại điều kiện tốt nghiệp
                    ChucNangThemThongTinXetTotNghiep chucNangThem = new ChucNangThemThongTinXetTotNghiep();
                    kqMoi = chucNangThem.DanhGiaDieuKienTotNghiep(kqMoi);

                    danhSach[i] = kqMoi;
                    return true;
                }
            }
            return false;
        }
    }
}
