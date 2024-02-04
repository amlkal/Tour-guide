using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Tour_guide.Forms
{
    public partial class Trips : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");
        public Trips()
        {
            InitializeComponent();
            SqlDataAdapter ad = new SqlDataAdapter("select * from sheduler", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Trips_Load(object sender, EventArgs e)
        {
            SqlDataAdapter ad0 = new SqlDataAdapter("select * from leader1", con);
            DataTable d0 = new DataTable();
            ad0.Fill(d0);

            comboBox1.DataSource = d0;
            comboBox1.DisplayMember = "name_guide";
            comboBox1.ValueMember = "code";


            SqlDataAdapter ad1 = new SqlDataAdapter("select * from tourist_data", con);
            DataTable d1 = new DataTable();
            ad1.Fill(d1);

            comboBox2.DataSource = d1;
            comboBox2.DisplayMember = "tourist_name";
            comboBox2.ValueMember = "code";







            LoadTheme();
        }


        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "insert into sheduler values (@code,@code_name,@tourist_name,@booking_data,@amount_)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@code", textBox1.Text);
            cmd.Parameters.AddWithValue("@code_name", comboBox1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@tourist_name", comboBox2.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@booking_data", dateTimePicker1.Value.ToString("yyyy/MM/dd 00:00:00"));
            cmd.Parameters.AddWithValue("@amount_", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الأضافة بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from sheduler", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update sheduler set  booking_data='" + dateTimePicker1.Value.ToString("yyyy/MM/dd 00:00:00") + "',amount_='" + textBox3.Text + "' where code='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم تحديث  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from sheduler", con);
            DataTable d = new DataTable(); 
            ad.Fill(d);
            dataGridView1.DataSource = d;
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox3.Text = "";
            button3.Enabled = true;
            button1.Enabled = true;

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from sheduler where code='" + dataGridView1.CurrentRow.Cells[0].Value + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحذف  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from sheduler", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter ad3 = new SqlDataAdapter("select * from sheduler where booking_data like '%"+ textBox2.Text+ "%'", con);
            DataTable d3 = new DataTable();
            ad3.Fill(d3);
            dataGridView1.DataSource = d3;

        }
    }
}
