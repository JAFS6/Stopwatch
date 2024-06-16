using Core.Common.Validation;

namespace StopwatchApplication.Commands
{
    internal class CommandUpdater
    {
        private readonly RelayCommand _startCommand;
        private readonly RelayCommand _pauseCommand;
        private readonly RelayCommand _stopCommand;

        public CommandUpdater(RelayCommand startCommand, RelayCommand pauseCommand, RelayCommand stopCommand)
        {
            ParameterChecker.IsNotNull(startCommand, nameof(startCommand));
            ParameterChecker.IsNotNull(pauseCommand, nameof(pauseCommand));
            ParameterChecker.IsNotNull(stopCommand, nameof(stopCommand));

            _startCommand = startCommand;
            _pauseCommand = pauseCommand;
            _stopCommand = stopCommand;
        }

        public void UpdateCommandsState()
        {
            _startCommand.RaiseCanExecuteChanged();
            _pauseCommand.RaiseCanExecuteChanged();
            _stopCommand.RaiseCanExecuteChanged();
        }
    }
}
