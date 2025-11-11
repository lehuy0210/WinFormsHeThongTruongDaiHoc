-- ==================== HỆ THỐNG QUẢN LÝ TRƯỜNG ĐẠI HỌC - DATABASE SCRIPT ====================
-- 📚 KIẾN THỨC ÁP DỤNG:
-- 1️⃣ DATABASE DESIGN: Tables, Relationships, Normalization (3NF)
-- 2️⃣ SQL DDL: CREATE DATABASE, CREATE TABLE, ALTER TABLE, CREATE INDEX
-- 3️⃣ SQL CONSTRAINTS: PRIMARY KEY, FOREIGN KEY, UNIQUE, CHECK, DEFAULT
-- 4️⃣ SQL DML: INSERT, UPDATE, DELETE, SELECT
-- 5️⃣ STORED PROCEDURES: CREATE PROCEDURE, Parameters, OUTPUT
-- 6️⃣ VIEWS: CREATE VIEW, Complex queries
-- 7️⃣ INDEXES: Clustered, Non-clustered, Performance optimization
--
-- 💡 MỤC ĐÍCH:
-- Tạo database hoàn chỉnh cho hệ thống quản lý trường đại học
-- Bao gồm: Sinh viên, Giảng viên, Môn học, Lớp học, Điểm, Hồ sơ,
--          Đào tạo, Xét tốt nghiệp, Xét thi đua
--
-- ⚙️ CÁCH SỬ DỤNG:
-- 1. Mở SQL Server Management Studio (SSMS)
-- 2. Connect to SQL Server instance
-- 3. Open this file and Execute (F5)
-- 4. Database và tất cả objects sẽ được tạo tự động

USE master;
GO

-- ==================== BƯỚC 1: TẠO DATABASE ====================
-- DROP database nếu đã tồn tại (cẩn thận trong production!)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'HeThongTruongDaiHoc')
BEGIN
    ALTER DATABASE HeThongTruongDaiHoc SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HeThongTruongDaiHoc;
END
GO

CREATE DATABASE HeThongTruongDaiHoc
ON PRIMARY
(
    NAME = N'HeThongTruongDaiHoc_Data',
    FILENAME = N'C:\Database\HeThongTruongDaiHoc_Data.mdf',
    SIZE = 100MB,
    MAXSIZE = UNLIMITED,
    FILEGROWTH = 10MB
)
LOG ON
(
    NAME = N'HeThongTruongDaiHoc_Log',
    FILENAME = N'C:\Database\HeThongTruongDaiHoc_Log.ldf',
    SIZE = 50MB,
    MAXSIZE = 1GB,
    FILEGROWTH = 5MB
);
GO

USE HeThongTruongDaiHoc;
GO

-- ==================== BƯỚC 2: TẠO TABLES ====================

-- TABLE 1: THÔNG TIN SINH VIÊN
CREATE TABLE ThongTinSinhVien
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSinhVien NVARCHAR(20) NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    Khoa NVARCHAR(100) NOT NULL,
    Nganh NVARCHAR(100) NOT NULL,
    KhoaHoc NVARCHAR(20) NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- INDEX cho tìm kiếm nhanh
CREATE NONCLUSTERED INDEX IX_ThongTinSinhVien_MaSinhVien ON ThongTinSinhVien(MaSinhVien);
CREATE NONCLUSTERED INDEX IX_ThongTinSinhVien_Khoa ON ThongTinSinhVien(Khoa);
CREATE NONCLUSTERED INDEX IX_ThongTinSinhVien_HoTen ON ThongTinSinhVien(HoTen);
GO

-- TABLE 2: THÔNG TIN GIẢNG VIÊN
CREATE TABLE ThongTinGiangVien
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaGiangVien NVARCHAR(20) NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100),
    Khoa NVARCHAR(100) NOT NULL,
    ChuyenNganh NVARCHAR(100),
    HocVi NVARCHAR(50), -- Cử nhân, Thạc sĩ, Tiến sĩ
    HocHam NVARCHAR(50), -- Giảng viên, Giảng viên chính, Phó giáo sư, Giáo sư
    NgayVaoLam DATE,
    NgayTao DATETIME DEFAULT GETDATE(),
    NgayCapNhat DATETIME DEFAULT GETDATE()
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinGiangVien_MaGiangVien ON ThongTinGiangVien(MaGiangVien);
CREATE NONCLUSTERED INDEX IX_ThongTinGiangVien_Khoa ON ThongTinGiangVien(Khoa);
GO

