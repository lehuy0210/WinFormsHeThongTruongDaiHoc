using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN MÔN HỌC (DTO) ====================
    public class ThongTinMonHoc
    {
        public int ID { get; set; }

        // Mã môn học (VD: CNTT101, TOAN201)
        public string MaMonHoc { get; set; } = "";

        // Tên môn học
        public string TenMonHoc { get; set; } = "";

        // Số tín chỉ
        public int SoTinChi { get; set; }

        // Số tiết lý thuyết
        public int SoTietLyThuyet { get; set; }

        // Số tiết thực hành
        public int SoTietThucHanh { get; set; }

        // Khoa quản lý
        public string Khoa { get; set; } = "";

        // Học kỳ (1, 2, 3...)
        public int HocKy { get; set; }

        // Năm học (VD: 2024-2025)
        public string NamHoc { get; set; } = "";

        // Mô tả môn học
        public string MoTa { get; set; } = "";
    }
}
