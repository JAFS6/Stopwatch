using System.Windows;

using Core.Common.Validation;

namespace StopwatchApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private readonly IDisposable _manager;
        private bool _disposed;

        public MainWindow(IDisposable manager)
        {
            ParameterChecker.IsNotNull(manager, nameof(manager));

            _manager = manager;

            InitializeComponent();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _manager.Dispose();
            }

            _disposed = true;
        }
    }
}