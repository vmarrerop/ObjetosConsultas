using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ModelosConsultas.Models.DataModels
{
    public class MotivoConsultaModel
    {
        [Required]
        [Key]
        public int idPatientReasonOfVisit { get; set; }
        public string? reason { get; set; }
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
