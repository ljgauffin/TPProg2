using Fabrica.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal interface IProductosServicios
    {
        List<Producto> ObtenerProductos(string nombre);
        //bool CrearOrden(OrdenProduccion equipo);
    }
}
