using System.Windows;

using StopwatchApplication.Factories;

namespace StopwatchApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowFactory factory = new MainWindowFactory();
            _mainWindow = factory.Create();
            _mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mainWindow.Dispose();
            base.OnExit(e);
        }
    }
}
