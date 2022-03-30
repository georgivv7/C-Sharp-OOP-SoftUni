using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Song
{
    private string artist;
    private string song;
    private int minutes;
    private int seconds;
    public Song(string[] tokens)
    {
        ValidateArgs(tokens);
        this.Artist = tokens[0];
        this.SongName = tokens[1];
        int[] lenghtArgs = ValidateLength(tokens[2]);
        this.Minutes = lenghtArgs[0];
        this.Seconds = lenghtArgs[1];
    }

    public string Artist
    {
        get { return this.artist; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artist = value;
        }
    }
    public string SongName
    {
        get { return song; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            this.song = value;
        }
    }
    public int Minutes
    {
        get { return this.minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }
    public int Seconds
    {
        get { return this.seconds; }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }
    private void ValidateArgs(string[] tokens)
    {
        if (tokens.Length != 3)
        {
            throw new InvalidSongException();
        }
    }

    private int[] ValidateLength(string length)
    {
        var tokens = length.Split(':');
        if (tokens.Length == 2 && tokens.Any(t => t.All(x => char.IsDigit(x))))
        {
            return tokens.Select(int.Parse).ToArray();
        }
        else
        {
            throw new InvalidSongLengthException();
        }

    }
    public int GetLengthInSeconds()
    {
        return this.Minutes * 60 + this.Seconds;
    }
}
