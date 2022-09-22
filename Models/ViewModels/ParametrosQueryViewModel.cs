namespace Perius.Models.ViewModels
{
    public class ParametrosConsultaViewModel
    {
        public ParametrosConsultaViewModel(string Consulta, dynamic? ParametrosEntrada = null, dynamic? ParametrosSalida = null)
        {
            this.Consulta = Consulta;
            this.ParametrosEntrada = ParametrosEntrada;
            this.ParametrosSalida = ParametrosSalida;
        }

        public string Consulta { get; set; }
        public dynamic? ParametrosEntrada { get; set; }
        public dynamic? ParametrosSalida { get; set; }
        public List<dynamic>? Resultados { get; set; }
    }
}
