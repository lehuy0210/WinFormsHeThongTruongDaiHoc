using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetThiDua
{
    // ==================== DATA ACCESS LAYER - SỬA THÔNG TIN XÉT THI DỰA ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL UPDATE statement, SET clause, WHERE clause
    // 2️⃣ CONCURRENCY CONTROL: Optimistic locking, Timestamp column, RowVersion
    // 3️⃣ VALIDATION: Data integrity, business rules
    // 4️⃣ AUDIT TRAIL: Tracking changes, update history

    public class ChucNangSuaDuLieuXetThiDua
    {
        // TODO: Implement khi có database
        // public bool SuaKetQuaXetThiDuaTrongDatabase(string maSinhVien, string tenMonHoc,
        //                                              int soLanCu, ThongTinXetThiDua ketQuaMoi)
        // {
        //     // SQL UPDATE với WHERE clause
        //     // string sql = "UPDATE KetQuaXetThiDua SET " +
        //     //              "DiemXetThiDua = @DiemXetThiDua, " +
        //     //              "SoLanThi = @SoLanThi, " +
        //     //              "LoaiThi = @LoaiThi, " +
        //     //              "NgayThi = @NgayThi, " +
        //     //              "GhiChu = @GhiChu, " +
        //     //              "NgayCapNhat = @NgayCapNhat " +
        //     //              "WHERE MaSinhVien = @MaSinhVien AND TenMonHoc = @TenMonHoc " +
        //     //              "AND SoLanThi = @SoLanCu AND RowVersion = @OldRowVersion";
        //     //
        //     //     using (SqlConnection conn = new SqlConnection(connectionString))
        //     //     {
        //     //         conn.Open();
        //     //         using (SqlCommand cmd = new SqlCommand(sql, conn))
        //     //         {
        //     //             cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
        //     //             cmd.Parameters.AddWithValue("@TenMonHoc", tenMonHoc);
        //     //             cmd.Parameters.AddWithValue("@SoLanCu", soLanCu);
        //     //             cmd.Parameters.AddWithValue("@DiemXetThiDua", ketQuaMoi.DiemXetThiDua);
        //     //             cmd.Parameters.AddWithValue("@SoLanThi", ketQuaMoi.SoLanThi);
        //     //             cmd.Parameters.AddWithValue("@LoaiThi", ketQuaMoi.LoaiThi);
        //     //             cmd.Parameters.AddWithValue("@NgayThi", ketQuaMoi.NgayThi);
        //     //             cmd.Parameters.AddWithValue("@GhiChu", ketQuaMoi.GhiChu);
        //     //             cmd.Parameters.AddWithValue("@NgayCapNhat", DateTime.Now);
        //     //             cmd.Parameters.AddWithValue("@OldRowVersion", ketQuaMoi.RowVersion);
        //     //
        //     //             int rowsAffected = cmd.ExecuteNonQuery();
        //     //             if (rowsAffected == 0)
        //     //                 throw new Exception("Record đã bị sửa bởi user khác");
        //     //             return true;
        //     //         }
        //     //     }
        // }

        // 🔍 CONCURRENCY ISSUES:
        // Vấn đề: 2 users cùng sửa 1 kết quả xét thi dụa
        // - User A đọc dữ liệu lúc 10:00
        // - User B đọc dữ liệu lúc 10:01
        // - User A save lúc 10:02 (Change: DiemXetThiDua = 7.5)
        // - User B save lúc 10:03 (Change: LoaiThi = 'Thi lại') → Overwrite changes của User A!
        //
        // 📋 GIẢI PHÁP: Optimistic Locking
        // - Thêm column RowVersion (timestamp)
        // - WHERE clause: WHERE MaSinhVien = @Ma AND RowVersion = @OldVersion
        // - Nếu rowsAffected = 0 → Record đã bị sửa bởi user khác
        //
        // 🎯 WORKFLOW CẬP NHẬT:
        // 1. Load kết quả xét thi dụa → Lưu RowVersion cũ
        // 2. User sửa dữ liệu
        // 3. Thực hiện UPDATE với WHERE clause kiểm tra RowVersion
        // 4. Nếu RowVersion khác nhau → Yêu cầu reload dữ liệu mới nhất
        // 5. Xóa bản sửa của user, người dùng phải sửa lại trên bản mới nhất
        //
        // 🔐 AUDIT TRAIL - TRACKING CHANGES:
        // - Tạo bảng XetThiDuaChanges để lưu lịch sử thay đổi
        // - Mỗi lần UPDATE → Ghi lại: MaSinhVien, NgayCapNhat, UserCapNhat, GiaTriCu, GiaTriMoi
        // - Giúp kiểm tra ai đã sửa cái gì vào lúc nào
        //
        // 📌 CHÍNH SÁCH SỬA THÔNG TIN THI DỰA:
        // - Chỉ có thể sửa nếu kết quả chưa được duyệt (status = 'Đang soạn')
        // - Không được sửa điểm nếu đã được giáo viên khác chấm
        // - Phải ghi lại lý do sửa trong bảng log
    }
}
