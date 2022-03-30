using System;

namespace Loggers.Models.Interfaces
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }
        string Message { get; }
    }
}