using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongLengthException : InvalidSongNameException
{
    public InvalidSongLengthException(string message = "Invalid song length.")
        : base(message)
    {

    }
}

