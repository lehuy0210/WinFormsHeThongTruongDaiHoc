using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer
{
    // ==================== CLASS CHỨC NĂNG SẮP XẾP SINH VIÊN (BLL) ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS: Chapter 4 (Nested loops), Chapter 5 (Functions)
    // 2️⃣ PROGRAMMING TECHNIQUES: Chapter 4 (String comparison)
    // 3️⃣ OOP: Chapter 2 (Classes, Objects, Methods)
    // 4️⃣ DSA1: Chapter 2 - Sorting
    //    • 2.1.1: Bubble Sort - Sắp xếp nổi bọt
    //    • 2.1.2: Selection Sort - Sắp xếp chọn  
    //    • 2.1.3: Insertion Sort - Sắp xếp chèn
    // 5️⃣ DATABASE PROGRAMMING: Chapter 3 (N-Layer - BLL)
    //
    // 🎯 MỤC ĐÍCH:
    // - SẮP XẾP theo TÊN (Bubble Sort)
    // - SẮP XẾP theo MÃ SV (Selection Sort)
    // - SẮP XẾP theo HỌ TÊN ĐẦY ĐỦ (Insertion Sort)
    // - SẮP XẾP theo NGÀY SINH, LỚP
    // - SẮP XẾP theo NHIỀU TIÊU CHÍ
    //
    // 💡 3 THUẬT TOÁN SẮP XẾP:
    // 
    // BUBBLE SORT: So sánh cặp kề nhau, đổi chỗ nếu sai thứ tự
    // SELECTION SORT: Tìm min/max, đưa về đúng vị trí
    // INSERTION SORT: Chèn từng phần tử vào vị trí đúng
    //
    // 📊 ĐỘ PHỨC TẠP: O(n²) - Phù hợp danh sách nhỏ (<1000 SV)
    /*
    Sắp xếp hoạt động như thế nào?
    - Giống như sắp xếp bài trong tay
    - Bubble: So sánh 2 lá kề nhau, đổi chỗ
    - Selection: Tìm lá nhỏ nhất, đưa về đầu
    - Insertion: Chèn lá vào đúng vị trí
    */
    public class ChucNangSapXepSV
    {
        // ==================== SẮP XẾP THEO TÊN (BUBBLE SORT) ====================
        // Sử dụng: Bubble Sort (Chapter 2.1.1 - DSA1)

        /// <summary>
        /// Sắp xếp theo tên sử dụng Bubble Sort
        /// Sort by name using Bubble Sort
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tangDan">true = tăng dần, false = giảm dần</param>
        /*
        VÍ DỤ CHẠY TAY BUBBLE SORT:
  
        ds = [Bình, An, Dũng, Chi]
        Sắp xếp tăng dần (A → Z)
      
        Vòng lặp i=0:
        - So sánh Bình vs An → Bình > An → Đổi chỗ → [An, Bình, Dũng, Chi]
    - So sánh Bình vs Dũng → Bình < Dũng → Không đổi
   - So sánh Dũng vs Chi → Dũng > Chi → Đổi chỗ → [An, Bình, Chi, Dũng]
        
  Vòng lặp i=1:
        - So sánh An vs Bình → An < Bình → Không đổi
   - So sánh Bình vs Chi → Bình < Chi → Không đổi
   
Kết quả: [An, Bình, Chi, Dũng]
  
  Độ phức tạp: O(n²)
        - Vòng ngoài: n-1 lần
        - Vòng trong: n-i-1 lần
        */
        public void SapXepTheoTen(List<ThongTinSinhVien> danhSach, bool tangDan = true)
        {
            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return;
            }

            if (danhSach.Count <= 1)
            {
                return; // Không cần sắp xếp
            }

            int n = danhSach.Count;

            // ===== BUBBLE SORT ALGORITHM =====
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Lấy tên 2 sinh viên cần so sánh
                    string tenTruoc = danhSach[j].TenSV;        // Sinh viên vị trí j
                    string tenSau = danhSach[j + 1].TenSV;      // Sinh viên vị trí j+1

                    // Chuyển về chữ thường để so sánh
                    tenTruoc = ChuyenVeChuThuong(tenTruoc);
                    tenSau = ChuyenVeChuThuong(tenSau);

                    // So sánh 2 tên
                    int ketQuaSoSanh = SoSanhChuoi(tenTruoc, tenSau);

                    // Kiểm tra cần hoán đổi không
                    bool canHoanDoi = false;

                    if (tangDan)
                    {
                        // Sắp xếp tăng dần (A → Z)
                        if (ketQuaSoSanh > 0)
                        {
                            canHoanDoi = true; // Tên trước > tên sau → Đổi chỗ
                        }
                    }
                    else
                    {
                        // Sắp xếp giảm dần (Z → A)
                        if (ketQuaSoSanh < 0)
                        {
                            canHoanDoi = true; // Tên trước < tên sau → Đổi chỗ
                        }
                    }

                    if (canHoanDoi)
                    {
                        // Hoán đổi (Swap)
                        ThongTinSinhVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        // ==================== SẮP XẾP THEO MÃ SINH VIÊN (SELECTION SORT) ====================
        // Sử dụng: Selection Sort (Chapter 2.1.2 - DSA1)

        /// <summary>
        /// Sắp xếp theo mã sinh viên sử dụng Selection Sort
        /// Sort by student ID using Selection Sort
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tangDan">true = tăng dần, false = giảm dần</param>
        /*
            VÍ DỤ CHẠY TAY SELECTION SORT:

    ds = [SV003, SV001, SV004, SV002]
            Sắp xếp tăng dần

            Vòng lặp i=0:
         - Tìm min trong [SV003, SV001, SV004, SV002] → SV001 (index 1)
            - Đổi chỗ: [SV001, SV003, SV004, SV002]

            Vòng lặp i=1:
      - Tìm min trong [SV003, SV004, SV002] → SV002 (index 3)
      - Đổi chỗ: [SV001, SV002, SV004, SV003]

            Vòng lặp i=2:
    - Tìm min trong [SV004, SV003] → SV003 (index 3)
      - Đổi chỗ: [SV001, SV002, SV003, SV004]

          Kết quả: [SV001, SV002, SV003, SV004]

        Độ phức tạp: O(n²)
            */
        public void SapXepTheoMaSV(List<ThongTinSinhVien> danhSach, bool tangDan = true)
        {
            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return;
            }

            if (danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // ===== SELECTION SORT ALGORITHM =====
            for (int i = 0; i < n - 1; i++)
            {
                // Tìm phần tử phù hợp nhất trong phần chưa sắp xếp
                int indexPhuHop = i;

                for (int j = i + 1; j < n; j++)
                {
                    // Lấy mã sinh viên cần so sánh
                    string maSVHienTai = danhSach[j].MaSV;
                    string maSVPhuHop = danhSach[indexPhuHop].MaSV;

                    // So sánh 2 mã sinh viên
                    int ketQuaSoSanh = SoSanhChuoi(maSVHienTai, maSVPhuHop);

                    // Kiểm tra có phù hợp hơn không
                    bool laPhuHopHon = false;

                    if (tangDan)
                    {
                        // Tăng dần: tìm mã nhỏ nhất
                        if (ketQuaSoSanh < 0)
                        {
                            laPhuHopHon = true;
                        }
                    }
                    else
                    {
                        // Giảm dần: tìm mã lớn nhất
                        if (ketQuaSoSanh > 0)
                        {
                            laPhuHopHon = true;
                        }
                    }

                    if (laPhuHopHon)
                    {
                        indexPhuHop = j;
                    }
                }

                // Hoán đổi với vị trí đầu tiên chưa sắp xếp
                if (indexPhuHop != i)
                {
                    // Swap
                    ThongTinSinhVien temp = danhSach[i];
                    danhSach[i] = danhSach[indexPhuHop];
                    danhSach[indexPhuHop] = temp;
                }
            }
        }

        // ==================== SẮP XẾP THEO HỌ VÀ TÊN (INSERTION SORT) ====================
        // Sử dụng: Insertion Sort (Chapter 2.1.3 - DSA1)

        /// <summary>
        /// Sắp xếp theo họ và tên sử dụng Insertion Sort
        /// Sort by full name using Insertion Sort
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tangDan">true = tăng dần, false = giảm dần</param>
        /*
               VÍ DỤ CHẠY TAY INSERTION SORT:

               ds = [Trần Bình, Nguyễn An, Lê Dũng]
         Sắp xếp tăng dần

               i=1: key = Nguyễn An
               - So sánh với Trần Bình → Nguyễn < Trần → Dịch Trần sang phải
              - Chèn Nguyễn An vào đầu
             - Kết quả: [Nguyễn An, Trần Bình, Lê Dũng]

               i=2: key = Lê Dũng
               - So sánh với Trần Bình → Lê < Trần → Dịch Trần sang phải
       - So sánh với Nguyễn An → Lê < Nguyễn → Dịch Nguyễn sang phải
         - Chèn Lê Dũng vào đầu
               - Kết quả: [Lê Dũng, Nguyễn An, Trần Bình]

         Độ phức tạp: O(n²)
               */
        public void SapXepTheoHoVaTen(List<ThongTinSinhVien> danhSach, bool tangDan = true)
        {
            // Kiểm tra danh sách
            if (danhSach == null)
            {
                return;
            }

            if (danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // ===== INSERTION SORT ALGORITHM =====
            for (int i = 1; i < n; i++)
            {
                // Lấy phần tử cần chèn vào vị trí đúng
                ThongTinSinhVien key = danhSach[i];
                int j = i - 1;

                // Dịch các phần tử lớn hơn key về phía sau
                while (j >= 0)
                {
                    // Lấy họ tên đầy đủ để so sánh
                    string hoTenKey = LayHoTenDayDu(key);
                    string hoTenJ = LayHoTenDayDu(danhSach[j]);

                    // So sánh 2 họ tên
                    int ketQuaSoSanh = SoSanhChuoi(hoTenJ, hoTenKey);

                    // Kiểm tra cần dịch chuyển không
                    bool canDich = false;

                    if (tangDan)
                    {
                        // Sắp xếp tăng dần
                        if (ketQuaSoSanh > 0)
                        {
                            canDich = true; // Họ tên J > họ tên key → Cần dịch
                        }
                    }
                    else
                    {
                        // Sắp xếp giảm dần
                        if (ketQuaSoSanh < 0)
                        {
                            canDich = true; // Họ tên J < họ tên key → Cần dịch
                        }
                    }

                    if (!canDich)
                    {
                        break; // Đã tìm thấy vị trí đúng
                    }

                    // Dịch phần tử về phía sau
                    danhSach[j + 1] = danhSach[j];
                    j--;
                }

                // Chèn key vào vị trí đúng
                danhSach[j + 1] = key;
            }
        }

        // ==================== SẮP XẾP THEO NGÀY SINH ====================

        /// <summary>
        /// Sắp xếp theo ngày sinh
        /// Sort by birth date
        /// </summary>
        /// <param name="danhSach">Danh sách sinh viên</param>
        /// <param name="tangDan">true = tăng dần, false = giảm dần</param>
        public void SapXepTheoNgaySinh(List<ThongTinSinhVien> danhSach, bool tangDan = true)
        {
            // Kiểm tra danh sách
            if (danhSach == null || danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // Bubble Sort algorithm
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Lấy ngày sinh
                    DateTime ngaySinhTruoc = danhSach[j].NgaySinhSV;
                    DateTime ngaySinhSau = danhSach[j + 1].NgaySinhSV;

                    // So sánh 2 ngày
                    int ketQuaSoSanh = SoSanhNgayThang(ngaySinhTruoc, ngaySinhSau);

                    // Kiểm tra cần hoán đổi
                    bool canHoanDoi = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh > 0)
                        {
                            canHoanDoi = true;
                        }
                    }
                    else
                    {
                        if (ketQuaSoSanh < 0)
                        {
                            canHoanDoi = true;
                        }
                    }

                    if (canHoanDoi)
                    {
                        // Swap
                        ThongTinSinhVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        // ==================== SẮP XẾP THEO LỚP ====================

        /// <summary>
        /// Sắp xếp theo lớp
        /// Sort by class
        /// </summary>
        public void SapXepTheoLop(List<ThongTinSinhVien> danhSach, bool tangDan = true)
        {
            // Kiểm tra danh sách
            if (danhSach == null || danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // Selection Sort
            for (int i = 0; i < n - 1; i++)
            {
                int indexPhuHop = i;

                for (int j = i + 1; j < n; j++)
                {
                    string lopHienTai = danhSach[j].LopSV;
                    string lopPhuHop = danhSach[indexPhuHop].LopSV;

                    int ketQuaSoSanh = SoSanhChuoi(lopHienTai, lopPhuHop);

                    bool laPhuHopHon = false;

                    if (tangDan)
                    {
                        if (ketQuaSoSanh < 0)
                        {
                            laPhuHopHon = true;
                        }
                    }
                    else
                    {
                        if (ketQuaSoSanh > 0)
                        {
                            laPhuHopHon = true;
                        }
                    }

                    if (laPhuHopHon)
                    {
                        indexPhuHop = j;
                    }
                }

                if (indexPhuHop != i)
                {
                    // Swap
                    ThongTinSinhVien temp = danhSach[i];
                    danhSach[i] = danhSach[indexPhuHop];
                    danhSach[indexPhuHop] = temp;
                }
            }
        }

        // ==================== SẮP XẾP THEO NHIỀU TIÊU CHÍ ====================

        /// <summary>
        /// Sắp xếp theo lớp, sau đó theo họ tên
        /// Sort by class, then by full name
        /// </summary>
        public void SapXepTheoLopVaHoTen(List<ThongTinSinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // Bubble Sort với 2 tiêu chí
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    string lopTruoc = danhSach[j].LopSV;
                    string lopSau = danhSach[j + 1].LopSV;

                    int soSanhLop = SoSanhChuoi(lopTruoc, lopSau);

                    bool canHoanDoi = false;

                    if (soSanhLop > 0)
                    {
                        canHoanDoi = true; // Lớp trước > lớp sau
                    }
                    else if (soSanhLop == 0)
                    {
                        // Cùng lớp → So sánh họ tên
                        string hoTenTruoc = LayHoTenDayDu(danhSach[j]);
                        string hoTenSau = LayHoTenDayDu(danhSach[j + 1]);

                        int soSanhHoTen = SoSanhChuoi(hoTenTruoc, hoTenSau);

                        if (soSanhHoTen > 0)
                        {
                            canHoanDoi = true; // Họ tên trước > họ tên sau
                        }
                    }

                    if (canHoanDoi)
                    {
                        // Swap
                        ThongTinSinhVien temp = danhSach[j];
                        danhSach[j] = danhSach[j + 1];
                        danhSach[j + 1] = temp;
                    }
                }
            }
        }

        // ==================== PHƯƠNG THỨC ĐẢO NGƯỢC DANH SÁCH ====================

        /// <summary>
        /// Đảo ngược thứ tự danh sách
        /// Reverse the order of the list
        /// </summary>
        public void DaoNguocDanhSach(List<ThongTinSinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count <= 1)
            {
                return;
            }

            int n = danhSach.Count;

            // Hoán đổi phần tử đầu với phần tử cuối
            for (int i = 0; i < n / 2; i++)
            {
                ThongTinSinhVien temp = danhSach[i];
                danhSach[i] = danhSach[n - 1 - i];
                danhSach[n - 1 - i] = temp;
            }
        }

        // ==================== PHƯƠNG THỨC KIỂM TRA DANH SÁCH ĐÃ SẮP XẾP ====================

        /// <summary>
        /// Kiểm tra danh sách đã được sắp xếp theo tên chưa
        /// Check if list is sorted by name
        /// </summary>
        public bool KiemTraDaSapXepTheoTen(List<ThongTinSinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count <= 1)
            {
                return true;
            }

            for (int i = 0; i < danhSach.Count - 1; i++)
            {
                string tenHienTai = ChuyenVeChuThuong(danhSach[i].TenSV);
                string tenKeTiep = ChuyenVeChuThuong(danhSach[i + 1].TenSV);

                int ketQuaSoSanh = SoSanhChuoi(tenHienTai, tenKeTiep);

                if (ketQuaSoSanh > 0)
                {
                    return false;
                }
            }

            return true;
        }

        // ==================== PHƯƠNG THỨC HỖ TRỢ (TỰ CODE) ====================

        /// <summary>
        /// So sánh 2 chuỗi
        /// </summary>
        /// <returns>< 0 nếu chuoi1 < chuoi2, > 0 nếu chuoi1 > chuoi2, = 0 nếu bằng nhau</returns>
        private int SoSanhChuoi(string chuoi1, string chuoi2)
        {
            // Chuyển về chữ thường
            chuoi1 = ChuyenVeChuThuong(chuoi1);
            chuoi2 = ChuyenVeChuThuong(chuoi2);

            // Lấy độ dài ngắn nhất
            int doDaiMin = chuoi1.Length < chuoi2.Length ? chuoi1.Length : chuoi2.Length;

            // So sánh từng ký tự
            for (int i = 0; i < doDaiMin; i++)
            {
                if (chuoi1[i] != chuoi2[i])
                {
                    return chuoi1[i] - chuoi2[i];
                }
            }

            // So sánh độ dài
            return chuoi1.Length - chuoi2.Length;
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

        /// <summary>
        /// Lấy họ tên đầy đủ
        /// </summary>
        private string LayHoTenDayDu(ThongTinSinhVien sv)
        {
            if (sv == null)
            {
                return "";
            }

            string hoTenDayDu = sv.HoSV;

            if (!KiemTraChuoiRong(sv.TenLotSV))
            {
                hoTenDayDu += " " + sv.TenLotSV;
            }

            hoTenDayDu += " " + sv.TenSV;

            return XoaKhoangTrangThua(hoTenDayDu);
        }

        /// <summary>
        /// So sánh 2 ngày tháng
        /// </summary>
        private int SoSanhNgayThang(DateTime ngay1, DateTime ngay2)
        {
            if (ngay1.Year != ngay2.Year)
            {
                return ngay1.Year - ngay2.Year;
            }

            if (ngay1.Month != ngay2.Month)
            {
                return ngay1.Month - ngay2.Month;
            }

            return ngay1.Day - ngay2.Day;
        }

        /// <summary>
        /// Kiểm tra chuỗi rỗng
        /// </summary>
        private bool KiemTraChuoiRong(string chuoi)
        {
            if (chuoi == null || chuoi.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < chuoi.Length; i++)
            {
                if (chuoi[i] != ' ' && chuoi[i] != '\t')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Xóa khoảng trắng thừa
        /// </summary>
        private string XoaKhoangTrangThua(string chuoi)
        {
            if (chuoi == null || chuoi.Length == 0)
            {
                return "";
            }

            // Tìm vị trí đầu
            int viTriDau = 0;
            for (int i = 0; i < chuoi.Length; i++)
            {
                if (chuoi[i] != ' ' && chuoi[i] != '\t')
                {
                    viTriDau = i;
                    break;
                }
            }

            // Tìm vị trí cuối
            int viTriCuoi = chuoi.Length - 1;
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                if (chuoi[i] != ' ' && chuoi[i] != '\t')
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

        /*
   ==================== TÓM TẮT CHO SINH VIÊN ====================
        
        1. CÁC THUẬT TOÁN SẮP XẾP:
  - Bubble Sort: O(n²) - Đơn giản, dễ hiểu
   - Selection Sort: O(n²) - Tìm min/max
- Insertion Sort: O(n²) - Chèn vào vị trí đúng
        
   2. CÁC PHƯƠNG THỨC SẮP XẾP:
        - SapXepTheoTen(): Bubble Sort
        - SapXepTheoMaSV(): Selection Sort
   - SapXepTheoHoVaTen(): Insertion Sort
    - SapXepTheoNgaySinh(): Bubble Sort
        - SapXepTheoLop(): Selection Sort
           - SapXepTheoLopVaHoTen(): Bubble Sort 2 tiêu chí
        
  3. CÁC METHOD HỖ TRỢ TỰ CODE:
        - SoSanhChuoi(): So sánh 2 chuỗi
   - ChuyenVeChuThuong(): Lowercase
    - LayHoTenDayDu(): Ghép họ + tên lót + tên
     - SoSanhNgayThang(): So sánh 2 ngày
 
     4. KIẾN THỨC ÁP DỤNG:
- OOP: Classes, Objects, Methods
- DSA1: Bubble Sort, Selection Sort, Insertion Sort
     - Comparison operations
   - Swap operations
  
  5. ĐỘ PHỨC TẠP:
        - Tất cả: O(n²)
- Phù hợp với danh sách nhỏ (< 1000 phần tử)
        
   ==================== END TÓM TẮT ====================
        */
    }
}