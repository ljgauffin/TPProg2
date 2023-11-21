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
    public partial class FrmPedido : Form
    {
        Pedido pedido;
        bool noise = false;
        public FrmPedido(Pedido pedido)
        {
            this.pedido = pedido;
            InitializeComponent();
        }


        private void CargarEncabezado()
        {
            noise = true;
            lblPedido.Text = pedido.Id.ToString();
            cboEstados.SelectedItem = pedido.Estado;
            dtpEntrega.Value = pedido.FechaEntrega;
            dtpPedido.Value = pedido.FechaPedido;
            txtNombre.Text = pedido.NombreCliente;
            txtCuit.Text = pedido.CuitCliente;
            txtCorreo.Text = pedido.CorreoCliente;
            noise = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void FrmPedido_Load(object sender, EventArgs e)
        {
            await CargarCombo();
            CargarEncabezado();
             await CargarDetalle();
            lblCosto.Text = String.Format("{0:0.00}", pedido.TotalCosto());
            lblPrecio.Text = String.Format("{0:0.00}", pedido.TotalPrecio());
            this.Text = $"Pedido {pedido.Id}";
        }

        private async Task CargarCombo()
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
                noise = true;
                cboEstados.SelectedIndex = 0;
                noise = false;

            }
            else
            {
                MessageBox.Show("Sin datos de estados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task CargarDetalle()
        {
            //https://localhost:7133/Detalle?id=0

            string url = string.Format("https://localhost:7133/Detalle?id={0}", pedido.Id.ToString());
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<DetallePedido>>(result);
            pedido.Detalle = lst;
            dgvDetalle.Rows.Clear();
            if (lst != null)
            {
                foreach (DetallePedido detalle in lst)
                {
                    dgvDetalle.Rows.Add(new object[] {
                    detalle.Product.Nombre.ToString(),
                    detalle.Product.id,
                    detalle.Cantidad,
                    String.Format("{0:0.00}", detalle.Precio),
                    String.Format("{0:0.00}", detalle.Costo),
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de productos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async  void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (noise) return;
            
            if (MessageBox.Show("¿Seguro que desea modificar el estado del pedido?", "Cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ActualizarEstado();
            }
            else
            {
                noise = true;
                cboEstados.SelectedIndex = pedido.Estado.Id;
                noise = false;
            }
            
            
            
        }

        private async void ActualizarEstado()
        {
            Pedido nuevoPedido = pedido;
            nuevoPedido.Estado = (Estado)cboEstados.SelectedItem;

            string url = string.Format("https://localhost:7133/Pedido");
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 

            //prod.Imagen = "no seas culiao";

            string data = JsonConvert.SerializeObject(nuevoPedido).ToString();
            Response result = await ConsultaHelper.GetInstance().PutAsync(url, data);

            if (result.Ok)
            {
                pedido.Estado = nuevoPedido.Estado;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, no se realizó el cambio de estado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                noise = true;
                cboEstados.SelectedIndex = pedido.Estado.Id; 
                noise = false;
            }
        }
    }
}
