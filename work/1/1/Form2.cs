using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form2 : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public Form2()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void отелиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void добавитьТурToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void продажаТураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellingTours sell = new SellingTours();
            sell.ShowDialog();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\t    Тур Оператор v0.01\t\nПрограмма разработана для ведения учета продажи туров\nРазработчик: Лобачева Ю.В.\nAllRightsReserved");
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckSale check = new CheckSale();
            check.ShowDialog();
        }

        private void валоваяПрибыльToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VP vp = new VP();
            vp.ShowDialog();
        }

        private void загрузитьИзToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFrom up = new UploadFrom();
            up.ShowDialog();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void поискТуровToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void продажаРезерваToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
