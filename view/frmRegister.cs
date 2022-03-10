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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void checkbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtComPassword.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void lblVoltarLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
