using System;
using System.Windows;
using System.Windows.Media;

namespace SmartRockets
{
    public class Rocket : DrawingVisual
    {
        private Size size;
        private Brush backgroundBrush;

        private Vector positionVector;
        private Vector velocityVector;
        private Vector accelerationVector;

        private int lifetime;
        private DNA dNA;

        public Rocket()
        {
            size = new Size(10, 40);
            backgroundBrush = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));

            positionVector = new Vector(
               DrawingTools.RightBoundary / 2 - size.Width / 2,
                DrawingTools.BottomBoundary - size.Height);

            velocityVector = new Vector();

            accelerationVector = new Vector();

            dNA = new DNA(200);

            this.AddToCanvas();
        }

        public void Update()
        {
            if (lifetime == dNA.Count)
            {
                return;
            }
            accelerationVector = Vector.Add(accelerationVector, dNA[lifetime++]);


            velocityVector = Vector.Add(velocityVector, accelerationVector);
            positionVector = Vector.Add(positionVector, velocityVector);

            accelerationVector = Vector.Multiply(accelerationVector, 0);
        }

        public void Show()
        {
            using (var render = RenderOpen())
            {
                var transition = new TranslateTransform(positionVector.X, positionVector.Y);
                render.PushTransform(transition);
                var rotation = new RotateTransform(Vector.AngleBetween(new Vector(0, -1), velocityVector));
                render.PushTransform(rotation);
                render.DrawRectangle(backgroundBrush, null, new Rect(0, 0, size.Width, size.Height));
            }
        }
    }
}




/*
private bool CheckBoundary()
{
    if (positionVector.X >= DrawingTools.RightBoundary
        || positionVector.X <= DrawingTools.TopBoundary
        || positionVector.Y >= DrawingTools.BottomBoundary
        || positionVector.Y <= DrawingTools.LeftBoundary)
    {
        alive = false;
        this.RemoveFromCanvas();
    }
    return alive;
}

private void Draw_Update_Helper(Action action)
{
    if (!alive) { return; }
    if (!CheckBoundary()) { return; }
    action?.Invoke();
}
*/
