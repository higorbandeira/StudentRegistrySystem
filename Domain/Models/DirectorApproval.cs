using Domain.Models.enums;

namespace Domain.Models
{
    public class DirectorApproval
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public enumApprovalStatus Status { get; set; }
        public string Reason { get; set; }
        public string ResponsiblePerson { get; set; }

        public Student Student { get; set; }

        public DirectorApproval()
        {
            Id = Guid.NewGuid();
            RequestDate = DateTime.UtcNow;
            Status = enumApprovalStatus.Pending;
        }
    }
}
