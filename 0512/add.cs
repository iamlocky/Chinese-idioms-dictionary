using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _0512
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        string str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=cy.mdb";
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into YesoulChenYu (ChengYu,PingYin,DianGu,ChuChu,LiZi,SPingYin) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            OleDbConnection conn = new OleDbConnection(str);

            try
            {
                conn.Open();
                OleDbCommand comm = new OleDbCommand(sql, conn);
                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("添加数据成功!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("添加失败!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_Load(object sender, EventArgs e)
        {
            
        }

        private void add_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            main.addnum = 0;
        }
    }
}
