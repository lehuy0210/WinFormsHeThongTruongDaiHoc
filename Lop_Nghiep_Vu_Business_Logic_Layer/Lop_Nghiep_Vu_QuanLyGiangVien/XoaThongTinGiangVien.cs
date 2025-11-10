using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyGiangVien
{
    // ==================== CLASS CHỨC NĂNG XÓA GIẢNG VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures (if/else, for, foreach)
    //    - Chapter 5: Functions (Methods, Return values, Parameters)
    //    - Chapter 6: Arrays (Array operations)
    //
    // 2️⃣ OBJECT-ORIENTED PROGRAMMING:
    //    - Chapter 2: Classes and Objects (Methods, Passing Objects)
    //
    // 3️⃣ DATA STRUCTURES AND ALGORITHMS 1:
    //    - Chapter 1: Lists
    //      • 1.1.3: Delete operation - Xóa phần tử khỏi danh sách
    //    - Chapter 2: Searching
    //      • 2.2.1: Sequential Search - Tìm giảng viên cần xóa
    //
    // 4️⃣ DATABASE PROGRAMMING:
    //    - Chapter 3: N-Layer Architecture (Business Logic Layer)
    //
    // 🎯 MỤC ĐÍCH:
    // - XÓA giảng viên theo mã
    // - XÓA NHIỀU giảng viên cùng lúc
    // - XÓA CÓ SAO LƯU (backup) để khôi phục nếu nhầm
    // - XÓA THEO ĐIỀU KIỆN (khoa, giới tính,...)
    //
    public class ChucNangXoaThongTinGiangVien
    {
        public bool XoaGiangVien(List<ThongTinGiangVien> danhSach, string maGV)
        {
            // ===== BƯỚC 1: KIỂM TRA DỮ LIỆU ĐẦU VÀO =====

            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return false;
            }
            // Kiểm tra mã giảng viên rỗng
            bool maRong = KiemTraChuoiRong(maGV);
            if (maRong)
            {
                return false;
            }
            // ===== BƯỚC 2: TÌM GIẢNG VIÊN CẦN XÓA =====

            ThongTinGiangVien gvCanXoa = TimGiangVienTheoMa(danhSach, maGV);
            // Kiểm tra có tìm thấy không
            if (gvCanXoa == null)
            {
                return false;
            }
            // ===== BƯỚC 3: XÓA GIẢNG VIÊN KHỎI DANH SÁCH =====

            bool daXoa = danhSach.Remove(gvCanXoa);
            // ===== BƯỚC 4: TRẢ VỀ KẾT QUẢ =====
            return daXoa;
        }

        public int XoaNhieuGiangVien(List<ThongTinGiangVien> danhSach, List<string> danhSachMaGV)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return 0;
            }

            if (danhSachMaGV == null)
            {
                return 0;
            }
            // Đếm số lượng đã xóa
            int soLuongDaXoa = 0;
            // Xóa từng giảng viên
            foreach (string maGV in danhSachMaGV)
            {
                // Gọi method XoaGiangVien
                bool ketQua = XoaGiangVien(danhSach, maGV);

                if (ketQua)
                {
                    soLuongDaXoa++;
                }
            }
            return soLuongDaXoa;
        }

        public int XoaTheoKhoa(List<ThongTinGiangVien> danhSach, string khoa)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return 0;
            }

            bool khoaRong = KiemTraChuoiRong(khoa);
            if (khoaRong)
            {
                return 0;
            }
            // ===== BƯỚC 1: TÌM TẤT CẢ GIẢNG VIÊN THUỘC KHOA =====
            // Tạo danh sách tạm để lưu giảng viên cần xóa
            List<ThongTinGiangVien> danhSachXoa = new List<ThongTinGiangVien>();
            foreach (ThongTinGiangVien gv in danhSach)
            {
                // So sánh khoa (không phân biệt hoa/thường)
                bool khoaKhop = SoSanhChuoiKhongPhanBietHoaThuong(gv.KhoaGV, khoa);

                if (khoaKhop)
                {
                    danhSachXoa.Add(gv);
                }
            }
            // ===== BƯỚC 2: XÓA CÁC GIẢNG VIÊN ĐÃ TÌM THẤY =====
            int soLuongDaXoa = 0;

            foreach (ThongTinGiangVien gv in danhSachXoa)
            {
                bool daXoa = danhSach.Remove(gv);

                if (daXoa)
                {
                    soLuongDaXoa++;
                }
            }
            return soLuongDaXoa;
        }

        private ThongTinGiangVien? TimGiangVienTheoMa(List<ThongTinGiangVien> danhSach, string maGV)
        {
            // Kiểm tra danh sách null
            if (danhSach == null)
            {
                return null;
            }
            // Kiểm tra mã rỗng
            bool maRong = KiemTraChuoiRong(maGV);
            if (maRong)
            {
                return null;
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
                    return gv;
                }
            }
            return null;
        }

        public bool KiemTraCoTheXoa(ThongTinGiangVien gv)
        {
            // Kiểm tra null
            if (gv == null)
            {
                return false;
            }
            return true;
        }

        public ThongTinGiangVien? SaoLuuGiangVien(ThongTinGiangVien gv)
        {
            // Kiểm tra null
            if (gv == null)
            {
                return null;
            }
            // Tạo bản sao MỚI
            ThongTinGiangVien banSao = new ThongTinGiangVien();

            // Sao chép từng thuộc tính
            banSao.ID = gv.ID;
            banSao.MaGV = gv.MaGV;
            banSao.HoGV = gv.HoGV;
            banSao.TenLotGV = gv.TenLotGV;
            banSao.TenGV = gv.TenGV;
            banSao.NgaySinhGV = gv.NgaySinhGV;
            banSao.GioiTinhGV = gv.GioiTinhGV;
            banSao.CCCDGV = gv.CCCDGV;
            banSao.DiaChiGV = gv.DiaChiGV;
            banSao.EmailGV = gv.EmailGV;
            banSao.SDTGV = gv.SDTGV;
            banSao.KhoaGV = gv.KhoaGV;
            banSao.ChuyenNganhGV = gv.ChuyenNganhGV;
            banSao.HocViGV = gv.HocViGV;
            banSao.TrangThaiGV = gv.TrangThaiGV;
            return banSao;
        }

        public bool XoaAnToan(List<ThongTinGiangVien> danhSach,
            string maGV,
            out ThongTinGiangVien? banSao)
        {
            // Khởi tạo biến out
            banSao = null;
            // ===== BƯỚC 1: TÌM GIẢNG VIÊN =====
            ThongTinGiangVien? gvCanXoa = TimGiangVienTheoMa(danhSach, maGV);
            if (gvCanXoa == null)
            {
                return false;
            }
            // ===== BƯỚC 2: KIỂM TRA CÓ THỂ XÓA KHÔNG =====
            bool coTheXoa = KiemTraCoTheXoa(gvCanXoa);

            if (!coTheXoa)
            {
                return false;
            }
            // ===== BƯỚC 3: SAO LƯU TRƯỚC KHI XÓA =====
            banSao = SaoLuuGiangVien(gvCanXoa);
            // ===== BƯỚC 4: XÓA GIẢNG VIÊN =====
            bool ketQua = danhSach.Remove(gvCanXoa);
            return ketQua;
        }

        public bool KhoiPhucGiangVien(List<ThongTinGiangVien> danhSach,
            ThongTinGiangVien gvKhoiPhuc)
        {
            // Kiểm tra đầu vào
            if (danhSach == null)
            {
                return false;
            }
            if (gvKhoiPhuc == null)
            {
                return false;
            }
            // ===== BƯỚC 1: KIỂM TRA MÃ ĐÃ TỒN TẠI CHƯA =====
            ThongTinGiangVien? gvTonTai = TimGiangVienTheoMa(danhSach, gvKhoiPhuc.MaGV);
            if (gvTonTai != null)
            {
                return false;
            }
            // ===== BƯỚC 2: THÊM LẠI GIẢNG VIÊN VÀO DANH SÁCH =====
            danhSach.Add(gvKhoiPhuc);
            return true;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ XỬ LÝ CHUỖI ====================

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

        private bool SoSanhChuoiKhongPhanBietHoaThuong(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null) return true;
            if (chuoi1 == null || chuoi2 == null) return false;

            string chuoi1Thuong = ChuyenVeChuThuong(chuoi1);
            string chuoi2Thuong = ChuyenVeChuThuong(chuoi2);

            return SoSanhChuoiChinhXac(chuoi1Thuong, chuoi2Thuong);
        }

        private bool SoSanhChuoiChinhXac(string chuoi1, string chuoi2)
        {
            if (chuoi1 == null && chuoi2 == null) return true;
            if (chuoi1 == null || chuoi2 == null) return false;

            if (chuoi1.Length != chuoi2.Length) return false;

            for (int i = 0; i < chuoi1.Length; i++)
            {
                if (chuoi1[i] != chuoi2[i]) return false;
            }
            return true;
        }

        private string ChuyenVeChuThuong(string chuoi)
        {
            if (chuoi == null) return "";

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
    }
}
