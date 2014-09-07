using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;



namespace CoolerController
{
    public partial class MainForm : Form
    {

        string RxString;
        //int myBytes;
        Timer timer = new Timer();
        Timer SaveToFileTimer = new Timer();
        Timer SaveToTmpFileTimer = new Timer();
        bool savetofile = false;
        string savefilename;
        string DEBUGText;
        //string ERROText;
        bool connected = false;
        //DateTime previousDataTime;
        int intervalo_ejecucion_controlador = 5;
        string tempfolder = Environment.GetEnvironmentVariable("TEMP");
        string tempfile= Environment.GetEnvironmentVariable("TEMP")+ "\\" + Application.ProductName + ".tmp";

        decimal Temperature;
        int ErrorTemp = 30;
        int CriticalTemp = 20;
        int WarningTemp = 10;
        int CoolingTemp = 5;


        string RXStringTrimed="";
        string DataTime="";

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Arduino DSLR Cooling";
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (1000) * (1);            // Cada 1segundos
            timer.Enabled = true;                      
            timer.Start();
            SaveToFileTimer.Tick += new EventHandler(SaveToFileTimer_Tick);
            SaveToFileTimer.Interval = (1000) * (60);            // Cada 60 segundos
            SaveToFileTimer.Enabled = true;
            SaveToFileTimer.Start();

            SaveToTmpFileTimer.Tick += new EventHandler(SaveToTmpFileTimer_Tick);
            SaveToTmpFileTimer.Interval = (1000) * (15);            // Cada 60 segundos
            SaveToTmpFileTimer.Enabled = true;
            SaveToTmpFileTimer.Start();      


        }




