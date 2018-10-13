using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RK = Terminal_Ballistics.RungeKutta;

namespace Terminal_Ballistics
{
    public partial class FrmPlots : Form
    {
        public FrmPlots()
        {
            InitializeComponent();
        }
        // Для того, чтобы выбрать минимальный или максимальный диапазон для
        // наиболее амплитудного графика
        double AxMin, AxMax;

        private void button1_Click(object sender, EventArgs e)
        {
            // Очистка пространства, обнуление диапазона по оси у
            chartPlots.Series.Clear();
            AxMin = 0; AxMax = 0;
            // Творим ось х и настраиваем её от нуля до максимального t
            double[] xAx = RK.Axis[cbXAxis.Text];
            chartPlots.ChartAreas[0].AxisX.Minimum = xAx.Min();
            chartPlots.ChartAreas[0].AxisX.Maximum = xAx.Max();
            chartPlots.ChartAreas[0].AxisX.Interval = Math.Round(Math.Abs(xAx.Max() - xAx.Min())) / 10.0;
            // Строим графики
            foreach (string s in clbYAxis.CheckedItems)
            {
                // Создаётся серия под один график; тип -- линия
                Series ser = new Series(s);
                ser.ChartType = SeriesChartType.Line;
                // Создаются ось у и min, max значения по ней
                double[] yAx = RK.Axis[s];
                if (AxMin > yAx.Min())
                    AxMin = yAx.Min();
                chartPlots.ChartAreas[0].AxisY.Minimum = AxMin;
                if (AxMax < yAx.Max())
                    AxMax = yAx.Max();
                chartPlots.ChartAreas[0].AxisY.Maximum = AxMax;
                chartPlots.ChartAreas[0].AxisY.Interval = Math.Round(Math.Abs(AxMax - AxMin)) / 10.0;
                // Построение, добавление в чарт
                for (int i = 0; i <= RK.t_Arr.Count() - 2; i++)
                    ser.Points.AddXY(xAx[i], yAx[i]);
                chartPlots.Series.Add(ser);
            }
        }

        private void cbXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXAxis.SelectedIndex != -1)
                btnPlot.Enabled = true;
        }

        private void FrmPlots_Load(object sender, EventArgs e)
        {
            //chartPlots.ChartAreas[0].AxisX.ScaleView.Zoom(0, 0.02);
            chartPlots.ChartAreas[0].CursorX.IsUserEnabled = true;
            chartPlots.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chartPlots.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chartPlots.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            // chartPlots.ChartAreas[0].AxisY.ScaleView.Zoom(0, 0);
            chartPlots.ChartAreas[0].CursorY.IsUserEnabled = true;
            chartPlots.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chartPlots.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chartPlots.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
        }
    }
}
