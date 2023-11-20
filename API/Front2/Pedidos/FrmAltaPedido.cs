using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fabrica.Dominio;
using Fabrica.Front2.http;
using Newtonsoft.Json;

namespace Front2.Pedidos
{
    public partial class FrmAltaPedido : Form
    {
        Pedido pedido;
        public FrmAltaPedido()
        {
            InitializeComponent();
            pedido = new Pedido()
            {
                Estado = new Estado() { Id = 0, Nombre = "Pendiente" }
            };
        }

        private void FrmAltaPedido_Load_1(object sender, EventArgs e)
        {
            CargarCombo();

        }

        private async void CargarCombo()
        {

            string url = string.Format("https://localhost:7133/Producto?nombre");
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Producto>>(result);
            cboProducto.Items.Clear();
            if (lst != null)
            {
                foreach (Producto producto in lst)
                {
                    cboProducto.Items.Add(producto);
                }

                cboProducto.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Sin datos de productos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            Producto prod = cboProducto.SelectedItem as Producto;
            DetallePedido detalle = new DetallePedido()
            {
                Cantidad = Convert.ToInt32(nmcCantifad.Value),
                Precio = prod.Precio,
                Costo = prod.Costo,
                Product = prod
            };

            AgregarDetalle(detalle);
        }

        private void AgregarDetalle(DetallePedido detalle)
        {
            if (pedido.AgregarDetalle(detalle))
            {
                ActualizarDetalles();
            }
            else
            {
                MessageBox.Show("Producto ya agregado, elimine el existente para modificar cantidad", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void ActualizarDetalles()
        {
            dgvDetalle.Rows.Clear();
            foreach (DetallePedido detalle in pedido.Detalle)
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

        private void dgvDetalle_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDetalle.CurrentCell.ColumnIndex == 5)
            {
                int productoId = int.Parse(dgvDetalle.CurrentRow.Cells["productoId"].Value.ToString());
                QuitarDetalle(productoId);

            }
        }

        private void QuitarDetalle(int productoId)
        {
            pedido.QuitarDetalle(productoId);
            ActualizarDetalles();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            //TODO: validar fecha posterior a la actual
            //TODO: validar al menos un detalle
            pedido.FechaEntrega = dtpEntrega.Value;
            pedido.NombreCliente = txtNombre.Text;
            pedido.CuitCliente = txtCuit.Text;
            pedido.CorreoCliente = txtCorreo.Text;

            CrearPedido(pedido);
        }

        private async void CrearPedido(Pedido pedido)
        {
            string url = string.Format("https://localhost:7133/Pedido");


            string data = JsonConvert.SerializeObject(pedido).ToString();
            Response result = await ConsultaHelper.GetInstance().PostAsync(url, data);

            if (result.Ok)
            {
                MessageBox.Show("Pedido creado con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
