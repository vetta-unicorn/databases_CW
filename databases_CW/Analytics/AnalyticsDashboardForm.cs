using LiveCharts.Definitions.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;
using static OfficeOpenXml.ExcelErrorValue;



namespace databases_CW.Analytics
{
    public partial class AnalyticsDashboardForm : Form
    {
        List<PieSlice> slices = new List<PieSlice>();
        List<PieSlice> price_slices = new List<PieSlice>();
        List<ScottPlot.Color> colors;
        string connectionString = "Host=localhost;Database=bookshop;Username=elisabeth_adm;Password=adm;";
        public AnalyticsDashboardForm()
        {
            InitializeComponent();
            colors = new List<ScottPlot.Color>()
            { Colors.Red, Colors.Orange, Colors.Gold, Colors.Green,
            Colors.Blue, Colors.Brown, Colors.DimGray, Colors.Crimson};
            MakePricesPie();
            MakeCitiesBarSimple();
            MakeYearOrders();
            CategoriesBookPrices();
        }

        private void MakePricesPie()
        {
            int i = 0;
            string pricesQuery =
            "SELECT b.theme, COUNT(b.id)\r\n" +
            "FROM books b\r\nJOIN bought_items i ON i.book_id = b.id " +
            "\r\nGROUP BY b.theme;";

            CountDiagram pieDiag = new CountDiagram();
            pieDiag.CreateDiag(connectionString, pricesQuery);
            Dictionary<string, int> dict = pieDiag.ItemsToCount;
            foreach (var item in dict)
            {
                slices.Add(new PieSlice
                {
                    Value = item.Value,
                    FillColor = colors[i],
                    Label = item.Key
                });
                if (i != dict.Count - 1) i++;
            }
            var pie = formsPlot1.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = 1.4;

            formsPlot1.Plot.ShowLegend();

            formsPlot1.Plot.Axes.Frameless();
            formsPlot1.Plot.HideGrid();

            formsPlot1.Refresh();
        }

        private void CategoriesBookPrices()
        {
            int i = 0;
            string pricesQuery =
                "SELECT \r\n    category,\r\n   " +
                " COUNT(*) AS количество_книг\r\n" +
                "FROM (\r\n    SELECT \r\n        " +
                "CASE \r\n " +
                "WHEN i.price < 300 THEN 'эконом'\r\n    " +
                "WHEN i.price BETWEEN 300 AND 800 THEN 'стандарт'\r\n" +
                "WHEN i.price > 800 THEN 'премиум'\r\n" +
                "ELSE 'не определена'\r\n" +
                "END AS category\r\nFROM items i\r\n" +
                "LEFT JOIN books b ON b.id = i.book_id\r\n) " +
                "AS categorized_books\r\nGROUP BY category\r\n" +
                "ORDER BY \r\n    CASE \r\n" +
                "WHEN category = 'эконом' THEN 1\r\n" +
                "WHEN category = 'стандарт' THEN 2\r\n" +
                "WHEN category = 'премиум' THEN 3\r\n" +
                "ELSE 4\r\nEND;";

            CountDiagram pieDiag = new CountDiagram();
            pieDiag.CreateDiag(connectionString, pricesQuery);
            Dictionary<string, int> dict = pieDiag.ItemsToCount;
            foreach (var item in dict)
            {
                price_slices.Add(new PieSlice
                {
                    Value = item.Value,
                    FillColor = colors[i],
                    Label = item.Key
                });
                if (i != dict.Count - 1) i++;
            }
            var pie = formsPlot4.Plot.Add.Pie(price_slices);
            pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = 1.4;

            formsPlot4.Plot.ShowLegend();

            formsPlot4.Plot.Axes.Frameless();
            formsPlot4.Plot.HideGrid();

            formsPlot4.Refresh();
        }

