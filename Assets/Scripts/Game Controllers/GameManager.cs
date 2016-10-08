using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{


    public static GameManager instace;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;


    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InicializeVariable();
    }

    void OnLevelWasLoaded()
    {

        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (gameRestartAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
               
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);


            }
        }
    }

    void InicializeVariable()
    {


        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighscore(0);

            GamePreferences.SetMediumDifficultyState(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighscore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighscore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if (instace != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {

            if (GamePreferences.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetEasyDifficultyHighscore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

                if (highScore < score)
                    GamePreferences.SetEasyDifficultyHighscore(score);

                if (coinHighScore < coinScore)
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);
            }

            if (GamePreferences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetMediumDifficultyHighscore();
                int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (highScore < score)
                    GamePreferences.SetMediumDifficultyHighscore(score);

                if (coinHighScore < coinScore)
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);
            }

            if (GamePreferences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePreferences.GetHardDifficultyHighscore();
                int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

                if (highScore < score)
                    GamePreferences.SetHardDifficultyHighscore(score);

                if (coinHighScore < coinScore)
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);
            }


            gameStartedFromMainMenu = false;
            gameRestartAfterPlayerDied = false;

            //game player controller
            GameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {


            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            /*GameplayController.instance.SetScore(score);
            GameplayController.instance.SetLifeScore(lifeScore);
            GameplayController.instance.SetCoinScore(coinScore);
            */

            gameStartedFromMainMenu = false;
            gameRestartAfterPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartTheGame();

        }
    }
}