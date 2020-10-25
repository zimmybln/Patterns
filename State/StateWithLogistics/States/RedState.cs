using System;
using System.Collections.Generic;
using System.Text;
using StateWithLogistics.Components;

namespace StateWithLogistics.States
{
    public class RedState : IBehavior
    {
        public bool CanLeave()
        {
            return true;
        }

        public void PrepareLeave()
        {
            
        }

        public void Leave()
        {
            
        }

        public bool CanEnter()
        {
            return true;
        }

        public void PrepareEnter()
        {
            
        }

        public void Enter()
        {
            
        }

        public void DoSomething()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
}
