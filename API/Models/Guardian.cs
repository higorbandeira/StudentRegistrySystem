namespace API.Models
{
    public class Guardian
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }

        public ICollection<Student> Students { get; set; }

        public Guardian()
        {
            Id = Guid.NewGuid();
            Students = new List<Student>();
        }
    }
}
