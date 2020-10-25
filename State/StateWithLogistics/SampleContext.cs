using System;
using System.Collections.Generic;
using System.Text;
using StateWithLogistics.Components;
using StateWithLogistics.States;

namespace StateWithLogistics
{
    public class SampleContext
    {
        private int emergencyValue = 0;
        private IBehavior currentStateBehavior;
        private Dictionary<Type, IBehavior> stateInstances = new Dictionary<Type, IBehavior>();

        public SampleContext()
        {
            var greenState = new GreenState();

            stateInstances.Add(greenState.GetType(), greenState);

            currentStateBehavior = greenState;
        }

        public int EmergencyValue
        {
            get => emergencyValue;
            set
            {
                if (value != emergencyValue)
                {
                    emergencyValue = value;
                    ApplyState(emergencyValue);
                }
            }
        }

        private void ApplyState(int value)
        {
            Type stateType;

            // Welcher Status wird gesucht
            if (emergencyValue > 100)
            {
                stateType = typeof(RedState);
            }
            else
            {
                stateType = typeof(GreenState);
            }

            // hat sich etwas geändert
            if (currentStateBehavior.GetType() == stateType)
            {
                return;
            }

            // Instanz erstellen bzw. ermitteln
            IBehavior nextState;

            if (!stateInstances.ContainsKey(stateType))
            {
                nextState = Activator.CreateInstance(stateType) as IBehavior;
                stateInstances.Add(stateType, nextState);
            }
            else
            {
                nextState = stateInstances[stateType];
            }

            // Wechsel durchführen
            if (nextState.CanEnter() && currentStateBehavior.CanLeave())
            {
                nextState.PrepareEnter();
                currentStateBehavior.PrepareLeave();

                nextState.Enter();
                currentStateBehavior.Leave();

                currentStateBehavior = nextState;
            }
        }

        public void DoSomething()
        {
            currentStateBehavior.DoSomething();
        }
    }
}
