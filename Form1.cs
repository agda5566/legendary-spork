using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = 9600;
                serialPort1.PortName = "COM3";
                serialPort1.Open();
                serialPort1.Write("33");

                label1.Text = "現在櫃內攝氏溫度是" + serialPort1.ReadLine();
                serialPort1.Close();
                /*while (true)
                {
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
                    sw.Reset();//碼表歸零
                    sw.Start();//碼表開始計時
                    sw.Stop();
                    
                    string result1 = sw.Elapsed.TotalMilliseconds.ToString();

                    if (result1 == "10")
                    {
                        serialPort1.BaudRate = 9600;
                        serialPort1.PortName = "COM3";
                        serialPort1.Open();
                        serialPort1.Write("33");

                        label1.Text = "現在櫃內攝氏溫度是" + serialPort1.ReadLine();
                        serialPort1.Close();
                    }
                
                }*/
            }
            catch
            {

                label1.Text = "Arduino未就緒";
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();//產生Form2的物件，才可以使用它所提供的Method
            form2.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.ShowDialog(this);
        }
    }
}
