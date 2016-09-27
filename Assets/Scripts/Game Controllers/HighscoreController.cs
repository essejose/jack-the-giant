using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighscoreController : MonoBehaviour {

    //exemp 1
    //private GameplayController gc;

	// Use this for initialization
	void Start () {
        //exemp 1
        //gc = GameObject.Find("GamePlay Controller").GetComponent<GameplayController>();
        //gc.someMethod();

            
        //using  public static mettho
        //GameplayController.instance.someMethod();
	}
	
	public void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
