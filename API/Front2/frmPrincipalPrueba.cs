using Front2.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front2
{
    public partial class frmPrincipalPrueba : Form
    {
        public frmPrincipalPrueba()
        {
            InitializeComponent();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReporte form = new frmReporte();
            //form.TopLevel = false;
            //Controls.Add(form);
            //form.Show();

            frmReporte form = new frmReporte();

            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void frmPrincipalPrueba_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmConsultaProductos form = new FrmConsultaProductos();

            //form.MdiParent = this;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            //form.Show();
            ////new FrmConsultaProductos().ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmConsultaProductos form = new FrmConsultaProductos();

            //form.MdiParent = this;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            //form.Show();
            ////new FrmConsultaProductos().ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmPedidos form = new frmPedidos();

            //form.MdiParent = this;
            //form.FormBorderStyle = FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            //form.Show();
        }
    }
}
