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
    public partial class Auth_Form : Form
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        public Auth_Form()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Auth_Form_KeyUp);
            this.button1.Click += new System.EventHandler(this.button2_Click);
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            
            try
            {
                const string comand = "Select * from Users WHERE login=@login AND password = @password";
                SqlCommand check = new SqlCommand(comand, conn);
                check.Parameters.AddWithValue("@login", FieldLogin.Text);
                check.Parameters.AddWithValue("@password", FieldPass.Text);
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

                SqlCommand comm = new SqlCommand("insert into users (login, password) " + "values (@login,@password)", conn);
                comm.Parameters.Add("@login", SqlDbType.NVarChar, 50).Value = FieldLogin.Text;
                comm.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = FieldPass.Text;
                conn.Open();
                comm.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Пользователь зарегистрирован");
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FieldLogin.Text == "" || FieldPass.Text == "")
            {
                MessageBox.Show("Недопустимое значение полей");
            }
            else
            {
                bool success = false;
                try
                {
                    const string comand = "Select * from Users WHERE login=@login AND password = @password";
                    SqlCommand check = new SqlCommand(comand, conn);
                    check.Parameters.AddWithValue("@login", FieldLogin.Text);
                    check.Parameters.AddWithValue("@password", FieldPass.Text);
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
                if (success)
                {
                    Form2 form2 = new Form2();
                    Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
                    
        }
        //установить ocalDb если не работает
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString=@"Data Source = (localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Base\MyDataBase.mdf;
                                      Initial Catalog = MyDataBase;
                                      Integrated Security = True;";
            conn.Open();
            conn.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Auth_Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void Auth_Form_Load(object sender, EventArgs e)
        {

        }

        private void Auth_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Up)
            {
                FieldLogin.Focus();
            }
            if(e.KeyCode==Keys.Down)
            {
                FieldPass.Focus();
            }
        }

        private void FieldLogin_Enter(object sender, EventArgs e)
        {
            FieldLogin.Focus();
        }

        private void FieldPass_Enter(object sender, EventArgs e)
        {
            FieldPass.Focus();
        }

    }
}
