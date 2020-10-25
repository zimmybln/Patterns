using System;
using System.Collections.Generic;
using System.Text;

namespace StateWithLogistics.Components
{
    interface IState
    {
        bool CanLeave();

        void PrepareLeave();

        void Leave();

        bool CanEnter();

        void PrepareEnter();

        void Enter();

    }
}
