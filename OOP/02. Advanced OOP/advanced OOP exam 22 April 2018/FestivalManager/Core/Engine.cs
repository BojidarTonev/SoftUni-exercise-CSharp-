
using System;
using System.Linq;
using FestivalManager.Core.IO;
using FestivalManager.Entities;

namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    private IReader chetаch;
	    private IWriter pisаch;

	    private IFestivalController festivalCоntroller;
	    private ISetController setCоntroller;

	    public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
	    {
	        this.chetаch = reader;
	        this.pisаch = writer;

	        this.festivalCоntroller = festivalController;
	        this.setCоntroller = setController;

	    }
		// дайгаз
		public void Run()
		{
			while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
			{
				var input = chetаch.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.pisаch.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.pisаch.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.pisаch.WriteLine("Results:");
			this.pisаch.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var chasti = input.Split(" ".ToCharArray().First());

			var purvoto = chasti.First();
			var parametri = chasti.Skip(1).ToArray();

			if (purvoto == "LetsRock")
			{
				var setovete = this.setCоntroller.PerformSets();
				return setovete;
			}

			var festivalcontrolfunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == purvoto);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { parametri });
			}
			catch (Exception up)
			{
				throw up.InnerException; // ha ha
			}

			return a;
		}
	}
}