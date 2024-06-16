namespace Core.StopwatchStates
{
    internal class Ready : StateBase
    {
        public Ready(Stopwatch context) : base(context)
        {
        }

        public override bool CanStart()
        {
            return true;
        }

        public override void Start()
        {
            _context.RegisterTime();
            _context.ChangeState(States.Running);
        }

        public override bool CanPause()
        {
            return false;
        }

        public override void Pause()
        {
            throw new InvalidOperationException("Not started yet.");
        }

        public override bool CanStop()
        {
            return false;
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
