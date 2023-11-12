using Fabrica.Datos;
using Fabrica.Dominio;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Servicios
{
    internal class ProductosServicios : IProductosServicios
    {
        private ProductoDao productoDAO;

        public ProductosServicios()
        {
            this.productoDAO = new ProductoDao();
        }

        //public bool CrearOrden(OrdenProduccion equipo)
        //{
        //    return productoDAO.CrearOrden(equipo);
        //}

        public List<Producto> ObtenerProductos(string nombre)
        {
            return productoDAO.ObtenerProductos(nombre, null);
        }
    }
}
