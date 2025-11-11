using System.Drawing;
using System.Windows.Forms;

namespace WinFormsHeThongTruongDaiHoc.Form_Quan_Ly_Dao_Tao
{
    partial class FormQuanLyDaoTao
    {
        // ==================== REQUIRED DESIGNER VARIABLE ====================
        // Component container cho các controls
        private System.ComponentModel.IContainer components = null;

        // ==================== DISPOSE PATTERN ====================
        // 📚 KIẾN THỨC: IDisposable pattern - Giải phóng resources (memory, file handles, database connections)
        // 🔍 MỤC ĐÍCH:
        // - Giải phóng managed resources (objects)
        // - Giải phóng unmanaged resources (Windows handles, database connections)
        // - Ngăn memory leaks
        //
        // 📝 CÁCH HOẠT ĐỘNG:
        // - disposing = true: Được gọi từ Dispose() method (do developer gọi)
        // - disposing = false: Được gọi từ Finalizer/Destructor (do Garbage Collector gọi)
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Giải phóng tất cả components
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // ==================== INITIALIZE COMPONENTS ====================
        // 📚 KIẾN THỨC: Windows Forms Designer - Auto-generated code
        // ⚠️ LƯU Ý: KHÔNG SỬA CODE TRONG NÀY BẰNG TAY!
        // - Code này được Visual Studio Form Designer tự động tạo
        // - Sửa trực tiếp trong Designer GUI, không edit code
        // - Nếu sửa tay có thể gây lỗi Designer không load được
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ==================== FORM PROPERTIES ====================
            this.Text = "Quản lý Đào tạo";
            this.Size = new Size(1300, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // ==================== DATAGRIDVIEW ====================
            // 📚 KIẾN THỨC: DataGridView - Hiển thị dữ liệu dạng bảng (rows & columns)
            // 🔍 THUỘC TÍNH:
            // - Location: Vị trí (X, Y) trên Form
            // - Size: Kích thước (Width, Height)
            // - AllowUserToAddRows: Cho phép thêm row mới trực tiếp trong grid
            // - SelectionMode: FullRowSelect - Chọn cả row thay vì từng cell
            // - MultiSelect: false - Chỉ chọn 1 row tại 1 thời điểm
            dataGridView = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1250, 450),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };

