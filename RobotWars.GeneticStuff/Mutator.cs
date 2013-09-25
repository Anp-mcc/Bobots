using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.GeneticStuff
{
    internal class Mutator : IMutator
    {
        private readonly IIndividualFactory _individualFactory;

        private readonly double _mutationProbability;
        private readonly double _mutationStrength;

        private readonly Random _random;


        public Mutator(IIndividualFactory individualFactory, double mutationProbability, double mutationStrength)
        {
            _individualFactory = individualFactory;
            _mutationProbability = mutationProbability;
            _mutationStrength = mutationStrength;

            _random = new Random();
        }


        public IIndividual Mutate(IIndividual individual)
        {
            var newGenes = new List<double>();
            
            foreach (var gene in individual.Genes)
            {
                if (_random.NextDouble() < _mutationProbability)
                {
                    newGenes.Add(gene*(1 + (2*_random.NextDouble() - 1)*_mutationStrength));
                }
                else
                {
                    newGenes.Add(gene);
                }
            }

            return _individualFactory.GenerateIndividual(newGenes);
        }
    }
}