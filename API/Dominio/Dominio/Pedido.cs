using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string CuitCliente { get; set; }
        public string CorreoCLiente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Estado Estado { get; set; }

        public List<DetallePedido> MyProperty { get; set; }
    }
}
