using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using Perius.Maps;
using Perius.Models.Functions;
using Perius.Models.ViewModels;
using Perius.Models.ViewModels.Clientes;

namespace Perius.Models.Repositories
{
    public class HomeRepository
    {
        public ModelMaps modelMaps;

        public HomeRepository()
        {
            modelMaps = new ModelMaps();
        }

        public List<ClienteViewModel> ObtenerClientes(DTParameters parametros)
        {
            //string sortOrder = parametros.SortOrder;
            //string nombre = parametros.CustomParameters.Nombre.Value;

            ParametrosConsultaViewModel parametrosConsulta = new("dbo.ObtenerClientes");
            FuncionesDB.EjecutarStoredProcedure(parametrosConsulta);
            IQueryable<ClienteViewModel>? clientes = modelMaps.MapClientes(parametrosConsulta.Resultados).OrderBy("Nombre desc");

            return clientes.Skip(parametros.Start).Take(parametros.Length).ToList();
        }
    }
}