using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transportation_of_dangerous_goods
{
    public partial class selectElement : Form
    {

        int nTable;
        string[] currtab;
        string expression, table;
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

        private void changeTable()
        {
            SqliteCommand command;
            SqliteDataReader reader;

            for (int i = 0; i < currtab.Length; i++)
                dataGridView1.Columns[i].HeaderText = currtab[i];
            for (int i = currtab.Length; i < 8; i++)
                dataGridView1.Columns[i].HeaderText = "";

            command = new SqliteCommand("select * from " + table + expression, connection);
            reader = command.ExecuteReader();
            dataGridView1.Rows.Clear();

            switch (currtab.Length) {
                case 2:
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1));
                    }
                    break;

                case 4:
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                    }
                    break;

                case 5:
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    }
                    break;

                case 8:
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7));
                    }
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] lbl = { label1, label2, label3, label4, label5, label6, label7, label8 };
            CheckBox[] chb = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            TextBox[] txb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            
            switch (comboBox1.SelectedIndex)
            {
                case 0://orders
                    currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
                    nTable = 0;
                    label1.Text = currtab[0];
                    break;

                case 1://trip
                    currtab = new string[] { "Номер рейса", "ID заказа", "Транспорт", "Дата отправления", "Дата прибытия" };
                    nTable = 1;
                    label1.Text = currtab[0];
                    break;

                case 2://transport
                    currtab = new string[] { "ID транспорта", "Экипаж", "Мкасимальный объем", "Максимальный вес", "Наименование" };
                    nTable = 2;
                    label1.Text = currtab[0];
                    break;

                case 3://company
                    currtab = new string[] { "Название", "Регион", "Город", "Адрес", "Количество заказов" };
                    nTable = 3;
                    label1.Text = currtab[0];
                    break;

                case 4://tarif
                    currtab = new string[] { "Название", "Классы грузов", "Цена за км", "Цена за м3", "Цена за тонну" };
                    nTable = 4;
                    label1.Text = currtab[0];
                    break;

                case 5://classes_of_goods
                    currtab = new string[] { "Номер класса", "Пояснение" };
                    nTable = 5;
                    label1.Text = currtab[0];
                    break;

                case 6://crew
                    currtab = new string[] { "Номер экипажа", "ФИО главного", "Размер экипажа", "Опыт" };
                    break;
            }


            for (int i = 0; i < currtab.Length; i++)
            {
                lbl[i].Show();
                lbl[i].Text = currtab[i];
                chb[i].Show();
                txb[i].Show();
            }
            for(int i=currtab.Length; i<8; i++)
            {
                lbl[i].Hide();
                chb[i].Hide();
                chb[i].Checked = false;
                txb[i].Hide();
                txb[i].Text = "";
            }
        }


        private string makeExpression(int like, ref bool and, string field, int num)
        {
            CheckBox[] chb = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8};
            TextBox[] txb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            bool check = chb[num].Checked;
            string inf = txb[num].Text;

            if (inf.Equals("")) return "";

            string res = "";

            if (and) res += " and ";
            else res += " where ";

            if (like == 0)
            {
                if (check)
                    res += field + " != " + inf;
                else res += field + " = " + inf;
            }

            else
            {
                if (check)
                    res += field + " not like '%" + inf + "%'";
                else res += field + " like '%" + inf + "%'";
            }

            and = true;
            return res;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            expression = "";
            bool oneExp = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders - id, from_company, to_company, googs, g_class, g_volume, g_weight, tarif
                    
                    table = " orders ";
                    string[] str = { "id", "from_company", "to_company", "goods", "g_class", "g_volume", "g_weight", "tarif" };

                    expression += makeExpression(0, ref oneExp, "id", 0);
                        
                    expression += makeExpression(1, ref oneExp, "from_company", 1);
                    
                    expression += makeExpression(1, ref oneExp, "to_company", 2);

                    expression += makeExpression(1, ref oneExp, "googs", 3);

                    expression += makeExpression(0, ref oneExp, "g_class", 4);

                    expression += makeExpression(0, ref oneExp, "g_volume", 5);
                    
                    expression += makeExpression(0, ref oneExp, "g_weight", 6);
                    
                    expression += makeExpression(1, ref oneExp, "tarif", 7);

                    break;

                case 1://trip - trip_number, id_orders, transport, date_departure, date_arrival

                    table = " trip ";

                    expression += makeExpression(0, ref oneExp, "trip_number", 0);

                    expression += makeExpression(0, ref oneExp, "id_orders", 1);

                    expression += makeExpression(0, ref oneExp, "transport", 2);

                    expression += makeExpression(1, ref oneExp, "date_departure", 3);

                    expression += makeExpression(1, ref oneExp, "date_arrival", 4);

                    break;

                case 2://transport - id, crew, max_volume, max_weight, name_transport
                    table = " transport ";


                    expression += makeExpression(0, ref oneExp, "id", 0);

                    expression += makeExpression(0, ref oneExp, "crew", 1);

                    expression += makeExpression(0, ref oneExp, "max_volume", 2);

                    expression += makeExpression(0, ref oneExp, "max_weight", 3);

                    expression += makeExpression(1, ref oneExp, "name_transport", 4);
                    break;

                case 3://company - name, region, city, adress, count_orders
                    table = " company ";

                    expression += makeExpression(1, ref oneExp, "name", 0);

                    expression += makeExpression(1, ref oneExp, "region", 1);

                    expression += makeExpression(1, ref oneExp, "city", 2);

                    expression += makeExpression(1, ref oneExp, "adress", 3);

                    expression += makeExpression(0, ref oneExp, "count_orders", 4);
                    break;

                case 4://tarif - tarif_name, class_of_goods, len, weight, volume
                    table = " tarif ";

                    expression += makeExpression(1, ref oneExp, "tarif_name", 0);

                    expression += makeExpression(0, ref oneExp, "class_of_goods", 1);

                    expression += makeExpression(0, ref oneExp, "len", 2);

                    expression += makeExpression(0, ref oneExp, "weight", 3);

                    expression += makeExpression(0, ref oneExp, "volume", 4);
                    break;

                case 5://classes_of_goods - class_number, desc
                    table = " classes_of_goods ";

                    expression += makeExpression(0, ref oneExp, "class_number", 0);

                    expression += makeExpression(1, ref oneExp, "desc", 1);
                    break;

                case 6://crew - number_crew, fio_lider, persons, experience
                    table = " crew ";

                    expression += makeExpression(0, ref oneExp, "number_crew", 0);

                    expression += makeExpression(1, ref oneExp, "fio_lider", 1);

                    expression += makeExpression(0, ref oneExp, "persons", 2);

                    expression += makeExpression(0, ref oneExp, "experience", 3);
                    break;
            }

            expression += ";";
            MessageBox.Show(expression);
            changeTable();
        }
    }
}
