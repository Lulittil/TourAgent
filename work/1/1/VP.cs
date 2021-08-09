using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class VP : Form
    {
        public VP()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1).AddDays(-1);
        }

        private void VP_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDataBaseDataSet6.InTour". При необходимости она может быть перемещена или удалена.
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.inTourTableAdapter.Fill(this.myDataBaseDataSet6.InTour, Convert.ToString(dateTimePicker1.Value.Date), Convert.ToString(dateTimePicker2.Value.Date));

            //this.dataGridView1.Rows[0].Cells[6] = ;
        }
    }
}
