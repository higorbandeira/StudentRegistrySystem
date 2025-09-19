using API.Models.enums;

namespace API.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IntendedSchoolYear { get; set; }
        public enumRegistrationStatus RegistrationStatus { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Guardian> Guardians { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public DirectorApproval DirectorApproval { get; set; }

        public Student()
        {
            Id = Guid.NewGuid();
            RegistrationDate = DateTime.UtcNow;
            RegistrationStatus = enumRegistrationStatus.Pending;
            Guardians = new List<Guardian>();
            Notifications = new List<Notification>();
        }

        public int CalculateAge(DateTime referenceDate)
        {
            var age = referenceDate.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > referenceDate.AddYears(-age))
                age--;

            return age;
        }

        public bool ValidateAgeForSchoolYear(DateTime schoolYearStartDate)
        {
            var age = CalculateAge(schoolYearStartDate);
            var expectedAge = IntendedSchoolYear + 5; // 1st year = 6 years, 2nd = 7, etc.

            return age == expectedAge;
        }
    }
}
