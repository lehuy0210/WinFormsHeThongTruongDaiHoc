using He_Thong_Truong_Dai_Hoc.Doi_Tuong_Trao_Doi_Du_Lieu__Data_Transfer_Object___DTO_;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Lop_Nghiep_Vu_XetThiDua;
using WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsHeThongTruongDaiHoc.Form_Xet_Thi_Dua
{
    // ==================== FORM QUẢN LÝ XÉT THI ĐUA ====================
    // 📚 Đánh giá thi đua cho sinh viên và giảng viên
    // 👨‍🎓 SINH VIÊN: Điểm rèn luyện (Học tập, Hoạt động, Công dân, Cộng đồng)
    // 👨‍🏫 GIẢNG VIÊN: Đánh giá giảng dạy (Chuyên môn, Phương pháp, Thái độ, Nghiên cứu)

    public partial class FormQuanLyXetThiDua : Form
    {
        private QuanLyXetThiDua quanLy;
        private ChucNangThemThongTinXetThiDua chucNangThem;
        private ChucNangXoaThongTinXetThiDua chucNangXoa;
        private ChucNangSuaThongTinXetThiDua chucNangSua;
        private ChucNangTimKiemThongTinXetThiDua chucNangTimKiem;
        private ChucNangSapXepThongTinXetThiDua chucNangSapXep;
        private ChucNangThongKeThongTinXetThiDua chucNangThongKe;

        private DataGridView dataGridView;
        private Button btnThem, btnXoa, btnSua, btnTimKiem, btnLamMoi, btnThongKe;
        private Button btnXuatExcel, btnXuatWord, btnXuatBieuDo;
        private TextBox txtTimKiem;
        private ComboBox cboLoaiDoiTuong, cboKhoa, cboXepLoai;
        private Label lblTimKiem, lblLoaiDoiTuong, lblKhoa, lblXepLoai;

        public FormQuanLyXetThiDua()
        {
            InitializeComponent();

            quanLy = new QuanLyXetThiDua();
            chucNangThem = new ChucNangThemThongTinXetThiDua();
            chucNangXoa = new ChucNangXoaThongTinXetThiDua();
            chucNangSua = new ChucNangSuaThongTinXetThiDua();
            chucNangTimKiem = new ChucNangTimKiemThongTinXetThiDua();
            chucNangSapXep = new ChucNangSapXepThongTinXetThiDua();
            chucNangThongKe = new ChucNangThongKeThongTinXetThiDua();

            LoadDuLieuMau();
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            try
            {
                List<ThongTinXetThiDua> danhSach = quanLy.LayDanhSachXetThiDua();
                dataGridView.DataSource = null;
                dataGridView.DataSource = danhSach;

                if (dataGridView.Columns.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["LoaiDoiTuong"].HeaderText = "Loại";
                    dataGridView.Columns["MaDoiTuong"].HeaderText = "Mã";
                    dataGridView.Columns["HoTen"].HeaderText = "Họ tên";
                    dataGridView.Columns["Khoa"].HeaderText = "Khoa";
                    dataGridView.Columns["HocKy"].HeaderText = "Học kỳ";

                    // Ẩn các cột điểm chi tiết
                    dataGridView.Columns["DiemYThucHocTap"].Visible = false;
                    dataGridView.Columns["DiemThamGiaHoatDong"].Visible = false;
                    dataGridView.Columns["DiemYThucCongDan"].Visible = false;
                    dataGridView.Columns["DiemQuanHeCongDong"].Visible = false;
                    dataGridView.Columns["SoLanViPham"].Visible = false;
                    dataGridView.Columns["DiemNangLucChuyenMon"].Visible = false;
                    dataGridView.Columns["DiemPhuongPhapGiangDay"].Visible = false;
                    dataGridView.Columns["DiemThaiDoVoiSinhVien"].Visible = false;
                    dataGridView.Columns["DiemNghienCuuKhoaHoc"].Visible = false;

                    dataGridView.Columns["TongDiem"].HeaderText = "Tổng điểm";
                    dataGridView.Columns["XepLoaiThiDua"].HeaderText = "Xếp loại";
                    dataGridView.Columns["DanhHieuThiDua"].HeaderText = "Danh hiệu";
                    dataGridView.Columns["NgayDanhGia"].HeaderText = "Ngày đánh giá";
                    dataGridView.Columns["NguoiDanhGia"].HeaderText = "Người đánh giá";
                    dataGridView.Columns["GhiChu"].HeaderText = "Ghi chú";

                    // Highlight rows theo xếp loại
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["XepLoaiThiDua"].Value != null)
                        {
                            string xepLoai = row.Cells["XepLoaiThiDua"].Value.ToString();
                            if (xepLoai == "Xuất sắc")
                                row.DefaultCellStyle.BackColor = Color.LightGreen;
                            else if (xepLoai == "Tốt")
                                row.DefaultCellStyle.BackColor = Color.LightBlue;
                            else if (xepLoai == "Khá")
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                            else if (xepLoai == "Yếu")
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
                // Demo: Thêm đánh giá mẫu
                ThongTinXetThiDua dgMoi = new ThongTinXetThiDua
                {
                    LoaiDoiTuong = "Sinh viên",
                    MaDoiTuong = "SV2024" + (quanLy.LaySoLuongDanhGia() + 1).ToString("D3"),
                    HoTen = "Nguyễn Văn Test",
                    Khoa = "Khoa CNTT",
                    HocKy = "HK1 2023-2024",
                    DiemYThucHocTap = 18,
                    DiemThamGiaHoatDong = 25,
                    DiemYThucCongDan = 17,
                    DiemQuanHeCongDong = 18,
                    SoLanViPham = 0,
                    NguoiDanhGia = "Cố vấn học tập"
                };

                bool ketQua = chucNangThem.ThemXetThiDua(quanLy.LayDanhSachXetThiDua(), dgMoi);

                if (ketQua)
                {
                    MessageBox.Show($"Thêm đánh giá thi đua thành công!\n\n" +
                        $"Họ tên: {dgMoi.HoTen}\n" +
                        $"Tổng điểm: {dgMoi.TongDiem}/100\n" +
                        $"Xếp loại: {dgMoi.XepLoaiThiDua}\n" +
                        $"Danh hiệu: {dgMoi.DanhHieuThiDua}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Đã tồn tại đánh giá trong học kỳ này.",
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
                    MessageBox.Show("Vui lòng chọn đánh giá cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ma = dataGridView.SelectedRows[0].Cells["MaDoiTuong"].Value.ToString();
                string hocKy = dataGridView.SelectedRows[0].Cells["HocKy"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa đánh giá thi đua của {ma}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool ketQua = chucNangXoa.XoaXetThiDua(quanLy.LayDanhSachXetThiDua(), ma, hocKy);
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
                    MessageBox.Show("Vui lòng chọn đánh giá cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ma = dataGridView.SelectedRows[0].Cells["MaDoiTuong"].Value.ToString();
                string hocKy = dataGridView.SelectedRows[0].Cells["HocKy"].Value.ToString();
                string loai = dataGridView.SelectedRows[0].Cells["LoaiDoiTuong"].Value.ToString();

                // Demo: Cập nhật điểm
                ThongTinXetThiDua dgMoi = new ThongTinXetThiDua
                {
                    LoaiDoiTuong = loai,
                    MaDoiTuong = ma,
                    HoTen = dataGridView.SelectedRows[0].Cells["HoTen"].Value.ToString(),
                    Khoa = dataGridView.SelectedRows[0].Cells["Khoa"].Value.ToString(),
                    HocKy = hocKy
                };

                if (loai == "Sinh viên")
                {
                    dgMoi.DiemYThucHocTap = 19;
                    dgMoi.DiemThamGiaHoatDong = 28;
                    dgMoi.DiemYThucCongDan = 18;
                    dgMoi.DiemQuanHeCongDong = 19;
                    dgMoi.SoLanViPham = 0;
                }
                else
                {
                    dgMoi.DiemNangLucChuyenMon = 28;
                    dgMoi.DiemPhuongPhapGiangDay = 27;
                    dgMoi.DiemThaiDoVoiSinhVien = 19;
                    dgMoi.DiemNghienCuuKhoaHoc = 18;
                }

                dgMoi.NguoiDanhGia = "Trưởng khoa";

                bool ketQua = chucNangSua.SuaThongTinXetThiDua(quanLy.LayDanhSachXetThiDua(), ma, hocKy, dgMoi);
                if (ketQua)
                {
                    MessageBox.Show($"Cập nhật thành công!\n\nTổng điểm: {dgMoi.TongDiem}\nXếp loại: {dgMoi.XepLoaiThiDua}",
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
                List<ThongTinXetThiDua> ketQua = quanLy.LayDanhSachXetThiDua();

                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                    ketQua = chucNangTimKiem.TimTheoMaDoiTuong(ketQua, txtTimKiem.Text);

                if (cboLoaiDoiTuong.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimTheoLoaiDoiTuong(ketQua, cboLoaiDoiTuong.SelectedItem.ToString());

                if (cboKhoa.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimTheoKhoa(ketQua, cboKhoa.SelectedItem.ToString());

                if (cboXepLoai.SelectedIndex > 0)
                    ketQua = chucNangTimKiem.TimTheoXepLoai(ketQua, cboXepLoai.SelectedItem.ToString());

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
            cboLoaiDoiTuong.SelectedIndex = 0;
            cboKhoa.SelectedIndex = 0;
            cboXepLoai.SelectedIndex = 0;
            HienThiDanhSach();
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinXetThiDua> danhSach = quanLy.LayDanhSachXetThiDua();

                Dictionary<string, int> thongKeXepLoai = chucNangThongKe.ThongKeTheoXepLoai(danhSach);
                Dictionary<string, int> thongKeLoai = chucNangThongKe.ThongKeTheoLoaiDoiTuong(danhSach);
                double diemTB = chucNangThongKe.TinhTrungBinhDiemChung(danhSach);

                string thongBao = "===== THỐNG KÊ XÉT THI ĐUA =====\n\n";
                thongBao += $"Tổng số đánh giá: {danhSach.Count}\n";
                thongBao += $"Điểm trung bình: {diemTB:F2}/100\n\n";

                thongBao += "THEO LOẠI ĐỐI TƯỢNG:\n";
                foreach (var item in thongKeLoai)
                    thongBao += $"- {item.Key}: {item.Value} người\n";

                thongBao += "\nTHEO XẾP LOẠI:\n";
                foreach (var item in thongKeXepLoai)
                    thongBao += $"- {item.Key}: {item.Value} người\n";

                MessageBox.Show(thongBao, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EXPORT FUNCTIONALITY ====================

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Xuất dữ liệu sang CSV (Excel)",
                    FileName = $"XetThiDua_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ChucNangXuatCSV xuatCSV = new ChucNangXuatCSV();
                    bool ketQua = xuatCSV.XuatDanhSachXetThiDua(
                        quanLy.LayDanhSachXetThiDua(),
                        saveDialog.FileName);

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất file CSV thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nFile có thể mở bằng Microsoft Excel.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{saveDialog.FileName}\"");
                    }
                    else
                    {
                        MessageBox.Show("Xuất file thất bại! Không có dữ liệu để xuất.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatWord_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Rich Text Format (*.rtf)|*.rtf",
                    Title = "Xuất báo cáo sang Word",
                    FileName = $"BaoCaoXetThiDua_{DateTime.Now:yyyyMMdd_HHmmss}.rtf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    List<ThongTinXetThiDua> danhSach = quanLy.LayDanhSachXetThiDua();
                    Dictionary<string, int> thongKeXepLoai = chucNangThongKe.ThongKeTheoXepLoai(danhSach);
                    Dictionary<string, int> thongKeLoai = chucNangThongKe.ThongKeTheoLoaiDoiTuong(danhSach);
                    double diemTB = chucNangThongKe.TinhTrungBinhDiemChung(danhSach);

                    ChucNangXuatRTF xuatRTF = new ChucNangXuatRTF();
                    bool ketQua = xuatRTF.XuatBaoCaoXetThiDua(
                        danhSach,
                        thongKeXepLoai,
                        thongKeLoai,
                        diemTB,
                        saveDialog.FileName);

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất file RTF thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nFile có thể mở bằng Microsoft Word.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{saveDialog.FileName}\"");
                    }
                    else
                    {
                        MessageBox.Show("Xuất file thất bại! Không có dữ liệu để xuất.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất RTF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXuatBieuDo_Click(object sender, EventArgs e)
        {
            try
            {
                List<ThongTinXetThiDua> danhSach = quanLy.LayDanhSachXetThiDua();

                if (danhSach.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất biểu đồ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "HTML files (*.html)|*.html",
                    Title = "Xuất biểu đồ thống kê",
                    FileName = $"BieuDoXetThiDua_{DateTime.Now:yyyyMMdd_HHmmss}.html"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Dictionary<string, int> thongKe = chucNangThongKe.ThongKeTheoXepLoai(danhSach);

                    // Convert Dictionary<string, int> to Dictionary<string, double>
                    Dictionary<string, double> data = new Dictionary<string, double>();
                    foreach (var item in thongKe)
                    {
                        data[item.Key] = item.Value;
                    }

                    ChucNangXuatBieuDo xuatBieuDo = new ChucNangXuatBieuDo();
                    bool ketQua = xuatBieuDo.TaoBieuDoCot(
                        data,
                        saveDialog.FileName,
                        "THỐNG KÊ XÉT THI ĐUA THEO XẾP LOẠI");

                    if (ketQua)
                    {
                        MessageBox.Show($"Xuất biểu đồ thành công!\n\nĐường dẫn: {saveDialog.FileName}\n\nFile HTML sẽ được mở trong trình duyệt.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("Xuất biểu đồ thất bại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuMau()
        {
            List<ThongTinXetThiDua> danhSach = quanLy.LayDanhSachXetThiDua();

            // Sinh viên 1: Xuất sắc
            chucNangThem.ThemXetThiDua(danhSach, new ThongTinXetThiDua
            {
                LoaiDoiTuong = "Sinh viên",
                MaDoiTuong = "SV2024001",
                HoTen = "Nguyễn Văn An",
                Khoa = "Khoa CNTT",
                HocKy = "HK1 2023-2024",
                DiemYThucHocTap = 19,
                DiemThamGiaHoatDong = 29,
                DiemYThucCongDan = 19,
                DiemQuanHeCongDong = 19,
                SoLanViPham = 0,
                NguoiDanhGia = "Cố vấn học tập"
            });

            // Sinh viên 2: Tốt
            chucNangThem.ThemXetThiDua(danhSach, new ThongTinXetThiDua
            {
                LoaiDoiTuong = "Sinh viên",
                MaDoiTuong = "SV2024002",
                HoTen = "Trần Thị Bình",
                Khoa = "Khoa Kinh tế",
                HocKy = "HK1 2023-2024",
                DiemYThucHocTap = 18,
                DiemThamGiaHoatDong = 26,
                DiemYThucCongDan = 18,
                DiemQuanHeCongDong = 17,
                SoLanViPham = 0,
                NguoiDanhGia = "Cố vấn học tập"
            });

            // Sinh viên 3: Khá (có vi phạm)
            chucNangThem.ThemXetThiDua(danhSach, new ThongTinXetThiDua
            {
                LoaiDoiTuong = "Sinh viên",
                MaDoiTuong = "SV2024003",
                HoTen = "Lê Văn Cường",
                Khoa = "Khoa CNTT",
                HocKy = "HK1 2023-2024",
                DiemYThucHocTap = 16,
                DiemThamGiaHoatDong = 24,
                DiemYThucCongDan = 16,
                DiemQuanHeCongDong = 15,
                SoLanViPham = 1, // -10 điểm
                NguoiDanhGia = "Cố vấn học tập",
                GhiChu = "Vi phạm 1 lần: Đi học muộn"
            });

            // Giảng viên 1: Xuất sắc
            chucNangThem.ThemXetThiDua(danhSach, new ThongTinXetThiDua
            {
                LoaiDoiTuong = "Giảng viên",
                MaDoiTuong = "GV001",
                HoTen = "TS. Phạm Thị Dung",
                Khoa = "Khoa CNTT",
                HocKy = "Năm học 2023-2024",
                DiemNangLucChuyenMon = 28,
                DiemPhuongPhapGiangDay = 28,
                DiemThaiDoVoiSinhVien = 19,
                DiemNghienCuuKhoaHoc = 18,
                NguoiDanhGia = "Trưởng khoa",
                GhiChu = "Công bố 2 bài báo ISI"
            });

            // Giảng viên 2: Tốt
            chucNangThem.ThemXetThiDua(danhSach, new ThongTinXetThiDua
            {
                LoaiDoiTuong = "Giảng viên",
                MaDoiTuong = "GV002",
                HoTen = "ThS. Hoàng Văn Em",
                Khoa = "Khoa Kinh tế",
                HocKy = "Năm học 2023-2024",
                DiemNangLucChuyenMon = 26,
                DiemPhuongPhapGiangDay = 25,
                DiemThaiDoVoiSinhVien = 18,
                DiemNghienCuuKhoaHoc = 15,
                NguoiDanhGia = "Trưởng khoa"
            });
        }
    }
}
