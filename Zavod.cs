using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    class Zavod
    {
        private List<Wheel> wheels = new List<Wheel>();
        //private List<Engine> list = new List<Engine>();

        public void Add(Detal detal)
        {
            if(detal is Wheel wheel && wheels.Count < 4)
            {
                wheels.Add(wheel);
            }
        }

        public void ShowState()
        {
            Console.WriteLine($"Wheels: {wheels.Count}");
        }
    }
}
