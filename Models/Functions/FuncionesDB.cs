using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Perius.Models.ViewModels;
using System.Dynamic;

namespace Perius.Models.Functions
{
    public class FuncionesDB
    {
        public static SqlConnection ObtenerSqlConnection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            SqlConnection conexion = new(builder.Build().GetConnectionString("PeriusDatabase"));
            return conexion;
        }
        public static void EjecutarStoredProcedure(ParametrosConsultaViewModel parametrosConsulta)
        {
            using SqlConnection connection = ObtenerSqlConnection();
            SqlCommand comando = new(parametrosConsulta.Consulta, connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 300
            };

            SqlParameter? parametroOutput = new();

            if (parametrosConsulta.ParametrosEntrada != null)
            {
                comando.Parameters.Add("@ParametrosEntrada", SqlDbType.NVarChar, -1).Value = JsonConvert.SerializeObject(parametrosConsulta.ParametrosEntrada);
            };

            if (parametrosConsulta.ParametrosSalida != null)
            {
                parametroOutput = new("@ParametrosSalida", SqlDbType.NVarChar, -1)
                {
                    Direction = ParameterDirection.Output
                };

                comando.Parameters.Add(parametroOutput);
            }

            connection.Open();
            List<dynamic>? listaObjetoModelo = new();

            try
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    List<string> campos = new();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        campos.Add(reader.GetName(i));
                    }

                    while (reader.Read())
                    {
                        IDictionary<string, object> registro = new ExpandoObject();

                        for (int i = 0; i < campos.Count; i++)
                        {
                            registro.Add(campos[i], reader[campos[i]]);
                        };

                        listaObjetoModelo.Add(registro);
                    }
                };
            }
            catch
            {
                listaObjetoModelo = null;
            }

            parametrosConsulta.ParametrosSalida = parametroOutput.Value == DBNull.Value ? null : parametroOutput.Value;
            parametrosConsulta.Resultados = listaObjetoModelo;
            connection.Close();
        }
    }
}