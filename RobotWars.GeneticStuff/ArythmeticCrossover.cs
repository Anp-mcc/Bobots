using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal class Crossover : ICrossover
    {
        private const double Alpha = 0.3;
        
        private readonly IIndividualFactory _individualFactory;
        

        public Crossover(IIndividualFactory individualFactory)
        {
            _individualFactory = individualFactory;
        }


        public IEnumerable<IIndividual> GetChildren(IIndividual parent1, IIndividual parent2)
        {
            var genes1 = new List<double>();
            var genes2 = new List<double>();

            for (var i = 0; i < parent1.Genes.Count; i++)
            {
                genes1.Add(parent1.Genes[i] + Alpha*(parent2.Genes[i] - parent1.Genes[i]));
                genes2.Add(parent2.Genes[i] - Alpha*(parent2.Genes[i] - parent1.Genes[i]));
            }

            var individual1 = _individualFactory.GenerateIndividual(genes1);
            var individual2 = _individualFactory.GenerateIndividual(genes2);

            var individuals = new List<IIndividual> {individual1, individual2};

            return individuals;
        }
    }
}
