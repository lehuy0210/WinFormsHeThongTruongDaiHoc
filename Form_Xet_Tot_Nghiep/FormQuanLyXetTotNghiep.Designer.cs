using System.Drawing;
using System.Windows.Forms;

namespace WinFormsHeThongTruongDaiHoc.Form_Xet_Tot_Nghiep
{
    partial class FormQuanLyXetTotNghiep
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.Text = "Quản lý Xét tốt nghiệp";
            this.Size = new Size(1400, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // DataGridView
            dataGridView = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1350, 500),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };

            // Labels
            lblTimKiem = new Label
            {
                Text = "Tìm kiếm (Mã SV):",
                Location = new Point(20, 20),
                Size = new Size(120, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblKhoa = new Label
            {
                Text = "Khoa:",
                Location = new Point(20, 60),
                Size = new Size(120, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblKetQua = new Label
            {
                Text = "Kết quả:",
                Location = new Point(400, 60),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblXepLoai = new Label
            {
                Text = "Xếp loại:",
                Location = new Point(750, 60),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // TextBox
            txtTimKiem = new TextBox
            {
                Location = new Point(150, 20),
                Size = new Size(200, 23),
                PlaceholderText = "Nhập mã sinh viên..."
            };

            // ComboBox Khoa
            cboKhoa = new ComboBox
            {
                Location = new Point(150, 60),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboKhoa.Items.AddRange(new object[] {
                "-- Tất cả --",
                "Khoa CNTT",
                "Khoa Kinh tế",
                "Khoa Ngoại ngữ",
                "Khoa Luật",
                "Khoa Y"
            });
            cboKhoa.SelectedIndex = 0;

            // ComboBox Kết quả
            cboKetQua = new ComboBox
            {
                Location = new Point(510, 60),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboKetQua.Items.AddRange(new object[] {
                "-- Tất cả --",
                "Đủ điều kiện",
                "Tốt nghiệp có điều kiện",
                "Không đủ điều kiện"
            });
            cboKetQua.SelectedIndex = 0;

            // ComboBox Xếp loại
            cboXepLoai = new ComboBox
            {
                Location = new Point(860, 60),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboXepLoai.Items.AddRange(new object[] {
                "-- Tất cả --",
                "Xuất sắc",
                "Giỏi",
                "Khá",
                "Trung bình"
            });
            cboXepLoai.SelectedIndex = 0;

            // Buttons
            btnThem = new Button
            {
                Text = "Thêm",
                Location = new Point(20, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThem.Click += BtnThem_Click;

            btnXoa = new Button
            {
                Text = "Xóa",
                Location = new Point(140, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnXoa.Click += BtnXoa_Click;

            btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(260, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSua.Click += BtnSua_Click;

            btnTimKiem = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(380, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += BtnTimKiem_Click;

            btnLamMoi = new Button
            {
                Text = "Làm mới",
                Location = new Point(500, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLamMoi.Click += BtnLamMoi_Click;

            btnThongKe = new Button
            {
                Text = "Thống kê",
                Location = new Point(620, 640),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThongKe.Click += BtnThongKe_Click;

            // Add controls to form
            this.Controls.Add(dataGridView);
            this.Controls.Add(lblTimKiem);
            this.Controls.Add(lblKhoa);
            this.Controls.Add(lblKetQua);
            this.Controls.Add(lblXepLoai);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(cboKhoa);
            this.Controls.Add(cboKetQua);
            this.Controls.Add(cboXepLoai);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnTimKiem);
            this.Controls.Add(btnLamMoi);
            this.Controls.Add(btnThongKe);
        }

        #endregion
    }
}
