using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;

namespace loginWithPHP
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlC = "datasource=127.0.0.1;username=root;password=;database=allowusers;SslMode=none";
            string sql = "SELECT * FROM `users` where username=@username AND  password=@password";

            MySqlConnection con = new MySqlConnection(sqlC);
            MySqlCommand command = new MySqlCommand(sql,con);
            command.Parameters.AddWithValue("@username",usernamea.Text);
            command.Parameters.AddWithValue("@password", pass.Text);
            try
            {
                con.Open();

                MySqlDataReader dr = command.ExecuteReader();

                if(dr.Read()==true)
                {
                    this.Hide();
                    Main frm = new Main();
                    frm.ShowDialog();
                }
                else if(dr.Read()==false)
                {
                    MessageBox.Show("false");
                }
                else
                {
                    MessageBox.Show("no con");
                }
                con.Close();

                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usernamea_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernamea_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
