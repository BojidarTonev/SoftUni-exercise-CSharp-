using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TorshiaWebApp.Data;
using TorshiaWebApp.Models;
using TorshiaWebApp.Models.Enums;
using TorshiaWebApp.Services.Contracts;

namespace TorshiaWebApp.Services
{
    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext _context;

        public ReportsService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Task> AllReportedTasks()
        {
            return this._context.Tasks.Include(r => r.Report).Where(t => t.IsReported == true);
        }

        public void ReportTask(Task task, User user)
        {
            Status status = Status.Archived;
            task.IsReported = true;
            int statusIndex = new Random().Next(0, 4);
            if (statusIndex % 4 == 0)
            {
                status = Status.Completed;
            }
            var report = new Report()
            {
                Task = task,
                ReportedOn = DateTime.UtcNow,
                Status = status
            };
            this._context.Update(task);
            this._context.Reports.Add(report);
            this._context.SaveChanges();
        }

        public Report Details(string id)
        {
            var report = this._context.Reports.Include(r => r.Task).Include(r => r.Task.AffectedSectors).FirstOrDefault(r => r.Id == id);

            return report;
        }

        public string GetReportEnums(string id)
        {
            var report = this._context.Reports.Include(r => r.Task).Include(r => r.Task.AffectedSectors).FirstOrDefault(r => r.Id == id);

            var result = "";
            foreach (var sector in report.Task.AffectedSectors)
            {
                var sectorInfo = this._context.Sectors.FirstOrDefault(s => s.Id == sector.SectorId);
                var sectorName = sectorInfo.Name.ToString();
                result += sectorName + " ";
            }

            result.TrimEnd();

            return result;
        }
    }
}
