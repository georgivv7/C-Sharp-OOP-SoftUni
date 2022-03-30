internal class Track
{  
    private Weather weather;
    public Track(int lapsNumber, int trackLength)
    {
        LapsNumber = lapsNumber;
        TrackLength = trackLength;
        Weather = Weather.Sunny;
        CurrentLap = 0;
    }
    public int LapsNumber { get; }
    public int TrackLength { get; }
    public int CurrentLap { get; set; } 
    public Weather Weather 
    {
        get { return this.weather; }
        set { this.weather = value; }
    }
}