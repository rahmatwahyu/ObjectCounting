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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string data,semua;
        string[] values = new string [30];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = textBox1.Text;
            serialPort1.BaudRate = Convert.ToInt16(textBox2.Text);
            if (serialPort1.IsOpen == false)
            {
                serialPort1.Open();
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            /*if (data != null)
            {
                richTextBox1.Text = data;
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            values = data.Split(',');
            if (data != null)
            {
                try
                {
                    this.Invoke(new EventHandler(parsing));
                }
                catch
                {
                    Console.Write("error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Application.Exit();
            this.Close();
        }
        private void parsing(object sender, EventArgs e)
        {
            try
            {
                if (data != null && values[0] != null)
                {
                    label6.Text = values[0];
                    if (values[1] == "1")
                    {
                        textBox3.Text = values[2];
                    }
                    else if (values[1] == "2")
                    {
                        textBox4.Text = values[2];
                    }
                    else if (values[1] == "3")
                    {
                        textBox5.Text = values[2];
                    }
                    semua = semua + values[3];
                    richTextBox1.Text = semua;
                }
            }
            catch { Console.Write("tidak ada data"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            semua = "";
            richTextBox1.Text = "";
        }
    }
}
