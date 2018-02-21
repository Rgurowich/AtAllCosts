using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text NameText;
    public Text DialogueText;

    public Animator animator;

    private Queue<string> speech;
 
	void Start () {
        speech = new Queue<string>();
	}

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        NameText.text = dialogue.name;

        speech.Clear();

        foreach (string sentance in dialogue.sentances)
        {
            speech.Enqueue(sentance);
        }

        DisplayNectSentence();
    }

    public void DisplayNectSentence()
    {
        if(speech.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentance = speech.Dequeue();
        StopAllCoroutines();
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
