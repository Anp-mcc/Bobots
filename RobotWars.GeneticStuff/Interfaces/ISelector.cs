using System;
using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public interface ISelector
    {
        Tuple<IIndividual, IIndividual> GetParents(IList<IIndividual> individuals);
    }
}