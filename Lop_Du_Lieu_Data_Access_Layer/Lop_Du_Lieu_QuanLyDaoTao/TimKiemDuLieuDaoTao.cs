using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_QuanLyDaoTao
{
    // ==================== DATA ACCESS LAYER - TÌM KIẾM THÔNG TIN ĐÀO TẠO ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL SELECT with WHERE, LIKE operator
    // 2️⃣ PERFORMANCE OPTIMIZATION: Indexes, Query optimization
    // 3️⃣ DATA RETRIEVAL: SqlDataReader, DataTable, Mapping to DTO

    public class ChucNangTimKiemDuLieuDaoTao
    {
        // TODO: Implement khi có database
        // public List<ThongTinDaoTao> TimKiemTheoMa(string ma)
        // {
        //     // SQL SELECT với LIKE operator
        //     // string sql = "SELECT * FROM ThongTinDaoTao WHERE MaChuongTrinh LIKE @Ma";
        //     // cmd.Parameters.AddWithValue("@Ma", "%" + ma + "%");
        //
        //     // 📊 PERFORMANCE:
        //     // - LIKE '%abc%' → Full table scan (chậm)
        //     // - LIKE 'abc%' → Index seek (nhanh)
        //     // - Tạo INDEX trên MaChuongTrinh để tăng tốc
        // }

        // public List<ThongTinDaoTao> TimKiemTheoKhoa(string khoa)
        // {
        //     // string sql = "SELECT * FROM ThongTinDaoTao WHERE Khoa LIKE @Khoa";
        // }

        // public List<ThongTinDaoTao> TimKiemTheoBac(string bac)
        // {
        //     // string sql = "SELECT * FROM ThongTinDaoTao WHERE BacDaoTao LIKE @Bac";
        // }

        // 🔍 MAPPING DATAREADER TO DTO:
        // while (reader.Read())
        // {
        //     ThongTinDaoTao ct = new ThongTinDaoTao
        //     {
        //         ID = reader.GetInt32(0),
        //         MaChuongTrinh = reader.GetString(1),
        //         TenChuongTrinh = reader.GetString(2),
        //         // ... map các columns khác
        //     };
        //     ketQua.Add(ct);
        // }
    }
}
