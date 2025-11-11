using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyHoSo
{
    // DAL: Tìm kiếm hồ sơ từ database
    public class TimKiemDuLieuHoSo
    {
        // TODO: SELECT * FROM HoSo WHERE MaHoSo LIKE '%' + @Keyword + '%'
        public List<ThongTinHoSo> TimKiemTrongDatabase(string keyword, string connectionString)
        {
            return new List<ThongTinHoSo>();
        }
    }
}
