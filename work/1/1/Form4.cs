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
    public partial class Form4 : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public Form4()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
        }

       
        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet1.Hotels". При необходимости она может быть перемещена или удалена.
            this.hotelsTableAdapter.Fill(this.myDataBaseDataSet.Hotels);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                

                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    try
                    {
                        const string comand = "Select * from Hotels WHERE hname=@hname AND rooms = @rooms AND country = @country";
                        SqlCommand check = new SqlCommand(comand, conn);
                        check.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                        check.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = row.Cells[2].Value;
                        check.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = row.Cells[3].Value;
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
                            insert.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                            insert.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = row.Cells[2].Value;
                            insert.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = row.Cells[3].Value;
                            insert.CommandText = "INSERT INTO Hotels (hname, rooms, country) VALUES (@hname, @rooms, @country)";
                            insert.Connection = conn;
                            insert.ExecuteNonQuery();
                            insert.Parameters.Clear();
                        }
                        conn.Close();
                        richTextBox1.Text = richTextBox1.Text + "Добавлена запись:\n" + "Название - " + row.Cells[1].Value +
                        ", " + Convert.ToString(row.Cells[2].Value) + "комнаты, " + row.Cells[3].Value + "\n";
                    }
                    
                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + "Запись с такими полями уже существует:\n" + "Название - " + row.Cells[1].Value +
                        ", " + Convert.ToString(row.Cells[2].Value) + "комнаты, " + row.Cells[3].Value + "\n";
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet1.Hotels". При необходимости она может быть перемещена или удалена.
                    this.hotelsTableAdapter.Fill(this.myDataBaseDataSet.Hotels);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            {
                SqlCommand insert = new SqlCommand();
                insert.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = dataGridView1.CurrentRow.Cells[1].Value;
                insert.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = dataGridView1.CurrentRow.Cells[2].Value;
                insert.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = dataGridView1.CurrentRow.Cells[3].Value;
                insert.CommandText = "DELETE FROM Hotels WHERE hname=@hname AND rooms = @rooms AND country = @country";
                insert.Connection = conn;
                insert.ExecuteNonQuery();
                insert.Parameters.Clear();
            }
            conn.Close();
            richTextBox1.Text = richTextBox1.Text + "Удалена запись:\n" + "Название - " + dataGridView1.CurrentRow.Cells[1].Value +
                        ", " + Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) + " комнаты, " + dataGridView1.CurrentRow.Cells[3].Value + "\n";
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet1.Hotels". При необходимости она может быть перемещена или удалена.
            this.hotelsTableAdapter.Fill(this.myDataBaseDataSet.Hotels);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //{
            //    SqlCommand insert = new SqlCommand();
            //    insert.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = dataGridView1.CurrentRow.Cells[1].Value;
            //    insert.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = dataGridView1.CurrentRow.Cells[2].Value;
            //    insert.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = dataGridView1.CurrentRow.Cells[3].Value;
            //    insert.Parameters.AddWithValue("@id", SqlDbType.Int).Value = dataGridView1.CurrentRow.Cells[0].Value;
            //    insert.CommandText = "UPDATE Hotels SET hname=@hname AND rooms = @rooms AND country = @country WHERE id=@id";
            //    insert.Connection = conn;
            //    insert.ExecuteNonQuery();
            //    insert.Parameters.Clear();
            //}
            //conn.Close();
            //richTextBox1.Text = richTextBox1.Text + "Изменена запись:\n" + "Название - " + dataGridView1.CurrentRow.Cells[1].Value +
            //            ", " + Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) + " комнаты, " + dataGridView1.CurrentRow.Cells[3].Value + "\n";
            //// TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet1.Hotels". При необходимости она может быть перемещена или удалена.

            this.hotelsTableAdapter.Update(this.myDataBaseDataSet.Hotels);
            this.hotelsTableAdapter.Fill(this.myDataBaseDataSet.Hotels);
        }
    }
}
