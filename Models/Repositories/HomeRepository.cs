using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Xml.Linq;
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
            string sortOrder = parametros.SortOrder;
            string search = parametros.Search.Value;
            // TODO FILTROS CUSTOM
            //string nombre = parametros.CustomParameters.Nombre.Value;

            ParametrosConsultaViewModel parametrosConsulta = new("dbo.ObtenerClientes");
            FuncionesDB.EjecutarStoredProcedure(parametrosConsulta);

            IQueryable<ClienteViewModel>? clientes = modelMaps.MapClientes(parametrosConsulta.Resultados)
                .Where(c => c.Nombre.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                            c.PrimerApellido.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                            c.SegundoApellido.Contains(search, StringComparison.OrdinalIgnoreCase))
                .OrderBy(sortOrder);

            return clientes.Skip(parametros.Start).Take(parametros.Length).ToList();
        }
    }
}