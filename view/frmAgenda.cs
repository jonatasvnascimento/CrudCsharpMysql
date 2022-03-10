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

namespace CrudCsharpMysql.view
{
    public partial class frmAgenda : Form
    {
        MySqlConnection conn;

        public frmAgenda()
        {
            InitializeComponent();

            listviewContatos.View = View.Details;
            listviewContatos.LabelEdit = true;
            listviewContatos.AllowColumnReorder = true;
            listviewContatos.FullRowSelect = true;
            listviewContatos.GridLines = true;

            listviewContatos.Columns.Add("ID",30 ,HorizontalAlignment.Left);
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
            try
            {
                conn = new MySqlConnection(connectDB.strConn);
                string xQueryInsert = $"INSERT INTO contatos (nome, email, telefone) values ('{txtNome.Text}','{txtEmail.Text}','{txtTelefone.Text}') ";

                MySqlCommand command = new MySqlCommand(xQueryInsert, conn);
                conn.Open();
                command.ExecuteReader();
                MessageBox.Show("Inserido com sucesso");
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(connectDB.strConn);
                string xQuerySelect = $"select * from openxcod.contatos where nome like '%{txtBuscar.Text}%' or email like '%{txtBuscar.Text}%' ";

                MySqlCommand command = new MySqlCommand(xQuerySelect, conn);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                listviewContatos.Items.Clear();

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
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
