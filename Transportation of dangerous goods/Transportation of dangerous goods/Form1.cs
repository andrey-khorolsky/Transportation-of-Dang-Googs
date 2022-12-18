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
            tabPage1.Text = "Компании";
            tabPage2.Text = "Тарифы";
            tabPage3.Text = "Клсааы опасных грузов";
            tabPage4.Text = "Экипажи";
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
        }


        //добавление данных
        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == null) return;

            SqliteCommand command = new SqliteCommand("update classes_of_goods set desc='окисляющие вещества'");
            command.Connection = connection;
            //command.ExecuteNonQuery();

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

        private void выборкаИзТаблицToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new addElement().Show();
        }

        private void обновитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            SqliteCommand comShow;
            SqliteDataReader reader;

            //orders
            comShow = new SqliteCommand("select * from orders", connection);
            reader = comShow.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7));
            }

            //trip
            comShow = new SqliteCommand("select * from trip", connection);
            reader = comShow.ExecuteReader();
            dataGridView2.Rows.Clear();

            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
            }

            //transport
            comShow = new SqliteCommand("select * from transport", connection);
            reader = comShow.ExecuteReader();
            dataGridView3.Rows.Clear();

            while (reader.Read())
            {
                dataGridView3.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
            }

            //company
            comShow = new SqliteCommand("select * from company", connection);
            reader = comShow.ExecuteReader();
            dataGridView4.Rows.Clear();

            while (reader.Read())
            {
                dataGridView4.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
            }

            //tarif
            comShow = new SqliteCommand("select * from tarif", connection);
            reader = comShow.ExecuteReader();
            dataGridView5.Rows.Clear();

            while (reader.Read())
            {
                dataGridView5.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
            }

            //classes of goods
            comShow = new SqliteCommand("select * from classes_of_goods", connection);
            reader = comShow.ExecuteReader();
            dataGridView6.Rows.Clear();

            while (reader.Read())
            {
                dataGridView6.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }

            //crew
            comShow = new SqliteCommand("select * from crew", connection);
            reader = comShow.ExecuteReader();
            dataGridView7.Rows.Clear();

            while (reader.Read())
            {
                dataGridView7.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void удалитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new deleteElement().Show();
        }
    }
}