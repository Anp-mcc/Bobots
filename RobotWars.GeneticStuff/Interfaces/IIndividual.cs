using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal interface IIndividual
    {
        IList<double> Genes { get; }
        double Fitness { get; }
    }
}