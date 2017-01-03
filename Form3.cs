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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            /*System.Object[] ItemObject = new System.Object[5]{"s",2,3,4,5};

            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;//設定只能為選取模式
            //comboBox2.Items.Add

            this.comboBox2.Items.AddRange(ItemObject);
        
             */
            //定義一個DataTable，包含兩個DataColumn
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("weekDisplay", System.Type.GetType("System.String"));
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            dt.Columns.Add(dc);
            dc = new DataColumn("weekVal", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            //定義兩個Array，分別定義DisplayMember和ValueMember的值，把Array寫到DataTable
            string[] strWeekDisplay = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string[] strWeekValue = { "0", "1", "2", "3", "4", "5", "6" };
            for (int i = 0; i < strWeekDisplay.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["weekDisplay"] = strWeekDisplay[i];
                dr["weekVal"] = strWeekValue[i];
                dt.Rows.Add(dr);
            }
            //將DataTable繫結到comboBox上
            comboBox2.DisplayMember = "weekDisplay";
            comboBox2.ValueMember = "weekVal";
            comboBox2.DataSource = dt;

         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
            Console.WriteLine(comboBox2.SelectedValue);
        }
    }
}
