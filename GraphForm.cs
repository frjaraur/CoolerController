using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace CoolerController
{
    public partial class GraphForm : Form
    {
        Timer graphtimer = new Timer();
        string graphdatafile = "";
        //Tiempo(s)	Temp	TlenteA	TlenteB	Hr%	P.Rocio	PA	PB	V	I	Start	ManA	ManB	PIDoutA	PIDoutB	SetPoint
        //string[] arrayavailabledatalabels = new string[13] { "Temp", "TlenteA", "TlenteB", "Hr%", "P.Rocio", "PA", "PB", "V", "I", "Start", "ManA", "ManB", "PIDoutA" };
        string datalabel = "Temperatura";
    

        public GraphForm(string myfilename)
        {
            
            InitializeComponent();
            graphtimer.Tick += new EventHandler(graphtimer_Tick);
            graphtimer.Interval = (1000) * (30);            // Cada 30 segundos
  
            graphtimer.Enabled = true;
            graphtimer.Start();
            graphdatafile = myfilename;
        }
        public string myfilename { get; set; }


        private void chart1_Click(object sender, EventArgs e)
        {
            GraphData(datalabel);

        }



        void graphtimer_Tick(object sender, EventArgs e)
        {
            if (graphdatafile != "")
            {
                GraphData(datalabel);
            }

        }


        public void GraphData(string datalabel)
        {
            //int datalabelposition = Array.IndexOf(arrayavailabledatalabels, datalabel);
            //datalabelposition = datalabelposition +2;
            chartDataGraph.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chartDataGraph.Series["Series1"].Color = Color.Red;
            chartDataGraph.Series["Series1"].BorderWidth = 2;
            chartDataGraph.Series["Series1"].BorderDashStyle = ChartDashStyle.Solid;
            chartDataGraph.Series["Series1"].Points.Clear();

            chartDataGraph.Series["Series1"].LegendText = datalabel;

            try
            {
                using (FileStream fileStream = new FileStream(graphdatafile, FileMode.Open, FileAccess.Read, FileShare.Write))
                {
                    using (TextReader tr = new StreamReader(fileStream))
                    {
                        //string lineread = tr.ReadToEnd();


                        string lineread;
                        while ((lineread = tr.ReadLine()) != null)
                        {
                            char[] charsToTrim = { ' ', '\t' };
                            string lineTrimed = lineread.Trim(charsToTrim);
                            //MessageBox.Show(lineTrimed);
                            //string RXStringTrimed = RxString.Trim();
                            if (!String.IsNullOrWhiteSpace(lineTrimed))
                            {
                                lineTrimed = lineTrimed.Replace("\t", " ");
                                // lineTrimed = lineTrimed.Replace("\n", ";");

                                string[] datalinearray = lineTrimed.Split(',');
                                int datalinecount = datalinearray.Length;
                                //MessageBox.Show(datalinearray[0] + " --- " + datalinearray[1]);
                                //datalinearray[datalabelposition]
                                //18/05/2014 20:49:05
                                DateTime readdatetime = DateTime.ParseExact(datalinearray[0], "dd/MM/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture);

                                //MessageBox.Show(readdatetime.ToString("HH:mm:ss") + " --- " + datalinearray[1]);
                                chartDataGraph.Series["Series1"].Points.AddXY(readdatetime.ToString("HH:mm:ss"), datalinearray[1]);
                                //MessageBox.Show(lineTrimed);

                                //double nextX = 1;

                                //if (chartDataGraph.Series["Series1"].Points.Count > 0)
                                //{
                                //    nextX = chartDataGraph.Series["Series1"].Points[chartDataGraph.Series["Series1"].Points.Count - 1].XValue + 1;
                                //}

                                //Add a new value to the Series
                               // Random rnd = new Random();
                                //chartDataGraph.Series["Series1"].Points.AddXY(nextX, (rnd.NextDouble() * 10) - 5);

                                //Remove Points on the left side after 100
                                while (chartDataGraph.Series["Series1"].Points.Count > 100)
                                {
                                    chartDataGraph.Series["Series1"].Points.RemoveAt(0);
                                }

                                //Set the Minimum and Maximum values for the X Axis on the Chart
                                //double min = chartDataGraph.Series["Series1"].Points[0].XValue;
                                //chartDataGraph.ChartAreas[0].AxisX.Minimum = min;
                                //chartDataGraph.ChartAreas[0].AxisX.Maximum = min + 100;




                            }
                        }

                    }
                }
            }
            catch (System.IO.IOException tmperror)
            {
                // MessageBox.Show(tmperror.Message);
                return;
            }

 

        }
        
        private void GraphForm_Load(object sender, EventArgs e)
        {
            datalabel = "Temp";
            GraphData("Temp");

        }

        private void buttonCloseGraph_Click(object sender, EventArgs e)
        {
            graphdatafile = "";
            this.Close();
        }

        

    }
}
