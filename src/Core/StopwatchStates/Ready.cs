namespace Core.StopwatchStates
{
    internal class Ready : StateBase
    {
        public Ready(Stopwatch context) : base(context)
        {
        }

        public override void Start()
        {
            _context.RegisterTime();
            _context.ChangeState(States.Running);
        }

        public override void Pause()
        {
            throw new InvalidOperationException("Not started yet.");
        }

        public override void Stop()
        {
            throw new InvalidOperationException("Already stopped.");
        }

        public override long GetElapsedTime()
        {
            return 0;
        }
    }
}
