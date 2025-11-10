using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG THÊM GIẢNG VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures
    //      • 4.2: Selection Structures (if/else) - Kiểm tra điều kiện
    //      • 4.3: Loop Structures (for, foreach) - Duyệt danh sách
    //    - Chapter 5: Functions
    //      • 5.2: Function Definition - Định nghĩa hàm
    //      • 5.4: Value-Returning Functions - Hàm trả về giá trị
    //      • 5.5.1: Value Parameters - Tham số theo giá trị
    //      • 5.5.2: Reference Parameters - Tham số theo tham chiếu
    //
    // 2️⃣ PROGRAMMING TECHNIQUES:
    //    - Chapter 4: Character Strings
    //      • 4.4: String Operations - Xử lý chuỗi
    //      • 4.4.1: Accessing individual elements - Truy cập từng ký tự
    //      • 4.4.2: Determining length - Lấy độ dài chuỗi
    //
    // 3️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class
    //      • 2.1.4: Methods - Phương thức
    //      • 2.2: Object - Tạo và sử dụng object
    //      • 2.2.3: Passing Objects to Methods - Truyền object vào method
    //
    // 4️⃣ GUI PROGRAMMING:
    //    - Chapter 2: The C# Programming Language
    //      • 2.7: Operators - Toán tử
    //      • 2.8: Selection Structures - Cấu trúc rẽ nhánh
    //      • 2.9: Loop Structures - Cấu trúc lặp
    //    - Chapter 3: Object-Oriented Programming in C#
    //      • 3.3: Methods - Phương thức
    //      • 3.9: Ways to pass parameters - Cách truyền tham số
    //
    // 5️⃣ DATA STRUCTURES AND ALGORITHMS 1:
    //    - Chapter 1: Lists
    //      • 1.1: Array-based Lists
    //      • 1.1.3: Basic operations - Insert (Thêm phần tử vào danh sách)
    //    - Chapter 2: Sorting - Searching
    //      • 2.2.1: Sequential Search - Tìm kiếm tuần tự (kiểm tra trùng)
    //
    // 6️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.2: Business Logic Layer (BLL) - Lớp nghiệp vụ
    //
    // 🎯 MỤC ĐÍCH CỦA CLASS:
    // ChucNangThemThongTinGV chứa TẤT CẢ logic để THÊM giảng viên mới:
    // - VALIDATION: Kiểm tra dữ liệu hợp lệ (họ, tên, tuổi, email,...)
    // - DUPLICATE CHECK: Kiểm tra mã GV không bị trùng
    // - DATA NORMALIZATION: Chuẩn hóa dữ liệu (viết hoa chữ đầu, xóa space thừa)
    // - AUTO GENERATE: Tạo mã GV tự động nếu chưa có
    // - INSERT: Thêm vào List
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như ĐĂNG KÝ GIẢNG VIÊN MỚI ở phòng Nhân sự:
    // Bước 1: Nhân viên kiểm tra giấy tờ (Validation)
    // Bước 2: Tra cứu mã GV đã tồn tại chưa (Duplicate check)
    // Bước 3: Điền thông tin vào form chuẩn (Normalization)
    // Bước 4: Cấp mã GV (Auto generate)
    // Bước 5: Lưu hồ sơ vào tủ (Insert to List)
    //
    // 🔍 QUY TRÌNH THÊM GIẢNG VIÊN (ALGORITHM):
    //
    // Bước 1: KIỂM TRA DỮ LIỆU HỢP LỆ (Validation)
    //    • Họ, tên không rỗng
    //    • Ngày sinh hợp lệ, tuổi >= 18
    //    • Giới tính = "Nam" hoặc "Nữ"
    //    • Email có ký tự '@'
    //
    // Bước 2: KIỂM TRA TRÙNG MÃ GIẢNG VIÊN
    //    • Sequential Search: O(n)
    //    • Duyệt qua toàn bộ danh sách
    //    • So sánh từng mã GV với mã mới
    //    • Nếu trùng → return false
    //
    // Bước 3: CHUẨN HÓA DỮ LIỆU (Data Normalization)
    //    • Xóa khoảng trắng thừa đầu/cuối
    //    • Viết HOA chữ cái đầu mỗi từ
    //    • VD: "  nguyễn  văn  an " → "Nguyễn Văn An"
    //
    // Bước 4: TẠO MÃ GIẢNG VIÊN TỰ ĐỘNG (nếu chưa có)
    //    • Format: GVYYxxxx
    //    • VD: GV240001, GV240002,...
    //    • YY = 2 số cuối năm (24 = 2024)
    //    • xxxx = Số thứ tự (tìm max + 1)
    //
    // Bước 5: THÊM VÀO DANH SÁCH
    //    • danhSach.Add(giangVienMoi)
    //    • Độ phức tạp: O(1) amortized
    //
    // 📊 ĐỘ PHỨC TẠP:
    // - Kiểm tra trùng: O(n) - Sequential Search
    // - Tìm mã lớn nhất: O(n)
    // - Add to List: O(1)
    // → Tổng: O(n)
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Chức năng THÊM hoạt động như thế nào?

    Bước 1: KIỂM TRA dữ liệu hợp lệ (Validation)
    Bước 2: KIỂM TRA mã giảng viên có bị trùng không
    Bước 3: CHUẨN HÓA dữ liệu (viết hoa chữ cái đầu, xóa khoảng trắng thừa)
    Bước 4: THÊM vào cuối List

    Tại sao thêm lại ảnh hưởng đến List gốc?
    - List.Add() thêm reference (địa chỉ) object vào cuối List
    - List tự động tăng Count lên 1
    - Object được quản lý bởi List!

    Độ phức tạp: O(n)
    - Kiểm tra trùng mã: O(n)
    - Add vào cuối: O(1)
    */
    public class ChucNangThemThongTinGV
    {
        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI (TỰ CODE) ====================

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
        /// Xóa khoảng trắng thừa ở đầu và cuối
        /// </summary>
        private string XoaKhoangTrangThua(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            if (chuoi.Length == 0)
            {
                return "";
            }

            // Tìm vị trí đầu
            int viTriDau = 0;
            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriDau = i;
                    break;
                }
            }

            // Tìm vị trí cuối
            int viTriCuoi = chuoi.Length - 1;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                char kyTu = chuoi[i];
                if (kyTu != ' ' && kyTu != '\t' && kyTu != '\n' && kyTu != '\r')
                {
                    viTriCuoi = i;
                    break;
                }
            }

            if (viTriDau > viTriCuoi)
            {
                return "";
            }

            int doDai = viTriCuoi - viTriDau + 1;
            return chuoi.Substring(viTriDau, doDai);
        }
        /// <summary>
        /// So sánh 2 chuỗi chính xác
        /// </summary>
        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null)
            {
                return true;
            }

            if (chuoi1 == null || chuoi2 == null)
            {
                return false;
            }

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

                bool laHoa = (kyTu >= 'A') && (kyTu <= 'Z');

                if (laHoa)
                {
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

        /// <summary>
        /// Chuyển chuỗi về chữ hoa
        /// </summary>
        private string ChuyenVeChuHoa(string chuoi)
        {
            if (chuoi == null)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                bool laThuong = (kyTu >= 'a') && (kyTu <= 'z');

                if (laThuong)
                {
                    char kyTuHoa = (char)(kyTu - 32);
                    ketQua += kyTuHoa;
                }
                else
                {
                    ketQua += kyTu;
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Chuyển 1 ký tự về chữ hoa
        /// </summary>
        private char ChuyenKyTuVeChuHoa(char kyTu)
        {
            bool laThuong = (kyTu >= 'a') && (kyTu <= 'z');

            if (laThuong)
            {
                return (char)(kyTu - 32);
            }

            return kyTu;
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

            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }


        /// <summary>
        /// Tách chuỗi thành các từ
        /// </summary>
        private List<string> TachChuoiThanhCacTu(string chuoi)
        {
            List<string> cacTu = new List<string>();

            if (chuoi == null || chuoi.Length == 0)
            {
                return cacTu;
            }

            string tuHienTai = "";

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                if (kyTu == ' ')
                {
                    if (tuHienTai.Length > 0)
                    {
                        cacTu.Add(tuHienTai);
                        tuHienTai = "";
                    }
                }
                else
                {
                    tuHienTai += kyTu;
                }
            }

            if (tuHienTai.Length > 0)
            {
                cacTu.Add(tuHienTai);
            }

            return cacTu;
        }

        /// <summary>
        /// Ghép các từ lại thành chuỗi
        /// </summary>
        private string GhepCacTu(List<string> cacTu)
        {
            if (cacTu == null || cacTu.Count == 0)
            {
                return "";
            }

            string ketQua = "";

            for (int i = 0; i < cacTu.Count; i++)
            {
                ketQua += cacTu[i];

                if (i < cacTu.Count - 1)
                {
                    ketQua += " ";
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Kiểm tra chuỗi có bắt đầu bằng chuỗi con không
        /// </summary>
        private bool KiemTraBatDauBang(string chuoi, string chuoiCon)
        {
            if (chuoi == null || chuoiCon == null)
            {
                return false;
            }

            if (chuoiCon.Length > chuoi.Length)
            {
                return false;
            }

            for (int i = 0; i < chuoiCon.Length; i++)
            {
                if (chuoi[i] != chuoiCon[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi thành số
        /// </summary>
        private int ChuyenChuoiThanhSo(string chuoi)
        {
            if (chuoi == null || chuoi.Length == 0)
            {
                return 0;
            }

            int ketQua = 0;

            for (int i = 0; i < chuoi.Length; i++)
            {
                char kyTu = chuoi[i];

                if (kyTu >= '0' && kyTu <= '9')
                {
                    int chuSo = kyTu - '0';
                    ketQua = ketQua * 10 + chuSo;
                }
                else
                {
                    return 0;
                }
            }

            return ketQua;
        }

        public bool ThemGiangVien(List<ThongTinGiangVien> danhSach, ThongTinGiangVien giangVienMoi)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra giảng viên mới null
            if (giangVienMoi == null)
            {
                return false;
            }

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return false;
            }

            // ===== BƯỚC 2: KIỂM TRA MÃ GIẢNG VIÊN TRÙNG =====

            bool maTonTai = KiemTraMaGVTonTai(danhSach, giangVienMoi.MaGV);

            if (maTonTai)
            {
                return false;
            }

            // ===== BƯỚC 3: KIỂM TRA DỮ LIỆU HỢP LỆ =====

            bool duLieuHopLe = KiemTraDuLieuHopLe(giangVienMoi);

            if (!duLieuHopLe)
            {
                return false;
            }

            // ===== BƯỚC 4: THÊM GIẢNG VIÊN VÀO CUỐI DANH SÁCH =====

            danhSach.Add(giangVienMoi);

            // ===== BƯỚC 5: TRẢ VỀ KẾT QUẢ =====
            return true;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA MÃ TỒN TẠI ====================

        private bool KiemTraMaGVTonTai(List<ThongTinGiangVien> danhSach, string maGV)
        {
            // Kiểm tra mã rỗng
            bool maRong = KiemTraChuoiRong(maGV);
            if (maRong)
            {
                return false;
            }

            // Tìm kiếm tuần tự
            foreach (ThongTinGiangVien gv in danhSach)
            {
                // Lấy mã giảng viên hiện tại
                string maGVHienTai = gv.MaGV;

                // So sánh mã (không phân biệt hoa/thường)
                bool khopMa = SoSanhChuoiKhongPhanBietHoaThuong(maGVHienTai, maGV);

                if (khopMa)
                {
                    return true;
                }
            }

            return false;
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA DỮ LIỆU HỢP LỆ ====================

        private bool KiemTraDuLieuHopLe(ThongTinGiangVien gv)
        {
            // ===== KIỂM TRA 1: MÃ GIẢNG VIÊN (BẮT BUỘC) =====
            bool maRong = KiemTraChuoiRong(gv.MaGV);

            if (maRong)
            {
                return false;
            }

            // ===== KIỂM TRA 2: HỌ (BẮT BUỘC) =====
            bool hoRong = KiemTraChuoiRong(gv.HoGV);

            if (hoRong)
            {
                return false;
            }

            // ===== KIỂM TRA 3: TÊN (BẮT BUỘC) =====
            bool tenRong = KiemTraChuoiRong(gv.TenGV);

            if (tenRong)
            {
                return false;
            }

            // ===== KIỂM TRA 4: NGÀY SINH (PHẢI HỢP LỆ) =====
            bool ngaySinhHopLe = (gv.NgaySinhGV != DateTime.MinValue);

            if (!ngaySinhHopLe)
            {
                return false;
            }

            // ===== KIỂM TRA 5: TUỔI (>= 18) =====
            int namHienTai = DateTime.Now.Year;
            int namSinh = gv.NgaySinhGV.Year;
            int tuoi = namHienTai - namSinh;

            bool tuoiHopLe = (tuoi >= 18);

            if (!tuoiHopLe)
            {
                return false;
            }

            return true;
        }

        // ==================== PHƯƠNG THỨC CHUẨN HÓA DỮ LIỆU ====================

        public void ChuanHoaDuLieu(ThongTinGiangVien gv)
        {
            // Kiểm tra null
            if (gv == null)
            {
                return;
            }

            // ===== BƯỚC 1: XÓA KHOẢNG TRẮNG THỪA =====

            gv.MaGV = XoaKhoangTrangThua(gv.MaGV);
            gv.HoGV = XoaKhoangTrangThua(gv.HoGV);
            gv.TenLotGV = XoaKhoangTrangThua(gv.TenLotGV);
            gv.TenGV = XoaKhoangTrangThua(gv.TenGV);
            gv.EmailGV = XoaKhoangTrangThua(gv.EmailGV);
            gv.DiaChiGV = XoaKhoangTrangThua(gv.DiaChiGV);
            gv.KhoaGV = XoaKhoangTrangThua(gv.KhoaGV);
            gv.CCCDGV = XoaKhoangTrangThua(gv.CCCDGV);

            // ===== BƯỚC 2: VIẾT HOA CHỮ CÁI ĐẦU =====

            gv.HoGV = VietHoaChuCaiDau(gv.HoGV);
            gv.TenLotGV = VietHoaChuCaiDau(gv.TenLotGV);
            gv.TenGV = VietHoaChuCaiDau(gv.TenGV);

            // ===== BƯỚC 3: VIẾT HOA MÃ GIẢNG VIÊN =====

            gv.MaGV = ChuyenVeChuHoa(gv.MaGV);
        }

        // ==================== PHƯƠNG THỨC VIẾT HOA CHỮ CÁI ĐẦU ====================

        public string VietHoaChuCaiDau(string chuoi)
        {
            // Kiểm tra rỗng
            bool rong = KiemTraChuoiRong(chuoi);
            if (rong)
            {
                return chuoi;
            }

            // Tách chuỗi thành các từ
            List<string> cacTu = TachChuoiThanhCacTu(chuoi);

            // Viết hoa chữ cái đầu mỗi từ
            for (int i = 0; i < cacTu.Count; i++)
            {
                string tu = cacTu[i];

                if (tu.Length > 0)
                {
                    // Lấy ký tự đầu tiên
                    char kyTuDau = tu[0];

                    // Chuyển thành chữ hoa
                    char kyTuDauHoa = ChuyenKyTuVeChuHoa(kyTuDau);

                    // Lấy phần còn lại
                    string phanConLai = "";
                    if (tu.Length > 1)
                    {
                        phanConLai = tu.Substring(1);
                        phanConLai = ChuyenVeChuThuong(phanConLai);
                    }

                    // Ghép lại
                    cacTu[i] = kyTuDauHoa + phanConLai;
                }
            }

            // Ghép các từ lại thành chuỗi
            return GhepCacTu(cacTu);
        }

        // ==================== PHƯƠNG THỨC TẠO MÃ GIẢNG VIÊN TỰ ĐỘNG ====================

        public string TaoMaGiangVienTuDong(List<ThongTinGiangVien> danhSach, int namVaoLam)
        {
            // Lấy 2 số cuối của năm
            int namCuoi = namVaoLam % 100;
            string namStr = namCuoi.ToString();

            // Đảm bảo luôn có 2 chữ số
            if (namStr.Length == 1)
            {
                namStr = "0" + namStr;
            }

            // Bắt đầu từ số thứ tự 1
            int soThuTu = 1;

            // Tìm số thứ tự lớn nhất trong năm này
            if (danhSach != null)
            {
                foreach (ThongTinGiangVien gv in danhSach)
                {
                    // Kiểm tra mã giảng viên có bắt đầu bằng "GV" + năm không
                    string dauMa = "GV" + namStr;

                    bool batDau = KiemTraBatDauBang(gv.MaGV, dauMa);

                    if (batDau)
                    {
                        // Lấy 4 số cuối (số thứ tự)
                        string soStr = gv.MaGV.Substring(4);

                        // Chuyển thành số
                        int so = ChuyenChuoiThanhSo(soStr);

                        // Cập nhật số thứ tự lớn nhất
                        if (so >= soThuTu)
                        {
                            soThuTu = so + 1;
                        }
                    }
                }
            }

            // Tạo mã giảng viên
            // Đảm bảo số thứ tự luôn có 4 chữ số
            string soThuTuStr = soThuTu.ToString();
            while (soThuTuStr.Length < 4)
            {
                soThuTuStr = "0" + soThuTuStr;
            }

            return "GV" + namStr + soThuTuStr;
        }
    }
}
