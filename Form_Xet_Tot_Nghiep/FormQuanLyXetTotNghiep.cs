using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetTotNghiep;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsHeThongTruongDaiHoc.Form_Xet_Tot_Nghiep
{
    // ==================== FORM QUẢN LÝ XÉT TỐT NGHIỆP ====================
    // 📚 Tự động đánh giá điều kiện tốt nghiệp của sinh viên
    // ✅ Kiểm tra: GPA, Tín chỉ, Điểm rèn luyện, Môn nợ, TOEIC, Khóa luận
    // 🏆 Phân loại: Xuất sắc, Giỏi, Khá, Trung bình

    public partial class FormQuanLyXetTotNghiep : Form
    {
        private QuanLyXetTotNghiep quanLy;
        private ChucNangThemThongTinXetTotNghiep chucNangThem;
        private ChucNangXoaThongTinXetTotNghiep chucNangXoa;
        private ChucNangSuaThongTinXetTotNghiep chucNangSua;
        private ChucNangTimKiemThongTinXetTotNghiep chucNangTimKiem;
        private ChucNangSapXepThongTinXetTotNghiep chucNangSapXep;
        private ChucNangThongKeThongTinXetTotNghiep chucNangThongKe;

        private DataGridView dataGridView;
        private Button btnThem, btnXoa, btnSua, btnTimKiem, btnLamMoi, btnThongKe;
        private Button btnXuatExcel, btnXuatWord, btnXuatBieuDo;
        private TextBox txtTimKiem;
        private ComboBox cboKhoa, cboKetQua, cboXepLoai;
        private Label lblTimKiem, lblKhoa, lblKetQua, lblXepLoai;

        public FormQuanLyXetTotNghiep()
        {
            InitializeComponent();

            quanLy = new QuanLyXetTotNghiep();
            chucNangThem = new ChucNangThemThongTinXetTotNghiep();
            chucNangXoa = new ChucNangXoaThongTinXetTotNghiep();
            chucNangSua = new ChucNangSuaThongTinXetTotNghiep();
            chucNangTimKiem = new ChucNangTimKiemThongTinXetTotNghiep();
            chucNangSapXep = new ChucNangSapXepThongTinXetTotNghiep();
            chucNangThongKe = new ChucNangThongKeThongTinXetTotNghiep();

            LoadDuLieuMau();
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            try
            {
                List<ThongTinXetTotNghiep> danhSach = quanLy.LayDanhSachXetTotNghiep();
                dataGridView.DataSource = null;
                dataGridView.DataSource = danhSach;

                if (dataGridView.Columns.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["MaSinhVien"].HeaderText = "Mã SV";
                    dataGridView.Columns["HoTen"].HeaderText = "Họ tên";
                    dataGridView.Columns["Khoa"].HeaderText = "Khoa";
                    dataGridView.Columns["Nganh"].HeaderText = "Ngành";
                    dataGridView.Columns["KhoaHoc"].HeaderText = "Khóa";
                    dataGridView.Columns["TongTinChiTichLuy"].HeaderText = "Tín chỉ";
                    dataGridView.Columns["DiemTrungBinhTichLuy"].HeaderText = "GPA";
                    dataGridView.Columns["DiemRenLuyen"].HeaderText = "ĐRL";
                    dataGridView.Columns["SoMonNo"].HeaderText = "Môn nợ";
                    dataGridView.Columns["DiemNgoaiNgu"].HeaderText = "TOEIC";
                    dataGridView.Columns["TrangThaiKhoaLuan"].HeaderText = "Khóa luận";
                    dataGridView.Columns["DieuKienTotNghiep"].HeaderText = "Điều kiện";
                    dataGridView.Columns["KetQuaXet"].HeaderText = "Kết quả";
                    dataGridView.Columns["XepLoaiTotNghiep"].HeaderText = "Xếp loại";
                    dataGridView.Columns["NgayXet"].HeaderText = "Ngày xét";
                    dataGridView.Columns["HocKyTotNghiep"].HeaderText = "Học kỳ TN";
                    dataGridView.Columns["GhiChu"].HeaderText = "Ghi chú";

                    // Highlight rows theo kết quả
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["KetQuaXet"].Value != null)
                        {
                            string ketQua = row.Cells["KetQuaXet"].Value.ToString();
                            if (ketQua == "Đủ điều kiện")
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                            else if (ketQua == "Tốt nghiệp có điều kiện")
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                            else if (ketQua == "Không đủ điều kiện")
                                row.DefaultCellStyle.BackColor = Color.LightCoral;
                        }
                    }

                    dataGridView.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Demo: Tạo sinh viên mẫu để test
                ThongTinXetTotNghiep svMoi = new ThongTinXetTotNghiep
                {
                    MaSinhVien = "SV2024" + (quanLy.LaySoLuongSinhVien() + 1).ToString("D3"),
                    HoTen = "Nguyễn Văn Test",
                    Khoa = "Khoa CNTT",
                    Nganh = "Công nghệ thông tin",
                    KhoaHoc = "2020-2024",
                    TongTinChiTichLuy = 128,
                    DiemTrungBinhTichLuy = 3.2,
                    DiemRenLuyen = 80,
                    SoMonNo = 0,
                    DiemNgoaiNgu = 500,
                    TrangThaiKhoaLuan = "Đã hoàn thành",
                    HocKyTotNghiep = "HK2 2023-2024",
                    GhiChu = ""
                };

                bool ketQua = chucNangThem.ThemKetQuaXet(quanLy.LayDanhSachXetTotNghiep(), svMoi);

                if (ketQua)
                {
                    MessageBox.Show($"Thêm kết quả xét tốt nghiệp thành công!\n\n" +
                        $"Sinh viên: {svMoi.HoTen}\n" +
                        $"Kết quả: {svMoi.KetQuaXet}\n" +
                        $"Xếp loại: {svMoi.XepLoaiTotNghiep}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Sinh viên đã được xét trong học kỳ này.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSV = dataGridView.SelectedRows[0].Cells["MaSinhVien"].Value.ToString();
                string hocKy = dataGridView.SelectedRows[0].Cells["HocKyTotNghiep"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa kết quả xét tốt nghiệp của sinh viên {maSV}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool ketQua = chucNangXoa.XoaKetQuaXet(quanLy.LayDanhSachXetTotNghiep(), maSV, hocKy);
                    if (ketQua)
                    {
                        MessageBox.Show("Xóa thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
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
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maSV = dataGridView.SelectedRows[0].Cells["MaSinhVien"].Value.ToString();
                string hocKy = dataGridView.SelectedRows[0].Cells["HocKyTotNghiep"].Value.ToString();

                // Demo: Cập nhật điểm
                ThongTinXetTotNghiep svMoi = new ThongTinXetTotNghiep
                {
                    MaSinhVien = maSV,
                    HoTen = dataGridView.SelectedRows[0].Cells["HoTen"].Value.ToString(),
                    Khoa = dataGridView.SelectedRows[0].Cells["Khoa"].Value.ToString(),
                    Nganh = dataGridView.SelectedRows[0].Cells["Nganh"].Value.ToString(),
                    KhoaHoc = dataGridView.SelectedRows[0].Cells["KhoaHoc"].Value.ToString(),
                    TongTinChiTichLuy = 130, // Cập nhật
                    DiemTrungBinhTichLuy = 3.5, // Cập nhật
                    DiemRenLuyen = 85,
                    SoMonNo = 0,
                    DiemNgoaiNgu = 550,
                    TrangThaiKhoaLuan = "Đã hoàn thành",
                    HocKyTotNghiep = hocKy
                };

                bool ketQua = chucNangSua.SuaKetQuaXet(quanLy.LayDanhSachXetTotNghiep(), maSV, hocKy, svMoi);
                if (ketQua)
                {
                    MessageBox.Show($"Cập nhật thành công!\n\nKết quả mới: {svMoi.KetQuaXet}\nXếp loại: {svMoi.XepLoaiTotNghiep}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
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
                List<ThongTinXetTotNghiep> ketQua = quanLy.LayDanhSachXetTotNghiep();

                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                    ketQua = chucNangTimKiem.TimKiemTheoMaSinhVien(ketQua, txtTimKiem.Text);

                if (cboKhoa.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimKiemTheoKhoa(ketQua, cboKhoa.SelectedItem.ToString());

                if (cboKetQua.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimKiemTheoKetQua(ketQua, cboKetQua.SelectedItem.ToString());

                if (cboXepLoai.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimKiemTheoXepLoai(ketQua, cboXepLoai.SelectedItem.ToString());

                dataGridView.DataSource = null;
                dataGridView.DataSource = ketQua;

                MessageBox.Show($"Tìm thấy {ketQua.Count} kết quả!", "Kết quả",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboKhoa.SelectedIndex = 0;
            cboKetQua.SelectedIndex = 0;
            cboXepLoai.SelectedIndex = 0;
            HienThiDanhSach();
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinXetTotNghiep> danhSach = quanLy.LayDanhSachXetTotNghiep();

                Dictionary<string, int> thongKeKetQua = chucNangThongKe.ThongKeTheoKetQua(danhSach);
                Dictionary<string, int> thongKeXepLoai = chucNangThongKe.ThongKeTheoXepLoai(danhSach);
                double tyLeTotNghiep = chucNangThongKe.TinhTyLeTotNghiep(danhSach);
                double gpaTrungBinh = chucNangThongKe.TinhGPATrungBinh(danhSach);

                string thongBao = "===== THỐNG KÊ XÉT TỐT NGHIỆP =====\n\n";
                thongBao += $"Tổng số sinh viên: {danhSach.Count}\n";
                thongBao += $"Tỷ lệ đủ điều kiện: {tyLeTotNghiep:F2}%\n";
                thongBao += $"GPA trung bình (sinh viên đủ ĐK): {gpaTrungBinh:F2}\n\n";

                thongBao += "THEO KẾT QUẢ:\n";
                foreach (var item in thongKeKetQua)
                    thongBao += $"- {item.Key}: {item.Value} SV\n";

                thongBao += "\nTHEO XẾP LOẠI:\n";
                foreach (var item in thongKeXepLoai)
                    thongBao += $"- {item.Key}: {item.Value} SV\n";

                MessageBox.Show(thongBao, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuMau()
        {
            List<ThongTinXetTotNghiep> danhSach = quanLy.LayDanhSachXetTotNghiep();

            // SV1: Đủ điều kiện - Xuất sắc
            chucNangThem.ThemKetQuaXet(danhSach, new ThongTinXetTotNghiep
            {
                MaSinhVien = "SV2024001",
                HoTen = "Nguyễn Văn An",
                Khoa = "Khoa CNTT",
                Nganh = "Công nghệ thông tin",
                KhoaHoc = "2020-2024",
                TongTinChiTichLuy = 128,
                DiemTrungBinhTichLuy = 3.75,
                DiemRenLuyen = 92,
                SoMonNo = 0,
                DiemNgoaiNgu = 650,
                TrangThaiKhoaLuan = "Đã hoàn thành",
                HocKyTotNghiep = "HK2 2023-2024",
                GhiChu = "Sinh viên xuất sắc"
            });

            // SV2: Đủ điều kiện - Giỏi
            chucNangThem.ThemKetQuaXet(danhSach, new ThongTinXetTotNghiep
            {
                MaSinhVien = "SV2024002",
                HoTen = "Trần Thị Bình",
                Khoa = "Khoa Kinh tế",
                Nganh = "Kế toán",
                KhoaHoc = "2020-2024",
                TongTinChiTichLuy = 125,
                DiemTrungBinhTichLuy = 3.35,
                DiemRenLuyen = 85,
                SoMonNo = 0,
                DiemNgoaiNgu = 500,
                TrangThaiKhoaLuan = "Đã hoàn thành",
                HocKyTotNghiep = "HK2 2023-2024"
            });

            // SV3: Tốt nghiệp có điều kiện (thiếu TOEIC)
            chucNangThem.ThemKetQuaXet(danhSach, new ThongTinXetTotNghiep
            {
                MaSinhVien = "SV2024003",
                HoTen = "Lê Văn Cường",
                Khoa = "Khoa CNTT",
                Nganh = "Hệ thống thông tin",
                KhoaHoc = "2020-2024",
                TongTinChiTichLuy = 122,
                DiemTrungBinhTichLuy = 2.85,
                DiemRenLuyen = 75,
                SoMonNo = 0,
                DiemNgoaiNgu = 380, // Thiếu TOEIC
                TrangThaiKhoaLuan = "Đã hoàn thành",
                HocKyTotNghiep = "HK2 2023-2024"
            });

            // SV4: Không đủ điều kiện (còn môn nợ, GPA thấp)
            chucNangThem.ThemKetQuaXet(danhSach, new ThongTinXetTotNghiep
            {
                MaSinhVien = "SV2024004",
                HoTen = "Phạm Thị Dung",
                Khoa = "Khoa Ngoại ngữ",
                Nganh = "Tiếng Anh",
                KhoaHoc = "2020-2024",
                TongTinChiTichLuy = 118,
                DiemTrungBinhTichLuy = 1.95,
                DiemRenLuyen = 60,
                SoMonNo = 2,
                DiemNgoaiNgu = 600,
                TrangThaiKhoaLuan = "Đang thực hiện",
                HocKyTotNghiep = "HK2 2023-2024"
            });

            // SV5: Đủ điều kiện - Khá
            chucNangThem.ThemKetQuaXet(danhSach, new ThongTinXetTotNghiep
            {
                MaSinhVien = "SV2024005",
                HoTen = "Hoàng Văn Em",
                Khoa = "Khoa CNTT",
                Nganh = "An toàn thông tin",
                KhoaHoc = "2020-2024",
                TongTinChiTichLuy = 130,
                DiemTrungBinhTichLuy = 2.95,
                DiemRenLuyen = 78,
                SoMonNo = 0,
                DiemNgoaiNgu = 480,
                TrangThaiKhoaLuan = "Đã hoàn thành",
                HocKyTotNghiep = "HK2 2023-2024"
            });
        }

        // ==================== XUẤT BÁO CÁO ====================

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Xuất dữ liệu sang CSV (Excel)",
                    FileName = $"XetTotNghiep_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ChucNangXuatCSV xuatCSV = new ChucNangXuatCSV();
                    bool ketQua = xuatCSV.XuatDanhSachXetTotNghiep(
                        quanLy.LayDanhSachXetTotNghiep(),
                        saveDialog.FileName);

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất file thành công!\n\nĐường dẫn: {saveDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file sau khi xuất
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{saveDialog.FileName}\"");
                    }
                    else
                    {
                        MessageBox.Show("Xuất file thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatWord_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "RTF files (*.rtf)|*.rtf",
                    Title = "Xuất báo cáo sang Word (RTF)",
                    FileName = $"BaoCaoXetTotNghiep_{DateTime.Now:yyyyMMdd_HHmmss}.rtf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ChucNangXuatRTF xuatRTF = new ChucNangXuatRTF();
                    bool ketQua = xuatRTF.XuatBaoCaoXetTotNghiep(
                        quanLy.LayDanhSachXetTotNghiep(),
                        saveDialog.FileName);

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất báo cáo thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nCó thể mở bằng Microsoft Word.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{saveDialog.FileName}\"");
                    }
                    else
                    {
                        MessageBox.Show("Xuất báo cáo thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatBieuDo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "HTML files (*.html)|*.html",
                    Title = "Xuất biểu đồ thống kê",
                    FileName = $"BieuDoXetTotNghiep_{DateTime.Now:yyyyMMdd_HHmmss}.html"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    List<ThongTinXetTotNghiep> danhSach = quanLy.LayDanhSachXetTotNghiep();

                    // Thống kê theo xếp loại
                    Dictionary<string, int> thongKe = chucNangThongKe.ThongKeTheoXepLoai(danhSach);

                    // Chuyển sang Dictionary<string, double> để vẽ biểu đồ
                    Dictionary<string, double> data = new Dictionary<string, double>();
                    foreach (var item in thongKe)
                    {
                        data[item.Key] = item.Value;
                    }

                    ChucNangXuatBieuDo xuatBieuDo = new ChucNangXuatBieuDo();
                    bool ketQua = xuatBieuDo.TaoBieuDoCot(
                        data,
                        saveDialog.FileName,
                        "THỐNG KÊ XÉT TỐT NGHIỆP THEO XẾP LOẠI");

                    if (ketQua)
                    {
                        MessageBox.Show($"Tạo biểu đồ thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nMở file HTML bằng trình duyệt để xem.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file HTML trong trình duyệt
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("Tạo biểu đồ thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biểu đồ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
