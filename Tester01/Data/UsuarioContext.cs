using Microsoft.EntityFrameworkCore;
using Tester01.Models;

namespace Tester01.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Usuario>().ToTable("tb_usuario");
            model.Entity<Usuario>().Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            model.Entity<Usuario>().Property(x => x.Nome).HasColumnName("nome").IsRequired();
            model.Entity<Usuario>().Property(x => x.dataNascimento).HasColumnName("data_nascimento");
            
        }

    }
}
