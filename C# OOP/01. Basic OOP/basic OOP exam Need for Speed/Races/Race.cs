using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;
    public bool hasStarted;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
        this.hasStarted = false;
    }

    public List<Car> Participants
    {
        get { return participants; }
        protected set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        protected set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        protected set { route = value; }
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

   
}

