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

            OtherTeamPlayer otherTeamPlayer = new OtherTeamPlayer();
            List<OtherTeamPlayer> playersToFight = new List<OtherTeamPlayer>();
            otherTeamPlayer.PlayersFromOtherTeams(playersToFight);

            MenuOptions menuOptions = new MenuOptions();
            
            bool refreshMenu = true;

            while (refreshMenu)
            {
                Console.Clear();
                Console.WriteLine("IT'S HOCKEY TIME IN AMERICA!!!!!\nPlay hockey with the Columbus Blue Jackets!\n");
                int currentScore = menuOptions.CalculateScore(blueJacketsRoster);
                int currentPenaltyTime = menuOptions.CalculateTotalPenaltyTime(blueJacketsRoster);
                Console.WriteLine($"Score: {currentScore}");
                Console.WriteLine("Choose your option:");
                Console.WriteLine(" 1. Shoot at the goal");
                Console.WriteLine(" 2. Defend a shot");
                Console.WriteLine(" 3. Start a fight");
                Console.WriteLine(" 4. Serve your time in the penalty box");
                Console.WriteLine(" 5. Add a player");
                Console.WriteLine(" 6. Instructions");
                Console.WriteLine(" 7. Quit");

                if (currentScore >= 10)
                {
                    Console.WriteLine("\nCongratulations!!! You win!!!");
                    break;
                }
                if (currentPenaltyTime > 10)
                {
                    Console.WriteLine("\nYou took too many penalties... You lose...");
                    break;
                }

                string userChoice = Console.ReadLine();
                bool ineligiblePlayer = true;

                switch (userChoice)
                {
                    case "1":
                        while (ineligiblePlayer)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose your player to take a shot!");
                            Player shootingPlayer = menuOptions.ShooterOptions(player, blueJacketsRoster);
                            if (shootingPlayer.PenaltyTime > 0)
                            {
                                Console.WriteLine("You can't pick him! He's in the penalty box!");
                                Console.ReadLine();
                            }
                            else
                            {
                                ineligiblePlayer = false;
                                Console.WriteLine($"{shootingPlayer.Name} takes the puck down the ice!");
                                Console.ReadLine();
                                menuOptions.ShotOptions(shootingPlayer);
                            }
                        }
                        break;
                    case "2":
                        while (ineligiblePlayer)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose which defenseman to make a play or goalie to defend the net!");
                            Player defensePlayer = menuOptions.DefenseOptions(player, blueJacketsRoster);
                            if (defensePlayer.PenaltyTime > 0)
                            {
                                Console.WriteLine("You can't pick him! He's in the penalty box!");
                                Console.ReadLine();
                            }
                            else
                            {
                                ineligiblePlayer = false;
                                Console.WriteLine($"The offense is coming down the ice toward {defensePlayer.Name}.");
                                Console.ReadLine();
                                menuOptions.DefenseOptions(defensePlayer);
                            }
                        }
                        break;
                    case "3":
                        while (ineligiblePlayer)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose your fighter:");
                            Player fightingPlayer = menuOptions.FighterOptions(player, blueJacketsRoster);
                            if (fightingPlayer.PenaltyTime > 0)
                            {
                                Console.WriteLine("You can't pick him! He's in the penalty box!");
                                Console.ReadLine();
                            }
                            else
                            {
                                ineligiblePlayer = false;
                                Console.Clear();
                                Console.WriteLine("Choose which player to fight:");
                                OtherTeamPlayer playerToFight = menuOptions.OpponentFighterOptions(otherTeamPlayer, playersToFight);
                                menuOptions.FightOutcome(fightingPlayer, playerToFight);
                            }
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Choose a player whose penalty time you want to reduce:");
                        Player penalizedPlayer = menuOptions.PenalizedOptions(player, blueJacketsRoster);
                        if (penalizedPlayer.Name != null)
                        {
                            Console.WriteLine($"\n{penalizedPlayer.Name}'s time in the box has been served.");
                        }
                        penalizedPlayer.PenaltyTime = 0;
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Add a player. What's their name?");
                        string newPlayerName = Console.ReadLine();
                        Console.WriteLine("What position?");
                        Console.WriteLine(" 1. Goalie (GK)");
                        Console.WriteLine(" 2. Defenseman (DE)");
                        Console.WriteLine(" 3. Center (C)");
                        Console.WriteLine(" 4. Left Wing (LW)");
                        Console.WriteLine(" 5. Right Wing (RW)");
                        bool invalidPostition = true;
                        string newPlayerPosition = null;
                        while (invalidPostition)
                        {
                            newPlayerPosition = Console.ReadLine();
                            switch (newPlayerPosition)
                            {
                                case "1":
                                    newPlayerPosition = "GK";
                                    invalidPostition = false;
                                    break;
                                case "2":
                                    newPlayerPosition = "DE";
                                    invalidPostition = false;
                                    break;
                                case "3":
                                    newPlayerPosition = "C ";
                                    invalidPostition = false;
                                    break;
                                case "4":
                                    newPlayerPosition = "LW";
                                    invalidPostition = false;
                                    break;
                                case "5":
                                    newPlayerPosition = "RW";
                                    invalidPostition = false;
                                    break;
                                default:
                                    Console.WriteLine("Hey, that's not an option!");
                                    break;
                            }

                        }

                        Console.WriteLine("What's their number?");
                        string newPlayerNumber = Console.ReadLine();
                        blueJacketsRoster.Add(new Player(newPlayerName,newPlayerNumber,newPlayerPosition));
                        int rosterCount = blueJacketsRoster.Count;
                        Console.WriteLine($"Okay, {blueJacketsRoster[rosterCount - 1].Name} is ready to take to the ice.");
                        Console.ReadLine();
                        break;
                    case "6":
                        menuOptions.Instructions();
                        break;
                    case "7":
                        refreshMenu = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
                if (userChoice == "1" || userChoice == "2" || userChoice == "3" || userChoice == "4")
                {
                    foreach (Player playerStats in blueJacketsRoster)
                    {
                        playerStats.PenaltyTime--;
                        playerStats.FightStamina++;
                    }
                }
            }
        }
    }
}
