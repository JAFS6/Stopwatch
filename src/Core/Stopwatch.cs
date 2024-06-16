using Core.StopwatchStates;

namespace Core
{
    public class Stopwatch
    {
        private IStopwatchState _state;

        /// <summary>
        /// Time records to avoid counting thread. A new record is added when starting or pausing.
        /// </summary>
        /// <remarks>
        /// Total elapsed time will be calculated as the sum of the differences of the pairs of time records in paused state.
        /// If on running state, difference between current time and last recorded time will be summed up.
        /// </remarks>
        public readonly IList<DateTime> Times;

        public Stopwatch()
        {
            Times = new List<DateTime>();
            _state = new Ready(this);
        }

        public void ChangeState(States newState)
        {
            switch (newState)
            {
                case States.Ready:
                    _state = new Ready(this);
                    break;
                case States.Running:
                    _state = new Running(this);
                    break;
                case States.Paused:
                    _state = new Paused(this);
                    break;
            }
        }

        public void RegisterTime()
        {
            Times.Add(DateTime.Now);
        }

        public void ClearTimeRegisters()
        {
            Times.Clear();
        }
    }
}
