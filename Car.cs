using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    class Car
    {
        protected Dictionary<Type, List<Detal>> details;

        public Car()
        {
            details = new Dictionary<Type, List<Detal>>
            {
                [typeof(Wheel)] = new List<Detal>(4),
                [typeof(Engine)] = new List<Detal>(2),
                [typeof(SteeringWheel)] = new List<Detal>(1),
                [typeof(Sit)] = new List<Detal>(2)
            };
        }

        public bool AddDetal(Detal detal)
        {
            var type = detal.GetType();
            var list = details[type];

            if (list.Count >= list.Capacity)
                return false;

            list.Add(detal);
            return true;
        }

        public Car PutDetal(params Detal[] detals)
        {
            var list = this.details[detals[0].GetType()];
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

            foreach (var pair in details)
            {
                foreach (var detail in pair.Value)
                    price += detail.Price;

                partsCount += pair.Value.Count;
                partsTotal += pair.Value.Capacity;
            }

            var result = Math.Round(100 / partsTotal * partsCount);
            return result;
        }
    }
}
