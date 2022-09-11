namespace Perius.Models.Clientes
{
    public class DatoBancarioViewModel
    {
        public int IdDatosBancarios { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoPago { get; set; }
        public string? CuentaBancaria { get; set; }
        public int? TarjetaCredito { get; set; }
    }
}

