using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));    // Output: Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Output: Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // Output: ???
    }

    // Dictionary to store word translations
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a translation from 'fromWord' to 'toWord' in the dictionary.
    /// For example, in an English to German dictionary:
    /// AddWord("Book", "Buch") will store the translation of "Book" as "Buch".
    /// </summary>
    /// <param name="fromWord">The source word to translate from (e.g., English)</param>
    /// <param name="toWord">The target word to translate to (e.g., German)</param>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord; // Add or update the translation
    }

    /// <summary>
    /// Translates the provided word using the dictionary.
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word, or "???" if the word is not in the dictionary</returns>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord]; // Return translation if it exists
        }
        return "???"; // Return default if not found
    }
}
