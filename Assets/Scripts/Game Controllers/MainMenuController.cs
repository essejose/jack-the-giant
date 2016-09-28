using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;
    [SerializeField]
    private Sprite[] musicIons;

    // Use this for initialization
    void Start () {
        CheckPlayTheMusic();


    }

    void CheckPlayTheMusic()
    {
        Debug.Log(GamePreferences.GetMusicState());
        if (GamePreferences.GetMusicState () == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIons[1];
        }
        else
        {

            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIons[0];
        }
    }
	
	public void StartGame()
    {
        GameManager.instace.gameStartedFromMainMenu = true;
         //SceneFader.instance.LoadLevel("GamePlay");
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
        if(GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIons[1];
        }
        else
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIons[0];
        }
    }
}
