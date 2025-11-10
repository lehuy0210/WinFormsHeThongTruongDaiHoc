using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN LỚP HỌC (DTO) ====================
    public class ThongTinLopHoc
    {
        public int ID { get; set; }

        // Mã lớp học (VD: CNTT1_2024)
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

        // Học kỳ
        public int HocKy { get; set; }

        // Năm học
        public string NamHoc { get; set; } = "";

        // Phòng học
        public string PhongHoc { get; set; } = "";

        // Thứ trong tuần (2-7, CN)
        public string Thu { get; set; } = "";

        // Tiết bắt đầu
        public int TietBatDau { get; set; }

        // Tiết kết thúc
        public int TietKetThuc { get; set; }

        // Sĩ số tối đa
        public int SiSoToiDa { get; set; }

        // Sĩ số hiện tại
        public int SiSoHienTai { get; set; }

        // Ghi chú
        public string GhiChu { get; set; } = "";
    }
}
