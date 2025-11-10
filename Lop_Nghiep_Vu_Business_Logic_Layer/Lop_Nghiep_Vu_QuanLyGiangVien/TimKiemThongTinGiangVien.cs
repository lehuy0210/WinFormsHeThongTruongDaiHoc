using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG TÌM KIẾM GIẢNG VIÊN (BLL) ====================
    public class ChucNangTimKiemThongTinGiangVien
    {
        public List<ThongTinGiangVien> TimKiemGiangVien(List<ThongTinGiangVien> danhSach,
                     ThongTinGiangVien tieuChi)
        {
            List<ThongTinGiangVien> ketQua = new List<ThongTinGiangVien>();

            if (danhSach == null) return ketQua;
            if (tieuChi == null) return ketQua;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                bool khopTieuChi = KiemTraKhopTieuChi(gv, tieuChi);

                if (khopTieuChi)
                {
                    ketQua.Add(gv);
                }
            }

            return ketQua;
        }

        public ThongTinGiangVien TimTheoMaGV(List<ThongTinGiangVien> danhSach, string maGV)
        {
            if (danhSach == null) return null;

            bool maRong = KiemTraChuoiRong(maGV);
            if (maRong) return null;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string maGVHienTai = gv.MaGV;

                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maGVHienTai, maGV);

                if (khopMa)
                {
                    return gv;
                }
            }

            return null;
        }

        public List<ThongTinGiangVien> TimTheoHoTen(List<ThongTinGiangVien> danhSach, string hoTen)
        {
            List<ThongTinGiangVien> ketQua = new List<ThongTinGiangVien>();

            if (danhSach == null) return ketQua;

            bool hoTenRong = KiemTraChuoiRong(hoTen);
            if (hoTenRong) return ketQua;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string hoGVHienTai = gv.HoGV;
                string tenGVHienTai = gv.TenGV;

                bool khopHo = CoChucHocTrongChuoi(hoGVHienTai, hoTen);
                bool khopTen = CoChucHocTrongChuoi(tenGVHienTai, hoTen);

                if (khopHo || khopTen)
                {
                    ketQua.Add(gv);
                }
            }

            return ketQua;
        }

        public List<ThongTinGiangVien> TimTheoKhoa(List<ThongTinGiangVien> danhSach, string khoa)
        {
            List<ThongTinGiangVien> ketQua = new List<ThongTinGiangVien>();

            if (danhSach == null) return ketQua;

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong) return ketQua;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string khoaGVHienTai = gv.KhoaGV;

                bool khopKhoa = SoSanhChuoiKhongPhanBietHoaThuong(khoaGVHienTai, khoa);

                if (khopKhoa)
                {
                    ketQua.Add(gv);
                }
            }

            return ketQua;
        }

        public List<ThongTinGiangVien> TimTheoTrangThai(List<ThongTinGiangVien> danhSach, string trangThai)
        {
            List<ThongTinGiangVien> ketQua = new List<ThongTinGiangVien>();

            if (danhSach == null) return ketQua;

            bool trangThaiRong = KiemTraChuoiRong(trangThai);
            if (trangThaiRong) return ketQua;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string trangThaiGVHienTai = gv.TrangThaiGV;

                bool khopTrangThai = SoSanhChuoiKhongPhanBietHoaThuong(trangThaiGVHienTai, trangThai);

                if (khopTrangThai)
                {
                    ketQua.Add(gv);
                }
            }

            return ketQua;
        }

        private bool KiemTraKhopTieuChi(ThongTinGiangVien gv, ThongTinGiangVien tieuChi)
        {
            if (!KiemTraChuoiRong(tieuChi.TenGV))
            {
                bool khopTen = CoChucHocTrongChuoi(gv.TenGV, tieuChi.TenGV);
                if (!khopTen) return false;
            }

            if (!KiemTraChuoiRong(tieuChi.HoGV))
            {
                bool khopHo = CoChucHocTrongChuoi(gv.HoGV, tieuChi.HoGV);
                if (!khopHo) return false;
            }

            if (!KiemTraChuoiRong(tieuChi.KhoaGV))
            {
                bool khopKhoa = SoSanhChuoiKhongPhanBietHoaThuong(gv.KhoaGV, tieuChi.KhoaGV);
                if (!khopKhoa) return false;
            }

            if (!KiemTraChuoiRong(tieuChi.TrangThaiGV))
            {
                bool khopTrangThai = SoSanhChuoiKhongPhanBietHoaThuong(gv.TrangThaiGV, tieuChi.TrangThaiGV);
                if (!khopTrangThai) return false;
            }

            return true;
        }

        private bool CoChucHocTrongChuoi(string chuoiGoc, string chuoiTim)
        {
            if (KiemTraChuoiRong(chuoiGoc)) return false;
            if (KiemTraChuoiRong(chuoiTim)) return false;

            string chuoiGocThuong = ChuyenVeChuThuong(chuoiGoc);
            string chuoiTimThuong = ChuyenVeChuThuong(chuoiTim);

            for (int i = 0; i <= chuoiGocThuong.Length - chuoiTimThuong.Length; i++)
            {
                bool khop = true;

                for (int j = 0; j < chuoiTimThuong.Length; j++)
                {
                    if (chuoiGocThuong[i + j] != chuoiTimThuong[j])
                    {
                        khop = false;
                        break;
                    }
                }

                if (khop) return true;
            }

            return false;
        }

        private bool KiemTraChuoiRong(string chuoi)
        {
            if (chuoi == null) return true;
            if (chuoi.Length == 0) return true;

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    return false;
                }
            }
            return true;
        }

        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null) return true;
            if (chuoi1 == null || chuoi2 == null) return false;

            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null) return true;
            if (chuoi1 == null || chuoi2 == null) return false;

            if (chuoi1.Length != chuoi2.Length) return false;

            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i]) return false;
            }
            return true;
        }

        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null) return "";

            string ketQua = "";
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
                    char kyTuThuong = (char)(kyTu + 32);
                    ketQua += kyTuThuong;
                }
                else
                {
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }
    }
}