-- TABLE 3: THÔNG TIN MÔN HỌC
CREATE TABLE ThongTinMonHoc
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaMonHoc NVARCHAR(20) NOT NULL UNIQUE,
    TenMonHoc NVARCHAR(200) NOT NULL,
    SoTinChi INT NOT NULL CHECK (SoTinChi > 0),
    TietLyThuyet INT NOT NULL DEFAULT 0,
    TietThucHanh INT NOT NULL DEFAULT 0,
    Khoa NVARCHAR(100) NOT NULL,
    MoTa NTEXT,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinMonHoc_MaMonHoc ON ThongTinMonHoc(MaMonHoc);
CREATE NONCLUSTERED INDEX IX_ThongTinMonHoc_Khoa ON ThongTinMonHoc(Khoa);
GO

-- TABLE 4: THÔNG TIN LỚP HỌC
CREATE TABLE ThongTinLopHoc
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaLopHoc NVARCHAR(20) NOT NULL UNIQUE,
    TenLopHoc NVARCHAR(100) NOT NULL,
    MaMonHoc NVARCHAR(20) NOT NULL,
    MaGiangVien NVARCHAR(20) NOT NULL,
    HocKy NVARCHAR(20) NOT NULL, -- HK1 2023-2024
    NamHoc NVARCHAR(20) NOT NULL, -- 2023-2024
    PhongHoc NVARCHAR(50),
    ThoiGianHoc NVARCHAR(100), -- Thứ 2, 7h-9h
    SiSoToiDa INT DEFAULT 50,
    SiSoHienTai INT DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Đang mở', -- Đang mở, Đã đóng, Đang học, Đã kết thúc
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaMonHoc) REFERENCES ThongTinMonHoc(MaMonHoc),
    FOREIGN KEY (MaGiangVien) REFERENCES ThongTinGiangVien(MaGiangVien)
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinLopHoc_MaLopHoc ON ThongTinLopHoc(MaLopHoc);
CREATE NONCLUSTERED INDEX IX_ThongTinLopHoc_HocKy ON ThongTinLopHoc(HocKy);
GO

-- TABLE 5: THÔNG TIN ĐIỂM
CREATE TABLE ThongTinDiem
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSinhVien NVARCHAR(20) NOT NULL,
    MaMonHoc NVARCHAR(20) NOT NULL,
    MaLopHoc NVARCHAR(20) NOT NULL,
    DiemChuyenCan FLOAT CHECK (DiemChuyenCan >= 0 AND DiemChuyenCan <= 10),
    DiemGiuaKy FLOAT CHECK (DiemGiuaKy >= 0 AND DiemGiuaKy <= 10),
    DiemCuoiKy FLOAT CHECK (DiemCuoiKy >= 0 AND DiemCuoiKy <= 10),
    DiemTongKet FLOAT CHECK (DiemTongKet >= 0 AND DiemTongKet <= 10),
    DiemChu NVARCHAR(2), -- A+, A, B+, B, C+, C, D+, D, F
    HocKy NVARCHAR(20) NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,
    GhiChu NVARCHAR(255),
    NgayNhapDiem DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaSinhVien) REFERENCES ThongTinSinhVien(MaSinhVien),
    FOREIGN KEY (MaMonHoc) REFERENCES ThongTinMonHoc(MaMonHoc),
    FOREIGN KEY (MaLopHoc) REFERENCES ThongTinLopHoc(MaLopHoc),
    UNIQUE (MaSinhVien, MaMonHoc, HocKy) -- Mỗi sinh viên chỉ có 1 điểm/môn/học kỳ
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinDiem_MaSinhVien ON ThongTinDiem(MaSinhVien);
CREATE NONCLUSTERED INDEX IX_ThongTinDiem_MaMonHoc ON ThongTinDiem(MaMonHoc);
CREATE NONCLUSTERED INDEX IX_ThongTinDiem_HocKy ON ThongTinDiem(HocKy);
GO

