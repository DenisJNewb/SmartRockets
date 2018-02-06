using System.Windows;
using System.Windows.Media;

using static SmartRockets.DrawingTools;

namespace SmartRockets
{
    public class Target : DrawingVisual
    {
        public static Target MyTarget { get; } = new Target();

        public Size Size { get; private set; }

        public Vector Position { get; private set; }

        public Target()
        {
            Size = new Size(10, 10);

            Position = new Vector(
                Random.Next(0, RightBoundary - (int)Size.Width),
                Random.Next(0, (int)(BottomBoundary * 0.1)));

            this.AddToCanvas();
        }

        public void Show()
        {
            using (var render = RenderOpen())
            {
                render.DrawEllipse(null, DrawingTools.Pen, new Point(Position.X, Position.Y), Size.Width, Size.Height);
            }
        }
    }
}
