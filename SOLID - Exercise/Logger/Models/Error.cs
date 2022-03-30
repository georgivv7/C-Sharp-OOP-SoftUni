using Loggers.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }
        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
