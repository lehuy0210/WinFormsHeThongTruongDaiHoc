using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetTotNghiep
{
    // ==================== DATA ACCESS LAYER - TÌM KIẾM THÔNG TIN XÉT TỐT NGHIỆP ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL SELECT with WHERE, LIKE operator, JOIN
    // 2️⃣ PERFORMANCE OPTIMIZATION: Indexes, Query optimization, Full-text search
    // 3️⃣ DATA RETRIEVAL: SqlDataReader, DataTable, Mapping to DTO
    // 4️⃣ FILTERING & SORTING: Multiple search criteria, ORDER BY clause

    public class ChucNangTimKiemDuLieuXetTotNghiep
    {
        // TODO: Implement khi có database
        // public List<ThongTinXetTotNghiep> TimKiemTheoMaSinhVien(string maSinhVien)
        // {
        //     List<ThongTinXetTotNghiep> ketQua = new List<ThongTinXetTotNghiep>();
        //
        //     // SQL SELECT với LIKE operator
        //     // string sql = "SELECT * FROM KetQuaXetTotNghiep WHERE MaSinhVien LIKE @Ma ORDER BY NamXet DESC";
        //     // cmd.Parameters.AddWithValue("@Ma", "%" + maSinhVien + "%");
        //     //
        //     // return ketQua;
        // }

        // public List<ThongTinXetTotNghiep> TimKiemTheoKhoa(string maKhoa)
        // {
        //     // SQL SELECT với JOIN
        //     // string sql = "SELECT * FROM KetQuaXetTotNghiep WHERE MaKhoa = @MaKhoa ORDER BY NamXet DESC, DiemTrungBinh DESC";
        // }

        // public List<ThongTinXetTotNghiep> TimKiemTheoTrangThai(string trangThai)
        // {
        //     // string sql = "SELECT * FROM KetQuaXetTotNghiep WHERE TrangThaiXet = @TrangThai ORDER BY NgayCapNhat DESC";
        // }

        // public List<ThongTinXetTotNghiep> TimKiemTheoNam(int nam)
        // {
        //     // string sql = "SELECT * FROM KetQuaXetTotNghiep WHERE NamXet = @Nam ORDER BY MaSinhVien";
        // }

        // public List<ThongTinXetTotNghiep> TimKiemNangCao(string maSinhVien, string maKhoa, int? nam, string trangThai)
        // {
        //     // Tìm kiếm với nhiều tiêu chí
        //     // string sql = "SELECT * FROM KetQuaXetTotNghiep WHERE 1=1";
        //     //
        //     // if (!string.IsNullOrEmpty(maSinhVien))
        //     //     sql += " AND MaSinhVien LIKE @MaSinhVien";
        //     // if (!string.IsNullOrEmpty(maKhoa))
        //     //     sql += " AND MaKhoa = @MaKhoa";
        //     // if (nam.HasValue)
        //     //     sql += " AND NamXet = @Nam";
        //     // if (!string.IsNullOrEmpty(trangThai))
        //     //     sql += " AND TrangThaiXet = @TrangThai";
        //     //
        //     // sql += " ORDER BY NamXet DESC, DiemTrungBinh DESC";
        // }

        // 🔍 MAPPING DATAREADER TO DTO:
        // while (reader.Read())
        // {
        //     ThongTinXetTotNghiep xet = new ThongTinXetTotNghiep
        //     {
        //         ID = reader.GetInt32(reader.GetOrdinal("ID")),
        //         MaSinhVien = reader.GetString(reader.GetOrdinal("MaSinhVien")),
        //         MaKhoa = reader.GetString(reader.GetOrdinal("MaKhoa")),
        //         DiemTrungBinh = reader.GetDecimal(reader.GetOrdinal("DiemTrungBinh")),
        //         SoTinChiDat = reader.GetInt32(reader.GetOrdinal("SoTinChiDat")),
        //         TrangThaiXet = reader.GetString(reader.GetOrdinal("TrangThaiXet")),
        //         NamXet = reader.GetInt32(reader.GetOrdinal("NamXet")),
        //         GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? "" : reader.GetString(reader.GetOrdinal("GhiChu"))
        //     };
        //     ketQua.Add(xet);
        // }

        // 📊 PERFORMANCE:
        // - LIKE '%abc%' → Full table scan (chậm)
        // - LIKE 'abc%' → Index seek (nhanh)
        // - Tạo INDEX trên MaSinhVien, MaKhoa, NamXet để tăng tốc
        //
        // 🎯 CHỈ MỤC (INDEXES) NÊN TẠO:
        // - CREATE INDEX IX_MaSinhVien ON KetQuaXetTotNghiep (MaSinhVien)
        // - CREATE INDEX IX_MaKhoa ON KetQuaXetTotNghiep (MaKhoa)
        // - CREATE INDEX IX_NamXet ON KetQuaXetTotNghiep (NamXet)
        // - CREATE INDEX IX_TrangThaiXet ON KetQuaXetTotNghiep (TrangThaiXet)
        // - Composite index: CREATE INDEX IX_Khoa_Tranghai ON KetQuaXetTotNghiep (MaKhoa, TrangThaiXet)
        //
        // ⚠️ TRÁNH VIỆC:
        // - SELECT * (chỉ lấy columns cần thiết)
        // - LIKE '%abc%' với large tables (dùng Full-Text Search)
        // - Kiểm tra NULL có cách đúng: WHERE Column IS NULL (không dùng = NULL)
    }
}
