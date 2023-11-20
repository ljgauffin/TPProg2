using Fabrica.Dominio;
using Fabrica.Front2.http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front2.Pedidos
{
    public partial class FrmConsultaPedidos : Form
    {
        public FrmConsultaPedidos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void FrmConsultaPedidos_Load(object sender, EventArgs e)
        {
            cargarCombo();
            setDefaultDate();

        }

        private async void cargarCombo()
        {

            string url = string.Format("https://localhost:7133/Estado");


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Estado>>(result);
            cboEstados.Items.Clear();
            if (lst != null)
            {
                foreach (Estado estado in lst)
                {
                    cboEstados.Items.Add(estado);
                }
                //cboEstados.DataSource = lst;
                //cboEstados.DisplayMember = "Nombre";
                //cboEstados.ValueMember = "Id";
                cboEstados.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Sin datos de estados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            consultarPedidos();
        }

        private async void consultarPedidos()
        {

            //DateTime desde = dtpDesde.Value.Date;
            //DateTime hasta = dtpHasta.Value.Date;

            string desde = dtpDesde.Value.Date.ToString("O");
            string hasta = dtpHasta.Value.Date.ToString("O");
            int estadoId = ((Estado)cboEstados.SelectedItem).Id;


            string url = string.Format("https://localhost:7133/Pedido?desde={0}&hasta={1}&estadoId={2}", desde, hasta, estadoId);
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 

            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Pedido>>(result);
            dgvPedidos.Rows.Clear();
            if (lst != null)
            {
                foreach (Pedido pedido in lst)
                {
                    dgvPedidos.Rows.Add(new object[] {
                    pedido.Id,
                    pedido.NombreCliente,
                    pedido.CuitCliente,
                    pedido.CorreoCliente,
                    pedido.FechaPedido,
                    pedido.Estado.Id,
                    pedido.FechaEntrega,
                    pedido.Estado.Nombre
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de pedidos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarConsulta();
        }

        private void limpiarConsulta()
        {
            dgvPedidos.Rows.Clear();
            setDefaultDate();
            cboEstados.SelectedIndex = 0;
        }

        private void setDefaultDate()
        {
            dtpDesde.Value = System.DateTime.Now.AddDays(-1);
            dtpHasta.Value = System.DateTime.Now.AddMonths(1);

        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvPedidos.CurrentCell.ColumnIndex == 8)
            {
                Pedido pedido = new Pedido()
                {
                    Id = int.Parse(dgvPedidos.CurrentRow.Cells[0].Value.ToString()),
                    NombreCliente = (dgvPedidos.CurrentRow.Cells[1].Value.ToString()),
                    CuitCliente = (dgvPedidos.CurrentRow.Cells[2].Value.ToString()),
                    CorreoCliente = (dgvPedidos.CurrentRow.Cells[3].Value.ToString()),
                    FechaPedido = Convert.ToDateTime(dgvPedidos.CurrentRow.Cells[4].Value.ToString()),

                    FechaEntrega = Convert.ToDateTime(dgvPedidos.CurrentRow.Cells[6].Value.ToString()),

                    Estado = new Estado() { Id = int.Parse(dgvPedidos.CurrentRow.Cells[5].Value.ToString()), Nombre = dgvPedidos.CurrentRow.Cells[7].Value.ToString() }



                    //dgvPedidos.Rows.Add(new object[] {
                    //pedido.Id,
                    //pedido.NombreCliente,
                    //pedido.CuitCliente,
                    //pedido.CorreoCliente,
                    //pedido.FechaPedido,
                    //pedido.Estado.Id,
                    //pedido.FechaEntrega,
                    //pedido.Estado.Nombre
                    //});

                };


                new FrmPedido(pedido).ShowDialog();

            }
        }

        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            new FrmAltaPedido().ShowDialog();
        }


    }
}
