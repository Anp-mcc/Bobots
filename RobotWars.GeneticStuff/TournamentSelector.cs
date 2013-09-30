using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotWars.GeneticStuff
{
    public class TournamentSelector : ISelector
    {
        private const int TournamentSize = 2;

        private readonly Random _random;


        public TournamentSelector()
        {
            _random = new Random();
        }


        public Tuple<IIndividual, IIndividual> GetParents(IList<IIndividual> individuals)
        {
            var parent1 = GetParent(individuals);

            IIndividual parent2;
            do
            {
                parent2 = GetParent(individuals);
            } while (parent2 == parent1);//(parent2.Equals(parent1));

            return new Tuple<IIndividual, IIndividual>(parent1, parent2);
        }


        private IIndividual GetParent(IList<IIndividual> individuals)
        {
            var chosenIndividuals = new Dictionary<int, double>();

            for (var i = 0; i < TournamentSize; i++)
            {
                int index;
                do
                {
                    index = _random.Next(individuals.Count());    
                } 
                while (chosenIndividuals.ContainsKey(index));

                chosenIndividuals.Add(index, individuals[index].Fitness);
            }

            var individual = individuals[chosenIndividuals.Aggregate((x1, x2) => x1.Value > x2.Value ? x1 : x2).Key];

            return individual;
        }
    }
}
