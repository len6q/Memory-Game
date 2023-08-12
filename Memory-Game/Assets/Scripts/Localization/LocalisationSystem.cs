using System.Collections.Generic;

public static class LocalisationSystem
{
    private static Dictionary<string, string> _enDictionary;
    private static Dictionary<string, string> _ruDictionary;
    private static Dictionary<string, string> _snDictionary;
    private static Dictionary<string, string> _prDictionary;
    private static Dictionary<string, string> _frDictionary;
    private static Dictionary<string, string> _itDictionary;
    private static Dictionary<string, string> _grDictionary;

    private static Language _language;

    public static void Load()
    {
       _language = ChooseLanguage();

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

    private static Language ChooseLanguage()
    {
        string lang = Dll.GetLanguage();
        return lang switch
        {
            "ru" => Language.Russian,
            "es" => Language.Spanish,
            "de" => Language.German,
            "fr" => Language.French,
            "it" => Language.Italian,
            "pt" => Language.Portuguese,
            _ => Language.English,
        };
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