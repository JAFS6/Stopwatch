namespace Core.StopwatchStates
{
    internal class Paused : StateBase
    {
        public Paused(Stopwatch context) : base(context)
        {
        }

        public override void Start()
        {
            _context.RegisterTime();
            _context.ChangeState(States.Running);
        }

        public override void Pause()
        {
            throw new InvalidOperationException("Already paused.");
        }

        public override void Stop()
        {
            _context.ClearTimeRegisters();
            _context.ChangeState(States.Ready);
        }

        public override long GetElapsedTime()
        {
            double totalElapsedTime = 0;

            for (int i = 0; i < _context.Times.Count; i += 2)
            {
                double blockElapsedTime = (_context.Times[i + 1] - _context.Times[i]).TotalMilliseconds;
                totalElapsedTime += blockElapsedTime;
            }

            return (long)totalElapsedTime;
        }
    }
}
