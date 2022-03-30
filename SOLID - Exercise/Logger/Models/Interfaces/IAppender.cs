using System;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Models.Interfaces
{
    public interface IAppender : ILevelable
    {
        ILayout Layout { get; }
        void Append(IError error);
    }
}
