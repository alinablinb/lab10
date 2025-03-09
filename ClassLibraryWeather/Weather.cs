using ClassLibrary;

namespace ClassLibraryWeather
{
    public class Weather : IInit, ICloneable, IComparable<Weather>
    {
        protected double temperature;
        protected int humidity;
        protected int pressure;

        public Weather()
        {
            temperature = 0.0;
            humidity = 0;
            pressure = 0;
        }

        public Weather(double temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public double Temperature { get => temperature; set => temperature = value; }
        public int Humidity { get => humidity; set => humidity = value; }
        public int Pressure { get => pressure; set => pressure = value; }

        // Реализация интерфейса IInit
        public void Init()
        {
            Console.WriteLine("Введите температуру:");
            Temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите влажность (0-100):");
            Humidity = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите давление:");
            Pressure = int.Parse(Console.ReadLine());
        }

        public void RandomInit()
        {
            Random rand = new Random();
            Temperature = Math.Round(rand.NextDouble() * 50 - 20, 2); // Температура от -20 до 30
            Humidity = rand.Next(0, 101);
            Pressure = rand.Next(700, 800);
        }

        // Реализация интерфейса ICloneable
        public object Clone()
        {
            return new Weather(Temperature, Humidity, Pressure);
        }

        public Weather ShallowCopy()
        {
            return (Weather)this.MemberwiseClone();
        }

        // Реализация интерфейса IComparable
        public int CompareTo(Weather other)
        {
            return Temperature.CompareTo(other.Temperature);
        }

        public override string ToString()
        {
            return $"Температура: {Temperature} °C, Влажность: {Humidity} %, Давление: {Pressure} мм рт. ст.";
        }

        public override bool Equals(object obj)
        {
            if (obj is Weather other)
            {
                return Temperature == other.Temperature &&
                       Humidity == other.Humidity &&
                       Pressure == other.Pressure;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Temperature, Humidity, Pressure);
        }
    }
}