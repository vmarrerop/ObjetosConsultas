using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ModelosConsultas.Models.DataModels
{
    public class NotaConsultaModel
    {
        [Required]
        [Key]
        public int idPatientCheckupNote { get; set; }
        public string? comments { get; set; }
        public int idUserModifiedBy { get; set; }
        public enum status
        {
            ACTIVE,
            INACTIVE
        }
        public DateTime? createdOn { get; set; }
        public DateTime? modifiedOn { get; set; }

    }
}
