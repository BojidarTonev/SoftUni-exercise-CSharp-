namespace FestivalManager
{
	using Core;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO.Contracts;
	using Entities;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();
            IReader reader = new Core.IO.StringReader();
		    IWriter writer = new Core.IO.StringWriter();
			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

			var engine = new Engine(festivalController, setController, reader, writer);

			engine.Run();
		}
	}
}