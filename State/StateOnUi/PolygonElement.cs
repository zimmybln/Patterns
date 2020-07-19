using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StateOnUi
{
    public class PolygonElement : IVisualElement
    {
        private Polygon polygon;

        public PolygonElement()
        {
            polygon = new Polygon();
            polygon.Stroke = System.Windows.Media.Brushes.Black;
            polygon.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            polygon.StrokeThickness = 2;
            polygon.HorizontalAlignment = HorizontalAlignment.Left;
            polygon.VerticalAlignment = VerticalAlignment.Center;
            polygon.Points = new PointCollection();
        }


        public Point? BeginElement(double x, double y)
        {
            var isFirstElement = !polygon.Points.Any();

            polygon.Points.Add(new Point(x, y));


            if (isFirstElement)
            {
                return new Point(0, 0);
            }

            return null;
        }

        public Point? ProcessElement(double x, double y, double width, double height)
        {
            return null;
        }

        public Point? EndElement(double x, double y, double width, double height)
        {
            return null;
        }

        public UIElement Control => polygon;
    }

}
