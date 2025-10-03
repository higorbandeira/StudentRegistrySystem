using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Context.Configuration
{
    public class StudentGuardianConfiguration : IEntityTypeConfiguration<StudentGuardian>
    {
        public void Configure(EntityTypeBuilder<StudentGuardian> builder)
        {
            builder.ToTable("student_guardians", "school");

            builder.HasKey(sg => new { sg.StudentId, sg.GuardianId });

            builder.Property(sg => sg.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            builder.Property(sg => sg.GuardianId)
                .HasColumnName("guardian_id")
                .IsRequired();

            builder.Property(sg => sg.Relationship)
                .HasColumnName("relationship")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(sg => sg.IsPrimaryContact)
                .HasColumnName("is_primary_contact")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(sg => sg.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.HasOne(sg => sg.Student)
                .WithMany(s => s.StudentGuardians)
                .HasForeignKey(sg => sg.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sg => sg.Guardian)
                .WithMany(g => g.StudentGuardians)
                .HasForeignKey(sg => sg.GuardianId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
