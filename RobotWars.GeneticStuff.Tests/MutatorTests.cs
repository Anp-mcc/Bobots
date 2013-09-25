using NUnit.Framework;

namespace RobotWars.GeneticStuff.Tests
{
    [TestFixture]
    public class MutatorTests
    {
        private Mutator _target;


        [SetUp]
        public void Setup()
        {
            var fitnessCalculator = new FitnessCalculator();
            var individualFactory = new IndividualFactory(fitnessCalculator);

            _target = new Mutator(individualFactory, 0.1, 0.05);
        }


        [Test]
        public void Mutate()
        {
            //IIndividual individual = new Individual();

            //_target.Mutate(individual);
        }
    }
}
