using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class joystyck : MonoBehaviour,IPointerUpHandler, IPointerDownHandler {

    private PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name == "Left")
        {
            Debug.Log("Touch touch left");
            playerMove.SetMoveLeft(true);
        }
        else
        {
            Debug.Log("Touch touch Right");
            playerMove.SetMoveLeft(false);
        }
    }


    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
    }
}
