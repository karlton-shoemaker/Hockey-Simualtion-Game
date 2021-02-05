using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class Player
    {
        //private string name;
        //private int number;
        //private string position;
        //public int fightStamina;
        //public int penaltyTime;

        public string Name { get; }
        public int Number { get; }
        public string Position { get; }
        public int FightStamina;
        public int PenaltyTime;

        public Player()
        {

        }

        public Player(string name, int number, string position)
        {
            Name = name;
            Number = number;
            Position = position;
        }

        public List<Player> BlueJacketsRoster(List<Player> players)
        {
            Player korpisalo = new Player("Joonas Korpisalo", 70, "GK");
            players.Add(korpisalo);
            return players;
        }
        public void StatDisplay(Player player)
        {
            Console.WriteLine($"{player.Position} {player.Number} {player.Name}");
        }
    }
}