-- TABLE 6: THÔNG TIN HỒ SƠ (Tuyển sinh, Nhân sự, Khen thưởng, Kỷ luật)
CREATE TABLE ThongTinHoSo
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaHoSo NVARCHAR(30) NOT NULL UNIQUE, -- HS-TS-2024-001
    LoaiHoSo NVARCHAR(50) NOT NULL CHECK (LoaiHoSo IN (N'Tuyển sinh', N'Nhân sự', N'Khen thưởng', N'Kỷ luật')),
    MaDoiTuong NVARCHAR(20) NOT NULL, -- Mã SV hoặc Mã GV
    TenDoiTuong NVARCHAR(100) NOT NULL,
    NgayNop DATE NOT NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xử lý', -- Chờ xử lý, Đầy đủ, Đã duyệt, Từ chối
    DanhSachGiayTo NVARCHAR(500), -- Separated by semicolon
    FileDinhKem NVARCHAR(255),
    NguoiXuLy NVARCHAR(100),
    NgayXuLy DATE,
    KetQuaXuLy NVARCHAR(255),
    GhiChu NTEXT,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinHoSo_MaHoSo ON ThongTinHoSo(MaHoSo);
CREATE NONCLUSTERED INDEX IX_ThongTinHoSo_LoaiHoSo ON ThongTinHoSo(LoaiHoSo);
CREATE NONCLUSTERED INDEX IX_ThongTinHoSo_MaDoiTuong ON ThongTinHoSo(MaDoiTuong);
GO

-- TABLE 7: THÔNG TIN CHƯƠNG TRÌNH ĐÀO TẠO
CREATE TABLE ThongTinDaoTao
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaChuongTrinh NVARCHAR(20) NOT NULL UNIQUE,
    TenChuongTrinh NVARCHAR(200) NOT NULL,
    BacDaoTao NVARCHAR(50) NOT NULL CHECK (BacDaoTao IN (N'Cử nhân', N'Thạc sĩ', N'Tiến sĩ')),
    Khoa NVARCHAR(100) NOT NULL,
    SoNamDaoTao INT NOT NULL CHECK (SoNamDaoTao > 0),
    TongTinChi INT NOT NULL CHECK (TongTinChi > 0),
    NamBatDau INT NOT NULL,
    MoTa NTEXT,
    DieuKienTotNghiep NTEXT,
    TrangThai NVARCHAR(50) DEFAULT N'Đang áp dụng', -- Đang áp dụng, Ngừng tuyển
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinDaoTao_MaChuongTrinh ON ThongTinDaoTao(MaChuongTrinh);
CREATE NONCLUSTERED INDEX IX_ThongTinDaoTao_Khoa ON ThongTinDaoTao(Khoa);
GO

-- TABLE 8: THÔNG TIN XÉT TỐT NGHIỆP
CREATE TABLE ThongTinXetTotNghiep
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSinhVien NVARCHAR(20) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Khoa NVARCHAR(100) NOT NULL,
    Nganh NVARCHAR(100) NOT NULL,
    KhoaHoc NVARCHAR(20) NOT NULL,
    TongTinChiTichLuy INT NOT NULL,
    DiemTrungBinhTichLuy FLOAT NOT NULL CHECK (DiemTrungBinhTichLuy >= 0 AND DiemTrungBinhTichLuy <= 4.0),
    DiemRenLuyen INT NOT NULL CHECK (DiemRenLuyen >= 0 AND DiemRenLuyen <= 100),
    SoMonNo INT NOT NULL DEFAULT 0,
    DiemNgoaiNgu INT NOT NULL DEFAULT 0, -- TOEIC score
    TrangThaiKhoaLuan NVARCHAR(50) DEFAULT N'Chưa đăng ký',
    DieuKienTotNghiep NVARCHAR(500),
    KetQuaXet NVARCHAR(50), -- Đủ điều kiện, Không đủ điều kiện, Tốt nghiệp có điều kiện
    XepLoaiTotNghiep NVARCHAR(50), -- Xuất sắc, Giỏi, Khá, Trung bình
    NgayXet DATE NOT NULL,
    HocKyTotNghiep NVARCHAR(20) NOT NULL,
    GhiChu NTEXT,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaSinhVien) REFERENCES ThongTinSinhVien(MaSinhVien),
    UNIQUE (MaSinhVien, HocKyTotNghiep) -- Mỗi sinh viên chỉ xét 1 lần/học kỳ
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinXetTotNghiep_MaSinhVien ON ThongTinXetTotNghiep(MaSinhVien);
CREATE NONCLUSTERED INDEX IX_ThongTinXetTotNghiep_KetQuaXet ON ThongTinXetTotNghiep(KetQuaXet);
CREATE NONCLUSTERED INDEX IX_ThongTinXetTotNghiep_HocKyTotNghiep ON ThongTinXetTotNghiep(HocKyTotNghiep);
GO

