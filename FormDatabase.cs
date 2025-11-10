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
    public partial class FormDatabase : Form
    {
        public string ConnectionString { get; private set; } = "";
        public string Username { get; private set; } = "";
        public bool IsConnected { get; private set; } = false;

        public FormDatabase()
        {
            InitializeComponent();

            // Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(500, 400);
            this.Text = "Kết Nối Database";

            // Thiết lập controls
            ThietLapControls();

            // Thiết lập event handlers
            radioButtonWindowsAuth.CheckedChanged += RadioButtonAuth_CheckedChanged;
            radioButtonSQLAuth.CheckedChanged += RadioButtonAuth_CheckedChanged;
            buttonTestConnection.Click += ButtonTestConnection_Click;
            buttonOK.Click += ButtonOK_Click;
            buttonCancel.Click += ButtonCancel_Click;

            // Mặc định chọn Windows Authentication
            radioButtonWindowsAuth.Checked = true;
            UpdateAuthenticationControls();
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

        private void UpdateAuthenticationControls()
        {
            bool isSQLAuth = radioButtonSQLAuth.Checked;

            labelUsername.Enabled = isSQLAuth;
            textBoxUsername.Enabled = isSQLAuth;
            labelPassword.Enabled = isSQLAuth;
            textBoxPassword.Enabled = isSQLAuth;

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

        private string BuildConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = textBoxServerName.Text.Trim();
            builder.InitialCatalog = textBoxDatabaseName.Text.Trim();

            if (radioButtonWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = textBoxUsername.Text.Trim();
                builder.Password = textBoxPassword.Text;
            }

            builder.ConnectTimeout = 30;
            builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}
