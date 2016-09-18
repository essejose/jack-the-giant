using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighscoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
