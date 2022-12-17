namespace Transportation_of_dangerous_goods
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рольToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администраторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.диспетчерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделКадровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборкаИзТаблицToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборкаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.n_trip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_depar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_arr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.рольToolStripMenuItem,
            this.выборкаИзТаблицToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1713, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(133, 22);
            this.openFile.Text = "Открыть";
            this.openFile.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // рольToolStripMenuItem
            // 
            this.рольToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.администраторToolStripMenuItem,
            this.диспетчерToolStripMenuItem,
            this.отделКадровToolStripMenuItem});
            this.рольToolStripMenuItem.Name = "рольToolStripMenuItem";
            this.рольToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.рольToolStripMenuItem.Text = "Роль";
            // 
            // администраторToolStripMenuItem
            // 
            this.администраторToolStripMenuItem.Name = "администраторToolStripMenuItem";
            this.администраторToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.администраторToolStripMenuItem.Text = "Администратор";
            // 
            // диспетчерToolStripMenuItem
            // 
            this.диспетчерToolStripMenuItem.Name = "диспетчерToolStripMenuItem";
            this.диспетчерToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.диспетчерToolStripMenuItem.Text = "Диспетчер";
            // 
            // отделКадровToolStripMenuItem
            // 
            this.отделКадровToolStripMenuItem.Name = "отделКадровToolStripMenuItem";
            this.отделКадровToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.отделКадровToolStripMenuItem.Text = "Отдел кадров";
            // 
            // выборкаИзТаблицToolStripMenuItem
            // 
            this.выборкаИзТаблицToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьДанныеToolStripMenuItem,
            this.удалитьДанныеToolStripMenuItem,
            this.выборкаДанныхToolStripMenuItem});
            this.выборкаИзТаблицToolStripMenuItem.Name = "выборкаИзТаблицToolStripMenuItem";
            this.выборкаИзТаблицToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.выборкаИзТаблицToolStripMenuItem.Text = "Таблицы";
            this.выборкаИзТаблицToolStripMenuItem.Click += new System.EventHandler(this.выборкаИзТаблицToolStripMenuItem_Click);
            // 
            // добавитьДанныеToolStripMenuItem
            // 
            this.добавитьДанныеToolStripMenuItem.Name = "добавитьДанныеToolStripMenuItem";
            this.добавитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.добавитьДанныеToolStripMenuItem.Text = "Добавить данные";
            this.добавитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.добавитьДанныеToolStripMenuItem_Click);
            // 
            // удалитьДанныеToolStripMenuItem
            // 
            this.удалитьДанныеToolStripMenuItem.Name = "удалитьДанныеToolStripMenuItem";
            this.удалитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.удалитьДанныеToolStripMenuItem.Text = "Удалить данные";
            // 
            // выборкаДанныхToolStripMenuItem
            // 
            this.выборкаДанныхToolStripMenuItem.Name = "выборкаДанныхToolStripMenuItem";
            this.выборкаДанныхToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.выборкаДанныхToolStripMenuItem.Text = "Выборка данных";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 544);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "show";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.from,
            this.to,
            this.goods,
            this.class_goods,
            this.g_volume,
            this.g_weight,
            this.tarif});
            this.dataGridView1.Location = new System.Drawing.Point(28, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 167);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID заказа";
            this.id.Name = "id";
            // 
            // from
            // 
            this.from.HeaderText = "Отправитель";
            this.from.Name = "from";
            this.from.Width = 200;
            // 
            // to
            // 
            this.to.HeaderText = "Приниматель";
            this.to.Name = "to";
            this.to.Width = 200;
            // 
            // goods
            // 
            this.goods.HeaderText = "Груз";
            this.goods.Name = "goods";
            // 
            // class_goods
            // 
            this.class_goods.HeaderText = "Класс груза";
            this.class_goods.Name = "class_goods";
            this.class_goods.Width = 70;
            // 
            // g_volume
            // 
            this.g_volume.HeaderText = "Объем";
            this.g_volume.Name = "g_volume";
            // 
            // g_weight
            // 
            this.g_weight.HeaderText = "Вес";
            this.g_weight.Name = "g_weight";
            this.g_weight.Width = 70;
            // 
            // tarif
            // 
            this.tarif.HeaderText = "Тариф";
            this.tarif.Name = "tarif";
            this.tarif.Width = 120;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1386, 387);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 72);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 72);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.n_trip,
            this.id_goods,
            this.transp,
            this.date_depar,
            this.date_arr});
            this.dataGridView2.Location = new System.Drawing.Point(28, 259);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(557, 150);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // n_trip
            // 
            this.n_trip.HeaderText = "Номер рейса";
            this.n_trip.Name = "n_trip";
            // 
            // id_goods
            // 
            this.id_goods.HeaderText = "ID заказа";
            this.id_goods.Name = "id_goods";
            // 
            // transp
            // 
            this.transp.HeaderText = "Транспорт";
            this.transp.Name = "transp";
            // 
            // date_depar
            // 
            this.date_depar.HeaderText = "Дата отправления";
            this.date_depar.Name = "date_depar";
            // 
            // date_arr
            // 
            this.date_arr.HeaderText = "Дата прибытия";
            this.date_arr.Name = "date_arr";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 764);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFile;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Button button2;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn from;
        private DataGridViewTextBoxColumn to;
        private DataGridViewTextBoxColumn goods;
        private DataGridViewTextBoxColumn class_goods;
        private DataGridViewTextBoxColumn g_volume;
        private DataGridViewTextBoxColumn g_weight;
        private DataGridViewTextBoxColumn tarif;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn n_trip;
        private DataGridViewTextBoxColumn id_goods;
        private DataGridViewTextBoxColumn transp;
        private DataGridViewTextBoxColumn date_depar;
        private DataGridViewTextBoxColumn date_arr;
        private ToolStripMenuItem рольToolStripMenuItem;
        private ToolStripMenuItem администраторToolStripMenuItem;
        private ToolStripMenuItem диспетчерToolStripMenuItem;
        private ToolStripMenuItem отделКадровToolStripMenuItem;
        private ToolStripMenuItem выборкаИзТаблицToolStripMenuItem;
        private ToolStripMenuItem добавитьДанныеToolStripMenuItem;
        private ToolStripMenuItem удалитьДанныеToolStripMenuItem;
        private ToolStripMenuItem выборкаДанныхToolStripMenuItem;
    }
}