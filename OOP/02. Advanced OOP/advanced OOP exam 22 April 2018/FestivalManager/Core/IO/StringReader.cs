using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	public class StringReader : IReader
	{
	    public string ReadLine()
	    {
	        return Console.ReadLine();
	    }
	}
}