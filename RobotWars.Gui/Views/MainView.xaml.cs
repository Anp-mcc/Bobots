using RobotWars.Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RobotWars.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        ObservableCollection<KeyValuePair<double, double>> Power = new ObservableCollection<KeyValuePair<double, double>>();

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();   
        }
        
    }
}
