using CrudCsharpMysql.model;
using CrudCsharpMysql.view;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrudCsharpMysql
{
    public partial class frmLogin1 : Form
    {
        public frmLogin1()
        {
            InitializeComponent();
        }

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister1().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool control = false;
            try
            {
                //txtUsername.Text = "admin";
                //txtPassword.Text = "123";
                MySqlConnection conn = new MySqlConnection(connectDB.strConn);

                string xQuerySelect = $"SELECT * FROM openxcod.usuarios where login = '{txtUsername.Text}' and senha = '{txtPassword.Text}' ";
                MySqlCommand command = new MySqlCommand(xQuerySelect, conn);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string user = reader.GetString(2);
                    string pass = reader.GetString(3);
                    control = true;
                    if (txtUsername.Text == user && txtPassword.Text == pass)
                    {
                        new frmAgenda().Show();
                        this.Hide();
                        control = true;
                    }
                    
                }
                if (control == false)
                {
                    MessageBox.Show("Usuario ou senha invalidos!");
                }
                conn.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex}");
            }


           
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
