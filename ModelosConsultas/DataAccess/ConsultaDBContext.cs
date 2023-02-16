using Microsoft.EntityFrameworkCore;
using ModelosConsultas.Models.DataModels;

namespace ModelosConsultas.DataAccess
{
    public class ConsultaDBContext: DbContext
    {
        public ConsultaDBContext(DbContextOptions<ConsultaDBContext> options): base(options) 
        {

        }

        //TO DO: Add DbSets (Tables of our Data Base)
        public DbSet<ObjetoConsulta>? Consultas { get; set; }
        public DbSet<AntropometricosModel>? Antropometricos { get; set; }
        public DbSet<HabitoIntestinalModel>? Habito { get; set; }
        public DbSet<MotivoConsultaModel>? Motivo { get; set; }
        public DbSet<NotaConsultaModel>? Nota { get; set; }
        public DbSet<PadecimientoModel>? Padecimiento { get; set; }



    }
}
