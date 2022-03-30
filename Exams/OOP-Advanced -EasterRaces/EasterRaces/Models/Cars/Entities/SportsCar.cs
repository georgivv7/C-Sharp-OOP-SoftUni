namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CUBICS = 3000d;
        private const int MinPOWER = 250;
        private const int MaxPOWER = 450;
        public SportsCar(string model, int horsePower) :  
            base(model, horsePower, CUBICS, MinPOWER, MaxPOWER)
        { }
    }
}
