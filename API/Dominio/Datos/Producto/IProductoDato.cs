using Fabrica.Dominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Datos
{
    public interface IProductoDao
    {
        bool CrearProducto(Producto producto);
        bool ElimitarProducto(int producto);
        bool ModificarProducto(Producto producto);
        List<Producto> ObtenerProductos(string nombre, int? id);
        //bool Obtener(Producto equipo);


    }
}
