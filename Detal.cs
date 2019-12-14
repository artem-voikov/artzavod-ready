﻿using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    abstract class Detal
    {
        public int Price { get; }
        public Detal(int price)
        {
            Price = price;
        }
    }

    class Engine : Detal { 
        public Engine(int price)
            : base(price)
        { }
    }

    class Wheel : Detal
    {
        public Wheel(int price) : base(price)
        {
        }
    }

    class SteeringWheel : Detal
    {
        public SteeringWheel(int price) : base(price)
        {
        }
    }

    class Sit : Detal
    {
        public Sit(int price) : base(price)
        {
        }
    }

    interface ICommand
    {
        void Act();
    }

    class CommandSimulator : ICommand
    {
        public void Act()
        {
            Console.WriteLine("Command triggered");
        }
    }

    class Command : ICommand
    {
        public void Act()
        {
            InternalAct();
        }

        protected virtual void InternalAct()
        {
        }
    }

    class CreateWheelCommand : Command
    {
        private Zavod zavod;
        public Detal Detal { get; set; }

        public CreateWheelCommand(Zavod zavod)
        {
            this.zavod = zavod;
        }

        protected override void InternalAct()
        {
            var key = Program.Rnd.Next(0, 4);

            Detal detal = null;

            if (key == 0)
                detal = new Wheel(250);
            else if (key == 1)
                detal = new Engine(1500);
            else if (key == 2)
                detal = new Sit(350);
            else if (key == 3)
                detal = new SteeringWheel(150);

            zavod.Add(detal);
            zavod.ShowState();
        }
    }
}
