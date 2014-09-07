using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CoolerController
{
    public partial class SmallForm : Form
    {
        Timer mytimer = new Timer();
        public string smalluidatafile = "";
        
        public SmallForm(string myfilename)
        {           
            InitializeComponent();
            mytimer.Tick += new EventHandler(mytimer_Tick);
            mytimer.Interval = (1000) * (1);            // Cada 1segundos
            mytimer.Enabled = true;
            mytimer.Start();
            smalluidatafile = myfilename;
            
        }

        public string myfilename { get; set; }

        void mytimer_Tick(object sender, EventArgs e)
        {
            if (smalluidatafile != ""){
             LoadSmallUIData(smalluidatafile);
            }
        }

        void LoadSmallUIData(string smalluidatafile)
        {
            try
            {
                using (FileStream fileStream = new FileStream(smalluidatafile, FileMode.Open, FileAccess.Read, FileShare.Write))
                {
                    using (TextReader tr = new StreamReader(fileStream))
                    {
                        string lineread;
                        while ((lineread = tr.ReadLine()) != null)
                        {
                            char[] charsToTrim = { ' ', '\t' };
                            string lineTrimed = lineread.Trim(charsToTrim);

                            //string RXStringTrimed = RxString.Trim();
                            if (!String.IsNullOrWhiteSpace(lineTrimed))
                            {
                                lineTrimed = lineTrimed.Replace("\t", " ");


                                string[] datalinearray = lineTrimed.Split(',');
                                int datalinecount = datalinearray.Length;

                                labelSmallUITime.Text = datalinearray[0];

//                                chartDataGraph.Series["Series1"].Points.AddXY(datalinearray[0], datalinearray[datalabelposition]);
                                //MessageBox.Show(lineTrimed);
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

        private void buttonMainForm_Click(object sender, EventArgs e)
        {
            Form MainForm = new MainForm();
           // MainForm.Show();
            MainForm.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
    }
}
