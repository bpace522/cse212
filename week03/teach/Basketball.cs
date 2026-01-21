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

using System.Security;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }

            else
            {
                players[playerId] = points;
            }
        }

        var playerList = players.ToList();
        playerList.Sort((a, b) => b.Value.CompareTo(a.Value));

        Console.WriteLine("Top 10 Players by career points");
        for (int i = 0; i < 10 && i < playerList.Count; i++)
        {
            var player = playerList[i];
            Console.WriteLine($"{i + 1}. {player.Key} - {player.Value} points");
        }
    }
}