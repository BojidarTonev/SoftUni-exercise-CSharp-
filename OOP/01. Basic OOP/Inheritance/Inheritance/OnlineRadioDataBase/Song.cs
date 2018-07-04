using System;
using System.Collections.Generic;
using System.Text;


class Song
{
    private string songName;
    private string artistName;
    private int minutes;
    private int seconds;

    public Song(string songName, string artistName, int minutes, int seconds)
    {
        this.SongName = songName;
        this.ArtistName = artistName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            artistName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            seconds = value;
        }
    }

    public int CalculatingLength()
    {
        int timeMinutes = Minutes*60;
        int timeSeconds = Seconds;
        int allTime = timeSeconds + timeMinutes;
        if (allTime < 0 || allTime > 899)
        {
            throw new ArgumentException("Invalid song length.");
        }

        return allTime;
    }
}

