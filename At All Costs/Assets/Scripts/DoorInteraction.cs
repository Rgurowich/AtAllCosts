using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour {

    public GameObject doorIcon;
    public GameObject chatIcon;
    public GameObject useIcon;
    public Transform doors;
    public GameObject sign;
    public Text signText;
    public GameObject noEntrySign;
    public Text noEntrySignText;
    private string roomName;

    //script that takes in the names of each door and displays a label above it, also displays hub icons//

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.IsChildOf(doors))
        {
            roomName = collision.gameObject.name;
            doorIcon.SetActive(true);
            Debug.Log(collision.gameObject.name);
            if (roomName == "SashaDoor")
            {
                sign.SetActive(true);
                signText.text = "Sasha's Room";

            }
            else if(roomName == "TylerDoor")
            {
                sign.SetActive(true);
                signText.text = "Tyler's Room";
            }
            else if (roomName == "BrandonDoor")
            {
                sign.SetActive(true);
                signText.text = "Brandon's Room";
            }
            else if (roomName == "RyanDoor")
            {
                sign.SetActive(true);
                signText.text = "Ryan's Room";
            }
            else if (roomName == "ChrisDoor")
            {
                sign.SetActive(true);
                signText.text = "Chris's Room";
            }
            else if (roomName == "VicDoor")
            {
                sign.SetActive(true);
                signText.text = "Vic's Room";
            }
            else if (roomName == "EmiliaDoor")
            {
                sign.SetActive(true);
                signText.text = "Emilia's Room";
            }
            else if (roomName == "Lobby2Dorms" || roomName == "SashaRoom" || roomName == "TylerRoom" || roomName == "BrandonRoom" || roomName == "RyanRoom" || roomName == "ChrisRoom" || roomName == "VicRoom" || roomName == "EmiliaRoom")
            {
                sign.SetActive(true);
                signText.text = "Crew Dorms";
            }
            else if (roomName == "Dorms" || roomName == "Outside")
            {
                sign.SetActive(true);
                signText.text = "Mess Hall";
            }
            else if (roomName == "OutsideDoor")
            {
                if (SceneManager.GetActiveScene().name == "AAC_Start")
                {
                    noEntrySign.SetActive(true);
                    noEntrySignText.text = "I'm not going outside tonight";
                    doorIcon.SetActive(false);
                }
                sign.SetActive(true);
                signText.text = "Head Outside";
            }
            else if (roomName == "HaydenDoor")
            {
                sign.SetActive(true);
                signText.text = "Hayden's Room";
                doorIcon.SetActive(false);
            }


        }
        else if (collision.gameObject.name == "WirePuzzle" || collision.gameObject.name == "NextDayObject")
        {
            useIcon.SetActive(true);
        }
        else
        {
            chatIcon.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorIcon.SetActive(false);
        chatIcon.SetActive(false);
        sign.SetActive(false);
        signText.text = "";
        noEntrySign.SetActive(false);
        noEntrySignText.text = "";
        useIcon.SetActive(false);
    }
}
