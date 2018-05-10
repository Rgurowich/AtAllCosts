using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public int code;
    private bool ready;

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("In");
        if (collision.gameObject.tag == "Player")
        {     
            Debug.Log("Player");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed");
                foreach (DoorScript door in FindObjectsOfType<DoorScript>())
                {
                    if (door.code == code && door != this)
                    {
                        Vector3 position = door.gameObject.transform.position;
                        collision.gameObject.transform.position = position;
                        Debug.Log("Teliported");
                    }
                }
            }
        }
    }
}