using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Perius.Models.Repositories;
using Perius.Models.ViewModels;
using Perius.Models.ViewModels.Clientes;

namespace Perius.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeRepository Repositorio;

        public HomeController()
        {
            Repositorio = new HomeRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarTablaEjemplo()
        {
            return PartialView("_TablaEjemplo");
        }

        public JsonResult ObtenerTablaEjemplo()
        {
            List<ClienteViewModel>? listaClientes = Repositorio.ObtenerClientes();
            //TODO
            return Json(new { draw = 1, recordsFiltered = listaClientes.Count, recordsTotal = listaClientes.Count, data = listaClientes });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}