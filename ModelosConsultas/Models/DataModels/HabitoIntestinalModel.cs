using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ModelosConsultas.Models.DataModels
{
    public class HabitoIntestinalModel
    {
        [Required]
        [Key]
        public int idPatientBowelHabit { get; set; }
        public string? description { get; set; }
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
