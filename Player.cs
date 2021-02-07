using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class Player
    {
        public int fightStamina;
        public int penaltyTime;
        public int goals;

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
        public int Goals { get; set; }

        public Player()
        {

        }

        public Player(string name, string number, string position)
        {
            Name = name;
            Number = number;
            Position = position;
            PenaltyTime = 0;
        }

        public List<Player> BlueJacketsRoster(List<Player> players)
        {
            players.Add(new Player("Joonas Korpisalo", "70", "GK"));
            players.Add(new Player("Matiss Kivlenieks", "80", "GK"));
            players.Add(new Player("Elvis Merzlikins", "90", "GK"));
            players.Add(new Player("Emil Bemstrom", "52", "C "));
            players.Add(new Player("Max Domi", "16", "C "));
            players.Add(new Player("Brandon Dubinsky", "17", "C "));
            players.Add(new Player("Mikhail Grigorenko", "25", "C "));
            players.Add(new Player("Boone Jenner", "38", "C "));
            players.Add(new Player("Mikko Koivu", " 9", "C "));
            players.Add(new Player("Riley Nash", "20", "C "));
            players.Add(new Player("Gustav Nyquist", "14", "C "));
            players.Add(new Player("Jack Roslovic", "96", "C "));
            players.Add(new Player("Kevin Stenlund", "11", "C "));
            players.Add(new Player("Alexandre Texier", "42", "C "));
            players.Add(new Player("Calvin Thurkauf", "48", "C "));
            players.Add(new Player("Nick Foligno", "71", "LW"));
            players.Add(new Player("Stefan Matteau", "23", "LW"));
            players.Add(new Player("Eric Robinson", "50", "LW"));
            players.Add(new Player("Cam Atkinson", "13", "RW"));
            players.Add(new Player("Oliver Bjorkstrand", "28", "RW"));
            players.Add(new Player("Patrik Laine", "29", "RW"));
            players.Add(new Player("Gabriel Carlsson", "53", "DE"));
            players.Add(new Player("Michael Del Zotto", "15", "DE"));
            players.Add(new Player("Vladislav Gavrikov", "44", "DE"));
            players.Add(new Player("Scott Harrington", " 4", "DE"));
            players.Add(new Player("Seth Jones", " 3", "DE"));
            players.Add(new Player("Dean Kukan", "46", "DE"));
            players.Add(new Player("David Savard", "58", "DE"));
            players.Add(new Player("Zach Werenski", " 8", "DE"));

            return players;
        }
        public void StatDisplay(Player player)
        {
            if (player.PenaltyTime > 0)
            {
                Console.WriteLine($"{player.Position} {player.Number} {player.Name} ***This player is currently in the box, {player.PenaltyTime} minutes left on the penalty.");
            }
            else
            {
                Console.WriteLine($"{player.Position} {player.Number} {player.Name}");
            }
        }
        public List<Player> FightStaminaGeneration(List<Player> players)
        {
            Random random = new Random();
            foreach (Player player in players)
            {
                player.FightStamina = random.Next(99) + 1;
            }
            return players;
        }
    }
}
