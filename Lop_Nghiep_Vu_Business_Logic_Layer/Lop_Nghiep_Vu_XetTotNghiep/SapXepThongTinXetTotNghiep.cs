using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    public class ChucNangSapXepThongTinXetTotNghiep
    {
        public void SapXepTheoGPA(List<ThongTinXetTotNghiep> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? danhSach[j].DiemTrungBinhTichLuy > danhSach[j + 1].DiemTrungBinhTichLuy
                        : danhSach[j].DiemTrungBinhTichLuy < danhSach[j + 1].DiemTrungBinhTichLuy;

                    if (swap)
                    {
                        ThongTinXetTotNghiep temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        public void SapXepTheoNgayXet(List<ThongTinXetTotNghiep> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? danhSach[j].NgayXet > danhSach[j + 1].NgayXet
                        : danhSach[j].NgayXet < danhSach[j + 1].NgayXet;

                    if (swap)
                    {
                        ThongTinXetTotNghiep temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }
    }
}
