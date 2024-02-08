using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ArduinoLedYakma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }
        private void InitializeSerialPort()
        {
            serialPort1.BaudRate = 9600;
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
                comboxPort.Items.Add(port);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
            label1.Text = "LED AÇIK";
           
            //  ledin  yakma butonu
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("0");
            label1.Text = "LED KAPALI";
           
            // ledi söndürme butonu


        }

        private void comboxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboxPort.SelectedItem.ToString();
                serialPort1.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Unauthorized access to {serialPort1.PortName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening {serialPort1.PortName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // comboxta seçili olan port ile bağlantı sağladığım  kısım
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // form  kapandığında seri portun kapanmasını sağladım
        }
    }
}
