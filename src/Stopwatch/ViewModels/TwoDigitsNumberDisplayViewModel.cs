using Core.Common.Validation;

namespace StopwatchApplication.ViewModels
{
    internal class TwoDigitsNumberDisplayViewModel : NotifyBase
    {
        private string _number;
        private NotifyingValue<short> _valueModel;

        public TwoDigitsNumberDisplayViewModel(NotifyingValue<short> valueModel)
        {
            ParameterChecker.IsNotNull(valueModel, nameof(valueModel));

            _valueModel = valueModel;
            _number = "00";
            _valueModel.PropertyChanged += _valueModel_PropertyChanged;
        }

        public string Number
        {
            get
            {
                return _number;
            }

            private set
            {
                if (value != _number)
                {
                    _number = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void _valueModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_valueModel.Value))
            {
                Number = _valueModel.Value.ToString("D2");
            }
        }
    }
}