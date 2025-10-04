using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Context.Configuration
{
    public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.ToTable("guardians", "school");

            // Chave Primária
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .IsRequired();

            // Propriedades
            builder.Property(g => g.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(g => g.Email)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(g => g.Phone)
                .HasColumnName("phone")
                .HasMaxLength(15)
                .HasColumnType("varchar(15)");

            // Relacionamento N:N com Student através da tabela de junção
            builder.HasMany(g => g.StudentGuardians)
                .WithOne(sg => sg.Guardian)
                .HasForeignKey(sg => sg.GuardianId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
