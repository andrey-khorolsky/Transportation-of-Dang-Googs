using Microsoft.Data.Sqlite;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Transportation_of_dangerous_goods
{
    public partial class Form1 : Form
    {

        SqliteConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
        }


        //добавление данных
        private void button1_Click(object sender, EventArgs e)
        {
            //if (connection == null) return;
            //connection = new SqliteConnection("Data Source=../../../TestDB.db");

            //connection.Open();

            //orders exists

            //command = new SqliteCommand("create table orders (" +
            //    "id integer not null," +
            //    "from_company varchar(50) not null," +
            //    "to_company varchar(50) not null," +
            //    "goods varchar(30) not null," +
            //    "g_class integer not null," +
            //    "g_volume integer not null," +
            //    "g_weight integer not null," +
            //    "tarif varchar(30) )");
            //command.Connection = connection;
            //command.ExecuteNonQuery();

            //command.ExecuteNonQuery();
            //String newId = textBox1.Text, newName = textBox2.Text;
            //if (newId.Equals("") || newName.Equals(""))
            //{

            //    status.Text = "error";
            //    return;
            //}

            Form addF = new addElement();
            addF.Show();

        }

        //открытие файла БД
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void status_Click(object sender, EventArgs e)
        {

        }

        //вывод данных
        private void button2_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            SqliteCommand comShow = new SqliteCommand("select * from orders", connection);
            SqliteDataReader reader = comShow.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}