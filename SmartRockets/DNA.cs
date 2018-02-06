using System.Windows;

namespace SmartRockets
{
    public class DNA
    {
        private Vector[] velocityVectors;

        public DNA(int maxLifeTime, bool? dontFillDNA = null)
        {
            velocityVectors = new Vector[maxLifeTime];

            if (dontFillDNA == true) { return; }

            for (int i = 0; i < velocityVectors.Length; i++)
            {
                velocityVectors[i] = new Vector(
                    DrawingTools.Random.Next(-50, 50),
                    DrawingTools.Random.Next(-25, 15));
            }
        }

        public Vector this[int index]
        {
            get => velocityVectors[index];
            set => velocityVectors[index] = value;
        }

        public int Count => velocityVectors.Length;

        public DNA Crossover(DNA dNA, double mutationPercent)
        {
            var newDNA = new DNA(velocityVectors.Length, true);

            for (int i = 0; i < velocityVectors.Length; i++)
            {
                if (DrawingTools.Random.NextDouble() < 0.5)
                {
                    newDNA[i] = new Vector(
                        DrawingTools.Random.Next(-50, 50),
                        DrawingTools.Random.Next(-25, 15));
                }

                if (i > velocityVectors.Length / 2)
                {
                    newDNA[i] = this[i];
                }
                else
                {
                    newDNA[i] = dNA[i];
                }
            }

            return newDNA;
        }
    }
}
