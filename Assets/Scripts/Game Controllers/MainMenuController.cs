using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void StartGame()
    {
        GameManager.instace.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Gameplay");
    }
    public void HightscoreMenu()
    {
        SceneManager.LoadScene("HighscoreScene");
    }
    public void OptionMenu()
    {
        SceneManager.LoadScene("OptionsMenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {

    }
}
