using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace _0512
{
    public partial class main : Form
    {
        string str = @"Provider=Microsoft.Jet.OLEDB.4.0;User Id=admin;Jet OLEDB:Database Password=cyber123;Data Source=cy.mdb;";
        string sql = "Select * from YesoulChenYu";

        public main()
        {
            InitializeComponent();
        }
        //
        OleDbDataAdapter ada;
        DataTable ta=new DataTable();

        //
        private void main_Load(object sender, EventArgs e)
        {
            sql = "Select * from YesoulChenYu";
            ada = new OleDbDataAdapter(sql,str);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(ada);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            t++;
            if (t >= 0)
            {
                try
                {
                    ta.Clear();
                    ada.Fill(ta);
                    dataGridView1.DataSource = ta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                label4.Visible = false;
                timer1.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label4.Visible = true ;
            sql = "Select * from YesoulChenYu";
            ada = new OleDbDataAdapter(sql, str);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(ada);
            timer1.Enabled = true;
            
            
        }
        int spec = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            spec = 1;
            label4.Visible = true;
            try
            {
                sql = "select * from YesoulChenYu where "+method + "='"+textBox1.Text+"'";
                ada = new OleDbDataAdapter(sql, str);
                
                
                timer1.Enabled = true;
                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spec = 0;
            label4.Visible = true;
            sql = "select * from YesoulChenYu where " + method + " like '" + textBox1.Text + "%'";
            ada = new OleDbDataAdapter(sql, str);
            timer1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string method = "SPinYin";
        string method1 = "拼音";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            method = "ChengYu";
            method1 = "成语";
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确认退出吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            method = "SPinYin";
            method1 = "拼音首字母";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void main_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static int addnum = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            

            if(addnum<1)
            {
                addnum++;
                add add1 = new add();
                add1.Show();
                
            }
            else
            {
                MessageBox.Show("添加成语窗口正在运行！");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            label5.Visible = false;
            DataTable dt = new DataTable();
            DataColumn column;
            DataRow row;



            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "id";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "c";
            dt.Columns.Add(column);

            row = dt.NewRow();
            row["id"] = "ChengYu";
            row["c"] = "成语";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["id"] = "PinYin";
            row["c"] = "拼音";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["id"] = "DianGu";
            row["c"] = "典故";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["id"] = "ChuChu";
            row["c"] = "出处";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["id"] = "LiZi";
            row["c"] = "例子";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["id"] = "SPinYin";
            row["c"] = "首字母拼音";
            dt.Rows.Add(row);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "c";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = 4;
        }
        int i = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            string returnValue = Interaction.InputBox("请输入管理密码（默认为admin）", "提示", "", -1, -1);
            if (returnValue == "admin"&&spec==1)
            {
                sql = "delete from YesoulChenYu where " + method + "='" + textBox1.Text + "'";
                try
                {

                    if (MessageBox.Show("确认删除精确查询 " + method1 + " 为 "+textBox1.Text + " 的成语？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OleDbConnection conn = new OleDbConnection(str);

                        conn.Open();
                        OleDbCommand comm = new OleDbCommand(sql, conn);
                        i = comm.ExecuteNonQuery();
                    }
                    
                    if (i > 0)
                    {
                        MessageBox.Show("删除数据成功!\n"+i+"行受影响", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("删除失败或用户取消!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (spec == 0)
                {
                    MessageBox.Show("非精确查询不能使用删除功能！");
                }
                else
                {
                    MessageBox.Show("删除失败！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            sql = "update YesoulChenYu set "+comboBox1.SelectedValue.ToString() +"='"+ textBox2.Text+"' where " + method + "='" + textBox1.Text + "'";
            //MessageBox.Show(sql);
            label5.Visible = true;
            try
            {
                OleDbConnection conn = new OleDbConnection(str);

                conn.Open();
                OleDbCommand comm = new OleDbCommand(sql, conn);
                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("数据修改成功!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(sender, e);
            panel1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
