using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangDay
{
    // ==================== CLASS CHỨC NĂNG TÍNH ĐIỂM (BLL) ====================
    public class ChucNangTinhDiem
    {
        /// <summary>
        /// Tính điểm tổng kết
        /// Công thức: DiemChuyenCan*0.1 + DiemGiuaKy*0.2 + DiemThucHanh*0.2 + DiemCuoiKy*0.5
        /// </summary>
        public double TinhDiemTongKet(double diemChuyenCan, double diemGiuaKy, double diemThucHanh, double diemCuoiKy)
        {
            if (!KiemTraDiemHopLe(diemChuyenCan) || !KiemTraDiemHopLe(diemGiuaKy) ||
                !KiemTraDiemHopLe(diemThucHanh) || !KiemTraDiemHopLe(diemCuoiKy))
            {
                return -1; // Điểm không hợp lệ
            }

            double diemTongKet = (diemChuyenCan * 0.1) + (diemGiuaKy * 0.2) + (diemThucHanh * 0.2) + (diemCuoiKy * 0.5);

            return diemTongKet;
        }

        /// <summary>
        /// Chuyển đổi điểm số sang điểm chữ
        /// A: >=9, B+: >=8.5, B: >=8, C+: >=7, C: >=6.5, D+: >=5.5, D: >=5, F: <5
        /// </summary>
        public string ChuyenDoiDiemChu(double diem)
        {
            if (!KiemTraDiemHopLe(diem))
                return "Không hợp lệ";

            if (diem >= 9.0)
                return "A";
            else if (diem >= 8.5)
                return "B+";
            else if (diem >= 8.0)
                return "B";
            else if (diem >= 7.0)
                return "C+";
            else if (diem >= 6.5)
                return "C";
            else if (diem >= 5.5)
                return "D+";
            else if (diem >= 5.0)
                return "D";
            else
                return "F";
        }

        /// <summary>
        /// Xét kết quả học tập
        /// Đạt nếu >=5, Không đạt nếu <5
        /// </summary>
        public string XetKetQua(double diem)
        {
            if (!KiemTraDiemHopLe(diem))
                return "Không hợp lệ";

            if (diem >= 5.0)
                return "Đạt";
            else
                return "Không đạt";
        }

        /// <summary>
        /// Kiểm tra điểm có hợp lệ không (0-10)
        /// </summary>
        private bool KiemTraDiemHopLe(double diem)
        {
            return diem >= 0 && diem <= 10;
        }
    }
}
