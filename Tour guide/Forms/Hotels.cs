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
    public partial class Hotels : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");
        public Hotels()
        {

            InitializeComponent();
            SqlDataAdapter ad = new SqlDataAdapter("select * from hotel", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            button2.Enabled = false;
            LoadTheme();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Hotels_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into hotel values (@code,@name,@acco,@day,@price)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@code", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@acco", comboBox1.Text);
            cmd.Parameters.AddWithValue("@day", textBox5.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الأضافة بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from hotel", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update hotel set  hotel_name='" + textBox2.Text + "',accommoda_type='" + comboBox1.Text + "',days='" + textBox5.Text + "',price_night='" + textBox4.Text + "' where code='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم تحديث  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from hotel", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            textBox1.Text= "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from hotel where code='" + dataGridView1.CurrentRow.Cells[0].Value + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحذف  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from hotel", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }
    }
}
