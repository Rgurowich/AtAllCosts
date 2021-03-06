﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueHandler : MonoBehaviour {

    public DialogueClass dialogue;
    public GameObject dialogueBox;

    public Text nameText;
    public Text messageText;

    public GameObject reponseOne;
    public GameObject reponseTwo;
    public GameObject reponseThree;
    public GameObject reponseFour;
    public Text reponseTextOne;
    public Text reponseTextTwo;
    public Text reponseTextThree;
    public Text reponseTextFour;
    public GameObject chatIcon;

    private int resLength;
    private int nextMsg;

    int msgNum = 0;

    int currentIndex = 0;

    private bool entered = false;
    [HideInInspector] public bool firstTime = false;
    [HideInInspector] public bool inConvo = false;

    //Script for displaying the dialogue between player and NPC//

    void Update()
    {
        if (inConvo == false)
        {
            //This if statment calls the LoadDialogue method when a user starts a convosation//
            if (Input.GetKeyDown(KeyCode.E) && entered == true)
            {
                inConvo = true;
                dialogueBox.SetActive(true);
                reponseOne.SetActive(false);
                reponseTwo.SetActive(false);
                reponseThree.SetActive(false);
                reponseFour.SetActive(false);
                LoadDialogue();
                chatIcon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        entered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        entered = false;

        dialogueBox.SetActive(false);

        inConvo = false;
    }

    //This method first checks to see if the player has already spooken to them before and then loads either the first dialogue or the dialoge loop then calls LoadText to display it//
    public void LoadDialogue()
    {
        if (firstTime == false)
        {
            firstTime = true;
            currentIndex = 0;
            nameText.text = dialogue.npcName;
            messageText.text = dialogue.messages[0].text;
            resLength = dialogue.messages[0].responses.Length;
            GetResLength();
        }
        else
        {
            currentIndex = dialogue.messages.Length - 1;
            nameText.text = dialogue.npcName;
            messageText.text = dialogue.messages[dialogue.messages.Length-1].text;
            resLength = dialogue.messages[dialogue.messages.Length-1].responses.Length;
            nextMsg = dialogue.messages.Length - 1;
            GetResLength();
        }
    }


    public void LoadText()
    {
        int buttonPressed = 0;
        string buttonName = EventSystem.current.currentSelectedGameObject.name; //Gets the name of the button pressed//

        if (buttonName == "ResponseOne")
        {
            buttonPressed = 0;
        }
        if (buttonName == "ResponseTwo")
        {
            buttonPressed = 1;
        }
        if (buttonName == "ResponseThree")
        {
            buttonPressed = 2;
        }
        if (buttonName == "ResponseFour")
        {
            buttonPressed = 3;
        }

        reponseOne.SetActive(false);
        reponseTwo.SetActive(false);
        reponseThree.SetActive(false);
        reponseFour.SetActive(false);

        if(dialogue.messages[currentIndex].responses[0].reply == "*Leave*") //if the reply is "*Leave*" the dialogue will end//
        {
            dialogueBox.SetActive(false);
            inConvo = false;
        }

        nextMsg = dialogue.messages[currentIndex].responses[buttonPressed].next; //get the next message number from the button pressed//

        resLength = dialogue.messages[nextMsg].responses.Length;

        messageText.text = dialogue.messages[nextMsg].text;

        GetResLength(); //uses this methord to find out how many replys there are to a message//

        msgNum = nextMsg;
        currentIndex = msgNum;
    }

    //this method uses the length of the responces array to figure out how many buttons should be displayed//
    void GetResLength()
    {
        if (resLength == 1)
        {
            reponseOne.SetActive(true);
            reponseTextOne.text = dialogue.messages[nextMsg].responses[0].reply;
        }
        if (resLength == 2)
        {
            reponseOne.SetActive(true);
            reponseTextOne.text = dialogue.messages[nextMsg].responses[0].reply;
            reponseTwo.SetActive(true);
            reponseTextTwo.text = dialogue.messages[nextMsg].responses[1].reply;
        }
        if (resLength == 3)
        {
            reponseOne.SetActive(true);
            reponseTextOne.text = dialogue.messages[nextMsg].responses[0].reply;
            reponseTwo.SetActive(true);
            reponseTextTwo.text = dialogue.messages[nextMsg].responses[1].reply;
            reponseThree.SetActive(true);
            reponseTextThree.text = dialogue.messages[nextMsg].responses[2].reply;

        }
        if (resLength == 4)
        {
            reponseOne.SetActive(true);
            reponseTextOne.text = dialogue.messages[nextMsg].responses[0].reply;
            reponseTwo.SetActive(true);
            reponseTextTwo.text = dialogue.messages[nextMsg].responses[1].reply;
            reponseThree.SetActive(true);
            reponseTextThree.text = dialogue.messages[nextMsg].responses[2].reply;
            reponseFour.SetActive(true);
            reponseTextFour.text = dialogue.messages[nextMsg].responses[3].reply;

        }
    }
}
