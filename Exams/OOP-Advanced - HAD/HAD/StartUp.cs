namespace HAD
{
    using HAD.Contracts;
    using HAD.Core;
    using HAD.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            HeroManager heroManager = new HeroManager();
            ICommandProcessor commandProcessor = new CommandProcessor(heroManager);

            var engine = new Engine(reader,writer,commandProcessor);
            engine.Run();
        }
    }
}
