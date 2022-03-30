using System;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Models.Interfaces
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}
