using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He_Thong_Truong_Dai_Hoc
{
    // ==================== FORM DATABASE CONNECTION ====================
    //
    // 📚 KIẾN THỨC ÁP DỤNG:
    //
    // 1️⃣ FUNDAMENTALS OF PROGRAMMING:
    //    - Chapter 4: Control Structures
    //      • 4.2: Selection Structures (if/else) - Kiểm tra điều kiện
    //      • 4.2.1: if statement - Kiểm tra null, kiểm tra chuỗi rỗng
    //    - Chapter 5: Functions
    //      • 5.2: Function Definition - Định nghĩa các phương thức
    //      • 5.4: Value-Returning Functions - Hàm trả về ConnectionString
    //
    // 2️⃣ OBJECT-ORIENTED PROGRAMMING (OOP):
    //    - Chapter 2: Classes and Objects
    //      • 2.1: Class - Định nghĩa class FormDatabase
    //      • 2.1.2: Properties - ConnectionString, Username, IsConnected
    //      • 2.1.4: Methods - BuildConnectionString(), UpdateAuthenticationControls()
    //      • 2.3: Encapsulation - Private methods, Public properties
    //    - Chapter 3: Inheritance
    //      • 3.1: Inheritance - FormDatabase kế thừa Form
    //      • 3.2: Base class - Form là base class
    //
    // 3️⃣ GUI PROGRAMMING:
    //    - Chapter 1: Introduction to Windows Forms
    //      • 1.2: Creating Forms - Tạo form kết nối database
    //      • 1.3: Form Properties - FormBorderStyle, StartPosition
    //    - Chapter 2: Controls
    //      • 2.1: TextBox - Nhập server name, database name, username, password
    //      • 2.2: Button - Test Connection, OK, Cancel
    //      • 2.3: RadioButton - Chọn loại authentication
    //      • 2.4: Label - Hiển thị tên field
    //      • 2.5: GroupBox - Nhóm các RadioButton
    //    - Chapter 3: Event Handling
    //      • 3.1: Button Click Events - Xử lý sự kiện click
    //      • 3.2: CheckedChanged Events - RadioButton state changes
    //    - Chapter 4: Dialog Forms
    //      • 4.1: ShowDialog() - Hiển thị form dưới dạng dialog
    //      • 4.2: DialogResult - Trả về OK/Cancel
    //
    // 4️⃣ DATABASE PROGRAMMING:
    //    - Chapter 1: Introduction to ADO.NET
    //      • 1.1: What is ADO.NET - Kết nối C# với SQL Server
    //      • 1.2: ADO.NET Architecture - Connection, Command, DataReader
    //    - Chapter 2: Connection Management
    //      • 2.1: SqlConnection - Đối tượng kết nối database
    //      • 2.2: Connection String - Chuỗi kết nối chứa thông tin server
    //      • 2.2.1: Data Source - Tên server (localhost, IP, instance)
    //      • 2.2.2: Initial Catalog - Tên database
    //      • 2.2.3: Integrated Security - Windows Authentication
    //      • 2.2.4: User ID & Password - SQL Server Authentication
    //    - Chapter 3: N-Layer Architecture
    //      • 3.3.1: Presentation Layer - FormDatabase là UI Layer
    //
    // 5️⃣ EXCEPTION HANDLING:
    //    - Chapter 6: Exception Handling
    //      • 6.1: try-catch blocks - Bắt lỗi kết nối
    //      • 6.2: Exception types - SqlException
    //      • 6.3: Error messages - Hiển thị lỗi cho người dùng
    //
    // 🎯 MỤC ĐÍCH CỦA FORM:
    // FormDatabase cho phép người dùng KẾT NỐI đến SQL Server:
    // - AUTHENTICATION: Hỗ trợ 2 loại xác thực (Windows Auth, SQL Auth)
    // - CONNECTION STRING: Xây dựng chuỗi kết nối từ thông tin nhập
    // - TEST CONNECTION: Kiểm tra kết nối trước khi lưu
    // - VALIDATION: Kiểm tra dữ liệu hợp lệ (server name, database name)
    // - RETURN DATA: Trả về ConnectionString và Username cho MainForm
    //
    // 💡 VÍ DỤ THỰC TẾ:
    // Giống như ĐĂNG NHẬP vào hệ thống ngân hàng:
    // Bước 1: Chọn phương thức đăng nhập (Vân tay/Mật khẩu = Windows/SQL Auth)
    // Bước 2: Nhập thông tin (Server, Database, Username, Password)
    // Bước 3: Test connection - Kiểm tra thông tin có đúng không
    // Bước 4: Đăng nhập thành công → Lưu thông tin phiên làm việc
    //
    // 🔍 QUY TRÌNH KẾT NỐI DATABASE (ALGORITHM):
    //
    // Bước 1: CHỌN LOẠI XÁC THỰC
    //    • Windows Authentication: Dùng tài khoản Windows hiện tại
    //    • SQL Server Authentication: Dùng Username/Password của SQL Server
    //
    // Bước 2: NHẬP THÔNG TIN
    //    • Server Name: localhost, .\SQLEXPRESS, IP address
    //    • Database Name: Tên database cần kết nối
    //    • Username/Password (nếu dùng SQL Auth)
    //
    // Bước 3: XÂY DỰNG CONNECTION STRING
    //    • Sử dụng SqlConnectionStringBuilder
    //    • Data Source = Server Name
    //    • Initial Catalog = Database Name
    //    • Integrated Security = true/false
    //    • User ID & Password (nếu SQL Auth)
    //
    // Bước 4: TEST CONNECTION
    //    • Tạo SqlConnection từ Connection String
    //    • Gọi conn.Open() - Mở kết nối
    //    • Nếu thành công: Hiển thị thông báo
    //    • Nếu thất bại: Hiển thị lỗi (sai server, sai tên DB, sai password)
    //
    // Bước 5: LƯU THÔNG TIN & TRẢ VỀ
    //    • ConnectionString → Dùng cho toàn bộ ứng dụng
    //    • Username → Hiển thị trên MainForm
    //    • IsConnected = true
    //    • DialogResult = OK
    //
    // 📊 CÁC LOẠI AUTHENTICATION:
    //
    // 1. WINDOWS AUTHENTICATION (Integrated Security = true):
    //    Connection String: "Data Source=localhost;Initial Catalog=HeThongTruongDaiHoc;Integrated Security=true"
    //    - Ưu điểm: Không cần nhập username/password
    //    - Nhược điểm: Phải có quyền truy cập Windows
    //
    // 2. SQL SERVER AUTHENTICATION (Integrated Security = false):
    //    Connection String: "Data Source=localhost;Initial Catalog=HeThongTruongDaiHoc;User ID=sa;Password=123456"
    //    - Ưu điểm: Linh hoạt, không phụ thuộc Windows account
    //    - Nhược điểm: Phải quản lý username/password
    //
    /*
    GIẢI THÍCH CHO SINH VIÊN:

    Connection String là gì?
    - Là chuỗi chứa THÔNG TIN kết nối database
    - Giống như địa chỉ nhà: Tên đường (Server) + Số nhà (Database)
    - VD: "Data Source=localhost;Initial Catalog=HeThongTruongDaiHoc;Integrated Security=true"

    Windows Authentication vs SQL Server Authentication:
    - Windows Auth: Dùng tài khoản đang đăng nhập Windows (tự động)
    - SQL Auth: Phải nhập Username/Password riêng của SQL Server

    Tại sao phải Test Connection?
    - Kiểm tra thông tin có đúng không trước khi lưu
    - Tránh lỗi khi chạy chương trình chính
    - Giống như thử chìa khóa trước khi mua nhà

    DialogResult là gì?
    - Kết quả trả về khi đóng form dialog
    - OK: Kết nối thành công
    - Cancel: Người dùng hủy
    */
    public partial class FormDatabase : Form
    {
        public string ConnectionString { get; private set; } = "";
        public string Username { get; private set; } = "";
        public bool IsConnected { get; private set; } = false;

        // ==================== CONSTRUCTOR - KHỞI TẠO FORM ====================
        // Sử dụng: Constructor (Chapter 2.1.3 - OOP)
        //          Event Handling (Chapter 3 - GUI Programming)

        /// <summary>
        /// Constructor - Khởi tạo form kết nối database
        /// Constructor - Initialize database connection form
        /// </summary>
        /*
        VÍ DỤ CHẠY TAY:

        Khi gọi: FormDatabase formDB = new FormDatabase()

        Bước 1: InitializeComponent() - Khởi tạo components (Designer.cs)
        Bước 2: Cấu hình Form properties
                - FormBorderStyle = FixedDialog (không thay đổi kích thước)
                - MaximizeBox = false (không có nút maximize)
                - StartPosition = CenterParent (hiển thị giữa màn hình)
        Bước 3: ThietLapControls() - Tạo các controls (TextBox, Button, Label,...)
        Bước 4: Gắn Event Handlers
                - radioButtonWindowsAuth.CheckedChanged += RadioButtonAuth_CheckedChanged
                  → Khi click Windows Auth, gọi RadioButtonAuth_CheckedChanged
                - buttonTestConnection.Click += ButtonTestConnection_Click
                  → Khi click Test Connection, gọi ButtonTestConnection_Click
        Bước 5: Thiết lập mặc định
                - radioButtonWindowsAuth.Checked = true
                - UpdateAuthenticationControls() → Disable Username/Password fields

        GIẢI THÍCH:
        - += là gắn event handler (subscribe to event)
        - Khi event xảy ra (click, checked changed), method được gọi tự động
        - VD: Click button → ButtonTestConnection_Click được gọi
        */
        public FormDatabase()
        {
            InitializeComponent();

            // ===== BƯỚC 1: CÂU HÌNH FORM =====
            // Sử dụng: Form Properties (Chapter 1.3 - GUI Programming)

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Không cho resize
            this.MaximizeBox = false;  // Không cho maximize
            this.MinimizeBox = false;  // Không cho minimize
            this.StartPosition = FormStartPosition.CenterParent; // Hiển thị giữa màn hình
            this.Size = new Size(500, 400); // Kích thước form
            this.Text = "Kết Nối Database"; // Tiêu đề form

            // ===== BƯỚC 2: THIẾT LẬP CONTROLS =====
            // Tạo các TextBox, Button, Label, RadioButton
            ThietLapControls();

            // ===== BƯỚC 3: THIẾT LẬP EVENT HANDLERS =====
            // Sử dụng: Event Handling (Chapter 3 - GUI Programming)
            // Gắn các event handler cho controls

            radioButtonWindowsAuth.CheckedChanged += RadioButtonAuth_CheckedChanged;
            radioButtonSQLAuth.CheckedChanged += RadioButtonAuth_CheckedChanged;
            buttonTestConnection.Click += ButtonTestConnection_Click;
            buttonOK.Click += ButtonOK_Click;
            buttonCancel.Click += ButtonCancel_Click;

            // ===== BƯỚC 4: THIẾT LẬP MẶC ĐỊNH =====
            // Mặc định chọn Windows Authentication
            radioButtonWindowsAuth.Checked = true;
            UpdateAuthenticationControls(); // Disable Username/Password fields
        }

        private void ThietLapControls()
        {
            // Label tiêu đề
            Label labelTitle = new Label();
            labelTitle.Text = "KẾT NỐI CƠ SỞ DỮ LIỆU";
            labelTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Size = new Size(450, 30);
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(labelTitle);

            // GroupBox Authentication Type
            GroupBox groupAuth = new GroupBox();
            groupAuth.Text = "Loại Xác Thực";
            groupAuth.Location = new Point(20, 60);
            groupAuth.Size = new Size(450, 80);
            this.Controls.Add(groupAuth);

            radioButtonWindowsAuth = new RadioButton();
            radioButtonWindowsAuth.Text = "Windows Authentication";
            radioButtonWindowsAuth.Location = new Point(20, 25);
            radioButtonWindowsAuth.Size = new Size(200, 20);
            groupAuth.Controls.Add(radioButtonWindowsAuth);

            radioButtonSQLAuth = new RadioButton();
            radioButtonSQLAuth.Text = "SQL Server Authentication";
            radioButtonSQLAuth.Location = new Point(20, 50);
            radioButtonSQLAuth.Size = new Size(200, 20);
            groupAuth.Controls.Add(radioButtonSQLAuth);

            // Server Name
            Label labelServer = new Label();
            labelServer.Text = "Server Name:";
            labelServer.Location = new Point(20, 155);
            labelServer.Size = new Size(150, 20);
            this.Controls.Add(labelServer);

            textBoxServerName = new TextBox();
            textBoxServerName.Location = new Point(180, 155);
            textBoxServerName.Size = new Size(290, 25);
            textBoxServerName.Text = "localhost"; // Mặc định
            this.Controls.Add(textBoxServerName);

            // Database Name
            Label labelDatabase = new Label();
            labelDatabase.Text = "Database Name:";
            labelDatabase.Location = new Point(20, 185);
            labelDatabase.Size = new Size(150, 20);
            this.Controls.Add(labelDatabase);

            textBoxDatabaseName = new TextBox();
            textBoxDatabaseName.Location = new Point(180, 185);
            textBoxDatabaseName.Size = new Size(290, 25);
            textBoxDatabaseName.Text = "HeThongTruongDaiHoc"; // Mặc định
            this.Controls.Add(textBoxDatabaseName);

            // Username
            labelUsername = new Label();
            labelUsername.Text = "Username:";
            labelUsername.Location = new Point(20, 215);
            labelUsername.Size = new Size(150, 20);
            this.Controls.Add(labelUsername);

            textBoxUsername = new TextBox();
            textBoxUsername.Location = new Point(180, 215);
            textBoxUsername.Size = new Size(290, 25);
            this.Controls.Add(textBoxUsername);

            // Password
            labelPassword = new Label();
            labelPassword.Text = "Password:";
            labelPassword.Location = new Point(20, 245);
            labelPassword.Size = new Size(150, 20);
            this.Controls.Add(labelPassword);

            textBoxPassword = new TextBox();
            textBoxPassword.Location = new Point(180, 245);
            textBoxPassword.Size = new Size(290, 25);
            textBoxPassword.PasswordChar = '*';
            this.Controls.Add(textBoxPassword);

            // Buttons
            buttonTestConnection = new Button();
            buttonTestConnection.Text = "Test Connection";
            buttonTestConnection.Location = new Point(20, 290);
            buttonTestConnection.Size = new Size(140, 35);
            this.Controls.Add(buttonTestConnection);

            buttonOK = new Button();
            buttonOK.Text = "OK";
            buttonOK.Location = new Point(270, 290);
            buttonOK.Size = new Size(95, 35);
            this.Controls.Add(buttonOK);

            buttonCancel = new Button();
            buttonCancel.Text = "Cancel";
            buttonCancel.Location = new Point(375, 290);
            buttonCancel.Size = new Size(95, 35);
            buttonCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(buttonCancel);
        }

        private RadioButton radioButtonWindowsAuth;
        private RadioButton radioButtonSQLAuth;
        private TextBox textBoxServerName;
        private TextBox textBoxDatabaseName;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonTestConnection;
        private Button buttonOK;
        private Button buttonCancel;

        private void RadioButtonAuth_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthenticationControls();
        }

        // ==================== PHƯƠNG THỨC CẬP NHẬT CONTROLS THEO LOẠI XÁC THỰC ====================
        // Sử dụng: Control Properties (Chapter 2 - GUI Programming)
        //          Boolean logic (Chapter 4.2 - Fundamentals)

        /// <summary>
        /// Cập nhật trạng thái controls dựa trên loại authentication
        /// Update controls state based on authentication type
        /// </summary>
        /*
        VÍ DỤ CHẠY TAY:

        Trường hợp 1: Windows Authentication được chọn
        - radioButtonWindowsAuth.Checked = true
        - radioButtonSQLAuth.Checked = false
        - isSQLAuth = false

        Bước 1: Disable Username/Password fields
                - labelUsername.Enabled = false (màu xám)
                - textBoxUsername.Enabled = false (không nhập được)
                - labelPassword.Enabled = false
                - textBoxPassword.Enabled = false

        Bước 2: Xóa nội dung Username/Password
                - textBoxUsername.Text = ""
                - textBoxPassword.Text = ""

        Trường hợp 2: SQL Server Authentication được chọn
        - radioButtonSQLAuth.Checked = true
        - isSQLAuth = true

        Bước 1: Enable Username/Password fields
                - labelUsername.Enabled = true (màu đen)
                - textBoxUsername.Enabled = true (nhập được)
                - labelPassword.Enabled = true
                - textBoxPassword.Enabled = true

        GIẢI THÍCH:
        - Enabled = true: Control hoạt động bình thường
        - Enabled = false: Control bị vô hiệu hóa (màu xám, không tương tác được)
        - Windows Auth không cần username/password → Disable để tránh nhầm lẫn
        */
        private void UpdateAuthenticationControls()
        {
            // Kiểm tra loại authentication đang chọn
            bool isSQLAuth = radioButtonSQLAuth.Checked;

            // Cập nhật trạng thái controls
            // Nếu SQL Auth: Enable username/password fields
            // Nếu Windows Auth: Disable username/password fields
            labelUsername.Enabled = isSQLAuth;
            textBoxUsername.Enabled = isSQLAuth;
            labelPassword.Enabled = isSQLAuth;
            textBoxPassword.Enabled = isSQLAuth;

            // Nếu không phải SQL Auth, xóa nội dung username/password
            if (!isSQLAuth)
            {
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void ButtonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = BuildConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show(
                        "Kết nối thành công!\n\nServer: " + textBoxServerName.Text + "\nDatabase: " + textBoxDatabaseName.Text,
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Kết nối thất bại!\n\nLỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(textBoxServerName.Text))
                {
                    MessageBox.Show("Vui lòng nhập Server Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxServerName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxDatabaseName.Text))
                {
                    MessageBox.Show("Vui lòng nhập Database Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxDatabaseName.Focus();
                    return;
                }

                if (radioButtonSQLAuth.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
                    {
                        MessageBox.Show("Vui lòng nhập Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxUsername.Focus();
                        return;
                    }
                }

                // Test connection
                string connStr = BuildConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                }

                // Lưu thông tin
                ConnectionString = connStr;
                Username = radioButtonWindowsAuth.Checked ? Environment.UserName : textBoxUsername.Text;
                IsConnected = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối!\n\nLỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ==================== PHƯƠNG THỨC XÂY DỰNG CONNECTION STRING ====================
        // Sử dụng: SqlConnectionStringBuilder (Chapter 2.2 - Database Programming)
        //          String manipulation (Chapter 4 - Programming Techniques)
        //          Conditional structures (Chapter 4.2 - Fundamentals)

        /// <summary>
        /// Xây dựng connection string từ thông tin người dùng nhập
        /// Build connection string from user input
        /// </summary>
        /// <returns>Connection string hoàn chỉnh</returns>
        /*
        VÍ DỤ CHẠY TAY:

        Trường hợp 1: Windows Authentication
        Input:
        - textBoxServerName.Text = "localhost"
        - textBoxDatabaseName.Text = "HeThongTruongDaiHoc"
        - radioButtonWindowsAuth.Checked = true

        Bước 1: Tạo SqlConnectionStringBuilder
                builder = new SqlConnectionStringBuilder()

        Bước 2: Thiết lập server & database
                builder.DataSource = "localhost"
                builder.InitialCatalog = "HeThongTruongDaiHoc"

        Bước 3: Thiết lập authentication (Windows)
                builder.IntegratedSecurity = true

        Bước 4: Thiết lập timeout & certificate
                builder.ConnectTimeout = 30 (chờ tối đa 30 giây)
                builder.TrustServerCertificate = true

        Output: "Data Source=localhost;Initial Catalog=HeThongTruongDaiHoc;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True"

        Trường hợp 2: SQL Server Authentication
        Input:
        - textBoxServerName.Text = "localhost"
        - textBoxDatabaseName.Text = "HeThongTruongDaiHoc"
        - textBoxUsername.Text = "sa"
        - textBoxPassword.Text = "123456"
        - radioButtonSQLAuth.Checked = true

        Bước 1-2: Giống trường hợp 1

        Bước 3: Thiết lập authentication (SQL)
                builder.IntegratedSecurity = false
                builder.UserID = "sa"
                builder.Password = "123456"

        Bước 4: Giống trường hợp 1

        Output: "Data Source=localhost;Initial Catalog=HeThongTruongDaiHoc;User ID=sa;Password=123456;Connect Timeout=30;Trust Server Certificate=True"

        GIẢI THÍCH:
        - SqlConnectionStringBuilder: Class hỗ trợ xây dựng connection string
        - DataSource: Tên server (localhost, IP, instance name)
        - InitialCatalog: Tên database
        - IntegratedSecurity: true = Windows Auth, false = SQL Auth
        - Trim(): Xóa khoảng trắng đầu/cuối để tránh lỗi
        - ConnectTimeout: Thời gian chờ kết nối (giây)
        - TrustServerCertificate: Tin tưởng certificate của server (cho môi trường dev)
        */
        private string BuildConnectionString()
        {
            // ===== BƯỚC 1: TẠO CONNECTION STRING BUILDER =====
            // SqlConnectionStringBuilder giúp xây dựng connection string an toàn
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            // ===== BƯỚC 2: THIẾT LẬP SERVER & DATABASE =====
            // Trim(): Xóa khoảng trắng đầu/cuối
            builder.DataSource = textBoxServerName.Text.Trim();        // Server name
            builder.InitialCatalog = textBoxDatabaseName.Text.Trim();  // Database name

            // ===== BƯỚC 3: THIẾT LẬP AUTHENTICATION =====
            if (radioButtonWindowsAuth.Checked)
            {
                // Windows Authentication: Dùng tài khoản Windows hiện tại
                builder.IntegratedSecurity = true;
            }
            else
            {
                // SQL Server Authentication: Dùng username/password
                builder.IntegratedSecurity = false;
                builder.UserID = textBoxUsername.Text.Trim();
                builder.Password = textBoxPassword.Text; // Không trim password (có thể có space)
            }

            // ===== BƯỚC 4: THIẾT LẬP CẤU HÌNH BỔ SUNG =====
            builder.ConnectTimeout = 30;              // Chờ tối đa 30 giây
            builder.TrustServerCertificate = true;    // Tin tưởng certificate (dev environment)

            // ===== BƯỚC 5: TRẢ VỀ CONNECTION STRING =====
            // builder.ConnectionString tự động ghép các thành phần thành chuỗi
            return builder.ConnectionString;
        }
    }
}
