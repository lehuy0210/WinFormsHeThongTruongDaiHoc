using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // ==================== CLASS CHỨC NĂNG THÊM HỒ SƠ (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG: Tương tự ThemThongTinSinhVien.cs
    //    - OOP: Classes, Methods, Objects
    //    - DSA1: Sequential Search, Insert operation
    //    - Database Programming: BLL Pattern
    //
    // 🎯 MỤC ĐÍCH: Thêm hồ sơ mới với validation
    //
    // 💡 ALGORITHM:
    // 1. Kiểm tra null
    // 2. Kiểm tra mã hồ sơ trùng (Sequential Search)
    // 3. Validation: Mã, Loại, Ngày nộp, Trạng thái
    // 4. Add vào List
    //
    public class ChucNangThemThongTinHoSo
    {
        public bool ThemHoSo(List<ThongTinHoSo> danhSach, ThongTinHoSo hoSoMoi)
        {
            // Kiểm tra null
            if (hoSoMoi == null || danhSach == null) return false;

            // Kiểm tra trùng mã
            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.MaHoSo.ToLower() == hoSoMoi.MaHoSo.ToLower())
                    return false; // Mã đã tồn tại
            }

            // Validation
            if (string.IsNullOrWhiteSpace(hoSoMoi.MaHoSo)) return false;
            if (string.IsNullOrWhiteSpace(hoSoMoi.LoaiHoSo)) return false;
            if (hoSoMoi.NgayNop == DateTime.MinValue) return false;

            // Thêm vào danh sách
            danhSach.Add(hoSoMoi);
            return true;
        }

        // Tạo mã hồ sơ tự động: HS-[LoaiHS]-[Nam]-[SoThuTu]
        public string TaoMaHoSoTuDong(List<ThongTinHoSo> danhSach, string loaiHoSo)
        {
            int nam = DateTime.Now.Year;
            string prefix = $"HS-{loaiHoSo.Substring(0, 2).ToUpper()}-{nam}-";
            
            int maxSo = 0;
            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.MaHoSo.StartsWith(prefix))
                {
                    string soStr = hs.MaHoSo.Replace(prefix, "");
                    if (int.TryParse(soStr, out int so) && so > maxSo)
                        maxSo = so;
                }
            }

            return prefix + (maxSo + 1).ToString("D3"); // Format: 001, 002,...
        }
    }
}
