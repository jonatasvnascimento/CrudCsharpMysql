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
                string xQuery = $"INSERT INTO contatos (nome, email, telefone) values ('{txtNome.Text}','{txtEmail.Text}','{txtTelefone.Text}') ";

                MySqlCommand command = new MySqlCommand(xQuery, conn);

                conn.Open();
                command.ExecuteReader();
                MessageBox.Show("Inserido com sucesso");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                string xQuery = $"INSERT INTO contatos (nome, email, telefone) values ('{txtNome.Text}','{txtEmail.Text}','{txtTelefone.Text}') ";

                MySqlCommand command = new MySqlCommand(xQuery, conn);

                conn.Open();
                command.ExecuteReader();
                MessageBox.Show("Inserido com sucesso");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
