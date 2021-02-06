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
            
            bool refreshMenu = true;
            blueJacketsRoster[15].PenaltyTime = 4;

            while (refreshMenu)
            {
                Console.Clear();
                Console.WriteLine("IT'S HOCKEY TIME IN AMERICA!!!!!\nPlay hockey with the Columbus Blue Jackets!\nChoose your options:");
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
                        Console.WriteLine("Choose which goalie shall defend the net!");
                        Player goaliePlayer = GoalieOptions(player, blueJacketsRoster);
                        Console.WriteLine(goaliePlayer.Name);
                        Console.ReadLine();
                        break;
                    case "5":
                        refreshMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                foreach (Player playerPenalty in blueJacketsRoster)
                {
                    playerPenalty.PenaltyTime--;
                }
            }
            
        }
        public static Player ShooterOptions(Player player, List<Player> players)
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
            int playerChoice = Convert.ToInt32(Console.ReadLine()) + 2;
            return players[playerChoice];
        }
        public static Player GoalieOptions(Player player, List<Player> players)
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
            int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            return players[playerChoice];
        }
    }
}