-- TABLE 9: THÔNG TIN XÉT THI ĐUA (cho cả Sinh viên và Giảng viên)
CREATE TABLE ThongTinXetThiDua
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    LoaiDoiTuong NVARCHAR(20) NOT NULL CHECK (LoaiDoiTuong IN (N'Sinh viên', N'Giảng viên')),
    MaDoiTuong NVARCHAR(20) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Khoa NVARCHAR(100) NOT NULL,
    HocKy NVARCHAR(50) NOT NULL,
    -- Điểm cho SINH VIÊN (Điểm rèn luyện)
    DiemYThucHocTap INT DEFAULT 0 CHECK (DiemYThucHocTap >= 0 AND DiemYThucHocTap <= 20),
    DiemThamGiaHoatDong INT DEFAULT 0 CHECK (DiemThamGiaHoatDong >= 0 AND DiemThamGiaHoatDong <= 30),
    DiemYThucCongDan INT DEFAULT 0 CHECK (DiemYThucCongDan >= 0 AND DiemYThucCongDan <= 20),
    DiemQuanHeCongDong INT DEFAULT 0 CHECK (DiemQuanHeCongDong >= 0 AND DiemQuanHeCongDong <= 20),
    SoLanViPham INT DEFAULT 0,
    -- Điểm cho GIẢNG VIÊN (Đánh giá giảng dạy)
    DiemNangLucChuyenMon INT DEFAULT 0 CHECK (DiemNangLucChuyenMon >= 0 AND DiemNangLucChuyenMon <= 30),
    DiemPhuongPhapGiangDay INT DEFAULT 0 CHECK (DiemPhuongPhapGiangDay >= 0 AND DiemPhuongPhapGiangDay <= 30),
    DiemThaiDoVoiSinhVien INT DEFAULT 0 CHECK (DiemThaiDoVoiSinhVien >= 0 AND DiemThaiDoVoiSinhVien <= 20),
    DiemNghienCuuKhoaHoc INT DEFAULT 0 CHECK (DiemNghienCuuKhoaHoc >= 0 AND DiemNghienCuuKhoaHoc <= 20),
    -- Kết quả chung
    TongDiem INT NOT NULL CHECK (TongDiem >= 0 AND TongDiem <= 100),
    XepLoaiThiDua NVARCHAR(50), -- Xuất sắc, Tốt, Khá, Trung bình, Yếu
    DanhHieuThiDua NVARCHAR(100),
    NgayDanhGia DATE NOT NULL,
    NguoiDanhGia NVARCHAR(100),
    GhiChu NTEXT,
    NgayTao DATETIME DEFAULT GETDATE(),
    UNIQUE (MaDoiTuong, HocKy, LoaiDoiTuong)
);
GO

CREATE NONCLUSTERED INDEX IX_ThongTinXetThiDua_MaDoiTuong ON ThongTinXetThiDua(MaDoiTuong);
CREATE NONCLUSTERED INDEX IX_ThongTinXetThiDua_LoaiDoiTuong ON ThongTinXetThiDua(LoaiDoiTuong);
CREATE NONCLUSTERED INDEX IX_ThongTinXetThiDua_HocKy ON ThongTinXetThiDua(HocKy);
GO

-- ==================== BƯỚC 3: TẠO VIEWS ====================

-- VIEW 1: Danh sách sinh viên với thông tin đầy đủ
CREATE VIEW vw_DanhSachSinhVienDayDu AS
SELECT
    sv.ID,
    sv.MaSinhVien,
    sv.HoTen,
    sv.NgaySinh,
    DATEDIFF(YEAR, sv.NgaySinh, GETDATE()) AS Tuoi,
    sv.GioiTinh,
    sv.Khoa,
    sv.Nganh,
    sv.KhoaHoc,
    sv.Email,
    sv.SoDienThoai,
    COUNT(DISTINCT d.MaMonHoc) AS SoMonDaHoc,
    ISNULL(AVG(d.DiemTongKet), 0) AS DiemTrungBinh
