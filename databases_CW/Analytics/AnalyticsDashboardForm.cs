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



namespace databases_CW.Analytics
{
    public partial class AnalyticsDashboardForm : Form
    {
        public AnalyticsDashboardForm()
        {
            InitializeComponent();

            // Создаем форму для графика
            var formsPlot = new FormsPlot();
            formsPlot.Dock = DockStyle.Fill;
            this.Controls.Add(formsPlot);

            // Генерируем данные
            Random rand = new Random();
            int pointCount = 100;
            double[] xs = new double[pointCount];
            double[] ys = new double[pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                xs[i] = i + rand.NextDouble() * 2;
                ys[i] = Math.Sin(i * 0.05) * 20 + rand.NextDouble() * 10;
            }

            // Создаем scatter plot - ПРАВИЛЬНЫЙ СИНТАКСИС
            var scatter = formsPlot.Plot.Add.Scatter(xs, ys);
            scatter.LineWidth = 0; // Только точки

            // Правильный способ задания маркера
            scatter.MarkerSize = 8;
            scatter.MarkerStyle = new ScottPlot.MarkerStyle(
                ScottPlot.MarkerShape.OpenCircle,
                8,
                ScottPlot.Color.FromHex("#2196F3")
            );

            scatter.Color = ScottPlot.Color.FromHex("#2196F3");

            // Настройка графика
            formsPlot.Plot.Title("Scatter Plot Demo");
            formsPlot.Plot.XLabel("X Values");
            formsPlot.Plot.YLabel("Y Values");
            formsPlot.Plot.Axes.SetLimits(0, 120, -30, 30);

            formsPlot.Refresh();
        }

        

        private void AnalyticsDashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
