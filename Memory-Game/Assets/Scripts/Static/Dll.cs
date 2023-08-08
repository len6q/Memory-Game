using System.Runtime.InteropServices;

public class Dll
{
    [DllImport("__Internal")]
    private static extern string GetLanguageExtern();

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void SetToLeaderboardExtern(int value);

    [DllImport("__Internal")]
    private static extern void ShowAdsInternalExtern();

    [DllImport("__Internal")]
    private static extern void ShowAdsRewardedExtern();

    [DllImport("__Internal")]
    private static extern void RateGameExtern();


    public static string GetLanguage() => GetLanguageExtern();
    public static void Load() => LoadExtern();
    public static void Save(string date) => SaveExtern(date);
    public static void SetToLeaderboard(int value) => SetToLeaderboardExtern(value); 
    public static void ShowAdsInternal() => ShowAdsInternalExtern(); 
    public static void ShowAdsRewarded() => ShowAdsRewardedExtern(); 
    public static void RateGame() => RateGameExtern();
}