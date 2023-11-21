using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabrica.Dominio;
using System.Windows.Forms;
using Newtonsoft.Json;
using Fabrica.Front2.http;

namespace Front2.Productos
{
    public partial class frmProducto : Form
    {
        int prodId;
        bool editing;
        public frmProducto(int prod, bool editing)
        {
            this.prodId = prod;
            InitializeComponent();
            this.editing = editing;
            btnEliminar.Visible = editing;

        }

        private async void frmProducto_Load(object sender, EventArgs e)
        {
            if (editing)
            {
                await CargarCombos();
                this.Text = $"Modificar producto: {prodId}";
                
            }
            else
            {
                this.Text = $"Crear nuevo producto";
            }


        }

        private async Task CargarCombos()
        {

            string url = string.Format("https://localhost:7133/Producto?id={0}", prodId.ToString());
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 


            var result = await ConsultaHelper.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Producto>>(result);
            if (lst != null)
            {
                Producto prod = (Producto)lst[0];
                txtNumero.Text = prod.id.ToString();
                txtNombre.Text = prod.Nombre.ToString();
                txtDescripcion.Text = prod.Descripcion.ToString();
                nmcCosto.Value = (decimal)prod.Costo;
                nmcPrecio.Value = (decimal)prod.Precio;
            }
            else
            {
                MessageBox.Show("Sin datos", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text))//controla que se ingrese nombre y descripcion
            {
                MessageBox.Show("Complete el nombre y descripcion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            if(nmcCosto.Value>=nmcPrecio.Value)
            {
                MessageBox.Show("El precio debe ser mayor al costo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {



                Producto prod = new Producto()
                {
                    Nombre = txtNombre.Text.ToString(),
                    Descripcion = txtDescripcion.Text.ToString(),
                    Costo = (float)nmcCosto.Value,
                    Precio = (float)nmcPrecio.Value
                };

                if (editing)
                {
                    prod.id = prodId;
                    modficiarProducto(prod);
                }
                else
                {
                    crearProducto(prod);
                }
            }
        }

        private async void crearProducto(Producto prod)
        {
            string url = string.Format("https://localhost:7133/Producto");
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 

            //prod.Imagen = "no seas culiao";

            string data = JsonConvert.SerializeObject(prod).ToString();
            Response result = await ConsultaHelper.GetInstance().PostAsync(url, data);

            if (result.Ok)
            {
                MessageBox.Show("Producto creado con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void modficiarProducto(Producto prod)
        {
            string url = string.Format("https://localhost:7133/Producto");
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 

            //prod.Imagen = "no seas culiao";

            string data = JsonConvert.SerializeObject(prod).ToString();
            Response result = await ConsultaHelper.GetInstance().PutAsync(url, data);

            if (result.Ok)
            {
                MessageBox.Show("Producto modificado con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EliminarProducto(prodId);
        }

        private async void EliminarProducto(int prodId)
        {
            //TODO: modal de confirmacion
            string url = string.Format("https://localhost:7133/Producto/{0}", prodId);

            Response result = await ConsultaHelper.GetInstance().DeleteAsync(url);

            if (result.Ok)
            {
                MessageBox.Show("Producto eliminado con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
