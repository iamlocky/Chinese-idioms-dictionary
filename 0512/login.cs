using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace _0512
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
        int fail = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string idstr = id.Text;
                string pwstr = pw.Text;
                string constr = "data source=(local);database=cy;user id=" + idstr + ";password=" + pwstr;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("登陆成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    main m = new main();
                    m.Show();
                    this.Hide();
                    con.Close();
                }

            }
            catch (Exception ex)
            { 
                fail++;
                if (fail < 3)
                {
                    MessageBox.Show("失败"+fail+"次!\n"+ex.Message,"",MessageBoxButtons.OK);
                }
                else 
                {
                    string errstr = id.Text + " " + pw.Text;
                    StreamWriter sw = File.AppendText(@"err.txt");
                    sw.WriteLine("失败用户:"+errstr+"\n");
                    sw.Flush();
                    sw.Close();
                    this.Close();
                }
            }
        }
    }
}
