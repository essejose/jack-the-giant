using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;

    private float minX, maxX;

    private float controlX;

    private float lastCloudPositionY;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
