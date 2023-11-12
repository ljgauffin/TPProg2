using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabrica.Dominio;

namespace Dominio.Datos
{
    public interface IEstadoDao
    {
        List<Estado> ObtenerEstados();
    }
}
