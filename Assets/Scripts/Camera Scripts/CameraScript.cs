using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private float speed = 3f;
    private float acceleration = 3.2f;
    private float maxSpeed = 33.2f;

    private float easySpeed = 1213.4f;
    private float mediumSpeed = 1534.8f;
    private float hardSpeed = 2252.2f;


    [HideInInspector]
    public bool moveCamera;

	// Use this for initialization
	void Start () {

        if(GamePreferences.GetEasyDifficultyState() == 1)
        {
            maxSpeed = easySpeed;
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            maxSpeed = mediumSpeed;
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            maxSpeed = hardSpeed;
        }

       
        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(moveCamera)
        {
            MoveCamera();
        }
	}

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed = Time.deltaTime);
        Debug.Log(temp.y - (speed = Time.deltaTime));
        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        Debug.Log(speed);
        if (speed > maxSpeed) {
            speed = maxSpeed;
        }

    

        
    }
}
