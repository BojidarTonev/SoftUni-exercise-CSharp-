using System;
using System.Collections.Generic;
using System.Text;



public class Repair
{
    private string partName;
    private int hoursWorked;

    public Repair(string partName, int hoursWorked)
    {
        this.HoursWorked = hoursWorked;
        this.PartName = partName;
    }

    public int HoursWorked
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }


    public string PartName
    {
        get { return partName; }
        set { partName = value; }
    }

    public override string ToString()
    {
        return $"Part Name: {this.partName} Hours Worked: {this.hoursWorked}";
    }
}

