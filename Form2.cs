using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public static bool IsNumeric(string TextBoxValue)
        //判斷是否為數字函式
        {
            try
            {

                int i = Convert.ToInt32(TextBoxValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            //Environment.Exit(Environment.ExitCode);
            try 
            {
                if (textBox1.Text != "")//判斷不為空
                {
                    if (IsNumeric(textBox1.Text))
                    {


                        int a = Convert.ToInt32(textBox1.Text);
                        string connetionString = null;
                        SqlConnection cnn;
                        connetionString = "Data Source=10.21.10.113;Initial Catalog=test1;User ID=sa;Password=root5566";
                        cnn = new SqlConnection(connetionString);
                        try
                        {
                            SqlCommand command = new SqlCommand();
                            command.Connection = cnn;            // <== lacking
                            command.CommandType = CommandType.Text;
                            command.CommandText = "SELECT * FROM Testarduinomemeber WHERE id=@id";
                            command.Parameters.AddWithValue("@id", a);

                            cnn.Open();
                            Int32 rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine("RowsAffected: {0}", rowsAffected);
                            SqlDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    /*Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                                        reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                                    */
                                    label4.Text = Convert.ToString(reader.GetInt32(0));
                                    label5.Text = reader.GetString(1);
                                    label6.Text = reader.GetString(2);

                                }
                            }
                            else
                            {
                                label4.Text=("該查詢碼並沒有找到對應的資料");
                            }
                            reader.Close();
                            cnn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex + "Can not open connection ! ");
                        }
                    }
                    else
                    {
                        label4.Text = "請輸入數字";
                    }
                }
                else
                {
                    label4.Text = "請輸入查詢碼";
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
