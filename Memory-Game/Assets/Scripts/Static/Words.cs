public class Words
{      
    private const string GAME_NAME_KEY = "game_name";
    private const string BEST_SCORE_KEY = "best_score";
    private const string LEVEL_KEY = "level";
    private const string TIME_KEY = "time";
    private const string CHANCE_KEY = "chance";
    private const string YES_KEY = "yes";
    private const string SEC_KEY = "sec";

    public static string GameName => LocalisationSystem.Get(GAME_NAME_KEY);
    public static string BestScore => LocalisationSystem.Get(BEST_SCORE_KEY);
    public static string Level => LocalisationSystem.Get(LEVEL_KEY);
    public static string Time => LocalisationSystem.Get(TIME_KEY);
    public static string Chance => LocalisationSystem.Get(CHANCE_KEY);
    public static string Yes => LocalisationSystem.Get(YES_KEY);
    public static string Sec => LocalisationSystem.Get(SEC_KEY);
}