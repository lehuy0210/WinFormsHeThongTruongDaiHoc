using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyDaoTao
{
    // ==================== DATA ACCESS LAYER - XÓA THÔNG TIN ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL DELETE statement, WHERE clause
    // 2️⃣ TRANSACTION MANAGEMENT: BEGIN TRANSACTION, COMMIT, ROLLBACK
    // 3️⃣ REFERENTIAL INTEGRITY: Foreign Key constraints, CASCADE DELETE
    // 4️⃣ EXCEPTION HANDLING: SqlException handling, error logging

    public class ChucNangXoaDuLieuDaoTao
    {
        // TODO: Implement khi có database
        // public bool XoaChuongTrinhKhoiDatabase(string maChuongTrinh)
        // {
        //     // SQL DELETE với WHERE clause
        //     // string sql = "DELETE FROM ThongTinDaoTao WHERE MaChuongTrinh = @MaChuongTrinh";
        //
        //     // ⚠️ LƯU Ý: Kiểm tra Foreign Key constraints trước khi xóa
        //     // - Nếu có sinh viên đang học chương trình này → không cho xóa
        //     // - Hoặc dùng CASCADE DELETE để xóa cả dữ liệu liên quan
        // }

        // 🔍 GIẢI THÍCH:
        // DELETE operation nguy hiểm hơn INSERT/UPDATE vì:
        // 1. Dữ liệu bị mất vĩnh viễn (không thể undo)
        // 2. Có thể vi phạm Foreign Key constraints
        // 3. Cần confirm từ user trước khi xóa
        //
        // BEST PRACTICE:
        // - Soft delete: Thêm cột IsDeleted = true thay vì xóa thật
        // - Hard delete: Xóa vật lý khỏi database (nguy hiểm)
        // - Backup database trước khi xóa dữ liệu quan trọng
    }
}
