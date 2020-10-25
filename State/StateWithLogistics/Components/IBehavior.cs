using System;
using System.Collections.Generic;
using System.Text;

namespace StateWithLogistics.Components
{
    interface IBehavior : IState
    {
        void DoSomething();
    }
}
