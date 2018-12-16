using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Services.Contracts
{
    public interface IReportsService
    {
        IEnumerable<Task> AllReportedTasks();

        void ReportTask(Task task, User user);

        Report Details(string id);

        string GetReportEnums(string id);
    }
}
