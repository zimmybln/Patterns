using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class StateMachine
    {
        private readonly List<State> _states = new List<State>();


        public List<State> States
        {
            get { return _states; }
        }
    }

    public static class ListOfStateExtender
    {
        public static bool Contains(this List<State> list, string name)
        {
            return list.Any(s => s.Name.Equals(name));
        }
    }


    public class State
    {
        public State(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static implicit operator State(string name)
        {
            return new State(name);
        }
    }
}
