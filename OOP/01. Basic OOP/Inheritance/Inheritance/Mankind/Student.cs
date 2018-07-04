using System;
using System.Collections.Generic;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            foreach (var c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber)
    :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Faculty number: {facultyNumber}");

        return sb.ToString();
    }
}

