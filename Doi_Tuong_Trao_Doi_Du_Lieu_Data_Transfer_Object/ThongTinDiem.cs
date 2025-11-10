using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN ĐIỂM (DTO) ====================
    public class ThongTinDiem
    {
        public int ID { get; set; }

        // Mã sinh viên
        public string MaSinhVien { get; set; } = "";

        // Tên sinh viên
        public string TenSinhVien { get; set; } = "";

        // Mã môn học
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Mã lớp học
        public string MaLopHoc { get; set; } = "";

        // Học kỳ
        public int HocKy { get; set; }

        // Năm học
        public string NamHoc { get; set; } = "";

        // Điểm chuyên cần (10%)
        public float DiemChuyenCan { get; set; }

        // Điểm kiểm tra giữa kỳ (20%)
        public float DiemGiuaKy { get; set; }

        // Điểm thực hành/bài tập (20%)
        public float DiemThucHanh { get; set; }

        // Điểm cuối kỳ (50%)
        public float DiemCuoiKy { get; set; }

        // Điểm tổng kết (tính tự động)
        public float DiemTongKet { get; set; }

        // Điểm chữ (A, B+, B, C+, C, D, F)
        public string DiemChu { get; set; } = "";

        // Kết quả (Đạt/Không đạt)
        public string KetQua { get; set; } = "";

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
