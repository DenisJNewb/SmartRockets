using System.Windows;
using System.Windows.Media;

namespace SmartRockets.VisualObjects
{
    //TODO: Target boundary for touch tests
    //TODO: Ability to calculate distance between boundaries
    public abstract class VisualObject : DrawingVisual
    {
        private Point positionPoint;
        private Size size;

        private Point centerPoint;

        private Vector velocityVector;
        private Vector accelerationVector;

        private Geometry geometry;

        public VisualObject()
        {
            geometry = new GeometryGroup();

            this.AddToCanvas();
        }

        public void Show()
        {
            using (var render = RenderOpen())
            {
                render.DrawGeometry(Brushes.Black, null, geometry);
            }
        }

        public void RemoveObject()
        {
            this.RemoveFromCanvas();
        }
    }
}
