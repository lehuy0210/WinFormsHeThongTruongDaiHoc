using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetThiDua
{
    // ==================== DATA ACCESS LAYER - LẤY TẤT CẢ DỮ LIỆU XÉT THI DỰA ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SELECT * statement, SqlDataReader, Connection pooling
    // 2️⃣ DATA BINDING: Binding List<T> to DataGridView, ListView
    // 3️⃣ MEMORY MANAGEMENT: Dispose pattern, using statement
    // 4️⃣ PAGINATION: OFFSET FETCH for large datasets

    public class ChucNangLayTatCaDuLieuXetThiDua
    {
        // TODO: Implement khi có database
        // public List<ThongTinXetThiDua> LayTatCaKetQuaXetThiDua()
        // {
        //     List<ThongTinXetThiDua> danhSach = new List<ThongTinXetThiDua>();
        //
        //     // BƯỚC 1: Tạo connection
        //     // using (SqlConnection conn = new SqlConnection(connectionString))
        //     // {
        //     //     conn.Open();
        //     //
        //     //     // BƯỚC 2: Tạo SELECT command
        //     //     string sql = "SELECT * FROM KetQuaXetThiDua ORDER BY NgayThi DESC, DiemXetThiDua DESC";
        //     //     using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //     {
        //     //         // BƯỚC 3: Execute và đọc dữ liệu
        //     //         using (SqlDataReader reader = cmd.ExecuteReader())
        //     //         {
        //     //             while (reader.Read())
        //     //             {
        //     //                 // BƯỚC 4: Map DataReader → DTO object
        //     //                 ThongTinXetThiDua xetThiDua = new ThongTinXetThiDua
        //     //                 {
        //     //                     ID = reader.GetInt32(reader.GetOrdinal("ID")),
        //     //                     MaSinhVien = reader.GetString(reader.GetOrdinal("MaSinhVien")),
        //     //                     MaGiaoVien = reader.GetString(reader.GetOrdinal("MaGiaoVien")),
        //     //                     TenMonHoc = reader.GetString(reader.GetOrdinal("TenMonHoc")),
        //     //                     DiemXetThiDua = reader.GetDecimal(reader.GetOrdinal("DiemXetThiDua")),
        //     //                     SoLanThi = reader.GetInt32(reader.GetOrdinal("SoLanThi")),
        //     //                     LoaiThi = reader.GetString(reader.GetOrdinal("LoaiThi")),
        //     //                     NgayThi = reader.GetDateTime(reader.GetOrdinal("NgayThi")),
        //     //                     GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? "" : reader.GetString(reader.GetOrdinal("GhiChu")),
        //     //                     NgayTao = reader.GetDateTime(reader.GetOrdinal("NgayTao")),
        //     //                     NgayCapNhat = reader.IsDBNull(reader.GetOrdinal("NgayCapNhat")) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("NgayCapNhat"))
        //     //                 };
        //     //                 danhSach.Add(xetThiDua);
        //     //             }
        //     //         }
        //     //     }
        //     // }
        //
        //     return danhSach;
        // }

        // public List<ThongTinXetThiDua> LayDuLieuCoPhantrang(int pageNumber, int pageSize)
        // {
        //     // SQL SELECT với OFFSET FETCH (SQL Server 2012+)
        //     // string sql = "SELECT * FROM KetQuaXetThiDua " +
        //     //              "ORDER BY NgayThi DESC, DiemXetThiDua DESC " +
        //     //              "OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        //     //
        //     // int offset = (pageNumber - 1) * pageSize;
        //     // cmd.Parameters.AddWithValue("@Offset", offset);
        //     // cmd.Parameters.AddWithValue("@PageSize", pageSize);
        // }

        // public List<ThongTinXetThiDua> LayDuLieuTheoNam(int nam)
        // {
        //     // Lấy các bản ghi thi dụa trong 1 năm cụ thể
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE YEAR(NgayThi) = @Nam ORDER BY NgayThi DESC";
        // }

        // public List<ThongTinXetThiDua> LayDuLieuTheoGiaoVien(string maGiaoVien)
        // {
        //     // Lấy tất cả các sinh viên được giáo viên này chấm thi
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE MaGiaoVien = @MaGiaoVien ORDER BY NgayThi DESC";
        // }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 TẠI SAO CẦN LẤY TẤT CẢ DỮ LIỆU?
        // - Hiển thị danh sách kết quả xét thi dụa trong DataGridView
        // - Load dữ liệu khi Form được mở (Form_Load event)
        // - Refresh sau khi Thêm/Xóa/Sửa kết quả xét thi
        // - Export ra Excel/PDF cho báo cáo
        // - Thống kê kết quả thi dụa (Đạt, Không đạt, Trung bình)
        //
        // 📝 CÁC BƯỚC THỰC HIỆN:
        //
        // BƯỚC 1: TẠO CONNECTION
        // - using statement tự động dispose connection
        // - conn.Open() mở kết nối đến SQL Server
        //
        // BƯỚC 2: TẠO SELECT COMMAND
        // - SELECT * lấy tất cả columns (không nên dùng trong production)
        // - Tốt hơn: SELECT ID, MaSinhVien, TenMonHoc, DiemXetThiDua, ... (chỉ lấy columns cần thiết)
        // - ORDER BY để sắp xếp kết quả (theo NgayThi giảm dần, sau đó DiemXetThiDua)
        //
        // BƯỚC 3: EXECUTE VÀ ĐỌC DỮ LIỆU
        // - ExecuteReader() trả về SqlDataReader
        // - reader.Read() đọc từng row, return false khi hết dữ liệu
        // - Forward-only, read-only cursor (hiệu suất cao)
        //
        // BƯỚC 4: MAP DATAREADER → DTO
        // - reader.GetOrdinal("ColumnName") → Index của column
        // - reader.GetInt32(index), reader.GetString(index), reader.GetDecimal(index) → Đọc giá trị
        // - reader.IsDBNull(index) → Kiểm tra NULL value
        //
        // ⚠️ BEST PRACTICES:
        // 1. Luôn dùng using statement để dispose resources
        // 2. Không dùng SELECT * (performance issue & bảo mật)
        // 3. Kiểm tra NULL values trước khi GetString/GetInt32
        // 4. Dùng GetOrdinal() thay vì hard-code column index
        // 5. Close connection ngay sau khi dùng xong
        //
        // 📊 PERFORMANCE OPTIMIZATION:
        // - Nếu table có nhiều rows (>10.000) → Dùng pagination (OFFSET FETCH)
        // - Dùng SqlDataAdapter + DataTable cho complex scenarios
        // - Cache dữ liệu trong memory nếu ít thay đổi (refresh every 5 minutes)
        // - Tạo VIEW trong SQL để lấy dữ liệu đã tính toán sẵn
        // - Tạo INDEX trên NgayThi, MaSinhVien để tăng tốc
        //
        // 🎓 SO SÁNH 3 CÁCH ĐỌC DỮ LIỆU:
        // ┌──────────────────┬─────────────┬─────────────┬──────────────┐
        // │     Method       │  Performance│  Memory     │  Use Case    │
        // ├──────────────────┼─────────────┼─────────────┼──────────────┤
        // │ SqlDataReader    │  Nhanh nhất │  Ít nhất    │  Read-only   │
        // │ DataTable        │  Trung bình │  Nhiều      │  Complex     │
        // │ Entity Framework │  Chậm nhất  │  Nhiều nhất │  ORM, LINQ   │
        // └──────────────────┴─────────────┴─────────────┴──────────────┘
        //
        // 📌 LƯU Ý CHO XÉT THI DỰA:
        // - Dữ liệu có thể rất lớn (100.000+ lần thi)
        // - Nên dùng pagination để tránh load tất cả dữ liệu 1 lúc
        // - Cache những năm xét cũ vì ít thay đổi
        // - Cần sắp xếp theo DiemXetThiDua giảm dần để dễ nhìn
        // - Phân biệt kỹ lưỡng giữa: Thi dụa, Thi lại, Thi nâng cao
    }
}
