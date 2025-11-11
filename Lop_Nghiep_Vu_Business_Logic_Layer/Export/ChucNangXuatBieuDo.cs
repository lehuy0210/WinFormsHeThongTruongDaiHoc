using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsHeThongTruongDaiHoc.Lop_Nghiep_Vu___Business_Logic_Layer.Export
{
    // ==================== BUSINESS LOGIC LAYER - XUẤT BIỂU ĐỒ BẰNG SVG ====================
    // 📚 KIẾN THỨC ÁP DỤNG:
    // 1️⃣ SVG (SCALABLE VECTOR GRAPHICS): Vector-based graphics format
    // 2️⃣ COORDINATE SYSTEM: SVG uses top-left origin (0,0) at top-left
    // 3️⃣ DATA VISUALIZATION: Converting data to visual shapes
    // 4️⃣ HTML GENERATION: Creating complete HTML documents with embedded SVG
    // 5️⃣ MATHEMATICS: Calculating positions, sizes, angles for charts
    //
    // 💡 MỤC ĐÍCH:
    // Tạo biểu đồ thống kê dạng SVG nhúng trong HTML
    // Không sử dụng thư viện bên ngoài (không dùng Chart.js, D3.js, v.v.)
    // Tự implement SVG generation để tạo biểu đồ cột, tròn, đường
    // Output là file .html có thể mở trực tiếp trong trình duyệt
    //
    // 📊 SVG BASICS:
    // SVG = XML-based format dùng để vẽ vector graphics
    // Các elements cơ bản: <rect>, <circle>, <path>, <text>, <line>
    // SVG có coordinate system: x tăng sang phải, y tăng xuống dưới
    //
    // 📐 SVG COORDINATE SYSTEM:
    // - Origin (0,0) ở TOP-LEFT corner (không như toán học ở bottom-left)
    // - X-axis: 0 = trái, x tăng = sang phải
    // - Y-axis: 0 = trên, y tăng = xuống dưới
    // - Units: có thể là pixels, inches, mm, hoặc em (relative units)
    // - viewBox = "minX minY width height": định nghĩa coordinate space
    //
    // 🎨 SVG ELEMENTS:
    // <rect> = hình chữ nhật: x, y, width, height, fill, stroke
    // <circle> = hình tròn: cx, cy, r, fill, stroke
    // <path> = đường tùy ý: d attribute với các lệnh M, L, Q, Z
    // <text> = chữ: x, y, text-anchor, font-size, fill
    // <line> = đường thẳng: x1, y1, x2, y2, stroke

    public class ChucNangXuatBieuDo
    {
        // ==================== CONSTANTS - KÍCH THƯỚC CHI TIẾT ====================
        // SVG dimensions (pixels)
        private const int SVG_WIDTH = 1000;
        private const int SVG_HEIGHT = 600;
        private const int MARGIN_LEFT = 80;
        private const int MARGIN_RIGHT = 40;
        private const int MARGIN_TOP = 60;
        private const int MARGIN_BOTTOM = 80;

        // Colors for bars/slices
        private string[] COLORS = {
            "#FF6B6B", "#4ECDC4", "#45B7D1", "#FFA07A", "#98D8C8",
            "#F7DC6F", "#BB8FCE", "#85C1E2", "#F8B88B", "#A8E6CF"
        };

        // ==================== XUẤT BIỂU ĐỒ CỘT ====================
        // 🎯 PURPOSE: Tạo biểu đồ cột (bar chart) từ dữ liệu
        // 📊 INPUT: Dictionary<string, int> hoặc Dictionary<string, double>
        // 📁 OUTPUT: HTML file với SVG embedded
        // ✅ USE CASE: Thống kê xét tốt nghiệp theo xếp loại
        //
        // THUẬT TOÁN:
        // 1. Tính max value từ dữ liệu
        // 2. Tính width của mỗi bar dựa trên chart width
        // 3. Tính height của mỗi bar dựa trên (value/maxValue) * chartHeight
        // 4. Vẽ X-axis labels, Y-axis scale
        // 5. Vẽ bars với colors khác nhau
        public bool TaoBieuDoCot(Dictionary<string, double> data, string filePath, string tieuDe = "Biểu Đồ Cột")
        {
            try
            {
                if (data == null || data.Count == 0)
                    return false;

                StringBuilder html = new StringBuilder();

                // BƯỚC 1: Tính toán data
                double maxValue = data.Values.Max();
                int numBars = data.Count;
                int chartWidth = SVG_WIDTH - MARGIN_LEFT - MARGIN_RIGHT;
                int chartHeight = SVG_HEIGHT - MARGIN_TOP - MARGIN_BOTTOM;

                // BƯỚC 2: Tạo HTML header
                html.Append(CreateHTMLHeader($"Biểu Đồ Cột - {tieuDe}"));

                // BƯỚC 3: Bắt đầu SVG
                html.Append($@"<svg width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" style=""border: 1px solid #ccc;"">");

                // BƯỚC 4: Vẽ background
                html.Append($@"<rect width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" fill=""#FFFFFF""/>");

                // BƯỚC 5: Vẽ title
                html.Append($@"<text x=""{SVG_WIDTH / 2}"" y=""35"" text-anchor=""middle"" font-size=""24"" font-weight=""bold"" fill=""#333333"">");
                html.Append(System.Net.WebUtility.HtmlEncode(tieuDe));
                html.Append(@"</text>");

                // BƯỚC 6: Vẽ axes
                DrawAxes(html, chartWidth, chartHeight, maxValue);

                // BƯỚC 7: Vẽ bars
                double barWidth = (double)chartWidth / numBars;
                int colorIndex = 0;

                foreach (var kvp in data)
                {
                    string label = kvp.Key;
                    double value = kvp.Value;

                    // Tính toán vị trí bar
                    double xPosition = MARGIN_LEFT + (colorIndex * barWidth) + (barWidth * 0.1);
                    double barHeight = (value / maxValue) * chartHeight;
                    double yPosition = SVG_HEIGHT - MARGIN_BOTTOM - barHeight;
                    double actualBarWidth = barWidth * 0.8;

                    // Vẽ bar
                    html.Append($@"<rect x=""{xPosition:F0}"" y=""{yPosition:F0}"" ");
                    html.Append($@"width=""{actualBarWidth:F0}"" height=""{barHeight:F0}"" ");
                    html.Append($@"fill=""{COLORS[colorIndex % COLORS.Length]}"" stroke=""#333"" stroke-width=""1""/>");

                    // Vẽ giá trị trên bar
                    html.Append($@"<text x=""{xPosition + actualBarWidth / 2}"" y=""{yPosition - 5}"" ");
                    html.Append($@"text-anchor=""middle"" font-size=""12"" fill=""#333333"">");
                    html.Append(value.ToString("F2"));
                    html.Append(@"</text>");

                    // Vẽ label bên dưới
                    html.Append($@"<text x=""{xPosition + actualBarWidth / 2}"" y=""{SVG_HEIGHT - MARGIN_BOTTOM + 20}"" ");
                    html.Append($@"text-anchor=""middle"" font-size=""11"" fill=""#666666"" ");
                    html.Append($@"transform=""rotate(0 {xPosition + actualBarWidth / 2} {SVG_HEIGHT - MARGIN_BOTTOM + 20})"">");
                    html.Append(System.Net.WebUtility.HtmlEncode(label));
                    html.Append(@"</text>");

                    colorIndex++;
                }

                // BƯỚC 8: Kết thúc SVG
                html.Append(@"</svg>");

                // BƯỚC 9: Thêm legend
                AppendLegend(html, data.Keys.ToList(), numBars);

                // BƯỚC 10: Kết thúc HTML
                html.Append(@"</body></html>");

                // BƯỚC 11: Ghi vào file
                System.IO.File.WriteAllText(filePath, html.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT BIỂU ĐỒ TRÒN ====================
        // 🎯 PURPOSE: Tạo biểu đồ tròn (pie chart) từ dữ liệu
        // 📊 INPUT: Dictionary<string, double>
        // 📐 ALGORITHM: Slice pie dựa trên tỷ lệ phần trăm
        // ✅ USE CASE: Thống kê thi đua theo danh hiệu
        //
        // THUẬT TOÁN:
        // 1. Tính tổng giá trị
        // 2. Tính mỗi slice chiếm % bao nhiêu từ 360 độ
        // 3. Dùng SVG <path> để vẽ pie slices
        // 4. Dùng SVG arcs (A command) để vẽ vòng cung tròn
        //
        // SVG ARC COMMAND: A rx ry x-axis-rotation large-arc-flag sweep-flag x y
        // - rx, ry = bán kính X, Y (cho ellipse)
        // - x-axis-rotation = góc quay (0 cho vòng tròn)
        // - large-arc-flag = 1 nếu arc > 180°, 0 nếu < 180°
        // - sweep-flag = 1 để vẽ theo chiều kim đồng hồ
        // - x, y = điểm kết thúc
        public bool TaoBieuDoTron(Dictionary<string, double> data, string filePath, string tieuDe = "Biểu Đồ Tròn")
        {
            try
            {
                if (data == null || data.Count == 0)
                    return false;

                StringBuilder html = new StringBuilder();

                // BƯỚC 1: Tính toán data
                double totalValue = data.Values.Sum();
                int numSlices = data.Count;

                // BƯỚC 2: Tạo HTML header
                html.Append(CreateHTMLHeader($"Biểu Đồ Tròn - {tieuDe}"));

                // BƯỚC 3: Bắt đầu SVG
                html.Append($@"<svg width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" style=""border: 1px solid #ccc;"">");

                // BƯỚC 4: Vẽ background
                html.Append($@"<rect width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" fill=""#FFFFFF""/>");

                // BƯỚC 5: Vẽ title
                html.Append($@"<text x=""{SVG_WIDTH / 2}"" y=""35"" text-anchor=""middle"" font-size=""24"" font-weight=""bold"" fill=""#333333"">");
                html.Append(System.Net.WebUtility.HtmlEncode(tieuDe));
                html.Append(@"</text>");

                // BƯỚC 6: Vẽ pie slices
                // Pie center & radius
                double centerX = SVG_WIDTH / 2;
                double centerY = SVG_HEIGHT / 2 - 20;
                double radius = 150;

                double currentAngle = 0; // Bắt đầu từ góc 0 (3 o'clock position)
                int colorIndex = 0;

                foreach (var kvp in data)
                {
                    string label = kvp.Key;
                    double value = kvp.Value;
                    double percentage = value / totalValue;
                    double sliceAngle = percentage * 360; // Góc cho slice này

                    // BƯỚC 7: Tính toán điểm bắt đầu và kết thúc của arc
                    double startAngleRad = DegToRad(currentAngle);
                    double endAngleRad = DegToRad(currentAngle + sliceAngle);

                    // Điểm bắt đầu của arc (từ center)
                    double startX = centerX + radius * Math.Cos(startAngleRad);
                    double startY = centerY + radius * Math.Sin(startAngleRad);

                    // Điểm kết thúc của arc
                    double endX = centerX + radius * Math.Cos(endAngleRad);
                    double endY = centerY + radius * Math.Sin(endAngleRad);

                    // BƯỚC 8: Xác định large-arc-flag (1 nếu arc > 180°)
                    int largeArc = sliceAngle > 180 ? 1 : 0;

                    // BƯỚC 9: Xây dựng SVG path cho slice
                    // Path: M (move to center) L (line to start) A (arc) Z (close path)
                    StringBuilder pathData = new StringBuilder();
                    pathData.Append($"M {centerX:F1} {centerY:F1} ");
                    pathData.Append($"L {startX:F1} {startY:F1} ");
                    pathData.Append($"A {radius:F1} {radius:F1} 0 {largeArc} 1 {endX:F1} {endY:F1} ");
                    pathData.Append("Z");

                    // Vẽ slice
                    html.Append($@"<path d=""{pathData}"" fill=""{COLORS[colorIndex % COLORS.Length]}"" ");
                    html.Append($@"stroke=""#FFFFFF"" stroke-width=""2""/>");

                    // BƯỚC 10: Vẽ percentage label trên slice
                    double labelAngleRad = DegToRad(currentAngle + sliceAngle / 2);
                    double labelRadius = radius * 0.7; // 70% của radius
                    double labelX = centerX + labelRadius * Math.Cos(labelAngleRad);
                    double labelY = centerY + labelRadius * Math.Sin(labelAngleRad);

                    html.Append($@"<text x=""{labelX:F1}"" y=""{labelY:F1}"" ");
                    html.Append($@"text-anchor=""middle"" dominant-baseline=""middle"" ");
                    html.Append($@"font-size=""12"" font-weight=""bold"" fill=""#FFFFFF"">");
                    html.Append((percentage * 100).ToString("F1"));
                    html.Append("%</text>");

                    currentAngle += sliceAngle;
                    colorIndex++;
                }

                // BƯỚC 11: Kết thúc SVG
                html.Append(@"</svg>");

                // BƯỚC 12: Thêm legend với giá trị
                AppendPieLegend(html, data, numSlices);

                // BƯỚC 13: Kết thúc HTML
                html.Append(@"</body></html>");

                // BƯỚC 14: Ghi vào file
                System.IO.File.WriteAllText(filePath, html.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== XUẤT BIỂU ĐỒ ĐƯỜNG ====================
        // 🎯 PURPOSE: Tạo biểu đồ đường (line chart) từ dữ liệu
        // 📊 INPUT: Dictionary<string, double>
        // 📈 ALGORITHM: Nối các điểm bằng đường thẳng (line segments)
        // ✅ USE CASE: Thống kê điểm trung bình theo học kỳ
        //
        // THUẬT TOÁN:
        // 1. Tính max value để scale Y-axis
        // 2. Tính vị trí mỗi điểm data dựa trên X-axis positions
        // 3. Dùng SVG <polyline> hoặc <path> với L command để nối điểm
        // 4. Vẽ markers (circles) tại mỗi data point
        // 5. Vẽ grid lines để dễ đọc giá trị
        public bool TaoBieuDoDuong(Dictionary<string, double> data, string filePath, string tieuDe = "Biểu Đồ Đường")
        {
            try
            {
                if (data == null || data.Count == 0)
                    return false;

                StringBuilder html = new StringBuilder();

                // BƯỚC 1: Tính toán data
                double maxValue = data.Values.Max();
                double minValue = Math.Min(0, data.Values.Min());
                double range = maxValue - minValue;
                if (range == 0) range = 1; // Tránh division by zero

                int numPoints = data.Count;
                int chartWidth = SVG_WIDTH - MARGIN_LEFT - MARGIN_RIGHT;
                int chartHeight = SVG_HEIGHT - MARGIN_TOP - MARGIN_BOTTOM;

                // BƯỚC 2: Tạo HTML header
                html.Append(CreateHTMLHeader($"Biểu Đồ Đường - {tieuDe}"));

                // BƯỚC 3: Bắt đầu SVG
                html.Append($@"<svg width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" style=""border: 1px solid #ccc;"">");

                // BƯỚC 4: Vẽ background
                html.Append($@"<rect width=""{SVG_WIDTH}"" height=""{SVG_HEIGHT}"" fill=""#FFFFFF""/>");

                // BƯỚC 5: Vẽ title
                html.Append($@"<text x=""{SVG_WIDTH / 2}"" y=""35"" text-anchor=""middle"" font-size=""24"" font-weight=""bold"" fill=""#333333"">");
                html.Append(System.Net.WebUtility.HtmlEncode(tieuDe));
                html.Append(@"</text>");

                // BƯỚC 6: Vẽ axes
                DrawAxes(html, chartWidth, chartHeight, maxValue);

                // BƯỚC 7: Vẽ grid lines (ngang)
                DrawGridLines(html, chartWidth, chartHeight, maxValue, minValue);

                // BƯỚC 8: Tính toán điểm data và vẽ line
                StringBuilder linePoints = new StringBuilder();
                double pointSpacing = (double)chartWidth / (numPoints - 1 > 0 ? numPoints - 1 : 1);
                int pointIndex = 0;

                foreach (var kvp in data)
                {
                    double value = kvp.Value;

                    // Tính toán vị trí điểm
                    double xPosition = MARGIN_LEFT + (pointIndex * pointSpacing);
                    double normalizedValue = (value - minValue) / range;
                    double yPosition = SVG_HEIGHT - MARGIN_BOTTOM - (normalizedValue * chartHeight);

                    // Thêm vào polyline points
                    if (pointIndex == 0)
                        linePoints.Append($"{xPosition:F0},{yPosition:F0}");
                    else
                        linePoints.Append($" {xPosition:F0},{yPosition:F0}");

                    pointIndex++;
                }

                // BƯỚC 9: Vẽ line (polyline)
                html.Append($@"<polyline points=""{linePoints}"" fill=""none"" stroke=""#45B7D1"" stroke-width=""3"" stroke-linejoin=""round""/>");

                // BƯỚC 10: Vẽ data points và labels
                pointIndex = 0;
                foreach (var kvp in data)
                {
                    string label = kvp.Key;
                    double value = kvp.Value;

                    double xPosition = MARGIN_LEFT + (pointIndex * pointSpacing);
                    double normalizedValue = (value - minValue) / range;
                    double yPosition = SVG_HEIGHT - MARGIN_BOTTOM - (normalizedValue * chartHeight);

                    // Vẽ marker (circle)
                    html.Append($@"<circle cx=""{xPosition:F0}"" cy=""{yPosition:F0}"" r=""5"" fill=""#45B7D1"" stroke=""#FFFFFF"" stroke-width=""2""/>");

                    // Vẽ giá trị trên điểm
                    html.Append($@"<text x=""{xPosition:F0}"" y=""{yPosition - 15}"" text-anchor=""middle"" font-size=""11"" fill=""#333333"">");
                    html.Append(value.ToString("F2"));
                    html.Append(@"</text>");

                    // Vẽ label bên dưới
                    html.Append($@"<text x=""{xPosition:F0}"" y=""{SVG_HEIGHT - MARGIN_BOTTOM + 20}"" ");
                    html.Append($@"text-anchor=""middle"" font-size=""11"" fill=""#666666"">");
                    html.Append(System.Net.WebUtility.HtmlEncode(label));
                    html.Append(@"</text>");

                    pointIndex++;
                }

                // BƯỚC 11: Kết thúc SVG
                html.Append(@"</svg>");

                // BƯỚC 12: Kết thúc HTML
                html.Append(@"</body></html>");

                // BƯỚC 13: Ghi vào file
                System.IO.File.WriteAllText(filePath, html.ToString(), Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== HELPER: VẼ AXES ====================
        // 🎯 PURPOSE: Vẽ X-axis và Y-axis với scales
        // 📊 INPUT: chart dimensions và max value
        private void DrawAxes(StringBuilder html, int chartWidth, int chartHeight, double maxValue)
        {
            // X-axis
            html.Append($@"<line x1=""{MARGIN_LEFT}"" y1=""{SVG_HEIGHT - MARGIN_BOTTOM}"" ");
            html.Append($@"x2=""{MARGIN_LEFT + chartWidth}"" y2=""{SVG_HEIGHT - MARGIN_BOTTOM}"" ");
            html.Append(@"stroke=""#333333"" stroke-width=""2""/>");

            // Y-axis
            html.Append($@"<line x1=""{MARGIN_LEFT}"" y1=""{MARGIN_TOP}"" ");
            html.Append($@"x2=""{MARGIN_LEFT}"" y2=""{SVG_HEIGHT - MARGIN_BOTTOM}"" ");
            html.Append(@"stroke=""#333333"" stroke-width=""2""/>");

            // Y-axis labels (scales)
            // Vẽ 5 labels trên Y-axis
            for (int i = 0; i <= 4; i++)
            {
                double yValue = maxValue * (4 - i) / 4;
                double yPosition = MARGIN_TOP + (i * chartHeight / 4);

                // Tick mark
                html.Append($@"<line x1=""{MARGIN_LEFT - 5}"" y1=""{yPosition}"" ");
                html.Append($@"x2=""{MARGIN_LEFT}"" y2=""{yPosition}"" ");
                html.Append(@"stroke=""#333333"" stroke-width=""1""/>");

                // Label
                html.Append($@"<text x=""{MARGIN_LEFT - 10}"" y=""{yPosition + 4}"" ");
                html.Append($@"text-anchor=""end"" font-size=""11"" fill=""#666666"">");
                html.Append(yValue.ToString("F1"));
                html.Append(@"</text>");
            }
        }

        // ==================== HELPER: VẼ GRID LINES ====================
        // 🎯 PURPOSE: Vẽ horizontal grid lines để dễ đọc giá trị
        private void DrawGridLines(StringBuilder html, int chartWidth, int chartHeight,
            double maxValue, double minValue)
        {
            int numLines = 5;
            for (int i = 0; i <= numLines; i++)
            {
                double yPosition = MARGIN_TOP + (i * chartHeight / numLines);

                html.Append($@"<line x1=""{MARGIN_LEFT}"" y1=""{yPosition}"" ");
                html.Append($@"x2=""{MARGIN_LEFT + chartWidth}"" y2=""{yPosition}"" ");
                html.Append(@"stroke=""#EEEEEE"" stroke-width=""1"" stroke-dasharray=""4,4""/>");
            }
        }

        // ==================== HELPER: APPEND LEGEND (BAR CHART) ====================
        private void AppendLegend(StringBuilder html, List<string> labels, int count)
        {
            html.Append(@"<div style=""margin-top: 20px; text-align: center;"">");
            html.Append(@"<h3>Chú Thích:</h3>");
            html.Append(@"<div style=""display: flex; flex-wrap: wrap; justify-content: center;"">");

            for (int i = 0; i < count; i++)
            {
                html.Append(@"<div style=""margin: 5px 10px; display: flex; align-items: center;"">");
                html.Append($@"<div style=""width: 20px; height: 20px; background-color: {COLORS[i % COLORS.Length]}; margin-right: 8px;""></div>");
                html.Append($@"<span>{System.Net.WebUtility.HtmlEncode(labels[i])}</span>");
                html.Append(@"</div>");
            }

            html.Append(@"</div></div>");
        }

        // ==================== HELPER: APPEND LEGEND (PIE CHART) ====================
        private void AppendPieLegend(StringBuilder html, Dictionary<string, double> data, int count)
        {
            double totalValue = data.Values.Sum();

            html.Append(@"<div style=""margin-top: 20px; text-align: center;"">");
            html.Append(@"<h3>Chú Thích:</h3>");
            html.Append(@"<div style=""display: flex; flex-wrap: wrap; justify-content: center;"">");

            int colorIndex = 0;
            foreach (var kvp in data)
            {
                string label = kvp.Key;
                double value = kvp.Value;
                double percentage = (value / totalValue) * 100;

                html.Append(@"<div style=""margin: 5px 10px; display: flex; align-items: center;"">");
                html.Append($@"<div style=""width: 20px; height: 20px; background-color: {COLORS[colorIndex % COLORS.Length]}; margin-right: 8px;""></div>");
                html.Append($@"<span>{System.Net.WebUtility.HtmlEncode(label)}: {percentage:F1}% ({value:F0})</span>");
                html.Append(@"</div>");

                colorIndex++;
            }

            html.Append(@"</div></div>");
        }

        // ==================== HELPER: CREATE HTML HEADER ====================
        private string CreateHTMLHeader(string title)
        {
            StringBuilder html = new StringBuilder();

            html.Append(@"<!DOCTYPE html>");
            html.Append(@"<html lang=""vi"">");
            html.Append(@"<head>");
            html.Append(@"<meta charset=""UTF-8"">");
            html.Append($@"<title>{System.Net.WebUtility.HtmlEncode(title)}</title>");
            html.Append(@"<style>");
            html.Append(@"body { font-family: Arial, sans-serif; margin: 20px; background-color: #F5F5F5; }");
            html.Append(@"svg { background-color: white; margin: 20px auto; display: block; }");
            html.Append(@"h1 { text-align: center; color: #333333; }");
            html.Append(@"h3 { text-align: center; color: #666666; }");
            html.Append(@"</style>");
            html.Append(@"</head>");
            html.Append(@"<body>");
            html.Append($@"<h1>{System.Net.WebUtility.HtmlEncode(title)}</h1>");

            return html.ToString();
        }

        // ==================== HELPER: CONVERT DEGREES TO RADIANS ====================
        // 🔢 PURPOSE: Toán học - chuyển đổi độ sang radian cho Math.Cos/Sin
        // 📐 FORMULA: radian = degree * (π / 180)
        private double DegToRad(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        // ==================== GIẢI THÍCH CHI TIẾT ====================
        //
        // 📊 SVG COORDINATE SYSTEM:
        //
        // SVG sử dụng coordinate system khác với hệ toán học:
        // - Gốc (0,0) ở TOP-LEFT corner (không phải bottom-left)
        // - X-axis: 0 = trái, x tăng = sang phải
        // - Y-axis: 0 = trên, y tăng = xuống dưới (NGƯỢC với toán học!)
        //
        // ⚠️ QUAN TRỌNG:
        // Khi vẽ biểu đồ, phải điều chỉnh giá trị Y:
        // yScreen = containerHeight - (normalizedValue * chartHeight)
        //
        // 📐 SVG ELEMENTS:
        //
        // <rect>: Hình chữ nhật
        //   <rect x="10" y="20" width="100" height="50" fill="#FF0000" />
        //   - x, y: vị trí top-left
        //   - width, height: kích thước
        //
        // <circle>: Hình tròn
        //   <circle cx="50" cy="50" r="40" fill="#00FF00" />
        //   - cx, cy: tâm (center X, center Y)
        //   - r: bán kính
        //
        // <path>: Đường tùy ý dùng commands
        //   <path d="M 10 10 L 90 90 Z" stroke="#000" fill="none" />
        //   Commands:
        //   - M x y: Move to (moveto)
        //   - L x y: Line to
        //   - H x: Horizontal line to x
        //   - V y: Vertical line to y
        //   - A rx ry x-axis-rotation large-arc-flag sweep-flag x y: Arc
        //   - Z: Close path
        //
        // 🎨 VÍ DỤ PIE CHART ARC:
        //
        // Vẽ pie slice từ 45° đến 135°:
        // - Tâm tròn: (200, 200)
        // - Bán kính: 150
        // - Start angle: 45° = 45 * π/180 rad
        // - End angle: 135° = 135 * π/180 rad
        //
        // Điểm bắt đầu:
        // startX = 200 + 150 * cos(45°) = 200 + 106.06 = 306.06
        // startY = 200 + 150 * sin(45°) = 200 + 106.06 = 306.06
        //
        // Điểm kết thúc:
        // endX = 200 + 150 * cos(135°) = 200 - 106.06 = 93.94
        // endY = 200 + 150 * sin(135°) = 200 + 106.06 = 306.06
        //
        // SVG Path:
        // M 200 200 L 306.06 306.06 A 150 150 0 0 1 93.94 306.06 Z
        // - M: Di chuyển đến tâm
        // - L: Vẽ đường thẳng đến điểm bắt đầu arc
        // - A: Vẽ arc (large-arc-flag=0 vì < 180°)
        // - Z: Đóng path
        //
        // 📈 SCALING DATA TO PIXELS:
        //
        // Công thức chung:
        // pixelValue = containerStart + (normalizedValue * containerSize)
        //
        // Ví dụ:
        // - Min value: 10, Max value: 100
        // - Chart height: 400 pixels
        // - Data point: 50
        //
        // Normalized (0-1 scale): (50 - 10) / (100 - 10) = 0.444
        // Pixel Y position: 400 - (0.444 * 400) = 222.4
        //
        // 🎓 VIEWBOX ATTRIBUTE:
        //
        // viewBox="minX minY width height"
        // Định nghĩa coordinate space cho SVG:
        // - (minX, minY): góc top-left của logical coordinate
        // - width, height: logical kích thước
        //
        // Ví dụ:
        // <svg width="400" height="300" viewBox="0 0 100 75">
        // - Physical size: 400x300 pixels
        // - Logical size: 100x75 units
        // - 1 logical unit = 4x4 pixels
        //
        // ⏱️ TIME COMPLEXITY:
        // - TaoBieuDoCot: O(n) where n = số bars
        // - TaoBieuDoTron: O(n) where n = số slices
        // - TaoBieuDoDuong: O(n) where n = số points
        //
        // 💾 SPACE COMPLEXITY:
        // - O(n) for StringBuilder storing SVG
        // - O(1) for computations
    }
}
