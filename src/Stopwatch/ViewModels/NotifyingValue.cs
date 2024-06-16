namespace StopwatchApplication.ViewModels
{
    internal class NotifyingValue<T> : NotifyBase
    {
        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }
    }
}
