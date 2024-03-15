using CadastroRotasDomain.Entities;
using CadastroRotasRepository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CadastroRotasRepository.Common
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Rota> Rotas { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new RotaConfiguration());           
        }

        //criar as migration 
        //Add-Migration Init-Project -Project CadastroRotasRepository -StartupProject CadastroRotasAPI -Context ApplicationDbContext

        // criar o banco e tabela 
        // Update-Database -Context ApplicationDbContext -Project CadastroRotasRepository -StartupProject CadastroRotasAPI
    }
}
