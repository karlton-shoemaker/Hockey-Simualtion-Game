using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class MenuOptions
    {

        public void ShotOptions(Player player)
        {
            List<string> scoreBanter = new List<string>
            {
                $"It's behind the goalie! {player.Name} scores!!!!!",
                $"{player.Name} sneaks it through, he's on the board!",
                "Fire the cannon! Jackets score!",
                $"What an amazing move!!! {player.Name} scores a humdinger!",
                $"Count one more point for number {player.Number}!!"
            };
            List<string> missBanter = new List<string>
            {
                $"Oooooh, close one off the crossbar... {player.Name} can't believe it!",
                $"Ricochet off the defender, the shot misses wide.",
                "The shot rings off the pipe. No goal..."
            };

            bool keepShooting = true;
            while (keepShooting)
            {
                Random random = new Random();
                int randomScoreBanter = random.Next(4);
                int randomMissBanter = random.Next(2);
                int randomResult = random.Next(99);
                Console.Clear();
                Console.WriteLine("Where do you shoot?");
                Console.WriteLine(" 1. Top shelf");
                Console.WriteLine(" 2. Side from a sharp angle");
                Console.WriteLine(" 3. One-timer slapshot");
                Console.WriteLine(" 4. Wraparound backhand");
                Console.WriteLine(" 5. Five-hole");

                Console.ReadLine();
                keepShooting = player.RandomPenaltyGenerator(player);
                if (keepShooting == false)
                {
                    break;
                }
                Console.WriteLine();
                if (randomResult > 40)
                {
                    Console.WriteLine(scoreBanter[randomScoreBanter]);
                    Console.ReadLine();
                    player.Goals += 1;
                }
                else
                {
                    Console.WriteLine(missBanter[randomMissBanter]);
                    Console.ReadLine();
                }
                Console.WriteLine("Shoot again? Y/N");
                string shootAgain = Console.ReadLine().ToLower();
                switch (shootAgain)
                {
                    case "y":
                        break;
                    case "n":
                        keepShooting = false;
                        break;
                    default:
                        Console.WriteLine("It was a simple question. Okay, back to main menu.");
                        Console.ReadLine();
                        keepShooting = false;
                        break;
                }
            }
        }
        public void DefenseOptions(Player player)
        {
            List<string> defenseBanter = new List<string>
            {
                "Kick save and a beauty!",
                $"The puck glances off {player.Name}'s skate!",
                $"The puck gets through the defense. {player.Name} can't believe it.",
                $"The shot goes off {player.Name}'s shoulder. That's gotta hurt!",
                $"{player.Name} gets his stick on it!",
                $"Shot deflects off {player.Name} and rings off the crossbar! That was close!",
                "That shot could not be stopped. Goal against the Blue Jackets.",
                $"The puck glances off {player.Name}'s glove. The defense clears the zone."
            };

            bool keepDefending = true;
            while (keepDefending)
            {
                Random random = new Random();
                int randomBanter = random.Next(7);
                if (player.Position == "DE")
                {
                    Console.Clear();
                    Console.WriteLine("What's your defensive strategy?");
                    Console.WriteLine(" 1. Crowd around the goal");
                    Console.WriteLine(" 2. Aggressive check on the boards");
                    Console.WriteLine(" 3. Poke check");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The puck is hurtling your way!\nWhat do you do???");
                    Console.WriteLine(" 1. Reach out your glove hand");
                    Console.WriteLine(" 2. Use legs to block");
                    Console.WriteLine(" 3. Get the stick on it");
                }

                Console.ReadLine();
                keepDefending = player.RandomPenaltyGenerator(player);
                if (keepDefending == false)
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine(defenseBanter[randomBanter]);
                Console.ReadLine();
                Console.WriteLine("Face another shot? Y/N");
                string defendAgain = Console.ReadLine().ToLower();
                switch (defendAgain)
                {
                    case "y":
                        break;
                    case "n":
                        keepDefending = false;
                        break;
                    default:
                        Console.WriteLine("In the time you spent answering wrong, the other team got the puck. They're coming at the net again!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void FightOutcome(Player player, OtherTeamPlayer otherTeamPlayer)
        {
            List<string> midFightBanter = new List<string>
            {
                "It's on!!!",
                "The fists are flying!",
                "He's getting some help from his teammates!",
                "They're holding him back!",
                "The refs are gonna let them go for a bit!",
                "The crowd is on their feet!"
            };
            List<string> victoryBanter = new List<string>
            {
                $"{player.Name} gets the better of it! He's off to the box with a smile on his face.",
                $"A decisive victory for {player.Name}!"
            };
            List<string> defeatBanter = new List<string>
            {
                $"Ouch! {otherTeamPlayer.Name} knocks {player.Name} down to the ice!",
                "The Jackets did not get the better of this fight..."
            };

            Random random = new Random();
            int randomMidFight = random.Next(5);
            int randomVictory = random.Next(1);
            int randomDefeat = random.Next(1);

            Console.WriteLine("The gloves are off!");
            Console.ReadLine();
            Console.WriteLine(midFightBanter[randomMidFight]);
            Console.ReadLine();
            if (player.FightStamina >= otherTeamPlayer.FightStamina)
            {
                Console.WriteLine(victoryBanter[randomVictory]);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(defeatBanter[randomDefeat]);
                Console.ReadLine();
            }

            player.FightStamina -= 31;
            player.PenaltyTime += 6;
        }
        public Player ShooterOptions(Player player, List<Player> players)
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
        public Player DefenseOptions(Player player, List<Player> players)
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
        public Player PenalizedOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;
            List<Player> filteredPlayers = new List<Player>();
            int playerChoice = 0;

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
            if (filteredPlayers.Count == 0)
            {
                Console.WriteLine("No players in penalty box.");
                filteredPlayers.Add(new Player());
            }
            else
            {
                playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            return filteredPlayers[playerChoice];
        }
        public Player FighterOptions(Player player, List<Player> players)
        {
            int number = 0;
            int displayNumber = 1;
            List<Player> filteredPlayers = new List<Player>();

            foreach (Player index in players)
            {
                if (players[number].FightStamina > 30)
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
        public OtherTeamPlayer OpponentFighterOptions(OtherTeamPlayer otherTeamPlayer, List<OtherTeamPlayer> otherTeamPlayers)
        {
            int number = 0;
            int displayNumber = 1;

            foreach (OtherTeamPlayer index in otherTeamPlayers)
            {
                if (number == 0)
                {
                    Console.WriteLine($"  {otherTeamPlayers[number].Team}");
                }
                else if (otherTeamPlayers[number].Team != otherTeamPlayers[number - 1].Team)
                {
                    Console.WriteLine($"  {otherTeamPlayers[number].Team}");
                }
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
                otherTeamPlayer.TeamStatDisplay(index);
                number++;
            }
            int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            return otherTeamPlayers[playerChoice];
        }
        public int CalculateScore(List<Player> players)
        {
            int score = 0;

            foreach (Player player in players)
            {
                score += player.Goals;
            }

            return score;
        }
        public int CalculateTotalPenaltyTime(List<Player> players)
        {
            int penaltyMinutes = 0;

            foreach (Player player in players)
            {
                penaltyMinutes += player.PenaltyTime;
            }

            return penaltyMinutes;
        }
        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine("Experience the thrill of playing in the National Hockey League!");
            Console.WriteLine("Your team is the Columbus Blue Jackets");
            Console.WriteLine("\nYou can:");
            Console.WriteLine(" -Attempt a shot on goal with any player except a goalie");
            Console.WriteLine(" -Attempt to prevent the other team from scoring with a goalie or defenseman");
            Console.WriteLine(" -Pick a fight with one of several players from another NHL team");
            Console.WriteLine(" -Serve your time in the penalty box");
            Console.WriteLine("\nConditions for victory/defeat:");
            Console.WriteLine("You will win the game if you can successfully score ten goals");
            Console.WriteLine("However, you will lose if your team accrues too many penalty minutes");
            Console.WriteLine("\nExplanation of penalty box:");
            Console.WriteLine("As long as your player has time to serve in the penalty box, you will not be able to use him.");
            Console.WriteLine("By choosing to serve time as your option, you will reduce one player's penalty minutes to zero immediately.");
            Console.WriteLine("Otherwise, the penalty time will decrease by one minute each time you pick an action.");
            Console.ReadLine();
        }
    }
}
