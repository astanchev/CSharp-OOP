namespace FootballTeamGenerator
{
    using System;
    public class PlayerStats
    {
        private const int MinStatsValue = 0;
        private const int MaxStatsValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private int averageStats;

        public PlayerStats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.averageStats = (int)Math.Round((endurance + sprint + dribble + passing + shooting)/5.0);
        }
        private int Endurance
        {
            set
            {
                ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        private int Sprint
        {
            set
            {
                ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        private int Dribble
        {
            set
            {
                ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        private int Passing
        {
            set
            {
                ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        private int Shooting
        {
            set
            {
                ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        public int AverageStats => this.averageStats;
        private static void ValidateStat(int stat, string propertyName)
        {
            if (stat < MinStatsValue || stat > MaxStatsValue)
            {
                throw new ArgumentException($"{propertyName} should be between 0 and 100.");
            }
        }
    }
}