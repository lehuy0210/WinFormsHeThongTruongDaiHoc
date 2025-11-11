using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyDaoTao
{
    // ==================== DATA ACCESS LAYER - THÊM THÔNG TIN ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: ADO.NET, SqlConnection, SqlCommand, Parameters
    // 2️⃣ SQL PROGRAMMING: INSERT statement, Primary Key, IDENTITY column
    // 3️⃣ EXCEPTION HANDLING: try-catch-finally, SqlException, Transaction rollback
    // 4️⃣ OBJECT-ORIENTED PROGRAMMING: Classes, Methods, Data encapsulation
    //
    // 📖 TÀI LIỆU THAM KHẢO:
    // Chương 7: Database Programming - ADO.NET Data Access
    // Chương 4: SQL INSERT statement và Transaction Management
    //
    // 💡 MỤC ĐÍCH:
    // Class này thực hiện INSERT dữ liệu chương trình đào tạo vào database SQL Server
    // Đây là tầng DAL (Data Access Layer) - tầng thứ 3 trong kiến trúc N-Layer
    //
    // 🎯 WORKFLOW:
    // UI Layer → BLL Layer → DAL Layer → SQL Server Database
    // User nhập liệu → Validation → INSERT vào DB → Return kết quả

    public class ChucNangThemDuLieuDaoTao
    {
        // TODO: Trong tương lai, khi kết nối database, sẽ implement method này
        // public bool ThemChuongTrinhVaoDatabase(ThongTinDaoTao chuongTrinh)
        // {
        //     // BƯỚC 1: Tạo connection string và mở kết nối
        //     // string connectionString = "Data Source=...;Initial Catalog=UniversityDB;...";
        //     // using (SqlConnection conn = new SqlConnection(connectionString))
        //     // {
        //     //     conn.Open();
        //     //
        //     //     // BƯỚC 2: Tạo SQL INSERT command với parameters (tránh SQL Injection)
        //     //     string sql = "INSERT INTO ThongTinDaoTao (MaChuongTrinh, TenChuongTrinh, BacDaoTao, " +
        //     //                  "Khoa, SoNamDaoTao, TongTinChi, NamBatDau, MoTa, DieuKienTotNghiep, TrangThai) " +
        //     //                  "VALUES (@MaChuongTrinh, @TenChuongTrinh, @BacDaoTao, @Khoa, @SoNamDaoTao, " +
        //     //                  "@TongTinChi, @NamBatDau, @MoTa, @DieuKienTotNghiep, @TrangThai)";
        //     //
        //     //     using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //     {
        //     //         // BƯỚC 3: Add parameters để tránh SQL Injection
        //     //         cmd.Parameters.AddWithValue("@MaChuongTrinh", chuongTrinh.MaChuongTrinh);
        //     //         cmd.Parameters.AddWithValue("@TenChuongTrinh", chuongTrinh.TenChuongTrinh);
        //     //         cmd.Parameters.AddWithValue("@BacDaoTao", chuongTrinh.BacDaoTao);
        //     //         cmd.Parameters.AddWithValue("@Khoa", chuongTrinh.Khoa);
        //     //         cmd.Parameters.AddWithValue("@SoNamDaoTao", chuongTrinh.SoNamDaoTao);
        //     //         cmd.Parameters.AddWithValue("@TongTinChi", chuongTrinh.TongTinChi);
        //     //         cmd.Parameters.AddWithValue("@NamBatDau", chuongTrinh.NamBatDau);
        //     //         cmd.Parameters.AddWithValue("@MoTa", chuongTrinh.MoTa);
        //     //         cmd.Parameters.AddWithValue("@DieuKienTotNghiep", chuongTrinh.DieuKienTotNghiep);
        //     //         cmd.Parameters.AddWithValue("@TrangThai", chuongTrinh.TrangThai);
        //     //
        //     //         // BƯỚC 4: Execute command và kiểm tra kết quả
        //     //         int rowsAffected = cmd.ExecuteNonQuery();
        //     //         return rowsAffected > 0;
        //     //     }
        //     // }
        // }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 🔍 PHÂN TÍCH VẤN ĐỀ:
        // Làm thế nào để lưu thông tin chương trình đào tạo vào database SQL Server?
        //
        // 📝 GIẢI PHÁP (5 BƯỚC):
        //
        // BƯỚC 1: TẠO KẾT NỐI DATABASE
        // - Sử dụng SqlConnection với connection string
        // - Connection string chứa: Server, Database, User, Password
        // - using statement tự động đóng connection (dispose pattern)
        //
        // BƯỚC 2: TẠO SQL INSERT COMMAND
        // - Sử dụng parameterized query (không nối chuỗi trực tiếp)
        // - Parameters bắt đầu với @ (ví dụ: @MaChuongTrinh, @TenChuongTrinh)
        // - Tránh SQL Injection attack (lỗ hổng bảo mật nghiêm trọng)
        //
        // BƯỚC 3: THÊM PARAMETERS
        // - cmd.Parameters.AddWithValue("@TenParameter", giaTri)
        // - ADO.NET tự động escape special characters
        // - Type-safe: kiểm tra kiểu dữ liệu tự động
        //
        // BƯỚC 4: EXECUTE COMMAND
        // - ExecuteNonQuery() cho INSERT/UPDATE/DELETE
        // - Trả về số rows affected
        // - rowsAffected > 0 nghĩa là INSERT thành công
        //
        // BƯỚC 5: XỬ LÝ EXCEPTION
        // - try-catch để bắt SqlException
        // - Log error message để debug
        // - Return false nếu có lỗi
        //
        // ⚠️ SQL INJECTION LÀ GÌ?
        // VÍ DỤ SAI (dễ bị tấn công):
        //   string sql = "INSERT INTO ThongTinDaoTao VALUES ('" + ma + "', '" + ten + "')";
        //   Hacker nhập: ma = "CNTT'; DROP TABLE ThongTinDaoTao; --"
        //   → SQL thực thi: INSERT INTO ThongTinDaoTao VALUES ('CNTT'; DROP TABLE ThongTinDaoTao; --', ...)
        //   → Table bị xóa!!!
        //
        // VÍ DỤ ĐÚNG (an toàn):
        //   cmd.Parameters.AddWithValue("@MaChuongTrinh", ma);
        //   → ADO.NET tự động escape ký tự đặc biệt
        //   → Hacker không thể inject SQL code
        //
        // 📊 SO SÁNH VỚI BLL LAYER:
        // ┌─────────────────────┬──────────────────────┬──────────────────────┐
        // │     Đặc điểm        │      BLL Layer       │      DAL Layer       │
        // ├─────────────────────┼──────────────────────┼──────────────────────┤
        // │ Dữ liệu             │ In-memory List<T>    │ SQL Server Database  │
        // │ Validation          │ Có (business rules)  │ Không (chỉ CRUD)     │
        // │ Dependency          │ DTO classes          │ ADO.NET, DTO         │
        // │ Return type         │ bool hoặc object     │ bool hoặc DataTable  │
        // │ Error handling      │ Return false         │ throw SqlException   │
        // └─────────────────────┴──────────────────────┴──────────────────────┘
        //
        // 🎓 LƯU Ý CHO SINH VIÊN:
        // - Hiện tại dùng List<T> trong memory (BLL Layer)
        // - Sau này sẽ migrate sang SQL Server (DAL Layer)
        // - Code đã chuẩn bị sẵn, chỉ cần uncomment và config connection string
        // - Test trên local database trước khi deploy production
    }
}
