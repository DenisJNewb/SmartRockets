using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SmartRockets
{
    public class Rocket : DrawingVisual
    {
        private Size size;
        private Brush backgroundBrush;
        public Rect Rect { get; private set; }

        private Vector positionVector;
        private Vector velocityVector;
        private Vector accelerationVector;

        public DNA DNA { get; private set; }
        public double Fitnes;

        private bool success;
        private bool failed;

        public Rocket(DNA dNA = null)
        {
            size = new Size(5, 20);
            backgroundBrush = new SolidColorBrush(Color.FromArgb(200, 0, 0, 0));

            positionVector = new Vector(
               DrawingTools.RightBoundary / 2 - size.Width / 2,
                DrawingTools.BottomBoundary - size.Height);

            velocityVector = new Vector();

            accelerationVector = new Vector();

            DNA = dNA ?? new DNA(Population.MaxLifeTime);

            this.AddToCanvas();
        }

        public void Update(int currentLifeTime)
        {
            if (failed || success)
            {
                return;
            }

            if (Vector.Subtract(Target.MyTarget.Position, positionVector).Length < 10)
            {
                success = true;
                return;
            }

            if (Wall.Walls.Any(x => this.IsTouching(x)))
            {
                failed = true;
                return;
            }

            accelerationVector = Vector.Add(accelerationVector, DNA[currentLifeTime]);
            accelerationVector = Vector.Multiply(accelerationVector, 0.1);

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

                Rect = new Rect(0, 0, size.Width, size.Height);

                render.DrawRectangle(backgroundBrush, null, Rect);
            }
        }

        public void CalculateFitnes()
        {
            Fitnes = 1 / Vector.Subtract(Target.MyTarget.Position, positionVector).Length;
            if (success) { Fitnes *= 10; }
            if (failed) { Fitnes /= 10; }
        }
    }
}