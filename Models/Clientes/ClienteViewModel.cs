namespace Perius.Models.Clientes
{
    public class ClienteViewModel 
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Documento { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}

