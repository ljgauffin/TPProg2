using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca;
using Produccion.Datos;
using Parcial2023.Datos;
using Produccion.Domino;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComponenteController : Controller
    {
        private IOrdenDao _ordenDao;
        public ComponenteController()
        {
            _ordenDao = new OrdenDAO();
        }

        // GET: ComponenteController
        [HttpGet]
        public IEnumerable<Componente> GetComponentes()
        {
            return _ordenDao.ObtenerComponentes();
        }

        //// GET: ComponenteController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ComponenteController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ComponenteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ComponenteController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ComponenteController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ComponenteController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ComponenteController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
