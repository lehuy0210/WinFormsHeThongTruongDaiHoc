using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN THỜI KHÓA BIỂU (DTO) ====================
    public class ThongTinThoiKhoaBieu
    {
        public int ID { get; set; }

        // Mã thời khóa biểu
        public string MaTKB { get; set; } = "";

        // Mã lớp học
        public string MaLopHoc { get; set; } = "";

        // Tên lớp học
        public string TenLopHoc { get; set; } = "";

        // Mã môn học
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Mã giảng viên
        public string MaGiangVien { get; set; } = "";

        // Tên giảng viên
        public string TenGiangVien { get; set; } = "";

        // Thứ trong tuần (2-7, CN)
        public string Thu { get; set; } = "";

        // Tiết bắt đầu
        public int TietBatDau { get; set; }

        // Tiết kết thúc
        public int TietKetThuc { get; set; }

        // Phòng học
        public string PhongHoc { get; set; } = "";

        // Tuần bắt đầu
        public int TuanBatDau { get; set; }

        // Tuần kết thúc
        public int TuanKetThuc { get; set; }

        // Học kỳ
        public int HocKy { get; set; }

        // Năm học
        public string NamHoc { get; set; } = "";

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
