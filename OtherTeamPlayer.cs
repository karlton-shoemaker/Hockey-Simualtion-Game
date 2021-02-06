using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class OtherTeamPlayer
    {
        public string Team { get; }
        public int fightStamina;
        public int penaltyTime;

        public string Name { get; }
        public string Number { get; }
        public string Position { get; }
        public int FightStamina
        {
            get
            {
                return fightStamina;
            }
            set
            {
                fightStamina = value;
                if (fightStamina < 0)
                {
                    fightStamina = 0;
                }
                if (fightStamina > 100)
                {
                    fightStamina = 100;
                }
            }
        }
        public int PenaltyTime
        {
            get
            {
                return penaltyTime;
            }
            set
            {
                penaltyTime = value;
                if (penaltyTime < 0)
                {
                    penaltyTime = 0;
                }
            }
        }

        public OtherTeamPlayer()
        {

        }

        public OtherTeamPlayer(string name, string number, string position, string team)
        {
            Name = name;
            Number = number;
            Position = position;
            Team = team;
            PenaltyTime = 0;
        }

        public void TeamStatDisplay(OtherTeamPlayer otherTeamPlayer)
        {
            if (otherTeamPlayer.PenaltyTime > 0)
            {
                Console.WriteLine($"{otherTeamPlayer.Team}");
                Console.WriteLine($"{otherTeamPlayer.Position} {otherTeamPlayer.Number} {otherTeamPlayer.Name} ***This player is currently in the box, {otherTeamPlayer.PenaltyTime} minutes left on the penalty.");
            }
            else
            {
                Console.WriteLine($"{otherTeamPlayer.Team}");
                Console.WriteLine($"{otherTeamPlayer.Position} {otherTeamPlayer.Number} {otherTeamPlayer.Name}");
            }
        }

        public List<OtherTeamPlayer> PlayersFromOtherTeams(List<OtherTeamPlayer> players)
        {
            players.Add(new OtherTeamPlayer("Brad Marchand", "63", "C ", "Boston Bruins"));
            players.Add(new OtherTeamPlayer("David Pastrnak", "88", "RW", "Boston Bruins"));
            players.Add(new OtherTeamPlayer("Charlie McAvoy", "73", "DE", "Boston Bruins"));
            players.Add(new OtherTeamPlayer("Patrick Kane", "88", "RW", "Chicago Blackhawks"));
            players.Add(new OtherTeamPlayer("Johnathan Toews", "19", "C ", "Chicago Blackhawks"));
            players.Add(new OtherTeamPlayer("Pius Suter", "24", "C ", "Chicago Blackhawks"));
            players.Add(new OtherTeamPlayer("Joe Pavelski", "16", "C ", "Dallas Stars"));
            players.Add(new OtherTeamPlayer("Jamie Benn", "14", "LW", "Dallas Stars"));
            players.Add(new OtherTeamPlayer("Tyler Seguin", "25", "LW", "Dallas Stars"));

            return players;
        }

        public List<OtherTeamPlayer> FightStaminaGeneration(List<OtherTeamPlayer> players)
        {
            Random random = new Random();
            foreach (OtherTeamPlayer player in players)
            {
                player.FightStamina = random.Next(99) + 1;
            }
            return players;
        }
    }
}
