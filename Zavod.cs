using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    class Zavod
    {
        private List<Wheel> wheels = new List<Wheel>();
        private List<Engine> engines = new List<Engine>();
        private int prosraliCounter = 0;

        public void Add(Detal detal)
        {
            if (detal == null)
                throw new ArgumentNullException("detail");

            if (detal.Price == 0)
                return;

          

            if(detal is Wheel wheel && wheels.Count < 4)
            {
                wheels.Add(wheel);
            } else if (detal is Engine engine && engines.Count < 2)
            {
                engines.Add(engine);
            }
            else
            {
                this.prosraliCounter += detal.Price;
            }

        }

        public void ShowState()
        {
            if (wheels.Count == 4 && engines.Count == 2)
            {
                Console.WriteLine($"Car is done, poterali: {prosraliCounter}");
                wheels.Clear(); 
                engines.Clear();
            }
            else
            {
                Console.WriteLine($"Wheels: {wheels.Count}, Engines: {engines.Count}");
            }
            
        }
    }
}
