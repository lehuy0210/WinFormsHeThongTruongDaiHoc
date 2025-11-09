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
            SuspendLayout();
            // 
            // buttonTimKiemOK
            // 
            buttonTimKiemOK.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            buttonTimKiemOK.Location = new Point(16, 335);
            buttonTimKiemOK.Margin = new Padding(4, 5, 4, 5);
            buttonTimKiemOK.Name = "buttonTimKiemOK";
            buttonTimKiemOK.Size = new Size(149, 109);
            buttonTimKiemOK.TabIndex = 1;
            buttonTimKiemOK.Text = "OK";
            buttonTimKiemOK.UseVisualStyleBackColor = true;
            // 
            // buttonTimKiemHuyBo
            // 
            buttonTimKiemHuyBo.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonTimKiemHuyBo.Location = new Point(229, 335);
            buttonTimKiemHuyBo.Margin = new Padding(4, 5, 4, 5);
            buttonTimKiemHuyBo.Name = "buttonTimKiemHuyBo";
            buttonTimKiemHuyBo.Size = new Size(143, 109);
            buttonTimKiemHuyBo.TabIndex = 2;
            buttonTimKiemHuyBo.Text = "HỦY BỎ";
            buttonTimKiemHuyBo.UseVisualStyleBackColor = true;
            // 
            // labelTitleTimKiem
            // 
            labelTitleTimKiem.AutoSize = true;
            labelTitleTimKiem.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTitleTimKiem.Location = new Point(115, 14);
            labelTitleTimKiem.Margin = new Padding(4, 0, 4, 0);
            labelTitleTimKiem.Name = "labelTitleTimKiem";
            labelTitleTimKiem.Size = new Size(155, 34);
            labelTitleTimKiem.TabIndex = 3;
            labelTitleTimKiem.Text = "TÌM KIẾM";
            // 
            // comboBoxTimKiemSV
            // 
            comboBoxTimKiemSV.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            comboBoxTimKiemSV.FormattingEnabled = true;
            comboBoxTimKiemSV.Items.AddRange(new object[] { "Mã Sinh Viên", "Họ và Tên", "Mã Số Sinh Viên", "Căn Cước Công Dân", "Số Điện Thoại" });
            comboBoxTimKiemSV.Location = new Point(16, 66);
            comboBoxTimKiemSV.Margin = new Padding(4, 5, 4, 5);
            comboBoxTimKiemSV.Name = "comboBoxTimKiemSV";
            comboBoxTimKiemSV.Size = new Size(355, 30);
            comboBoxTimKiemSV.TabIndex = 4;
            // 
            // richTextBoxTimKiemSV
            // 
            richTextBoxTimKiemSV.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            richTextBoxTimKiemSV.Location = new Point(16, 137);
            richTextBoxTimKiemSV.Margin = new Padding(4, 5, 4, 5);
            richTextBoxTimKiemSV.Name = "richTextBoxTimKiemSV";
            richTextBoxTimKiemSV.Size = new Size(355, 152);
            richTextBoxTimKiemSV.TabIndex = 0;
            richTextBoxTimKiemSV.Text = "";
            // 
            // FormTimKiemThongTinSV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 486);
            Controls.Add(comboBoxTimKiemSV);
            Controls.Add(labelTitleTimKiem);
            Controls.Add(buttonTimKiemHuyBo);
            Controls.Add(buttonTimKiemOK);
            Controls.Add(richTextBoxTimKiemSV);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormTimKiemThongTinSV";
            Text = "Tìm Kiếm Thông Tin Sinh Viên";
            FormClosing += FormTimKiemThongTinSV_FormClosing;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonTimKiemOK;
        private System.Windows.Forms.Button buttonTimKiemHuyBo;
        private System.Windows.Forms.Label labelTitleTimKiem;
        private System.Windows.Forms.ComboBox comboBoxTimKiemSV;
        private System.Windows.Forms.RichTextBox richTextBoxTimKiemSV;
    }
}