using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Perius.Models.Repositories;
using Perius.Models.ViewModels;
using Perius.Models.ViewModels.Clientes;

namespace Perius.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeRepository _repositorio;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repositorio = new HomeRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarTablaEjemplo()
        {
            return PartialView("_TablaEjemplo");
        }

        //public JsonResult ObtenerTablaEjemplo(dynamic data)
        public JsonResult ObtenerTablaEjemplo()
        {
            List<ClienteViewModel> listaClientes = _repositorio.ObtenerClientes();
            return Json(new { draw = 1, recordsFiltered = listaClientes.Count(), recordsTotal = listaClientes.Count(), data = listaClientes });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}