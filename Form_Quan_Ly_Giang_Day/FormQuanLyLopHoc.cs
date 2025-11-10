using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Giang_Day
{
    public partial class FormQuanLyLopHoc : Form
    {
        public FormQuanLyLopHoc()
        {
            InitializeComponent();

            // Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.Size = new Size(1000, 600);
            this.Text = "Quản Lý Lớp Học";
        }

        private void FormQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView
            dataGridViewLopHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLopHoc.AllowUserToAddRows = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
