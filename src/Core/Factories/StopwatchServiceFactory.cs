namespace Core.Factories
{
    public class StopwatchServiceFactory
    {
        public IStopwatchService Create()
        {
            return new Stopwatch();
        }
    }
}
