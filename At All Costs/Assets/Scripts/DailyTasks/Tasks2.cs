using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks2 : MonoBehaviour {

    public GameObject TaskBar;

    public NextDay nextDay;

    [HideInInspector] public bool dayCompleted = false;

    public DialogueHandler sasha;
    public WireMiniGame wireGame;

    public Text task1;
    public Text task2;
    public Text task2Header;
    public GameObject taskDone;

    //Script for displaying the tasks for day 2//
    void Update()
    {

        UpdateTaskList();

        if (sasha.firstTime == true && wireGame.gameCompleted == true)
        {
            dayCompleted = true;
            nextDay.dayCompleted = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TaskBar.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            TaskBar.gameObject.SetActive(false);
        }
    }

    void UpdateTaskList()
    {
        if (sasha.firstTime == true)
        {
            task1.color = Color.white;
            task2Header.enabled = true;
            task2.enabled = true;
        }
        if (wireGame.gameCompleted == true)
        {
            task2.enabled = false;
        }
        if(nextDay.dayCompleted == true)
        {
            taskDone.SetActive(true);
        }
    }
}
