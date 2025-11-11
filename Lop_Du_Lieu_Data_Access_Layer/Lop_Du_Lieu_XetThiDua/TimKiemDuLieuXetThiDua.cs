using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;

namespace WinFormsHeThongTruongDaiHoc.Lop_Du_Lieu___Data_Access_Layer.Lop_Du_Lieu_XetThiDua
{
    // ==================== DATA ACCESS LAYER - TÌM KIẾM THÔNG TIN XÉT THI DỰA ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ DATABASE PROGRAMMING: SQL SELECT with WHERE, LIKE operator, JOIN
    // 2️⃣ PERFORMANCE OPTIMIZATION: Indexes, Query optimization, Full-text search
    // 3️⃣ DATA RETRIEVAL: SqlDataReader, DataTable, Mapping to DTO
    // 4️⃣ FILTERING & SORTING: Multiple search criteria, ORDER BY clause

    public class ChucNangTimKiemDuLieuXetThiDua
    {
        // TODO: Implement khi có database
        // public List<ThongTinXetThiDua> TimKiemTheoMaSinhVien(string maSinhVien)
        // {
        //     List<ThongTinXetThiDua> ketQua = new List<ThongTinXetThiDua>();
        //
        //     // SQL SELECT với LIKE operator
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE MaSinhVien LIKE @Ma ORDER BY NgayThi DESC";
        //     // cmd.Parameters.AddWithValue("@Ma", "%" + maSinhVien + "%");
        //     //
        //     // return ketQua;
        // }

        // public List<ThongTinXetThiDua> TimKiemTheoTenMonHoc(string tenMonHoc)
        // {
        //     // SQL SELECT với LIKE operator
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE TenMonHoc LIKE @TenMon ORDER BY DiemXetThiDua DESC";
        // }

        // public List<ThongTinXetThiDua> TimKiemTheoMaGiaoVien(string maGiaoVien)
        // {
        //     // SQL SELECT với JOIN để lấy thông tin giáo viên
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE MaGiaoVien = @MaGiaoVien ORDER BY NgayThi DESC";
        // }

        // public List<ThongTinXetThiDua> TimKiemTheoLoaiThi(string loaiThi)
        // {
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE LoaiThi = @LoaiThi ORDER BY NgayThi DESC";
        // }

        // public List<ThongTinXetThiDua> TimKiemTheoNgayThi(DateTime ngayBatDau, DateTime ngayKetThuc)
        // {
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE NgayThi BETWEEN @NgayBatDau AND @NgayKetThuc ORDER BY NgayThi DESC";
        // }

        // public List<ThongTinXetThiDua> TimKiemNangCao(string maSinhVien, string tenMonHoc, string maGiaoVien,
        //                                                 string loaiThi, decimal? diemTu, decimal? diemDen)
        // {
        //     // Tìm kiếm với nhiều tiêu chí
        //     // string sql = "SELECT * FROM KetQuaXetThiDua WHERE 1=1";
        //     //
        //     // if (!string.IsNullOrEmpty(maSinhVien))
        //     //     sql += " AND MaSinhVien LIKE @MaSinhVien";
        //     // if (!string.IsNullOrEmpty(tenMonHoc))
        //     //     sql += " AND TenMonHoc LIKE @TenMonHoc";
        //     // if (!string.IsNullOrEmpty(maGiaoVien))
        //     //     sql += " AND MaGiaoVien = @MaGiaoVien";
        //     // if (!string.IsNullOrEmpty(loaiThi))
        //     //     sql += " AND LoaiThi = @LoaiThi";
        //     // if (diemTu.HasValue && diemDen.HasValue)
        //     //     sql += " AND DiemXetThiDua BETWEEN @DiemTu AND @DiemDen";
        //     //
        //     // sql += " ORDER BY NgayThi DESC, DiemXetThiDua DESC";
        // }

        // 🔍 MAPPING DATAREADER TO DTO:
        // while (reader.Read())
        // {
        //     ThongTinXetThiDua xetThiDua = new ThongTinXetThiDua
        //     {
        //         ID = reader.GetInt32(reader.GetOrdinal("ID")),
        //         MaSinhVien = reader.GetString(reader.GetOrdinal("MaSinhVien")),
        //         MaGiaoVien = reader.GetString(reader.GetOrdinal("MaGiaoVien")),
        //         TenMonHoc = reader.GetString(reader.GetOrdinal("TenMonHoc")),
        //         DiemXetThiDua = reader.GetDecimal(reader.GetOrdinal("DiemXetThiDua")),
        //         SoLanThi = reader.GetInt32(reader.GetOrdinal("SoLanThi")),
        //         LoaiThi = reader.GetString(reader.GetOrdinal("LoaiThi")),
        //         NgayThi = reader.GetDateTime(reader.GetOrdinal("NgayThi")),
        //         GhiChu = reader.IsDBNull(reader.GetOrdinal("GhiChu")) ? "" : reader.GetString(reader.GetOrdinal("GhiChu"))
        //     };
        //     ketQua.Add(xetThiDua);
        // }

        // 📊 PERFORMANCE:
        // - LIKE '%abc%' → Full table scan (chậm)
        // - LIKE 'abc%' → Index seek (nhanh)
        // - Tạo INDEX trên MaSinhVien, TenMonHoc, MaGiaoVien để tăng tốc
        //
        // 🎯 CHỈ MỤC (INDEXES) NÊN TẠO:
        // - CREATE INDEX IX_MaSinhVien ON KetQuaXetThiDua (MaSinhVien)
        // - CREATE INDEX IX_TenMonHoc ON KetQuaXetThiDua (TenMonHoc)
        // - CREATE INDEX IX_MaGiaoVien ON KetQuaXetThiDua (MaGiaoVien)
        // - CREATE INDEX IX_LoaiThi ON KetQuaXetThiDua (LoaiThi)
        // - CREATE INDEX IX_NgayThi ON KetQuaXetThiDua (NgayThi)
        // - Composite index: CREATE INDEX IX_Sinh_Mon ON KetQuaXetThiDua (MaSinhVien, TenMonHoc)
        //
        // ⚠️ TRÁNH VIỆC:
        // - SELECT * (chỉ lấy columns cần thiết)
        // - LIKE '%abc%' với large tables (dùng Full-Text Search)
        // - Kiểm tra NULL có cách đúng: WHERE Column IS NULL (không dùng = NULL)
        //
        // 📌 TRỨ NGÀNH TÌM KIẾM:
        // - Sinh viên thường tìm kiếm: Môn học, Lần thi, Điểm
        // - Giáo viên thường tìm kiếm: Sinh viên, Môn, Ngày thi
        // - Khoa thường tìm kiếm: Ngày thi, Giáo viên, Kết quả (Đạt/Không đạt)
    }
}
