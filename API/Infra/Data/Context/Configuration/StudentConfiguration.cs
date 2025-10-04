using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Context.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "school");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(s => s.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.DateOfBirth)
                .HasColumnName("date_of_birth")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(s => s.IntendedSchoolYear)
                .HasColumnName("intended_school_year")
                .IsRequired();

            builder.Property(s => s.RegistrationStatus)
                .HasColumnName("registration_status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.RegistrationDate)
                .HasColumnName("registration_date")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            // Relacionamento N:N com Guardian através da tabela de junção
            builder.HasMany(s => s.StudentGuardians)
                .WithOne(sg => sg.Student)
                .HasForeignKey(sg => sg.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:1 com DirectorApproval
            builder.HasOne(s => s.DirectorApproval)
                .WithOne(da => da.Student)
                .HasForeignKey<DirectorApproval>("student_id")
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N com Notification
            builder.HasMany(s => s.Notifications)
                .WithOne()
                .HasForeignKey("student_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
