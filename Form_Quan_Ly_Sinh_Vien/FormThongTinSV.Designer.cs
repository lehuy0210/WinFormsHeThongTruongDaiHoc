namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien
{
    partial class FormThongTinSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTenForm = new Label();
            groupBoxThongTinCaNhan = new GroupBox();
            textBoxTenSV = new TextBox();
            textBoxTenLotSV = new TextBox();
            textBoxHoSV = new TextBox();
            textBoxMaSV = new TextBox();
            radioButtonNu = new RadioButton();
            radioButtonNam = new RadioButton();
            dateTimePickerSV = new DateTimePicker();
            labelGioiTinh = new Label();
            labelNgaySinh = new Label();
            labelTenSV = new Label();
            labelTenLotSV = new Label();
            labelHoSV = new Label();
            labelMaSV = new Label();
            groupBoxThongTinLienLac = new GroupBox();
            textBoxDiaChi = new TextBox();
            textBoxCCCD = new TextBox();
            textBoxSDT = new TextBox();
            textBoxEmail = new TextBox();
            labelDiaChi = new Label();
            labelCCCD = new Label();
            labelSDT = new Label();
            labelEmail = new Label();
            groupBoxThongTinHocVu = new GroupBox();
            comboBoxTrangThaiSV = new ComboBox();
            comboBoxLopSV = new ComboBox();
            labelTrangThaiSV = new Label();
            labelLop = new Label();
            buttonOKSV = new Button();
            buttonHuyBoSV = new Button();
            pictureBoxAnhDaiDienSV = new PictureBox();
            buttonChonAnhSV = new Button();
            groupBoxThongTinCaNhan.SuspendLayout();
            groupBoxThongTinLienLac.SuspendLayout();
            groupBoxThongTinHocVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnhDaiDienSV).BeginInit();
            SuspendLayout();
            //
            // labelTenForm
            //
            labelTenForm.Dock = DockStyle.Top;
            labelTenForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTenForm.ForeColor = Color.FromArgb(0, 120, 215);
            labelTenForm.Location = new Point(0, 0);
            labelTenForm.Name = "labelTenForm";
            labelTenForm.Size = new Size(884, 50);
            labelTenForm.TabIndex = 0;
            labelTenForm.Text = "THÔNG TIN CHI TIẾT";
            labelTenForm.TextAlign = ContentAlignment.MiddleCenter;
            //
            // groupBoxThongTinCaNhan
            //
            groupBoxThongTinCaNhan.Controls.Add(textBoxTenSV);
            groupBoxThongTinCaNhan.Controls.Add(textBoxTenLotSV);
            groupBoxThongTinCaNhan.Controls.Add(textBoxHoSV);
            groupBoxThongTinCaNhan.Controls.Add(textBoxMaSV);
            groupBoxThongTinCaNhan.Controls.Add(radioButtonNu);
            groupBoxThongTinCaNhan.Controls.Add(radioButtonNam);
            groupBoxThongTinCaNhan.Controls.Add(dateTimePickerSV);
            groupBoxThongTinCaNhan.Controls.Add(labelGioiTinh);
            groupBoxThongTinCaNhan.Controls.Add(labelNgaySinh);
            groupBoxThongTinCaNhan.Controls.Add(labelTenSV);
            groupBoxThongTinCaNhan.Controls.Add(labelTenLotSV);
            groupBoxThongTinCaNhan.Controls.Add(labelHoSV);
            groupBoxThongTinCaNhan.Controls.Add(labelMaSV);
            groupBoxThongTinCaNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTinCaNhan.ForeColor = Color.FromArgb(0, 120, 215);
            groupBoxThongTinCaNhan.Location = new Point(20, 60);
            groupBoxThongTinCaNhan.Name = "groupBoxThongTinCaNhan";
            groupBoxThongTinCaNhan.Padding = new Padding(10);
            groupBoxThongTinCaNhan.Size = new Size(640, 180);
            groupBoxThongTinCaNhan.TabIndex = 1;
            groupBoxThongTinCaNhan.TabStop = false;
            groupBoxThongTinCaNhan.Text = "Thông Tin Cá Nhân";
            //
            // textBoxTenSV
            //
            textBoxTenSV.Font = new Font("Segoe UI", 10F);
            textBoxTenSV.Location = new Point(490, 65);
            textBoxTenSV.Name = "textBoxTenSV";
            textBoxTenSV.Size = new Size(130, 30);
            textBoxTenSV.TabIndex = 3;
            //
            // textBoxTenLotSV
            //
            textBoxTenLotSV.Font = new Font("Segoe UI", 10F);
            textBoxTenLotSV.Location = new Point(340, 65);
            textBoxTenLotSV.Name = "textBoxTenLotSV";
            textBoxTenLotSV.Size = new Size(130, 30);
            textBoxTenLotSV.TabIndex = 2;
            //
            // textBoxHoSV
            //
            textBoxHoSV.Font = new Font("Segoe UI", 10F);
            textBoxHoSV.Location = new Point(180, 65);
            textBoxHoSV.Name = "textBoxHoSV";
            textBoxHoSV.Size = new Size(130, 30);
            textBoxHoSV.TabIndex = 1;
            //
            // textBoxMaSV
            //
            textBoxMaSV.Font = new Font("Segoe UI", 10F);
            textBoxMaSV.Location = new Point(180, 30);
            textBoxMaSV.Name = "textBoxMaSV";
            textBoxMaSV.Size = new Size(180, 30);
            textBoxMaSV.TabIndex = 0;
            //
            // radioButtonNu
            //
            radioButtonNu.AutoSize = true;
            radioButtonNu.Font = new Font("Segoe UI", 10F);
            radioButtonNu.ForeColor = SystemColors.ControlText;
            radioButtonNu.Location = new Point(280, 140);
            radioButtonNu.Name = "radioButtonNu";
            radioButtonNu.Size = new Size(51, 27);
            radioButtonNu.TabIndex = 6;
            radioButtonNu.Text = "Nữ";
            radioButtonNu.UseVisualStyleBackColor = true;
            //
            // radioButtonNam
            //
            radioButtonNam.AutoSize = true;
            radioButtonNam.Checked = true;
            radioButtonNam.Font = new Font("Segoe UI", 10F);
            radioButtonNam.ForeColor = SystemColors.ControlText;
            radioButtonNam.Location = new Point(180, 140);
            radioButtonNam.Name = "radioButtonNam";
            radioButtonNam.Size = new Size(65, 27);
            radioButtonNam.TabIndex = 5;
            radioButtonNam.TabStop = true;
            radioButtonNam.Text = "Nam";
            radioButtonNam.UseVisualStyleBackColor = true;
            //
            // dateTimePickerSV
            //
            dateTimePickerSV.Font = new Font("Segoe UI", 10F);
            dateTimePickerSV.Format = DateTimePickerFormat.Short;
            dateTimePickerSV.Location = new Point(180, 100);
            dateTimePickerSV.Name = "dateTimePickerSV";
            dateTimePickerSV.Size = new Size(180, 30);
            dateTimePickerSV.TabIndex = 4;
            //
            // labelGioiTinh
            //
            labelGioiTinh.AutoSize = true;
            labelGioiTinh.Font = new Font("Segoe UI", 10F);
            labelGioiTinh.ForeColor = SystemColors.ControlText;
            labelGioiTinh.Location = new Point(20, 142);
            labelGioiTinh.Name = "labelGioiTinh";
            labelGioiTinh.Size = new Size(89, 23);
            labelGioiTinh.TabIndex = 0;
            labelGioiTinh.Text = "Giới tính: *";
            //
            // labelNgaySinh
            //
            labelNgaySinh.AutoSize = true;
            labelNgaySinh.Font = new Font("Segoe UI", 10F);
            labelNgaySinh.ForeColor = SystemColors.ControlText;
            labelNgaySinh.Location = new Point(20, 103);
            labelNgaySinh.Name = "labelNgaySinh";
            labelNgaySinh.Size = new Size(101, 23);
            labelNgaySinh.TabIndex = 0;
            labelNgaySinh.Text = "Ngày sinh: *";
            //
            // labelTenSV
            //
            labelTenSV.AutoSize = true;
            labelTenSV.Font = new Font("Segoe UI", 10F);
            labelTenSV.ForeColor = SystemColors.ControlText;
            labelTenSV.Location = new Point(490, 37);
            labelTenSV.Name = "labelTenSV";
            labelTenSV.Size = new Size(49, 23);
            labelTenSV.TabIndex = 0;
            labelTenSV.Text = "Tên: *";
            //
            // labelTenLotSV
            //
            labelTenLotSV.AutoSize = true;
            labelTenLotSV.Font = new Font("Segoe UI", 10F);
            labelTenLotSV.ForeColor = SystemColors.ControlText;
            labelTenLotSV.Location = new Point(340, 37);
            labelTenLotSV.Name = "labelTenLotSV";
            labelTenLotSV.Size = new Size(66, 23);
            labelTenLotSV.TabIndex = 0;
            labelTenLotSV.Text = "Tên lót:";
            //
            // labelHoSV
            //
            labelHoSV.AutoSize = true;
            labelHoSV.Font = new Font("Segoe UI", 10F);
            labelHoSV.ForeColor = SystemColors.ControlText;
            labelHoSV.Location = new Point(180, 37);
            labelHoSV.Name = "labelHoSV";
            labelHoSV.Size = new Size(44, 23);
            labelHoSV.TabIndex = 0;
            labelHoSV.Text = "Họ: *";
            //
            // labelMaSV
            //
            labelMaSV.AutoSize = true;
            labelMaSV.Font = new Font("Segoe UI", 10F);
            labelMaSV.ForeColor = SystemColors.ControlText;
            labelMaSV.Location = new Point(20, 33);
            labelMaSV.Name = "labelMaSV";
            labelMaSV.Size = new Size(122, 23);
            labelMaSV.TabIndex = 0;
            labelMaSV.Text = "Mã sinh viên: *";
            //
            // groupBoxThongTinLienLac
            //
            groupBoxThongTinLienLac.Controls.Add(textBoxDiaChi);
            groupBoxThongTinLienLac.Controls.Add(textBoxCCCD);
            groupBoxThongTinLienLac.Controls.Add(textBoxSDT);
            groupBoxThongTinLienLac.Controls.Add(textBoxEmail);
            groupBoxThongTinLienLac.Controls.Add(labelDiaChi);
            groupBoxThongTinLienLac.Controls.Add(labelCCCD);
            groupBoxThongTinLienLac.Controls.Add(labelSDT);
            groupBoxThongTinLienLac.Controls.Add(labelEmail);
            groupBoxThongTinLienLac.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTinLienLac.ForeColor = Color.FromArgb(0, 120, 215);
            groupBoxThongTinLienLac.Location = new Point(20, 250);
            groupBoxThongTinLienLac.Name = "groupBoxThongTinLienLac";
            groupBoxThongTinLienLac.Padding = new Padding(10);
            groupBoxThongTinLienLac.Size = new Size(640, 180);
            groupBoxThongTinLienLac.TabIndex = 2;
            groupBoxThongTinLienLac.TabStop = false;
            groupBoxThongTinLienLac.Text = "Thông Tin Liên Lạc";
            //
            // textBoxDiaChi
            //
            textBoxDiaChi.Font = new Font("Segoe UI", 10F);
            textBoxDiaChi.Location = new Point(180, 135);
            textBoxDiaChi.Name = "textBoxDiaChi";
            textBoxDiaChi.Size = new Size(440, 30);
            textBoxDiaChi.TabIndex = 3;
            //
            // textBoxCCCD
            //
            textBoxCCCD.Font = new Font("Segoe UI", 10F);
            textBoxCCCD.Location = new Point(180, 100);
            textBoxCCCD.MaxLength = 12;
            textBoxCCCD.Name = "textBoxCCCD";
            textBoxCCCD.Size = new Size(200, 30);
            textBoxCCCD.TabIndex = 2;
            //
            // textBoxSDT
            //
            textBoxSDT.Font = new Font("Segoe UI", 10F);
            textBoxSDT.Location = new Point(180, 65);
            textBoxSDT.MaxLength = 10;
            textBoxSDT.Name = "textBoxSDT";
            textBoxSDT.Size = new Size(200, 30);
            textBoxSDT.TabIndex = 1;
            //
            // textBoxEmail
            //
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(180, 30);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(440, 30);
            textBoxEmail.TabIndex = 0;
            //
            // labelDiaChi
            //
            labelDiaChi.AutoSize = true;
            labelDiaChi.Font = new Font("Segoe UI", 10F);
            labelDiaChi.ForeColor = SystemColors.ControlText;
            labelDiaChi.Location = new Point(20, 138);
            labelDiaChi.Name = "labelDiaChi";
            labelDiaChi.Size = new Size(66, 23);
            labelDiaChi.TabIndex = 0;
            labelDiaChi.Text = "Địa chỉ:";
            //
            // labelCCCD
            //
            labelCCCD.AutoSize = true;
            labelCCCD.Font = new Font("Segoe UI", 10F);
            labelCCCD.ForeColor = SystemColors.ControlText;
            labelCCCD.Location = new Point(20, 103);
            labelCCCD.Name = "labelCCCD";
            labelCCCD.Size = new Size(61, 23);
            labelCCCD.TabIndex = 0;
            labelCCCD.Text = "CCCD:";
            //
            // labelSDT
            //
            labelSDT.AutoSize = true;
            labelSDT.Font = new Font("Segoe UI", 10F);
            labelSDT.ForeColor = SystemColors.ControlText;
            labelSDT.Location = new Point(20, 68);
            labelSDT.Name = "labelSDT";
            labelSDT.Size = new Size(122, 23);
            labelSDT.TabIndex = 0;
            labelSDT.Text = "Số điện thoại:";
            //
            // labelEmail
            //
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F);
            labelEmail.ForeColor = SystemColors.ControlText;
            labelEmail.Location = new Point(20, 33);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(55, 23);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Email:";
            //
            // groupBoxThongTinHocVu
            //
            groupBoxThongTinHocVu.Controls.Add(comboBoxTrangThaiSV);
            groupBoxThongTinHocVu.Controls.Add(comboBoxLopSV);
            groupBoxThongTinHocVu.Controls.Add(labelTrangThaiSV);
            groupBoxThongTinHocVu.Controls.Add(labelLop);
            groupBoxThongTinHocVu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTinHocVu.ForeColor = Color.FromArgb(0, 120, 215);
            groupBoxThongTinHocVu.Location = new Point(20, 440);
            groupBoxThongTinHocVu.Name = "groupBoxThongTinHocVu";
            groupBoxThongTinHocVu.Padding = new Padding(10);
            groupBoxThongTinHocVu.Size = new Size(640, 100);
            groupBoxThongTinHocVu.TabIndex = 3;
            groupBoxThongTinHocVu.TabStop = false;
            groupBoxThongTinHocVu.Text = "Thông Tin Học Vụ";
            //
            // comboBoxTrangThaiSV
            //
            comboBoxTrangThaiSV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTrangThaiSV.Font = new Font("Segoe UI", 10F);
            comboBoxTrangThaiSV.FormattingEnabled = true;
            comboBoxTrangThaiSV.Location = new Point(410, 50);
            comboBoxTrangThaiSV.Name = "comboBoxTrangThaiSV";
            comboBoxTrangThaiSV.Size = new Size(210, 31);
            comboBoxTrangThaiSV.TabIndex = 1;
            //
            // comboBoxLopSV
            //
            comboBoxLopSV.Font = new Font("Segoe UI", 10F);
            comboBoxLopSV.FormattingEnabled = true;
            comboBoxLopSV.Location = new Point(180, 50);
            comboBoxLopSV.Name = "comboBoxLopSV";
            comboBoxLopSV.Size = new Size(150, 31);
            comboBoxLopSV.TabIndex = 0;
            //
            // labelTrangThaiSV
            //
            labelTrangThaiSV.AutoSize = true;
            labelTrangThaiSV.Font = new Font("Segoe UI", 10F);
            labelTrangThaiSV.ForeColor = SystemColors.ControlText;
            labelTrangThaiSV.Location = new Point(410, 27);
            labelTrangThaiSV.Name = "labelTrangThaiSV";
            labelTrangThaiSV.Size = new Size(103, 23);
            labelTrangThaiSV.TabIndex = 0;
            labelTrangThaiSV.Text = "Trạng thái: *";
            //
            // labelLop
            //
            labelLop.AutoSize = true;
            labelLop.Font = new Font("Segoe UI", 10F);
            labelLop.ForeColor = SystemColors.ControlText;
            labelLop.Location = new Point(180, 27);
            labelLop.Name = "labelLop";
            labelLop.Size = new Size(51, 23);
            labelLop.TabIndex = 0;
            labelLop.Text = "Lớp: *";
            //
            // buttonOKSV
            //
            buttonOKSV.BackColor = Color.FromArgb(0, 120, 215);
            buttonOKSV.Cursor = Cursors.Hand;
            buttonOKSV.FlatStyle = FlatStyle.Flat;
            buttonOKSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonOKSV.ForeColor = Color.White;
            buttonOKSV.Location = new Point(490, 560);
            buttonOKSV.Name = "buttonOKSV";
            buttonOKSV.Size = new Size(160, 45);
            buttonOKSV.TabIndex = 4;
            buttonOKSV.Text = "✓ Lưu";
            buttonOKSV.UseVisualStyleBackColor = false;
            //
            // buttonHuyBoSV
            //
            buttonHuyBoSV.BackColor = Color.FromArgb(240, 240, 240);
            buttonHuyBoSV.Cursor = Cursors.Hand;
            buttonHuyBoSV.FlatStyle = FlatStyle.Flat;
            buttonHuyBoSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonHuyBoSV.ForeColor = Color.FromArgb(64, 64, 64);
            buttonHuyBoSV.Location = new Point(680, 560);
            buttonHuyBoSV.Name = "buttonHuyBoSV";
            buttonHuyBoSV.Size = new Size(160, 45);
            buttonHuyBoSV.TabIndex = 5;
            buttonHuyBoSV.Text = "✕ Hủy bỏ";
            buttonHuyBoSV.UseVisualStyleBackColor = false;
            //
            // pictureBoxAnhDaiDienSV
            //
            pictureBoxAnhDaiDienSV.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAnhDaiDienSV.Location = new Point(680, 70);
            pictureBoxAnhDaiDienSV.Name = "pictureBoxAnhDaiDienSV";
            pictureBoxAnhDaiDienSV.Size = new Size(180, 220);
            pictureBoxAnhDaiDienSV.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAnhDaiDienSV.TabIndex = 6;
            pictureBoxAnhDaiDienSV.TabStop = false;
            //
            // buttonChonAnhSV
            //
            buttonChonAnhSV.BackColor = Color.FromArgb(240, 240, 240);
            buttonChonAnhSV.Cursor = Cursors.Hand;
            buttonChonAnhSV.FlatStyle = FlatStyle.Flat;
            buttonChonAnhSV.Font = new Font("Segoe UI", 9F);
            buttonChonAnhSV.ForeColor = Color.FromArgb(64, 64, 64);
            buttonChonAnhSV.Location = new Point(680, 300);
            buttonChonAnhSV.Name = "buttonChonAnhSV";
            buttonChonAnhSV.Size = new Size(180, 35);
            buttonChonAnhSV.TabIndex = 7;
            buttonChonAnhSV.Text = "📁 Chọn ảnh...";
            buttonChonAnhSV.UseVisualStyleBackColor = false;
            //
            // FormThongTinSV
            //
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(884, 620);
            Controls.Add(buttonChonAnhSV);
            Controls.Add(pictureBoxAnhDaiDienSV);
            Controls.Add(buttonHuyBoSV);
            Controls.Add(buttonOKSV);
            Controls.Add(groupBoxThongTinHocVu);
            Controls.Add(groupBoxThongTinLienLac);
            Controls.Add(groupBoxThongTinCaNhan);
            Controls.Add(labelTenForm);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormThongTinSV";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông Tin Sinh Viên";
            FormClosing += FormThemThongTinSV_FormClosing;
            groupBoxThongTinCaNhan.ResumeLayout(false);
            groupBoxThongTinCaNhan.PerformLayout();
            groupBoxThongTinLienLac.ResumeLayout(false);
            groupBoxThongTinLienLac.PerformLayout();
            groupBoxThongTinHocVu.ResumeLayout(false);
            groupBoxThongTinHocVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnhDaiDienSV).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTenForm;
        private System.Windows.Forms.GroupBox groupBoxThongTinCaNhan;
        private System.Windows.Forms.GroupBox groupBoxThongTinLienLac;
        private System.Windows.Forms.GroupBox groupBoxThongTinHocVu;
        private System.Windows.Forms.Label labelMaSV;
        private System.Windows.Forms.TextBox textBoxMaSV;
        private System.Windows.Forms.Label labelHoSV;
        private System.Windows.Forms.TextBox textBoxHoSV;
        private System.Windows.Forms.Label labelTenLotSV;
        private System.Windows.Forms.TextBox textBoxTenLotSV;
        private System.Windows.Forms.Label labelTenSV;
        private System.Windows.Forms.TextBox textBoxTenSV;
        private System.Windows.Forms.Label labelNgaySinh;
        private System.Windows.Forms.DateTimePicker dateTimePickerSV;
        private System.Windows.Forms.Label labelGioiTinh;
        private System.Windows.Forms.RadioButton radioButtonNam;
        private System.Windows.Forms.RadioButton radioButtonNu;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelSDT;
        private System.Windows.Forms.TextBox textBoxSDT;
        private System.Windows.Forms.Label labelCCCD;
        private System.Windows.Forms.TextBox textBoxCCCD;
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.Label labelLop;
        private System.Windows.Forms.ComboBox comboBoxLopSV;
        private System.Windows.Forms.Label labelTrangThaiSV;
        private System.Windows.Forms.ComboBox comboBoxTrangThaiSV;
        private System.Windows.Forms.Button buttonOKSV;
        private System.Windows.Forms.Button buttonHuyBoSV;
        private System.Windows.Forms.PictureBox pictureBoxAnhDaiDienSV;
        private System.Windows.Forms.Button buttonChonAnhSV;
    }
}
