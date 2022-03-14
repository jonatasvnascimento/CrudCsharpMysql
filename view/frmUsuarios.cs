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
            listviewUsers.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Login", 70, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Pass", 100, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Status", 50, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Access", 0, HorizontalAlignment.Left);
            listviewUsers.Columns.Add("Deleted", 60, HorizontalAlignment.Left);

            carregaLista();

            comboBoxStatus.Items.Add("Ativo");
            comboBoxStatus.Items.Add("Inativo");
            comboBoxStatus.Items.Add("Bloqueado");

           



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
            string status = Convert.ToString(comboBoxStatus.SelectedItem);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void carregaLista()
        {
            //cria um objeto DataTable
            DataTable dt = new DataTable();
            //inclui duas colunas no datatable definindo o seu tipo como booleano e string
            dt.Columns.Add("Estado", typeof(bool));
            dt.Columns.Add("Nome", typeof(string));
            //cria um array do tipo string com nomes
            string[] nomes = { "Macoratti", "Jefferson", "Janice", "Jessica", "Miriam" };
            //define um array com valores booleanos
            bool[] status = { true, true, false, false, false };
            //inclui linhas e valores no datatable
            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Estado"] = status[i];
                dr["Nome"] = nomes[i];
                dt.Rows.Add(dr);
            }
            //vincula os valores do datatable no DataGridView
            dataGridView1.DataSource = dt;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
