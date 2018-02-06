using System;
using System.Windows.Media;

namespace SmartRockets
{
    public static class DrawingTools
    {
        public static Pen Pen { get; } = new Pen(Brushes.Black, 1);
        public static Random Random { get; } = new Random();
        public static int TopBoundary { get; } = 0;
        public static int BottomBoundary { get; } = (int)CustomCanvas.MyCanvas.Height;
        public static int LeftBoundary { get; } = 0;
        public static int RightBoundary { get; } = (int)CustomCanvas.MyCanvas.Width;
    }
}
