
using Fabrica.Http;
using Newtonsoft.Json;
using Fabrica.Dominio;

namespace Front
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dgvProductos.CurrentRow.Cells["id"].Value.ToString());
                new frmProducto(nro, true).ShowDialog();
                
            }
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
                    producto.Precio,
                    producto.Costo
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de productos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            CargarProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmProducto(0, false).ShowDialog();
            CargarProductos();
        }
    }
}
