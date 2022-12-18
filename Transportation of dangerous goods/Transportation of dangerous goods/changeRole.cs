using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportation_of_dangerous_goods
{
    public partial class changeRole : Form
    {
        //будующая роль
        string expectedRole;


        //конструктор, выводит ожидаемую роль
        public changeRole(string str)
        {
            InitializeComponent();
            expectedRole = str;
            switch (expectedRole)
            {
                case "admin":
                    label2.Text = "Администратор";
                    break;
                case "dispatcher":
                    label2.Text = "Диспетчер";
                    break;
                case "hr":
                    label2.Text = "Отдел кадров";
                    break;
            }
        }


        //подтверждение ввода, если верно - смена роли
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (expectedRole.Equals("admin"))
            {
                if (textBox1.Text.Equals("000a"))
                DialogResult = DialogResult.OK;
            }

            if (expectedRole.Equals("dispatcher"))
            {
                if (textBox1.Text.Equals("000d"))
                    DialogResult = DialogResult.OK;
            }

            if (expectedRole.Equals("hr"))
            {
                if (textBox1.Text.Equals("000h"))
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
