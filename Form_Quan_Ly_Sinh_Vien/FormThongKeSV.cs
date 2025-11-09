using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsHeThongTruongDaiHoc.Lớp_Nghiệp_Vụ___Business_Logic_Layer;

namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien
{
    // ==================== FORM THỐNG KÊ SINH VIÊN (MODERN UI) ====================
    // CẢI TIẾN:
    // 1. UI hiện đại với GroupBox, màu sắc đẹp
    // 2. Sử dụng ChucNangThongKeSV từ BLL
    // 3. Hiển thị thống kê tổng quan, theo lớp, theo trạng thái
    // 4. Code đơn giản, dễ hiểu cho sinh viên
    public partial class FormThongKeSV : Form
    {
        // ===== THUỘC TÍNH =====
        private List<ThongTinSinhVien> danhSachSV;
        private ChucNangThongKeSV chucNangThongKe;

        // ===== CONSTRUCTOR =====
        public FormThongKeSV(List<ThongTinSinhVien> danhSach)
        {
            InitializeComponent();

            // Lưu danh sách sinh viên
            this.danhSachSV = danhSach;

            // Khởi tạo BLL
            chucNangThongKe = new ChucNangThongKeSV();

            // Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // Cấu hình button
            buttonDong.DialogResult = DialogResult.Cancel;
            buttonLamMoi.Click += buttonLamMoi_Click;
            buttonThongKeLop.Click += buttonThongKeLop_Click;

            // Khởi tạo ComboBox
            KhoiTaoComboBoxLop();

            // Load thống kê ban đầu
            LoadThongKe();
        }

        // ===== KHỞI TẠO COMBOBOX LỚP =====
        private void KhoiTaoComboBoxLop()
        {
            comboBoxChonLop.Items.AddRange(new object[] {
                "CNTT1", "CNTT2", "CNTT3", "CNTT4",
                "KHMT1", "KHMT2", "KHMT3", "KHMT4",
                "HTTT1", "HTTT2", "HTTT3", "HTTT4",
                "KTPM1", "KTPM2", "KTPM3", "KTPM4"
            });

            if (comboBoxChonLop.Items.Count > 0)
                comboBoxChonLop.SelectedIndex = 0;
        }

        // ===== LOAD THỐNG KÊ =====
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Method này load tất cả thống kê và hiển thị lên form:
         * 1. Thống kê tổng quan (Tổng số, Nam, Nữ)
         * 2. Thống kê theo trạng thái (Đang học, Tốt nghiệp, ...)
         *
         * Sử dụng ChucNangThongKeSV từ BLL để tính toán
         */
        private void LoadThongKe()
        {
            // Kiểm tra danh sách
            if (danhSachSV == null || danhSachSV.Count == 0)
            {
                MessageBox.Show(
                    "Không có dữ liệu sinh viên để thống kê!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // ===== 1. THỐNG KÊ TỔNG QUAN =====
            Dictionary<string, int> thongKeTongQuan = chucNangThongKe.LayThongKeTongQuan(danhSachSV);

            labelValueTongSo.Text = thongKeTongQuan["TongSoSV"].ToString();
            labelValueNam.Text = thongKeTongQuan["SoSVNam"].ToString();
            labelValueNu.Text = thongKeTongQuan["SoSVNu"].ToString();

            // ===== 2. THỐNG KÊ THEO TRẠNG THÁI =====
            int soDangHoc = chucNangThongKe.DemTheoTrangThai(danhSachSV, "Đang học");
            int soTotNghiep = chucNangThongKe.DemTheoTrangThai(danhSachSV, "Tốt nghiệp");
            int soNghiHoc = chucNangThongKe.DemTheoTrangThai(danhSachSV, "Nghỉ học");
            int soBaoLuu = chucNangThongKe.DemTheoTrangThai(danhSachSV, "Bảo lưu");
            int soDinhChi = chucNangThongKe.DemTheoTrangThai(danhSachSV, "Đình chỉ");

            labelValueDangHoc.Text = soDangHoc.ToString();
            labelValueTotNghiep.Text = soTotNghiep.ToString();
            labelValueNghiHoc.Text = soNghiHoc.ToString();
            labelValueBaoLuu.Text = soBaoLuu.ToString();
            labelValueDinhChi.Text = soDinhChi.ToString();
        }

        // ===== XỬ LÝ BUTTON THỐNG KÊ LỚP =====
        private void buttonThongKeLop_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn lớp chưa
            if (comboBoxChonLop.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn lớp cần thống kê!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Lấy tên lớp đã chọn
            string tenLop = comboBoxChonLop.Text;

            // Thống kê theo lớp
            int soSVTrongLop = chucNangThongKe.DemTheoLop(danhSachSV, tenLop);

            // Hiển thị kết quả
            labelValueSoSVLop.Text = soSVTrongLop.ToString();

            // Hiển thị thông báo
            MessageBox.Show(
                $"Lớp {tenLop} có {soSVTrongLop} sinh viên",
                "Kết quả thống kê",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ===== XỬ LÝ BUTTON LÀM MỚI =====
        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            // Load lại thống kê
            LoadThongKe();

            // Reset ComboBox
            if (comboBoxChonLop.Items.Count > 0)
                comboBoxChonLop.SelectedIndex = 0;

            // Reset label số SV lớp
            labelValueSoSVLop.Text = "0";

            MessageBox.Show(
                "Đã làm mới thống kê!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /*
         * ==================== TÓM TẮT CẢI TIẾN ====================
         *
         * 1. UI DESIGN:
         *    - 3 GroupBox: Tổng quan, Theo lớp, Theo trạng thái
         *    - Màu sắc đẹp: Blue (0, 120, 215), Green (16, 185, 129), ...
         *    - Modern font: Segoe UI
         *    - Icon: 📊, 🔄, ✕
         *
         * 2. CHỨC NĂNG:
         *    - Thống kê tổng quan tự động
         *    - Thống kê theo lớp (người dùng chọn)
         *    - Thống kê theo trạng thái tự động
         *    - Làm mới dữ liệu
         *
         * 3. BLL USAGE:
         *    - Sử dụng ChucNangThongKeSV
         *    - DemTheoGioiTinh()
         *    - DemTheoLop()
         *    - DemTheoTrangThai()
         *    - LayThongKeTongQuan()
         *
         * 4. CODE ORGANIZATION:
         *    - Constructor: Khởi tạo và load
         *    - KhoiTaoComboBoxLop(): Setup ComboBox
         *    - LoadThongKe(): Load tất cả thống kê
         *    - Event handlers: Xử lý user interaction
         *
         * 5. UX IMPROVEMENTS:
         *    - Auto-load thống kê khi mở form
         *    - Thông báo rõ ràng
         *    - Button làm mới
         *    - Center form
         *
         * ==================== END TÓM TẮT ====================
         */
    }
}
