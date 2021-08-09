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
    public partial class UploadFrom : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public UploadFrom()
        {
            InitializeComponent();
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
        }

        private void UploadFrom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*xlsx";
            ofd.Filter = "Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            ofd.FileName +
                            ";Extended Properties='Excel 12.0 XML;HDR=NO;';";

            System.Data.OleDb.OleDbConnection con =
                new System.Data.OleDb.OleDbConnection(constr);
            con.Open();

            DataSet ds = new DataSet();
            System.Data.DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables,
                new object[] { null, null, null, "TABLE" });

            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);

            System.Data.OleDb.OleDbDataAdapter ad =
                new System.Data.OleDb.OleDbDataAdapter(select, con);

            ad.Fill(ds);

            System.Data.DataTable tb = ds.Tables[0];
            //con.Close();
            dataGridView1.DataSource = tb;
            con.Close();
        }
            else
            {
                MessageBox.Show("Вы не выбрали файл для открытия",
                        "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            bool success = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[0].Value != null)
                {
                    try
                    {
                        const string comand = "Select * from Hotels WHERE hname=@hname AND rooms = @rooms AND country = @country";
                        SqlCommand check = new SqlCommand(comand, conn);
                        check.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                        check.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = row.Cells[1].Value;
                        check.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = row.Cells[2].Value;
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
                            insert.Parameters.AddWithValue("@hname", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                            insert.Parameters.AddWithValue("@rooms", SqlDbType.Int).Value = row.Cells[1].Value;
                            insert.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                            insert.CommandText = "INSERT INTO Hotels (hname, rooms, country) VALUES (@hname, @rooms, @country)";
                            insert.Connection = conn;
                            insert.ExecuteNonQuery();
                            insert.Parameters.Clear();
                        }
                        conn.Close();
                        richTextBox1.Text = richTextBox1.Text + "Добавлена запись:\n" + "Название - " + row.Cells[0].Value +
                        ", " + Convert.ToString(row.Cells[1].Value) + "комнаты, " + row.Cells[2].Value + "\n";
                    }

                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + "Запись с такими полями уже существует:\n" + "Название - " + row.Cells[0].Value +
                        ", " + Convert.ToString(row.Cells[1].Value) + "комнаты, " + row.Cells[2].Value + "\n";
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet1.Hotels". При необходимости она может быть перемещена или удалена.
                }


            }
        }
    }
}
