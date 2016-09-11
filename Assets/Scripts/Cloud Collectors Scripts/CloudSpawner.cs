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
    void Awake () {
        controlX = 0;
        SetMininAndMax();
        CreateClounds();

    }
	
    //Criando minino e maximo dentro do game view
	void SetMininAndMax(){
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void Shuffle(GameObject[] ArrayToShuffle){
        for(int i = 0; i < ArrayToShuffle.Length; i++){
            GameObject temp = ArrayToShuffle[i];
            int random = Random.Range(i, ArrayToShuffle.Length);
            ArrayToShuffle[i] = ArrayToShuffle[random];
            ArrayToShuffle[random] = temp;


        }

    }
    void CreateClounds(){

        Shuffle(clouds);

        float positionY = 0f;
    
        for(int i = 0; i < clouds.Length; i++){

            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;

            //temp.x = Random.Range(minX, maxX);

            if(controlX == 0) {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }else if(controlX == 1){
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }
            lastCloudPositionY = positionY;

            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;




        }
    }
}
