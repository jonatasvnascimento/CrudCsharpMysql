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
    public partial class frmPrincipal : Form
    {
        private Form frmAtivo;
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void FromShow(Form frm)
        {
            ActiveFormClose();
            frmAtivo = frm;
            frm.TopLevel = false;
            panelForm.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void ActiveFormClose()
        {
            if (frmAtivo != null) frmAtivo.Close();
        }

        private void ActiveButton(Button frmAtivo)
        {
            foreach (Control ctrl in panelPrincipal.Controls) ctrl.ForeColor = Color.White;
            frmAtivo.ForeColor = Color.Black;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveButton(btnHome);
            ActiveFormClose();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            ActiveButton(btnAgenda);
            FromShow(new frmAgenda());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ActiveButton(btnUsuarios);
            FromShow(new frmUsuarios());

        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            ActiveButton(btnProdutos);

        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            ActiveButton(btnConfiguracao);

        }


        private void btnSair_Click(object sender, EventArgs e)
        {
            ActiveButton(btnSair);
            ActiveFormClose();
            Application.Exit(); 

        }
    }
}
