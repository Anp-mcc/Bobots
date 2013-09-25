using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal interface IFitnessCalculator
    {
        double CalculateFitness(IList<double> genes);
    }
}