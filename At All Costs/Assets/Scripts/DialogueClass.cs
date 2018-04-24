using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Data / New Dialogue")]
public class DialogueClass : ScriptableObject
{
    public int npcID;
    public string npcName;
    public Message[] messages;
}

[System.Serializable]
public class Message
{
    public string text;
    public Response[] responses;
}

[System.Serializable]
public class Response
{
    public int next;
    public string reply;
    public string prereq;
    public string trigger;

}
public class CreateDialogue : DialogueClass {}