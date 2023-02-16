using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace ModelosConsultas.Models.DataModels
{
    public class AntropometricosModel
    {
        [Required]
        [Key]
        public int idPatientAnthropometricData { get; set; }
        public float height { get; set; }
        public enum heightUnit
        {
            GRAM,
            KILOGRAM,
            POUND
        }
        public float weight { get; set; }
        public enum weightUnit
        {
            CENTIMETER,
            METER,
            INCH
        }
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
