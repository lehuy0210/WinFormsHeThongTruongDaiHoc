using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG SỬA GIẢNG VIÊN (BLL) ====================
    public class ChucNangSuaThongTinGiangVien
    {
        public bool SuaThongTinGiangVien(List<ThongTinGiangVien> danhSach,
            string maGV,
            ThongTinGiangVien thongTinMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====
            if (danhSach == null) return false;

            bool maGVRong = KiemTraChuoiRong(maGV);
            if (maGVRong) return false;

            if (thongTinMoi == null) return false;

            // ===== BƯỚC 2: TÌM GIẢNG VIÊN CẦN SỬA =====
            ThongTinGiangVien gvCanSua = TimGiangVienTheoMa(danhSach, maGV);

            if (gvCanSua == null) return false;

            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU MỚI HỢP LỆ =====
            bool duLieuHopLe = KiemTraDuLieuHopLe(thongTinMoi);

            if (!duLieuHopLe) return false;

            // ===== BƯỚC 4: CẬP NHẬT THÔNG TIN =====
            gvCanSua.HoGV = thongTinMoi.HoGV;
            gvCanSua.TenLotGV = thongTinMoi.TenLotGV;
            gvCanSua.TenGV = thongTinMoi.TenGV;
            gvCanSua.NgaySinhGV = thongTinMoi.NgaySinhGV;
            gvCanSua.GioiTinhGV = thongTinMoi.GioiTinhGV;
            gvCanSua.CCCDGV = thongTinMoi.CCCDGV;
            gvCanSua.DiaChiGV = thongTinMoi.DiaChiGV;
            gvCanSua.EmailGV = thongTinMoi.EmailGV;
            gvCanSua.SDTGV = thongTinMoi.SDTGV;
            gvCanSua.KhoaGV = thongTinMoi.KhoaGV;
            gvCanSua.ChuyenNganhGV = thongTinMoi.ChuyenNganhGV;
            gvCanSua.HocViGV = thongTinMoi.HocViGV;
            gvCanSua.TrangThaiGV = thongTinMoi.TrangThaiGV;

            // ===== BƯỚC 5: TRẢ VỀ KẾT QUẢ =====
            return true;
        }

        public bool SuaHo(List<ThongTinGiangVien> danhSach, string maGV, string hoMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            bool hoRong = KiemTraChuoiRong(hoMoi);
            if (hoRong) return false;

            gv.HoGV = XoaKhoangTrangThua(hoMoi);
            return true;
        }

        public bool SuaTen(List<ThongTinGiangVien> danhSach, string maGV, string tenMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            bool tenRong = KiemTraChuoiRong(tenMoi);
            if (tenRong) return false;

            gv.TenGV = XoaKhoangTrangThua(tenMoi);
            return true;
        }

        public bool SuaEmail(List<ThongTinGiangVien> danhSach, string maGV, string emailMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            bool emailRong = KiemTraChuoiRong(emailMoi);
            if (emailRong) return false;

            gv.EmailGV = XoaKhoangTrangThua(emailMoi);
            return true;
        }

        public bool SuaNgaySinh(List<ThongTinGiangVien> danhSach, string maGV, DateTime ngaySinhMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            if (ngaySinhMoi == DateTime.MinValue) return false;

            int tuoi = DateTime.Now.Year - ngaySinhMoi.Year;
            if (tuoi < 18) return false;

            gv.NgaySinhGV = ngaySinhMoi;
            return true;
        }

        public bool SuaKhoa(List<ThongTinGiangVien> danhSach, string maGV, string khoaMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            bool khoaRong = KiemTraChuoiRong(khoaMoi);
            if (khoaRong) return false;

            gv.KhoaGV = XoaKhoangTrangThua(khoaMoi);
            return true;
        }

        public bool SuaTrangThai(List<ThongTinGiangVien> danhSach, string maGV, string trangThaiMoi)
        {
            ThongTinGiangVien gv = TimGiangVienTheoMa(danhSach, maGV);

            if (gv == null) return false;

            bool trangThaiRong = KiemTraChuoiRong(trangThaiMoi);
            if (trangThaiRong) return false;

            gv.TrangThaiGV = XoaKhoangTrangThua(trangThaiMoi);
            return true;
        }

        private ThongTinGiangVien TimGiangVienTheoMa(List<ThongTinGiangVien> danhSach, string maGV)
        {
            if (danhSach == null) return null;

            bool maRong = KiemTraChuoiRong(maGV);
            if (maRong) return null;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string maGVHienTai = gv.MaGV;
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maGVHienTai, maGV);

                if (khopMa) return gv;
            }
            return null;
        }

        private bool KiemTraDuLieuHopLe(ThongTinGiangVien gv)
        {
            bool maRong = KiemTraChuoiRong(gv.MaGV);
            if (maRong) return false;

            bool hoRong = KiemTraChuoiRong(gv.HoGV);
            if (hoRong) return false;

            bool tenRong = KiemTraChuoiRong(gv.TenGV);
            if (tenRong) return false;

            bool ngaySinhHopLe = (gv.NgaySinhGV != DateTime.MinValue);
            if (!ngaySinhHopLe) return false;

            int namHienTai = DateTime.Now.Year;
            int namSinh = gv.NgaySinhGV.Year;
            int tuoi = namHienTai - namSinh;

            bool tuoiHopLe = (tuoi >= 18);
            if (!tuoiHopLe) return false;

            return true;
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

        private string XoaKhoangTrangThua(string chuoi)
        {
            if (chuoi == null) return "";
            if (chuoi.Length == 0) return "";

            int viTriDau = 0;
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriDau = i;
                    break;
                }
            }

            int viTriCuoi = chuoi.Length - 1;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriCuoi = i;
                    break;
                }
            }

            if (viTriDau > viTriCuoi) return "";

            int doDai = viTriCuoi - viTriDau + 1;
            return chuoi.Substring(viTriDau, doDai);
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
