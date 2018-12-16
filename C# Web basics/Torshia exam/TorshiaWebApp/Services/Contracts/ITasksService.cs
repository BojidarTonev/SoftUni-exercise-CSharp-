using System.Collections.Generic;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Services.Contracts
{
    public interface ITasksService
    {
        IEnumerable<Task> AllTasks { get; }

        void CreateTask(string title, string dateTime, string description, string participants, List<string> affectedSectors);

        Task TaskDetails(string id);
    }
}
