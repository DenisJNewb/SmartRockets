using System.Threading.Tasks;

namespace SmartRockets
{
    public static class Population
    {
        private static Rocket[] rocketsArray;

        public static void GrowPopulation(int number)
        {
            rocketsArray = new Rocket[number];
            for (int i = 0; i < rocketsArray.Length; i++)
            {
                rocketsArray[i] = new Rocket();
            }
        }

        public async static void MobilizePopulation()
        {
            while (true)
            {
                for (int i = 0; i < rocketsArray.Length; i++)
                {
                    rocketsArray[i].Update();
                    rocketsArray[i].Show();
                }

                await Task.Delay(20);
            }
        }
    }
}
