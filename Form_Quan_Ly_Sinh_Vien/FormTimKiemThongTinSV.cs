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
    // ==================== FORM TÌM KIẾM SINH VIÊN (OPTIMIZED) ====================
    // CẢI TIẾN:
    // 1. Refactor parsing logic thành helper methods
    // 2. Di chuyển logic từ FormClosing sang OK button
    // 3. Simplify code và improve readability
    // 4. Thêm validation
    public partial class FormTimKiemThongTinSV : Form
    {
        // ===== THUỘC TÍNH =====
        public ThongTinSinhVien TieuChiTimKiem { get; private set; }

        // ===== CONSTRUCTOR =====
        public FormTimKiemThongTinSV()
        {
            InitializeComponent();

            // Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // XÓA DialogResult để xử lý thủ công
            buttonTimKiemOK.DialogResult = DialogResult.None;
            buttonTimKiemHuyBo.DialogResult = DialogResult.Cancel;

            // THÊM event handler cho button OK
            buttonTimKiemOK.Click += buttonTimKiemOK_Click;

            // Set giá trị mặc định cho ComboBox
            if (comboBoxTimKiemSV.Items.Count > 0)
                comboBoxTimKiemSV.SelectedIndex = 0;
        }

        // ===== XỬ LÝ BUTTON OK =====
        private void buttonTimKiemOK_Click(object sender, EventArgs e)
        {
            // VALIDATION
            if (string.IsNullOrWhiteSpace(comboBoxTimKiemSV.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn tiêu chí tìm kiếm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxTimKiemSV.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập giá trị cần tìm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // XỬ LÝ TIÊU CHÍ TÌM KIẾM
            string tieuChi = comboBoxTimKiemSV.Text;
            string giaTri = richTextBoxTimKiemSV.Text;

            this.TieuChiTimKiem = new ThongTinSinhVien();

            switch (tieuChi)
            {
                case "Mã Sinh Viên":
                    this.TieuChiTimKiem.MaSV = giaTri.Trim();
                    break;

                case "Họ Và Tên":
                case "Họ và Tên":
                    // REFACTORED: Gọi helper method để parse họ tên
                    ParseHoVaTen(giaTri);
                    break;

                default:
                    MessageBox.Show(
                        "Tiêu chí tìm kiếm không hợp lệ!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
            }

            // Đóng form với kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===== PARSE HỌ VÀ TÊN (REFACTORED) =====
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Parsing (Phân tích cú pháp) là gì?
         * - Chuyển đổi chuỗi text thành các thành phần có ý nghĩa
         * - VD: "Nguyễn Văn An" → Họ: "Nguyễn", Tên lót: "Văn", Tên: "An"
         *
         * Các bước xử lý:
         * 1. Trim (loại bỏ khoảng trắng đầu/cuối)
         * 2. Normalize (chuẩn hóa khoảng trắng giữa các từ)
         * 3. Split (tách thành mảng các từ)
         * 4. Map (ánh xạ vào Họ, Tên lót, Tên)
         *
         * Refactoring Benefits:
         * - Code ngắn gọn, dễ đọc
         * - Tái sử dụng được
         * - Dễ test và debug
         * - Giảm code duplication
         */
        private void ParseHoVaTen(string hoVaTen)
        {
            // BƯỚC 1: Trim và Normalize
            string chuoiChuanHoa = TrimAndNormalize(hoVaTen);

            if (string.IsNullOrEmpty(chuoiChuanHoa))
            {
                MessageBox.Show(
                    "Họ và tên không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // BƯỚC 2: Split thành mảng từ
            string[] cacTu = SplitString(chuoiChuanHoa);

            // BƯỚC 3: Map vào DTO
            MapHoTenLotTen(cacTu);
        }

        // ===== HELPER METHOD: TRIM AND NORMALIZE =====
        /*
         * Loại bỏ khoảng trắng đầu/cuối và chuẩn hóa khoảng trắng giữa các từ
         * VD: "  Nguyễn   Văn    An  " → "Nguyễn Văn An"
         *
         * Sử dụng: String manipulation (Chapter 3 - DSA)
         */
        private string TrimAndNormalize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            string result = "";
            bool daBatDau = false; // Đã gặp ký tự đầu tiên chưa?
            bool coKhoangTrang = false; // Đã có khoảng trắng trước đó chưa?

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ') // Gặp ký tự KHÔNG phải khoảng trắng
                {
                    daBatDau = true;
                    result = result + input[i];
                    coKhoangTrang = false;
                }
                else if (daBatDau && !coKhoangTrang) // Đã bắt đầu, chưa có khoảng trắng
                {
                    result = result + ' ';
                    coKhoangTrang = true;
                }
                // Bỏ qua các khoảng trắng thừa
            }

            // Xóa khoảng trắng cuối (nếu có)
            if (result.Length > 0 && result[result.Length - 1] == ' ')
            {
                result = result.Remove(result.Length - 1);
            }

            return result;
        }

        // ===== HELPER METHOD: SPLIT STRING =====
        /*
         * Tách chuỗi thành mảng các từ
         * VD: "Nguyễn Văn An" → ["Nguyễn", "Văn", "An"]
         *
         * Sử dụng: String manipulation, Array (Chapter 1 & 3 - DSA)
         */
        private string[] SplitString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new string[0];

            // Tạo mảng tạm với kích thước tối đa
            string[] temp = new string[100];
            int count = 0;
            string currentWord = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ') // Ký tự không phải khoảng trắng
                {
                    currentWord = currentWord + input[i];
                }
                else if (currentWord != "") // Gặp khoảng trắng và có từ hiện tại
                {
                    temp[count] = currentWord;
                    count++;
                    currentWord = "";
                }
            }

            // Thêm từ cuối cùng
            if (currentWord != "")
            {
                temp[count] = currentWord;
                count++;
            }

            // Tạo mảng kết quả với đúng kích thước
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }

            return result;
        }

        // ===== HELPER METHOD: MAP HỌ TÊN LÓT TÊN =====
        /*
         * Ánh xạ mảng từ vào Họ, Tên lót, Tên
         *
         * Logic:
         * - 1 từ: Tên
         * - 2 từ: Họ + Tên
         * - 3+ từ: Họ + Tên lót + Tên
         */
        private void MapHoTenLotTen(string[] words)
        {
            int soTu = words.Length;

            if (soTu == 0)
                return;

            if (soTu == 1)
            {
                // Chỉ có 1 từ → coi như Tên
                this.TieuChiTimKiem.TenSV = words[0];
            }
            else if (soTu == 2)
            {
                // 2 từ → Họ + Tên
                this.TieuChiTimKiem.HoSV = words[0];
                this.TieuChiTimKiem.TenSV = words[1];
            }
            else // soTu >= 3
            {
                // Họ = từ đầu tiên
                this.TieuChiTimKiem.HoSV = words[0];

                // Tên = từ cuối cùng
                this.TieuChiTimKiem.TenSV = words[soTu - 1];

                // Tên lót = ghép các từ ở giữa
                string tenLot = "";
                for (int i = 1; i < soTu - 1; i++)
                {
                    if (tenLot != "")
                        tenLot = tenLot + " ";
                    tenLot = tenLot + words[i];
                }
                this.TieuChiTimKiem.TenLotSV = tenLot;
            }
        }

        // ===== XỬ LÝ FORMCLOSING (GIỮ LẠI ĐỂ TƯƠNG THÍCH) =====
        // NOTE: Logic chính đã chuyển sang buttonTimKiemOK_Click
        private void FormTimKiemThongTinSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Không cần xử lý gì ở đây nữa
            // Logic đã được di chuyển sang buttonTimKiemOK_Click
        }

        /*
         * ==================== TÓM TẮT CẢI TIẾN ====================
         *
         * 1. CODE ORGANIZATION:
         *    - Tách parsing logic thành 4 helper methods:
         *      + ParseHoVaTen() - Main parser
         *      + TrimAndNormalize() - Chuẩn hóa chuỗi
         *      + SplitString() - Tách thành mảng
         *      + MapHoTenLotTen() - Ánh xạ vào DTO
         *
         * 2. READABILITY:
         *    - Giảm từ 80+ dòng xuống ~30 dòng (logic chính)
         *    - Mỗi method có 1 trách nhiệm rõ ràng
         *    - Tên method/variable tự giải thích
         *
         * 3. MAINTAINABILITY:
         *    - Dễ sửa lỗi (debug từng method riêng)
         *    - Dễ test (test từng method độc lập)
         *    - Dễ mở rộng (thêm tiêu chí tìm kiếm mới)
         *
         * 4. REUSABILITY:
         *    - TrimAndNormalize() có thể dùng cho nhiều mục đích
         *    - SplitString() có thể dùng cho parsing khác
         *
         * 5. VALIDATION:
         *    - Kiểm tra ComboBox và RichTextBox trước khi xử lý
         *    - Thông báo lỗi rõ ràng
         *
         * ==================== END TÓM TẮT ====================
         */
    }
}