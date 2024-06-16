using System.Windows;

using StopwatchApplication.Factories;

namespace StopwatchApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowFactory factory = new MainWindowFactory();
            MainWindow mainWindow = factory.Create();
            mainWindow.Show();
        }
    }
}
