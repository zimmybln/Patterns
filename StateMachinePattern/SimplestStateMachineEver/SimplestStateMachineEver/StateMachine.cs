using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplestStateMachineEver
{
    public class StateMachine<T>
    {
        private T _currentState;

        public StateMachine(T defaultState)
        {
            _currentState = defaultState;
        }

        public T State => _currentState;

        public void SetState(T state)
        {
            _currentState = state;
        }
    }
}
