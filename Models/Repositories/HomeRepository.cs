﻿using Perius.Models.Functions;
using Perius.Models.ViewModels;
using Perius.Models.ViewModels.Clientes;
using Perius.Maps;

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
            ParametrosConsultaViewModel parametrosConsulta = new("dbo.ObtenerClientes", typeof(ClienteViewModel));
            FuncionesDB.EjecutarStoredProcedure(parametrosConsulta);
            List<ClienteViewModel> resultados = modelMaps.MapClientes(parametrosConsulta.Resultados);

            return resultados;
        }
    }
}