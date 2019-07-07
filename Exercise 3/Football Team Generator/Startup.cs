namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {
            teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] commandLine = input.Split(';');
                string command = commandLine[0];
                string teamName = commandLine[1];

                Team team = null;

                try
                {
                    team = CheckTeam(command, team, teamName);

                    switch (command)
                    {
                        case "Team":
                            AddTeam(teamName);
                            break;
                        case "Add":
                            AddPlayer(commandLine, team);
                            break;
                        case "Remove":
                            RemovePlayer(commandLine, team);
                            break;
                        case "Rating":
                            PrintRating(team);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Team CheckTeam(string command, Team team, string teamName)
        {
            if (command != "Team")
            {
                team = FindTeam(teamName);

                IsTeamExist(team, teamName);
            }

            return team;
        }

        private static void AddPlayer(string[] commandLine, Team team)
        {
            PlayerStats stats = new PlayerStats( int.Parse(commandLine[3]), int.Parse(commandLine[4]),
                int.Parse(commandLine[5]), int.Parse(commandLine[6]), int.Parse(commandLine[7]));


            var player = new Player(commandLine[2], stats);

            team.AddPlayer(player);
        }

        private static void PrintRating(Team team)
        {
            Console.WriteLine($"{team.Name} - {team.Rating}");
        }

        private static void RemovePlayer(string[] commandLine, Team team)
        {
            string playerName = commandLine[2];
            team.RemovePlayer(playerName);
        }

        private static Team FindTeam(string teamName)
        {
            return teams.FirstOrDefault(t => t.Name == teamName);
        }

        private static void IsTeamExist(Team team, string teamName)
        {
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }

        private static void AddTeam(string teamName)
        {
            Team teamToAdd = new Team(teamName);

            teams.Add(teamToAdd);
        }
    }
}
