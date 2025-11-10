using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG SẮP XẾP GIẢNG VIÊN (BLL) ====================
    public class ChucNangSapXepGV
    {
        public void SapXepTheoTen(List<ThongTinGiangVien> danhSach, bool tangDan = true)
        {
            if (danhSach == null) return;
            if (danhSach.Count <= 1) return;

            int n = danhSach.Count;

            // ===== BUBBLE SORT ALGORITHM =====
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    string tenTruoc = danhSach[j].TenGV;
                    string tenSau = danhSach[j + 1].TenGV;

                    tenTruoc = ChuyenVeChuThuong(tenTruoc);
                    tenSau = ChuyenVeChuThuong(tenSau);

                    int ketQuaSoSanh = SoSanhChuoi(tenTruoc, tenSau);

                    bool canHoanDoi = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh > 0)
                        {
                            canHoanDoi = true;
                        }
                    }
                    else
                    {
                        if (ketQuaSoSanh < 0)
                        {
                            canHoanDoi = true;
                        }
                    }

                    if (canHoanDoi)
                    {
                        ThongTinGiangVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        public void SapXepTheoMa(List<ThongTinGiangVien> danhSach, bool tangDan = true)
        {
            if (danhSach == null) return;
            if (danhSach.Count <= 1) return;

            int n = danhSach.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int viTrMin = i;

                for (int j = i + 1; j < n; j++)
                {
                    string maTruoc = danhSach[viTrMin].MaGV;
                    string maSau = danhSach[j].MaGV;

                    int ketQuaSoSanh = SoSanhChuoi(maTruoc, maSau);

                    bool canDoiChon = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh > 0)
                        {
                            canDoiChon = true;
                        }
                    }
                    else
                    {
                        if (ketQuaSoSanh < 0)
                        {
                            canDoiChon = true;
                        }
                    }

                    if (canDoiChon)
                    {
                        viTrMin = j;
                    }
                }

                if (viTrMin != i)
                {
                    ThongTinGiangVien temp = danhSach[i];
                    danhSach[i] = danhSach[viTrMin];
                    danhSach[viTrMin] = temp;
                }
            }
        }

        public void SapXepTheoHoTen(List<ThongTinGiangVien> danhSach, bool tangDan = true)
        {
            if (danhSach == null) return;
            if (danhSach.Count <= 1) return;

            int n = danhSach.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    string hoTenTruoc = danhSach[j].HoGV + " " + danhSach[j].TenGV;
                    string hoTenSau = danhSach[j + 1].HoGV + " " + danhSach[j + 1].TenGV;

                    hoTenTruoc = ChuyenVeChuThuong(hoTenTruoc);
                    hoTenSau = ChuyenVeChuThuong(hoTenSau);

                    int ketQuaSoSanh = SoSanhChuoi(hoTenTruoc, hoTenSau);

                    bool canHoanDoi = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh > 0) canHoanDoi = true;
                    }
                    else
                    {
                        if (ketQuaSoSanh < 0) canHoanDoi = true;
                    }

                    if (canHoanDoi)
                    {
                        ThongTinGiangVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        public void SapXepTheoNgaySinh(List<ThongTinGiangVien> danhSach, bool tangDan = true)
        {
            if (danhSach == null) return;
            if (danhSach.Count <= 1) return;

            int n = danhSach.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    DateTime ngayTruoc = danhSach[j].NgaySinhGV;
                    DateTime ngaySau = danhSach[j + 1].NgaySinhGV;

                    int ketQuaSoSanh = ngayTruoc.CompareTo(ngaySau);

                    bool canHoanDoi = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh > 0) canHoanDoi = true;
                    }
                    else
                    {
                        if (ketQuaSoSanh < 0) canHoanDoi = true;
                    }

                    if (canHoanDoi)
                    {
                        ThongTinGiangVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        private int SoSanhChuoi(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null) return 0;
            if (chuoi1 == null) return -1;
            if (chuoi2 == null) return 1;

            int n = chuoi1.Length < chuoi2.Length ? chuoi1.Length : chuoi2.Length;

            for (int i = 0; i < n; i++)
            {
                if (chuoi1[i] < chuoi2[i]) return -1;
                if (chuoi1[i] > chuoi2[i]) return 1;
            }

            if (chuoi1.Length < chuoi2.Length) return -1;
            if (chuoi1.Length > chuoi2.Length) return 1;

            return 0;
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
