using System.Collections.Generic;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Services.Contracts;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            this._tasksService = tasksService;
        }

        [Authorize]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IHttpResponse Create(CreateTaskViewModel model)
        {
            var affectedSectors = new List<string>
            {
                model.Customers,
                model.Marketing,
                model.Finances,
                model.Internal,
                model.Management
            };

            _tasksService.CreateTask(model.Title, model.DueDate, model.Description, model.Participants, affectedSectors);

            return Redirect("/");
        }

        public IHttpResponse Details(string id)
        {
            var task = this._tasksService.TaskDetails(id);
            var affectedSectors = "";
            foreach (var sector in task.AffectedSectors)
            {
                affectedSectors += sector.ToString() + " ";
            }

            affectedSectors.TrimEnd();

            var dto = new TaskDetailsViewModel()
            {
                AffectedSectors = affectedSectors,
                Description = task.Description,
                DueData = task.DueDate.ToString(),
                Level = task.AffectedSectors.Count.ToString(),
                Participants = task.Participants.TrimEnd(),
                Title = task.Title
            };

            return this.View(dto);
        }
    }
}
