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

        public JsonResult ObtenerTablaEjemplo([FromBody] DTParameters parametros)
        {
            List<ClienteViewModel> listaClientes = Repositorio.ObtenerClientes(parametros);

            DTParameters resultado = new()
            {
                Draw = parametros.Draw,
                Data = listaClientes,
                RecordsFiltered = listaClientes.Count,
                RecordsTotal = listaClientes.Count

            };

            return Json(resultado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}