namespace Terminal_Ballistics
{
    partial class FrmPlots
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnPlot = new System.Windows.Forms.Button();
            this.chartPlots = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clbYAxis = new System.Windows.Forms.CheckedListBox();
            this.gbPlotYAxis = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbXAxis = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlots)).BeginInit();
            this.gbPlotYAxis.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlot
            // 
            this.btnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlot.Enabled = false;
            this.btnPlot.Location = new System.Drawing.Point(12, 554);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(123, 42);
            this.btnPlot.TabIndex = 0;
            this.btnPlot.Text = "Построить графики";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartPlots
            // 
            this.chartPlots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartPlots.ChartAreas.Add(chartArea2);
            this.chartPlots.Cursor = System.Windows.Forms.Cursors.Cross;
            legend2.Name = "Legend1";
            this.chartPlots.Legends.Add(legend2);
            this.chartPlots.Location = new System.Drawing.Point(0, 27);
            this.chartPlots.Name = "chartPlots";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.LegendText = "sin(x)";
            series2.Name = "Series1";
            this.chartPlots.Series.Add(series2);
            this.chartPlots.Size = new System.Drawing.Size(844, 505);
            this.chartPlots.TabIndex = 1;
            this.chartPlots.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Графики";
            this.chartPlots.Titles.Add(title2);
            // 
            // clbYAxis
            // 
            this.clbYAxis.CheckOnClick = true;
            this.clbYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbYAxis.FormattingEnabled = true;
            this.clbYAxis.Items.AddRange(new object[] {
            "t",
            "X",
            "Y",
            "Z",
            "Vx",
            "Vy",
            "Vz",
            "V",
            "ωx",
            "ωy",
            "ωz",
            "ω",
            "Fx",
            "Fy",
            "Fz",
            "F",
            "Mx",
            "My",
            "Mz",
            "M",
            "θ",
            "Ψ",
            "φ",
            "x"});
            this.clbYAxis.Location = new System.Drawing.Point(3, 16);
            this.clbYAxis.MultiColumn = true;
            this.clbYAxis.Name = "clbYAxis";
            this.clbYAxis.Size = new System.Drawing.Size(369, 126);
            this.clbYAxis.TabIndex = 2;
            // 
            // gbPlotYAxis
            // 
            this.gbPlotYAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPlotYAxis.Controls.Add(this.clbYAxis);
            this.gbPlotYAxis.Location = new System.Drawing.Point(469, 538);
            this.gbPlotYAxis.Name = "gbPlotYAxis";
            this.gbPlotYAxis.Size = new System.Drawing.Size(375, 145);
            this.gbPlotYAxis.TabIndex = 3;
            this.gbPlotYAxis.TabStop = false;
            this.gbPlotYAxis.Text = "Ось Y";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // cbXAxis
            // 
            this.cbXAxis.FormattingEnabled = true;
            this.cbXAxis.Items.AddRange(new object[] {
            "t",
            "X",
            "Y",
            "Z",
            "Vx",
            "Vy",
            "Vz",
            "V",
            "ωx",
            "ωy",
            "ωz",
            "ω",
            "Fx",
            "Fy",
            "Fz",
            "F",
            "Mx",
            "My",
            "Mz",
            "M",
            "θ",
            "Ψ",
            "φ",
            "x"});
            this.cbXAxis.Location = new System.Drawing.Point(345, 554);
            this.cbXAxis.Name = "cbXAxis";
            this.cbXAxis.Size = new System.Drawing.Size(121, 21);
            this.cbXAxis.TabIndex = 24;
            this.cbXAxis.SelectedIndexChanged += new System.EventHandler(this.cbXAxis_SelectedIndexChanged);
            // 
            // FrmPlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 682);
            this.Controls.Add(this.cbXAxis);
            this.Controls.Add(this.gbPlotYAxis);
            this.Controls.Add(this.chartPlots);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(860, 720);
            this.Name = "FrmPlots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графики";
            this.Load += new System.EventHandler(this.FrmPlots_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlots)).EndInit();
            this.gbPlotYAxis.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlots;
        private System.Windows.Forms.CheckedListBox clbYAxis;
        private System.Windows.Forms.GroupBox gbPlotYAxis;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbXAxis;
    }
}