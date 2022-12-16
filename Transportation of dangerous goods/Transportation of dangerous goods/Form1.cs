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
            if (connection == null) return;

            SqliteCommand command = new SqliteCommand("update classes_of_goods set desc='окисл€ющие вещества'");
            command.Connection = connection;
            //command.ExecuteNonQuery();

            Form addF = new addElement();
            addF.Show();

        }

        //открытие файла Ѕƒ
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

            SqliteCommand comShow2 = new SqliteCommand("select * from trip", connection);
            SqliteDataReader reader2 = comShow2.ExecuteReader();
            dataGridView2.Rows.Clear();

            while (reader2.Read())
            {
                dataGridView2.Rows.Add(reader2.GetValue(0), reader2.GetValue(1), reader2.GetValue(2), reader2.GetValue(3), reader2.GetValue(4));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void выборка»з“аблицToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьƒанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addF = new addElement();
            addF.Show();
        }
    }
}