using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string CuitCliente { get; set; }
        public string CorreoCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Estado Estado { get; set; }

        public List<DetallePedido> Detalle { get; set; }

        public bool AgregarDetalle(DetallePedido detalleNuevo)
        {
            
            if (Detalle == null)
            {
                Detalle = new List<DetallePedido>();
            }

            foreach(DetallePedido detalle in Detalle)
            {
                if(detalle.Product.id== detalleNuevo.Product.id)
                {

                    return false;
                }
            }

            Detalle.Add(detalleNuevo);
            return true;
        }

        public void QuitarDetalle(int productoId)
        {
            var itemToRemove = Detalle.SingleOrDefault(r => r.Product.id == productoId);
            if (itemToRemove != null)
                Detalle.Remove(itemToRemove);
        }

        public float TotalCosto()
        {
            float total = 0;
            foreach(DetallePedido item in Detalle)
            {
                total += item.Costo * item.Cantidad;
            }
            return total;
        }
        public float TotalPrecio()
        {
            float total = 0;
            foreach (DetallePedido item in Detalle)
            {
                total += item.Precio * item.Cantidad;
            }
            return total;
        }

    }
}
