using System;

namespace artzavod
{
    class Program
    {
        static void Main(string[] args)
        {
            var zavod = new Zavod();
            zavod.Add(new Detal());

            Console.WriteLine("Hello World!");
        }
    }
}
