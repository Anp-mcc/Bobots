using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal interface IIndividualFactory
    {
        IIndividual GenerateIndividual(IList<double> genes);
        IIndividual GetRandomIndividual(int genesCount, double maxGenesValue, double minGenesValue);
    }
}
