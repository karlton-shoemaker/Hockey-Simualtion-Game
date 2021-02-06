using System;
using System.Collections.Generic;

namespace Choose_Your_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            List<Player> blueJacketsRoster = new List<Player>();
            player.BlueJacketsRoster(blueJacketsRoster);
            PlayOutcome playOutcome = new PlayOutcome();
            player.FightStaminaGeneration(blueJacketsRoster);
            
            bool refreshMenu = true;
            blueJacketsRoster[15].PenaltyTime = 4;
            blueJacketsRoster[5].PenaltyTime = 5;
            blueJacketsRoster[7].PenaltyTime = 2;

            while (refreshMenu)
            {
                Console.Clear();
                Console.WriteLine("IT'S HOCKEY TIME IN AMERICA!!!!!\nPlay hockey with the Columbus Blue Jackets!\n\nChoose your options:");
                Console.WriteLine(" 1. Shoot at the goal");
                Console.WriteLine(" 2. Defend a shot");
                Console.WriteLine(" 3. Start a fight");
                Console.WriteLine(" 4. Serve your time in the penalty box");
                Console.WriteLine(" 5. Quit");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Choose your player to take a shot!");
                        Player shootingPlayer = ShooterOptions(player, blueJacketsRoster);
                        Console.WriteLine($"{shootingPlayer.Name} takes the puck down the ice!");
                        Console.ReadLine();
                        playOutcome.ShotOptions(shootingPlayer);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Choose which defenseman to make a play or goalie to defend the net!");
                        Player defensePlayer = DefenseOptions(player, blueJacketsRoster);
                        Console.WriteLine($"The offense is coming down the ice toward {defensePlayer.Name}.");
                        Console.ReadLine();
                        playOutcome.DefenseOptions(defensePlayer);
                        break;
                    case "3":
                        
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Choose a player whose penalty time you want to reduce.");
                        Player penalizedPlayer = PenalizedOptions(player, blueJacketsRoster);
                        Console.WriteLine($"\n{penalizedPlayer.Name}'s time in the box has been served.");
                        penalizedPlayer.PenaltyTime = 0;
                        Console.ReadLine();
                        break;
                    case "5":
                        refreshMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                foreach (Player playerStats in blueJacketsRoster)
                {
                    playerStats.PenaltyTime--;
                    playerStats.FightStamina++;
                }
            }
            
        }
        public static Player ShooterOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;
            List<Player> filteredPlayers = new List<Player>();

            foreach (Player index in players)
            {
                if (players[number].Position != "GK")
                {
                    filteredPlayers.Add(players[number]);

                    if (displayNumber < 10)
                    {
                        Console.Write($" {displayNumber}. ");
                        displayNumber++;
                    }
                    else
                    {
                        Console.Write($"{displayNumber}. ");
                        displayNumber++;
                    }
                    player.StatDisplay(index);
                }
                number++;
            }
            int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            return filteredPlayers[playerChoice];
        }
        public static Player DefenseOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;
            List<Player> filteredPlayers = new List<Player>();

            foreach (Player index in players)
            {
                if (players[number].Position == "GK" || players[number].Position == "DE")
                {
                    filteredPlayers.Add(players[number]);

                    if (displayNumber < 10)
                    {
                        Console.Write($" {displayNumber}. ");
                        displayNumber++;
                    }
                    else
                    {
                        Console.Write($"{displayNumber}. ");
                        displayNumber++;
                    }
                player.StatDisplay(index);
                }
                number++;
            }
            int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            return filteredPlayers[playerChoice];
        }
        public static Player PenalizedOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;
            List<Player> filteredPlayers = new List<Player>();

            foreach (Player index in players)
            {
                if (players[number].PenaltyTime > 0)
                {
                    filteredPlayers.Add(players[number]);

                    if (displayNumber < 10)
                    {
                        Console.Write($" {displayNumber}. ");
                        displayNumber++;
                    }
                    else
                    {
                        Console.Write($"{displayNumber}. ");
                        displayNumber++;
                    }
                    player.StatDisplay(index);
                }
                number++;
            }
            int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            return filteredPlayers[playerChoice];
        }
    }
}
