using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 12f,
                 maxVelocity = 4f;
    //[SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}


    void PlayerMoveKeyboard(){
        float forceX = 0f;
        
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");


        /*        float forceY = 0f;
                  fazer ele voar 
                  float l = Input.GetAxisRaw("Vertical");
                  Debug.Log(l);

                if (l > 0)
                {
                    if (vel < maxVelocity)
                        forceY = speed;

                    myBody.AddForce(new Vector2(0, forceY += 10));
                    anim.SetBool("Walk", true);
                }
                else if (l < 0)
                {
                    if (vel < maxVelocity)
                        forceY = -speed;

                    myBody.AddForce(new Vector2(0, forceY -= 10));
                    anim.SetBool("Walk", true);
                }
                else
                {
                    anim.SetBool("Walk", false);
                }


            */
        if ( h > 0){
            if(vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale;
            temp.x = 1.3f; 
            transform.localScale = temp;
             
            anim.SetBool("Walk",true);
        }else if( h < 0)
        {
            if (vel < maxVelocity)
                forceX = -speed; 

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
            
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk",false);
        }
        myBody.AddForce(new Vector2(forceX, 0));
    }
}
