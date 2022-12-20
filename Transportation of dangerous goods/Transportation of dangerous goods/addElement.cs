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

        Form1 f1;
        SqliteConnection connection;
        int nTable = 0;
        string[] currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };


    public addElement(Form1 f)
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
            f1 = f;
            comboBox1.SelectedIndex = 0;
        }


        //добавление в таблицу
        private void button1_Click(object sender, EventArgs e)
        {
            String str = String.Format("insert into orders " +
                    "values ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, '{7}');", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);

            switch (nTable) {

                case (0)://orders
                    str = String.Format("insert into orders " +
                    "values ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, '{7}');", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
                    break;

                case (1)://trip
                    str = String.Format("insert into trip " +
                    "values ({0}, {1}, {2}, '{3}', '{4}');", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text);
                    break;

                case (2)://transport
                    str = String.Format("insert into transport " +
                    "values ({0}, {1}, {2}, {3}, '{4}');", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text);
                    break;

                case (3)://company
                    str = String.Format("insert into company " +
                    "values ('{0}', '{1}', '{2}', '{3}', {4});", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text);
                    break;

                case (4)://tarif
                    str = String.Format("insert into tarif " +
                    "values ('{0}', {1}, {2}, {3}, {4});", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text);
                    break;

                case (5)://classes_of_goods
                    str = String.Format("insert into classes_of_goods " +
                    "values ({0}, '{1}');", textBox1.Text, textBox2.Text);
                    break;

                case (6)://crew
                    str = String.Format("insert into crew " +
                    "values ({0}, '{1}', {2}, {3});", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    break;
            }

            try
            {
                SqliteCommand command = new SqliteCommand(str, connection);
                command.ExecuteNonQuery();
                f1.updTables();
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка при добвалении",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        //закрытие формы
        private void button2_Click(object sender, EventArgs e)
        {
            f1.setAddFalse();
            Close();
        }


        //выбор таблицы для добавления
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] lbl = { label1, label2, label3, label4, label5, label6, label7, label8 };
            TextBox[] txb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            for (int i = 0; i < 8; i++)
            {
                lbl[i].Show();
                txb[i].Show();
                txb[i].Clear();
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders
                    currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
                    nTable = 0;
                    break;

                case 1://trip
                    currtab = new string[] { "Номер рейса", "ID заказа", "Транспорт", "Дата отправления", "Дата прибытия" };
                    nTable = 1;
                    break;
                
                case 2://transport
                    currtab = new string[] { "ID транспорта", "Экипаж", "Мкасимальный объем", "Максимальный вес", "Наименование" };
                    nTable = 2;
                    break;

                case 3://company
                    currtab = new string[] { "Название", "Регион", "Город", "Адрес", "Количество заказов" };
                    nTable = 3;
                    break;

                case 4://tarif
                    currtab = new string[] { "Название", "Классы грузов", "Цена за км", "Цена за м3", "Цена за тонну" };
                    nTable = 4;
                    break;

                case 5://classes_of_goods
                    currtab = new string[] { "Номер класса", "Пояснение" };
                    nTable = 5;
                    break;

                case 6://crew
                    currtab = new string[] { "Номер экипажа", "ФИО главного", "Размер экипажа", "Опыт" };
                    nTable = 6;
                    break;
            }

            for (int i = 0; i < currtab.Length; i++)
            {
                lbl[i].Text = currtab[i];
            }
            for (int i = currtab.Length; i < 8; i++)
            {
                txb[i].Hide();
                lbl[i].Hide();
            }
        }

        private void addElement_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.setAddFalse();
        }
    }
}
