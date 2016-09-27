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

    // Use this for initialization
    void Start()
    {
        MakeSingleton();

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
            else if( gameStartedFromMainMenu)
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
        if(lifeScore < 0)
        {
            gameStartedFromMainMenu = false;
            gameRestartAfterPlayerDied = false;

            //game player controller
            GameplayController.instance.GameOverShowPanel(score,coinScore);
        }
        else
        {

            Debug.Log(score);
            Debug.Log(coinScore);
            Debug.Log(lifeScore);
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
