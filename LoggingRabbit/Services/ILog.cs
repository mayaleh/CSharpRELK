using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingRabbit.Services
{
    public interface ILog
    {
        public void Information(string message);
        public void Warning(string message);
        public void Debug(string message);
        public void Error(string message);
    }
}
