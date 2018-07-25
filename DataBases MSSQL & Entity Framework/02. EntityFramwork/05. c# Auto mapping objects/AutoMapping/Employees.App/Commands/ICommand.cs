using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
