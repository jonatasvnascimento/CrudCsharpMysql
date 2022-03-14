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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            listviewUsers.View = View.Details;
            listviewUsers.LabelEdit = true;
            listviewUsers.AllowColumnReorder = true;
            listviewUsers.FullRowSelect = true;
            listviewUsers.GridLines = true;

            listviewUsers.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Name", 200, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Login", 100, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Pass", 100, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Email", 200, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Status", 100, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Access", 0, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Deleted", 100, HorizontalAlignment.Left);

            comboBox1.Items.Add("Ativo");
            comboBox1.Items.Add("Inativo");
            comboBox1.Items.Add("Bloqueado");


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                UserController userController = new UserController();
                MySqlDataReader reader = userController.Read(txtBuscar.Text);

                listviewUsers.Items.Clear();
                if (!userController.messageError.Equals(""))
                {
                    MessageBox.Show(userController.messageError, "Error!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }
                while (reader.Read())
                {
                    string[] row =
                    {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7),
                };
                    var linha_listview = new ListViewItem(row);
                    listviewUsers.Items.Add(linha_listview);
                }
                ConnectDB.closeConnection();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            string name = txtName.Text;
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string status = txtStatus.Text;
            string access = "";
            string deleted = "";
            userController.Insert(name, login, password, email, status, access, deleted);

            if (userController.sucessInsert == true)
            {
                MessageBox.Show("Cadastrado com sucesso", "Sucesso!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(userController.messageError, "Erro!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
        }
    }
}
