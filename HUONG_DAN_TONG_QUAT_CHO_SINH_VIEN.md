# HƯỚNG DẪN TỔNG QUÁT XÂY DỰNG ỨNG DỤNG WINFORMS - N-LAYER ARCHITECTURE

## 📚 DÀNH CHO SINH VIÊN HỌC LỰC TRUNG BÌNH - KHÁ

---

## 🎯 MỤC LỤC

1. [Tổng quan kiến trúc](#1-tổng-quan-kiến-trúc)
2. [Cấu trúc thư mục dự án](#2-cấu-trúc-thư-mục-dự-án)
3. [Công thức 3 bước: DTO → BLL → UI](#3-công-thức-3-bước-dto--bll--ui)
4. [Hướng dẫn chi tiết từng phần](#4-hướng-dẫn-chi-tiết-từng-phần)
5. [Quy trình làm một chức năng hoàn chỉnh](#5-quy-trình-làm-một-chức-năng-hoàn-chỉnh)
6. [Các mẫu code hay dùng (Templates)](#6-các-mẫu-code-hay-dùng-templates)
7. [Checklist trước khi nộp bài](#7-checklist-trước-khi-nộp-bài)

---

## 1. TỔNG QUAN KIẾN TRÚC

### 1.1. N-Layer là gì?

Hình dung như một **CHIẾC BÁNH 3 TẦNG**:

```
┌─────────────────────────────────┐
│    TẦNG 3: UI (Form)            │  ← Người dùng tương tác
│    - Hiển thị dữ liệu           │
│    - Nhận input từ user         │
└─────────────────────────────────┘
           ↓ ↑
┌─────────────────────────────────┐
│    TẦNG 2: BLL (Business Logic) │  ← Xử lý logic nghiệp vụ
│    - Thêm/Sửa/Xóa/Tìm kiếm      │
│    - Validation                 │
│    - Tính toán                  │
└─────────────────────────────────┘
           ↓ ↑
┌─────────────────────────────────┐
│    TẦNG 1: DTO (Data)           │  ← Chứa dữ liệu
│    - Class chứa thuộc tính      │
│    - Không có logic             │
└─────────────────────────────────┘
```

### 1.2. Lợi ích của N-Layer

✅ **Dễ quản lý**: Mỗi tầng làm 1 việc rõ ràng
✅ **Dễ sửa lỗi**: Biết ngay lỗi ở tầng nào
✅ **Dễ mở rộng**: Thêm chức năng mới không ảnh hưởng code cũ
✅ **Dễ tái sử dụng**: BLL có thể dùng cho nhiều UI khác nhau

---

## 2. CẤU TRÚC THƯ MỤC DỰ ÁN

### 2.1. Cấu trúc chuẩn

```
📁 WinFormsHeThongTruongDaiHoc/
├── 📁 Doi_Tuong_Trao_Doi_Du_Lieu_Data_Transfer_Object/
│   ├── ThongTinSinhVien.cs          // DTO - Class chứa dữ liệu sinh viên
│   └── QuanLySinhVien.cs            // DTO - Class quản lý danh sách
│
├── 📁 Lop_Nghiep_Vu_Business_Logic_Layer/
│   ├── ThemThongTinSinhVien.cs      // BLL - Chức năng THÊM
│   ├── XoaThongTinSinhVien.cs       // BLL - Chức năng XÓA
│   ├── SuaThongTinSinhVien.cs       // BLL - Chức năng SỬA
│   ├── TimKiemThongTinSinhVien.cs   // BLL - Chức năng TÌM KIẾM
│   ├── SapXepThongTinSinhVien.cs    // BLL - Chức năng SẮP XẾP
│   └── ThongKeThongTinSinhVien.cs   // BLL - Chức năng THỐNG KÊ
│
├── 📁 Form_Quan_Ly_Sinh_Vien/
│   ├── FormThongTinSV.cs            // UI - Form thêm/sửa sinh viên
│   ├── FormTimKiemThongTinSV.cs     // UI - Form tìm kiếm
│   └── FormThongKeSV.cs             // UI - Form thống kê
│
├── HeThongTruongDaiHoc.cs           // UI - Form chính (Main)
└── Program.cs                       // Entry point
```

### 2.2. Quy tắc đặt tên

| Loại | Công thức đặt tên | Ví dụ |
|------|-------------------|-------|
| **DTO Class** | `ThongTin` + TênĐốiTượng | `ThongTinSinhVien`, `ThongTinMonHoc` |
| **BLL Class** | `ChucNang` + TênHànhĐộng | `ChucNangThemThongTinSV`, `ChucNangXoaSV` |
| **Form Class** | `Form` + TênMànHình | `FormThongTinSV`, `FormTimKiem` |
| **Namespace** | Tiếng Việt có dấu | `Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_` |

---

## 3. CÔNG THỨC 3 BƯỚC: DTO → BLL → UI

### ⭐ QUY TẮC VÀNG: LUÔN LÀM THEO THỨ TỰ NÀY!

```
BƯỚC 1: Tạo DTO (Dữ liệu)
   ↓
BƯỚC 2: Tạo BLL (Logic nghiệp vụ)
   ↓
BƯỚC 3: Tạo UI (Giao diện)
```

### Giải thích tại sao?

- **DTO trước**: Vì phải biết dữ liệu có gì thì mới xử lý được
- **BLL giữa**: Vì phải có logic xử lý rồi mới hiển thị
- **UI cuối**: Vì UI chỉ gọi BLL, không tự xử lý

---

## 4. HƯỚNG DẪN CHI TIẾT TỪNG PHẦN

---

## 4.1. TẦNG 1: DTO (Data Transfer Object)

### 📖 Khái niệm

DTO giống như **TỜ GIẤY GHI THÔNG TIN**:
- Chỉ chứa **THUỘC TÍNH** (properties)
- **KHÔNG** chứa logic xử lý
- **KHÔNG** có methods (ngoại trừ getter/setter đơn giản)

### 📝 Template chuẩn cho DTO

```csharp
// File: Doi_Tuong_Trao_Doi_Du_Lieu_Data_Transfer_Object/ThongTinSinhVien.cs

using System;

namespace TenDuAn.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    public class ThongTinSinhVien
    {
        // ===== CÁC THUỘC TÍNH (PROPERTIES) =====

        // ID tự động tăng (nếu dùng database)
        public int ID { get; set; }

        // Mã sinh viên (Primary key)
        public string MaSV { get; set; } = "";

        // Họ
        public string HoSV { get; set; } = "";

        // Tên lót (không bắt buộc)
        public string TenLotSV { get; set; } = "";

        // Tên
        public string TenSV { get; set; } = "";

        // Ngày sinh
        public DateTime NgaySinhSV { get; set; }

        // Giới tính ("Nam" hoặc "Nữ")
        public string GioiTinhSV { get; set; } = "";

        // CCCD (12 số)
        public string CCCDSV { get; set; } = "";

        // Địa chỉ
        public string DiaChiSV { get; set; } = "";

        // Email
        public string EmailSV { get; set; } = "";

        // Lớp
        public string LopSV { get; set; } = "";

        // Trạng thái (Đang học, Tốt nghiệp, ...)
        public string TrangThaiSV { get; set; } = "";

        // Đường dẫn hình ảnh
        public string HinhAnhSV { get; set; } = "";
    }
}
```

### 📝 Template cho class Quản lý danh sách

```csharp
// File: Doi_Tuong_Trao_Doi_Du_Lieu_Data_Transfer_Object/QuanLySinhVien.cs

using System.Collections.Generic;

namespace TenDuAn.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_
{
    public class QuanLySinhVien
    {
        // ===== THUỘC TÍNH =====
        private List<ThongTinSinhVien> danhSachSinhVien;

        // ===== CONSTRUCTOR =====
        public QuanLySinhVien()
        {
            danhSachSinhVien = new List<ThongTinSinhVien>();
        }

        // ===== GETTER METHODS =====

        // Lấy danh sách sinh viên
        public List<ThongTinSinhVien> LayDanhSachSinhVien()
        {
            return danhSachSinhVien;
        }

        // Lấy số lượng sinh viên
        public int LaySoLuongSinhVien()
        {
            return danhSachSinhVien.Count;
        }

        // ===== SETTER METHOD =====

        // Cập nhật toàn bộ danh sách
        public void CapNhatDanhSach(List<ThongTinSinhVien> danhSachMoi)
        {
            if (danhSachMoi != null)
            {
                this.danhSachSinhVien = danhSachMoi;
            }
        }
    }
}
```

### ✅ Checklist cho DTO

- [ ] Tất cả properties đều có `{ get; set; }`
- [ ] String properties được khởi tạo = `""`
- [ ] DateTime không cần khởi tạo (là value type)
- [ ] **KHÔNG CÓ** methods xử lý logic
- [ ] **KHÔNG CÓ** validation trong DTO

---

## 4.2. TẦNG 2: BLL (Business Logic Layer)

### 📖 Khái niệm

BLL giống như **NHÂN VIÊN XỬ LÝ CÔNG VIỆC**:
- Chứa **TẤT CẢ LOGIC NGHIỆP VỤ**
- Validation (kiểm tra dữ liệu hợp lệ)
- Xử lý (Thêm/Sửa/Xóa/Tìm kiếm/Sắp xếp/Thống kê)
- **KHÔNG** có giao diện (UI)
- **KHÔNG** chứa dữ liệu (Data)

### 📋 Các loại BLL thường gặp

| BLL Class | Chức năng | Method chính |
|-----------|-----------|--------------|
| **ChucNangThemThongTinSV** | Thêm sinh viên | `ThemSinhVien(List, SV)` |
| **ChucNangXoaThongTinSinhVien** | Xóa sinh viên | `XoaSinhVien(List, maSV)` |
| **ChucNangSuaThongTinSinhVien** | Sửa sinh viên | `SuaThongTinSinhVien(List, maSV, SVMoi)` |
| **ChucNangTimKiemThongTinSinhVien** | Tìm kiếm | `TimKiemSinhVien(List, tieuChi)` |
| **ChucNangSapXepSV** | Sắp xếp | `SapXepTheoTen(List)` |
| **ChucNangThongKeSV** | Thống kê | `DemTheoGioiTinh(List)` |

### 📝 Template chuẩn cho BLL - CHỨC NĂNG THÊM

```csharp
// File: Lop_Nghiep_Vu_Business_Logic_Layer/ThemThongTinSinhVien.cs

using System.Collections.Generic;

namespace TenDuAn.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    public class ChucNangThemThongTinSV
    {
        // ==================== PHƯƠNG THỨC THÊM CHÍNH ====================

        /// <summary>
        /// Thêm sinh viên mới vào danh sách
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên hiện tại</param>
        /// <param name="sinhVienMoi">Sinh viên cần thêm</param>
        /// <returns>true nếu thêm thành công, false nếu thất bại</returns>
        public bool ThemSinhVien(List<ThongTinSinhVien> danhSach,
                                 ThongTinSinhVien sinhVienMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            if (sinhVienMoi == null)
            {
                return false; // Không có sinh viên để thêm
            }

            if (danhSach == null)
            {
                return false; // Danh sách không tồn tại
            }

            // ===== BƯỚC 2: KIỂM TRA MÃ SINH VIÊN TRÙNG =====

            bool maTonTai = KiemTraMaSVTonTai(danhSach, sinhVienMoi.MaSV);

            if (maTonTai)
            {
                return false; // Mã sinh viên đã tồn tại
            }

            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(sinhVienMoi);

            if (!duLieuHopLe)
            {
                return false; // Dữ liệu không hợp lệ
            }

            // ===== BƯỚC 4: THÊM VÀO DANH SÁCH =====

            danhSach.Add(sinhVienMoi);

            // ===== BƯỚC 5: TRẢ VỀ KẾT QUẢ =====

            return true; // Thêm thành công!
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ ====================

        /// <summary>
        /// Kiểm tra mã sinh viên đã tồn tại chưa
        /// </summary>
        private bool KiemTraMaSVTonTai(List<ThongTinSinhVien> danhSach, string maSV)
        {
            // Kiểm tra mã rỗng
            bool maRong = KiemTraChuoiRong(maSV);
            if (maRong)
            {
                return false;
            }

            // Tìm kiếm tuần tự
            foreach (ThongTinSinhVien sv in danhSach)
            {
                string maSVHienTai = sv.MaSV;

                // So sánh mã (không phân biệt hoa/thường)
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maSVHienTai, maSV);

                if (khopMa)
                {
                    return true; // Tìm thấy → Đã tồn tại
                }
            }

            return false; // Không tìm thấy → Chưa tồn tại
        }

        /// <summary>
        /// Kiểm tra dữ liệu sinh viên có hợp lệ không
        /// </summary>
        private bool KiemTraDuLieuHopLe(ThongTinSinhVien sv)
        {
            // Kiểm tra mã sinh viên (bắt buộc)
            bool maRong = KiemTraChuoiRong(sv.MaSV);
            if (maRong)
            {
                return false;
            }

            // Kiểm tra họ (bắt buộc)
            bool hoRong = KiemTraChuoiRong(sv.HoSV);
            if (hoRong)
            {
                return false;
            }

            // Kiểm tra tên (bắt buộc)
            bool tenRong = KiemTraChuoiRong(sv.TenSV);
            if (tenRong)
            {
                return false;
            }

            // Kiểm tra ngày sinh (phải hợp lệ)
            bool ngaySinhHopLe = (sv.NgaySinhSV != DateTime.MinValue);
            if (!ngaySinhHopLe)
            {
                return false;
            }

            // Kiểm tra tuổi (>= 18)
            int namHienTai = DateTime.Now.Year;
            int namSinh = sv.NgaySinhSV.Year;
            int tuoi = namHienTai - namSinh;

            bool tuoiHopLe = (tuoi >= 18);
            if (!tuoiHopLe)
            {
                return false;
            }

            // Tất cả đều hợp lệ
            return true;
        }

        // ==================== CÁC METHODS XỬ LÝ CHUỖI TỰ CODE ====================

        /// <summary>
        /// Kiểm tra chuỗi có rỗng không
        /// </summary>
        private bool KiemTraChuoiRong(string chuoi)
        {
            if (chuoi == null)
            {
                return true;
            }

            if (chuoi.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// So sánh 2 chuỗi không phân biệt hoa/thường
        /// </summary>
        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

            // Chuyển về chữ thường
            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            // So sánh
            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        /// <summary>
        /// So sánh 2 chuỗi chính xác
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1.Length != chuoi2.Length)
            {
                return false;
            }

            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi về chữ thường
        /// </summary>
        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                // Kiểm tra có phải chữ HOA không (A-Z)
                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
                    // Chuyển thành chữ thường (khoảng cách = 32)
                    char kyTuThuong = (char)(kyTu + 32);
                    ketQua += kyTuThuong;
                }
                else
                {
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }
    }
}
```

### ✅ Checklist cho BLL

- [ ] Tất cả methods đều có XML comment (`/// <summary>`)
- [ ] Return type rõ ràng (`bool`, `List<>`, etc.)
- [ ] Kiểm tra `null` cho tất cả tham số
- [ ] Validation đầy đủ trước khi xử lý
- [ ] **KHÔNG** có code UI (MessageBox, Form, ...)
- [ ] **KHÔNG** lưu trữ dữ liệu (dùng tham số `List<>`)

---

## 4.3. TẦNG 3: UI (User Interface - Form)

### 📖 Khái niệm

UI giống như **QUẦY GIAO DỊCH**:
- Hiển thị dữ liệu cho người dùng
- Nhận input từ người dùng
- **GỌI** BLL để xử lý
- **KHÔNG TỰ XỬ LÝ** logic nghiệp vụ

### 📝 Template chuẩn cho Form chính (Main Form)

```csharp
// File: HeThongTruongDaiHoc.cs

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TenDuAn
{
    public partial class HeThongTruongDaiHoc : Form
    {
        // ==================== KHAI BÁO DTO & BLL ====================

        // DTO (Data Transfer Object)
        private QuanLySinhVien quanLy;

        // BLL (Business Logic Layer)
        private ChucNangThemThongTinSV chucNangThem;
        private ChucNangXoaThongTinSinhVien chucNangXoa;
        private ChucNangSuaThongTinSinhVien chucNangSua;
        private ChucNangTimKiemThongTinSinhVien chucNangTimKiem;
        private ChucNangSapXepSV chucNangSapXep;
        private ChucNangThongKeSV chucNangThongKe;

        // ==================== CONSTRUCTOR ====================

        public HeThongTruongDaiHoc()
        {
            InitializeComponent();

            // BƯỚC 1: Khởi tạo DTO
            quanLy = new QuanLySinhVien();

            // BƯỚC 2: Khởi tạo BLL
            chucNangThem = new ChucNangThemThongTinSV();
            chucNangXoa = new ChucNangXoaThongTinSinhVien();
            chucNangSua = new ChucNangSuaThongTinSinhVien();
            chucNangTimKiem = new ChucNangTimKiemThongTinSinhVien();
            chucNangSapXep = new ChucNangSapXepSV();
            chucNangThongKe = new ChucNangThongKeSV();

            // BƯỚC 3: Thiết lập giao diện
            ThietLapGiaoDien();
            ThietLapDataGridView();
        }

        // ==================== SỰ KIỆN THÊM SINH VIÊN ====================

        private void buttonThemThongTinSV_Click(object sender, EventArgs e)
        {
            try
            {
                // BƯỚC 1: Mở Form thêm thông tin
                using (FormThongTinSV formThem = new FormThongTinSV(null))
                {
                    DialogResult ketQua = formThem.ShowDialog();

                    if (ketQua == DialogResult.OK)
                    {
                        ThongTinSinhVien svMoi = formThem.SinhVienMoi;

                        if (svMoi != null)
                        {
                            // BƯỚC 2: Gọi BLL để thêm sinh viên
                            bool themThanhCong = chucNangThem.ThemSinhVien(
                                quanLy.LayDanhSachSinhVien(), // Lấy danh sách từ DTO
                                svMoi  // Sinh viên mới
                            );

                            if (themThanhCong)
                            {
                                // BƯỚC 3: Cập nhật giao diện
                                HienThiDanhSach(quanLy.LayDanhSachSinhVien());

                                MessageBox.Show(
                                    "Thêm sinh viên thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Thêm sinh viên thất bại!\n" +
                                    "Nguyên nhân:\n" +
                                    "- Mã sinh viên đã tồn tại\n" +
                                    "- Dữ liệu không hợp lệ",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Đã xảy ra lỗi: {ex.Message}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==================== HIỂN THỊ DANH SÁCH ====================

        private void HienThiDanhSach(List<ThongTinSinhVien> danhSach)
        {
            dataGridViewThongTinSinhVien.SuspendLayout();

            try
            {
                // Xóa tất cả dòng hiện tại
                dataGridViewThongTinSinhVien.Rows.Clear();

                // Duyệt qua danh sách và hiển thị
                foreach (ThongTinSinhVien sv in danhSach)
                {
                    dataGridViewThongTinSinhVien.Rows.Add(
                        sv.MaSV,
                        sv.HoSV,
                        sv.TenLotSV,
                        sv.TenSV,
                        sv.NgaySinhSV,
                        sv.GioiTinhSV,
                        sv.CCCDSV,
                        sv.DiaChiSV,
                        sv.EmailSV,
                        sv.LopSV,
                        sv.TrangThaiSV
                    );
                }
            }
            finally
            {
                dataGridViewThongTinSinhVien.ResumeLayout();
            }
        }
    }
}
```

### ✅ Checklist cho UI

- [ ] Tất cả event handlers có `try-catch`
- [ ] Hiển thị thông báo rõ ràng cho user
- [ ] **KHÔNG** xử lý logic nghiệp vụ trực tiếp
- [ ] **LUÔN** gọi BLL để xử lý
- [ ] Cập nhật giao diện sau mỗi thao tác

---

## 5. QUY TRÌNH LÀM MỘT CHỨC NĂNG HOÀN CHỈNH

### 📋 VÍ DỤ: Làm chức năng THÊM SINH VIÊN từ đầu

#### BƯỚC 1: Tạo DTO (Data)

**1.1. Tạo class ThongTinSinhVien.cs**

```csharp
public class ThongTinSinhVien
{
    public string MaSV { get; set; } = "";
    public string HoSV { get; set; } = "";
    public string TenSV { get; set; } = "";
    // ... các thuộc tính khác
}
```

**1.2. Tạo class QuanLySinhVien.cs**

```csharp
public class QuanLySinhVien
{
    private List<ThongTinSinhVien> danhSachSinhVien;

    public QuanLySinhVien()
    {
        danhSachSinhVien = new List<ThongTinSinhVien>();
    }

    public List<ThongTinSinhVien> LayDanhSachSinhVien()
    {
        return danhSachSinhVien;
    }
}
```

#### BƯỚC 2: Tạo BLL (Logic)

**2.1. Tạo class ChucNangThemThongTinSV.cs**

```csharp
public class ChucNangThemThongTinSV
{
    public bool ThemSinhVien(List<ThongTinSinhVien> danhSach,
                             ThongTinSinhVien svMoi)
    {
        // 1. Kiểm tra null
        // 2. Kiểm tra trùng mã
        // 3. Kiểm tra dữ liệu hợp lệ
        // 4. Thêm vào danh sách
        // 5. Return kết quả
    }
}
```

#### BƯỚC 3: Tạo UI (Giao diện)

**3.1. Tạo FormThongTinSV.cs (Form nhập liệu)**

```csharp
public partial class FormThongTinSV : Form
{
    public ThongTinSinhVien SinhVienMoi { get; private set; }

    private void buttonOK_Click(object sender, EventArgs e)
    {
        // 1. Validation input
        // 2. Tạo object ThongTinSinhVien
        // 3. Gán vào property SinhVienMoi
        // 4. this.DialogResult = DialogResult.OK
        // 5. this.Close()
    }
}
```

**3.2. Trong Main Form (HeThongTruongDaiHoc.cs)**

```csharp
private void buttonThem_Click(object sender, EventArgs e)
{
    // 1. Mở FormThongTinSV
    // 2. Lấy SinhVienMoi từ form
    // 3. Gọi BLL: chucNangThem.ThemSinhVien(...)
    // 4. Cập nhật DataGridView
    // 5. Hiển thị thông báo
}
```

---

## 6. CÁC MẪU CODE HAY DÙNG (TEMPLATES)

### 6.1. Template Method xử lý chuỗi (Copy-Paste)

```csharp
// ===== Kiểm tra chuỗi rỗng =====
private bool KiemTraChuoiRong(string chuoi)
{
    if (chuoi == null) return true;
    if (chuoi.Length == 0) return true;

    for (int i = 0; i < chuoi.Length; i++)
    {
        char kyTu = chuoi[i];
        if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
        {
            return false;
        }
    }
    return true;
}

// ===== Chuyển về chữ thường =====
private string ChuyenVeChuThuong(string chuoi)
{
    if (chuoi == null) return "";

    string ketQua = "";
    for (int i = 0; i < chuoi.Length; i++)
    {
        char kyTu = chuoi[i];
        if (kyTu >= 'A' && kyTu <= 'Z')
        {
            ketQua += (char)(kyTu + 32);
        }
        else
        {
            ketQua += kyTu;
        }
    }
    return ketQua;
}

// ===== So sánh 2 chuỗi (không phân biệt hoa/thường) =====
private bool SoSanhChuoi(string chuoi1, string chuoi2)
{
    if (chuoi1 == null && chuoi2 == null) return true;
    if (chuoi1 == null || chuoi2 == null) return false;

    string s1 = ChuyenVeChuThuong(chuoi1);
    string s2 = ChuyenVeChuThuong(chuoi2);

    if (s1.Length != s2.Length) return false;

    for (int i = 0; i < s1.Length; i++)
    {
        if (s1[i] != s2[i]) return false;
    }
    return true;
}

// ===== Kiểm tra chứa chuỗi con =====
private bool KiemTraChuaChuoiCon(string chuoiGoc, string chuoiCon)
{
    if (chuoiGoc == null) return false;
    if (chuoiCon == null) return true;
    if (chuoiCon.Length > chuoiGoc.Length) return false;

    string goc = ChuyenVeChuThuong(chuoiGoc);
    string con = ChuyenVeChuThuong(chuoiCon);

    for (int i = 0; i <= goc.Length - con.Length; i++)
    {
        bool khop = true;
        for (int j = 0; j < con.Length; j++)
        {
            if (goc[i + j] != con[j])
            {
                khop = false;
                break;
            }
        }
        if (khop) return true;
    }
    return false;
}
```

### 6.2. Template Validation trong Form

```csharp
private string ValidateInput()
{
    string errors = "";

    // 1. Kiểm tra required fields
    if (string.IsNullOrWhiteSpace(textBoxMaSV.Text))
        errors += "- Mã sinh viên không được để trống\n";

    if (string.IsNullOrWhiteSpace(textBoxHoSV.Text))
        errors += "- Họ sinh viên không được để trống\n";

    if (string.IsNullOrWhiteSpace(textBoxTenSV.Text))
        errors += "- Tên sinh viên không được để trống\n";

    // 2. Kiểm tra định dạng email
    if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
    {
        if (!IsValidEmail(textBoxEmail.Text.Trim()))
            errors += "- Email không đúng định dạng\n";
    }

    // 3. Kiểm tra tuổi
    int tuoi = DateTime.Now.Year - dateTimePickerNgaySinh.Value.Year;
    if (tuoi < 18)
        errors += "- Sinh viên phải đủ 18 tuổi\n";

    return errors;
}

private bool IsValidEmail(string email)
{
    if (string.IsNullOrEmpty(email)) return false;

    // Kiểm tra có khoảng trắng
    for (int i = 0; i < email.Length; i++)
    {
        if (email[i] == ' ') return false;
    }

    // Tìm vị trí '@'
    int viTriAt = -1;
    int soLuongAt = 0;

    for (int i = 0; i < email.Length; i++)
    {
        if (email[i] == '@')
        {
            viTriAt = i;
            soLuongAt++;
        }
    }

    // Kiểm tra có đúng 1 '@' và không ở đầu/cuối
    if (soLuongAt != 1 || viTriAt == 0 || viTriAt == email.Length - 1)
        return false;

    // Kiểm tra có dấu '.' sau '@'
    bool coDauChamSauAt = false;
    for (int i = viTriAt + 1; i < email.Length; i++)
    {
        if (email[i] == '.')
        {
            coDauChamSauAt = true;
            break;
        }
    }

    return coDauChamSauAt;
}
```

### 6.3. Template Event Handler chuẩn

```csharp
private void buttonThemSV_Click(object sender, EventArgs e)
{
    try
    {
        // BƯỚC 1: Kiểm tra điều kiện (nếu cần)
        if (quanLy.LaySoLuongSinhVien() == 0)
        {
            MessageBox.Show(
                "Chưa có dữ liệu!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        // BƯỚC 2: Mở form nhập liệu (nếu cần)
        using (FormThongTinSV form = new FormThongTinSV(null))
        {
            DialogResult ketQua = form.ShowDialog();

            if (ketQua == DialogResult.OK)
            {
                // BƯỚC 3: Lấy dữ liệu từ form
                ThongTinSinhVien svMoi = form.SinhVienMoi;

                // BƯỚC 4: Gọi BLL xử lý
                bool thanhCong = chucNangThem.ThemSinhVien(
                    quanLy.LayDanhSachSinhVien(),
                    svMoi
                );

                // BƯỚC 5: Hiển thị kết quả
                if (thanhCong)
                {
                    HienThiDanhSach(quanLy.LayDanhSachSinhVien());
                    MessageBox.Show("Thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thất bại!", "Lỗi");
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống");
    }
}
```

---

## 7. CHECKLIST TRƯỚC KHI NỘP BÀI

### ✅ Kiểm tra DTO
- [ ] Tất cả properties có `{ get; set; }`
- [ ] String properties khởi tạo = `""`
- [ ] Không có logic trong DTO
- [ ] Class QuanLySinhVien có method `LayDanhSachSinhVien()`

### ✅ Kiểm tra BLL
- [ ] Mỗi chức năng có 1 class riêng
- [ ] Tất cả methods public có XML comment
- [ ] Kiểm tra `null` cho tất cả tham số
- [ ] Không có code UI trong BLL
- [ ] Validation đầy đủ

### ✅ Kiểm tra UI
- [ ] Tất cả event handlers có `try-catch`
- [ ] Khởi tạo BLL trong constructor
- [ ] Gọi BLL để xử lý, không tự xử lý
- [ ] Hiển thị thông báo rõ ràng
- [ ] DataGridView cập nhật sau mỗi thao tác

### ✅ Kiểm tra tổng thể
- [ ] Chạy được không lỗi
- [ ] Thêm/Sửa/Xóa/Tìm kiếm hoạt động đúng
- [ ] Validation hoạt động
- [ ] Thông báo lỗi rõ ràng
- [ ] Code có comment đầy đủ

---

## 📌 LƯU Ý QUAN TRỌNG

### 🔴 NHỮNG ĐIỀU TUYỆT ĐỐI KHÔNG ĐƯỢC LÀM

1. ❌ **KHÔNG** để logic nghiệp vụ trong DTO
2. ❌ **KHÔNG** để code UI trong BLL
3. ❌ **KHÔNG** xử lý logic trực tiếp trong Form
4. ❌ **KHÔNG** quên kiểm tra `null`
5. ❌ **KHÔNG** quên `try-catch` trong event handlers

### 🟢 NHỮNG ĐIỀU NÊN LÀM

1. ✅ Luôn làm theo thứ tự: DTO → BLL → UI
2. ✅ Comment đầy đủ cho mọi class/method
3. ✅ Đặt tên rõ ràng, dễ hiểu
4. ✅ Validation đầy đủ
5. ✅ Test kỹ trước khi nộp

---

## 🎓 KẾT LUẬN

Với hướng dẫn này, bạn có thể:

✅ Hiểu rõ kiến trúc N-Layer
✅ Biết cách tổ chức code
✅ Có templates để copy-paste
✅ Làm được các bài tương tự

**QUAN TRỌNG NHẤT**: Hãy **TỰ TAY VIẾT CODE** thay vì chỉ copy. Như vậy bạn mới thực sự hiểu và nhớ lâu!

---

## 📞 HỖ TRỢ

Nếu gặp khó khăn, hãy:

1. Đọc lại phần **Checklist**
2. Xem lại **Templates**
3. So sánh code của bạn với code mẫu
4. Hỏi thầy/bạn nếu vẫn chưa hiểu

**CHÚC BẠN HỌC TỐT!** 🎉
