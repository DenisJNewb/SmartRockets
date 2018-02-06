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

    public class Wall : DrawingVisual
    {
        public static Wall[] Walls { get; private set; } = new Wall[2];

        public Size Size { get; private set; }
        public Vector PositionVector { get; private set; }

        public Wall()
        {
            Size = new Size(
                DrawingTools.Random.Next(40, 100),
                DrawingTools.Random.Next(5, 15));

            PositionVector = new Vector(
               DrawingTools.Random.Next(0, (int)(DrawingTools.RightBoundary - Size.Width)),
               DrawingTools.Random.Next((int)(Target.MyTarget.Position.Y + Target.MyTarget.Size.Height), DrawingTools.BottomBoundary / 2));

            Show();

            this.AddToCanvas();
        }

        public static void ShowWalls()
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                Walls[i] = new Wall();
            }
        }

        public static void Clear()
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                Walls[i].RemoveFromCanvas();
            }
        }

        private void Show()
        {
            using (var render = RenderOpen())
            {
                var transition = new TranslateTransform(PositionVector.X, PositionVector.Y);
                var rotation = new RotateTransform(Vector.AngleBetween(new Vector(0, -1), PositionVector));
                render.PushTransform(transition);
                render.PushTransform(rotation);
                render.DrawRectangle(
                    null,
                    DrawingTools.Pen,
                    new Rect(0,
                            0,
                            Size.Width,
                            Size.Height));
            }
        }
    }
}
