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
    // ==================== FORM THÔNG TIN SINH VIÊN (OPTIMIZED) ====================
    // CẢI TIẾN:
    // 1. Thêm validation dữ liệu đầu vào
    // 2. Populate data khi chỉnh sửa sinh viên
    // 3. Khởi tạo ComboBox items
    // 4. Di chuyển logic từ FormClosing sang OK button
    // 5. Cải thiện UX với error messages
    public partial class FormThongTinSV : Form
    {
        // ===== THUỘC TÍNH =====
        public ThongTinSinhVien SinhVienMoi { get; private set; }
        private bool isEditMode = false; // Đánh dấu chế độ sửa hay thêm mới
        private string duongDanAnhDaChon = ""; // Lưu đường dẫn ảnh đã chọn

        // ===== CONSTRUCTOR =====
        public FormThongTinSV(ThongTinSinhVien sv)
        {
            InitializeComponent();

            // Cấu hình Form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            // XÓA DialogResult khỏi button để xử lý thủ công
            buttonOKSV.DialogResult = DialogResult.None;
            buttonHuyBoSV.DialogResult = DialogResult.Cancel;

            // THÊM event handler cho button OK
            buttonOKSV.Click += buttonOKSV_Click;

            // THÊM event handler cho button Chọn Ảnh
            buttonChonAnhSV.Click += buttonChonAnhSV_Click;

            // Cấu hình DateTimePicker
            dateTimePickerSV.Format = DateTimePickerFormat.Short;
            dateTimePickerSV.MaxDate = DateTime.Now; // Không cho chọn ngày tương lai

            // KHỞI TẠO COMBOBOX ITEMS
            KhoiTaoComboBoxItems();

            // Set giá trị mặc định cho RadioButton
            radioButtonNam.Checked = true;

            // POPULATE DATA NẾU LÀ CHẾ ĐỘ CHỈNH SỬA
            if (sv != null)
            {
                isEditMode = true;
                PopulateData(sv);
                labelTenForm.Text = "CHỈNH SỬA THÔNG TIN";
                // Không cho sửa mã sinh viên khi đang edit
                textBoxMaSV.ReadOnly = true;
                textBoxMaSV.BackColor = SystemColors.Control;
            }
            else
            {
                labelTenForm.Text = "THÊM SINH VIÊN MỚI";
            }

            // CÀI ĐẶT TAB ORDER
            SetTabOrder();
        }

        // ===== KHỞI TẠO DỮ LIỆU CHO COMBOBOX =====
        private void KhoiTaoComboBoxItems()
        {
            // Danh sách lớp (có thể tùy chỉnh)
            comboBoxLopSV.Items.AddRange(new object[] {
                "CNTT1", "CNTT2", "CNTT3", "CNTT4",
                "KHMT1", "KHMT2", "KHMT3", "KHMT4",
                "HTTT1", "HTTT2", "HTTT3", "HTTT4",
                "KTPM1", "KTPM2", "KTPM3", "KTPM4"
            });

            // Danh sách trạng thái
            comboBoxTrangThaiSV.Items.AddRange(new object[] {
                "Đang học",
                "Tốt nghiệp",
                "Nghỉ học",
                "Bảo lưu",
                "Đình chỉ"
            });

            // Set giá trị mặc định
            if (!isEditMode)
            {
                comboBoxTrangThaiSV.SelectedIndex = 0; // "Đang học"
            }
        }

        // ===== POPULATE DATA KHI CHỈNH SỬA =====
        private void PopulateData(ThongTinSinhVien sv)
        {
            textBoxMaSV.Text = sv.MaSV;
            textBoxHoSV.Text = sv.HoSV;
            textBoxTenLotSV.Text = sv.TenLotSV;
            textBoxTenSV.Text = sv.TenSV;
            dateTimePickerSV.Value = sv.NgaySinhSV;

            // Set RadioButton
            if (sv.GioiTinhSV == "Nam")
                radioButtonNam.Checked = true;
            else
                radioButtonNu.Checked = true;

            textBoxCCCD.Text = sv.CCCDSV;
            textBoxDiaChi.Text = sv.DiaChiSV;
            textBoxEmail.Text = sv.EmailSV;
            comboBoxLopSV.Text = sv.LopSV;
            comboBoxTrangThaiSV.Text = sv.TrangThaiSV;

            // Load hình ảnh nếu có
            if (!string.IsNullOrWhiteSpace(sv.HinhAnhSV) && System.IO.File.Exists(sv.HinhAnhSV))
            {
                duongDanAnhDaChon = sv.HinhAnhSV;
                try
                {
                    // Load ảnh vào PictureBox (tạo copy để tránh lock file)
                    using (Image anhGoc = Image.FromFile(sv.HinhAnhSV))
                    {
                        pictureBoxAnhDaiDienSV.Image = new Bitmap(anhGoc);
                    }
                }
                catch
                {
                    // Nếu có lỗi khi load ảnh, để trống
                    pictureBoxAnhDaiDienSV.Image = null;
                }
            }
        }

        // ===== CÀI ĐẶT TAB ORDER =====
        private void SetTabOrder()
        {
            int tabIndex = 0;
            textBoxMaSV.TabIndex = tabIndex++;
            textBoxHoSV.TabIndex = tabIndex++;
            textBoxTenLotSV.TabIndex = tabIndex++;
            textBoxTenSV.TabIndex = tabIndex++;
            dateTimePickerSV.TabIndex = tabIndex++;
            radioButtonNam.TabIndex = tabIndex++;
            radioButtonNu.TabIndex = tabIndex++;
            textBoxEmail.TabIndex = tabIndex++;
            textBoxSDT.TabIndex = tabIndex++;
            textBoxCCCD.TabIndex = tabIndex++;
            comboBoxLopSV.TabIndex = tabIndex++;
            comboBoxTrangThaiSV.TabIndex = tabIndex++;
            textBoxDiaChi.TabIndex = tabIndex++;
            buttonOKSV.TabIndex = tabIndex++;
            buttonHuyBoSV.TabIndex = tabIndex++;
        }

        // ===== XỬ LÝ BUTTON OK =====
        private void buttonOKSV_Click(object sender, EventArgs e)
        {
            // VALIDATION DỮ LIỆU
            string errorMessage = ValidateInput();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(
                    errorMessage,
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // Không đóng form nếu dữ liệu không hợp lệ
            }

            // TẠO ĐỐI TƯỢNG SINH VIÊN MỚI
            SinhVienMoi = new ThongTinSinhVien();
            SinhVienMoi.MaSV = textBoxMaSV.Text.Trim();
            SinhVienMoi.HoSV = textBoxHoSV.Text.Trim();
            SinhVienMoi.TenLotSV = textBoxTenLotSV.Text.Trim();
            SinhVienMoi.TenSV = textBoxTenSV.Text.Trim();
            SinhVienMoi.NgaySinhSV = dateTimePickerSV.Value.Date;
            SinhVienMoi.GioiTinhSV = radioButtonNam.Checked ? "Nam" : "Nữ";
            SinhVienMoi.CCCDSV = textBoxCCCD.Text.Trim();
            SinhVienMoi.DiaChiSV = textBoxDiaChi.Text.Trim();
            SinhVienMoi.EmailSV = textBoxEmail.Text.Trim();
            SinhVienMoi.LopSV = comboBoxLopSV.Text.Trim();
            SinhVienMoi.TrangThaiSV = comboBoxTrangThaiSV.Text.Trim();
            SinhVienMoi.HinhAnhSV = duongDanAnhDaChon; // Lưu đường dẫn ảnh đã chọn

            // Đóng form với kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ===== XỬ LÝ BUTTON CHỌN ẢNH =====
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Chức năng: Mở hộp thoại chọn file ảnh
         * - Sử dụng OpenFileDialog để người dùng chọn file
         * - Filter chỉ cho phép các file ảnh (jpg, png, gif, bmp)
         * - Load ảnh vào PictureBox để preview
         * - Lưu đường dẫn file vào biến duongDanAnhDaChon
         *
         * OpenFileDialog là gì?
         * - Dialog chuẩn của Windows để chọn file
         * - Có thể filter theo loại file
         * - Trả về đường dẫn đầy đủ của file được chọn
         */
        private void buttonChonAnhSV_Click(object sender, EventArgs e)
        {
            // BƯỚC 1: Tạo OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // BƯỚC 2: Cấu hình OpenFileDialog
                openFileDialog.Title = "Chọn ảnh đại diện sinh viên";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                openFileDialog.FilterIndex = 1; // Mặc định chọn filter đầu tiên
                openFileDialog.RestoreDirectory = true;

                // BƯỚC 3: Hiển thị dialog và kiểm tra kết quả
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // BƯỚC 4: Lưu đường dẫn file đã chọn
                        duongDanAnhDaChon = openFileDialog.FileName;

                        // BƯỚC 5: Load ảnh vào PictureBox
                        // Tạo copy của ảnh để tránh lock file
                        using (Image anhGoc = Image.FromFile(duongDanAnhDaChon))
                        {
                            // Dispose ảnh cũ nếu có (tránh memory leak)
                            if (pictureBoxAnhDaiDienSV.Image != null)
                            {
                                pictureBoxAnhDaiDienSV.Image.Dispose();
                            }

                            // Set ảnh mới
                            pictureBoxAnhDaiDienSV.Image = new Bitmap(anhGoc);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi khi load ảnh (file hỏng, không phải ảnh...)
                        MessageBox.Show(
                            "Không thể tải ảnh!\n\nChi tiết lỗi: " + ex.Message,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        duongDanAnhDaChon = ""; // Reset đường dẫn
                    }
                }
            }
        }

        // ===== VALIDATION DỮ LIỆU =====
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Validation (Xác thực) là gì?
         * - Kiểm tra dữ liệu người dùng nhập vào có hợp lệ không
         * - Ngăn chặn dữ liệu sai/thiếu được lưu vào hệ thống
         *
         * Các loại validation:
         * 1. Required fields: Trường bắt buộc phải có giá trị
         * 2. Format validation: Định dạng email, số điện thoại, CCCD
         * 3. Length validation: Độ dài tối thiểu/tối đa
         * 4. Range validation: Giá trị trong khoảng cho phép
         *
         * NOTE: Validation nên được thực hiện ở CẢẢ CLIENT (Form) và SERVER (BLL)
         * - Client validation: Phản hồi nhanh cho người dùng
         * - Server validation: Bảo mật, ngăn chặn dữ liệu sai từ nguồn khác
         *
         * REFACTORED: Không dùng StringBuilder, dùng string concatenation đơn giản
         */
        private string ValidateInput()
        {
            string errors = ""; // Chuỗi chứa các lỗi (thay vì StringBuilder)

            // 1. KIỂM TRA CÁC TRƯỜNG BẮT BUỘC
            if (string.IsNullOrWhiteSpace(textBoxMaSV.Text))
                errors = errors + "- Mã sinh viên không được để trống\n";

            if (string.IsNullOrWhiteSpace(textBoxHoSV.Text))
                errors = errors + "- Họ sinh viên không được để trống\n";

            if (string.IsNullOrWhiteSpace(textBoxTenSV.Text))
                errors = errors + "- Tên sinh viên không được để trống\n";

            // 2. KIỂM TRA ĐỊNH DẠNG EMAIL
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                if (!IsValidEmail(textBoxEmail.Text.Trim()))
                    errors = errors + "- Email không đúng định dạng\n";
            }

            // 3. KIỂM TRA CCCD (12 chữ số)
            if (!string.IsNullOrWhiteSpace(textBoxCCCD.Text))
            {
                string cccd = textBoxCCCD.Text.Trim();
                if (!IsNumeric(cccd) || cccd.Length != 12)
                    errors = errors + "- CCCD phải là 12 chữ số\n";
            }

            // 4. KIỂM TRA SỐ ĐIỆN THOẠI (10 chữ số)
            if (!string.IsNullOrWhiteSpace(textBoxSDT.Text))
            {
                string sdt = textBoxSDT.Text.Trim();
                if (!IsNumeric(sdt) || sdt.Length != 10)
                    errors = errors + "- Số điện thoại phải là 10 chữ số\n";
            }

            // 5. KIỂM TRA NGÀY SINH (phải >= 18 tuổi)
            DateTime ngaySinh = dateTimePickerSV.Value.Date;
            int tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (ngaySinh > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18)
                errors = errors + "- Sinh viên phải đủ 18 tuổi\n";

            // 6. KIỂM TRA COMBOBOX
            if (string.IsNullOrWhiteSpace(comboBoxLopSV.Text))
                errors = errors + "- Vui lòng chọn lớp\n";

            if (string.IsNullOrWhiteSpace(comboBoxTrangThaiSV.Text))
                errors = errors + "- Vui lòng chọn trạng thái\n";

            return errors;
        }

        // ===== HELPER METHODS =====

        // Kiểm tra email hợp lệ
        // REFACTORED: Không dùng Regex, dùng logic thủ công
        /*
         * GIẢI THÍCH CHO SINH VIÊN:
         *
         * Email hợp lệ cần có các điều kiện:
         * 1. Có đúng 1 ký tự '@'
         * 2. '@' không ở đầu hoặc cuối
         * 3. Có ít nhất 1 dấu '.' sau '@'
         * 4. Dấu '.' cuối không ở vị trí cuối cùng
         * 5. Không có khoảng trắng
         *
         * VD hợp lệ: abc@gmail.com, student@university.edu.vn
         * VD không hợp lệ: abc, @gmail.com, abc@, abc @gmail.com
         */
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // BƯỚC 1: Kiểm tra có khoảng trắng không (email không được chứa khoảng trắng)
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == ' ')
                    return false;
            }

            // BƯỚC 2: Tìm vị trí của ký tự '@'
            int viTriAt = -1; // Vị trí của '@'
            int soLuongAt = 0; // Số lượng '@'

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    viTriAt = i;
                    soLuongAt++;
                }
            }

            // Kiểm tra: phải có đúng 1 '@' và không ở đầu/cuối
            if (soLuongAt != 1 || viTriAt == 0 || viTriAt == email.Length - 1)
                return false;

            // BƯỚC 3: Kiểm tra phần sau '@' phải có ít nhất 1 dấu '.'
            bool coDauChamSauAt = false;
            int viTriDauChamCuoi = -1;

            for (int i = viTriAt + 1; i < email.Length; i++)
            {
                if (email[i] == '.')
                {
                    coDauChamSauAt = true;
                    viTriDauChamCuoi = i;
                }
            }

            // Kiểm tra: phải có dấu '.' sau '@' và dấu '.' không ở cuối
            if (!coDauChamSauAt || viTriDauChamCuoi == email.Length - 1)
                return false;

            // BƯỚC 4: Kiểm tra dấu '.' không đứng liền sau '@'
            if (email[viTriAt + 1] == '.')
                return false;

            return true;
        }

        // Kiểm tra chuỗi toàn số
        // Sử dụng: String manipulation (theo yêu cầu không dùng built-in)
        private bool IsNumeric(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            // Duyệt từng ký tự
            for (int i = 0; i < str.Length; i++)
            {
                // Kiểm tra ký tự có phải số không (0-9)
                if (str[i] < '0' || str[i] > '9')
                    return false;
            }
            return true;
        }

        // ===== XỬ LÝ FORMCLOSING (GIỮ LẠI ĐỂ TƯƠNG THÍCH) =====
        // NOTE: Logic chính đã chuyển sang buttonOKSV_Click
        private void FormThemThongTinSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Không cần xử lý gì ở đây nữa
            // Logic đã được di chuyển sang buttonOKSV_Click
        }

        /*
         * ==================== TÓM TẮT CẢI TIẾN ====================
         *
         * 1. VALIDATION:
         *    - Kiểm tra required fields
         *    - Kiểm tra định dạng email, CCCD, SĐT
         *    - Kiểm tra tuổi >= 18
         *
         * 2. POPULATE DATA:
         *    - Hiển thị dữ liệu khi chỉnh sửa
         *    - Không cho sửa mã SV khi edit
         *
         * 3. COMBOBOX:
         *    - Khởi tạo items cho Lớp và Trạng thái
         *    - Set giá trị mặc định
         *
         * 4. UX IMPROVEMENTS:
         *    - Tab order cho dễ nhập liệu
         *    - Error messages rõ ràng
         *    - Không đóng form nếu dữ liệu sai
         *    - Center form trên parent
         *
         * 5. CODE ORGANIZATION:
         *    - Tách validation thành method riêng
         *    - Helper methods cho email/numeric check
         *    - Comments chi tiết giải thích
         *
         * ==================== END TÓM TẮT ====================
         */
    }
}

