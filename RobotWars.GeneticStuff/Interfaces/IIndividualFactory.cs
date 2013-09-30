using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public interface IIndividualFactory
    {
        IIndividual GenerateIndividual(IList<double> genes);
        IIndividual GetRandomIndividual(int genesCount, double maxGenesValue, double minGenesValue);
    }
}
