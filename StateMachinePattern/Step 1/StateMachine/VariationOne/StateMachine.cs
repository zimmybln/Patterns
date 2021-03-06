﻿using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Exceptions;

namespace StateMachine.VariationOne
{
    public class StateMachine
    {
        public List<State> States { get; } = new List<State>();

        /// <summary>
        /// Verifies if a state is set or not.
        /// </summary>
        public bool IsSet(string statename)
        {
            var state = States.FirstOrDefault(s => s.Name.Equals(statename));

            if (state == null)
                throw new UnknownStateException(statename);

            return state.Expression();
        }
    }

    public static class ListOfStateExtender
    {
        public static bool ContainsByName(this List<State> list, string name)
        {
            return list.Any(s => s.Name.Equals(name));
        }
    }


    public class State
    {
        private Func<bool> _stateExpression = null;

        public State(string name, Func<bool> expression = null)
        {
            Name = name;
            _stateExpression = expression;
        }

        public Func<bool> Expression
        {
            get { return _stateExpression; }
            set { _stateExpression = value; }
        }

        public string Name { get; }

        public static implicit operator State(string name)
        {
            return new State(name);
        }
    }
}
