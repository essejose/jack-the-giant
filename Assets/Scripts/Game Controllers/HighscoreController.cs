﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

	void Start () {
        SetScoreBaseOnDifficulty();

    }
	

    void SetScore(int score, int coinScore)
    {
      scoreText.text = score.ToString();
      coinText.text = coinScore.ToString();

    }

    void SetScoreBaseOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState () == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
        }
        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
        }

       
    }

	public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
