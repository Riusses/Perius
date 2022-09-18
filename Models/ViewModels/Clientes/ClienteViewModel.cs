using System.ComponentModel.DataAnnotations;

namespace Perius.Models.ViewModels.Clientes
{
    public class ClienteViewModel
    {
        [Display(Name = "idCliente")]
        public int IdCliente { get; set; }
        [Display(Name = "idTipoDocumento")]
        public int IdTipoDocumento { get; set; }
        [Display(Name = "nombre")]
        public string Nombre { get; set; }
        [Display(Name = "primerApellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "segundoApellido")]
        public string SegundoApellido { get; set; }
        [Display(Name = "documento")]
        public string Documento { get; set; }
        [Display(Name = "fechaAlta")]
        public DateTime FechaAlta { get; set; }
        [Display(Name = "fechaBaja")]
        public DateTime FechaBaja { get; set; }
        [Display(Name = "activo")]
        public bool Activo { get; set; }
    }
}

