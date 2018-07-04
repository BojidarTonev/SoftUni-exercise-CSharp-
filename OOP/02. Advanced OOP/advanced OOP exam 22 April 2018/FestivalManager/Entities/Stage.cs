using System.Linq;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
	    private List<ISet> sets { get; set; }

	    private List<ISong> songs { get; set; }

	    private List<IPerformer> performers { get; set; }

	    public Stage()
	    {
	        this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
	    }
		// да си вкарват през полетата бе
	    public IReadOnlyCollection<ISet> Sets => this.sets;

	    public IReadOnlyCollection<ISong> Songs => this.songs;

	    public IReadOnlyCollection<IPerformer> Performers => this.performers;

	    public IPerformer GetPerformer(string name)
	    {
	        return this.Performers.FirstOrDefault(p => p.Name == name);
	    }

	    public ISong GetSong(string name)
	    {
	        return this.Songs.FirstOrDefault(s => s.Name == name);
	    }

	    public ISet GetSet(string name)
	    {
	        return this.Sets.FirstOrDefault(s => s.Name == name);
	    }

	    public void AddPerformer(IPerformer performer)
	    {
	        List<IPerformer> newList = new List<IPerformer>(this.Performers);
            newList.Add(performer);
	        this.performers = newList;
	    }

	    public void AddSong(ISong song)
	    {
	        List<ISong> newList = new List<ISong>(this.Songs);
            newList.Add(song);
            this.songs = newList;
	    }

	    public void AddSet(ISet set)
	    {
	        List<ISet> newList = new List<ISet>(this.Sets);
            newList.Add(set);
	        this.sets = newList;
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.Performers.Any(p => p.Name == name);
	    }

	    public bool HasSong(string name)
	    {
	        return this.Songs.Any(s => s.Name == name);
	    }

	    public bool HasSet(string name)
	    {
	        return this.Sets.Any(s => s.Name == name);
	    }
	}
}
