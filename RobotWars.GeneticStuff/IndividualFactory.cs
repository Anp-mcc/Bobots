using System;
using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    public class IndividualFactory : IIndividualFactory
    {
        private IFitnessCalculator _fitnessCalculator;

        private readonly Random _random;


        public IndividualFactory(IFitnessCalculator fitnessCalculator)
        {
            _fitnessCalculator = fitnessCalculator;

            _random = new Random();
        }


        public IIndividual GenerateIndividual(IList<double> genes)
        {
            var fitness = _fitnessCalculator.CalculateFitness(genes);
            return new Individual(genes, fitness);
        }

        public IIndividual GetRandomIndividual(int genesCount, double maxGenesValue, double minGenesValue)
        {
            var genes = new List<double>();

            for (var i = 0; i < genesCount; i++)
            {
                genes.Add(minGenesValue + (maxGenesValue - minGenesValue)*_random.NextDouble());
            }

            return GenerateIndividual(genes);
        }
    }
} 