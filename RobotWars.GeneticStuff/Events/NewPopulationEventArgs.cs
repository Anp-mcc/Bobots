using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.GeneticStuff.Events
{
    public class NewPopulationEventArgs : EventArgs
    {
        public double MaxFitness { get; set; }
        public double AverageFitness { get; set; }

        public NewPopulationEventArgs(double maxFitness, double averageFitness)
        {
            this.MaxFitness = maxFitness;
            this.AverageFitness = averageFitness;
        }
    }
}
