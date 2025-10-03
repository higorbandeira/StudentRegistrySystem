using Domain.Models.enums;

namespace Domain.Models
{
    public class StudentGuardian
    {
        public Guid StudentId { get; set; }
        public Guid GuardianId { get; set; }
        public enumGuardianRelationship Relationship { get; set; }
        public bool IsPrimaryContact { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navegação
        public Student Student { get; set; }
        public Guardian Guardian { get; set; }

        public StudentGuardian()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
