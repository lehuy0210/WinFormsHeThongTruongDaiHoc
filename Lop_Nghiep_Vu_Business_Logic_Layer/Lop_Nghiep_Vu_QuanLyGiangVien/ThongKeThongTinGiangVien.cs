using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG THỐNG KÊ GIẢNG VIÊN ====================
    public class ChucNangThongKeGV
    {
        public int DemTheoGioiTinh(List<ThongTinGiangVien> danhSach, string gioiTinh)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (danhSach == null) return 0;

            bool gioiTinhRong = KiemTraChuoiRong(gioiTinh);
            if (gioiTinhRong) return 0;

            // ===== BƯỚC 2: KHỞI TẠO BIẾN ĐẾM =====
            int dem = 0;

            // ===== BƯỚC 3: DUYỆT QUA TỪNG GIẢNG VIÊN (TRAVERSE) =====
            foreach (ThongTinGiangVien gv in danhSach)
            {
                string gioiTinhGV = gv.GioiTinhGV;

                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(gioiTinhGV, gioiTinh);

                if (khop)
                {
                    dem++;
                }
            }

            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return dem;
        }

        public int DemTheoKhoa(List<ThongTinGiangVien> danhSach, string khoa)
        {
            if (danhSach == null) return 0;

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong) return 0;

            int dem = 0;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string khoaGV = gv.KhoaGV;

                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(khoaGV, khoa);

                if (khop)
                {
                    dem++;
                }
            }

            return dem;
        }

        public int DemTheoTrangThai(List<ThongTinGiangVien> danhSach, string trangThai)
        {
            if (danhSach == null) return 0;

            bool trangThaiRong = KiemTraChuoiRong(trangThai);
            if (trangThaiRong) return 0;

            int dem = 0;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string trangThaiGV = gv.TrangThaiGV;

                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(trangThaiGV, trangThai);

                if (khop)
                {
                    dem++;
                }
            }

            return dem;
        }

        public int DemTheoChuyenNganh(List<ThongTinGiangVien> danhSach, string chuyenNganh)
        {
            if (danhSach == null) return 0;

            bool chuyenNganhRong = KiemTraChuoiRong(chuyenNganh);
            if (chuyenNganhRong) return 0;

            int dem = 0;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string chuyenNganhGV = gv.ChuyenNganhGV;

                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(chuyenNganhGV, chuyenNganh);

                if (khop)
                {
                    dem++;
                }
            }

            return dem;
        }

        public int DemTheoHocVi(List<ThongTinGiangVien> danhSach, string hocVi)
        {
            if (danhSach == null) return 0;

            bool hocViRong = KiemTraChuoiRong(hocVi);
            if (hocViRong) return 0;

            int dem = 0;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string hocViGV = gv.HocViGV;

                bool khop = SoSanhChuoiKhongPhanBietHoaThuong(hocViGV, hocVi);

                if (khop)
                {
                    dem++;
                }
            }

            return dem;
        }

        public int TongSoGiangVien(List<ThongTinGiangVien> danhSach)
        {
            if (danhSach == null) return 0;
            return danhSach.Count;
        }

        public List<string> LayDanhSachKhoa(List<ThongTinGiangVien> danhSach)
        {
            List<string> danhSachKhoa = new List<string>();

            if (danhSach == null) return danhSachKhoa;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string khoaGV = gv.KhoaGV;

                bool daTonTai = false;

                foreach (string khoa in danhSachKhoa)
                {
                    if (SoSanhChuoiKhongPhanBietHoaThuong(khoa, khoaGV))
                    {
                        daTonTai = true;
                        break;
                    }
                }

                if (!daTonTai && !KiemTraChuoiRong(khoaGV))
                {
                    danhSachKhoa.Add(khoaGV);
                }
            }

            return danhSachKhoa;
        }

        public List<string> LayDanhSachTrangThai(List<ThongTinGiangVien> danhSach)
        {
            List<string> danhSachTrangThai = new List<string>();

            if (danhSach == null) return danhSachTrangThai;

            foreach (ThongTinGiangVien gv in danhSach)
            {
                string trangThaiGV = gv.TrangThaiGV;

                bool daTonTai = false;

                foreach (string trangThai in danhSachTrangThai)
                {
                    if (SoSanhChuoiKhongPhanBietHoaThuong(trangThai, trangThaiGV))
                    {
                        daTonTai = true;
                        break;
                    }
                }

                if (!daTonTai && !KiemTraChuoiRong(trangThaiGV))
                {
                    danhSachTrangThai.Add(trangThaiGV);
                }
            }

            return danhSachTrangThai;
        }

        public int DemGiangVienNam(List<ThongTinGiangVien> danhSach)
        {
            return DemTheoGioiTinh(danhSach, "Nam");
        }

        public int DemGiangVienNu(List<ThongTinGiangVien> danhSach)
        {
            return DemTheoGioiTinh(danhSach, "Nữ");
        }

        public int DemGiangVienDangLamViec(List<ThongTinGiangVien> danhSach)
        {
            return DemTheoTrangThai(danhSach, "Đang làm việc");
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
