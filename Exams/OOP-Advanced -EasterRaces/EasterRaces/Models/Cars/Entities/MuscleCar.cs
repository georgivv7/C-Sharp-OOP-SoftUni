namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CUBICS = 5000d;
        private const int MinPOWER = 400;
        private const int MaxPOWER = 600;
        public MuscleCar(string model, int horsePower) : 
            base(model, horsePower, CUBICS, MinPOWER, MaxPOWER)
        { }
    }
}
