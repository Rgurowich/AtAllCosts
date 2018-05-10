using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour {

    public GameObject doorIcon;
    public GameObject chatIcon;
    public Transform doors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.IsChildOf(doors))
        {
            doorIcon.SetActive(true);
        }
        else
        {
            chatIcon.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorIcon.SetActive(false);
        chatIcon.SetActive(false);
    }
}
