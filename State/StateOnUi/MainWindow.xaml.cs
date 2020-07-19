using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StateOnUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnDrawModeClicked(object sender, RoutedEventArgs e)
        {
            (new ToggleButton[]{circleButton, rectangleButton, polygonButton, noneButton}).ToList()
                .ForEach(b => b.IsChecked = false);

            if (Equals(sender, circleButton))
            {
                drawingPad.DrawingMode = DrawingModes.Circle;
            }
            else if (Equals(sender, rectangleButton))
            {
                drawingPad.DrawingMode = DrawingModes.Rectangle;
            }
            else if (Equals(sender, polygonButton))
            {
                drawingPad.DrawingMode = DrawingModes.Polygon;
            }
            else
            {
                drawingPad.DrawingMode = DrawingModes.None;
            }
            
            ((ToggleButton) sender).IsChecked = true;
        }
    }
}
