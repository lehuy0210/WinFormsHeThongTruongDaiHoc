using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyDaoTao
{
    // CLASS THÊM CHƯƠNG TRÌNH ĐÀO TẠO (BLL)
    // Kiến thức: OOP, Sequential Search, Validation
    public class ChucNangThemThongTinDaoTao
    {
        public bool ThemChuongTrinh(List<ThongTinDaoTao> danhSach, ThongTinDaoTao chuongTrinhMoi)
        {
            // Kiểm tra null
            if (chuongTrinhMoi == null || danhSach == null) return false;

            // Kiểm tra trùng mã
            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.MaChuongTrinh.ToLower() == chuongTrinhMoi.MaChuongTrinh.ToLower())
                    return false;
            }

            // Validation
            if (string.IsNullOrWhiteSpace(chuongTrinhMoi.MaChuongTrinh)) return false;
            if (string.IsNullOrWhiteSpace(chuongTrinhMoi.TenChuongTrinh)) return false;
            if (chuongTrinhMoi.SoNamDaoTao <= 0) return false;
            if (chuongTrinhMoi.TongTinChi <= 0) return false;

            // Thêm vào danh sách
            danhSach.Add(chuongTrinhMoi);
            return true;
        }

        // Tạo mã tự động: [Khoa][Nam]
        public string TaoMaChuongTrinhTuDong(List<ThongTinDaoTao> danhSach, string khoa, int nam)
        {
            string prefix = khoa.ToUpper().Substring(0, Math.Min(4, khoa.Length)) + nam;
            int soThuTu = 1;

            foreach (ThongTinDaoTao ct in danhSach)
            {
                if (ct.MaChuongTrinh.StartsWith(prefix))
                    soThuTu++;
            }

            return prefix + soThuTu.ToString("D2");
        }
    }
}
