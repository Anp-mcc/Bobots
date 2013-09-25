using System;
using System.Collections.Generic;

namespace RobotWars.GeneticStuff
{
    internal class Individual : IIndividual, IComparable
    {
        private const double Epsilon = 0.0000000001;

        public IList<double> Genes { get; private set; }
        public double Fitness { get; private set; }


        public Individual(IList<double> genes, double fitness )
        {
            Genes = genes;
            Fitness = fitness;
        }


        public override bool Equals(object obj)
        {
            var individual = (IIndividual) obj;

            for (var i = 0; i < Genes.Count; i++)
            {
                if (Math.Abs(Genes[i] - individual.Genes[i]) > Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        public int CompareTo(object obj)
        {
            var individual = (IIndividual) obj;

            return Fitness.CompareTo(individual.Fitness);
        }
    }
}
