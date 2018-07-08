using System;
using StudentSystem.Data.Configurations;

namespace P01_StudentSystem
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var db = new StudentConfiguration();
        }
    }
}
