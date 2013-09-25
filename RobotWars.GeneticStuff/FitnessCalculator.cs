using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.GeneticStuff
{
    internal class FitnessCalculator : IFitnessCalculator
    {
        public double CalculateFitness(IList<double> genes)
        {
            return -genes.Sum(x => x*x);
        }
    }
}