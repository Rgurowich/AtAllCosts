using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public int code;

    //Script for teliporting the player through doors to other locations in the game//

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {     
            if (Input.GetKeyDown(KeyCode.E))
            {            
                foreach (DoorScript door in FindObjectsOfType<DoorScript>())
                {
                    if (door.code == code && door != this)                      //checks for the door with the same code//
                    {
                        Vector3 position = door.gameObject.transform.position;
                        collision.gameObject.transform.position = position;
                    }
                }
            }
        }
    }
}