        private void MakeCitiesBarSimple()
        {
            string citiesQuery =
                "SELECT c.name, COUNT(e.id)" +
                "\r\nFROM cities c\r\nJOIN employees e " +
                "ON e.city_id = c.id\r\nGROUP BY c.name";

            CountDiagram barDiag = new CountDiagram();
            barDiag.CreateDiag(connectionString, citiesQuery);
            Dictionary<string, int> dict = barDiag.ItemsToCount;
            double[] values = new double[dict.Count];
            string[] dKeys = new string[dict.Count];
            int i = 0;

            foreach (var num in dict)
            {
                double tmp = Convert.ToDouble(num.Value);
                values[i] = tmp;
                dKeys[i] = num.Key;
                i++;
            }

            int k = 0;

            var barPlot = formsPlot2.Plot.Add.Bars(values);
            foreach (var bar in barPlot.Bars)
            {
                bar.Label = dKeys[k];
                k++;
            }

            barPlot.ValueLabelStyle.Bold = true;
            barPlot.ValueLabelStyle.FontSize = 18;
            barPlot.Horizontal = true;

            formsPlot2.Plot.Axes.SetLimitsX(0, 30);
            formsPlot2.Plot.Add.VerticalLine(0, 1, Colors.Black);

            formsPlot2.Refresh();

        }

        private void MakeYearOrders()
        {
            string orderQuery =
                "SELECT \r\nTO_CHAR(order_date, 'Month') AS month_name," +
                "\r\n\tCOUNT(*) AS orders_count" +
                "\r\nFROM orders\r\n" +
                "WHERE EXTRACT(YEAR FROM order_date) = EXTRACT(YEAR FROM CURRENT_DATE)" +
                "\r\nGROUP BY TO_CHAR(order_date, 'Month')\r\n" +
                "ORDER BY MIN(EXTRACT(MONTH FROM order_date));";

            CountDiagram yearDiag = new CountDiagram();
            yearDiag.CreateDiag(connectionString, orderQuery);
            Dictionary<string, int> dict = yearDiag.ItemsToCount;

            if (dict.Count == 0)
            {
                MessageBox.Show("Нет данных о заказах за текущий год");
                return;
            }
            var sortedDict = dict.OrderBy(kv => MonthToNum.ReturnNum(kv.Key.Trim()))
                                 .ToDictionary(kv => kv.Key, kv => kv.Value);

            double[] xMonths = new double[sortedDict.Count];
            double[] yOrders = new double[sortedDict.Count];
            string[] monthLabels = new string[sortedDict.Count];

            int i = 0;
            foreach (var item in sortedDict)
            {
                string monthName = item.Key.Trim();
                monthLabels[i] = monthName;
                xMonths[i] = MonthToNum.ReturnNum(monthName);
                yOrders[i] = item.Value;
                i++;
            }

            formsPlot3.Plot.Clear();

            var scatter = formsPlot3.Plot.Add.Scatter(xMonths, yOrders);
            scatter.LineWidth = 2;
            scatter.MarkerSize = 8;
            scatter.Color = ScottPlot.Colors.RebeccaPurple;

            formsPlot3.Plot.Axes.Bottom.Label.Text = "Месяц";

            formsPlot3.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot3.Plot.Axes.Bottom.TickLabelStyle.Alignment = Alignment.UpperLeft;

            formsPlot3.Plot.Axes.Left.Label.Text = "Количество заказов";

            formsPlot3.Plot.Axes.Margins(bottom: 0.2, left: 0.05);


            formsPlot3.Refresh();
        }

        private void ExportAllPlotsToPng()
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Выберите папку для сохранения диаграмм";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;

                    formsPlot1.Plot.SavePng(Path.Combine(folderPath, "Круговая_диаграмма_книги.png"),
                                           formsPlot1.Width, formsPlot1.Height);

                    formsPlot2.Plot.SavePng(Path.Combine(folderPath, "Столбчатая_диаграмма_сотрудники.png"),
                                           formsPlot2.Width, formsPlot2.Height);

                    formsPlot3.Plot.SavePng(Path.Combine(folderPath, "График_заказов_по_месяцам.png"),
                                           formsPlot3.Width, formsPlot3.Height);

                    formsPlot4.Plot.SavePng(Path.Combine(folderPath, "График_книг_категоризация_цены.png"),
                                           formsPlot4.Width, formsPlot4.Height);

                    MessageBox.Show($"Все диаграммы сохранены в папке:\n{folderPath}",
                                  "Экспорт завершен",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
        }

        // выход на главную
        private void button1_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        // экспорт графиков
        private void button2_Click(object sender, EventArgs e)
        {
            ExportAllPlotsToPng();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
