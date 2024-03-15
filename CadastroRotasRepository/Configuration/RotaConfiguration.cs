using CadastroRotasDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroRotasRepository.Configuration
{
    public class RotaConfiguration : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("rota");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(a => a.Origem).HasColumnName("origem").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Destino).HasColumnName("destino").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Custo).HasColumnName("custo").HasColumnType("DECIMAL(18, 2)");
        }
    }
}
