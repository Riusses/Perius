using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}

