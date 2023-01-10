namespace XantiumCoursCSharp
{
    public class SportCar : ICar
    {
        private string Marque { get; init; }

        public SportCar(string MarqueDeLaTuture)
        {
            Marque = MarqueDeLaTuture;
        }

        private bool _started;

        public bool StartEngine()
        {
            if (_started)
            {
                return false;
            }

            Console.WriteLine($"{Marque} Engine started");
            _started = true;
            return true;
        }

        public void StopEngine()
        {
            _started = false;
            Console.WriteLine($"{Marque} Engine stopped");
        }
    }
}