            // ==================== LABELS ====================
            lblTimKiem = new Label
            {
                Text = "Tìm kiếm (Mã CT):",
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

            lblBacDaoTao = new Label
            {
                Text = "Bậc đào tạo:",
                Location = new Point(400, 60),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblTrangThai = new Label
            {
                Text = "Trạng thái:",
                Location = new Point(750, 60),
                Size = new Size(100, 23),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // ==================== TEXTBOX TÌM KIẾM ====================
            // 📚 KIẾN THỨC: TextBox - Nhập liệu text từ user
            txtTimKiem = new TextBox
            {
                Location = new Point(150, 20),
                Size = new Size(200, 23),
                PlaceholderText = "Nhập mã chương trình..."
            };

            // ==================== COMBOBOX KHOA ====================
            // 📚 KIẾN THỨC: ComboBox - Dropdown list cho user chọn
            // 🔍 THUỘC TÍNH:
            // - DropDownStyle: ComboBoxStyle.DropDownList - Chỉ cho chọn, không cho nhập tay
            // - Items: Danh sách các options
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
                "Khoa Y",
                "Khoa Luật",
                "Khoa Ngoại ngữ"
            });
            cboKhoa.SelectedIndex = 0;

            // ==================== COMBOBOX BẬC ĐÀO TẠO ====================
            cboBacDaoTao = new ComboBox
            {
                Location = new Point(510, 60),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboBacDaoTao.Items.AddRange(new object[] {
                "-- Tất cả --",
                "Cử nhân",
                "Thạc sĩ",
                "Tiến sĩ"
            });
            cboBacDaoTao.SelectedIndex = 0;

            // ==================== COMBOBOX TRẠNG THÁI ====================
            cboTrangThai = new ComboBox
            {
                Location = new Point(860, 60),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTrangThai.Items.AddRange(new object[] {
                "-- Tất cả --",
                "Đang áp dụng",
                "Ngừng tuyển"
            });
            cboTrangThai.SelectedIndex = 0;

            // ==================== BUTTONS ====================
            // 📚 KIẾN THỨC: Button - Nút bấm để trigger events
            // 🔍 EVENT HANDLER:
            // - Click event: Được gọi khi user click vào button
            // - += operator: Đăng ký event handler
            // - BtnThem_Click: Method được gọi khi button được click

            // Button Thêm
            btnThem = new Button
            {
                Text = "Thêm",
                Location = new Point(20, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThem.Click += BtnThem_Click; // Đăng ký event handler

            // Button Xóa
            btnXoa = new Button
            {
                Text = "Xóa",
                Location = new Point(140, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnXoa.Click += BtnXoa_Click;

            // Button Sửa
            btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(260, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSua.Click += BtnSua_Click;

            // Button Tìm kiếm
            btnTimKiem = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(380, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnTimKiem.Click += BtnTimKiem_Click;

            // Button Làm mới
            btnLamMoi = new Button
            {
                Text = "Làm mới",
                Location = new Point(500, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLamMoi.Click += BtnLamMoi_Click;

            // Button Thống kê
            btnThongKe = new Button
            {
                Text = "Thống kê",
                Location = new Point(620, 580),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnThongKe.Click += BtnThongKe_Click;

            // ==================== ADD CONTROLS TO FORM ====================
            // 📚 KIẾN THỨC: Controls.Add() - Thêm controls vào Form
            // 🔍 LƯU Ý: Phải Add controls vào Form thì mới hiển thị được
            this.Controls.Add(dataGridView);
            this.Controls.Add(lblTimKiem);
            this.Controls.Add(lblKhoa);
            this.Controls.Add(lblBacDaoTao);
            this.Controls.Add(lblTrangThai);
            this.Controls.Add(txtTimKiem);
            this.Controls.Add(cboKhoa);
            this.Controls.Add(cboBacDaoTao);
            this.Controls.Add(cboTrangThai);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnTimKiem);
            this.Controls.Add(btnLamMoi);
            this.Controls.Add(btnThongKe);

            // ==================== GIẢI THÍCH DESIGNER PATTERN ====================
            //
            // 🔍 TẠI SAO CÓ FILE .DESIGNER.CS RIÊNG?
            // - Tách biệt UI initialization code khỏi business logic
            // - Visual Studio Form Designer tự động generate code này
            // - Developer chỉ cần kéo thả controls trong Designer GUI
            // - Code trong FormQuanLyDaoTao.cs chứa event handlers và logic
            //
            // 📝 WORKFLOW KHI DESIGN FORM:
            // 1. Kéo thả controls trong Visual Studio Form Designer
            // 2. Set properties trong Properties Window (Location, Size, Text, Color, ...)
            // 3. Designer tự động generate code trong InitializeComponent()
            // 4. Double-click button → Designer tạo event handler stub
            // 5. Developer viết logic trong event handler
            //
            // ⚠️ QUAN TRỌNG:
            // - KHÔNG SỬA CODE TRONG InitializeComponent() BẰNG TAY!
            // - Mọi thay đổi UI phải làm qua Designer GUI
            // - Nếu sửa tay → Designer có thể không load được form
            //
            // 🎨 BUTTON COLOR SCHEME:
            // - Thêm (Blue): 0, 122, 204 → Positive action
            // - Xóa (Red): 220, 53, 69 → Destructive action
            // - Sửa (Yellow): 255, 193, 7 → Caution action
            // - Tìm kiếm (Green): 40, 167, 69 → Success action
            // - Làm mới (Gray): 108, 117, 125 → Neutral action
            // - Thống kê (Cyan): 23, 162, 184 → Info action
            //
            // 📐 LAYOUT CALCULATIONS:
            // Form size: 1300 x 700
            // - Top section (filters): Y = 20-100
            // - DataGridView: Y = 120, Height = 450
            // - Buttons: Y = 580, Height = 40
            // - Margins: 20px from edges
            // - Button spacing: 120px (100px button + 20px gap)
        }

        #endregion
    }
}
