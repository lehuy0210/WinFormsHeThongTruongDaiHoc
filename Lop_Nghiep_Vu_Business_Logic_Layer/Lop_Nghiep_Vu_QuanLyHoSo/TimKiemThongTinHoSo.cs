using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo
{
    // CLASS TÌM KIẾM HỒ SƠ (BLL)
    // Kiến thức: Sequential Search, String operations
    public class ChucNangTimKiemThongTinHoSo
    {
        public List<ThongTinHoSo> TimKiemTheoMa(List<ThongTinHoSo> danhSach, string maHoSo)
        {
            List<ThongTinHoSo> ketQua = new List<ThongTinHoSo>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.MaHoSo.ToLower().Contains(maHoSo.ToLower()))
                    ketQua.Add(hs);
            }

            return ketQua;
        }

        public List<ThongTinHoSo> TimKiemTheoLoai(List<ThongTinHoSo> danhSach, string loaiHoSo)
        {
            List<ThongTinHoSo> ketQua = new List<ThongTinHoSo>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.LoaiHoSo.ToLower().Contains(loaiHoSo.ToLower()))
                    ketQua.Add(hs);
            }

            return ketQua;
        }

        public List<ThongTinHoSo> TimKiemTheoTrangThai(List<ThongTinHoSo> danhSach, string trangThai)
        {
            List<ThongTinHoSo> ketQua = new List<ThongTinHoSo>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinHoSo hs in danhSach)
            {
                if (hs.TrangThai.ToLower().Contains(trangThai.ToLower()))
                    ketQua.Add(hs);
            }

            return ketQua;
        }
    }
}
