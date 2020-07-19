using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StateOnUi
{
    public class ActionStartedArgs : EventArgs
    {
        public double StartX { get; set; }

        public double StartY { get; set; }

        public object CustomElement { get; set; }
    }

    public class ActionProcessedArgs : EventArgs
    {
        public double StartX { get; set; }
        public double StartY { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public object CustomElement { get; set; }

    }

    public class ActionCompletedArgs : EventArgs
    {
        public double StartX { get; set; }
        public double StartY { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public object CustomElement { get; set; }
    }

    public delegate void OnActionCompletedHandler(object sender, ActionCompletedArgs args);

    public delegate void OnActionProcessedHandler(object sender, ActionProcessedArgs args);

    public delegate void OnActionStartedHandler(object sender, ActionStartedArgs args);


    public class MouseInteractionState
    {
        private IInputElement inputHost;
        private bool mouseDown = false;
        private Point startPoint;
        private object customElement;


        public event OnActionCompletedHandler ActionCompleted;
        public event OnActionStartedHandler ActionStarted;
        public event OnActionProcessedHandler ActionProcessed;

        public MouseInteractionState(IInputElement host)
        {
            inputHost = host;

            inputHost.MouseLeftButtonDown += OnLeftButtonDown;
            inputHost.MouseMove += OnMouseMove;
            inputHost.MouseLeftButtonUp += OnLeftButtonUp;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && mouseDown)
            {
                Point endPosition = e.GetPosition(inputHost);

                var args = new ActionProcessedArgs()
                {
                    StartX = startPoint.X,
                    StartY = startPoint.Y,
                    Width = endPosition.X - startPoint.X,
                    Height = endPosition.Y - startPoint.Y,
                    CustomElement = customElement
                };

                ActionProcessed?.Invoke(this, args);

            }
        }

        private void OnLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                startPoint = e.GetPosition(inputHost);

                mouseDown = true;

                var args = new ActionStartedArgs()
                {
                    StartX = startPoint.X,
                    StartY = startPoint.Y
                };

                ActionStarted?.Invoke(this, args);

                customElement = args.CustomElement;
            }
        }


        private void OnLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mouseDown)
            {
                Point endPosition = e.GetPosition(inputHost);

                var args = new ActionCompletedArgs()
                {
                    StartX = startPoint.X,
                    StartY = startPoint.Y,
                    Width = endPosition.X - startPoint.X,
                    Height = endPosition.Y - startPoint.Y,
                    CustomElement = customElement
                };

                ActionCompleted?.Invoke(this, args);
            }

            mouseDown = false;
            customElement = null;
        }

    }
}
