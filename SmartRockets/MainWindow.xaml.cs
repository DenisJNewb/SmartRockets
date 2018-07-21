using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using static SmartRockets.CustomCanvas;

namespace SmartRockets
{
    public partial class MainWindow : Window
    {
        public static TextBlock lifeTextBlock;

        public MainWindow()
        {
            InitializeComponent();

            var stackPanel = new StackPanel();
            stackPanel.Children.Add(MyCanvas);

            lifeTextBlock = new TextBlock() { Text = "0" };
            stackPanel.Children.Add(lifeTextBlock);

            Content = new Border()
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = stackPanel
            };

            MyCanvas.Loaded += MyCanvas_Loaded;
        }

        private void MyCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Target.MyTarget.Show();
            Wall.ShowWalls();
            var pop = new Population(); pop.GrowNew();
        }
    }
}
