using System;
using System.Collections.Generic;
using System.Text;

namespace Choose_Your_Class
{
    public class OtherTeamPlayer : Player
    {
        public string Team { get; }

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
    }
}
