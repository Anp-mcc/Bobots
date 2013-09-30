using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.GeneticStuff
{
    public class FitnessCalculator : IFitnessCalculator
    {
        public double CalculateFitness(IList<double> genes)
        {
            return -genes.Sum(x => x*x);
        }
    }
}