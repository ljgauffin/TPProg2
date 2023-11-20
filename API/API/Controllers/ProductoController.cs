using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Fabrica.Datos;

using Fabrica.Dominio;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private IProductoDao _productoDao;
        public ProductoController()
        {
            _productoDao = new ProductoDao();
        }

        // GET: ComponenteController
        [HttpGet]
        public IEnumerable<Producto> GetProductos(string? nombre = null, int? id = null)
        {
            
            return _productoDao.ObtenerProductos(nombre, id);
        }


        [HttpPost]
        //public JsonResult PostProducto([FromBody] JsonElement json)
        //{
        //    Console.WriteLine(json);
        //    return Json(json);
        //}

        public IActionResult PostProducto(Producto producto)
        {

            try
            {
                if (producto == null)
                {
                    return BadRequest("Datos de producto incorrectos!");
                }
                if (_productoDao.CrearProducto(producto))
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


        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id) {
            Console.WriteLine($"Se esta ejecutando delete {id}");
            try
            {
                if (id == null)
                {
                    return BadRequest("Datos de producto incorrectos!");
                }
                if (_productoDao.ElimitarProducto(id))
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


        [HttpPut]
        public IActionResult PutProducto(Producto producto)
        {
            try
            {
                if (producto == null)
                {
                    return BadRequest("Datos de producto incorrectos!");
                }
                if (_productoDao.ModificarProducto(producto))
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
