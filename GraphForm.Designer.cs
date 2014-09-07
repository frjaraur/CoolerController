namespace CoolerController
{
    partial class GraphForm
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
        {            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonCloseGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDataGraph
            // 
            this.chartDataGraph.BorderlineWidth = 4;
            chartArea1.AxisY.Maximum = 50D;
            chartArea1.AxisY.Minimum = -10D;
            chartArea1.Name = "ChartArea1";
            this.chartDataGraph.ChartAreas.Add(chartArea1);
            this.chartDataGraph.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartDataGraph.Legends.Add(legend1);
            this.chartDataGraph.Location = new System.Drawing.Point(0, 0);
            this.chartDataGraph.Margin = new System.Windows.Forms.Padding(0);
            this.chartDataGraph.Name = "chartDataGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDataGraph.Series.Add(series1);
            this.chartDataGraph.Size = new System.Drawing.Size(687, 428);
            this.chartDataGraph.TabIndex = 0;
            this.chartDataGraph.Text = "chart1";
            this.chartDataGraph.Click += new System.EventHandler(this.chart1_Click);
            // 
            // buttonCloseGraph
            // 
            this.buttonCloseGraph.Location = new System.Drawing.Point(612, 431);
            this.buttonCloseGraph.Name = "buttonCloseGraph";
            this.buttonCloseGraph.Size = new System.Drawing.Size(75, 23);
            this.buttonCloseGraph.TabIndex = 8;
            this.buttonCloseGraph.Text = "Close";
            this.buttonCloseGraph.UseVisualStyleBackColor = true;
            this.buttonCloseGraph.Click += new System.EventHandler(this.buttonCloseGraph_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 457);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCloseGraph);
            this.Controls.Add(this.chartDataGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GraphForm";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDataGraph)).EndInit();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDataGraph;
        private System.Windows.Forms.Button buttonCloseGraph;

    }
}