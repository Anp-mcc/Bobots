using System;
using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal interface ISelector
    {
        Tuple<IIndividual, IIndividual> GetParents(IList<IIndividual> individuals);
    }
}