using System;
using Perius.Models.Functions;
using Perius.Models.ViewModels;
using Perius.Models.ViewModels.Clientes;
using Perius.Mapping;
using Perius.Models.Functions;

namespace Perius.Models.Repositories
{
    public class HomeRepository
    {
        public Maps mapper;

        public HomeRepository()
        {
            mapper = new Maps();
        }

        //public IQueryable<ClienteViewModel> ObtenerClientes(dynamic parametros)
        //public List<ClienteViewModel> ObtenerClientes(dynamic parametros)
        public List<ClienteViewModel> ObtenerClientes()
        {
            //string nombre = parametros.parametrosTabla["Nombre"];

            dynamic parametrosEntrada = new { };
            ParametrosConsultaViewModel parametrosConsulta = new("dbo.ObtenerClientes", typeof(ClienteViewModel), parametrosEntrada);
            FuncionesDB.EjecutarStoredProcedure(parametrosConsulta);

            // TODO: revisar el mapper
            List<ClienteViewModel> resultados = mapper.MappingClientes(parametrosConsulta.Resultados);

            return resultados;
        }
    }
}