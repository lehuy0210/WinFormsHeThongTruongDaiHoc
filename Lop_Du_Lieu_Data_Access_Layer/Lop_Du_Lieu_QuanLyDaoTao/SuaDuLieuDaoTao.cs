using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyDaoTao
{
    // ==================== DATA ACCESS LAYER - SỬA THÔNG TIN ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL UPDATE statement, SET clause, WHERE clause
    // 2️⃣ CONCURRENCY CONTROL: Optimistic locking, Timestamp column
    // 3️⃣ VALIDATION: Data integrity, business rules

    public class ChucNangSuaDuLieuDaoTao
    {
        // TODO: Implement khi có database
        // public bool SuaChuongTrinhTrongDatabase(string maCu, ThongTinDaoTao ctMoi)
        // {
        //     // SQL UPDATE với WHERE clause
        //     // string sql = "UPDATE ThongTinDaoTao SET " +
        //     //              "TenChuongTrinh = @TenChuongTrinh, " +
        //     //              "BacDaoTao = @BacDaoTao, " +
        //     //              "Khoa = @Khoa, " +
        //     //              "SoNamDaoTao = @SoNamDaoTao, " +
        //     //              "TongTinChi = @TongTinChi, " +
        //     //              "NamBatDau = @NamBatDau, " +
        //     //              "MoTa = @MoTa, " +
        //     //              "DieuKienTotNghiep = @DieuKienTotNghiep, " +
        //     //              "TrangThai = @TrangThai " +
        //     //              "WHERE MaChuongTrinh = @MaCu";
        // }

        // 🔍 CONCURRENCY ISSUES:
        // Vấn đề: 2 users cùng sửa 1 record
        // - User A đọc dữ liệu lúc 10:00
        // - User B đọc dữ liệu lúc 10:01
        // - User A save lúc 10:02
        // - User B save lúc 10:03 → Overwrite changes của User A!
        //
        // GIẢI PHÁP: Optimistic Locking
        // - Thêm column Timestamp hoặc RowVersion
        // - WHERE clause: WHERE MaChuongTrinh = @Ma AND RowVersion = @OldVersion
        // - Nếu rowsAffected = 0 → Record đã bị sửa bởi user khác
    }
}
