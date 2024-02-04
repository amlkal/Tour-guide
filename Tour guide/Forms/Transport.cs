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
    public partial class Transport : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");
        public Transport()

        {
            InitializeComponent();
            button3.Enabled = false;
            SqlDataAdapter ad = new SqlDataAdapter("select * from means_transmission", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
           
        }

        private void Transport_Load(object sender, EventArgs e)
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
            //label1.ForeColor = ThemeColor.SecondaryColor;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into means_transmission values (@id,@tr_type,@nam_pass,@price)";
            SqlCommand cmd = new SqlCommand(sql,con);

            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@tr_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@nam_pass", textBox3.Text);
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الأضافة بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from means_transmission", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from means_transmission where code='"+dataGridView1.CurrentRow.Cells[0].Value+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحذف  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from means_transmission", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update means_transmission set  transportation_type='" + comboBox1.Text + "',num_passengers='" + textBox3.Text + "',price_person='" + textBox4.Text + "' where code='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم تحديث  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from means_transmission", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button3.Enabled = false;
            button1.Enabled = true;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            textBox1.Text =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
