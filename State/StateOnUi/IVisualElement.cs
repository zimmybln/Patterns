using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StateOnUi
{
    public interface IVisualElement
    {
        Point? BeginElement(double x, double y);

        Point? ProcessElement(double x, double y, double width, double height);

        Point? EndElement(double x, double y, double width, double height);

        UIElement Control { get; }
    }
}
