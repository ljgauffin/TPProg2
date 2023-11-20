using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Fabrica.Datos;

using Fabrica.Dominio;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private IPedidoDao _pedidoDao;
        public PedidoController()
        {
            _pedidoDao = new PedidoDao();
        }

        // GET: ComponenteController
        [HttpGet]
        public IEnumerable<Pedido> GetPedidos(DateTime desde, DateTime hasta, int estadoId, int? id = null)
        {
            Console.WriteLine($"Consultando pedidos desde :{desde} - Hasta: {hasta} - estadoId: {estadoId} - id: {id}");
            return _pedidoDao.ObtenerPedidos(desde, hasta, estadoId, id);
        }

        [HttpGet("/Detalle")]
        public IEnumerable<DetallePedido> GetDetalle(int id )
        {

            return _pedidoDao.ObtenerDetalle( id);
        }

        [HttpPost]
        //public JsonResult PostPresupuesto([FromBody] JsonElement json)
        //{
        //    Console.WriteLine(json);
        //    return Json(json);
        //}
        public IActionResult PostPresupuesto(Pedido pedido)
        {
            try
            {
                if (pedido == null)
                {
                    return BadRequest("Datos de producto incorrectos!");
                }
                if (_pedidoDao.CrearPedido(pedido))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "Error interno! Intente luego");
                }




            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
