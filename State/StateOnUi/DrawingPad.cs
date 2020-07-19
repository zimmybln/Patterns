using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StateOnUi
{
    public enum DrawingModes
    {
        None = 0,
        Circle = 1,
        Rectangle = 2,
        Polygon = 3
    }


    public class DrawingPad : Canvas
    {
        private MouseInteractionState mouseInteraction;
        private IVisualElement element;

        public static DependencyProperty DrawingModeProperty = DependencyProperty.Register("DrawingMode", typeof(DrawingModes), typeof(DrawingPad), new PropertyMetadata(OnDrawingModeChanged));

        private static void OnDrawingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DrawingPad drawingPad)
            {
                switch ((DrawingModes)e.NewValue)
                {
                    case DrawingModes.Circle: drawingPad.element = new CircleElement();
                        break;

                    case DrawingModes.Rectangle: drawingPad.element = new RectangleElement();
                        break;

                    case DrawingModes.Polygon: drawingPad.element = new PolygonElement();
                        break;

                    default: drawingPad.element = null;
                        break;
                }
            }
        }


        public DrawingModes DrawingMode
        {
            get => (DrawingModes) GetValue(DrawingModeProperty);
            set => SetValue(DrawingModeProperty, value);
        }
        
        public DrawingPad()
        {
            mouseInteraction = new MouseInteractionState(this);
            mouseInteraction.ActionCompleted += OnActionCompleted;
            mouseInteraction.ActionStarted += OnActionStarted;
            mouseInteraction.ActionProcessed += OnActionProcessed;

            this.Background = Brushes.Beige;

            element = new RectangleElement();
        }

        private void OnActionStarted(object sender, ActionStartedArgs e)
        {
            if (element == null)
                return;

            var position = element.BeginElement(e.StartX, e.StartY);

            if (position.HasValue)
            {
                Canvas.SetLeft(element.Control, position.Value.X);
                Canvas.SetTop(element.Control, position.Value.Y);

                this.Children.Add(element.Control);
            }


            e.CustomElement = element;
        }

        private void OnActionProcessed(object sender, ActionProcessedArgs e)
        {
            if (e.CustomElement is IVisualElement element)
            {
                var p = element.ProcessElement(e.StartX, e.StartY, e.Width, e.Height);

                if (p.HasValue)
                {
                    Canvas.SetLeft(element.Control, p.Value.X);
                    Canvas.SetTop(element.Control, p.Value.Y);
                }
            }
        }



        private void OnActionCompleted(object? sender, ActionCompletedArgs e)
        {
            if (e.CustomElement is IVisualElement element)
            {
                var p = element.EndElement(e.StartX, e.StartY, e.Width, e.Height);

                if (p.HasValue)
                {
                    Canvas.SetLeft(element.Control, p.Value.X);
                    Canvas.SetTop(element.Control, p.Value.Y);
                }

            }
        }
    }
}
