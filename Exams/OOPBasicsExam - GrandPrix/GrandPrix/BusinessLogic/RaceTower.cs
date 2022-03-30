using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const string crashReason = "Crashed";
    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private Track track;

    public RaceTower()
    {
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
    }
    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;
    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string name = commandArgs[1];

            int horsePower = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();
            Tyre tyre = tyreFactory.CreateTyre(tyreArgs);

            Car car = new Car(horsePower, fuelAmount, tyre);

            Driver driver = driverFactory.CreateDriver(driverType, name, car);

            racingDrivers.Add(driver);
        }
        catch { }

    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = this.racingDrivers.FirstOrDefault(d => d.Name == driverName);
        string[] methodArgs = commandArgs.Skip(2).ToArray();

        if (boxReason == "Refuel")
        {
            driver.Refuel(methodArgs);
        }
        else if (boxReason == "ChangeTyres")
        {
            Tyre tyre = tyreFactory.CreateTyre(methodArgs);
            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException($"There is no time! On lap {this.track.CurrentLap}.");
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
            
        }
        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int i = 0; i < this.racingDrivers.Count; i++)
            {
                Driver driver = racingDrivers[i];
                try
                {
                    driver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException ex)
                {
                    driver.Fail(ex.Message);
                    failedDrivers.Push(driver);
                    racingDrivers.RemoveAt(i);
                    i--;
                }
            }
            this.track.CurrentLap++;

            List<Driver> orderedDrivers = racingDrivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int index = 0; index < orderedDrivers.Count - 1; index++)
            {
                Driver overtakingDriver = orderedDrivers[index];
                Driver targetDriver = orderedDrivers[index + 1];

                bool overtakeHappened = this.TryOverTake(overtakingDriver, targetDriver);

                if (overtakeHappened)
                {
                    index++;
                    builder.AppendLine(string.Format($"{overtakingDriver} has overtaken {targetDriver} on lap {track.CurrentLap}."));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }
        
            
        if (this.IsRaceOver)
        {
            Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();
            builder.AppendLine(
                string.Format($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds."));
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
            overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranceDriver = overtakingDriver is EnduranceDriver &&
            overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.track.Weather == Weather.Foggy) ||
            (enduranceDriver && this.track.Weather == Weather.Rainy);

        if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(crashReason);
                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }
    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderBoardDrivers = racingDrivers.OrderBy(d => d.TotalTime)
            .Concat(failedDrivers);

        int position = 1;
        foreach (Driver driver in leaderBoardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];

        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherobj);

        if (!validWeather)
        {
            throw new ArgumentException("Invalid Weather Type");
        }
        Weather weather = (Weather)weatherobj;
        this.track.Weather = weather; 
    }
}

