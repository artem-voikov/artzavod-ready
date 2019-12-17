using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    class Car
    {
        //protected Dictionary<Type, List<Detal>> details;

        protected List<Detal> wheels = new List<Detal>(4);
        protected List<Detal> engines = new List<Detal>(2);
        protected List<Detal> steeringWheels = new List<Detal>(1);
        protected List<Detal> sits = new List<Detal>(2);

        public Car()
        { }

        public bool AddDetal(Detal detal)
        {
            var type = detal.GetType();
            var list = GetListByType(detal);
            if (list == null)
                throw new ArgumentException("wut?");

            if (list.Count >= list.Capacity)
                return false;

            list.Add(detal);
            return true;
        }

        protected List<Detal> GetListByType(Detal detal)
        {
            switch(detal)
            {
                case SteeringWheel sw:
                    return steeringWheels;
                case Sit sit:
                    return sits;
                case Engine e:
                    return engines;
                case Wheel w:
                    return wheels;
            }

            return null;
        }

        public Car PutDetal(params Detal[] detals)
        {
            var list = GetListByType(detals[0]);
            list.AddRange(detals);

            return this;
        }

        public override string ToString()
        {
            double result = GetReadynessPercent(out int price);

            return $"Car is ready by {result} percent {price}";
        }

        private double GetReadynessPercent(out int price)
        {
            price = 0;
            double partsCount = 0;
            double partsTotal = 0;
            var allDetailsLists = new List<Detal>[] { wheels, sits, steeringWheels, engines };

            foreach (var list in allDetailsLists)
            {
                foreach (var detail in list)
                    price += detail.Price;

                partsCount += list.Count;
                partsTotal += list.Capacity;
            }

            var result = Math.Round(100 / partsTotal * partsCount);

            return result;
        }
    }
}
