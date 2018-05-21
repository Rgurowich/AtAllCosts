using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGameInteraction : MonoBehaviour {

    private bool entered;
    public GameObject WireGame;

    //interaction script for the minigame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered == true)
        {
            GameObject.Find("Hayden").GetComponent<Contoller>().enabled = false;
            WireGame.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;

        WireGame.SetActive(false);
    }
}
