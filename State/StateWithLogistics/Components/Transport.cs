using System;
using System.Collections.Generic;
using System.Text;

namespace StateWithLogistics.Components
{
    public enum TransportTypes
    {
        None = 0,
        SlowCar = 1,
        FastCar = 2,
        Human = 3
    }


    public class Transport : ITransportContext
    {
        private readonly Point startPoint;
        private readonly Point endPoint;
        private int weight;
        private IMovement currentMovement = null;

        public Transport(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.TransportType = TransportTypes.None;
        }

        public int Weight { get; set; }

        public int Amount { get; set; }

        public Point Position { get; set; }

        public TransportTypes TransportType { get; private set; }

        public void GoNext()
        {
            // Ermittle die nächste Bewegungsform
            currentMovement ??= GetMovement(this.TransportType);
            
            // Führe die nächste Bewegungsform aus
            currentMovement.NextMove(this);

            // Überprüfe die Eigenschaften und setze den neuen Transporttyp
            if (Weight > 20000 || Amount > 3)
            {
                
            }
            else
            {
                this.TransportType = TransportTypes.Human;
            }

        }

        private bool IsChangeOfTransportTypeAllowed(IMovement fromTransportType, IMovement toTransportType)
        {

            return true;
        }

        private IMovement GetMovement(TransportTypes transportType)
        {
            return null;
        }
    }
}
