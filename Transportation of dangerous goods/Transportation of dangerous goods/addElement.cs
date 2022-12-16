using Microsoft.Data.Sqlite;
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
    public partial class addElement : Form
    {
        
        SqliteConnection connection;
        String[] orders = new string[] { "ID", "От", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };


    public addElement()
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
            textBox1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = String.Format("insert into orders " +
                "values ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, '{7}');", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
            
            SqliteCommand command = new SqliteCommand(str, connection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = this;
            form.Close();
        }
    }
}
