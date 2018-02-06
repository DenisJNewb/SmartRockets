using System;
using System.Windows.Media;

namespace SmartRockets
{
    public static class ExtensionsClass
    {
        public static void AddToCanvas(this Visual visual)
        {
            CustomCanvas.MyCanvas.AddVisual(visual);
        }

        public static void RemoveFromCanvas(this Visual visual)
        {
            CustomCanvas.MyCanvas.RemoveVisual(visual);
        }
    }
}
