using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Perius.Models.ViewModels;

namespace Perius.Models.Functions
{
    public class FuncionesDB
    {
        public static SqlConnection ObtenerSqlConnection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configuration = builder.Build();

            SqlConnection connection = new(configuration.GetConnectionString("PeriusDatabase"));

            return connection;
        }

        public static void EjecutarStoredProcedure(ParametrosConsultaViewModel parametrosConsulta)
        {
            /* STORED PROCEDURE */
            string tipoConsulta = "EXEC ";

            using SqlConnection connection = ObtenerSqlConnection();

            SqlCommand command = new(tipoConsulta + parametrosConsulta.Consulta, connection);

            if (parametrosConsulta.ParametrosEntrada != null)
            {
                command.Parameters.Add("@ParametrosEntrada", SqlDbType.NVarChar, -1).Value = JsonConvert.SerializeObject(parametrosConsulta.ParametrosEntrada);
            }

            connection.Open();

            // REFORZAR CONTRA BUGS Y FORMALIZAR
            List<dynamic> listaObjetoModelo = new();
            try
            {
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object? objetoModelo = Activator.CreateInstance(parametrosConsulta.Modelo);
                    foreach (PropertyInfo prop in objetoModelo.GetType().GetProperties().Where<PropertyInfo>(prop => !Equals(reader[prop.Name], DBNull.Value)))
                    {
                        prop.SetValue(objetoModelo, reader[prop.Name], null);
                    }

                    listaObjetoModelo.Add(objetoModelo);
                }

                parametrosConsulta.Resultados = listaObjetoModelo;
            }
            catch
            {
                // TODO: EMITIR MENSAJE A TABLA INTERNA
            }

            connection.Close();
        }
    }
}