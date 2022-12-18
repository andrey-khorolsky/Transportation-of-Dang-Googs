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
    public partial class deleteElement : Form
    {
        
        SqliteConnection connection;
        int nTable = 0;
        String[] currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };

        public deleteElement()
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
            comboBox1.SelectedIndex = 0;
        }


        //удаление записей
        private void button3_Click(object sender, EventArgs e)
        {
            String strForDel = new string("delete from ");
            string table;//создание выражения из разных кусков??

            switch (nTable)
            {
                case 0: strForDel += "orders "; break;
                case 1: strForDel += "trip "; break;
                case 2: strForDel += "transport "; break;
                case 3: strForDel += "company "; break;
                case 4: strForDel += "tarif "; break;
                case 5: strForDel += "classes_of_goods "; break;
                case 6: strForDel += "crew "; break;
            }

            strForDel += "where ";
            switch (nTable)
            {
                case 0:
                    if (!textBox1.Equals(""))
                    {
                        if (checkBox1.Checked) strForDel += "id != " + textBox1.Text;
                        else strForDel += "id = " + textBox1.Text;
                    }
                    break;
                case 1:
                    if (!textBox1.Equals(""))
                    {
                        if (checkBox1.Checked) strForDel += "trip_number != " + textBox1.Text;
                        strForDel += "trip_number = " + textBox1.Text;
                    }
                    break;
                case 2:
                    if (!textBox1.Equals(""))
                        strForDel += "id = " + textBox1.Text;
                    break;
                case 3:
                    if (!textBox1.Equals(""))
                        strForDel += "name = " + textBox1.Text;
                    break;
                case 4:
                    if (!textBox1.Equals(""))
                        strForDel += "tarif_name = " + textBox1.Text;
                    break;
                case 5:
                    if (!textBox1.Equals(""))
                        strForDel += "class_number = " + textBox1.Text;
                    break;
                case 6:
                    if (!textBox1.Equals(""))
                        strForDel += "number_crew = " + textBox1.Text;
                    break;
            }
            strForDel += ";";

            SqliteCommand comDel = new SqliteCommand(strForDel, connection);
            SqliteCommand nc = new SqliteCommand("select count(*) from classes_of_goods where class_number=2;", connection);

            
            try
            {
                DialogResult result = MessageBox.Show(
                       "Будет удалено " + nc.ExecuteScalar() + " записей",
                       "Удаление",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                    MessageBox.Show(
                            "Записи удалены",
                            "Удаление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);

            }
            catch
            {
                MessageBox.Show(
                        "Ошибка при удалении записей",
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
            Form form = this;
            form.Close();
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
    }
    
}
