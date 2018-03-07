using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

    public DialogueClass dialogue;
    public GameObject dialogueBox;

    public Text nameText;
    public Text messageText;

    public Button reponseOne;
    public Button reponseTwo;
    public Button reponseThree;
    public Button reponseFour;
    public Text reponseTextOne;
    public Text reponseTextTwo;
    public Text reponseTextThree;
    public Text reponseTextFour;

    int msgNum = 0;

    int currentIndex = 0;

    private bool entered = false;

    void Start()
    {
        LoadDialogue();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && entered == true)
        {
            dialogueBox.SetActive(true);
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
        messageText.text = dialogue.messages[0].text;

        reponseTextOne.text = dialogue.messages[0].responses[0].reply;
        reponseTextTwo.text = dialogue.messages[0].responses[1].reply;
        reponseTextThree.text = dialogue.messages[0].responses[2].reply;
        //reponseTextFour.text = dialogue.messages[0].responses[3].reply;
    }

    public void LoadText()
    {
        
        string currentMsg = dialogue.messages[msgNum].text;
        Debug.Log(currentMsg);
        //int currentMsgIndex = Array.IndexOf(dialogue.messages, currentMsg) + 1;
        //Debug.Log(currentMsgIndex);
        int nextMsg = dialogue.messages[currentIndex].responses[0].next;
        Debug.Log(nextMsg);

        messageText.text = dialogue.messages[nextMsg].text;
        reponseTextOne.text = dialogue.messages[nextMsg].responses[0].reply;
        msgNum = nextMsg;
        Debug.Log(msgNum);

        currentIndex++;
    }
}
