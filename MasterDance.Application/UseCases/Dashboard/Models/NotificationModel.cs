using System;

namespace MasterDance.Application.UseCases.Dashboard.Models
{
    public class NotificationModel
    {
        public int MemberId { get; set; }
        public string Member { get; set; }
        public string NotificationType { get; set; }
        public DateTime Date { get; set; }
        public int DaysDiff { get; set; }
    }
}