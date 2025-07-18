using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

/// <summary>
/// Static class containing various methods that demonstrate how to use sets, dictionaries,
/// and JSON parsing in C# for real-world problems.
/// </summary>
public static class SetsAndMaps
{
    /// <summary>
    /// Finds all symmetric 2-letter word pairs from the input list.
    /// A pair is symmetric if reversing one word gives the other.
    /// Words like "aa" are skipped because no duplicates are allowed.
    /// 
    /// Example:
    /// Input: [am, at, ma, if, fi]
    /// Output: ["am & ma", "if & fi"]
    /// </summary>
    /// <param name="words">An array of 2-character lowercase words (no duplicates)</param>
    /// <returns>An array of formatted symmetric word pairs</returns>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);  // For O(1) lookups
        var result = new HashSet<string>();        // Use HashSet to avoid duplicates

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;  // Skip words like "aa"

            var reversed = new string(new[] { word[1], word[0] });  // Reverse the word

            if (wordSet.Contains(reversed))
            {
                // Ensure consistent ordering of pairs (e.g., "am & ma" not "ma & am")
                var pair = string.Compare(word, reversed) < 0
                    ? $"{word} & {reversed}"
                    : $"{reversed} & {word}";

                result.Add(pair);  // Add only unique pairs
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Reads a CSV file and summarizes how many people earned each degree (4th column).
    /// 
    /// Example input file (no header):
    /// John,Doe,30,Bachelor
    /// Jane,Smith,25,Master
    /// Bob,Lee,40,Bachelor
    /// 
    /// Output: { "Bachelor": 2, "Master": 1 }
    /// </summary>
    /// <param name="filename">Path to the CSV file</param>
    /// <returns>A dictionary summarizing degrees and their counts</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length >= 4)
            {
                var degree = fields[3].Trim();

                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determines whether two words are anagrams (same letters in different order).
    /// Ignores spaces and is case-insensitive.
    /// 
    /// Example:
    /// IsAnagram("CAT", "ACT") => true
    /// IsAnagram("DOG", "GOOD") => false
    /// </summary>
    /// <param name="word1">First word</param>
    /// <param name="word2">Second word</param>
    /// <returns>True if the words are anagrams, false otherwise</returns>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        var clean1 = word1.Replace(" ", "").ToLower();
        var clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length)
            return false;

        var countMap = new Dictionary<char, int>();

        // Count letters in word1
        foreach (var c in clean1)
        {
            if (!countMap.ContainsKey(c))
                countMap[c] = 0;
            countMap[c]++;
        }

        // Subtract counts using word2
        foreach (var c in clean2)
        {
            if (!countMap.ContainsKey(c)) return false;

            countMap[c]--;

            if (countMap[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Reads today's earthquake data from USGS and returns a summary of each earthquake's location and magnitude.
    /// Example output: ["California: 4.2", "Alaska: 3.1", ...]
    /// 
    /// Visit https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php for data format.
    /// </summary>
    /// <param name="v">Unused parameter (can be removed if not needed)</param>
    /// <returns>An array of string summaries for each earthquake</returns>
    
    public static string[] EarthquakeDailySummary()

    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserialize the earthquake feature collection
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Safely create a summary for each valid feature
        var summaries = featureCollection?.Features?
            .Where(f => f.Properties?.Mag != null && f.Properties?.Place != null)
            .Select(f => $"{f.Properties.Place}: {f.Properties.Mag:F1}")
            .ToArray();

        return summaries ?? Array.Empty<string>();
    }
}
