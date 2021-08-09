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
    public partial class Form3 : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public Form3()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet3.InTour". При необходимости она может быть перемещена или удалена.
            this.inTourTableAdapter.Fill(this.myDataBaseDataSet3.InTour);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet2.Hotels". При необходимости она может быть перемещена или удалена.
            this.hotelsTableAdapter.Fill(this.myDataBaseDataSet2.Hotels);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = true;

            try
            {
                const string comand = "SELECT * FROM InTour WHERE sdata=@sdata AND edata = @edata AND inprice = @inprice AND hotelid=@hotelid";
                SqlCommand check = new SqlCommand(comand, conn);
                check.Parameters.AddWithValue("@sdata", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                check.Parameters.AddWithValue("@edata", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                check.Parameters.AddWithValue("@inprice", SqlDbType.Int).Value = textBox1.Text;
                check.Parameters.AddWithValue("@hotelid", SqlDbType.Int).Value = textBox2.Text;

                conn.Open();

                using (var dataReader = check.ExecuteReader())
                {
                    success = dataReader.Read();
                }

            }

            finally
            {
                conn.Close();
            }
            if (!success)
            {
                conn.Open();
                {
                    SqlCommand insert = new SqlCommand();
                    insert.Parameters.AddWithValue("@sdata", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    insert.Parameters.AddWithValue("@edata", SqlDbType.Int).Value = dateTimePicker2.Value.Date;
                    insert.Parameters.AddWithValue("@inprice", SqlDbType.Int).Value = textBox2.Text;
                    insert.Parameters.AddWithValue("@hotelid", SqlDbType.Int).Value = textBox1.Text;
                    insert.CommandText = "INSERT INTO InTour (sdata, edata, inprice, hotelid, reserved) VALUES (@sdata, @edata, @inprice, @hotelid, 0)";
                    insert.Connection = conn;
                    insert.ExecuteNonQuery();
                    insert.Parameters.Clear();
                }
                conn.Close();
                MessageBox.Show("Добавлен новый тур");
                this.inTourTableAdapter.Fill(this.myDataBaseDataSet3.InTour);

            }
            else
            {
                MessageBox.Show("Запись с такими полями уже существует");

            }
        }



        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            object value = dataGridView1.CurrentRow.Cells[0].Value;
            textBox1.Text = Convert.ToString(value);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //{
            //    SqlCommand insert = new SqlCommand();
            //    insert.Parameters.AddWithValue("@sdata", SqlDbType.Date).Value = dataGridView2.CurrentRow.Cells[1].Value;
            //    insert.Parameters.AddWithValue("@edata", SqlDbType.Date).Value = dataGridView2.CurrentRow.Cells[2].Value;
            //    insert.Parameters.AddWithValue("@inprice", SqlDbType.Money).Value = dataGridView2.CurrentRow.Cells[3].Value;
            //    insert.Parameters.AddWithValue("@reserved", SqlDbType.Bit).Value = dataGridView2.CurrentRow.Cells[4].Value;
            //    insert.Parameters.AddWithValue("@hotelid", SqlDbType.Int).Value = dataGridView2.CurrentRow.Cells[5].Value;
            //    insert.CommandText = "UPDATE InTour SET sdata=@sdata, edata=@edata, inprice=@inprice, reserved=@reserved WHERE id=@id";
            //    insert.Connection = conn;
            //    insert.ExecuteNonQuery();
            //    insert.Parameters.Clear();
            //}
            //conn.Close();
            //richTextBox1.Text = richTextBox1.Text + "Изменена запись:\n" + "Название - " + dataGridView1.CurrentRow.Cells[1].Value +
            //            ", " + Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) + " комнаты, " + dataGridView1.CurrentRow.Cells[3].Value + "\n";
            this.inTourTableAdapter.Update(this.myDataBaseDataSet3.InTour);
            this.inTourTableAdapter.Fill(this.myDataBaseDataSet3.InTour);
        }
    }
}
