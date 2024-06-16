namespace Core
{
    internal interface IStopwatchState
    {
        /// <summary>
        /// Checks if start/resume can be performed from current state.
        /// </summary>
        /// <returns><c>true</c> if start can be performed, <c>false</c> otherwise.</returns>
        bool CanStart();

        /// <summary>
        /// To start or resume the stopwatch.
        /// </summary>
        void Start();

        /// <summary>
        /// Checks if pause can be performed from current state.
        /// </summary>
        /// <returns><c>true</c> if pause can be performed, <c>false</c> otherwise.</returns>
        bool CanPause();

        /// <summary>
        /// To pause the stopwatch.
        /// </summary>
        void Pause();

        /// <summary>
        /// Checks if stop can be performed from current state.
        /// </summary>
        /// <returns><c>true</c> if stop can be performed, <c>false</c> otherwise.</returns>
        bool CanStop();

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
