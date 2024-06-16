using Core;
using Core.Common.Validation;

using StopwatchApplication.Commands;
using StopwatchApplication.Converters;
using StopwatchApplication.ViewModels;

namespace StopwatchApplication.Managers
{
    internal class StopwatchManager : IDisposable
    {
        private const int IntervalUpdateTime = 100;

        private readonly IStopwatchService _stopwatchService;
        private readonly TimeUnitsConverter _timeUnitsConverter;
        private CommandUpdater _commandUpdater;

        private bool _disposed;

        public StopwatchManager(IStopwatchService stopwatchService, TimeUnitsConverter timeUnitsConverter)
        {
            ParameterChecker.IsNotNull(stopwatchService, nameof(stopwatchService));
            ParameterChecker.IsNotNull(timeUnitsConverter, nameof(timeUnitsConverter));

            _stopwatchService = stopwatchService;
            _timeUnitsConverter = timeUnitsConverter;

            Hours = new NotifyingValue<short>();
            Minutes = new NotifyingValue<short>();
            Seconds = new NotifyingValue<short>();

            Task.Run(() =>
            {
                while (!_disposed)
                {
                    UpdateCount();
                    Thread.Sleep(IntervalUpdateTime);
                }
            });
        }

        public NotifyingValue<short> Hours { get; private set; }
        public NotifyingValue<short> Minutes { get; private set; }
        public NotifyingValue<short> Seconds { get; private set; }

        public void SetCommandsUpdater(CommandUpdater commandUpdater)
        {
            ParameterChecker.IsNotNull(commandUpdater, nameof(commandUpdater));

            _commandUpdater = commandUpdater;
        }

        public bool CanStartStopwatch()
        {
            return _stopwatchService.CanStart();
        }

        public void StartStopwatch()
        {
            _stopwatchService.Start();
            _commandUpdater.UpdateCommandsState();
        }

        public bool CanPauseStopwatch()
        {
            return _stopwatchService.CanPause();
        }
        public void PauseStopwatch()
        {
            _stopwatchService.Pause();
            _commandUpdater.UpdateCommandsState();
        }

        public bool CanStopStopwatch()
        {
            return _stopwatchService.CanStop();
        }

        public void StopStopwatch()
        {
            _stopwatchService.Stop();
            _commandUpdater.UpdateCommandsState();
        }

        private void UpdateCount()
        {
            long elapsedTime = _stopwatchService.GetElapsedTime();

            Seconds.Value = _timeUnitsConverter.GetSeconds(elapsedTime);
            Minutes.Value = _timeUnitsConverter.GetMinutes(elapsedTime);
            Hours.Value = _timeUnitsConverter.GetHours(elapsedTime);
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // No other resources to dispose
            }

            _disposed = true;
        }
    }
}
