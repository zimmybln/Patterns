using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineWithCharacteristicByValues
{
    public class StateMachine<TStates, TContext> where TStates : struct, IConvertible, IComparable
    {
        private TStates _currentState;
        private readonly Dictionary<TStates, StateDefinition> _stateDefinitions = new Dictionary<TStates, StateDefinition>();

        public StateMachine(TStates defaultstate)
        {
            _currentState = defaultstate;
        }

        public TStates CurrentState => _currentState;

        public StateDefinition this[TStates state]
        {
            get
            {
                if (!_stateDefinitions.ContainsKey(state))
                {
                    StateDefinition statedefinition = new StateDefinition(state);
                    _stateDefinitions.Add(state, statedefinition);
                    
                    return statedefinition;
                }

                return _stateDefinitions[state];
            }
        }

        public bool FindState(TContext userContext)
        {
            List<TStates> lstValidStates = new List<TStates>();

            foreach (KeyValuePair<TStates, StateDefinition> valuePair in _stateDefinitions)
            {
                if (valuePair.Value._verifyFunc != null)
                {
                    if (valuePair.Value._verifyFunc(userContext))
                    {
                        lstValidStates.Add(valuePair.Key);
                    }
                }
            }

            if (lstValidStates.Count == 1)
            {
                if (!EqualityComparer<TStates>.Default.Equals(lstValidStates[0], _currentState))
                {
                    _currentState = lstValidStates[0];
                    return true;
                }
            }

            return false;
        }



        public class StateDefinition
        {
            protected internal readonly TStates _state;
            protected internal Func<TContext, bool> _verifyFunc = null;

            protected internal StateDefinition(TStates state)
            {
                _state = state;
            }

            public void OnVerifyState(Func<TContext, bool> verifyFunc)
            {
                _verifyFunc = verifyFunc;
            }

            public override bool Equals(object obj)
            {
                var stateDefinition = obj as StateDefinition;

                return stateDefinition != null && EqualityComparer<TStates>.Default.Equals(_state, stateDefinition._state);
            }

            public static bool operator ==(StateDefinition a, TStates b)
            {
                var rightstateasComparable = b as IComparable;

                return rightstateasComparable.CompareTo(a._state) == 0;
            }

            public static bool operator !=(StateDefinition a, TStates b)
            {
                var rightstateasComparable = b as IComparable;

                return rightstateasComparable.CompareTo(a._state) != 0;
            }
        }



    }


}
