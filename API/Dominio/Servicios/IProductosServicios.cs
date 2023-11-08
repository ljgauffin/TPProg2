using Dominio;
using Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal interface IProductosServicios
    {
        List<Producto> ObtenerProductos();
        //bool CrearOrden(OrdenProduccion equipo);
    }
}
