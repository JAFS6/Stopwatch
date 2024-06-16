using Core.Factories;

using StopwatchApplication.Commands;
using StopwatchApplication.Converters;
using StopwatchApplication.Managers;
using StopwatchApplication.ViewModels;

namespace StopwatchApplication.Factories
{
    internal class MainWindowFactory
    {
        public MainWindow Create()
        {
            var stopwatchServiceFactory = new StopwatchServiceFactory();
            var stopwatchService = stopwatchServiceFactory.Create();
            var timeUnitsConverter = new TimeUnitsConverter();

            var manager = new StopwatchManager(stopwatchService, timeUnitsConverter);

            var startCommand = new RelayCommand(x => manager.StartStopwatch(), x => manager.CanStartStopwatch());
            var pauseCommand = new RelayCommand(x => manager.PauseStopwatch(), x => manager.CanPauseStopwatch());
            var stopCommand = new RelayCommand(x => manager.StopStopwatch(), x => manager.CanStopStopwatch());

            var commandUpdater = new CommandUpdater(startCommand, pauseCommand, stopCommand);
            manager.SetCommandsUpdater(commandUpdater);

            var hoursViewModel = new TwoDigitsNumberDisplayViewModel(manager.Hours);
            var minutesViewModel = new TwoDigitsNumberDisplayViewModel(manager.Minutes);
            var secondsViewModel = new TwoDigitsNumberDisplayViewModel(manager.Seconds);

            var mainWindowViewModel = new MainWindowViewModel(hoursViewModel, minutesViewModel, secondsViewModel, startCommand, pauseCommand, stopCommand);

            var mainWindow = new MainWindow(manager);
            mainWindow.DataContext = mainWindowViewModel;
            return mainWindow;
        }
    }
}
