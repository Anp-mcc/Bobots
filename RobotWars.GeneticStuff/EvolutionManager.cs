using RobotWars.GeneticStuff.Events;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.GeneticStuff
{
    public class EvolutionManager
    {
        private readonly ICrossover _crossover;
        private readonly ISelector _selector;
        private readonly IMutator _mutator;
        private readonly IIndividualFactory _individualFactory;


        public EvolutionManager(ICrossover crossover, ISelector selector, IMutator mutator, IIndividualFactory individualFactory)
        {
            _crossover = crossover;
            _selector = selector;
            _mutator = mutator;
            _individualFactory = individualFactory;
        }
            

        public IEnumerable<double> GetSolution(int populationSize, int genesCount, double MaxGeneValue, double minGeneValue, int maxGenerationCount)
        {
            var population = InitPopulation(populationSize, genesCount, MaxGeneValue, minGeneValue);

            for (var i = 0; i < maxGenerationCount; i++) 
            {
                var children = new List<IIndividual>();

                while (children.Count < population.Count)
                {
                    var parents = _selector.GetParents(population);

                    var newBornChildren = _crossover.GetChildren(parents.Item1, parents.Item2);

                    children.AddRange(newBornChildren.Select(x => _mutator.Mutate(x)));
                }
                RaisePopulationChanged(population);
                population.AddRange(children);
                
                population = population.OrderByDescending(x => x.Fitness).ToList();
                population.RemoveRange(populationSize, populationSize);
            }

            return population[0].Genes;
        }

        #region EventDeclaration

        public delegate void NewPopulationEventHandler(object sender, NewPopulationEventArgs args);

        public event NewPopulationEventHandler OnPopulationChanged;

        private void RaisePopulationChanged(List<IIndividual> population)
        {
            double avg = population.Average(x => x.Fitness);
            double max = population.Max(x => x.Fitness);

            OnPopulationChanged(this, new NewPopulationEventArgs(max, avg));
        }

        #endregion


        private List<IIndividual> InitPopulation(int populationSize, int genesCount, double MaxGeneValue, double minGeneValue)
        {
            var population = new List<IIndividual>();

            for (var i = 0; i < populationSize; i++)
            {
                population.Add(_individualFactory.GetRandomIndividual(genesCount, MaxGeneValue, minGeneValue));
            }

            return population;
        }
    }
}
