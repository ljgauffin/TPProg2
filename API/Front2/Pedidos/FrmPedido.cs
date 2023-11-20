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
        public FrmPedido(Pedido pedido)
        {
            this.pedido = pedido;
            InitializeComponent();
        }


        private void CargarEncabezado()
        {
            lblPedido.Text = pedido.Id.ToString();
            lblEstado.Text = pedido.Estado.ToString();
            dtpEntrega.Value = pedido.FechaEntrega;
            dtpPedido.Value = pedido.FechaPedido;
            txtNombre.Text = pedido.NombreCliente;
            txtCuit.Text = pedido.CuitCliente;
            txtCorreo.Text = pedido.CorreoCliente;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            CargarEncabezado();
            CargarDetalle();
        }

        private async void CargarDetalle()
        {
            //https://localhost:7133/Detalle?id=0

            string url = string.Format("https://localhost:7133/Detalle?id={0}", pedido.Id.ToString());
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<DetallePedido>>(result);
            dgvDetalle.Rows.Clear();
            if (lst != null)
            {
                foreach (DetallePedido detalle in lst)
                {
                    dgvDetalle.Rows.Add(new object[] {
                    detalle.Product.Nombre.ToString(),
                    detalle.Product.id,
                    detalle.Cantidad,
                    detalle.Precio,
                    detalle.Costo
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


    }
}
