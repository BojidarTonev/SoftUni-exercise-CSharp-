using System.Linq;
using SIS.HTTP.Responses;
using TorshiaWebApp.Services.Contracts;
using TorshiaWebApp.ViewModels.Reports;

namespace TorshiaWebApp.Controllers
{
    public class ReportsController : BaseController
    {
        private readonly IReportsService _reportsService;
        private readonly ITasksService _tasksService;

        public ReportsController(IReportsService reportsService, ITasksService tasksService)
        {
            this._reportsService = reportsService;
            this._tasksService = tasksService;
        }

        public IHttpResponse All()
        {
            var reports = this._reportsService.AllReportedTasks().ToList();
            var reportsDto = reports.Select(r => new ReportViewModel()
            {
                Level = r.AffectedSectors.Count.ToString(),
                Status = r.Report.Status.ToString(),
                TaskId = r.Id,
                TaskName = r.Title,
                ReportId = r.Report.Id
            }).ToList();

            var dto = new ReportsViewModelCollection()
            {
                AllReports = reportsDto
            };

            return this.View(dto);
        }

        public IHttpResponse Create(string id)
        {
            var task = this._tasksService.TaskDetails(id);
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);
            this._reportsService.ReportTask(task, user);

            
            return this.Redirect("/");

        }

        public IHttpResponse Details(string id)
        {
            var report = this._reportsService.Details(id);
            var affectedSectors = this._reportsService.GetReportEnums(id);
            
            var dto = new ReportsDetailsViewModel()
            {
                Id = report.Id,
                Status = report.Status.ToString(),
                TaskAffectedSectors = affectedSectors,
                TaskDescription = report.Task.Description,
                TaskLevel = report.Task.AffectedSectors.Count.ToString(),
                TaskParticipants = report.Task.Participants,
                TaskTitle = report.Task.Title
            };

            return this.View(dto);
        }
    }
}
