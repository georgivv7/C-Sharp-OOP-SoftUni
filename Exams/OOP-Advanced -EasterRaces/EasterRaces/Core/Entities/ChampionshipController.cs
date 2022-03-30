namespace EasterRaces.Core.Entities
{
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;
        private CarRepository carRepository;
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new CarRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound,
                    driverName));
            }

            var car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound,
                    carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,
                    raceName));
            }

            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound,
                    driverName));
            }
            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded,
                driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetAll().Any(c=>c.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists,
                    model));
            }
            ICar car = null; 
            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
                default:
                    break;
            }
            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated,
                car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists,
                    driverName));
            }

            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated,
                driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists,
                    name));
            }

            IRace race = new Race(name,laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated,
                name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,
                    raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid,
                    raceName, 3));
            }

            var sorted = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            this.raceRepository.Remove(race);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {sorted[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {sorted[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {sorted[2].Name} is third in {race.Name} race.");

            return sb.ToString().Trim();
        }
    }
}
