using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour {

    public GameObject TaskBar;

    public NextDay nextDay;

    [HideInInspector] public bool dayCompleted = false;

    public DialogueHandler sasha;
    public DialogueHandler chris;
    public DialogueHandler tyler;
    public DialogueHandler ryan;
    public DialogueHandler vic;
    public DialogueHandler brandon;
    public DialogueHandler emilia;

    public Text task1;
    public Text task2;
    public Text task3;
    public Text task4;
    public Text task5;
    public Text task6;
    public Text task7;
    public GameObject taskDone;


    //script to managen the tasks for day 1//
    void Update()
    {

        UpdateTaskList();

        if (sasha.firstTime == true && chris.firstTime == true && tyler.firstTime == true && ryan.firstTime == true && vic.firstTime == true && brandon.firstTime == true && emilia.firstTime == true)
        {
            Debug.Log("YOU CAN SLEEP");
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
        }
        if (ryan.firstTime == true)
        {
            task2.color = Color.white;
        }
        if (chris.firstTime == true)
        {
            task3.color = Color.white;
        }
        if (tyler.firstTime == true)
        {
            task4.color = Color.white;
        }
        if (brandon.firstTime == true)
        {
            task5.color = Color.white;
        }
        if (vic.firstTime == true)
        {
            task6.color = Color.white;
        }
        if (emilia.firstTime == true)
        {
            task7.color = Color.white;
        }
        if (nextDay.dayCompleted == true)
        {
            taskDone.SetActive(true);
        }
    }
}
