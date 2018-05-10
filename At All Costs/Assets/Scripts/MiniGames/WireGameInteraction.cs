using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireGameInteraction : MonoBehaviour {

    private bool entered;
    private bool playing;
    public GameObject WireGame;

    void Start()
    {
        playing = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered == true && playing == false)
        {
            WireGame.SetActive(true);
            playing = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && playing == true)
        {
            WireGame.SetActive(false);
            playing = false;
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
