using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public interface ICrossover
    {
        IEnumerable<IIndividual> GetChildren(IIndividual parent1, IIndividual parent2);
    }
}