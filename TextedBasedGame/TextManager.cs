using System;
using System.Collections.Generic;

public class TextManager
{
    private Dictionary<string, string> _texts;

    public TextManager(string filePath)
    {
        _texts = FileManager.ReadFromFile<Dictionary<string, string>>(filePath);
    }

    public string GetText(string key)
    {
        if (_texts.ContainsKey(key))
        {
            return _texts[key];
        }
        else
        {
            throw new KeyNotFoundException($"Key '{key}' not found in texts.");
        }
    }
}