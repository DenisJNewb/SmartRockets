using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

        //TODO: REALY SLOW!!!
        public static bool IsTouching(this DrawingVisual visual, DrawingVisual visual2)
        {
            return false;
        }

        public static T PickRandom<T>(this List<T> list)
        {
            return list[DrawingTools.Random.Next(0, list.Count - 1)];
        }
    }
}
