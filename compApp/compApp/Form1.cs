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

namespace compApp
{
    public partial class Form1 : Form
    {
        SerialPort port;
        String[] myPorts;
        bool isConnected = false;
        String infoSent = "";
        String val1;
        String val2;
        String val3;
        public Form1()
        {
            
                InitializeComponent();
                getPorts();
                disableAll();
                

                foreach (String port in myPorts)
                {
                    comboBox1.Items.Add(port);
                }
                if (myPorts[0] != null)
                {
                    comboBox1.SelectedItem = myPorts[0];
                }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        public void getPorts()
        {
            myPorts = SerialPort.GetPortNames();
        }

        public void connectToArduino()
        {
            isConnected = true;
            String selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            button5.Text = "DISCONNECT";
            enableAll();
        }

        public void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            button5.Text = "CONNECT";
            disableAll();
        }

        public void disableAll()
        {
            trackBar1.Enabled = false;
            trackBar2.Enabled = false;
            trackBar3.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
        }

        public void enableAll()
        {
            trackBar2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String val = trackBar1.Value.ToString();
            
            if (int.Parse(val) == 10)
            {
                val = "9";
            }
            String val2 = trackBar2.Value.ToString();
            
            if (int.Parse(val2) == 10)
            {
                val2 = "9";
            }
            
            String val3 = trackBar3.Value.ToString();
            
            if (int.Parse(val3) == 10)
            {
                val3 = "9";
            }
            
            bool val4 = checkBox1.Checked;
            bool val5 = checkBox2.Checked;
            bool val6 = checkBox3.Checked;
            String str4 = "";
            String str5 = "";
            String str6 = "";
            if (val4 == true)
            {
                str4 = "T";
            }
            else
            {
                str4 = "F";
            }
            if (val5 == true)
            {
                str5 = "T";
            }
            else
            {
                str5 = "F";
            }
            if (val6 == true)
            {
                str6 = "T";
            }
            else
            {
                str6 = "F";
            }
            Console.WriteLine(val + val3 + val2 + str4 + str5 + str6);
            port.Write(val+val3+val2+str4+str5+str6);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                trackBar1.Enabled = true;
                trackBar3.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                trackBar3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customize your experience, and click on 'save changes' to apply!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.Show();
        }
    }
}
