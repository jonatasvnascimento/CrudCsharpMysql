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
    public partial class frmLogin : Form
    {
        public frmLogin()
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
            new frmRegister().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(connectDB.strConn);

            //try
            //{
            //    conn.Open();
            //    string xQuery = "select * from actor limit 1";
            //    var cmd = new MySqlCommand(xQuery, conn);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erro: {ex}");
            //}
            //finally
            //{
            //    conn.Close();
            //}

            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                new frmAgenda().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("não logado");
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
