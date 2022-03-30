using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Team> teams = new List<Team>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] info = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                switch (info[0])
                {
                    case "Team":
                        string teamName = info[1];
                        teams.Add(new Team(teamName));
                        break;
                    case "Add":
                        teamName = info[1];
                        string playerName = info[2];
                        int endurance = int.Parse(info[3]);
                        int sprint = int.Parse(info[4]);
                        int dribble = int.Parse(info[5]);
                        int passing = int.Parse(info[6]);
                        int shooting = int.Parse(info[7]);
                        Team team;
                        if (teams.Any(x => x.Name == teamName))
                        {
                            try
                            {
                                team = teams.First(x => x.Name == teamName);
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.AddPlayer(player);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;
                    case "Remove":
                        try
                        {
                            teamName = info[1];
                            team = teams.First(x => x.Name == teamName);
                            playerName = info[2];
                            team.RemovePlayer(playerName);

                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Rating":
                        teamName = info[1];
                        if (teams.Any(x => x.Name == teamName))
                        {
                            team = teams.First(x => x.Name == teamName);
                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;
                }
            }
        }
    }
}
