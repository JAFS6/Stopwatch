using Core;
using Core.Common.Validation;

using StopwatchApplication.Commands;
using StopwatchApplication.Converters;
using StopwatchApplication.ViewModels;

namespace StopwatchApplication.Managers
{
    internal class StopwatchManager
    {
        private const int IntervalUpdateTime = 100;

        private readonly Stopwatch _stopwatchModel;
        private readonly TimeUnitsConverter _timeUnitsConverter;
        private CommandUpdater _commandUpdater;

        public StopwatchManager(Stopwatch stopwatch, TimeUnitsConverter timeUnitsConverter)
        {
            ParameterChecker.IsNotNull(stopwatch, nameof(stopwatch));
            ParameterChecker.IsNotNull(timeUnitsConverter, nameof(timeUnitsConverter));

            _stopwatchModel = stopwatch;
            _timeUnitsConverter = timeUnitsConverter;

            Hours = new NotifyingValue<short>();
            Minutes = new NotifyingValue<short>();
            Seconds = new NotifyingValue<short>();

            Task.Run(() =>
            {
                while (true)
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
            return _stopwatchModel.CanStart();
        }

        public void StartStopwatch()
        {
            _stopwatchModel.Start();
            _commandUpdater.UpdateCommandsState();
        }

        public bool CanPauseStopwatch()
        {
            return _stopwatchModel.CanPause();
        }
        public void PauseStopwatch()
        {
            _stopwatchModel.Pause();
            _commandUpdater.UpdateCommandsState();
        }

        public bool CanStopStopwatch()
        {
            return _stopwatchModel.CanStop();
        }

        public void StopStopwatch()
        {
            _stopwatchModel.Stop();
            _commandUpdater.UpdateCommandsState();
        }

        private void UpdateCount()
        {
            long elapsedTime = _stopwatchModel.GetElapsedTime();

            Seconds.Value = _timeUnitsConverter.GetSeconds(elapsedTime);
            Minutes.Value = _timeUnitsConverter.GetMinutes(elapsedTime);
            Hours.Value = _timeUnitsConverter.GetHours(elapsedTime);
        }
    }
}
