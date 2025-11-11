using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep
{
    public class ChucNangThongKeThongTinXetTotNghiep
    {
        // Thống kê số lượng sinh viên theo kết quả xét (Đủ điều kiện, Không đủ, Có điều kiện)
        public Dictionary<string, int> ThongKeTheoKetQua(List<ThongTinXetTotNghiep> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (thongKe.ContainsKey(kq.KetQuaXet))
                    thongKe[kq.KetQuaXet]++;
                else
                    thongKe[kq.KetQuaXet] = 1;
            }
            return thongKe;
        }

        // Thống kê số lượng sinh viên theo xếp loại (Xuất sắc, Giỏi, Khá, Trung bình)
        public Dictionary<string, int> ThongKeTheoXepLoai(List<ThongTinXetTotNghiep> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (thongKe.ContainsKey(kq.XepLoaiTotNghiep))
                    thongKe[kq.XepLoaiTotNghiep]++;
                else
                    thongKe[kq.XepLoaiTotNghiep] = 1;
            }
            return thongKe;
        }

        // Thống kê theo Khoa
        public Dictionary<string, int> ThongKeTheoKhoa(List<ThongTinXetTotNghiep> danhSach)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            if (danhSach == null) return thongKe;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (thongKe.ContainsKey(kq.Khoa))
                    thongKe[kq.Khoa]++;
                else
                    thongKe[kq.Khoa] = 1;
            }
            return thongKe;
        }

        // Tính tỷ lệ tốt nghiệp (%)
        public double TinhTyLeTotNghiep(List<ThongTinXetTotNghiep> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0) return 0;

            int soSinhVienDuDieuKien = 0;
            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.KetQuaXet == "Đủ điều kiện" || kq.KetQuaXet == "Tốt nghiệp có điều kiện")
                    soSinhVienDuDieuKien++;
            }

            return (double)soSinhVienDuDieuKien / danhSach.Count * 100;
        }

        // Tính GPA trung bình của sinh viên tốt nghiệp
        public double TinhGPATrungBinh(List<ThongTinXetTotNghiep> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0) return 0;

            double tongGPA = 0;
            int dem = 0;

            foreach (ThongTinXetTotNghiep kq in danhSach)
            {
                if (kq.KetQuaXet == "Đủ điều kiện")
                {
                    tongGPA += kq.DiemTrungBinhTichLuy;
                    dem++;
                }
            }

            return dem > 0 ? tongGPA / dem : 0;
        }
    }
}
