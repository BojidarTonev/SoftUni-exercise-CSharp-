using System;
using TorshiaWebApp.Models.Enums;

namespace TorshiaWebApp.Models
{
    public class Report
    {
        public string Id { get; set; }

        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public string TaskId { get; set; }
        public virtual Task Task { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
