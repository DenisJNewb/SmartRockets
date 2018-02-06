using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartRockets
{
    public class CustomCanvas : Panel
    {
        public static CustomCanvas MyCanvas = new CustomCanvas();

        private List<Visual> visualObjects;

        public CustomCanvas()
        {
            Height = 600;
            Width = 600;
            ClipToBounds = true;
            visualObjects = new List<Visual>();
        }

        public void AddVisual(Visual visualObject)
        {
            AddVisualChild(visualObject);
            AddLogicalChild(visualObject);
            visualObjects.Add(visualObject);
        }

        public void RemoveVisual(Visual visualObject)
        {
            visualObjects.Remove(visualObject);
            RemoveLogicalChild(visualObject);
            RemoveVisualChild(visualObject);
        }

        public void ClearVisuals()
        {
            foreach (var visual in visualObjects)
            {
                RemoveLogicalChild(visual);
                RemoveVisualChild(visual);
            }
            visualObjects.Clear();
        }

        protected override int VisualChildrenCount => visualObjects.Count;

        protected override Visual GetVisualChild(int index) => visualObjects[index];
    }
}
