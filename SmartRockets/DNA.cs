using System.Windows;

namespace SmartRockets
{
    public class DNA
    {
        private Vector[] velocityVectors;

        public DNA(int maxLifeTime)
        {
            velocityVectors = new Vector[maxLifeTime];
            for (int i = 0; i < velocityVectors.Length; i++)
            {
                velocityVectors[i] = new Vector(
                    DrawingTools.Random.Next(-4, 4),
                    DrawingTools.Random.Next(-2, 2));
            }
        }

        public Vector this[int index] => velocityVectors[index];

        public int Count => velocityVectors.Length;
    }
}
