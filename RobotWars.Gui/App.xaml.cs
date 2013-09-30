using RobotWars.Gui.Views;
using System.Windows;

namespace RobotWars.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void OnStartup(object sender, StartupEventArgs e)
        {
            MainView main = new MainView();
            main.Show();
        }
    }
}
