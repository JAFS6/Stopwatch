namespace Core
{
    internal interface IStopwatchState
    {
        /// <summary>
        /// To start or resume the stopwatch.
        /// </summary>
        void Start();

        /// <summary>
        /// To pause the stopwatch.
        /// </summary>
        void Pause();

        /// <summary>
        /// To stop the stopwatch and restart count.
        /// </summary>
        void Stop();

        /// <summary>
        /// Get the elapsed time from the start of the count.
        /// </summary>
        /// <returns>The number of milliseconds elapsed since the start of the count.</returns>
        long GetElapsedTime();
    }
}
