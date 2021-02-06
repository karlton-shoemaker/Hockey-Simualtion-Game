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
    }
}
