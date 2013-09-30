using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public interface IIndividual
    {
        IList<double> Genes { get; }
        double Fitness { get; }
    }
}