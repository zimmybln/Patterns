using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StateOnUi
{
    public class RectangleElement : IVisualElement
    {
        private Rectangle rectangle = new Rectangle();

        public Point? BeginElement(double x, double y)
        {
            rectangle = new Rectangle();


            rectangle.Width = 2;
            rectangle.Height = 2;
            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = 2;

            return new Point(x - 1, y - 1);
        }

        public Point? ProcessElement(double x, double y, double width, double height)
        {
            rectangle.Width = Math.Abs(width);
            rectangle.Height = Math.Abs(height);

            return new Point(width < 0 ? x + width : x, height < 0 ? y + height : y);

        }

        public Point? EndElement(double x, double y, double width, double height)
        {
            rectangle.Width = Math.Abs(width);
            rectangle.Height = Math.Abs(height);

            return new Point(width < 0 ? x + width : x, height < 0 ? y + height : y);

        }

        public UIElement Control => rectangle;
    }

}
