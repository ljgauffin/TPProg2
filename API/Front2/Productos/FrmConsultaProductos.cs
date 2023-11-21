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

namespace Front2.Productos
{
    public partial class FrmConsultaProductos : Form
    {
        public FrmConsultaProductos()
        {
            InitializeComponent();

        }

        private void ConsultaProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            CargarProductos();
        }

   

        private async void CargarProductos()
        {
            string nombre = txtProducto.Text.ToString();
            string url = string.Format("https://localhost:7133/Producto?nombre={0}", nombre);
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Producto>>(result);
            dgvProductos.Rows.Clear();
            if (lst != null)
            {
                foreach (Producto producto in lst)
                {
                    dgvProductos.Rows.Add(new object[] {
                    producto.id,
                    producto.Nombre,
                    String.Format("{0:0.00}",producto.Precio),
                    String.Format("{0:0.00}",producto.Costo)
                    
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de productos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            new frmProducto(0, false).ShowDialog();
            CargarProductos();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvProductos.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dgvProductos.CurrentRow.Cells["id"].Value.ToString());
                
               
                new frmProducto(nro, true).ShowDialog();

            }
        }

        private void FrmConsultaProductos_Load(object sender, EventArgs e)
        {

            CargarProductos();
            dgvProductos.AllowUserToOrderColumns = true;

            //((DataGridViewButtonColumn)dgvProductos.Columns[4]).Text. = 
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            CargarProductos();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                btnConsultar.PerformClick();
            }
        }
    }
}
