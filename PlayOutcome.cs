using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class PlayOutcome
    {

        public void ShotOptions(Player player)
        {
            List<string> scoreBanter = new List<string>
            {
                $"It's behind the goalie! {player.Name} scores!!!!!",
                $"{player.Name} sneaks it through, he's on the board!",
                "Fire the cannon! Jackets score!",
                $"Oooooh, close one off the crossbar... {player.Name} can't believe it!",
                $"Ricochet off the defender, the shot misses wide.",
                "The shot rings off the pipe. No goal...",
                $"What an amazing move!!! {player.Name} scores a humdinger!",
                $"Count one more point for number {player.Number}!!"
            };

            bool keepShooting = true;
            while (keepShooting)
            {
                Random random = new Random();
                int randomBanter = random.Next(7);
                Console.Clear();
                Console.WriteLine("Where do you shoot?");
                Console.WriteLine(" 1. Top shelf");
                Console.WriteLine(" 2. Side from a sharp angle");
                Console.WriteLine(" 3. One-timer slapshot");
                Console.WriteLine(" 4. Wraparound backhand");
                Console.WriteLine(" 5. Five-hole");

                Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine(scoreBanter[randomBanter]);
                Console.ReadLine();
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
    }
}
