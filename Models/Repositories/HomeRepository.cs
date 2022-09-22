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

        public List<ClienteViewModel> ObtenerClientes()
        {
            ParametrosConsultaViewModel parametrosConsulta = new("dbo.ObtenerClientes");
            FuncionesDB.EjecutarStoredProcedure(parametrosConsulta);
            List<ClienteViewModel> resultados = modelMaps.MapClientes(parametrosConsulta.Resultados);

            return resultados;
        }
    }
}