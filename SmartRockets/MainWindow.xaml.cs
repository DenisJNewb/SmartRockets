using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using static SmartRockets.CustomCanvas;

namespace SmartRockets
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Content = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = MyCanvas
            };

            MyCanvas.Loaded += MyCanvas_Loaded;
        }

        private void MyCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Population.GrowPopulation(15);
            Population.MobilizePopulation();
        }
    }
}
