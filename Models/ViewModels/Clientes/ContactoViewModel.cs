namespace Perius.Models.ViewModels.Clientes
{
    public class TipoDireccionViewModel
    {
        public int IdContacto { get; set; }
        public int IdCliente { get; set; }
        public int? Prefijo { get; set; }
        public int? Movil { get; set; }
        public int? Fijo { get; set; }
        public string? CorreoElectronico { set; get; }
    }
}