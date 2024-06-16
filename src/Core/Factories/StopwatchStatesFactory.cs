using Core.StopwatchStates;

namespace Core.Factories
{
    internal class StopwatchStatesFactory
    {
        public IStopwatchState Create(States state, Stopwatch context)
        {
            switch (state)
            {
                case States.Ready:
                    return new Ready(context);
                case States.Running:
                    return new Running(context);
                case States.Paused:
                    return new Paused(context);
                default:
                    throw new InvalidOperationException($"No creationn method for state {state.ToString()}");
            }
        }
    }
}
