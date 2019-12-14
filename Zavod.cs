using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace artzavod
{
    class Zavod
    {
        private List<Car> cars = new List<Car>();
        private Storage storage = new Storage();

        public Zavod()
        {
            cars.Add(new Car());
        }

        public void Add(Detal detal)
        {
            if (detal == null)
                throw new ArgumentNullException("detail");

            if (detal.Price == 0)
                return;

            foreach (var c in cars)
            {
                var isDone = c.AddDetal(detal);
                if (isDone)
                {
                    return;
                }
            }

            if (storage.AddDetal(detal))
                return;

            var detals = storage.ReleaseStorage(detal);

            //cars.Add(new Car().PutDetal(detals.ToArray()));

            var aNewCar = new Car();
            aNewCar.PutDetal(detals.ToArray());
            cars.Add(aNewCar);
        }

        public void ShowState()
        {
            Console.Clear();
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($" [{i+1}] - {cars[i]}");
            }
                
        }
    }
}
