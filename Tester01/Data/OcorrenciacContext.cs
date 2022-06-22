using Microsoft.EntityFrameworkCore;

namespace seCuidaBenca.Data
{
    public class OcorrenciaContext : DbContext
    {
        public OcorrenciaContext(DbContextOptions<OcorrenciaContext> options) : base(options)
        {
        }

        public DbSet<Ocorrencia> Ocorrencia { get; set; }
    }
}
