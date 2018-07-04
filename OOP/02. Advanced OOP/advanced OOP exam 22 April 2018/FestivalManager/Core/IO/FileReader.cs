using System.IO;
using FestivalManager.Core.IO.Contracts;

// we might want to read from files idk lol ¯\_(ツ)_/¯
namespace FestivalManager.Core.IO
{
	using System.IO;

	public class FileReader : IReader
	{
		private readonly System.IO.StreamReader reader;

		public FileReader(string contents)
		{
			this.reader = new System.IO.StreamReader(new System.IO.FileStream(contents, FileMode.Open, FileAccess.Read & FileAccess.Write));
		}

		public string ReadLine() => this.reader.ReadLine();
	}
}