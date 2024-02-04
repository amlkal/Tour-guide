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
namespace Tour_guide.Forms
{
    public partial class Tourist : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");
      
        public Tourist()
        {
            InitializeComponent();
            SqlDataAdapter ad = new SqlDataAdapter("select * from tourist_data", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            button2.Enabled = false;
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
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into tourist_data values (@id,@t_n,@country,@sex,@pas)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            cmd.Parameters.AddWithValue("@t_n", textBox1.Text);
            cmd.Parameters.AddWithValue("@country", textBox2.Text);
            cmd.Parameters.AddWithValue("@sex", comboBox1.Text);
            cmd.Parameters.AddWithValue("@pas", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الأضافة بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from tourist_data", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }
        private void Tourist_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("delete from tourist_data where code='" + dataGridView1.CurrentRow.Cells[0].Value + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحذف  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from tourist_data", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update tourist_data set  tourist_name='" + textBox1.Text + "',country='" + textBox2.Text + "',sex='" + comboBox1.Text + "',pass_num='"+ textBox4.Text + "' where code='" + textBox5.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم تحديث  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from tourist_data", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            button2.Enabled = false;
            btnInsert.Enabled = true;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            btnInsert.Enabled = true;
            button2.Enabled = true;
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
