using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TorshiaWebApp.Models.Enums;

namespace TorshiaWebApp.Models
{
    public class Task
    {
        public Task()
        {
            this.IsReported = false;
            this.AffectedSectors = new List<TaskSector>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsReported { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public virtual List<TaskSector> AffectedSectors { get; set; }

        [NotMapped]
        public int? ReportId { get; set; }

        public virtual Report Report { get; set; }
    }
}
