using CrudCsharpMysql.controller;
using CrudCsharpMysql.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudCsharpMysql.view
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginController controle = new LoginController();
            //controle.access(txtUsername.Text, txtPassword.Text);
            controle.access("admin", "123");
            if (controle.messageError.Equals(""))
            {
                if (controle.haveLogin)
                {
                    new frmPrincipal().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario ou senha invalidos!");
                }
            }
            else
            {
                MessageBox.Show(controle.messageError);
            }
            

            #region
            //bool control = false;
            //try
            //{
            //    //txtUsername.Text = "admin";
            //    //txtPassword.Text = "123";
            //    MySqlConnection conn = new MySqlConnection(ConnectDB.strConn);

            //    string xQuerySelect = $"SELECT * FROM openxcod.usuarios where login = '{txtUsername.Text}' and senha = '{txtPassword.Text}' ";
            //    MySqlCommand command = new MySqlCommand(xQuerySelect, conn);
            //    conn.Open();
            //    MySqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        string user = reader.GetString(2);
            //        string pass = reader.GetString(3);
            //        control = true;
            //        if (txtUsername.Text == user && txtPassword.Text == pass)
            //        {
            //            new frmAgenda().Show();
            //            this.Hide();
            //            control = true;
            //        }

            //    }
            //    if (control == false)
            //    {
            //        MessageBox.Show("Usuario ou senha invalidos!");
            //    }
            //    conn.Close();

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show($"{ex}");
            //}
            #endregion
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
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

        private void lblCriarConta_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }
    }
}
