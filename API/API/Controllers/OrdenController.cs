using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fabrica.Datos;
using Fabrica.Dominio;

namespace Fabrica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenController : Controller
    {
        //    private IOrdenDao ordenDAO;
        //    public OrdenController()
        //    {
        //        ordenDAO = new OrdenDAO();
        //    }
        //    [HttpPost]
        //    public IActionResult Post([FromBody] OrdenProduccion orden)
        //    {
        //        if (orden == null)
        //        {
        //            return BadRequest();
        //        }
        //        //TODO se debe validar los campos
        //        if(ordenDAO == null)
        //        {
        //            return StatusCode(500);
        //        }

        //        if (ordenDAO.CrearOrden(orden))
        //        {
        //            return Ok();
        //        }

        //        return StatusCode(500);
        //    }
    }

}