FROM ThongTinSinhVien sv
LEFT JOIN ThongTinDiem d ON sv.MaSinhVien = d.MaSinhVien
GROUP BY sv.ID, sv.MaSinhVien, sv.HoTen, sv.NgaySinh, sv.GioiTinh,
         sv.Khoa, sv.Nganh, sv.KhoaHoc, sv.Email, sv.SoDienThoai;
GO

-- VIEW 2: Thống kê xét tốt nghiệp theo khoa
CREATE VIEW vw_ThongKeXetTotNghiepTheoKhoa AS
SELECT
    Khoa,
    HocKyTotNghiep,
    COUNT(*) AS TongSoSinhVien,
    SUM(CASE WHEN KetQuaXet = N'Đủ điều kiện' THEN 1 ELSE 0 END) AS SoDuDieuKien,
    SUM(CASE WHEN KetQuaXet = N'Không đủ điều kiện' THEN 1 ELSE 0 END) AS SoKhongDuDieuKien,
    SUM(CASE WHEN XepLoaiTotNghiep = N'Xuất sắc' THEN 1 ELSE 0 END) AS SoXuatSac,
    SUM(CASE WHEN XepLoaiTotNghiep = N'Giỏi' THEN 1 ELSE 0 END) AS SoGioi,
    SUM(CASE WHEN XepLoaiTotNghiep = N'Khá' THEN 1 ELSE 0 END) AS SoKha,
    AVG(DiemTrungBinhTichLuy) AS GPATrungBinh
FROM ThongTinXetTotNghiep
GROUP BY Khoa, HocKyTotNghiep;
GO

-- VIEW 3: Thống kê xét thi đua theo loại đối tượng
CREATE VIEW vw_ThongKeXetThiDuaTheoLoai AS
SELECT
    LoaiDoiTuong,
    HocKy,
    Khoa,
    COUNT(*) AS TongSoDanhGia,
    SUM(CASE WHEN XepLoaiThiDua = N'Xuất sắc' THEN 1 ELSE 0 END) AS SoXuatSac,
    SUM(CASE WHEN XepLoaiThiDua = N'Tốt' THEN 1 ELSE 0 END) AS SoTot,
    SUM(CASE WHEN XepLoaiThiDua = N'Khá' THEN 1 ELSE 0 END) AS SoKha,
    AVG(CAST(TongDiem AS FLOAT)) AS DiemTrungBinh
FROM ThongTinXetThiDua
GROUP BY LoaiDoiTuong, HocKy, Khoa;
GO

-- ==================== BƯỚC 4: TẠO STORED PROCEDURES ====================

-- STORED PROCEDURE 1: Thêm sinh viên mới
CREATE PROCEDURE sp_ThemSinhVienMoi
    @MaSinhVien NVARCHAR(20),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai NVARCHAR(15) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Khoa NVARCHAR(100),
    @Nganh NVARCHAR(100),
    @KhoaHoc NVARCHAR(20),
    @KetQua INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra mã sinh viên đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM ThongTinSinhVien WHERE MaSinhVien = @MaSinhVien)
    BEGIN
        SET @KetQua = 0; -- Mã đã tồn tại
        RETURN;
    END

    BEGIN TRY
        INSERT INTO ThongTinSinhVien (MaSinhVien, HoTen, NgaySinh, GioiTinh, DiaChi,
                                      SoDienThoai, Email, Khoa, Nganh, KhoaHoc)
        VALUES (@MaSinhVien, @HoTen, @NgaySinh, @GioiTinh, @DiaChi,
                @SoDienThoai, @Email, @Khoa, @Nganh, @KhoaHoc);

        SET @KetQua = 1; -- Thành công
    END TRY
    BEGIN CATCH
        SET @KetQua = -1; -- Lỗi
    END CATCH
END;
GO

