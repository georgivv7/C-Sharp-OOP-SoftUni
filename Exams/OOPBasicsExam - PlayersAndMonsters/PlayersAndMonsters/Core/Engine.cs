namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using System;
    public class Engine : IEngine
    {
        public void Run()
        {
            PlayerRepository playerRepository = new PlayerRepository();
            CardRepository cardRepository = new CardRepository();
            BattleField battleField = new BattleField();

            ManagerController manager = new ManagerController(playerRepository, cardRepository, battleField);
            
            
            while (true)
            {
                var reader = new Reader();
                var writer = new Writer();
                string input = reader.ReadLine();
                if (input == "Exit")
                {
                    break;
                }
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            string type = commandArgs[1];
                            string name = commandArgs[2];
                            writer.WriteLine(manager.AddPlayer(type, name));
                            break;
                        case "AddCard":
                            type = commandArgs[1];
                            name = commandArgs[2];
                            writer.WriteLine(manager.AddCard(type, name));
                            break;
                        case "AddPlayerCard":
                            string username = commandArgs[1];
                            string cardname = commandArgs[2];
                            writer.WriteLine(manager.AddPlayerCard(username, cardname));
                            break;
                        case "Fight":
                            string attacker = commandArgs[1];
                            string enemy = commandArgs[2];
                            writer.WriteLine(manager.Fight(attacker, enemy));
                            break;
                        case "Report":
                            writer.WriteLine(manager.Report());
                            break;
                    }
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }
                
            }
        }
    }
}
