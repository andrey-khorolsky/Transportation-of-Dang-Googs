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
    public partial class deleteElement : Form
    {

        Form1 f1;
        SqliteConnection connection;
        String[] currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };

        public deleteElement(Form1 f, SqliteConnection newCon)
        {
            InitializeComponent();
            connection = newCon;
            comboBox1.SelectedIndex = 0;
            f1 = f;
        }

        private string makeExpression(int like, ref bool and, string field, int num)
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


        //удаление записей
        private void button3_Click(object sender, EventArgs e)
        {
            String strForDel = new string("delete from ");
            string table="";

            strForDel = "";
            bool oneExp = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders - id, from_company, to_company, googs, g_class, g_volume, g_weight, tarif

                    table = " orders ";
                    string[] str = { "id", "from_company", "to_company", "goods", "g_class", "g_volume", "g_weight", "tarif" };

                    strForDel += makeExpression(0, ref oneExp, "id", 0);

                    strForDel += makeExpression(1, ref oneExp, "from_company", 1);

                    strForDel += makeExpression(1, ref oneExp, "to_company", 2);

                    strForDel += makeExpression(1, ref oneExp, "googs", 3);

                    strForDel += makeExpression(0, ref oneExp, "g_class", 4);

                    strForDel += makeExpression(0, ref oneExp, "g_volume", 5);

                    strForDel += makeExpression(0, ref oneExp, "g_weight", 6);

                    strForDel += makeExpression(1, ref oneExp, "tarif", 7);

                    break;

                case 1://trip - trip_number, id_orders, transport, date_departure, date_arrival

                    table = " trip ";

                    strForDel += makeExpression(0, ref oneExp, "trip_number", 0);

                    strForDel += makeExpression(0, ref oneExp, "id_orders", 1);

                    strForDel += makeExpression(0, ref oneExp, "transport", 2);

                    strForDel += makeExpression(1, ref oneExp, "date_departure", 3);

                    strForDel += makeExpression(1, ref oneExp, "date_arrival", 4);

                    break;

                case 2://transport - id, crew, max_volume, max_weight, name_transport
                    table = " transport ";


                    strForDel += makeExpression(0, ref oneExp, "id", 0);

                    strForDel += makeExpression(0, ref oneExp, "crew", 1);

                    strForDel += makeExpression(0, ref oneExp, "max_volume", 2);

                    strForDel += makeExpression(0, ref oneExp, "max_weight", 3);

                    strForDel += makeExpression(1, ref oneExp, "name_transport", 4);
                    break;

                case 3://company - name, region, city, adress, count_orders
                    table = " company ";

                    strForDel += makeExpression(1, ref oneExp, "name", 0);

                    strForDel += makeExpression(1, ref oneExp, "region", 1);

                    strForDel += makeExpression(1, ref oneExp, "city", 2);

                    strForDel += makeExpression(1, ref oneExp, "adress", 3);

                    strForDel += makeExpression(0, ref oneExp, "count_orders", 4);
                    break;

                case 4://tarif - tarif_name, class_of_goods, len, weight, volume
                    table = " tarif ";

                    strForDel += makeExpression(1, ref oneExp, "tarif_name", 0);

                    strForDel += makeExpression(0, ref oneExp, "class_of_goods", 1);

                    strForDel += makeExpression(0, ref oneExp, "len", 2);

                    strForDel += makeExpression(0, ref oneExp, "weight", 3);

                    strForDel += makeExpression(0, ref oneExp, "volume", 4);
                    break;

                case 5://classes_of_goods - class_number, desc
                    table = " classes_of_goods ";

                    strForDel += makeExpression(0, ref oneExp, "class_number", 0);

                    strForDel += makeExpression(1, ref oneExp, "desc", 1);
                    break;

                case 6://crew - number_crew, fio_lider, persons, experience
                    table = " crew ";

                    strForDel += makeExpression(0, ref oneExp, "number_crew", 0);

                    strForDel += makeExpression(1, ref oneExp, "fio_lider", 1);

                    strForDel += makeExpression(0, ref oneExp, "persons", 2);

                    strForDel += makeExpression(0, ref oneExp, "experience", 3);
                    break;
            }

            strForDel += ";";
            //MessageBox.Show(strForDel);

            //strForDel += ";";

            SqliteCommand comDel = new SqliteCommand("delete from " + table + strForDel, connection);
            SqliteCommand nc = new SqliteCommand("select count(*) from" + table + strForDel, connection);


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
                {
                    comDel.ExecuteNonQuery();
                    f1.updTables();
                    MessageBox.Show(
                            "Записи удалены",
                            "Удаление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                }
                f1.Focus();
                this.Focus();

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



        //закрытие формы через кнопку "отмена"
        private void button2_Click(object sender, EventArgs e)
        {
            f1.setDelFalse();
            Close();
        }



        //выбор таблицы для добавления
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] lbl = { label1, label2, label3, label4, label5, label6, label7, label8 };
            TextBox[] txb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            CheckBox[] chb = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };

            for (int i = 0; i < 8; i++)
            {
                lbl[i].Show();
                chb[i].Show();
                txb[i].Show();
                txb[i].Clear();
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0://orders
                    currtab = new string[] { "ID", "От кого", "Кому", "Груз", "Класс груза", "Объем груза", "Вес груза", "Тариф" };
                    break;

                case 1://trip
                    currtab = new string[] { "Номер рейса", "ID заказа", "Транспорт", "Дата отправления", "Дата прибытия" };
                    break;

                case 2://transport
                    currtab = new string[] { "ID транспорта", "Экипаж", "Мкасимальный объем", "Максимальный вес", "Наименование" };
                    break;

                case 3://company
                    currtab = new string[] { "Название", "Регион", "Город", "Адрес", "Количество заказов" };
                    break;

                case 4://tarif
                    currtab = new string[] { "Название", "Классы грузов", "Цена за км", "Цена за м3", "Цена за тонну" };
                    break;

                case 5://classes_of_goods
                    currtab = new string[] { "Номер класса", "Пояснение" };
                    break;

                case 6://crew
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
                chb[i].Hide();
                lbl[i].Hide();
            }
        }

        
        //закрытие формы
        private void deleteElement_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.setDelFalse();
        }
    }
    
}
