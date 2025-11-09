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

namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien
{
    public partial class FormThongTinSV : Form
    {
        public ThongTinSinhVien SinhVienMoi { get; private set; }
        public FormThongTinSV(ThongTinSinhVien sv)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            buttonOKSV.DialogResult = DialogResult.OK;
            buttonHuyBoSV.DialogResult = DialogResult.Cancel;

            dateTimePickerSV.Format = DateTimePickerFormat.Short;

        }
        private void FormThemThongTinSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem người dùng có bấm "OK" không
            if (this.DialogResult == DialogResult.OK)
            {
                // Nếu bấm OK, thì mới tạo đối tượng
                SinhVienMoi = new ThongTinSinhVien();
                SinhVienMoi.MaSV = textBoxMaSV.Text;
                SinhVienMoi.HoSV = textBoxHoSV.Text;
                SinhVienMoi.TenLotSV = textBoxTenLotSV.Text;
                SinhVienMoi.TenSV = textBoxTenSV.Text;
                SinhVienMoi.NgaySinhSV = dateTimePickerSV.Value.Date;
                SinhVienMoi.GioiTinhSV = radioButtonNam.Checked ? "Nam" : "Nữ";
                SinhVienMoi.CCCDSV = textBoxCCCD.Text;
                SinhVienMoi.DiaChiSV = textBoxDiaChi.Text;
                SinhVienMoi.EmailSV = textBoxEmail.Text;
                SinhVienMoi.LopSV = comboBoxLopSV.Text;
                SinhVienMoi.TrangThaiSV = comboBoxTrangThaiSV.Text;
            }
        }
    }
}

