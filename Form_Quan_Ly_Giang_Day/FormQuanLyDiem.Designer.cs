namespace He_Thong_Truong_Dai_Hoc.Form_Quan_Ly_Giang_Day
{
    partial class FormQuanLyDiem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTieuDe = new System.Windows.Forms.Label();
            this.dataGridViewDiem = new System.Windows.Forms.DataGridView();
            this.panelButton = new System.Windows.Forms.Panel();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonTimKiem = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonLamMoi = new System.Windows.Forms.Button();
            this.buttonThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).BeginInit();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();

            // labelTieuDe
            this.labelTieuDe.AutoSize = true;
            this.labelTieuDe.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.labelTieuDe.Location = new System.Drawing.Point(12, 9);
            this.labelTieuDe.Name = "labelTieuDe";
            this.labelTieuDe.Size = new System.Drawing.Size(150, 25);
            this.labelTieuDe.TabIndex = 0;
            this.labelTieuDe.Text = "QUẢN LÝ ĐIỂM";

            // dataGridViewDiem
            this.dataGridViewDiem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDiem.Location = new System.Drawing.Point(0, 50);
            this.dataGridViewDiem.Name = "dataGridViewDiem";
            this.dataGridViewDiem.Size = new System.Drawing.Size(984, 430);
            this.dataGridViewDiem.TabIndex = 1;

            // panelButton
            this.panelButton.AutoScroll = true;
            this.panelButton.Controls.Add(this.buttonThem);
            this.panelButton.Controls.Add(this.buttonTimKiem);
            this.panelButton.Controls.Add(this.buttonSua);
            this.panelButton.Controls.Add(this.buttonXoa);
            this.panelButton.Controls.Add(this.buttonLamMoi);
            this.panelButton.Controls.Add(this.buttonThongKe);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 480);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(984, 80);
            this.panelButton.TabIndex = 2;

            // buttonThem
            this.buttonThem.Location = new System.Drawing.Point(10, 10);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(100, 35);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);

            // buttonTimKiem
            this.buttonTimKiem.Location = new System.Drawing.Point(120, 10);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(100, 35);
            this.buttonTimKiem.TabIndex = 1;
            this.buttonTimKiem.Text = "Tìm kiếm";
            this.buttonTimKiem.UseVisualStyleBackColor = true;
            this.buttonTimKiem.Click += new System.EventHandler(this.buttonTimKiem_Click);

            // buttonSua
            this.buttonSua.Location = new System.Drawing.Point(230, 10);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(100, 35);
            this.buttonSua.TabIndex = 2;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);

            // buttonXoa
            this.buttonXoa.Location = new System.Drawing.Point(340, 10);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(100, 35);
            this.buttonXoa.TabIndex = 3;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);

            // buttonLamMoi
            this.buttonLamMoi.Location = new System.Drawing.Point(450, 10);
            this.buttonLamMoi.Name = "buttonLamMoi";
            this.buttonLamMoi.Size = new System.Drawing.Size(100, 35);
            this.buttonLamMoi.TabIndex = 4;
            this.buttonLamMoi.Text = "Làm mới";
            this.buttonLamMoi.UseVisualStyleBackColor = true;
            this.buttonLamMoi.Click += new System.EventHandler(this.buttonLamMoi_Click);

            // buttonThongKe
            this.buttonThongKe.Location = new System.Drawing.Point(560, 10);
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.Size = new System.Drawing.Size(100, 35);
            this.buttonThongKe.TabIndex = 5;
            this.buttonThongKe.Text = "Thống kê";
            this.buttonThongKe.UseVisualStyleBackColor = true;
            this.buttonThongKe.Click += new System.EventHandler(this.buttonThongKe_Click);

            // FormQuanLyDiem
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 560);
            this.Controls.Add(this.dataGridViewDiem);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.labelTieuDe);
            this.Name = "FormQuanLyDiem";
            this.Text = "Quản Lý Điểm";
            this.Load += new System.EventHandler(this.FormQuanLyDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelTieuDe;
        private System.Windows.Forms.DataGridView dataGridViewDiem;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonTimKiem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonLamMoi;
        private System.Windows.Forms.Button buttonThongKe;
    }
}
