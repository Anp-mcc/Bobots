using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public interface IFitnessCalculator
    {
        double CalculateFitness(IList<double> genes);
    }
}