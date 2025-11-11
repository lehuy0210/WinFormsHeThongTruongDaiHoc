using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_QuanLyHoSo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Ho_So
{
    // ==================== FORM QUẢN LÝ HỒ SƠ ====================
    // N-Layer Architecture: UI Layer
    // Quản lý hồ sơ Tuyển sinh & Nhân sự
    public partial class FormQuanLyHoSo : Form
    {
        // DTO & BLL
        private QuanLyHoSo quanLy;
        private ChucNangThemThongTinHoSo chucNangThem;
        private ChucNangXoaThongTinHoSo chucNangXoa;
        private ChucNangSuaThongTinHoSo chucNangSua;
        private ChucNangTimKiemThongTinHoSo chucNangTimKiem;
        private ChucNangSapXepThongTinHoSo chucNangSapXep;
        private ChucNangThongKeThongTinHoSo chucNangThongKe;

        // Controls
        private DataGridView dataGridView;
        private Button btnThem, btnXoa, btnSua, btnTimKiem, btnLamMoi, btnThongKe;
        private TextBox txtTimKiem;
        private ComboBox cboLoaiHoSo, cboTrangThai;
        private Label lblTongSo;

        public FormQuanLyHoSo()
        {
            InitializeComponent();
            
            // Khởi tạo DTO & BLL
            quanLy = new QuanLyHoSo();
            chucNangThem = new ChucNangThemThongTinHoSo();
            chucNangXoa = new ChucNangXoaThongTinHoSo();
            chucNangSua = new ChucNangSuaThongTinHoSo();
            chucNangTimKiem = new ChucNangTimKiemThongTinHoSo();
            chucNangSapXep = new ChucNangSapXepThongTinHoSo();
            chucNangThongKe = new ChucNangThongKeThongTinHoSo();

            // Thiết lập UI
            ThietLapGiaoDien();
            HienThiDanhSach();
        }

        private void ThietLapGiaoDien()
        {
            this.Text = "Quản Lý Hồ Sơ - Tuyển Sinh & Nhân Sự";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView
            dataGridView = new DataGridView
            {
                Location = new Point(20, 100),
                Size = new Size(1150, 450),
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Buttons
            btnThem = new Button { Text = "Thêm Hồ Sơ", Location = new Point(20, 20), Size = new Size(120, 35) };
            btnXoa = new Button { Text = "Xóa Hồ Sơ", Location = new Point(150, 20), Size = new Size(120, 35) };
            btnSua = new Button { Text = "Sửa Hồ Sơ", Location = new Point(280, 20), Size = new Size(120, 35) };
            btnLamMoi = new Button { Text = "Làm Mới", Location = new Point(410, 20), Size = new Size(120, 35) };
            btnThongKe = new Button { Text = "Thống Kê", Location = new Point(540, 20), Size = new Size(120, 35) };

            // Search controls
            txtTimKiem = new TextBox { Location = new Point(20, 65), Size = new Size(200, 25) };
            btnTimKiem = new Button { Text = "Tìm Kiếm", Location = new Point(230, 63), Size = new Size(100, 30) };
            
            cboLoaiHoSo = new ComboBox { Location = new Point(340, 65), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiHoSo.Items.AddRange(new object[] { "Tất cả", "Tuyển sinh", "Nhân sự", "Khen thưởng", "Kỷ luật" });
            cboLoaiHoSo.SelectedIndex = 0;

            cboTrangThai = new ComboBox { Location = new Point(500, 65), Size = new Size(150, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "Chờ xử lý", "Đầy đủ", "Thiếu giấy tờ", "Đã duyệt", "Từ chối" });
            cboTrangThai.SelectedIndex = 0;

            lblTongSo = new Label { Location = new Point(20, 560), Size = new Size(300, 25), Text = "Tổng số: 0 hồ sơ" };

            // Events
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnThongKe.Click += BtnThongKe_Click;

            // Add controls
            this.Controls.AddRange(new Control[] { 
                dataGridView, btnThem, btnXoa, btnSua, btnLamMoi, btnThongKe,
                txtTimKiem, btnTimKiem, cboLoaiHoSo, cboTrangThai, lblTongSo
            });
        }

        private void HienThiDanhSach()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = quanLy.LayDanhSachHoSo();
            lblTongSo.Text = $"Tổng số: {quanLy.LaySoLuongHoSo()} hồ sơ";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ThongTinHoSo hoSoMoi = new ThongTinHoSo
                {
                    MaHoSo = chucNangThem.TaoMaHoSoTuDong(quanLy.LayDanhSachHoSo(), "TS"),
                    LoaiHoSo = "Tuyển sinh",
                    MaDoiTuong = "TS001",
                    TenDoiTuong = "Nguyễn Văn A",
                    NgayNop = DateTime.Now,
                    TrangThai = "Chờ xử lý",
                    DanhSachGiayTo = "CMND;Bằng TN;Giấy khai sinh",
                    NguoiXuLy = "Admin",
                    NgayXuLy = DateTime.Now
                };

                if (chucNangThem.ThemHoSo(quanLy.LayDanhSachHoSo(), hoSoMoi))
                {
                    MessageBox.Show("Thêm hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Thêm hồ sơ thất bại! Mã đã tồn tại hoặc dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ThongTinHoSo hoSo = (ThongTinHoSo)dataGridView.SelectedRows[0].DataBoundItem;
                
                if (MessageBox.Show($"Bạn có chắc muốn xóa hồ sơ {hoSo.MaHoSo}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (chucNangXoa.XoaHoSo(quanLy.LayDanhSachHoSo(), hoSo.MaHoSo))
                    {
                        MessageBox.Show("Xóa hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hồ sơ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ThongTinHoSo hoSoCu = (ThongTinHoSo)dataGridView.SelectedRows[0].DataBoundItem;
                ThongTinHoSo hoSoMoi = new ThongTinHoSo
                {
                    MaHoSo = hoSoCu.MaHoSo,
                    LoaiHoSo = hoSoCu.LoaiHoSo,
                    MaDoiTuong = hoSoCu.MaDoiTuong,
                    TenDoiTuong = hoSoCu.TenDoiTuong,
                    NgayNop = hoSoCu.NgayNop,
                    TrangThai = "Đã duyệt", // Example: Update status
                    DanhSachGiayTo = hoSoCu.DanhSachGiayTo,
                    NguoiXuLy = "Admin",
                    NgayXuLy = DateTime.Now,
                    KetQuaXuLy = "Đạt"
                };

                if (chucNangSua.SuaHoSo(quanLy.LayDanhSachHoSo(), hoSoCu.MaHoSo, hoSoMoi))
                {
                    MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Cập nhật hồ sơ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinHoSo> ketQua = new List<ThongTinHoSo>();

                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    ketQua = chucNangTimKiem.TimKiemTheoMa(quanLy.LayDanhSachHoSo(), txtTimKiem.Text);
                }
                else if (cboLoaiHoSo.SelectedIndex > 0)
                {
                    ketQua = chucNangTimKiem.TimKiemTheoLoai(quanLy.LayDanhSachHoSo(), cboLoaiHoSo.Text);
                }
                else if (cboTrangThai.SelectedIndex > 0)
                {
                    ketQua = chucNangTimKiem.TimKiemTheoTrangThai(quanLy.LayDanhSachHoSo(), cboTrangThai.Text);
                }
                else
                {
                    ketQua = quanLy.LayDanhSachHoSo();
                }

                dataGridView.DataSource = null;
                dataGridView.DataSource = ketQua;
                lblTongSo.Text = $"Tìm thấy: {ketQua.Count} hồ sơ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLoaiHoSo.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            HienThiDanhSach();
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                var thongKeLoai = chucNangThongKe.ThongKeTheoLoai(quanLy.LayDanhSachHoSo());
                var thongKeTrangThai = chucNangThongKe.ThongKeTheoTrangThai(quanLy.LayDanhSachHoSo());

                string message = "=== THỐNG KÊ HỒ SƠ ===\n\n";
                message += "Theo Loại:\n";
                foreach (var item in thongKeLoai)
                    message += $"  - {item.Key}: {item.Value} hồ sơ\n";
                
                message += "\nTheo Trạng Thái:\n";
                foreach (var item in thongKeTrangThai)
                    message += $"  - {item.Key}: {item.Value} hồ sơ\n";

                MessageBox.Show(message, "Thống Kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
