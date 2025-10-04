using Domain.Models.enums;

namespace Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public enumNotificationType Type { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public enumNotificationStatus Status { get; set; }
        public enumNotificationChannel Channel { get; set; }

        public Guardian Recipient { get; set; }
        public Student Student { get; set; }
    }
}
