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
            
            bool refreshMenu = true;

            while (refreshMenu)
            {
                Console.Clear();
                Console.WriteLine("IT'S HOCKEY TIME IN AMERICA!!!!!\nChoose your options:");
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
                        ShooterOptions(player, blueJacketsRoster);
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Choose which goalie shall defend the net!");
                        GoalieOptions(player, blueJacketsRoster);
                        Console.ReadLine();
                        break;
                    case "5":
                        refreshMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            
        }
        public static void ShooterOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;

            foreach (Player index in players)
            {
                if (players[number].Position != "GK")
                {

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
        }
        public static void GoalieOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;

            foreach (Player index in players)
            {
                if (players[number].Position == "GK")
                {

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
        }
    }
}
