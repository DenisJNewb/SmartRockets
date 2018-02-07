using System.Windows;
using System.Windows.Media;

namespace SmartRockets
{
    public class Wall : DrawingVisual
    {
        public static Wall[] Walls { get; private set; } = new Wall[2];

        public Size Size { get; private set; }
        public Vector PositionVector { get; private set; }

        public Rect Rect { get; private set; }

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

                Rect = new Rect(0, 0, Size.Width, Size.Height);

                render.DrawRectangle(
                    null,
                    DrawingTools.Pen,
                    Rect);
            }
        }
    }
}
