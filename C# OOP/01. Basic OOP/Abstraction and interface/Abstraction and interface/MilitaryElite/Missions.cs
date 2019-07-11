using System;
using System.Collections.Generic;
using System.Text;


public class Missions
{
    private string codeName;
    private string state;

    public Missions(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string State
    {
        get { return state; }
        set
        {
            if (value == "inProgress" || value == "Finished")
            {
                state = value;
            }           
        }
    }

    public string CodeName
    {
        get { return codeName; }
        set { codeName = value; }
    }

    public void CompleteMission()
    {
        if (this.State == "inProgress")
        {
            this.State = "Finished";
        }
    }

    public override string ToString()
    {
        return $"Code Name: {this.codeName} State: {this.state}";
    }
}

