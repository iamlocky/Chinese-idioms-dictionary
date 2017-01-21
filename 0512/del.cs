using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace _0512
{
    public partial class del : Form
    {
        public del()
        {
            InitializeComponent();
        }

        private void del_Load(object sender, EventArgs e)
        {
            string returnValue = Interaction.InputBox("请输入管理密码", "提示", "", -1, -1);
            if (returnValue == "admin")
            { }
            else 
            {
                MessageBox.Show("错误！","", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
