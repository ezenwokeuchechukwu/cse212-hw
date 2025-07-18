/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // Dictionary to track total points per player
        var players = new Dictionary<string, int>();

        // Open and read CSV
        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // skip header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var pointsStr = fields[8];

            if (int.TryParse(pointsStr, out int points))
            {
                if (players.ContainsKey(playerId))
                {
                    players[playerId] += points;
                }
                else
                {
                    players[playerId] = points;
                }
            }
        }

        // Sort players by points descending and take top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .ToList();

        Console.WriteLine("Top 10 Players by Total Career Points:");
        Console.WriteLine("Rank\tPlayer ID\tTotal Points");
        for (int i = 0; i < topPlayers.Count; i++)
        {
            var (id, totalPoints) = topPlayers[i];
            Console.WriteLine($"{i + 1}\t{id}\t\t{totalPoints}");
        }
    }
}