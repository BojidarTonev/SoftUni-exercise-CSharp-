using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    public double WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public override string ToString()
    {
        double totalAmount = WorkHoursPerDay * 5;
        double result = WeekSalary / totalAmount;
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Week Salary: {WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {workHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {result:f2}");

        return sb.ToString();
    }
}