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
using System.Windows.Forms.VisualStyles;

namespace Transportation_of_dangerous_goods
{
    public partial class changeElement : Form
    {

        //переменные
        Form1 f1;
        SqliteConnection connection;
        string[] currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
        bool and = false;
        bool sets = false;
        string role = "";


        //конструктор
        public changeElement(Form1 f, SqliteConnection newCon, string rol)
        {
            InitializeComponent();
            connection = newCon;
            comboBox1.SelectedIndex = 0;
            role = rol;
            f1 = f;
            comboBox1_SelectedIndexChanged(this, EventArgs.Empty);
        }


        //создание выражения для выборки
        private string makeExpression(int like, string field, int num)
        {
            CheckBox[] chb = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
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


        //создание выражения для изменения (на него заменяется)
        private string makeChangesForItem(int like, string field, int newText)
        {
            TextBox[] txb = { textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 };

            if (txb[newText].Text.Equals("")) return "";


            string res = "";
            if (sets) res += ",";
            else sets = true;

            if (like == 0)
                res += field + " = " + txb[newText].Text;
            else
                res += field + " = '" + txb[newText].Text + "'";
            return res;
        }


        //изменение элементов
        private void button1_Click(object sender, EventArgs e)
        {
            string find = "";
            string replaceAt = "set ";
            string table = "";

            sets = false;
            and = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders - id, from_company, to_company, googs, g_class, g_volume, g_weight, tarif

                    table = " orders ";

                    find += makeExpression(0, "id", 0);
                    find += makeExpression(1, "from_company", 1);
                    find += makeExpression(1, "to_company", 2);
                    find += makeExpression(1, "googs", 3);
                    find += makeExpression(0, "g_class", 4);
                    find += makeExpression(0, "g_volume", 5);
                    find += makeExpression(0, "g_weight", 6);
                    find += makeExpression(1, "tarif", 7);

                    replaceAt += makeChangesForItem(0, "id", 0);
                    replaceAt += makeChangesForItem(1, "from_company", 1);
                    replaceAt += makeChangesForItem(1, "to_company", 2);
                    replaceAt += makeChangesForItem(1, "googs", 3);
                    replaceAt += makeChangesForItem(0, "g_class", 4);
                    replaceAt += makeChangesForItem(0, "g_volume", 5);
                    replaceAt += makeChangesForItem(0, "g_weight", 6);
                    replaceAt += makeChangesForItem(1, "tarif", 7);
                    break;

                case 1://trip - trip_number, id_orders, transport, date_departure, date_arrival

                    table = " trip ";

                    find += makeExpression(0, "trip_number", 0);

                    find += makeExpression(0, "id_orders", 1);

                    find += makeExpression(0, "transport", 2);

                    find += makeExpression(1, "date_departure", 3);

                    find += makeExpression(1, "date_arrival", 4);

                    replaceAt += makeChangesForItem(0, "trip_number", 0);

                    replaceAt += makeChangesForItem(0, "id_orders", 1);

                    replaceAt += makeChangesForItem(0, "transport", 2);

                    replaceAt += makeChangesForItem(1, "date_departure", 3);

                    replaceAt += makeChangesForItem(1, "date_arrival", 4);
                    break;

                case 2://transport - id, crew, max_volume, max_weight, name_transport

                    table = " transport ";

                    find += makeExpression(0, "id", 0);

                    find += makeExpression(0, "crew", 1);

                    find += makeExpression(0, "max_volume", 2);

                    find += makeExpression(0, "max_weight", 3);

                    find += makeExpression(1, "name_transport", 4);

                    replaceAt += makeChangesForItem(0, "id", 0);

                    replaceAt += makeChangesForItem(0, "crew", 1);

                    replaceAt += makeChangesForItem(0, "max_volume", 2);

                    replaceAt += makeChangesForItem(1, "max_weight", 3);

                    replaceAt += makeChangesForItem(1, "name_transport", 4);
                    break;

                case 3://company - name, region, city, adress, count_orders

                    table = " company ";

                    find += makeExpression(1, "name", 0);

                    find += makeExpression(1, "region", 1);

                    find += makeExpression(1, "city", 2);

                    find += makeExpression(1, "adress", 3);

                    find += makeExpression(0, "count_orders", 4);

                    replaceAt += makeChangesForItem(1, "name", 0);

                    replaceAt += makeChangesForItem(1, "region", 1);

                    replaceAt += makeChangesForItem(1, "city", 2);

                    replaceAt += makeChangesForItem(1, "adress", 3);

                    replaceAt += makeChangesForItem(0, "count_orders", 4);
                    break;

                case 4://tarif - tarif_name, class_of_goods, len, weight, volume

                    table = " tarif ";

                    find += makeExpression(1, "tarif_name", 0);

                    find += makeExpression(0, "class_of_goods", 1);

                    find += makeExpression(0, "len", 2);

                    find += makeExpression(0, "weight", 3);

                    find += makeExpression(0, "volume", 4);

                    replaceAt += makeChangesForItem(1, "tarif_name", 0);

                    replaceAt += makeChangesForItem(0, "class_of_goods", 1);

                    replaceAt += makeChangesForItem(0, "len", 2);

                    replaceAt += makeChangesForItem(0, "weight", 3);

                    replaceAt += makeChangesForItem(0, "volume", 4);
                    break;

                case 5://classes_of_goods - class_number, desc

                    table = " classes_of_goods ";

                    find += makeExpression(0, "class_number", 0);

                    find += makeExpression(1, "desc", 1);

                    replaceAt += makeChangesForItem(0, "class_number", 0);

                    replaceAt += makeChangesForItem(1, "desc", 1);
                    break;

                case 6://crew - number_crew, fio_lider, persons, experience

                    table = " crew ";

                    find += makeExpression(0, "number_crew", 0);

                    find += makeExpression(1, "fio_lider", 1);

                    find += makeExpression(0, "persons", 2);

                    find += makeExpression(0, "experience", 3);

                    replaceAt += makeChangesForItem(0, "number_crew", 0);

                    replaceAt += makeChangesForItem(1, "fio_lider", 1);

                    replaceAt += makeChangesForItem(0, "persons", 2);

                    replaceAt += makeChangesForItem(0, "experience", 3);
                    break;
            }


            //если выражение составлено не корректно
            find += ";";
            if (replaceAt.Equals("set ") || find.Equals(""))
            {
                MessageBox.Show(
                        "Невозможно заменить",
                        "Изменение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                return;
            }

            SqliteCommand comDel = new SqliteCommand("update " + table + replaceAt + find, connection);
            SqliteCommand nc = new SqliteCommand("select count(*) from" + table + find, connection);


            //попытка изменения данных
            try
            {
                string count =  nc.ExecuteScalar().ToString();
                if (int.Parse(count) == 0)
                {
                    MessageBox.Show(
                            "Записи не найдены",
                            "Изменение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    return;
                }

                DialogResult result = MessageBox.Show(
                       "Будет изменено " + count + " записей",
                       "Изменение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    comDel.ExecuteNonQuery();
                    f1.updTables();
                    MessageBox.Show(
                            "Записи изменены",
                            "Изменение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                }

            }
            catch
            {
                MessageBox.Show(
                        "Ошибка при изменении записей",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
            }
        }


        //выбор таблицы для добавления
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] lbl = { label1, label2, label3, label4, label5, label6, label7, label8,
                            label9, label10, label11, label12, label13, label14, label15, label16};
            TextBox[] txb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8,
                            textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16};
            CheckBox[] chb = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };

            for (int i = 0; i < 8; i++)
            {
                lbl[i].Show();
                lbl[i + 8].Show();
                chb[i].Show();
                txb[i].Show();
                txb[i + 8].Show();
                txb[i].Clear();
            }

            button1.Enabled = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0://orders
                    if (role.Equals("hr")) button1.Enabled = false;
                    currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
                    break;

                case 1://trip
                    if (role.Equals("hr")) button1.Enabled = false;
                    currtab = new string[] { "Номер рейса", "ID заказа", "Транспорт", "Дата отправления", "Дата прибытия" };
                    break;

                case 2://transport
                    if (role.Equals("hr")) button1.Enabled = false;
                    if (role.Equals("dispatcher")) button1.Enabled = false;
                    currtab = new string[] { "ID транспорта", "Экипаж", "Мкасимальный объем", "Максимальный вес", "Наименование" };
                    break;

                case 3://company
                    if (role.Equals("hr")) button1.Enabled = false;
                    if (role.Equals("dispatcher")) button1.Enabled = false;
                    currtab = new string[] { "Название", "Регион", "Город", "Адрес", "Количество заказов" };
                    break;

                case 4://tarif
                    if (role.Equals("hr")) button1.Enabled = false;
                    if (role.Equals("dispatcher")) button1.Enabled = false;
                    currtab = new string[] { "Название", "Классы грузов", "Цена за км", "Цена за м3", "Цена за тонну" };
                    break;

                case 5://classes_of_goods
                    if (role.Equals("hr")) button1.Enabled = false;
                    if (role.Equals("dispatcher")) button1.Enabled = false;
                    currtab = new string[] { "Номер класса", "Пояснение" };
                    break;

                case 6://crew
                    if (role.Equals("dispatcher")) button1.Enabled = false;
                    currtab = new string[] { "Номер экипажа", "ФИО главного", "Размер экипажа", "Опыт" };
                    break;
            }

            for (int i = 0; i < currtab.Length; i++)
            {
                lbl[i].Text = currtab[i];
            }
            for (int i = currtab.Length; i < 8; i++)
            {
                txb[i].Hide();
                txb[i + 8].Hide();
                chb[i].Hide();
                lbl[i].Hide();
                lbl[i + 8].Hide();
            }
        }

        //закрытие формы
        private void changeElement_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.updTables();
            f1.setChaFalse();
        }
    }
}
