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
    public partial class CheckSale : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public CheckSale()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
        }

        private void CheckSale_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet5.SaleTour". При необходимости она может быть перемещена или удалена.
            //string first = ;

 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.saleTourTableAdapter.Fill(this.myDataBaseDataSet5.SaleTour, Convert.ToString(dateTimePicker1.Value.Date), Convert.ToString(dateTimePicker2.Value.Date));

        }

    }
}