-- STORED PROCEDURE 2: Tính điểm tổng kết tự động
CREATE PROCEDURE sp_TinhDiemTongKet
    @MaSinhVien NVARCHAR(20),
    @MaMonHoc NVARCHAR(20),
    @HocKy NVARCHAR(20),
    @DiemChuyenCan FLOAT,
    @DiemGiuaKy FLOAT,
    @DiemCuoiKy FLOAT,
    @DiemTongKet FLOAT OUTPUT,
    @DiemChu NVARCHAR(2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Công thức: Điểm TK = 10% Chuyên cần + 20% Giữa kỳ + 70% Cuối kỳ
    SET @DiemTongKet = (@DiemChuyenCan * 0.1) + (@DiemGiuaKy * 0.2) + (@DiemCuoiKy * 0.7);

    -- Xác định điểm chữ
    IF @DiemTongKet >= 9.0 SET @DiemChu = 'A+';
    ELSE IF @DiemTongKet >= 8.5 SET @DiemChu = 'A';
    ELSE IF @DiemTongKet >= 8.0 SET @DiemChu = 'B+';
    ELSE IF @DiemTongKet >= 7.0 SET @DiemChu = 'B';
    ELSE IF @DiemTongKet >= 6.5 SET @DiemChu = 'C+';
    ELSE IF @DiemTongKet >= 5.5 SET @DiemChu = 'C';
    ELSE IF @DiemTongKet >= 5.0 SET @DiemChu = 'D+';
    ELSE IF @DiemTongKet >= 4.0 SET @DiemChu = 'D';
    ELSE SET @DiemChu = 'F';
END;
GO

-- STORED PROCEDURE 3: Xét tốt nghiệp tự động
CREATE PROCEDURE sp_XetTotNghiepTuDong
    @MaSinhVien NVARCHAR(20),
    @HocKy NVARCHAR(20),
    @KetQua INT OUTPUT,
    @ThongBao NVARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TinChi INT, @GPA FLOAT, @DiemRL INT, @MonNo INT, @TOEIC INT, @KhoaLuan NVARCHAR(50);
    DECLARE @XepLoai NVARCHAR(50);

    -- Lấy thông tin sinh viên
    SELECT @TinChi = TongTinChiTichLuy, @GPA = DiemTrungBinhTichLuy,
           @DiemRL = DiemRenLuyen, @MonNo = SoMonNo, @TOEIC = DiemNgoaiNgu,
           @KhoaLuan = TrangThaiKhoaLuan
    FROM ThongTinXetTotNghiep
    WHERE MaSinhVien = @MaSinhVien AND HocKyTotNghiep = @HocKy;

    -- Kiểm tra các điều kiện
    IF @TinChi >= 120 AND @GPA >= 2.0 AND @DiemRL >= 50 AND @MonNo = 0
       AND @TOEIC >= 450 AND @KhoaLuan = N'Đã hoàn thành'
    BEGIN
        -- Đủ điều kiện
        IF @GPA >= 3.6 SET @XepLoai = N'Xuất sắc';
        ELSE IF @GPA >= 3.2 SET @XepLoai = N'Giỏi';
        ELSE IF @GPA >= 2.5 SET @XepLoai = N'Khá';
        ELSE SET @XepLoai = N'Trung bình';

        UPDATE ThongTinXetTotNghiep
        SET KetQuaXet = N'Đủ điều kiện',
            XepLoaiTotNghiep = @XepLoai,
            DieuKienTotNghiep = N'Đủ tất cả điều kiện tốt nghiệp'
        WHERE MaSinhVien = @MaSinhVien AND HocKyTotNghiep = @HocKy;

        SET @KetQua = 1;
        SET @ThongBao = N'Sinh viên đủ điều kiện tốt nghiệp loại ' + @XepLoai;
    END
    ELSE
    BEGIN
        -- Không đủ điều kiện
        SET @ThongBao = N'Không đủ điều kiện: ';
        IF @TinChi < 120 SET @ThongBao = @ThongBao + N'Thiếu ' + CAST(120 - @TinChi AS NVARCHAR(10)) + N' tín chỉ; ';
        IF @GPA < 2.0 SET @ThongBao = @ThongBao + N'GPA chưa đạt; ';
        IF @DiemRL < 50 SET @ThongBao = @ThongBao + N'Điểm rèn luyện yếu; ';
        IF @MonNo > 0 SET @ThongBao = @ThongBao + N'Còn ' + CAST(@MonNo AS NVARCHAR(10)) + N' môn nợ; ';
        IF @TOEIC < 450 SET @ThongBao = @ThongBao + N'TOEIC chưa đạt; ';

        UPDATE ThongTinXetTotNghiep
        SET KetQuaXet = N'Không đủ điều kiện',
            DieuKienTotNghiep = @ThongBao
        WHERE MaSinhVien = @MaSinhVien AND HocKyTotNghiep = @HocKy;

        SET @KetQua = 0;
    END
END;
GO

-- ==================== BƯỚC 5: INSERT SAMPLE DATA ====================

-- Sample Sinh viên
INSERT INTO ThongTinSinhVien (MaSinhVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, Khoa, Nganh, KhoaHoc)
VALUES
(N'SV2024001', N'Nguyễn Văn An', '2003-05-15', N'Nam', N'Hà Nội', N'0912345678', N'annv@student.edu.vn', N'Khoa CNTT', N'Công nghệ thông tin', N'2020-2024'),
(N'SV2024002', N'Trần Thị Bình', '2003-08-20', N'Nữ', N'Hồ Chí Minh', N'0923456789', N'binhtt@student.edu.vn', N'Khoa Kinh tế', N'Kế toán', N'2020-2024'),
(N'SV2024003', N'Lê Văn Cường', '2003-11-10', N'Nam', N'Đà Nẵng', N'0934567890', N'cuonglv@student.edu.vn', N'Khoa CNTT', N'Hệ thống thông tin', N'2020-2024'),
(N'SV2024004', N'Phạm Thị Dung', '2003-03-25', N'Nữ', N'Hải Phòng', N'0945678901', N'dungpt@student.edu.vn', N'Khoa Ngoại ngữ', N'Tiếng Anh', N'2020-2024'),
(N'SV2024005', N'Hoàng Văn Em', '2003-07-30', N'Nam', N'Cần Thơ', N'0956789012', N'emhv@student.edu.vn', N'Khoa CNTT', N'An toàn thông tin', N'2020-2024');
GO

-- Sample Giảng viên
INSERT INTO ThongTinGiangVien (MaGiangVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, Khoa, ChuyenNganh, HocVi, HocHam, NgayVaoLam)
VALUES
(N'GV001', N'TS. Phạm Thị Dung', '1980-05-15', N'Nữ', N'Hà Nội', N'0911111111', N'dungpt@university.edu.vn', N'Khoa CNTT', N'Trí tuệ nhân tạo', N'Tiến sĩ', N'Giảng viên chính', '2010-09-01'),
(N'GV002', N'ThS. Hoàng Văn Em', '1985-08-20', N'Nam', N'Hồ Chí Minh', N'0922222222', N'emhv@university.edu.vn', N'Khoa Kinh tế', N'Quản trị kinh doanh', N'Thạc sĩ', N'Giảng viên', '2015-03-01'),
(N'GV003', N'PGS.TS. Nguyễn Văn Giang', '1975-11-10', N'Nam', N'Hà Nội', N'0933333333', N'giangnv@university.edu.vn', N'Khoa CNTT', N'Mạng máy tính', N'Tiến sĩ', N'Phó giáo sư', '2005-01-15');
GO

-- Sample Môn học
INSERT INTO ThongTinMonHoc (MaMonHoc, TenMonHoc, SoTinChi, TietLyThuyet, TietThucHanh, Khoa, MoTa)
VALUES
(N'IT101', N'Nhập môn lập trình', 3, 30, 30, N'Khoa CNTT', N'Học lập trình C/C++ cơ bản'),
(N'IT201', N'Cấu trúc dữ liệu và giải thuật', 4, 45, 30, N'Khoa CNTT', N'Data structures & algorithms'),
(N'IT301', N'Cơ sở dữ liệu', 3, 30, 30, N'Khoa CNTT', N'Database programming'),
(N'EC101', N'Kinh tế vi mô', 3, 45, 0, N'Khoa Kinh tế', N'Microeconomics'),
(N'EN101', N'Tiếng Anh 1', 3, 30, 15, N'Khoa Ngoại ngữ', N'English elementary');
GO

PRINT N'✅ Database HeThongTruongDaiHoc đã được tạo thành công!';
PRINT N'📊 Bao gồm: 9 Tables, 3 Views, 3 Stored Procedures';
PRINT N'📝 Sample data đã được thêm vào các bảng';
GO
