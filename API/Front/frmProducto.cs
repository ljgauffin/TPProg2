using Fabrica.Dominio;
using Fabrica.Http;
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


namespace Front
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
        }

        private void frmProductocs_Load(object sender, EventArgs e)
        {
            if (editing)
            {

                this.Text = $"Editando producto {prodId}";
                CargarCombos();
            }
            else
            {
                this.Text = $"Crear nuevo";
            }


        }

        private async void CargarCombos()
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtNombre.Text)||string.IsNullOrEmpty(txtDescripcion.Text))//controla que se ingrese nombre y descripcion
            {
                MessageBox.Show("Complete el nombre y descripcion","advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

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
    }
}
