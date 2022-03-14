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
        private List<Pessoa> pLista;

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

            var acesso = new DataGridViewCheckBoxColumn();
            acesso.HeaderText = "C";
            acesso.Width = 50;
            acesso.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            acesso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(acesso);

            dataGridView1.DataSource = pLista;

            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[0].Cells["Chave"].Value = "001";
            //dataGridView1.Rows[0].Cells["Acesso"].Value = "Criação de Usuário";



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

        class Pessoa
        {
            public Pessoa()
            { }

            public Pessoa(int _id, string _nome, short _idade, char _sexo)
            {
                this.p_id = _id;
                this.p_nome = _nome;
                this.p_idade = _idade;
                this.p_sexo = _sexo;
            }

            private int p_id = -1;
            private string p_nome = String.Empty;
            private short p_idade = 0;
            private char? p_sexo = null;

            public int ID
            {
                get { return p_id; }
                set { p_id = value; }
            }

            public string Nome
            {
                get { return p_nome; }
                set { p_nome = value; }
            }

            public short Idade
            {
                get { return p_idade; }
                set { p_idade = value; }
            }

            public char? Sexo
            {
                get { return p_sexo; }
                set { p_sexo = value; }
            }
        }
        private void carregaLista()
        {
            pLista = new List<Pessoa>();
            pLista.Add(new Pessoa(1, "João", 29, 'M'));
            pLista.Add(new Pessoa(2, "Macoratti", 35, 'F'));
            pLista.Add(new Pessoa(3, "Americo", 25, 'M'));
            pLista.Add(new Pessoa(4, "Katia", 21, 'F'));
            pLista.Add(new Pessoa(5, "Lena", 33, 'F'));
            pLista.Add(new Pessoa(6, "Suzana", 45, 'F'));
            pLista.Add(new Pessoa(7, "Jim", 38, 'M'));
            pLista.Add(new Pessoa(8, "Jane", 32, 'F'));
            pLista.Add(new Pessoa(9, "Roberto", 31, 'M'));
            pLista.Add(new Pessoa(10, "Cintia", 25, 'F'));
            pLista.Add(new Pessoa(11, "Gina", 27, 'F'));
            pLista.Add(new Pessoa(12, "Joel", 33, 'M'));
            pLista.Add(new Pessoa(13, "Germano", 55, 'M'));
            pLista.Add(new Pessoa(14, "Ricardo", 22, 'M'));
            pLista.Add(new Pessoa(15, "Maria", 39, 'F'));
        }
    }
}
