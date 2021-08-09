using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1
{
    public partial class SellingTours : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        string data1;
        public SellingTours()
        {

            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
            
        }

        private void SellingTours_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet4.InTour". При необходимости она может быть перемещена или удалена.
            this.inTourTableAdapter.Fill(this.myDataBaseDataSet4.InTour, Convert.ToString(dateTimePicker1.Value.Date), Convert.ToString(dateTimePicker2.Value.Date));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.inTourTableAdapter.Fill(this.myDataBaseDataSet4.InTour, Convert.ToString(dateTimePicker1.Value.Date), Convert.ToString(dateTimePicker2.Value.Date));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            SqlCommand insert = new SqlCommand();
            insert.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = textBox1.Text;
            insert.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = textBox2.Text;
            insert.Parameters.AddWithValue("@tourid", SqlDbType.Int).Value = textBox4.Text;
            insert.Parameters.AddWithValue("@saleprice", SqlDbType.Money).Value = textBox3.Text;
            insert.Parameters.AddWithValue("@avance", SqlDbType.Money).Value = textBox5.Text;
            insert.Parameters.AddWithValue("@dataavance", SqlDbType.Date).Value = Convert.ToDateTime(textBox7.Text);
            insert.CommandText = "INSERT INTO SaleTour (fname,lname,tourid,saleprice,avance,dataavance) VALUES (@fname,@lname,@tourid,@saleprice,@avance,@dataavance)";
            insert.Connection = conn;
            insert.ExecuteNonQuery();
            insert.Parameters.Clear();
            conn.Close();

            conn.Open();
            SqlCommand update = new SqlCommand();
            update.CommandText = "UPDATE InTour SET reserved=1, sale=0 where id=@id";
            update.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox4.Text;
            update.Connection = conn;
            update.ExecuteNonQuery();
            update.Parameters.Clear();
            MessageBox.Show("Зарезирвировано");
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = Convert.ToString(Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value) * 1.25);
            //data1 = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string i = "";
            double a = 0;
            
            try
            {
                i = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                a = Convert.ToDouble(i) - Convert.ToDouble(textBox5.Text);
                textBox6.Text = Convert.ToString(a);

                /*string i = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = i;
                int a = (int)(Convert.ToInt32(i) - Convert.ToInt32(textBox5.Text));*/

            }
            catch
            {
                textBox5.Text = "";
                textBox6.Text = "";
            }
            DateTime t1 = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            DateTime t2 = t1.AddDays(-10);
            /*textBox7.Text = Convert.ToDateTime(t2).ToShortDateString();*/
            textBox7.Text = Convert.ToString(t2);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
              textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
              textBox3.Text = Convert.ToString(Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value) * 1.25);
              
        }

        private void SellingTours_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool success = true;
            try
            {
                const string comand = "Select * from SaleTour WHERE TourId= @tourid ";
                SqlCommand check = new SqlCommand(comand, conn);
                check.Parameters.AddWithValue("@tourid", textBox4.Text);
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
                SqlCommand insert = new SqlCommand();
                insert.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = textBox1.Text;
                insert.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = textBox2.Text;
                insert.Parameters.AddWithValue("@tourid", SqlDbType.Int).Value = textBox4.Text;
                insert.Parameters.AddWithValue("@saleprice", SqlDbType.Money).Value = textBox3.Text;
                insert.CommandText = "INSERT INTO SaleTour (fname,lname,tourid,saleprice) VALUES (@fname,@lname,@tourid,@saleprice)";
                insert.Connection = conn;
                insert.ExecuteNonQuery();
                insert.Parameters.Clear();
                conn.Close();
                conn.Open();
                SqlCommand update = new SqlCommand();
                update.CommandText = "UPDATE InTour SET sale=0, reserved=1 where id=@id";
                update.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox4.Text;
                update.Connection = conn;
                update.ExecuteNonQuery();
                update.Parameters.Clear();
                conn.Close();
                MessageBox.Show("Продажа осуществилась");
            }
            else
            {
                conn.Open();
                SqlCommand update = new SqlCommand();
                update.CommandText = "UPDATE InTour SET sale=1, reserved=0 where id=@id";
                update.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox4.Text;
                update.Connection = conn;
                update.ExecuteNonQuery();
                update.Parameters.Clear();
                MessageBox.Show("Продан зарезервированный тур");
                conn.Close();
                
            }
            

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.inTourTableAdapter.FillBy(this.myDataBaseDataSet4.InTour, Convert.ToString(dateTimePicker1.Value.Date), Convert.ToString(dateTimePicker2.Value.Date));
            string first = "";
            string second = "";
            conn.Open();
            using (SqlCommand sel = new SqlCommand("Select st.Fname,st.LName From SaleTour as st,InTour as it where st.Tourid=@id",conn))
            {
                sel.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox4.Text;
                using (SqlDataReader reader = sel.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        first = reader["Fname"].ToString();
                        second = reader["Lname"].ToString();
                    }
                }
            }
            textBox1.Text = second;
            textBox2.Text=second;
            conn.Close();
        }

        private void SellingTours_Load_1(object sender, EventArgs e)
        {

        }
    }
}

