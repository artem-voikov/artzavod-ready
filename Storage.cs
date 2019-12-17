using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    class Storage : Car
    {
        public IEnumerable<Detal> ReleaseStorage(Detal detal)
        {
            var list = this.GetListByType(detal);
            foreach (var item in list)
                yield return item;

            list.Clear();

            Console.WriteLine($"List after cleansing:{list.Count}, {this.GetListByType(detal).Count}");

            list.Add(detal);

        }
    }
}
