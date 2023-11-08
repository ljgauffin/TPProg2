using Datos;
using Dominio;
using Domino;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2023.Servicios
{
    internal class ProductosServicios : IProductosServicios
    {
        private ProductoDAO productoDAO;

        public ProductosServicios()
        {
            this.productoDAO = new ProductoDAO();
        }

        //public bool CrearOrden(OrdenProduccion equipo)
        //{
        //    return productoDAO.CrearOrden(equipo);
        //}

        public List<Producto> ObtenerProductos()
        {
            return productoDAO.ObtenerProductos();
        }
    }
}
