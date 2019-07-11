using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CleansingCenter:Centers
{
    private string animalsRecievedFrom;

    public CleansingCenter(string name) 
        : base(name)
    {
    }

    public string AnimalsRecievedFrom
    {
        get { return animalsRecievedFrom; }
        set { animalsRecievedFrom = value; }
    }
}

