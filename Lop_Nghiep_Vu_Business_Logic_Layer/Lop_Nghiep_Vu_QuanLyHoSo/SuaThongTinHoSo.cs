using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // CLASS SỬA HỒ SƠ (BLL)
    // Kiến thức: Sequential Search, Object reference update
    public class ChucNangSuaThongTinHoSo
    {
        public bool SuaHoSo(List<ThongTinHoSo> danhSach, string maHoSoCu, ThongTinHoSo hoSoMoi)
        {
            if (danhSach == null || hoSoMoi == null) return false;

            // Tìm hồ sơ cần sửa
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].MaHoSo.ToLower() == maHoSoCu.ToLower())
                {
                    // Cập nhật thông tin
                    danhSach[i] = hoSoMoi;
                    return true;
                }
            }

            return false;
        }
    }
}
