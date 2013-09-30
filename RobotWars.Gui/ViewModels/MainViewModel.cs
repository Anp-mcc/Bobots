using RobotWars.GeneticStuff;
using RobotWars.Gui.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RobotWars.Gui.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Privates

        private void InitDefaultPropertys()
        {
            PopulationSize = 100;
            GenesCount = 2;

            MaxGeneValue = 100;
            MinGeneValue = -100;

            GenerationCount = 10;
        }

        private void TestInitialize()
        {
            var fitnessCalculator = new FitnessCalculator();
            var individualFactory = new IndividualFactory(fitnessCalculator);
            var crossover = new Crossover(individualFactory);
            var selector = new TournamentSelector();
            var mutator = new Mutator(individualFactory, 0.1, 0.05);

            var evolutionManager = new EvolutionManager(crossover, selector, mutator, individualFactory);

            this.Evolution = new EvolutionManagerViewModel(evolutionManager);
        }

        #endregion

        public EvolutionManagerViewModel Evolution { get; set; }

        public MainViewModel()
        {
            InitDefaultPropertys();
            TestInitialize();
        }

        #region PublicPropertys

        public int PopulationSize { get; set; }
        public int GenesCount { get; set; }

        public double MaxGeneValue { get; set; }
        public double MinGeneValue { get; set; }

        public int GenerationCount { get; set; }

        #endregion

        #region Commands

        private ICommand _genSolutionCommand;

        public ICommand GenSolutionCommand
        {
            get
            {
                if (_genSolutionCommand == null)
                    _genSolutionCommand = new DelegateCommand(GenSolution);
                return _genSolutionCommand;
            }
        }

        private void GenSolution()
        {
            Evolution.GenSolution(PopulationSize, GenesCount, MaxGeneValue, MinGeneValue, GenerationCount);
            OnPropertyChanged("Evolution");
            TestInitialize();
        }

        #endregion
    }
}
