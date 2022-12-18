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
    public partial class selectElement : Form
    {

        int nTable;
        string[] currtab;
        SqliteConnection connection;
        public selectElement()
        {
            InitializeComponent();
            connection = new SqliteConnection("Data Source=../../../Trans_dangerous_goods_DB.db");
            connection.Open();
            comboBox1.SelectedIndex = 0;
            nTable = 0;
            currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqliteCommand command;
            SqliteDataReader reader;

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders
                    currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
                    for(int i = 0; i < currtab.Length; i++)
                        dataGridView1.Columns[i].HeaderText = currtab[i];
                    nTable = 0;

                    command = new SqliteCommand("select * from orders", connection);
                    reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7));
                    }
                    break;

                case 1://trip
                    currtab = new string[] { "Номер рейса", "ID заказа", "Транспорт", "Дата отправления", "Дата прибытия" };
                    for (int i = 0; i < currtab.Length; i++)
                        dataGridView1.Columns[i].HeaderText = currtab[i];
                    nTable = 1;

                    command = new SqliteCommand("select * from trip", connection);
                    reader = command.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    }
                    break;

                case 2://transport
                    //currtab = new string[] { "ID транспорта", "Экипаж", "Мкасимальный объем", "Максимальный вес", "Наименование" };
                    nTable = 2;
                    break;

                case 3://company
                    //currtab = new string[] { "Название", "Регион", "Город", "Адрес", "Количество заказов" };
                    nTable = 3;
                    break;

                case 4://tarif
                    //currtab = new string[] { "Название", "Классы грузов", "Цена за км", "Цена за м3", "Цена за тонну" };
                    nTable = 4;
                    break;

                case 5://classes_of_goods
                    //currtab = new string[] { "Номер класса", "Пояснение" };
                    nTable = 5;
                    break;

                case 6://crew
                    //currtab = new string[] { "Номер экипажа", "ФИО главного", "Размер экипажа", "Опыт" };
                    nTable = 6;
                    break;
            }
        }
    }
}
