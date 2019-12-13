using System;
using System.Collections.Generic;

namespace artzavod
{
    class Program
    {
        public static Random Rnd = new Random();
        static void Main(string[] args)
        {
            var zavod = new Zavod();



            var commands = new Dictionary<ConsoleKey, ICommand>
            {
                [ConsoleKey.Spacebar] = new CreateWheelCommand(zavod),
                [ConsoleKey.Enter] = new CommandSimulator()
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
