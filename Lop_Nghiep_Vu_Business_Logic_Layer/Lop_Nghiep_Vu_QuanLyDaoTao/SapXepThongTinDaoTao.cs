using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    public class ChucNangSapXepThongTinDaoTao
    {
        public void SapXepTheoMa(List<ThongTinDaoTao> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            // Bubble Sort
            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? string.Compare(danhSach[j].MaChuongTrinh, danhSach[j + 1].MaChuongTrinh) > 0
                        : string.Compare(danhSach[j].MaChuongTrinh, danhSach[j + 1].MaChuongTrinh) < 0;

                    if (swap)
                    {
                        ThongTinDaoTao temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        public void SapXepTheoNam(List<ThongTinDaoTao> danhSach, bool tangDan)
        {
            if (danhSach == null || danhSach.Count <= 1) return;

            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                for (int j = 0; j < danhSach.Count - i - 1; j++)
                {
                    bool swap = tangDan
                        ? danhSach[j].NamBatDau > danhSach[j + 1].NamBatDau
                        : danhSach[j].NamBatDau < danhSach[j + 1].NamBatDau;

                    if (swap)
                    {
                        ThongTinDaoTao temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }
    }
}
