using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyDaoTao
{
    // ==================== DATA ACCESS LAYER - LẤY TẤT CẢ DỮ LIỆU ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SELECT * statement, SqlDataReader
    // 2️⃣ DATA BINDING: Binding List<T> to DataGridView
    // 3️⃣ MEMORY MANAGEMENT: Dispose pattern, using statement

    public class ChucNangLayTatCaDuLieuDaoTao
    {
        // TODO: Implement khi có database
        // public List<ThongTinDaoTao> LayTatCaChuongTrinh()
        // {
        //     List<ThongTinDaoTao> danhSach = new List<ThongTinDaoTao>();
        //
        //     // BƯỚC 1: Tạo connection
        //     // using (SqlConnection conn = new SqlConnection(connectionString))
        //     // {
        //     //     conn.Open();
        //     //
        //     //     // BƯỚC 2: Tạo SELECT command
        //     //     string sql = "SELECT * FROM ThongTinDaoTao ORDER BY NamBatDau DESC, MaChuongTrinh";
        //     //     using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //     {
        //     //         // BƯỚC 3: Execute và đọc dữ liệu
        //     //         using (SqlDataReader reader = cmd.ExecuteReader())
        //     //         {
        //     //             while (reader.Read())
        //     //             {
        //     //                 // BƯỚC 4: Map DataReader → DTO object
        //     //                 ThongTinDaoTao ct = new ThongTinDaoTao
        //     //                 {
        //     //                     ID = reader.GetInt32(reader.GetOrdinal("ID")),
        //     //                     MaChuongTrinh = reader.GetString(reader.GetOrdinal("MaChuongTrinh")),
        //     //                     TenChuongTrinh = reader.GetString(reader.GetOrdinal("TenChuongTrinh")),
        //     //                     BacDaoTao = reader.GetString(reader.GetOrdinal("BacDaoTao")),
        //     //                     Khoa = reader.GetString(reader.GetOrdinal("Khoa")),
        //     //                     SoNamDaoTao = reader.GetInt32(reader.GetOrdinal("SoNamDaoTao")),
        //     //                     TongTinChi = reader.GetInt32(reader.GetOrdinal("TongTinChi")),
        //     //                     NamBatDau = reader.GetInt32(reader.GetOrdinal("NamBatDau")),
        //     //                     MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? "" : reader.GetString(reader.GetOrdinal("MoTa")),
        //     //                     DieuKienTotNghiep = reader.GetString(reader.GetOrdinal("DieuKienTotNghiep")),
        //     //                     TrangThai = reader.GetString(reader.GetOrdinal("TrangThai"))
        //     //                 };
        //     //                 danhSach.Add(ct);
        //     //             }
        //     //         }
        //     //     }
        //     // }
        //
        //     return danhSach;
        // }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 TẠI SAO CẦN LẤY TẤT CẢ DỮ LIỆU?
        // - Hiển thị danh sách chương trình đào tạo trong DataGridView
        // - Load dữ liệu khi Form được mở (Form_Load event)
        // - Refresh sau khi Thêm/Xóa/Sửa
        //
        // 📝 CÁC BƯỚC THỰC HIỆN:
        //
        // BƯỚC 1: TẠO CONNECTION
        // - using statement tự động dispose connection
        // - conn.Open() mở kết nối đến SQL Server
        //
        // BƯỚC 2: TẠO SELECT COMMAND
        // - SELECT * lấy tất cả columns (không nên dùng trong production)
        // - Tốt hơn: SELECT ID, MaChuongTrinh, TenChuongTrinh, ... (chỉ lấy columns cần thiết)
        // - ORDER BY để sắp xếp kết quả
        //
        // BƯỚC 3: EXECUTE VÀ ĐỌC DỮ LIỆU
        // - ExecuteReader() trả về SqlDataReader
        // - reader.Read() đọc từng row, return false khi hết dữ liệu
        // - Forward-only, read-only cursor (hiệu suất cao)
        //
        // BƯỚC 4: MAP DATAREADER → DTO
        // - reader.GetOrdinal("ColumnName") → Index của column
        // - reader.GetInt32(index), reader.GetString(index) → Đọc giá trị
        // - reader.IsDBNull(index) → Kiểm tra NULL value
        //
        // ⚠️ BEST PRACTICES:
        // 1. Luôn dùng using statement để dispose resources
        // 2. Không dùng SELECT * (performance issue)
        // 3. Kiểm tra NULL values trước khi GetString/GetInt32
        // 4. Dùng GetOrdinal() thay vì hard-code column index
        // 5. Close connection ngay sau khi dùng xong
        //
        // 📊 PERFORMANCE OPTIMIZATION:
        // - Nếu table có nhiều rows → Dùng pagination (OFFSET FETCH)
        // - Dùng SqlDataAdapter + DataTable cho complex scenarios
        // - Cache dữ liệu trong memory nếu ít thay đổi
        //
        // 🎓 SO SÁNH 3 CÁCH ĐỌC DỮ LIỆU:
        // ┌──────────────────┬─────────────┬─────────────┬──────────────┐
        // │     Method       │  Performance│  Memory     │  Use Case    │
        // ├──────────────────┼─────────────┼─────────────┼──────────────┤
        // │ SqlDataReader    │  Nhanh nhất │  Ít nhất    │  Read-only   │
        // │ DataTable        │  Trung bình │  Nhiều      │  Complex     │
        // │ Entity Framework │  Chậm nhất  │  Nhiều nhất │  ORM, LINQ   │
        // └──────────────────┴─────────────┴─────────────┴──────────────┘
    }
}
