using Core.Common.Validation;

using StopwatchApplication.Commands;

namespace StopwatchApplication.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel(
            TwoDigitsNumberDisplayViewModel hours,
            TwoDigitsNumberDisplayViewModel minutes,
            TwoDigitsNumberDisplayViewModel seconds,
            RelayCommand startCommand,
            RelayCommand pauseCommand,
            RelayCommand stopCommand)
        {
            ParameterChecker.IsNotNull(hours, nameof(hours));
            ParameterChecker.IsNotNull(hours, nameof(minutes));
            ParameterChecker.IsNotNull(hours, nameof(seconds));

            HoursViewModel = hours;
            MinutesViewModel = minutes;
            SecondsViewModel = seconds;

            StartCommand = startCommand;
            PauseCommand = pauseCommand;
            StopCommand = stopCommand;
        }


        public TwoDigitsNumberDisplayViewModel HoursViewModel { get; private set; }
        public TwoDigitsNumberDisplayViewModel MinutesViewModel { get; private set; }
        public TwoDigitsNumberDisplayViewModel SecondsViewModel { get; private set; }

        public RelayCommand StartCommand { get; private set; }
        public RelayCommand PauseCommand { get; private set; }
        public RelayCommand StopCommand { get; private set; }
    }
}
