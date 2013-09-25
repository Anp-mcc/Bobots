using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RobotWars.GeneticStuff.Tests
{
    [TestFixture]
    public class EvolutionManagerTests
    {
        [Test]
        public void GetSolution()
        {
            var fitnessCalculator = new FitnessCalculator();
            var individualFactory = new IndividualFactory(fitnessCalculator);
            var crossover = new Crossover(individualFactory);
            var selector = new TournamentSelector();
            var mutator = new Mutator(individualFactory, 0.1, 0.05);

            var evolutionManager = new EvolutionManager(crossover, selector, mutator, individualFactory);

            var result = evolutionManager.GetSolution(100, 2, 100, -100, 1000);

            Assert.Greater(0.0001, Math.Abs(result.ElementAt(0)));
            Assert.Greater(0.0001, Math.Abs(result.ElementAt(1)));
        }

    }
}
