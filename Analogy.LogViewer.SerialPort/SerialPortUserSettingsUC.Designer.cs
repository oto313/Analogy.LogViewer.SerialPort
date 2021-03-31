
namespace Analogy.LogViewer.SerialPort
{
    partial class SerialPortUserSettingsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbSerialPort = new System.Windows.Forms.TextBox();
            this.txtbSerialPortBaudrate = new System.Windows.Forms.TextBox();
            this.txbRegex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // txtbSerialPort
            // 
            this.txtbSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSerialPort.Location = new System.Drawing.Point(326, 6);
            this.txtbSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtbSerialPort.Name = "txtbSerialPort";
            this.txtbSerialPort.Size = new System.Drawing.Size(389, 20);
            this.txtbSerialPort.TabIndex = 2;
            this.txtbSerialPort.TextChanged += new System.EventHandler(this.txtbRealTimeServerURL_TextChanged);
            // 
            // txtbSerialPortBaudrate
            // 
            this.txtbSerialPortBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSerialPortBaudrate.Location = new System.Drawing.Point(326, 28);
            this.txtbSerialPortBaudrate.Margin = new System.Windows.Forms.Padding(2);
            this.txtbSerialPortBaudrate.Name = "txtbSerialPortBaudrate";
            this.txtbSerialPortBaudrate.Size = new System.Drawing.Size(389, 20);
            this.txtbSerialPortBaudrate.TabIndex = 3;
            this.txtbSerialPortBaudrate.TextChanged += new System.EventHandler(this.txtbSelfHostingServerURL_TextChanged);
            // 
            // txbRegex
            // 
            this.txbRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRegex.Location = new System.Drawing.Point(326, 49);
            this.txbRegex.Margin = new System.Windows.Forms.Padding(2);
            this.txbRegex.Name = "txbRegex";
            this.txbRegex.Size = new System.Drawing.Size(389, 20);
            this.txbRegex.TabIndex = 4;
            this.txbRegex.TextChanged += new System.EventHandler(this.txtbRegex);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Regex:";
            // 
            // SerialPortUserSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbRegex);
            this.Controls.Add(this.txtbSerialPortBaudrate);
            this.Controls.Add(this.txtbSerialPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SerialPortUserSettingsUC";
            this.Size = new System.Drawing.Size(727, 243);
            this.Load += new System.EventHandler(this.SerialPortUserSettingsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbSerialPort;
        private System.Windows.Forms.TextBox txtbSerialPortBaudrate;
        private System.Windows.Forms.TextBox txbRegex;
        private System.Windows.Forms.Label label3;
    }
}
