using System;

namespace Bank
{
    internal class Logger
    {
        Action<string> _logger;

        public Logger()
        {
            _logger = null;
        }

        public Logger(Action<string> logger)
        {
            _logger = logger;
        }

        public void AddLogger(Action<string> logger)
        {
            _logger += logger;
        }

        public void RemoveLogger(Action<string> logger)
        {
            _logger -= logger;
        }

        public void Log(string message)
        {
            _logger?.Invoke(message);
        }
    }

}
