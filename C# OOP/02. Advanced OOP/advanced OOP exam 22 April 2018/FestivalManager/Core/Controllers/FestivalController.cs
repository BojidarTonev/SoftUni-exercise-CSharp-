using FestivalManager.Entities;
using FestivalManager.Entities.Factories;

namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "hh\\:mm\\:ss";

        private readonly IStage stage;
        private readonly InstrumentFactory instrumentFactory;
        private readonly PerformerFactory performerFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));


            result += $"Festival length: {(int)totalFestivalLength.TotalMinutes:d2}:{(int)totalFestivalLength.Seconds:d2}\n";


            foreach (var set in this.stage.Sets)
            {
                if (set.GetType().Name == "Long")
                {
                    result += $"--{set.Name} ({(int)set.ActualDuration.TotalMinutes:d2}:{(int)set.ActualDuration.Seconds:d2}):\n";
                }
                else
                {
                    result += $"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):\n";
                }

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            SetFactory factory = new SetFactory();

            var insntace = factory.CreateSet(name, type);

            this.stage.AddSet(insntace);

            return $"Registered {type} set";
        } //checked

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var inputInstrumenti = args.Skip(2).ToArray();

            var instruments = inputInstrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        } //checked

        public string RegisterSong(string[] args) //checked
        {
            string name = args[0];
            var time = args[1].Split(':');
            int minutes = int.Parse(time[0]);
            int second = int.Parse(time[1]);
            TimeSpan duration = new TimeSpan(0, minutes, second);

            Song song = new Song(name, duration);

            this.stage.AddSong(song);

            return $"Registered song {name} ({duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {setName}";
        } //checked

        //  public string SongRegistration(string[] args)
        //{
        //	var songName = args[0];
        //	var setName = args[1];
        //
        //	if (!this.stage.HasSet(setName))
        //	{
        //		throw new InvalidOperationException("Invalid set provided");
        //	}
        //
        //	if (!this.stage.HasSong(songName))
        //	{
        //		throw new InvalidOperationException("Invalid song provided");
        //	}
        //
        //	var set = this.stage.GetSet(setName);
        //	var song = this.stage.GetSong(songName);
        //
        //	set.AddSong(song);
        //
        //	return $"Added {song} to {set.Name}";
        //}

        // Временно!!! Чтобы работало делаем срез на конец месяца

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        } //checked

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        } //checked
    }
}