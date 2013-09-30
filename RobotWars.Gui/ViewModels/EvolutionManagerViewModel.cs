using RobotWars.GeneticStuff;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Gui.ViewModels
{
    public class EvolutionManagerViewModel
    {
        private EvolutionManager _evolutionManager;
        private int _currIteration;

        public ObservableCollection<KeyValuePair<int, double>> BestFitness { get; set; }
        public ObservableCollection<KeyValuePair<int, double>> AverageFitness { get; set; }

        public EvolutionManagerViewModel(EvolutionManager evolutionManager)
        {
            this._evolutionManager = evolutionManager;
            this._evolutionManager.OnPopulationChanged += PopulationHandler;
            BestFitness = new ObservableCollection<KeyValuePair<int, double>>();
            AverageFitness = new ObservableCollection<KeyValuePair<int, double>>();
            _currIteration = 0;
        }

        private void PopulationHandler(object sender, GeneticStuff.Events.NewPopulationEventArgs args)
        {
            BestFitness.Add(new KeyValuePair<int,double>(_currIteration, args.MaxFitness));
            AverageFitness.Add(new KeyValuePair<int,double>(_currIteration, args.AverageFitness));
            _currIteration += 1;
        }

        internal void GenSolution(int PopulationSize, int GenesCount, double MaxGeneValue, double MinGeneValue, int GenerationCount)
        {
            _evolutionManager.GetSolution(PopulationSize, GenesCount, MaxGeneValue, MinGeneValue, GenerationCount);
        }
    }
}
