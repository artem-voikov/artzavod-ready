using System;
using System.Collections.Generic;

namespace artzavod
{
    class Program
    {
        static void Main(string[] args)
        {
            var zavod = new Zavod();
            zavod.Add(new Wheel());

            var commands = new Dictionary<ConsoleKey, Command>
            {
                [ConsoleKey.Spacebar] = new CreateWheelCommand(zavod) { Detal = new Wheel() } 
            };

            var undone = true;
            while(undone)
            {
                var key = Console.ReadKey().Key;
                if (!commands.ContainsKey(key))
                    break;

                var command = commands[key];
                command.Act(); 
            }
        }
    }
}
