using System;

namespace Codara.Application
{
    public sealed class ErrorHandler : IErrorHandler
    {
        public event Action<Exception> ErrorRaised;

        public void Handle(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            ErrorRaised?.Invoke(exception);
        }
    }
}
