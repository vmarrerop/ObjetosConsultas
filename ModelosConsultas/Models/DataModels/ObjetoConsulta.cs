using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ModelosConsultas.Models.DataModels
{
    public class ObjetoConsulta
    {
        [Required]
        [Key]
        public int idEvent { get; set; }
        public int idUser { get; set; }
        public int idPatienteFile { get; set; }
        public enum consultationType
        {
            INITIAL,
            FOLLOW_UP
        }
        public int idUserModifiedBy { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? modifiedOn { get; set; }
    }
}
