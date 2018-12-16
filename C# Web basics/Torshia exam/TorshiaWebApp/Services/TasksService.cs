using System;
using System.Collections.Generic;
using System.Linq;
using TorshiaWebApp.Data;
using TorshiaWebApp.Models;
using TorshiaWebApp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace TorshiaWebApp.Services
{
    public class TasksService : ITasksService
    {
        private readonly ApplicationDbContext context;

        public TasksService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Task> AllTasks => this.context.Tasks.Where(x => x.IsReported == false).ToList();

        public void CreateTask(string title, string dueDate, string description, string participants,
            List<string> selectedSectors)
        {

            DateTime.TryParse(dueDate, out DateTime date);

            var task = new Task
            {
                Title = title,
                DueDate = date,
                Description = description,
                Participants = participants

            };

            var taskSectors = new List<TaskSector>();
            foreach (var selectedSector in selectedSectors)
            {
                if (selectedSector != null)
                {
                    bool isValidSector = Enum.TryParse(typeof(Models.Enums.AffectedSectors), selectedSector,
                        out object sectorValue);

                    if (isValidSector)
                    {
                        var sector = new Sector { Name = (Models.Enums.AffectedSectors) sectorValue };
                        var taskSector = new TaskSector { Task = task, Sector = sector };
                        taskSectors.Add(taskSector);
                    }
                }
            }

            task.AffectedSectors.AddRange(taskSectors);

            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public Task TaskDetails(string id)
        {
            return this.context.Tasks.Include(t => t.AffectedSectors).Include(t => t.Report).FirstOrDefault(t => t.Id == id);
        }
    }
}

