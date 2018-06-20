using System;
using System.Collections.Generic;
using System.Linq;


namespace CuttingStock
{
    class Program
    {
        //The possible lengths of plank
        static List<float> PossibleLengths = new List<float> { 450, 900, 1200, 1800 };

        private static void Main(string[] args)
        {
            //The cuts to be made
            List<float> DesiredLengths = new List<float> { 775, 775, 400, 400, 1350, 550, 550, 1150, 1150, 750, 750, 750, 750, 750, 750, 750 };

            //Perform some basic optimisations
            DesiredLengths.Sort();
            DesiredLengths.Reverse();

            //Cut!
            var planks = CalculateCuts(DesiredLengths);

            Console.WriteLine();
            foreach (var plank in planks)
            {
                Console.WriteLine("Cut a {0} long plank by: {1} to end up with {2} waste.", plank.OriginalLength, string.Join(", ", plank.Cuts), plank.FreeLength);
            }

            Console.WriteLine("Finished with {0} waste", GetFree(planks));

            Console.ReadKey();
        }

        //Calculate how much waste/free length is left in a list of planks
        private static float GetFree(List<Plank> planks)
        {
            float free = 0;

            foreach (var plank in planks)
            {
                free += plank.FreeLength;
            }
            return free;
        }

        private static List<Plank> CalculateCuts(List<float> desired)
        {
            var planks = new List<Plank>(); //Buffer list

            //go through cuts
            foreach (var i in desired)
            {
                //if no eligible planks can be found
                if (!planks.Any(plank => plank.FreeLength >= i))
                {
                    //make a plank
                    planks.Add(new Plank(PossibleLengths.Max()));
                }

                //cut where possible
                foreach (var plank in planks.Where(plank => plank.FreeLength >= i))
                {
                    plank.Cut(i);
                    break;
                }

            }

            //cut down on waste by minimising length of plank
            foreach (var plank in planks)
            {
                float newLength = plank.OriginalLength;
                foreach (float possibleLength in PossibleLengths)
                {
                    if (possibleLength != plank.OriginalLength && plank.OriginalLength - plank.FreeLength <= possibleLength)
                    {
                        newLength = possibleLength;
                        break;
                    }
                }
                plank.OriginalLength = newLength;
            }

            return planks;
        }
    }

    //class for a generic 'plank'
    class Plank
    {
        public Plank(float length)
        {
            OriginalLength = length;
        }

        public float FreeLength
        {
            get { return OriginalLength - Cuts.Sum(); }
        }

        public float OriginalLength;

        public List<float> Cuts = new List<float>();

        public void Cut(float cutLength)
        {
            Cuts.Add(cutLength);
        }

    }

}
