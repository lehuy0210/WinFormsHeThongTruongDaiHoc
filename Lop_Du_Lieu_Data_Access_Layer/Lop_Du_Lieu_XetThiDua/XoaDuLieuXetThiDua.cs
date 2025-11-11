using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetThiDua
{
    // ==================== DATA ACCESS LAYER - XÓA THÔNG TIN XÉT THI DỰA ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL DELETE statement, WHERE clause
    // 2️⃣ TRANSACTION MANAGEMENT: BEGIN TRANSACTION, COMMIT, ROLLBACK
    // 3️⃣ REFERENTIAL INTEGRITY: Foreign Key constraints, CASCADE Delete
    // 4️⃣ EXCEPTION HANDLING: SqlException handling, error logging

    public class ChucNangXoaDuLieuXetThiDua
    {
        // TODO: Implement khi có database
        // public bool XoaKetQuaXetThiDuaKhoiDatabase(string maSinhVien, string tenMonHoc, int soLanThi)
        // {
        //     // SQL DELETE với WHERE clause
        //     // string sql = "DELETE FROM KetQuaXetThiDua WHERE MaSinhVien = @MaSinhVien " +
        //     //              "AND TenMonHoc = @TenMonHoc AND SoLanThi = @SoLanThi";
        //
        //     //     using (SqlConnection conn = new SqlConnection(connectionString))
        //     //     {
        //     //         conn.Open();
        //     //         using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //         {
        //     //             cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
        //     //             cmd.Parameters.AddWithValue("@TenMonHoc", tenMonHoc);
        //     //             cmd.Parameters.AddWithValue("@SoLanThi", soLanThi);
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
        // ⚠️ BEST PRACTICE CHO XÉT THI DỰA:
        // - Soft delete: Thêm cột IsDeleted = true thay vì xóa thật
        //   (Vì lý do audit trail - cần lưu lịch sử thi dụa của sinh viên)
        // - Hard delete: Xóa vật lý khỏi database (nguy hiểm, không nên dùng)
        // - Backup database trước khi xóa dữ liệu quan trọng
        //
        // 📋 WORKFLOW XÓA AN TOÀN:
        // 1. Kiểm tra sinh viên có đang trong process thi dụa không
        // 2. Kiểm tra xem đã được tính điểm cuối cùng chưa
        // 3. Update IsDeleted = true (soft delete)
        // 4. Log thông tin xóa: UserID, NgayXoa, LyDoXoa
        // 5. Commit transaction
        //
        // 🔐 QUYỀN HẠN:
        // - Chỉ admin hoặc trưởng khoa mới được xóa kết quả xét thi dụa
        // - Không cho xóa các bản ghi cũ hơn 1 năm
        //
        // 📌 LƯỚI XÓẢN:
        // - Không được xóa kết quả thi nếu đã nhập điểm cuối cùng
        // - Không được xóa nếu sinh viên đã graduation
        // - Phải ghi lại lý do xóa trong bảng audit log
    }
}
