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
        }


        //добавление данных
        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == null) return;
            //connection = new SqliteConnection("Data Source=../../../TestDB.db");

            //connection.Open();

            /*SqliteCommand command = new SqliteCommand("create table first(" +
                "id integer not null primary key," +
                "name varchar(20) not null);");*/
            //command.Connection = connection;

            //command.ExecuteNonQuery();
            String newId = textBox1.Text, newName = textBox2.Text;
            if (newId.Equals("") || newName.Equals(""))
            {
                status.Text = "error";
                return;
            }
            SqliteCommand comAdd = new SqliteCommand("insert into first (id, name)" +
                "values (" + newId + ", '" + newName + "');");
            comAdd.Connection = connection;
            comAdd.ExecuteNonQuery();

            textBox1.Text = "";
            textBox2.Text = "";
            status.Text = "added";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //открытие файла БД
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection = new SqliteConnection("Data Source=../../../TestDB.db");
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
            SqliteCommand comShow = new SqliteCommand("select * from first", connection);
            SqliteDataReader reader = comShow.ExecuteReader();
            //int i = 0;
            label1.Text = "";
            while (reader.Read())
            {
                var id = reader.GetValue(0);
                var name = reader.GetValue(1);
                Console.WriteLine($"{id} \t {name}");
                label1.Text += "id " + id.ToString() + " name " + name.ToString() + "\n";
            }
        }
    }
}