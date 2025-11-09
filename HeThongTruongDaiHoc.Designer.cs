namespace He_Thong_Truong_Dai_Hoc
{
    partial class HeThongTruongDaiHoc
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
            tabControlHeThong = new TabControl();
            tabPageQuanLySinhVien = new TabPage();
            buttonThongKeSV = new Button();
            buttonLamMoiThongTinSV = new Button();
            dataGridViewThongTinSinhVien = new DataGridView();
            buttonXoaThongTinSV = new Button();
            buttonSuaThongTinSV = new Button();
            buttonTimKiemSV = new Button();
            buttonThemThongTinSV = new Button();
            tabPage2 = new TabPage();
            menuStripHeThongTruongDaiHoc = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tabControlHeThong.SuspendLayout();
            tabPageQuanLySinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThongTinSinhVien).BeginInit();
            menuStripHeThongTruongDaiHoc.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlHeThong
            // 
            tabControlHeThong.Appearance = TabAppearance.Buttons;
            tabControlHeThong.Controls.Add(tabPageQuanLySinhVien);
            tabControlHeThong.Controls.Add(tabPage2);
            tabControlHeThong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tabControlHeThong.Location = new Point(0, 33);
            tabControlHeThong.Name = "tabControlHeThong";
            tabControlHeThong.SelectedIndex = 0;
            tabControlHeThong.Size = new Size(1148, 690);
            tabControlHeThong.TabIndex = 0;
            // 
            // tabPageQuanLySinhVien
            //
            tabPageQuanLySinhVien.Controls.Add(buttonThongKeSV);
            tabPageQuanLySinhVien.Controls.Add(buttonLamMoiThongTinSV);
            tabPageQuanLySinhVien.Controls.Add(dataGridViewThongTinSinhVien);
            tabPageQuanLySinhVien.Controls.Add(buttonXoaThongTinSV);
            tabPageQuanLySinhVien.Controls.Add(buttonSuaThongTinSV);
            tabPageQuanLySinhVien.Controls.Add(buttonTimKiemSV);
            tabPageQuanLySinhVien.Controls.Add(buttonThemThongTinSV);
            tabPageQuanLySinhVien.Location = new Point(4, 34);
            tabPageQuanLySinhVien.Name = "tabPageQuanLySinhVien";
            tabPageQuanLySinhVien.Padding = new Padding(3);
            tabPageQuanLySinhVien.Size = new Size(1140, 652);
            tabPageQuanLySinhVien.TabIndex = 0;
            tabPageQuanLySinhVien.Text = "Quản Lý Sinh Viên";
            tabPageQuanLySinhVien.UseVisualStyleBackColor = true;
            // 
            // buttonThongKeSV
            //
            buttonThongKeSV.BackColor = Color.FromArgb(16, 185, 129);
            buttonThongKeSV.Cursor = Cursors.Hand;
            buttonThongKeSV.FlatAppearance.BorderSize = 0;
            buttonThongKeSV.FlatStyle = FlatStyle.Flat;
            buttonThongKeSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonThongKeSV.ForeColor = Color.White;
            buttonThongKeSV.Location = new Point(921, 435);
            buttonThongKeSV.Name = "buttonThongKeSV";
            buttonThongKeSV.Size = new Size(217, 80);
            buttonThongKeSV.TabIndex = 6;
            buttonThongKeSV.Text = "📊 THỐNG KÊ";
            buttonThongKeSV.UseVisualStyleBackColor = false;
            buttonThongKeSV.Click += buttonThongKeSV_Click;
            //
            // buttonLamMoiThongTinSV
            //
            buttonLamMoiThongTinSV.BackColor = Color.FromArgb(108, 117, 125);
            buttonLamMoiThongTinSV.Cursor = Cursors.Hand;
            buttonLamMoiThongTinSV.FlatAppearance.BorderSize = 0;
            buttonLamMoiThongTinSV.FlatStyle = FlatStyle.Flat;
            buttonLamMoiThongTinSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonLamMoiThongTinSV.ForeColor = Color.White;
            buttonLamMoiThongTinSV.Location = new Point(921, 349);
            buttonLamMoiThongTinSV.Name = "buttonLamMoiThongTinSV";
            buttonLamMoiThongTinSV.Size = new Size(217, 80);
            buttonLamMoiThongTinSV.TabIndex = 5;
            buttonLamMoiThongTinSV.Text = "🔄 LÀM MỚI";
            buttonLamMoiThongTinSV.UseVisualStyleBackColor = false;
            buttonLamMoiThongTinSV.Click += buttonLamMoiThongTinSV_Click;
            //
            // dataGridViewThongTinSinhVien
            //
            dataGridViewThongTinSinhVien.AllowUserToAddRows = false;
            dataGridViewThongTinSinhVien.AllowUserToDeleteRows = false;
            dataGridViewThongTinSinhVien.AllowUserToResizeRows = false;
            dataGridViewThongTinSinhVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
            dataGridViewThongTinSinhVien.BackgroundColor = Color.White;
            dataGridViewThongTinSinhVien.BorderStyle = BorderStyle.None;
            dataGridViewThongTinSinhVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewThongTinSinhVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinSinhVien.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewThongTinSinhVien.ColumnHeadersHeight = 45;
            dataGridViewThongTinSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewThongTinSinhVien.DefaultCellStyle.BackColor = Color.White;
            dataGridViewThongTinSinhVien.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridViewThongTinSinhVien.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewThongTinSinhVien.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dataGridViewThongTinSinhVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinSinhVien.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewThongTinSinhVien.EnableHeadersVisualStyles = false;
            dataGridViewThongTinSinhVien.GridColor = Color.FromArgb(222, 226, 230);
            dataGridViewThongTinSinhVien.Location = new Point(0, 5);
            dataGridViewThongTinSinhVien.MultiSelect = false;
            dataGridViewThongTinSinhVien.Name = "dataGridViewThongTinSinhVien";
            dataGridViewThongTinSinhVien.ReadOnly = true;
            dataGridViewThongTinSinhVien.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewThongTinSinhVien.RowHeadersVisible = false;
            dataGridViewThongTinSinhVien.RowHeadersWidth = 51;
            dataGridViewThongTinSinhVien.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewThongTinSinhVien.RowTemplate.Height = 35;
            dataGridViewThongTinSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThongTinSinhVien.Size = new Size(919, 634);
            dataGridViewThongTinSinhVien.TabIndex = 4;
            // 
            // buttonXoaThongTinSV
            //
            buttonXoaThongTinSV.BackColor = Color.FromArgb(220, 53, 69);
            buttonXoaThongTinSV.Cursor = Cursors.Hand;
            buttonXoaThongTinSV.FlatAppearance.BorderSize = 0;
            buttonXoaThongTinSV.FlatStyle = FlatStyle.Flat;
            buttonXoaThongTinSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonXoaThongTinSV.ForeColor = Color.White;
            buttonXoaThongTinSV.Location = new Point(921, 263);
            buttonXoaThongTinSV.Name = "buttonXoaThongTinSV";
            buttonXoaThongTinSV.Size = new Size(217, 80);
            buttonXoaThongTinSV.TabIndex = 3;
            buttonXoaThongTinSV.Text = "🗑️ XÓA THÔNG TIN";
            buttonXoaThongTinSV.UseVisualStyleBackColor = false;
            buttonXoaThongTinSV.Click += buttonXoaThongTinSV_Click;
            // 
            // buttonSuaThongTinSV
            //
            buttonSuaThongTinSV.BackColor = Color.FromArgb(255, 152, 0);
            buttonSuaThongTinSV.Cursor = Cursors.Hand;
            buttonSuaThongTinSV.FlatAppearance.BorderSize = 0;
            buttonSuaThongTinSV.FlatStyle = FlatStyle.Flat;
            buttonSuaThongTinSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSuaThongTinSV.ForeColor = Color.White;
            buttonSuaThongTinSV.Location = new Point(921, 177);
            buttonSuaThongTinSV.Name = "buttonSuaThongTinSV";
            buttonSuaThongTinSV.Size = new Size(217, 80);
            buttonSuaThongTinSV.TabIndex = 2;
            buttonSuaThongTinSV.Text = "✏️ SỬA THÔNG TIN";
            buttonSuaThongTinSV.UseVisualStyleBackColor = false;
            buttonSuaThongTinSV.Click += buttonSuaThongTinSV_Click;
            // 
            // buttonTimKiemSV
            //
            buttonTimKiemSV.BackColor = Color.FromArgb(102, 51, 153);
            buttonTimKiemSV.Cursor = Cursors.Hand;
            buttonTimKiemSV.FlatAppearance.BorderSize = 0;
            buttonTimKiemSV.FlatStyle = FlatStyle.Flat;
            buttonTimKiemSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonTimKiemSV.ForeColor = Color.White;
            buttonTimKiemSV.Location = new Point(921, 91);
            buttonTimKiemSV.Name = "buttonTimKiemSV";
            buttonTimKiemSV.Size = new Size(217, 80);
            buttonTimKiemSV.TabIndex = 1;
            buttonTimKiemSV.Text = "🔍 TÌM KIẾM";
            buttonTimKiemSV.UseVisualStyleBackColor = false;
            buttonTimKiemSV.Click += buttonTimKiemSV_Click;
            // 
            // buttonThemThongTinSV
            //
            buttonThemThongTinSV.BackColor = Color.FromArgb(0, 120, 215);
            buttonThemThongTinSV.Cursor = Cursors.Hand;
            buttonThemThongTinSV.FlatAppearance.BorderSize = 0;
            buttonThemThongTinSV.FlatStyle = FlatStyle.Flat;
            buttonThemThongTinSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonThemThongTinSV.ForeColor = Color.White;
            buttonThemThongTinSV.Location = new Point(921, 5);
            buttonThemThongTinSV.Name = "buttonThemThongTinSV";
            buttonThemThongTinSV.Size = new Size(217, 80);
            buttonThemThongTinSV.TabIndex = 0;
            buttonThemThongTinSV.Text = "➕ THÊM THÔNG TIN";
            buttonThemThongTinSV.UseVisualStyleBackColor = false;
            buttonThemThongTinSV.Click += buttonThemThongTinSV_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1140, 652);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStripHeThongTruongDaiHoc
            // 
            menuStripHeThongTruongDaiHoc.ImageScalingSize = new Size(20, 20);
            menuStripHeThongTruongDaiHoc.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStripHeThongTruongDaiHoc.Location = new Point(0, 0);
            menuStripHeThongTruongDaiHoc.Name = "menuStripHeThongTruongDaiHoc";
            menuStripHeThongTruongDaiHoc.Padding = new Padding(8, 3, 0, 3);
            menuStripHeThongTruongDaiHoc.RenderMode = ToolStripRenderMode.System;
            menuStripHeThongTruongDaiHoc.Size = new Size(1148, 30);
            menuStripHeThongTruongDaiHoc.TabIndex = 1;
            menuStripHeThongTruongDaiHoc.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // HeThongTruongDaiHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 723);
            Controls.Add(tabControlHeThong);
            Controls.Add(menuStripHeThongTruongDaiHoc);
            Name = "HeThongTruongDaiHoc";
            Text = "Hệ Thống Trường Học";
            tabControlHeThong.ResumeLayout(false);
            tabPageQuanLySinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewThongTinSinhVien).EndInit();
            menuStripHeThongTruongDaiHoc.ResumeLayout(false);
            menuStripHeThongTruongDaiHoc.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlHeThong;
        private System.Windows.Forms.TabPage tabPageQuanLySinhVien;
        private System.Windows.Forms.Button buttonXoaThongTinSV;
        private System.Windows.Forms.Button buttonSuaThongTinSV;
        private System.Windows.Forms.Button buttonTimKiemSV;
        private System.Windows.Forms.Button buttonThemThongTinSV;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewThongTinSinhVien;
        private System.Windows.Forms.MenuStrip menuStripHeThongTruongDaiHoc;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private Button buttonLamMoiThongTinSV;
        private Button buttonThongKeSV;
    }
}