        void SaveToFileTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(DataTime + " " + RXStringTrimed);
            if (DataTime != "")
            {
                if (savetofile == true)
                {

                    //FileMode.Open, FileAccess.ReadWrite, FileShare.Read)
                    StringBuilder sb = new StringBuilder();
                    //sb.AppendLine(DataTime + "," + RXStringTrimed + "\n");
                    sb.AppendLine(DataTime + "," + RXStringTrimed);

                    FileStream fileStream = new FileStream(savefilename, FileMode.Append, FileAccess.Write, FileShare.Read);
                    using (TextWriter tw = new StreamWriter(fileStream))
                    {
                        tw.Write(sb.ToString());
                        tw.Close();
                    }

                    //File.AppendAllText(savefilename, sb.ToString());
                    DEBUGText = "SerialPortData saved...";
                    this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));

                }



            }
        }

            void SaveToTmpFileTimer_Tick(object sender, EventArgs e)
        {
            if (DataTime != "")
            {
                StringBuilder sbtemp = new StringBuilder();
                sbtemp.AppendLine(DataTime + "," + RXStringTrimed);

                FileStream tempfileStream = new FileStream(tempfile, FileMode.Append, FileAccess.Write, FileShare.Read);
                using (TextWriter temptw = new StreamWriter(tempfileStream))
                {
                    temptw.Write(sbtemp.ToString());
                    temptw.Close();
                }





            }


        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {

            try
            {
                serialPortCoolerController.PortName = this.comboBoxSelectPorts.SelectedItem.ToString();

                serialPortCoolerController.BaudRate = 9600;

                serialPortCoolerController.Open();


                serialPortCoolerController.Handshake = Handshake.None;

                serialPortCoolerController.WriteTimeout = 5000;
                serialPortCoolerController.ReadTimeout = 5000;

                if (serialPortCoolerController.IsOpen)
                {
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    comboBoxSelectPorts.Enabled = false;
                    textBoxData.ReadOnly = false;
                    textBoxComStatus.BackColor = Color.Green;
                    connected = true;

                    File.WriteAllText(tempfile, String.Empty);
                    File.CreateText(tempfile).Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No es posible la conexion","Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPortCoolerController.IsOpen)
            {
                serialPortCoolerController.Close();
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                comboBoxSelectPorts.Enabled = true;
                textBoxData.ReadOnly = true;
                textBoxComStatus.BackColor = Color.Red;
                connected = true;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortCoolerController.IsOpen) serialPortCoolerController.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the port is closed, don't try to send a character.
            if (!serialPortCoolerController.IsOpen) return;

            // If the port is Open, declare a char[] array with one element.
            char[] buff = new char[1];

            // Load element 0 with the key character.
            buff[0] = e.KeyChar;

            // Send the one character buffer.
            serialPortCoolerController.Write(buff, 0, 1);

            // Set the KeyPress event as handled so the character won't
            // display locally. If you want it to display, omit the next line.
            e.Handled = true;
        }

       private void DisplayDEBUGWindowINFO(object sender, EventArgs e)
        {
            //DEBUGText = " INFO: " + DateTime.Now.ToString() + " select port.";
            //this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));
            //string DataTime = DateTime.Now.ToString();
            textBoxInfo.Text = " INFO: " + DateTime.Now.ToString() + " " + DEBUGText; // +Convert.ToString(RxArrayCount);
            DEBUGText="";
        }
        private void DisplayText(object sender, EventArgs e)
        {
            DataTime = DateTime.Now.ToString();
            //string DataTime = DateTime.Now.ToString();
            //previousDataTime = DateTime.Now.AddSeconds(30);
            //textBoxData.AppendText(DataTime + "\t" + RxString + "\n");

            //char[] charsToTrim = { ' ', '\t' };
            //string RXStringTrimed = RxString.Trim(charsToTrim);
            //string RXStringTrimed = RxString.Trim();
            //string RXStringTrimed = RxString.Replace("\t", ",");

            RXStringTrimed = Regex.Replace(RxString, @"\s+", ",");
            //string RXStringTrimed = Regex.Replace(RxString, @"\s+", ",");

            //RXStringTrimed = RxString.Replace("  ", " ");
            //RegexOptions options = RegexOptions.None;
            //Regex regex = new Regex("\t", options);
            //RXStringTrimed = regex.Replace(RXStringTrimed, ",");
            //MessageBox.Show(RXStringTrimed);


            textBoxData.AppendText(DataTime + "\t" + RXStringTrimed + "\n");


            RXStringTrimed = RXStringTrimed.Replace(" ", ",");
          
            string[] RxArray = RXStringTrimed.Split(',');
            
            int RxArrayCount=RxArray.Length;
            
           // MessageBox.Show(Convert.ToString(RxArrayCount));
            //textBoxInfo.Text = " INFO: " + DataTime + " SerialPortData received...";// +Convert.ToString(RxArrayCount);

            DEBUGText = "SerialPortData received...";
            this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));

            labelTemperatureValue.ForeColor = Color.Green;
            
            if (RxArrayCount == 2) {
                
                labelTimer.Text = DataTime;
                //if (Int32.TryParse(RxArray[0], -1)) { 
                string tempTempData = RxArray[0];
                tempTempData = tempTempData.Replace('.', ',');
                Temperature = Decimal.Parse(tempTempData);
                Temperature = Decimal.Round(Temperature);
                //MessageBox.Show(">>> " + Temperature);
                    

                //}
                //Int32 Temperature = Convert.ToInt32(RxArray[0]);

                //int Temperature = RxArray[0];
                if (Temperature == -1000) {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        labelTemperatureValue.Visible = false;
                        labelTemperatureValue.Visible = true;
                        labelTemperatureValue.ForeColor = Color.Red;
                        System.Media.SystemSounds.Hand.Play();
                        Temperature = 0;
                        labelTemperatureValue.Text = "ERROR";
                    }

                }else {
                    if (Temperature >= CoolingTemp) { labelTemperatureValue.ForeColor = Color.White; }
                    if (Temperature >= WarningTemp) { labelTemperatureValue.ForeColor = Color.Cyan; }
                    if (Temperature >= CriticalTemp) { labelTemperatureValue.ForeColor = Color.Orange; }
                    if (Temperature >= ErrorTemp) { labelTemperatureValue.ForeColor = Color.Red; System.Media.SystemSounds.Hand.Play(); }
                
                    labelTemperatureValue.Text = Convert.ToString(Temperature)+"C";
                }
            }




        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           // try
           // {

                if (connected == true)
                {
                    //DateTime NowDataTime=DateTime.Now;
                    //MessageBox.Show(Convert.ToString(previousDataTime.Subtract(NowDataTime)));
                    if (!serialPortCoolerController.IsOpen) { serialPortCoolerController.Open(); } 
                    RxString = serialPortCoolerController.ReadLine();
                    if (RxString == null ) { MessageBox.Show("ERROR"); }


                }
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("error writing to serial port:" + ex.Message, "Error");
            //}

           
            this.Invoke(new EventHandler(DisplayText));

        }


        public string comboBox1_SelectedIndexChangedx { get; set; }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.comboBoxSelectPorts.Text = "Puerto COM";
            this.comboBoxSelectPorts.Items.Clear();
            DEBUGText = "Seleccionar COM";
            this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));
            this.comboBoxSelectPorts.Items.AddRange(SerialPort.GetPortNames());
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            this.textBoxData.Clear(); 
        }



        private void buttonWriteDataToFile_Click(object sender, EventArgs e)
        {
            if (connected == true)
            {
                SaveFileDialog saveFileDialogWriteDataToFile = new SaveFileDialog();
                saveFileDialogWriteDataToFile.Filter = "CoolerData Files|*.acc";
                saveFileDialogWriteDataToFile.Title = "Select a Data File Name";

                if (saveFileDialogWriteDataToFile.ShowDialog() == DialogResult.OK)
                {
                    savefilename = saveFileDialogWriteDataToFile.FileName;
                    savetofile = true;
                    DEBUGText = "Will save data to " + savefilename;

                    if (System.IO.File.Exists(savefilename))
                    {

                        try
                        {
                            System.IO.File.Delete(savefilename);
                        }
                        catch (System.IO.IOException tmperror)
                        {
                            DEBUGText = tmperror.Message;
                            return;
                        }
                    }

                    this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));
                    // Assign the cursor in the Stream to the Form's Cursor property.
                    // this.Cursor = new Cursor(saveFileDialogWriteDataToFile.OpenFile());
                }
            }
            else
            {
                MessageBox.Show("Must connect first..");
                DEBUGText = "Must connect first..";
                this.Invoke(new EventHandler(DisplayDEBUGWindowINFO));
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {

            this.comboBoxSelectPorts.Items.AddRange(SerialPort.GetPortNames());

        }

        void timer_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = DateTime.Now.ToString();
        }


        private void buttonShowGraph_Click(object sender, EventArgs e)
        {
            Form GraphForm = new GraphForm(tempfile);
            GraphForm.Show();

        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
            //throw new NotImplementedException();
        }

    }
}