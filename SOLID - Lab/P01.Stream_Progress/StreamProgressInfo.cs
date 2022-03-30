using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress streamable;
        public StreamProgressInfo(IStreamProgress stream)
        {
            this.streamable = stream;
        }

        public int CalculateCurrentPercent() 
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
