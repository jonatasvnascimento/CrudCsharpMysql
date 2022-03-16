using CrudCsharpMysql.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrudCsharpMysql.controller;

namespace CrudCsharpMysql.view
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();

            listviewContatos.View = View.Details;
            listviewContatos.LabelEdit = true;
            listviewContatos.AllowColumnReorder = true;
            listviewContatos.FullRowSelect = true;
            listviewContatos.GridLines = true;

            listviewContatos.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listviewContatos.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listviewContatos.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listviewContatos.Columns.Add("Telefone", 150, HorizontalAlignment.Left);
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            AgendaController agendaController = new AgendaController();
            agendaController.Insert(txtNome.Text, txtEmail.Text, txtTelefone.Text);
            //agendaController.Insert("teste", "teste@teste", "11 5621-3231");

            if (agendaController.sucessInsert == true)
            {
                MessageBox.Show("Cadastrado com sucesso", "Sucesso!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(agendaController.messageError, "Erro!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }


            #region
            //try
            //{
            //    conn = new MySqlConnection(ConnectDB.strConn);
            //    string xQueryInsert = $"INSERT INTO contatos (nome, email, telefone) values ('{txtNome.Text}','{txtEmail.Text}','{txtTelefone.Text}') ";

            //    MySqlCommand command = new MySqlCommand(xQueryInsert, conn);
            //    conn.Open();
            //    command.ExecuteReader();
            //    MessageBox.Show("Inserido com sucesso");
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show($"{ex}");
            //}
            //finally
            //{
            //    conn.Close();
            //}
            #endregion
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AgendaController agendaController = new AgendaController();
                MySqlDataReader reader = agendaController.Read(txtBuscar.Text);

                listviewContatos.Items.Clear();
                if (!agendaController.messageError.Equals(""))
                {
                    MessageBox.Show(agendaController.messageError, "Error!",
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
                };
                    var linha_listview = new ListViewItem(row);
                    listviewContatos.Items.Add(linha_listview);
                }
                ConnectDB.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }

            #region
            //try
            //{
            //    conn = new MySqlConnection(ConnectDB.strConn);
            //    string xQuerySelect = $"select * from openxcod.contatos where nome like '%{txtBuscar.Text}%' or email like '%{txtBuscar.Text}%' ";

            //    MySqlCommand command = new MySqlCommand(xQuerySelect, conn);
            //    conn.Open();
            //    MySqlDataReader reader = command.ExecuteReader();
            //    listviewContatos.Items.Clear();

            //    while (reader.Read())
            //    {
            //        string[] row =
            //        {
            //            reader.GetString(0),
            //            reader.GetString(1),
            //            reader.GetString(2),
            //            reader.GetString(3),
            //        };
            //        var linha_listview = new ListViewItem(row);
            //        listviewContatos.Items.Add(linha_listview);
            //    }
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show($"{ex}");
            //}
            //finally
            //{
            //    conn.Close();
            //}
            #endregion
        }

        private void listviewContatos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itens_selecionados = listviewContatos.SelectedItems;

            foreach (ListViewItem item in itens_selecionados)
            {
                txtNome.Text = item.SubItems[1].Text;
                txtTelefone.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
            }
        }
    }
}
