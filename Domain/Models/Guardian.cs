using Domain.Models;

namespace Domain.Models
{
    public class Guardian
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<StudentGuardian> StudentGuardians { get; set; }
    }
}
