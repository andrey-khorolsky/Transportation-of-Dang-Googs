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


        //�����������
        public Form1()
        {
            InitializeComponent();
            tabPage1.Text = "��������";
            tabPage2.Text = "������";
            tabPage3.Text = "������ ������� ������";
            tabPage4.Text = "�������";
            openFileDialog1.Filter = "Data base files(*.db)|*.db";
            saveFileDialog1.Filter = "Data base files(*.db)|*.db";
            saveFileDialog1.Title = "����� ����� ��� ����������";
            saveFileDialog1.InitialDirectory = "../../..";
            saveFileDialog1.DefaultExt = ".db";
            openFileDialog1.InitialDirectory = "../../..";
            openFileDialog1.Title = "����� ����� ��� ��������";
            connection = new SqliteConnection("Data Source=C:\\TWO\\BD\\RGR\\Transportation of dangerous goods\\Transportation of dangerous goods\\Trans_dangerous_goods_DB.db");
            connection.Open();
            this.Text = "Transportation of dangerous goods C:\\TWO\\BD\\RGR\\Transportation of dangerous goods\\Transportation of dangerous goods\\Trans_dangerous_goods_DB.db";
            label4.Text = "����������� �����������";
            updTables();
        }


        //�������� ����� ��
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            connection.Close();
            connection = new SqliteConnection("Data Source=" + openFileDialog1.FileName);
            connection.Open();
            this.Text = "Transportation of dangerous goods " + openFileDialog1.FileName;
            label4.Text = "����������� �����������";
            ���������������ToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            updTables();
        }


        //�������� ��
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.Close();
            ���������������ToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            this.Text = "Transportation of dangerous goods";
            label4.Text = "���������";
        }


        //���� ��� ���������� ������
        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addW) return;
            if (role == "user")
            {
                MessageBox.Show(
                    "� ��� ������������ ���������� ��� ����� ��������",
                    "���������� ��������� ��������",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new addElement(this, connection).Show();
            addW = true;
        }


        //���������� ������
        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection == null) return;

            updTables();
        }


        //���� ��� �������� ������
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (delW) return;

            if (role == "user")
            {
                MessageBox.Show(
                    "� ��� ������������ ���������� ��� ����� ��������",
                    "���������� ��������� ��������",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new deleteElement(this, connection).Show();
            delW = true;
        }


        //����� ���� �� ��������������
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("admin").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "����� �� � ���� ��������������!",
                    "����� ����",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "admin";
            }
        }


        //����� ���� �� ����������
        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("dispatcher").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "����� �� � ���� ����������!",
                    "����� ����",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "dispatcher";
            }
        }


        //����� ���� �� ����� ������
        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new changeRole("hr").ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show(
                    "����� �� � ���� ������ ������!",
                    "����� ����",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                role = "hr";
            }
        }


        //����� ���� �� ������������
        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "������ �� � ���� ������������!",
                "����� ����",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            role = "user";
        }


        //���������� �����
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connection.State.ToString().Equals("Open"))
            {
                MessageBox.Show(
                "������ ��������� ������, ��� ��� ����������� �����������",
                "���������� ����������",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            File.Delete(saveFileDialog1.FileName);
            File.Copy(connection.DataSource, saveFileDialog1.FileName);
        }


        //���������� ����������
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "\tTransfer of Dang Googs (v1.1)\n\n" +
                "�����: ���������� ������ ����������\n" +
                "e-mail: horolskyandrey@gmail.com\n" +
                "2022",
                "� ���������",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        //�������� ���� ��� ��������� ������
        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chaW) return;
            new changeElement(this, connection).Show();
            chaW = true;
        }


        //�������� ���� ��� �������
        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selW < 2)
            {
                new selectElement(this, connection).Show();
                selW += 1;
            }
        }
    }
}