using Loggers.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Models
{
    public class Logger : ILogger
    {
        ICollection<IAppender> appenders;
        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;
        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
