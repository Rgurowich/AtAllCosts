using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGameInteraction : MonoBehaviour {

    private bool entered;
    public GameObject WireGame;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered == true)
        {
            WireGame.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WireGame.SetActive(false);
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
