using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN LỊCH THI (DTO) ====================
    public class ThongTinLichThi
    {
        public int ID { get; set; }

        // Mã lịch thi
        public string MaLichThi { get; set; } = "";

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

        // Ngày thi
        public DateTime NgayThi { get; set; }

        // Giờ bắt đầu
        public TimeSpan GioBatDau { get; set; }

        // Giờ kết thúc
        public TimeSpan GioKetThuc { get; set; }

        // Phòng thi
        public string PhongThi { get; set; } = "";

        // Hình thức thi (Tự luận, Trắc nghiệm, Vấn đáp, Thực hành)
        public string HinhThucThi { get; set; } = "";

        // Số sinh viên dự thi
        public int SoSinhVien { get; set; }

        // Giảng viên coi thi 1
        public string GiaoVienCoiThi1 { get; set; } = "";

        // Giảng viên coi thi 2
        public string GiaoVienCoiThi2 { get; set; } = "";

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
