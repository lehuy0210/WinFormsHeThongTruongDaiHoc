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
using System.Windows.Forms.VisualStyles;

namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien
{
    public partial class FormTimKiemThongTinSV : Form
    {
        // Thêm required hoặc khởi tạo giá trị mặc định
        public ThongTinSinhVien TieuChiTimKiem { get; private set; } = new ThongTinSinhVien();

        public FormTimKiemThongTinSV()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            buttonTimKiemOK.DialogResult = DialogResult.OK;
            buttonTimKiemHuyBo.DialogResult = DialogResult.Cancel;
        }

        private void FormTimKiemThongTinSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                string tieuChi = comboBoxTimKiemSV.Text;
                string giaTri = richTextBoxTimKiemSV.Text;
                this.TieuChiTimKiem = new ThongTinSinhVien();
                switch (tieuChi)
                {
                    case "Mã Sinh Viên":
                        {
                            this.TieuChiTimKiem.MaSV = giaTri;
                            break;
                        }
                    case "Họ Và Tên":
                        {
                            // Bước 1: Loại bỏ khoảng trắng đầu/cuối
                            string chuoiHoVaTen = "";
                            bool daBatDau = false; // Đánh dấu đã gặp ký tự đầu tiên chưa
                            for (int i = 0; i < giaTri.Length; i++)
                            {
                                if (giaTri[i] != ' ') // Gặp ký tự KHÔNG phải khoảng trắng
                                {
                                    daBatDau = true;
                                    chuoiHoVaTen = chuoiHoVaTen + giaTri[i];
                                }
                                else if (daBatDau) // Đã bắt đầu rồi, gặp khoảng trắng
                                {
                                    chuoiHoVaTen = chuoiHoVaTen + giaTri[i];
                                }
                            }
                            // Xóa khoảng trắng cuối chuỗi
                            for (int i = chuoiHoVaTen.Length - 1; i >= 0; i--)
                            {
                                if (chuoiHoVaTen[i] != ' ')
                                {
                                    break; // Gặp ký tự → dừng
                                }
                                chuoiHoVaTen = chuoiHoVaTen.Remove(i);
                            }
                            // Bước 2: Tách chuỗi thành mảng
                            {
                                string[] cacTu = new string[100]; // Giả sử tối đa 100 từ
                                int soTu = 0;
                                string tuHienTai = "";

                                for (int i = 0; i < chuoiHoVaTen.Length; i++)
                                {
                                    if (chuoiHoVaTen[i] != ' ') // Ký tự KHÔNG phải khoảng trắng
                                    {
                                        tuHienTai = tuHienTai + chuoiHoVaTen[i];
                                    }
                                    else // Gặp khoảng trắng → kết thúc 1 từ
                                    {
                                        if (tuHienTai != "") // Chỉ lưu từ KHÔNG RỖNG
                                        {
                                            cacTu[soTu] = tuHienTai;
                                            soTu++;
                                            tuHienTai = "";
                                        }
                                    }
                                }
                                // Lưu từ CUỐI CÙNG (vì sau từ cuối không có khoảng trắng)
                                if (tuHienTai != "")
                                {
                                    cacTu[soTu] = tuHienTai;
                                    soTu++;
                                }
                                if (soTu == 1)
                                {
                                    this.TieuChiTimKiem.TenSV = cacTu[0];
                                }
                                else if (soTu == 2)
                                {
                                    this.TieuChiTimKiem.HoSV = cacTu[0];
                                    this.TieuChiTimKiem.TenSV = cacTu[1];
                                }
                                else if (soTu >= 3)
                                {
                                    // Họ = từ đầu tiên
                                    this.TieuChiTimKiem.HoSV = cacTu[0];
                                    // Tên = từ cuối cùng
                                    this.TieuChiTimKiem.TenSV = cacTu[soTu - 1];
                                    // Tên lót = ghép các từ ở giữa
                                    string tenLot = "";
                                    for (int i = 1; i < soTu - 1; i++)
                                    {
                                        if (tenLot != "")
                                        {
                                            tenLot = tenLot + " ";
                                        }
                                        tenLot = tenLot + cacTu[i];
                                    }
                                    this.TieuChiTimKiem.TenLotSV = tenLot;
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}