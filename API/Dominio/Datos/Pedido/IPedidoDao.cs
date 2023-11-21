using Fabrica.Dominio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Datos
{
    public interface IPedidoDao
    {
        bool CambiarEstado(Pedido pedido);
        bool CrearPedido(Pedido pedido);
        List<DetallePedido> ObtenerDetalle(int id);
        List<Pedido> ObtenerPedidos(DateTime desde, DateTime hasta, int estadoId, int? id);
        //bool Obtener(Producto equipo);


    }
}
