using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour {

    public Tasks taskList;
    private bool entered;

    public Image returnMessage;
    public Image nextDayMessage;
    public Image shipLog;
    public AudioSource mainMusic;

    void Update () {
		if(taskList.dayCompleted == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && entered == true)
            {
                mainMusic.enabled = false;
                shipLog.gameObject.SetActive(true);
                GameObject.Find("Hayden").GetComponent<Contoller>().enabled = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;

        if(taskList.dayCompleted == true)
        {
            nextDayMessage.gameObject.SetActive(true);
        }
        else
        {
            returnMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
        returnMessage.gameObject.SetActive(false);
        nextDayMessage.gameObject.SetActive(false);
    }
}
