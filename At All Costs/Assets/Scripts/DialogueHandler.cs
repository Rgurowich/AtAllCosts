using System;
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

    int msgNum = 0;

    int currentIndex = 0;

    private bool entered = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && entered == true)
        {
            dialogueBox.SetActive(true);
            LoadDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");

        entered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");

        entered = false;

        dialogueBox.SetActive(false);
    }

    public void LoadDialogue()
    {
        currentIndex = 0;
        nameText.text = dialogue.npcName;
        Debug.Log(dialogue.npcName);
        messageText.text = dialogue.messages[0].text;
        Debug.Log(dialogue.messages[0].text);

        reponseTextOne.text = dialogue.messages[0].responses[0].reply;
        //reponseTextTwo.text = dialogue.messages[0].responses[1].reply;
        //reponseTextThree.text = dialogue.messages[0].responses[2].reply;
        //reponseTextFour.text = dialogue.messages[0].responses[3].reply;
    }

 
    public void LoadText()
    {
        int buttonPressed = 0;
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        
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

        int nextMsg = dialogue.messages[currentIndex].responses[buttonPressed].next;
        int resLength = dialogue.messages[nextMsg].responses.Length;
        Debug.Log("Res Length = " + resLength);
        Debug.Log("Next Message = " + nextMsg);
        messageText.text = dialogue.messages[nextMsg].text;
        if(resLength == 1)
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
        msgNum = nextMsg;
        Debug.Log(msgNum);
        currentIndex++;
        //if (currentIndex >= dialogue.messages.Length)
        //{
        //    currentIndex -= 3;
        //}
    }
}
