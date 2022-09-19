using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Perius.ComponentModels.CustomAttributes;

namespace Perius.Models.ViewModels.Clientes
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Primer apellido")]
        public string PrimerApellido { get; set; }
        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        [DisplayName("Fecha alta")]
        public DateTime FechaAlta { get; set; }
        [DisplayName("Fecha baja")]
        public DateTime FechaBaja { get; set; }
        public bool Activo { get; set; }
        // Propiedades adicionales
        [SkipAditionalProperty]
        public string FechaAltaToString => FechaAlta != DateTime.MinValue ? FechaAlta.ToString("g") : string.Empty;
        [SkipAditionalProperty]
        public string FechaBajaToString => FechaBaja != DateTime.MinValue ? FechaBaja.ToString("g") : string.Empty;
    }
}

