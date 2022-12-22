using Microsoft.Data.Sqlite;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Transportation_of_dangerous_goods
{
    public partial class Form1 : Form
    {

        //variables
        bool addW = false,
            delW = false,
            chaW = false;
        int selW = 0;
        SqliteConnection connection;
        protected static string role = "admin";

        public void setAddFalse()
        {
            addW = false;
        }

        public void setDelFalse()
        {
            delW = false;
        }

        public void setChaFalse()
        {
            chaW = false;
        }

        public void closeSelectWin()
        {
            selW -= 1;
        }

        public void updTables()
        {
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


        //крнструктор
        public Form1()
        {
            InitializeComponent();
            tabPage1.Text = "Компании";
            tabPage2.Text = "Тарифы";
            tabPage3.Text = "Клсааы опасных грузов";
            tabPage4.Text = "Экипажи";
            openFileDialog1.Filter = "Data base files(*.db)|*.db";
            saveFileDialog1.Filter = "Data base files(*.db)|*.db";
            saveFileDialog1.Title = "Выбор файла для сохранения";
            saveFileDialog1.InitialDirectory = "../../..";
            saveFileDialog1.DefaultExt = ".db";
            openFileDialog1.InitialDirectory = "../../..";
            openFileDialog1.Title = "Выбор файла для открытия";
            connection = new SqliteConnection("Data Source=C:\\TWO\\BD\\RGR\\Transportation of dangerous goods\\Transportation of dangerous goods\\Trans_dangerous_goods_DB.db");
            connection.Open();
            this.Text = "Transportation of dangerous goods C:\\TWO\\BD\\RGR\\Transportation of dangerous goods\\Transportation of dangerous goods\\Trans_dangerous_goods_DB.db";
            label4.Text = "Подключение установлено";
            updTables();
        }


        //открытие файла БД
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            connection.Close();
            connection = new SqliteConnection("Data Source=" + openFileDialog1.FileName);
            connection.Open();
            this.Text = "Transportation of dangerous goods " + openFileDialog1.FileName;
            label4.Text = "Подключение установлено";
            выборкаИзТаблицToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            updTables();
        }


        //закрытие БД
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.Close();
            выборкаИзТаблицToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            this.Text = "Transportation of dangerous goods";
            label4.Text = "Отключено";
        }


        //окно для добавления данных
        private void добавитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addW) return;
            if (role == "user")
            {
                MessageBox.Show(
                    "У Вас недостаточно полномочий для этого действия",
                    "Невозможно выполнить действие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new addElement(this, connection).Show();
            addW = true;
        }


        //обновление таблиц
        private void обновитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection == null) return;

            updTables();
        }


        //окно для удаления данных
        private void удалитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (delW) return;

            if (role == "user")
            {
                MessageBox.Show(
                    "У Вас недостаточно полномочий для этого действия",
                    "Невозможно выполнить действие",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new deleteElement(this, connection).Show();
            delW = true;
        }


        //смена роли на администратора
        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("admin").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "Тперь Вы в роли администратора!",
                    "Смена роли",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "admin";
            }
        }


        //смена роли на диспетчера
        private void диспетчерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("dispatcher").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "Тперь Вы в роли диспетчера!",
                    "Смена роли",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "dispatcher";
            }
        }


        //смена роли на отдел кадров
        private void отделКадровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("hr").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "Тперь Вы в роли отдела кадров!",
                    "Смена роли",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "hr";
            }
        }


        //смена роли на пользователя
        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Теперь Вы в роли пользователя!",
                "Смена роли",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            role = "user";
        }


        //сохранение файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connection.State.ToString().Equals("Open"))
            {
                MessageBox.Show(
                "Нельзя сохранить данные, так как отсутствует подключение",
                "Сохранение невозможно",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            File.Delete(saveFileDialog1.FileName);
            File.Copy(connection.DataSource, saveFileDialog1.FileName);
        }


        //справочная информация
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\tTransfer of Dang Googs (v1.1)\n\n" +
                "Автор: Хорольский Андрей Дмитриевич\n" +
                "e-mail: horolskyandrey@gmail.com\n" +
                "2022",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        //открытие окна для изменения данных
        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chaW) return;
            new changeElement(this, connection).Show();
            chaW = true;
        }


        //открытие окна для выборки
        private void выборкаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selW < 2)
            {
                new selectElement(this, connection).Show();
                selW += 1;
            }
        }
    }
}