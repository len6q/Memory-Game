using System.Collections.Generic;
using UnityEngine;

public static class LocalisationSystem
{
    private static Dictionary<string, string> _enDictionary;
    private static Dictionary<string, string> _ruDictionary;
    private static Dictionary<string, string> _snDictionary;
    private static Dictionary<string, string> _prDictionary;
    private static Dictionary<string, string> _frDictionary;
    private static Dictionary<string, string> _itDictionary;
    private static Dictionary<string, string> _grDictionary;

    private static Language _language = Language.English;

    public static void Load()
    {
        //ChooseLanguage();

        var csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        _enDictionary = csvLoader.GetDictionaryValues("en");
        _ruDictionary = csvLoader.GetDictionaryValues("ru");
        _snDictionary = csvLoader.GetDictionaryValues("sn");
        _prDictionary = csvLoader.GetDictionaryValues("pr");
        _frDictionary = csvLoader.GetDictionaryValues("fr");
        _itDictionary = csvLoader.GetDictionaryValues("it");
        _grDictionary = csvLoader.GetDictionaryValues("gr");
    }

    public static string Get(string key)
    {
        string value = string.Empty;

        switch(_language)
        {
            case Language.English: _enDictionary.TryGetValue(key, out value); return value;
            case Language.Russian: _ruDictionary.TryGetValue(key, out value); return value;            
            case Language.Spanish: _snDictionary.TryGetValue(key, out value); return value;            
            case Language.Portuguese: _prDictionary.TryGetValue(key, out value); return value;            
            case Language.French: _frDictionary.TryGetValue(key, out value); return value;            
            case Language.Italian: _itDictionary.TryGetValue(key, out value); return value;            
            case Language.German: _grDictionary.TryGetValue(key, out value); return value;            
        }
        return value;
    }

    private static void ChooseLanguage()
    {
        SystemLanguage language = Application.systemLanguage;
        if (language == SystemLanguage.Belarusian || language == SystemLanguage.Russian
            || language == SystemLanguage.Ukrainian)
        {
            _language = Language.Russian;
        }
        else if (language == SystemLanguage.Catalan || language == SystemLanguage.Spanish)
        {
            _language = Language.Spanish;
        }
        else if (language == SystemLanguage.Danish || language == SystemLanguage.Dutch
            || language == SystemLanguage.Faroese || language == SystemLanguage.German)
        {
            _language = Language.German;
        }
        else if (language == SystemLanguage.French)
        {
            _language = Language.French;
        }
        else if (language == SystemLanguage.Italian)
        {
            _language = Language.Italian;
        }
        else if (language == SystemLanguage.Portuguese)
        {
            _language = Language.Portuguese;
        }
        else
        {
            _language = Language.English;
        }
    }
}

public enum Language
{
    English,
    Russian,
    Spanish,
    Portuguese,
    French,
    Italian,
    German
}