using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour {

    private DoorScript door;
    private bool entered = false;
    private Vector3 player;
    private Vector3 exit;

    //void Update()
    //{
    //    player = GameObject.Find("Hayden").transform.position;
    //    if (Input.GetKeyDown(KeyCode.UpArrow) && entered == true)
    //    {
    //        player = door.doorway;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("entered");
    //    entered = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Exit");
    //    entered = false;
    //}
}
