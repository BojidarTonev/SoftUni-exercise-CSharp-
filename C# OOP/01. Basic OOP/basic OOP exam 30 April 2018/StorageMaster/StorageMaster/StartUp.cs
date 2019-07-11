using System;
using StorageMaster.Controllers;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
