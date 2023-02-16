using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ModelosConsultas.Models.DataModels
{
    public class PadecimientoModel
    {
        [Required]
        [Key]
        public int idPatientSuffering { get; set; }
        public string? suffering { get; set; }
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
