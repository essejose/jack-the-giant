using UnityEngine;
using System.Collections;

public static class GamePreferences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";


    public static string EasyDifficultyScore = "EasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    public static string HardDifficultyScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    //Note we are going to use integers to represent boolean variables
    // 0 - false, 1 - true


    // a method for getting the music state - On or Off
    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    // a method for setting the music state - On or Off
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }

    // method for getting easy difficulty state
    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    // method for setting easy difficulty state
    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, state);
    }

    // method for getting medium difficulty state
    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    // method for setting medium difficulty state
    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, state);
    }

    // method for getting hard difficulty state
    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }

    // method for setting hard difficulty state
    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, state);
    }

    // method for getting easy difficulty highscore
    public static int GetEasyDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyScore);
    }

    // method for setting easy difficulty highscore
    public static void SetEasyDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyScore, score);
    }

    // method for getting medium difficulty highscore
    public static int GetMediumDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyScore);
    }

    // method for setting medium difficulty highscore
    public static void SetMediumDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyScore, score);
    }

    // method for getting hard difficulty highscore
    public static int GetHardDifficultyHighscore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyScore);
    }

    // method for setting hard difficulty highscore
    public static void SetHardDifficultyHighscore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyScore, score);
    }

    // method for getting easy difficulty coin score
    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    // method for setting easy difficulty coin score
    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }

    // method for getting medium difficulty coin score
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    // method for setting medium difficulty coin score
    public static void SetMediumDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, score);
    }

    // method for getting hard difficulty coin score
    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }

    // method for setting hard difficulty coin score
    public static void SetHardDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, score);
    }





}
