using System;
using System.Collections.Generic;
using System.Text;

namespace artzavod
{
    abstract class Detal
    {
    }

    class Engine : Detal { }


    class Wheel : Detal { }

    interface ICommand
    {
        void Act();
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
            zavod.Add(Detal);
            zavod.ShowState();
        }
    }
}
