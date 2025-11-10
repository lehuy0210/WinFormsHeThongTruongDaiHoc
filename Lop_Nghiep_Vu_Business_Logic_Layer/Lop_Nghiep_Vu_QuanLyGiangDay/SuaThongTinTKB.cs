using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangDay
{
    // ==================== CLASS CHỨC NĂNG SỬA THỜI KHÓA BIỂU (BLL) ====================
    public class ChucNangSuaTKB
    {
        /// <summary>
        /// Kiểm tra chuỗi có rỗng không
        /// </summary>
        private bool KiemTraChuoiRong(string chuoi)
        {
            if (chuoi == null)
                return true;

            if (chuoi.Length == 0)
                return true;

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// So sánh 2 chuỗi không phân biệt hoa/thường
        /// </summary>
        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
                return true;

            if (chuoi1 == null || chuoi2 == null)
                return false;

            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        /// <summary>
        /// So sánh 2 chuỗi chính xác
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
                return true;

            if (chuoi1 == null || chuoi2 == null)
                return false;

            if (chuoi1.Length != chuoi2.Length)
                return false;

            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi về chữ thường
        /// </summary>
        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null)
                return "";

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

        /// <summary>
        /// Tìm vị trí thời khóa biểu theo mã
        /// </summary>
        private int TimViTriTKB(List<ThongTinThoiKhoaBieu> danhSach, string maTKB)
        {
            bool maRong = KiemTraChuoiRong(maTKB);
            if (maRong)
                return -1;

            for (int i = 0; i < danhSach.Count; i++)
            {
                string maTKBHienTai = danhSach[i].MaTKB;
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maTKBHienTai, maTKB);

                if (khopMa)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Kiểm tra dữ liệu thời khóa biểu có hợp lệ không
        /// </summary>
        private bool KiemTraDuLieuHopLe(ThongTinThoiKhoaBieu tkb)
        {
            bool maRong = KiemTraChuoiRong(tkb.MaTKB);
            if (maRong)
                return false;

            bool maLopRong = KiemTraChuoiRong(tkb.MaLopHoc);
            if (maLopRong)
                return false;

            return true;
        }

        /// <summary>
        /// Sửa thông tin thời khóa biểu
        /// </summary>
        public bool SuaTKB(List<ThongTinThoiKhoaBieu> danhSach, string maTKB, ThongTinThoiKhoaBieu tkbMoi)
        {
            if (danhSach == null || tkbMoi == null)
                return false;

            int viTri = TimViTriTKB(danhSach, maTKB);

            if (viTri == -1)
                return false;

            bool duLieuHopLe = KiemTraDuLieuHopLe(tkbMoi);

            if (!duLieuHopLe)
                return false;

            danhSach[viTri] = tkbMoi;

            return true;
        }
    }
}
