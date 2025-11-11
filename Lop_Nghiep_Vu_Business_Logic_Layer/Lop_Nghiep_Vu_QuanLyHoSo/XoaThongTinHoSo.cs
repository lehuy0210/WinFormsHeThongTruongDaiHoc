using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // CLASS XÓA HỒ SƠ (BLL)
    // Kiến thức: Sequential Search, List.Remove()
    public class ChucNangXoaThongTinHoSo
    {
        public bool XoaHoSo(List<ThongTinHoSo> danhSach, string maHoSo)
        {
            if (danhSach == null || string.IsNullOrWhiteSpace(maHoSo)) return false;

            // Tìm hồ sơ cần xóa
            ThongTinHoSo hoSoCanXoa = null;
            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.MaHoSo.ToLower() == maHoSo.ToLower())
                {
                    hoSoCanXoa = hs;
                    break;
                }
            }

            if (hoSoCanXoa != null)
            {
                danhSach.Remove(hoSoCanXoa);
                return true;
            }

            return false;
        }
    }
}
