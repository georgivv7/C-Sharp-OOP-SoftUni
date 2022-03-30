using Loggers.Models.Interfaces;

namespace Loggers.Models
{
    internal class FileAppender : IAppender
    {
        private ILogFile logfile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logfile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logfile = logfile;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }
        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logfile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessagesAppended}, File size: {this.logfile.Size}";
            return result;
        }
    }
}