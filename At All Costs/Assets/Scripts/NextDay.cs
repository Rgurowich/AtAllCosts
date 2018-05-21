using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextDay : MonoBehaviour {

    public bool dayCompleted;
    private bool entered;

    public Image returnMessage;
    public Image nextDayMessage;
    public Image shipLog;
    public Image useIcon;
    public AudioSource mainMusic;


    //This script controls the ship log end day sequence//
    void Start()
    {
        dayCompleted = false;
    }

    void Update () {

        //if the tasks for the day have been completed the user can continue to the next day by pressing E next to their bed//
		if(dayCompleted == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && entered == true)
            {
                mainMusic.enabled = false;
                shipLog.gameObject.SetActive(true);
                GameObject.Find("Hayden").GetComponent<Contoller>().enabled = false;
                useIcon.enabled = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;

        if(dayCompleted == true)
        {
            nextDayMessage.gameObject.SetActive(true);
        }
        else
        {
            returnMessage.gameObject.SetActive(true);
            useIcon.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;
        returnMessage.gameObject.SetActive(false);
        nextDayMessage.gameObject.SetActive(false);      
    }

    public void LoadNextDay()
    {
        SceneManager.LoadScene("AAC_Day2");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
