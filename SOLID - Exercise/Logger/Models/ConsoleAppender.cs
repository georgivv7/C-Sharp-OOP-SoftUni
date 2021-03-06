using Loggers.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loggers.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            MessagesAppended = 0;
        }
        public int MessagesAppended { get; private set; }
        public ILayout Layout { get; }
        public ErrorLevel Level { get; }
        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
