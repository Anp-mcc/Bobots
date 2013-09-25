using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal interface ICrossover
    {
        IEnumerable<IIndividual> GetChildren(IIndividual parent1, IIndividual parent2);
    }
}