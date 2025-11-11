using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    public class ChucNangTimKiemThongTinXetTotNghiep
    {
        public List<ThongTinXetTotNghiep> TimKiemTheoMaSinhVien(List<ThongTinXetTotNghiep> danhSach, string maSV)
        {
            List<ThongTinXetTotNghiep> ketQua = new List<ThongTinXetTotNghiep>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.MaSinhVien.ToLower().Contains(maSV.ToLower()))
                    ketQua.Add(kq);
            }
            return ketQua;
        }

        public List<ThongTinXetTotNghiep> TimKiemTheoKhoa(List<ThongTinXetTotNghiep> danhSach, string khoa)
        {
            List<ThongTinXetTotNghiep> ketQua = new List<ThongTinXetTotNghiep>();
            if (danhSach == null) return ketQua;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.Khoa.ToLower().Contains(khoa.ToLower()))
                    ketQua.Add(kq);
            }
            return ketQua;
        }

        public List<ThongTinXetTotNghiep> TimKiemTheoKetQua(List<ThongTinXetTotNghiep> danhSach, string ketQua)
        {
            List<ThongTinXetTotNghiep> result = new List<ThongTinXetTotNghiep>();
            if (danhSach == null) return result;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.KetQuaXet.ToLower().Contains(ketQua.ToLower()))
                    result.Add(kq);
            }
            return result;
        }

        public List<ThongTinXetTotNghiep> TimKiemTheoXepLoai(List<ThongTinXetTotNghiep> danhSach, string xepLoai)
        {
            List<ThongTinXetTotNghiep> result = new List<ThongTinXetTotNghiep>();
            if (danhSach == null) return result;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.XepLoaiTotNghiep.ToLower().Contains(xepLoai.ToLower()))
                    result.Add(kq);
            }
            return result;
        }
    }
}
