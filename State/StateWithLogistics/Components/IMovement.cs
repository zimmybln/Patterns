using System;
using System.Collections.Generic;
using System.Text;

namespace StateWithLogistics.Components
{

    public interface IMovement
    {
        void NextMove(ITransportContext context);
    }
}
