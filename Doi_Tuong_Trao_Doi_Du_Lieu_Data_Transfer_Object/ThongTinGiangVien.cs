using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    // ==================== CLASS THÔNG TIN GIẢNG VIÊN (DTO) ====================
    // Data Transfer Object for Lecturer Information
    public class ThongTinGiangVien
    {
        // ===== THUỘC TÍNH ID =====
        public int ID { get; set; }

        // ===== THUỘC TÍNH MÃ GIẢNG VIÊN =====
        public string MaGV { get; set; } = "";

        // ===== THUỘC TÍNH HỌ =====
        public string HoGV { get; set; } = "";

        // ===== THUỘC TÍNH TÊN LÓT =====
        public string TenLotGV { get; set; } = "";

        // ===== THUỘC TÍNH TÊN =====
        public string TenGV { get; set; } = "";

        // ===== THUỘC TÍNH NGÀY SINH =====
        public DateTime NgaySinhGV { get; set; }

        // ===== THUỘC TÍNH GIỚI TÍNH =====
        public string GioiTinhGV { get; set; } = "";

        // ===== THUỘC TÍNH CCCD =====
        public string CCCDGV { get; set; } = "";

        // ===== THUỘC TÍNH ĐỊA CHỈ =====
        public string DiaChiGV { get; set; } = "";

        // ===== THUỘC TÍNH EMAIL =====
        public string EmailGV { get; set; } = "";

        // ===== THUỘC TÍNH SỐ ĐIỆN THOẠI =====
        public string SDTGV { get; set; } = "";

        // ===== THUỘC TÍNH KHOA =====
        public string KhoaGV { get; set; } = "";

        // ===== THUỘC TÍNH CHUYÊN NGÀNH =====
        public string ChuyenNganhGV { get; set; } = "";

        // ===== THUỘC TÍNH HỌC VỊ =====
        // VD: Cử nhân, Thạc sĩ, Tiến sĩ, Giáo sư
        public string HocViGV { get; set; } = "";

        // ===== THUỘC TÍNH TRẠNG THÁI =====
        // VD: Đang làm việc, Nghỉ việc, Nghỉ hưu
        public string TrangThaiGV { get; set; } = "";

        // ===== THUỘC TÍNH HÌNH ẢNH =====
        public string HinhAnhGV { get; set; } = "";
    }
}
