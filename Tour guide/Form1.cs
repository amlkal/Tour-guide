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

namespace Tour_guide
{
    public partial class Form1 : Form
    {
        
        //SqlCommand com = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand();
            try
            {
                conn.Open();
             
                com.Connection = conn;
            com.CommandText = "select * from users";
            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                if (textBox1.Text.Equals(dr["Username"].ToString())&& textBox2.Text.Equals(dr["Password"].ToString()))
                {
                    MessageBox.Show("تم تسجيل الدخول بنجاح ");
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();
                        
                }
                else
                {
                    MessageBox.Show("خطأ في كلمة المرور ");
                }

                   
            }





            }
            catch(Exception ex)
            {
                MessageBox.Show("ex.messsge");
            }











            /*SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server = DESKTOP - 2OFMH7G\\SQLEXPRESS;database=a_tour_guide;integrated security=true";
            
           // SqlCommand com = new SqlCommand();

            conn.Open();
            MessageBox.Show(conn.State.ToString());
            /*com.Connection = con;
            com.CommandText = "select * from users";
            SqlDataReader dr = com.ExecuteReader();

            if (dr.Read())
            {
                if (textBox1.Text.Equals(dr["Username"].ToString())&& textBox2.Text.Equals(dr["Password"].ToString()))
                {
                    MessageBox.Show("تم تسجيل الدخول بنجاح ");
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                else
                {
                    MessageBox.Show("خطأ في كلمة المرور ");
                }

                   
            }



            conn.Close();
            MessageBox.Show(conn.State.ToString()); */
            }
    }
}
