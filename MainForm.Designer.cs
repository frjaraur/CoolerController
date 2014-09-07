using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System;
namespace CoolerController
{
   
    partial class MainForm
    {
        
        //public string[] arrayOPCIONESCANAL = { "MANUAL", "AUTO", "100%","0%" };
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.serialPortCoolerController = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxSelectPorts = new System.Windows.Forms.ComboBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonClearText = new System.Windows.Forms.Button();
            this.buttonWriteDataToFile = new System.Windows.Forms.Button();
            this.saveFileDialogWriteDataToFile = new System.Windows.Forms.SaveFileDialog();
            this.textBoxComStatus = new System.Windows.Forms.TextBox();
            this.labelData1 = new System.Windows.Forms.Label();
            this.labelTemperatureValue = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.buttonShowGraph = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 44);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(62, 22);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Conectar";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(78, 43);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(81, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Desconectar";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // textBoxData
            // 
            this.textBoxData.BackColor = System.Drawing.SystemColors.ControlText;
            this.textBoxData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBoxData.Location = new System.Drawing.Point(10, 72);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxData.Size = new System.Drawing.Size(204, 44);
            this.textBoxData.TabIndex = 90;
            this.textBoxData.TabStop = false;
            this.textBoxData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // serialPortCoolerController
            // 
            this.serialPortCoolerController.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // comboBoxSelectPorts
            // 
            this.comboBoxSelectPorts.FormattingEnabled = true;
            this.comboBoxSelectPorts.Location = new System.Drawing.Point(184, 44);
            this.comboBoxSelectPorts.Name = "comboBoxSelectPorts";
            this.comboBoxSelectPorts.Size = new System.Drawing.Size(96, 21);
            this.comboBoxSelectPorts.TabIndex = 2;
            this.comboBoxSelectPorts.Text = "Puerto COM";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInfo.Location = new System.Drawing.Point(9, 122);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(271, 23);
            this.textBoxInfo.TabIndex = 89;
            this.textBoxInfo.TabStop = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(215, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(65, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Actualizar";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonClearText
            // 
            this.buttonClearText.Location = new System.Drawing.Point(220, 72);
            this.buttonClearText.Name = "buttonClearText";
            this.buttonClearText.Size = new System.Drawing.Size(49, 23);
            this.buttonClearText.TabIndex = 4;
            this.buttonClearText.Text = "Limpiar";
            this.buttonClearText.UseMnemonic = false;
            this.buttonClearText.UseVisualStyleBackColor = true;
            this.buttonClearText.Click += new System.EventHandler(this.buttonClearText_Click);
            // 
            // buttonWriteDataToFile
            // 
            this.buttonWriteDataToFile.Location = new System.Drawing.Point(9, 196);
            this.buttonWriteDataToFile.Name = "buttonWriteDataToFile";
            this.buttonWriteDataToFile.Size = new System.Drawing.Size(101, 22);
            this.buttonWriteDataToFile.TabIndex = 40;
            this.buttonWriteDataToFile.Text = "Guardar Datos";
            this.buttonWriteDataToFile.UseVisualStyleBackColor = true;
            this.buttonWriteDataToFile.Click += new System.EventHandler(this.buttonWriteDataToFile_Click);
            // 
            // textBoxComStatus
            // 
            this.textBoxComStatus.BackColor = System.Drawing.Color.Red;
            this.textBoxComStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxComStatus.Location = new System.Drawing.Point(164, 45);
            this.textBoxComStatus.Name = "textBoxComStatus";
            this.textBoxComStatus.ReadOnly = true;
            this.textBoxComStatus.Size = new System.Drawing.Size(14, 20);
            this.textBoxComStatus.TabIndex = 88;
            this.textBoxComStatus.TabStop = false;
            // 
            // labelData1
            // 
            this.labelData1.AutoSize = true;
            this.labelData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData1.Location = new System.Drawing.Point(175, 148);
            this.labelData1.Name = "labelData1";
            this.labelData1.Size = new System.Drawing.Size(82, 13);
            this.labelData1.TabIndex = 87;
            this.labelData1.Text = "Temperatura:";
            // 
            // labelTemperatureValue
            // 
            this.labelTemperatureValue.AutoSize = true;
            this.labelTemperatureValue.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperatureValue.Location = new System.Drawing.Point(144, 191);
            this.labelTemperatureValue.Name = "labelTemperatureValue";
            this.labelTemperatureValue.Size = new System.Drawing.Size(128, 56);
            this.labelTemperatureValue.TabIndex = 80;
            this.labelTemperatureValue.Text = "----";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(13, 148);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(100, 16);
            this.labelTimer.TabIndex = 73;
            this.labelTimer.Text = "--/--/---- --:--:--";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTime.ForeColor = System.Drawing.Color.Red;
            this.labelCurrentTime.Location = new System.Drawing.Point(9, 9);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(161, 19);
            this.labelCurrentTime.TabIndex = 72;
            this.labelCurrentTime.Text = "01/10/2013 19:35:32";
            // 
            // buttonShowGraph
            // 
            this.buttonShowGraph.BackColor = System.Drawing.Color.Green;
            this.buttonShowGraph.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonShowGraph.Location = new System.Drawing.Point(12, 224);
            this.buttonShowGraph.Name = "buttonShowGraph";
            this.buttonShowGraph.Size = new System.Drawing.Size(61, 23);
            this.buttonShowGraph.TabIndex = 6;
            this.buttonShowGraph.Text = "Gráficas";
            this.buttonShowGraph.UseVisualStyleBackColor = false;
            this.buttonShowGraph.Click += new System.EventHandler(this.buttonShowGraph_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(12, 253);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 55;
            this.buttonExit.Text = "SALIR";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click_1);
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonShowGraph);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelTemperatureValue);
            this.Controls.Add(this.labelData1);
            this.Controls.Add(this.textBoxComStatus);
            this.Controls.Add(this.buttonWriteDataToFile);
            this.Controls.Add(this.buttonClearText);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.comboBoxSelectPorts);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(549, 406);
            this.Name = "MainForm";
            this.Text = "Heatdrew Controller 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }






        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBoxData;
        private System.IO.Ports.SerialPort serialPortCoolerController;
        private System.Windows.Forms.ComboBox comboBoxSelectPorts;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Button buttonReset;
        private Button buttonClearText;
        private Button buttonWriteDataToFile;
        private SaveFileDialog saveFileDialogWriteDataToFile;
        private TextBox textBoxComStatus;
        private Label labelData1;
        private Label labelTemperatureValue;
        private Label labelTimer;
        private Label labelCurrentTime;
        private Button buttonShowGraph;
        private Button buttonExit;
    }
}

