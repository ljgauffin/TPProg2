using Dominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public interface IProductoDato
    {
        List<Producto> ObtenerProductos();
        //bool Obtener(Producto equipo);


    }
}
