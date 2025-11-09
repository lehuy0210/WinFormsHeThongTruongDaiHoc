namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Sinh_Vien
{
    partial class FormTimKiemThongTinSV
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
            buttonTimKiemOK = new Button();
            buttonTimKiemHuyBo = new Button();
            labelTitleTimKiem = new Label();
            comboBoxTimKiemSV = new ComboBox();
            richTextBoxTimKiemSV = new RichTextBox();
            labelHuongDan = new Label();
            groupBoxTimKiem = new GroupBox();
            labelTieuChi = new Label();
            labelGiaTri = new Label();
            groupBoxTimKiem.SuspendLayout();
            SuspendLayout();
            //
            // labelTitleTimKiem
            //
            labelTitleTimKiem.Dock = DockStyle.Top;
            labelTitleTimKiem.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitleTimKiem.ForeColor = Color.FromArgb(0, 120, 215);
            labelTitleTimKiem.Location = new Point(0, 0);
            labelTitleTimKiem.Name = "labelTitleTimKiem";
            labelTitleTimKiem.Size = new Size(460, 50);
            labelTitleTimKiem.TabIndex = 0;
            labelTitleTimKiem.Text = "TÌM KIẾM SINH VIÊN";
            labelTitleTimKiem.TextAlign = ContentAlignment.MiddleCenter;
            //
            // groupBoxTimKiem
            //
            groupBoxTimKiem.Controls.Add(labelGiaTri);
            groupBoxTimKiem.Controls.Add(labelTieuChi);
            groupBoxTimKiem.Controls.Add(richTextBoxTimKiemSV);
            groupBoxTimKiem.Controls.Add(comboBoxTimKiemSV);
            groupBoxTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxTimKiem.ForeColor = Color.FromArgb(0, 120, 215);
            groupBoxTimKiem.Location = new Point(20, 70);
            groupBoxTimKiem.Name = "groupBoxTimKiem";
            groupBoxTimKiem.Padding = new Padding(15);
            groupBoxTimKiem.Size = new Size(420, 280);
            groupBoxTimKiem.TabIndex = 1;
            groupBoxTimKiem.TabStop = false;
            groupBoxTimKiem.Text = "Thông Tin Tìm Kiếm";
            //
            // labelTieuChi
            //
            labelTieuChi.AutoSize = true;
            labelTieuChi.Font = new Font("Segoe UI", 10F);
            labelTieuChi.ForeColor = SystemColors.ControlText;
            labelTieuChi.Location = new Point(20, 35);
            labelTieuChi.Name = "labelTieuChi";
            labelTieuChi.Size = new Size(134, 23);
            labelTieuChi.TabIndex = 0;
            labelTieuChi.Text = "Tiêu chí tìm kiếm:";
            //
            // comboBoxTimKiemSV
            //
            comboBoxTimKiemSV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimKiemSV.Font = new Font("Segoe UI", 11F);
            comboBoxTimKiemSV.FormattingEnabled = true;
            comboBoxTimKiemSV.Items.AddRange(new object[] { "Mã Sinh Viên", "Họ và Tên", "Mã Số Sinh Viên", "Căn Cước Công Dân", "Số Điện Thoại" });
            comboBoxTimKiemSV.Location = new Point(20, 65);
            comboBoxTimKiemSV.Name = "comboBoxTimKiemSV";
            comboBoxTimKiemSV.Size = new Size(380, 33);
            comboBoxTimKiemSV.TabIndex = 0;
            //
            // labelGiaTri
            //
            labelGiaTri.AutoSize = true;
            labelGiaTri.Font = new Font("Segoe UI", 10F);
            labelGiaTri.ForeColor = SystemColors.ControlText;
            labelGiaTri.Location = new Point(20, 110);
            labelGiaTri.Name = "labelGiaTri";
            labelGiaTri.Size = new Size(155, 23);
            labelGiaTri.TabIndex = 0;
            labelGiaTri.Text = "Giá trị cần tìm kiếm:";
            //
            // richTextBoxTimKiemSV
            //
            richTextBoxTimKiemSV.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxTimKiemSV.Font = new Font("Segoe UI", 11F);
            richTextBoxTimKiemSV.Location = new Point(20, 140);
            richTextBoxTimKiemSV.Name = "richTextBoxTimKiemSV";
            richTextBoxTimKiemSV.Size = new Size(380, 120);
            richTextBoxTimKiemSV.TabIndex = 1;
            richTextBoxTimKiemSV.Text = "";
            //
            // labelHuongDan
            //
            labelHuongDan.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            labelHuongDan.ForeColor = Color.FromArgb(100, 100, 100);
            labelHuongDan.Location = new Point(20, 360);
            labelHuongDan.Name = "labelHuongDan";
            labelHuongDan.Size = new Size(420, 40);
            labelHuongDan.TabIndex = 2;
            labelHuongDan.Text = "Lưu ý: Với tìm kiếm theo \"Họ và Tên\", bạn có thể nhập họ tên đầy đủ\nhoặc chỉ một phần của họ tên.";
            labelHuongDan.TextAlign = ContentAlignment.MiddleCenter;
            //
            // buttonTimKiemOK
            //
            buttonTimKiemOK.BackColor = Color.FromArgb(0, 120, 215);
            buttonTimKiemOK.Cursor = Cursors.Hand;
            buttonTimKiemOK.FlatStyle = FlatStyle.Flat;
            buttonTimKiemOK.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonTimKiemOK.ForeColor = Color.White;
            buttonTimKiemOK.Location = new Point(90, 415);
            buttonTimKiemOK.Name = "buttonTimKiemOK";
            buttonTimKiemOK.Size = new Size(140, 45);
            buttonTimKiemOK.TabIndex = 3;
            buttonTimKiemOK.Text = "🔍 Tìm kiếm";
            buttonTimKiemOK.UseVisualStyleBackColor = false;
            //
            // buttonTimKiemHuyBo
            //
            buttonTimKiemHuyBo.BackColor = Color.FromArgb(240, 240, 240);
            buttonTimKiemHuyBo.Cursor = Cursors.Hand;
            buttonTimKiemHuyBo.FlatStyle = FlatStyle.Flat;
            buttonTimKiemHuyBo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonTimKiemHuyBo.ForeColor = Color.FromArgb(64, 64, 64);
            buttonTimKiemHuyBo.Location = new Point(240, 415);
            buttonTimKiemHuyBo.Name = "buttonTimKiemHuyBo";
            buttonTimKiemHuyBo.Size = new Size(140, 45);
            buttonTimKiemHuyBo.TabIndex = 4;
            buttonTimKiemHuyBo.Text = "✕ Hủy bỏ";
            buttonTimKiemHuyBo.UseVisualStyleBackColor = false;
            //
            // FormTimKiemThongTinSV
            //
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(460, 480);
            Controls.Add(buttonTimKiemHuyBo);
            Controls.Add(buttonTimKiemOK);
            Controls.Add(labelHuongDan);
            Controls.Add(groupBoxTimKiem);
            Controls.Add(labelTitleTimKiem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTimKiemThongTinSV";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tìm Kiếm Thông Tin Sinh Viên";
            FormClosing += FormTimKiemThongTinSV_FormClosing;
            groupBoxTimKiem.ResumeLayout(false);
            groupBoxTimKiem.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonTimKiemOK;
        private System.Windows.Forms.Button buttonTimKiemHuyBo;
        private System.Windows.Forms.Label labelTitleTimKiem;
        private System.Windows.Forms.ComboBox comboBoxTimKiemSV;
        private System.Windows.Forms.RichTextBox richTextBoxTimKiemSV;
        private System.Windows.Forms.Label labelHuongDan;
        private System.Windows.Forms.GroupBox groupBoxTimKiem;
        private System.Windows.Forms.Label labelTieuChi;
        private System.Windows.Forms.Label labelGiaTri;
    }
}
