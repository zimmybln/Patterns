using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StateOnUi
{
    public class CircleElement : IVisualElement
    {
        private Ellipse circle;

        public CircleElement()
        {
            circle = new Ellipse();
        }

        public Point? BeginElement(double x, double y)
        {
            circle = new Ellipse();


            circle.Width = 2;
            circle.Height = 2;
            circle.Stroke = Brushes.Red;

            return new Point(x - 1, y - 1);

        }

        public Point? ProcessElement(double x, double y, double width, double height)
        {
            circle.Width = Math.Abs(width);
            circle.Height = Math.Abs(height);

            return new Point(width < 0 ? x + width : x, height < 0 ? y + height : y);
        }

        public Point? EndElement(double x, double y, double width, double height)
        {
            circle.Width = Math.Abs(width);
            circle.Height = Math.Abs(height);

            return new Point(width < 0 ? x + width : x, height < 0 ? y + height : y);
        }

        public UIElement Control => circle;
    }

}
