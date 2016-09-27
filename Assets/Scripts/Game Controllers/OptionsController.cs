using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class OptionsController : MonoBehaviour {


    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
        SetTheDifficulty();
	}

    void SetInicialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy": 
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
       
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
               
                break;
        }
    }

    void SetTheDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetInicialDifficulty("easy");
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetInicialDifficulty("medium");
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetInicialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(1);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(1);
        GamePreferences.SetHardDifficultyState(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
