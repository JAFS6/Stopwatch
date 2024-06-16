namespace Core.StopwatchStates
{
    internal class Running : StateBase
    {
        public Running(Stopwatch context) : base(context)
        {
        }

        public override void Start()
        {
            throw new InvalidOperationException("Already started.");
        }

        public override void Pause()
        {
            _context.RegisterTime();
            _context.ChangeState(States.Paused);
        }

        public override void Stop()
        {
            _context.ClearTimeRegisters();
            _context.ChangeState(States.Ready);
        }

        public override long GetElapsedTime()
        {
            var current = DateTime.Now;
            var lastRegister = _context.Times.Last();

            double totalElapsedTime = 0;

            for (int i = 0; i < _context.Times.Count - 1; i += 2)
            {
                double blockElapsedTime = (_context.Times[i + 1] - _context.Times[i]).TotalMilliseconds;
                totalElapsedTime += blockElapsedTime;
            }

            double lastBlockElapsedTime = (current - lastRegister).TotalMilliseconds;
            totalElapsedTime += lastBlockElapsedTime;

            return (long)totalElapsedTime;
        }
    }
}
