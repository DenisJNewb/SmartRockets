using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRockets
{
    public class Population
    {
        private Rocket[] rocketsArray;

        private int lifeTime;
        public static int MaxLifeTime { get; private set; }

        private List<Rocket> matingPool;

        public void GrowNew()
        {
            rocketsArray = new Rocket[100];

            MaxLifeTime = 70;

            for (int i = 0; i < rocketsArray.Length; i++)
            {
                rocketsArray[i] = new Rocket();
            }

            MobilizePopulation();
        }

        private async void MobilizePopulation()
        {
            while (true)
            {
                if (MaxLifeTime == lifeTime)
                {
                    break;
                }

                for (int i = 0; i < rocketsArray.Length; i++)
                {
                    rocketsArray[i].Update(lifeTime);
                    rocketsArray[i].Show();
                }
                MainWindow.lifeTextBlock.Text = $"{lifeTime++}";

                await Task.Delay(20);
            }
            Evaluate();
            RemoveRockets();
            GrowSelection();
        }

        private void Evaluate()
        {
            var maxfitnes = 0d;
            for (int i = 0; i < rocketsArray.Length; i++)
            {
                rocketsArray[i].CalculateFitnes();
                if (rocketsArray[i].Fitnes > maxfitnes) { maxfitnes = rocketsArray[i].Fitnes; }
            }
            for (int i = 0; i < rocketsArray.Length; i++)
            {
                rocketsArray[i].Fitnes /= maxfitnes;
            }

            matingPool = new List<Rocket>();
            for (int i = 0; i < rocketsArray.Length; i++)
            {
                var n = rocketsArray[i].Fitnes * 100;
                for (int k = 0; k < n; k++)
                {
                    matingPool.Add(rocketsArray[i]);
                }
            }
        }

        private void GrowSelection()
        {
            lifeTime = 0;

            for (int i = 0; i < rocketsArray.Length; i++)
            {
                var dna1 = matingPool.PickRandom().DNA;
                var dna2 = matingPool.PickRandom().DNA;
                var newDNA = dna1.Crossover(dna2, 0.3);
                rocketsArray[i] = new Rocket(newDNA);
            }

            MobilizePopulation();
        }

        private void RemoveRockets()
        {
            foreach (var rocket in rocketsArray)
            {
                rocket.RemoveFromCanvas();
            }
        }
    }
}
