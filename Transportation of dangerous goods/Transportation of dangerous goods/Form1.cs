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
        SqliteConnection connection;
        protected static string role = "user";

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
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
            updTables();
        }


        //�������� ����� ��
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();

        }


        //�������� ��
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.Close();
        }


        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //���� ��� ���������� ������
        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (role == "user")
            {
                MessageBox.Show(
                    "� ��� ������������ ���������� ��� ����� ��������",
                    "���������� ��������� ��������",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new addElement().Show();
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
            if (role == "user")
            {
                MessageBox.Show(
                    "� ��� ������������ ���������� ��� ����� ��������",
                    "���������� ��������� ��������",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            new deleteElement().Show();
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
                "����� �� � ���� ������������!",
                "����� ����",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            role = "user";
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new selectElement().Show();
        }
    }
}