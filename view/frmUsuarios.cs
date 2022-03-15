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
        private int b;

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

            comboBoxStatus.Items.Add("Ativo");
            comboBoxStatus.Items.Add("Inativo");
            comboBoxStatus.Items.Add("Bloqueado");
            carregaLista();

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
        private void LineSelectedChechBox()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                bool cheked;
                bool.TryParse(dr.Cells[0].Value?.ToString() ,out cheked);
                if (cheked)
                {
                    MessageBox.Show("Linha " + dr.Index + " foi selecionada");
                }
            }
        }

        private void carregaLista()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mark", typeof(bool));
            dt.Columns.Add("Chave", typeof(string));
            dt.Columns.Add("Descrição", typeof(string));

            //cria um array do tipo string com nomes
            string[] nomes = { "Criação de Usuarios", "Adição de Notas" };
            string[] chaves = { "001", "002" };

            //bool[] status = { false, false, false, false, false };
            for (int i = 0; i < nomes.Length; i++)
            {
                DataRow dr = dt.NewRow();
                //dr["Estado"] = status[i];
                dr["Chave"] = chaves[i];
                dr["Descrição"] = nomes[i];
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;

        }
       
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtEmail.Text = "";
            txtLogin.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
        }

        private void dataGridView1_EnabledChanged(object sender, EventArgs e)
        {
        }
    }
}
