namespace FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;
        private PlayerStats stats;
        private int playerRating;

        public Player(string name, PlayerStats stats)
        {
            this.Name = name;
            this.stats = stats;
            this.playerRating = stats.AverageStats;
        }

        internal string Name
        {
            get { return this.name; }

            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        internal int PlayerRating => this.playerRating;

    }
}