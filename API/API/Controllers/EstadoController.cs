using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Fabrica.Datos;

using Fabrica.Dominio;
using System.Text.Json;
using Dominio.Datos;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : Controller
    {
        private IEstadoDao _estadoDao;
        public EstadoController()
        {
            _estadoDao = new EstadoDAO();
        }

        // GET: ComponenteController
        [HttpGet]
        public IEnumerable<Estado> GetProductos()
        {

            return _estadoDao.ObtenerEstados();
        }



    }
}

