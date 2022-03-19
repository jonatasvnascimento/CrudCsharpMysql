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
        private readonly int b;
        public string aux = "";
        List<string> ContainsAccessKey = new();
        List<string> NotContainsAccessKey = new();
        private int? IdContatoSelecionado = null;
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
            CarregarDados();

        }

        public void CarregarDados()
        {
            try
            {
                UserController userController = new();
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtLogin.Text == "" && txtPassword.Text == "" && txtEmail.Text == "" && comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Campos devem ser preenchidos", "Alerta!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            UserController userController = new();
            string name = txtName.Text;
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string status = Convert.ToString(comboBoxStatus.SelectedItem);
            string access = "";
            string deleted = "";
            int id = 0;
            if (IdContatoSelecionado != null)
            {
                id = (int)IdContatoSelecionado;
            }
            userController.Insert(name, login, password, email, status, access, deleted, id);

            if (userController.sucessInsert == true && id == 0)
            {
                MessageBox.Show("Cadastrado com sucesso", "Sucesso!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else if (userController.sucessInsert == true && id != 0)
            {
                MessageBox.Show("Atualizado com sucesso", "Sucesso!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(userController.messageError, "Erro!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }

            txtBuscar.Text = "";
            txtEmail.Text = "";
            txtLogin.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            comboBoxStatus.SelectedItem = null;
            CarregarDados();
        }
        private void LineSelectedChechBox()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                bool cheked;
                bool.TryParse(dr.Cells[0].Value?.ToString(), out cheked);
                if (cheked)
                {
                    if (!ContainsAccessKey.Contains("-" + dr.Cells["Chave"].Value.ToString()))
                    {
                        aux = "-" + dr.Cells["Chave"].Value.ToString();
                        ContainsAccessKey.Add(aux);
                        for (int i = 0; i < ContainsAccessKey.Count(); i++)
                        {
                            MessageBox.Show($"Contens: {ContainsAccessKey[i]}");
                        }
                    }

                }
                if (cheked == false)
                {
                    NotContainsAccessKey.Add(dr.Cells["Chave"].Value?.ToString());
                    foreach (var item in NotContainsAccessKey)
                    {
                        if (ContainsAccessKey.Contains(item))
                        {
                            ContainsAccessKey.Remove(item);
                        }

                    }

                }
            }

        }

        private void carregaLista()
        {
            DataTable dt = new();

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

        private void listviewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itens_selecionados = listviewUsers.SelectedItems;

            foreach (ListViewItem item in itens_selecionados)
            {
                IdContatoSelecionado = Convert.ToInt32(item.SubItems[0].Text);
                txtName.Text = item.SubItems[1].Text;
                txtLogin.Text = item.SubItems[2].Text;
                txtPassword.Text = item.SubItems[3].Text;
                txtEmail.Text = item.SubItems[4].Text;
                switch (item.SubItems[5].Text)
                {
                    case "A":
                        comboBoxStatus.Text = "Ativo";
                        break;
                    case "I":
                        comboBoxStatus.Text = "Inativo";
                        break;
                    case "B":
                        comboBoxStatus.Text = "Bloqueado";
                        break;
                    default:
                        comboBoxStatus.Text = "";
                        break;
                }

            }
        }
    }
}
