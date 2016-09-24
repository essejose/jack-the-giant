using UnityEngine;
using System.Collections;

public class GameplayController : MonoBehaviour {


    public static GameplayController instance;


	// Use this for initialization
	void Start () {
	
	}
	
	void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
