using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using StateMachine.Annotations;

namespace StateMachine.Common
{
    /// <summary>
    /// A statemachine base class
    /// </summary>
    /// <typeparam name="TStates"></typeparam>
    /// <typeparam name="TContext"></typeparam>
    public class StateMachine<TStates, TContext> : INotifyPropertyChanged
        where TStates : struct, IConvertible, IComparable
    {
        private TStates[] _currentState;
        private readonly Dictionary<TStates, StateDefinition> _stateDefinitions = new Dictionary<TStates, StateDefinition>();

        public StateMachine(TStates defaultstate)
        {
            _currentState = new []{defaultstate};
        }

        public TStates[] CurrentState => _currentState;

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

            if (AreValidStates(lstValidStates))
            {
                if (!_currentState.Except(lstValidStates, EqualityComparer<TStates>.Default).Any())
                {
                    return false;
                }
                ProceedStateChange(lstValidStates);
            }

            return false;
        }

        /// <summary>
        /// Check if the states are valid. This method is called before the
        /// current state is set.
        /// </summary>
        /// <param name="states">List of states that became 'true'</param>
        /// <returns></returns>
        protected virtual bool AreValidStates(List<TStates> states)
        {
            return states.Count == 1;
        }

        private void ProceedStateChange(List<TStates> states)
        {
            var newstates = states.ToArray();

            StateChanging(_currentState, newstates);
            
            _currentState = newstates;

            OnPropertyChanged(nameof(CurrentState));
        }

        protected virtual void StateChanging(TStates[] oldStates, TStates[] newStates)
        {
            
        }



        /// <summary>
        /// A state definition
        /// </summary>
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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var evt = PropertyChanged;
            evt?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
