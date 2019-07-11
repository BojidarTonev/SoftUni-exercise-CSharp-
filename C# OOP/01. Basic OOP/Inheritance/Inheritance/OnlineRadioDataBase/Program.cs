using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            try
            {                
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    var input = Console.ReadLine().Split(new char[]{ ';' , ':'}).ToArray();
                    if (input.Length == 4)
                    {
                        string artistName = input[0];
                        string songName = input[1];
                        int minutes = int.Parse(input[2]);
                        int seconds = int.Parse(input[3]);

                        Song song = new Song(songName, artistName, minutes, seconds);
                        songs.Add(song);
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid song.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }       
            
            int allTimeSeconds = 0;
            foreach (var song in songs)
            {
                allTimeSeconds += song.CalculatingLength();
            }
            TimeSpan res = TimeSpan.FromSeconds(allTimeSeconds);

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {res.Hours}h {res.Minutes}m {res.Seconds}s");
        }
    }
}
