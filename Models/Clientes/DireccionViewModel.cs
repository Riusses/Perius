namespace Perius.Models.Clientes
{
    public class DireccionViewModel
    {
        public int IdDireccion { get; set; }
        public int IdTipoDireccion { set; get; }
        public int IdCliente { set; get; }
        public int IdCodigoPostal { set; get; }
        public string? Direccion { set; get; }
    }
}