using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetTotNghiep
{
    // ==================== DATA ACCESS LAYER - XÓA THÔNG TIN XÉT TỐT NGHIỆP ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL DELETE statement, WHERE clause
    // 2️⃣ TRANSACTION MANAGEMENT: BEGIN TRANSACTION, COMMIT, ROLLBACK
    // 3️⃣ REFERENTIAL INTEGRITY: Foreign Key constraints, CASCADE Delete
    // 4️⃣ EXCEPTION HANDLING: SqlException handling, error logging

    public class ChucNangXoaDuLieuXetTotNghiep
    {
        // TODO: Implement khi có database
        // public bool XoaKetQuaXetTotNghiepKhoiDatabase(string maSinhVien, int namXet)
        // {
        //     // SQL DELETE với WHERE clause
        //     // string sql = "DELETE FROM KetQuaXetTotNghiep WHERE MaSinhVien = @MaSinhVien AND NamXet = @NamXet";
        //
        //     //     using (SqlConnection conn = new SqlConnection(connectionString))
        //     //     {
        //     //         conn.Open();
        //     //         using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //         {
        //     //             cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
        //     //             cmd.Parameters.AddWithValue("@NamXet", namXet);
        //     //             int rowsAffected = cmd.ExecuteNonQuery();
        //     //             return rowsAffected > 0;
        //     //         }
        //     //     }
        // }

        // 🔍 GIẢI THÍCH:
        // DELETE operation nguy hiểm hơn INSERT/UPDATE vì:
        // 1. Dữ liệu bị mất vĩnh viễn (không thể undo)
        // 2. Có thể vi phạm Foreign Key constraints
        // 3. Cần confirm từ user trước khi xóa
        //
        // ⚠️ BEST PRACTICE CHO XÉT TỐT NGHIỆP:
        // - Soft delete: Thêm cột IsDeleted = true thay vì xóa thật
        //   (Vì lý do audit trail - cần lưu lịch sử xét tốt nghiệp)
        // - Hard delete: Xóa vật lý khỏi database (nguy hiểm, không nên dùng)
        // - Backup database trước khi xóa dữ liệu quan trọng
        //
        // 📋 WORKFLOW XÓA AN TOÀN:
        // 1. Kiểm tra sinh viên có đang trong process xét không
        // 2. Kiểm tra xem đã được cấp bằng chưa
        // 3. Update IsDeleted = true (soft delete)
        // 4. Log thông tin xóa: UserID, NgayXoa, LyDoXoa
        // 5. Commit transaction
        //
        // 🔐 QUYỀN HẠN:
        // - Chỉ admin hoặc trưởng khoa mới được xóa kết quả xét
        // - Không cho xóa các bản ghi cũ hơn 1 năm
    }
}
