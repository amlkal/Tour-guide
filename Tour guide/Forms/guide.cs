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
    public partial class guide : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2OFMH7G\SQLEXPRESS;Initial Catalog=a_tour_guide;Integrated Security=True");
        
        public guide()
        {
            InitializeComponent();
            SqlDataAdapter ad = new SqlDataAdapter("select * from leader1", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            button3.Enabled = false;
            LoadTheme();


        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guide_Load(object sender, EventArgs e)
        {
            
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
            string sql = "insert into leader1 values (@code,@name_guide,@address,@phone)";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@code", textBox1.Text);
            cmd.Parameters.AddWithValue("@name_guide", textBox2.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الأضافة بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from leader1", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from leader1 where code='" + dataGridView1.CurrentRow.Cells[0].Value + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم الحذف  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from leader1", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update leader1 set  name_guide='" + textBox2.Text + "',address='" + textBox3.Text + "',phone='" + textBox4.Text + "' where code='" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم تحديث  بنجاح ");
            SqlDataAdapter ad = new SqlDataAdapter("select * from leader1", con);
            DataTable d = new DataTable();
            ad.Fill(d);
            dataGridView1.DataSource = d;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
