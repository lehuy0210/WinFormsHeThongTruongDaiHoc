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
            buttonXuatExcelSV = new Button();
            buttonThongKeSV = new Button();
            buttonLamMoiThongTinSV = new Button();
            dataGridViewThongTinSinhVien = new DataGridView();
            buttonXoaThongTinSV = new Button();
            buttonSuaThongTinSV = new Button();
            buttonTimKiemSV = new Button();
            buttonThemThongTinSV = new Button();
            tabPageQuanLyGiangVien = new TabPage();
            dataGridViewThongTinGiangVien = new DataGridView();
            buttonThongKeGV = new Button();
            buttonLamMoiGV = new Button();
            buttonXoaGV = new Button();
            buttonSuaGV = new Button();
            buttonTimKiemGV = new Button();
            buttonThemGV = new Button();
            tabPageQuanLyGiangDay = new TabPage();
            groupBoxQuanLyGiangDay = new GroupBox();
            buttonQuanLyThongKhoaBieu = new Button();
            buttonQuanLyLichThi = new Button();
            buttonQuanLyDiem = new Button();
            buttonQuanLyLopHoc = new Button();
            buttonQuanLyMonHoc = new Button();
            dataGridViewGiangDay = new DataGridView();
            menuStripHeThongTruongDaiHoc = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            connectDatabaseToolStripMenuItem = new ToolStripMenuItem();
            tabControlHeThong.SuspendLayout();
            tabPageQuanLySinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThongTinSinhVien).BeginInit();
            tabPageQuanLyGiangVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewThongTinGiangVien).BeginInit();
            tabPageQuanLyGiangDay.SuspendLayout();
            groupBoxQuanLyGiangDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGiangDay).BeginInit();
            menuStripHeThongTruongDaiHoc.SuspendLayout();
            SuspendLayout();
            //
            // tabControlHeThong
            //
            tabControlHeThong.Appearance = TabAppearance.Buttons;
            tabControlHeThong.Controls.Add(tabPageQuanLySinhVien);
            tabControlHeThong.Controls.Add(tabPageQuanLyGiangVien);
            tabControlHeThong.Controls.Add(tabPageQuanLyGiangDay);
            tabControlHeThong.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            tabControlHeThong.Location = new Point(0, 33);
            tabControlHeThong.Name = "tabControlHeThong";
            tabControlHeThong.SelectedIndex = 0;
            tabControlHeThong.Size = new Size(1148, 690);
            tabControlHeThong.TabIndex = 0;
            //
            // tabPageQuanLySinhVien
            //
            tabPageQuanLySinhVien.Controls.Add(buttonXuatExcelSV);
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
            // buttonXuatExcelSV
            //
            buttonXuatExcelSV.BackColor = Color.FromArgb(13, 110, 253);
            buttonXuatExcelSV.Cursor = Cursors.Hand;
            buttonXuatExcelSV.FlatAppearance.BorderSize = 0;
            buttonXuatExcelSV.FlatStyle = FlatStyle.Flat;
            buttonXuatExcelSV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonXuatExcelSV.ForeColor = Color.White;
            buttonXuatExcelSV.Location = new Point(921, 521);
            buttonXuatExcelSV.Name = "buttonXuatExcelSV";
            buttonXuatExcelSV.Size = new Size(217, 80);
            buttonXuatExcelSV.TabIndex = 7;
            buttonXuatExcelSV.Text = "📄 XUẤT EXCEL";
            buttonXuatExcelSV.UseVisualStyleBackColor = false;
            buttonXuatExcelSV.Click += buttonXuatExcelSV_Click;
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
            // tabPageQuanLyGiangVien
            //
            tabPageQuanLyGiangVien.Controls.Add(buttonThongKeGV);
            tabPageQuanLyGiangVien.Controls.Add(buttonLamMoiGV);
            tabPageQuanLyGiangVien.Controls.Add(dataGridViewThongTinGiangVien);
            tabPageQuanLyGiangVien.Controls.Add(buttonXoaGV);
            tabPageQuanLyGiangVien.Controls.Add(buttonSuaGV);
            tabPageQuanLyGiangVien.Controls.Add(buttonTimKiemGV);
            tabPageQuanLyGiangVien.Controls.Add(buttonThemGV);
            tabPageQuanLyGiangVien.Location = new Point(4, 34);
            tabPageQuanLyGiangVien.Name = "tabPageQuanLyGiangVien";
            tabPageQuanLyGiangVien.Padding = new Padding(3);
            tabPageQuanLyGiangVien.Size = new Size(1140, 652);
            tabPageQuanLyGiangVien.TabIndex = 1;
            tabPageQuanLyGiangVien.Text = "Quản Lý Giảng Viên";
            tabPageQuanLyGiangVien.UseVisualStyleBackColor = true;
            //
            // dataGridViewThongTinGiangVien
            //
            dataGridViewThongTinGiangVien.AllowUserToAddRows = false;
            dataGridViewThongTinGiangVien.AllowUserToDeleteRows = false;
            dataGridViewThongTinGiangVien.AllowUserToResizeRows = false;
            dataGridViewThongTinGiangVien.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
            dataGridViewThongTinGiangVien.BackgroundColor = Color.White;
            dataGridViewThongTinGiangVien.BorderStyle = BorderStyle.None;
            dataGridViewThongTinGiangVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewThongTinGiangVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinGiangVien.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewThongTinGiangVien.ColumnHeadersHeight = 45;
            dataGridViewThongTinGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewThongTinGiangVien.DefaultCellStyle.BackColor = Color.White;
            dataGridViewThongTinGiangVien.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridViewThongTinGiangVien.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewThongTinGiangVien.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dataGridViewThongTinGiangVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewThongTinGiangVien.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewThongTinGiangVien.EnableHeadersVisualStyles = false;
            dataGridViewThongTinGiangVien.GridColor = Color.FromArgb(222, 226, 230);
            dataGridViewThongTinGiangVien.Location = new Point(0, 5);
            dataGridViewThongTinGiangVien.MultiSelect = false;
            dataGridViewThongTinGiangVien.Name = "dataGridViewThongTinGiangVien";
            dataGridViewThongTinGiangVien.ReadOnly = true;
            dataGridViewThongTinGiangVien.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewThongTinGiangVien.RowHeadersVisible = false;
            dataGridViewThongTinGiangVien.RowHeadersWidth = 51;
            dataGridViewThongTinGiangVien.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewThongTinGiangVien.RowTemplate.Height = 35;
            dataGridViewThongTinGiangVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThongTinGiangVien.Size = new Size(919, 634);
            dataGridViewThongTinGiangVien.TabIndex = 4;
            //
            // buttonThemGV
            //
            buttonThemGV.BackColor = Color.FromArgb(0, 120, 215);
            buttonThemGV.Cursor = Cursors.Hand;
            buttonThemGV.FlatAppearance.BorderSize = 0;
            buttonThemGV.FlatStyle = FlatStyle.Flat;
            buttonThemGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonThemGV.ForeColor = Color.White;
            buttonThemGV.Location = new Point(921, 5);
            buttonThemGV.Name = "buttonThemGV";
            buttonThemGV.Size = new Size(217, 80);
            buttonThemGV.TabIndex = 0;
            buttonThemGV.Text = "➕ THÊM THÔNG TIN";
            buttonThemGV.UseVisualStyleBackColor = false;
            buttonThemGV.Click += buttonThemGV_Click;
            //
            // buttonTimKiemGV
            //
            buttonTimKiemGV.BackColor = Color.FromArgb(102, 51, 153);
            buttonTimKiemGV.Cursor = Cursors.Hand;
            buttonTimKiemGV.FlatAppearance.BorderSize = 0;
            buttonTimKiemGV.FlatStyle = FlatStyle.Flat;
            buttonTimKiemGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonTimKiemGV.ForeColor = Color.White;
            buttonTimKiemGV.Location = new Point(921, 91);
            buttonTimKiemGV.Name = "buttonTimKiemGV";
            buttonTimKiemGV.Size = new Size(217, 80);
            buttonTimKiemGV.TabIndex = 1;
            buttonTimKiemGV.Text = "🔍 TÌM KIẾM";
            buttonTimKiemGV.UseVisualStyleBackColor = false;
            buttonTimKiemGV.Click += buttonTimKiemGV_Click;
            //
            // buttonSuaGV
            //
            buttonSuaGV.BackColor = Color.FromArgb(255, 152, 0);
            buttonSuaGV.Cursor = Cursors.Hand;
            buttonSuaGV.FlatAppearance.BorderSize = 0;
            buttonSuaGV.FlatStyle = FlatStyle.Flat;
            buttonSuaGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSuaGV.ForeColor = Color.White;
            buttonSuaGV.Location = new Point(921, 177);
            buttonSuaGV.Name = "buttonSuaGV";
            buttonSuaGV.Size = new Size(217, 80);
            buttonSuaGV.TabIndex = 2;
            buttonSuaGV.Text = "✏️ SỬA THÔNG TIN";
            buttonSuaGV.UseVisualStyleBackColor = false;
            buttonSuaGV.Click += buttonSuaGV_Click;
            //
            // buttonXoaGV
            //
            buttonXoaGV.BackColor = Color.FromArgb(220, 53, 69);
            buttonXoaGV.Cursor = Cursors.Hand;
            buttonXoaGV.FlatAppearance.BorderSize = 0;
            buttonXoaGV.FlatStyle = FlatStyle.Flat;
            buttonXoaGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonXoaGV.ForeColor = Color.White;
            buttonXoaGV.Location = new Point(921, 263);
            buttonXoaGV.Name = "buttonXoaGV";
            buttonXoaGV.Size = new Size(217, 80);
            buttonXoaGV.TabIndex = 3;
            buttonXoaGV.Text = "🗑️ XÓA THÔNG TIN";
            buttonXoaGV.UseVisualStyleBackColor = false;
            buttonXoaGV.Click += buttonXoaGV_Click;
            //
            // buttonLamMoiGV
            //
            buttonLamMoiGV.BackColor = Color.FromArgb(108, 117, 125);
            buttonLamMoiGV.Cursor = Cursors.Hand;
            buttonLamMoiGV.FlatAppearance.BorderSize = 0;
            buttonLamMoiGV.FlatStyle = FlatStyle.Flat;
            buttonLamMoiGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonLamMoiGV.ForeColor = Color.White;
            buttonLamMoiGV.Location = new Point(921, 349);
            buttonLamMoiGV.Name = "buttonLamMoiGV";
            buttonLamMoiGV.Size = new Size(217, 80);
            buttonLamMoiGV.TabIndex = 5;
            buttonLamMoiGV.Text = "🔄 LÀM MỚI";
            buttonLamMoiGV.UseVisualStyleBackColor = false;
            buttonLamMoiGV.Click += buttonLamMoiGV_Click;
            //
            // buttonThongKeGV
            //
            buttonThongKeGV.BackColor = Color.FromArgb(16, 185, 129);
            buttonThongKeGV.Cursor = Cursors.Hand;
            buttonThongKeGV.FlatAppearance.BorderSize = 0;
            buttonThongKeGV.FlatStyle = FlatStyle.Flat;
            buttonThongKeGV.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonThongKeGV.ForeColor = Color.White;
            buttonThongKeGV.Location = new Point(921, 435);
            buttonThongKeGV.Name = "buttonThongKeGV";
            buttonThongKeGV.Size = new Size(217, 80);
            buttonThongKeGV.TabIndex = 6;
            buttonThongKeGV.Text = "📊 THỐNG KÊ";
            buttonThongKeGV.UseVisualStyleBackColor = false;
            buttonThongKeGV.Click += buttonThongKeGV_Click;
            //
            // tabPageQuanLyGiangDay
            //
            tabPageQuanLyGiangDay.Controls.Add(groupBoxQuanLyGiangDay);
            tabPageQuanLyGiangDay.Controls.Add(dataGridViewGiangDay);
            tabPageQuanLyGiangDay.Location = new Point(4, 34);
            tabPageQuanLyGiangDay.Name = "tabPageQuanLyGiangDay";
            tabPageQuanLyGiangDay.Padding = new Padding(3);
            tabPageQuanLyGiangDay.Size = new Size(1140, 652);
            tabPageQuanLyGiangDay.TabIndex = 2;
            tabPageQuanLyGiangDay.Text = "Quản Lý Giảng Dạy";
            tabPageQuanLyGiangDay.UseVisualStyleBackColor = true;
            //
            // groupBoxQuanLyGiangDay
            //
            groupBoxQuanLyGiangDay.Controls.Add(buttonQuanLyMonHoc);
            groupBoxQuanLyGiangDay.Controls.Add(buttonQuanLyLopHoc);
            groupBoxQuanLyGiangDay.Controls.Add(buttonQuanLyDiem);
            groupBoxQuanLyGiangDay.Controls.Add(buttonQuanLyLichThi);
            groupBoxQuanLyGiangDay.Controls.Add(buttonQuanLyThongKhoaBieu);
            groupBoxQuanLyGiangDay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxQuanLyGiangDay.Location = new Point(0, 5);
            groupBoxQuanLyGiangDay.Name = "groupBoxQuanLyGiangDay";
            groupBoxQuanLyGiangDay.Size = new Size(1140, 120);
            groupBoxQuanLyGiangDay.TabIndex = 0;
            groupBoxQuanLyGiangDay.TabStop = false;
            groupBoxQuanLyGiangDay.Text = "Quản Lý Thành Phần Giảng Dạy";
            //
            // buttonQuanLyMonHoc
            //
            buttonQuanLyMonHoc.BackColor = Color.FromArgb(0, 120, 215);
            buttonQuanLyMonHoc.Cursor = Cursors.Hand;
            buttonQuanLyMonHoc.FlatAppearance.BorderSize = 0;
            buttonQuanLyMonHoc.FlatStyle = FlatStyle.Flat;
            buttonQuanLyMonHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonQuanLyMonHoc.ForeColor = Color.White;
            buttonQuanLyMonHoc.Location = new Point(10, 30);
            buttonQuanLyMonHoc.Name = "buttonQuanLyMonHoc";
            buttonQuanLyMonHoc.Size = new Size(210, 70);
            buttonQuanLyMonHoc.TabIndex = 0;
            buttonQuanLyMonHoc.Text = "📚 Quản Lý\r\nMôn Học";
            buttonQuanLyMonHoc.UseVisualStyleBackColor = false;
            buttonQuanLyMonHoc.Click += buttonQuanLyMonHoc_Click;
            //
            // buttonQuanLyLopHoc
            //
            buttonQuanLyLopHoc.BackColor = Color.FromArgb(102, 51, 153);
            buttonQuanLyLopHoc.Cursor = Cursors.Hand;
            buttonQuanLyLopHoc.FlatAppearance.BorderSize = 0;
            buttonQuanLyLopHoc.FlatStyle = FlatStyle.Flat;
            buttonQuanLyLopHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonQuanLyLopHoc.ForeColor = Color.White;
            buttonQuanLyLopHoc.Location = new Point(230, 30);
            buttonQuanLyLopHoc.Name = "buttonQuanLyLopHoc";
            buttonQuanLyLopHoc.Size = new Size(210, 70);
            buttonQuanLyLopHoc.TabIndex = 1;
            buttonQuanLyLopHoc.Text = "🏫 Quản Lý\r\nLớp Học";
            buttonQuanLyLopHoc.UseVisualStyleBackColor = false;
            buttonQuanLyLopHoc.Click += buttonQuanLyLopHoc_Click;
            //
            // buttonQuanLyDiem
            //
            buttonQuanLyDiem.BackColor = Color.FromArgb(255, 152, 0);
            buttonQuanLyDiem.Cursor = Cursors.Hand;
            buttonQuanLyDiem.FlatAppearance.BorderSize = 0;
            buttonQuanLyDiem.FlatStyle = FlatStyle.Flat;
            buttonQuanLyDiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonQuanLyDiem.ForeColor = Color.White;
            buttonQuanLyDiem.Location = new Point(450, 30);
            buttonQuanLyDiem.Name = "buttonQuanLyDiem";
            buttonQuanLyDiem.Size = new Size(210, 70);
            buttonQuanLyDiem.TabIndex = 2;
            buttonQuanLyDiem.Text = "📝 Quản Lý\r\nĐiểm";
            buttonQuanLyDiem.UseVisualStyleBackColor = false;
            buttonQuanLyDiem.Click += buttonQuanLyDiem_Click;
            //
            // buttonQuanLyLichThi
            //
            buttonQuanLyLichThi.BackColor = Color.FromArgb(220, 53, 69);
            buttonQuanLyLichThi.Cursor = Cursors.Hand;
            buttonQuanLyLichThi.FlatAppearance.BorderSize = 0;
            buttonQuanLyLichThi.FlatStyle = FlatStyle.Flat;
            buttonQuanLyLichThi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonQuanLyLichThi.ForeColor = Color.White;
            buttonQuanLyLichThi.Location = new Point(670, 30);
            buttonQuanLyLichThi.Name = "buttonQuanLyLichThi";
            buttonQuanLyLichThi.Size = new Size(210, 70);
            buttonQuanLyLichThi.TabIndex = 3;
            buttonQuanLyLichThi.Text = "🗓️ Quản Lý\r\nLịch Thi";
            buttonQuanLyLichThi.UseVisualStyleBackColor = false;
            buttonQuanLyLichThi.Click += buttonQuanLyLichThi_Click;
            //
            // buttonQuanLyThongKhoaBieu
            //
            buttonQuanLyThongKhoaBieu.BackColor = Color.FromArgb(16, 185, 129);
            buttonQuanLyThongKhoaBieu.Cursor = Cursors.Hand;
            buttonQuanLyThongKhoaBieu.FlatAppearance.BorderSize = 0;
            buttonQuanLyThongKhoaBieu.FlatStyle = FlatStyle.Flat;
            buttonQuanLyThongKhoaBieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonQuanLyThongKhoaBieu.ForeColor = Color.White;
            buttonQuanLyThongKhoaBieu.Location = new Point(890, 30);
            buttonQuanLyThongKhoaBieu.Name = "buttonQuanLyThongKhoaBieu";
            buttonQuanLyThongKhoaBieu.Size = new Size(230, 70);
            buttonQuanLyThongKhoaBieu.TabIndex = 4;
            buttonQuanLyThongKhoaBieu.Text = "⏰ Quản Lý\r\nThời Khóa Biểu";
            buttonQuanLyThongKhoaBieu.UseVisualStyleBackColor = false;
            buttonQuanLyThongKhoaBieu.Click += buttonQuanLyThongKhoaBieu_Click;
            //
            // dataGridViewGiangDay
            //
            dataGridViewGiangDay.AllowUserToAddRows = false;
            dataGridViewGiangDay.AllowUserToDeleteRows = false;
            dataGridViewGiangDay.AllowUserToResizeRows = false;
            dataGridViewGiangDay.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
            dataGridViewGiangDay.BackgroundColor = Color.White;
            dataGridViewGiangDay.BorderStyle = BorderStyle.None;
            dataGridViewGiangDay.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewGiangDay.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 10, 10, 10);
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewGiangDay.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewGiangDay.ColumnHeadersHeight = 45;
            dataGridViewGiangDay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewGiangDay.DefaultCellStyle.BackColor = Color.White;
            dataGridViewGiangDay.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridViewGiangDay.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewGiangDay.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dataGridViewGiangDay.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridViewGiangDay.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewGiangDay.EnableHeadersVisualStyles = false;
            dataGridViewGiangDay.GridColor = Color.FromArgb(222, 226, 230);
            dataGridViewGiangDay.Location = new Point(0, 135);
            dataGridViewGiangDay.MultiSelect = false;
            dataGridViewGiangDay.Name = "dataGridViewGiangDay";
            dataGridViewGiangDay.ReadOnly = true;
            dataGridViewGiangDay.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewGiangDay.RowHeadersVisible = false;
            dataGridViewGiangDay.RowHeadersWidth = 51;
            dataGridViewGiangDay.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewGiangDay.RowTemplate.Height = 35;
            dataGridViewGiangDay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGiangDay.Size = new Size(1140, 507);
            dataGridViewGiangDay.TabIndex = 4;
            //
            // menuStripHeThongTruongDaiHoc
            //
            menuStripHeThongTruongDaiHoc.ImageScalingSize = new Size(20, 20);
            menuStripHeThongTruongDaiHoc.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, databaseToolStripMenuItem });
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
            // databaseToolStripMenuItem
            //
            databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectDatabaseToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(84, 24);
            databaseToolStripMenuItem.Text = "Database";
            //
            // connectDatabaseToolStripMenuItem
            //
            connectDatabaseToolStripMenuItem.Name = "connectDatabaseToolStripMenuItem";
            connectDatabaseToolStripMenuItem.Size = new Size(185, 26);
            connectDatabaseToolStripMenuItem.Text = "Kết nối Database";
            connectDatabaseToolStripMenuItem.Click += connectDatabaseToolStripMenuItem_Click;
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
            tabPageQuanLyGiangVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewThongTinGiangVien).EndInit();
            tabPageQuanLyGiangDay.ResumeLayout(false);
            groupBoxQuanLyGiangDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewGiangDay).EndInit();
            menuStripHeThongTruongDaiHoc.ResumeLayout(false);
            menuStripHeThongTruongDaiHoc.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlHeThong;
        private System.Windows.Forms.TabPage tabPageQuanLySinhVien;
        private System.Windows.Forms.Button buttonXuatExcelSV;
        private System.Windows.Forms.Button buttonXoaThongTinSV;
        private System.Windows.Forms.Button buttonSuaThongTinSV;
        private System.Windows.Forms.Button buttonTimKiemSV;
        private System.Windows.Forms.Button buttonThemThongTinSV;
        private System.Windows.Forms.TabPage tabPageQuanLyGiangVien;
        private System.Windows.Forms.DataGridView dataGridViewThongTinGiangVien;
        private System.Windows.Forms.Button buttonThongKeGV;
        private System.Windows.Forms.Button buttonLamMoiGV;
        private System.Windows.Forms.Button buttonXoaGV;
        private System.Windows.Forms.Button buttonSuaGV;
        private System.Windows.Forms.Button buttonTimKiemGV;
        private System.Windows.Forms.Button buttonThemGV;
        private System.Windows.Forms.TabPage tabPageQuanLyGiangDay;
        private System.Windows.Forms.GroupBox groupBoxQuanLyGiangDay;
        private System.Windows.Forms.Button buttonQuanLyThongKhoaBieu;
        private System.Windows.Forms.Button buttonQuanLyLichThi;
        private System.Windows.Forms.Button buttonQuanLyDiem;
        private System.Windows.Forms.Button buttonQuanLyLopHoc;
        private System.Windows.Forms.Button buttonQuanLyMonHoc;
        private System.Windows.Forms.DataGridView dataGridViewGiangDay;
        private System.Windows.Forms.DataGridView dataGridViewThongTinSinhVien;
        private System.Windows.Forms.MenuStrip menuStripHeThongTruongDaiHoc;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectDatabaseToolStripMenuItem;
        private Button buttonLamMoiThongTinSV;
        private Button buttonThongKeSV;
    }
}