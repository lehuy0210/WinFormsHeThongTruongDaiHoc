using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // CLASS SẮP XẾP HỒ SƠ (BLL)
    // Kiến thức: Sorting algorithms - Bubble Sort
    public class ChucNangSapXepThongTinHoSo
    {
        public void SapXepTheoMa(List<ThongTinHoSo> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            // Bubble Sort
            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? string.Compare(danhSach[j].MaHoSo, danhSach[j + 1].MaHoSo) > 0
                        : string.Compare(danhSach[j].MaHoSo, danhSach[j + 1].MaHoSo) < 0;

                    if (swap)
                    {
                        ThongTinHoSo temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        public void SapXepTheoNgayNop(List<ThongTinHoSo> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? danhSach[j].NgayNop > danhSach[j + 1].NgayNop
                        : danhSach[j].NgayNop < danhSach[j + 1].NgayNop;

                    if (swap)
                    {
                        ThongTinHoSo temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }
    }
}
