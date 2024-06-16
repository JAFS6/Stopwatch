using Core.Common.Validation;

namespace Core.StopwatchStates
{
    /// <summary>
    /// Base class for stopwatch states. Uses State pattern.
    /// </summary>
    internal abstract class StateBase : IStopwatchState
    {
        protected readonly Stopwatch _context;

        public StateBase(Stopwatch context)
        {
            ParameterChecker.IsNotNull(context, nameof(context));

            _context = context;
        }

        public abstract bool CanStart();

        public abstract void Start();

        public abstract bool CanPause();

        public abstract void Pause();

        public abstract bool CanStop();

        public abstract void Stop();

        public abstract long GetElapsedTime();
    }
}
