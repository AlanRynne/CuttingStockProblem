using System;
using System.Collections.Generic;
using System.Linq;


namespace CuttingStockComponent
{
    class CuttingStockClass
    {
        //The possible or available lengths of planks in stock
        static List<double> PossibleLengths;
        //The list of lengths TO CUT
        public List<double> DesiredLengths;
        public List<String> DesiredLengthsLabels;

        public CuttingStockClass(List<double> cuts, List<double> stockLengths, List<String> cutLabels )
        {
            DesiredLengths = cuts;
            PossibleLengths = stockLengths;
            DesiredLengthsLabels = cutLabels;
        }

        //
        public List<String> CutStock()
        {
            List<string> textResults = new List<string>();

            //Perform some basic optimisations
            //DesiredLengths.Sort();
            //DesiredLengths.Reverse();

            //Cut!
            var planks = CalculateCuts(DesiredLengths);

            foreach (var plank in planks)
            {
                String st = String.Format("Cut a {0} long plank by: {1} to end up with {2} waste. Labels: {3}", plank.OriginalLength, string.Join(", ", plank.Cuts), plank.FreeLength, string.Join(", ", plank.CutsLabels));
                textResults.Add(st);
            }

            textResults.Add(String.Format("Finished with {0} waste", GetFree(planks)));
            
            return textResults; 
        }
        //Calculate how much waste/free length is left in a list of planks
        private static double GetFree(List<Plank> planks)
        {
            double free = 0;

            foreach (var plank in planks)
            {
                free += plank.FreeLength;
            }
            return free;
        }

        private List<Plank> CalculateCuts(List<double> desired)
        {
            var planks = new List<Plank>(); //Buffer list

            //go through cuts
            for (int j = 0; j < desired.Count; j++)
            {
                double i = desired[j];
                //if no eligible planks can be found
                if (!planks.Any(plank => plank.FreeLength >= i))
                {
                    //make a plank
                    planks.Add(new Plank(PossibleLengths.Max()));
                }

                //cut where possible
                foreach (var plank in planks.Where(plank => plank.FreeLength >= i))
                {
                    plank.CutWithLabel(i,DesiredLengthsLabels[j]);
                    break;
                }

            }

            //cut down on waste by minimising length of plank
            foreach (var plank in planks)
            {
                double newLength = plank.OriginalLength;
                foreach (double possibleLength in PossibleLengths)
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
        public Plank(double length)
        {
            OriginalLength = length;
        }

        public double FreeLength
        {
            get { return OriginalLength - Cuts.Sum(); }
        }

        public double OriginalLength;

        public List<double> Cuts = new List<double>();
        public List<String> CutsLabels = new List<string>();

        public void Cut(double cutLength)
        {
            Cuts.Add(cutLength);
        }

        public void CutWithLabel(double cutLength, String label)
        {
            Cut(cutLength);
            CutsLabels.Add(label);
        }

    }

}
