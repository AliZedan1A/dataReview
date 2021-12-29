using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginWithPHP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlC = "datasource=127.0.0.1;username=root;password=;database=271;SslMode=none";
            string sql = "SELECT * FROM `accounts` where username=@user";

            
            MySqlConnection con = new MySqlConnection(sqlC);
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.AddWithValue("@user", nameID.Text);
            try
            {
                con.Open();
               
                    using (MySqlDataReader dr = command.ExecuteReader())
                    {


                        if (dr.Read())
                        {
                            panel1.Visible = true;

                            ID.Text = dr["id"].ToString();
                            passL.Text = dr["password"].ToString();
                            Email.Text = dr["email"].ToString();
                        lastL.Text = dr["lastlogin"].ToString();
                        }
                        else if (dr.Read() == false)
                        {
                            MessageBox.Show("اسم الحساب غير موجود في قاعدة البيانات");
                        } 
                    }
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlC = "datasource=127.0.0.1;username=root;password=;database=271;SslMode=none";
            string sql = "UPDATE `accounts` SET `password`=@pass,`email`=@email WHERE id = @id";


            MySqlConnection con = new MySqlConnection(sqlC);
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.AddWithValue("pass", passtext.Text);
            command.Parameters.AddWithValue("email", emailtext.Text);
            command.Parameters.AddWithValue("id", ID.Text);

            try
            {
                con.Open();
              if(command.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("تم تحديث البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel1.Visible = false;

                }
                con.Close();
              
            }catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Main_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("عليك ادخال اسم الحساب المراد البحث عليه بعدها الضغط على زر الدخول", "تعليمات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("عليك ادخال اسم الحساب المراد البحث عليه بعدها الضغط على زر الدخول", "تعليمات", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
