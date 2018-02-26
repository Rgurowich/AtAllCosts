using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text NameText;
    public Text DialogueText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> speech;
 
	void Start () {
        names = new Queue<string>();
        speech = new Queue<string>();
	}

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        //NameText.text = dialogue.name;

        speech.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
            //Debug.Log(name);
        }

        foreach (string sentance in dialogue.sentances)
        {
            speech.Enqueue(sentance);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(speech.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentance = speech.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        NameText.text = name;
        StartCoroutine(TypeSentence(sentance));
    }

    IEnumerator TypeSentence (string sentance)
    {
        DialogueText.text = "";
        foreach (char letter in sentance.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
      



}
