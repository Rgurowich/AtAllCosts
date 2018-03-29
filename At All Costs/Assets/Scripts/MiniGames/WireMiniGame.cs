using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class WireMiniGame : MonoBehaviour {

    public double timeLeft;
    public Text timeDisplay;
    public string FirstWireName;
    public Button[] Wires;
    public Image[] unlitPower;
    private Image[] litPower;

    private bool blueConnected;
    private bool redConnected;
    private bool purpleConnected;
    private bool greenConnected;

    private int powerOn;
    private int randNum;

    // Use this for initialization
    void Start () {
        FirstWireName = "Not Selected";
        greenConnected = false;
        blueConnected = false;
        redConnected = false;
        purpleConnected = false;

    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeDisplay.text = timeLeft.ToString("00:00");
        if(FirstWireName == "Not Selected")
        {
            Wires[0].interactable = true;
            Wires[1].interactable = true;
            Wires[2].interactable = true;
            Wires[3].interactable = true;
            Wires[4].interactable = true;
            Wires[5].interactable = true;
            Wires[6].interactable = true;
            Wires[7].interactable = true;
        }

        if(greenConnected == true && purpleConnected == true && blueConnected == true && redConnected == true)
        {
            timeDisplay.text = "YAAAY";
            Wires[0].interactable = false;
            Wires[1].interactable = false;
            Wires[2].interactable = false;
            Wires[3].interactable = false;
            Wires[4].interactable = false;
            Wires[5].interactable = false;
            Wires[6].interactable = false;
            Wires[7].interactable = false;
        }
    }

    public void GetFirstWire()
    {
        if (FirstWireName == "Not Selected")
        {
            FirstWireName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log(FirstWireName);
            if (FirstWireName == "TopBlue" || FirstWireName == "TopRed" || FirstWireName == "TopPurple" || FirstWireName == "TopGreen")
            {
                Wires[0].interactable = false;
                Wires[1].interactable = false;
                Wires[2].interactable = false;
                Wires[3].interactable = false;
                Wires[4].interactable = true;
                Wires[5].interactable = true;
                Wires[6].interactable = true;
                Wires[7].interactable = true;
                
        }
            if (FirstWireName == "BottomBlue" || FirstWireName == "BottomRed" || FirstWireName == "BottomPurple" || FirstWireName == "BottomGreen")
            {
                Wires[0].interactable = true;
                Wires[1].interactable = true;
                Wires[2].interactable = true;
                Wires[3].interactable = true;
                Wires[4].interactable = false;
                Wires[5].interactable = false;
                Wires[6].interactable = false;
                Wires[7].interactable = false;
            }
        }
        else
        {
            string secondWireName = EventSystem.current.currentSelectedGameObject.name;
            if (FirstWireName == "TopBlue" && secondWireName == "BottomBlue" || FirstWireName == "BottomBlue" && secondWireName == "TopBlue")
            {
                Debug.Log("BLUE AND BLUE");
                FirstWireName = "Not Selected";
                blueConnected = true;
                PowerIndicater();

            }         
            else if (FirstWireName == "TopRed" && secondWireName == "BottomRed" || FirstWireName == "BottomRed" && secondWireName == "TopRed")
            {
                Debug.Log("RED AND RED");
                FirstWireName = "Not Selected";
                redConnected = true;
                PowerIndicater();
            }
            else if (FirstWireName == "TopPurple" && secondWireName == "BottomPurple" || FirstWireName == "BottomPurple" && secondWireName == "TopPurple")
            {
                Debug.Log("PURPLE AND PURPLE");
                FirstWireName = "Not Selected";
                purpleConnected = true;
                PowerIndicater();
            }
            else if (FirstWireName == "TopGreen" && secondWireName == "BottomGreen" || FirstWireName == "BottomGreen" && secondWireName == "TopGreen")
            {
                Debug.Log("GREEN AND GREEN");
                FirstWireName = "Not Selected";
                greenConnected = true;
                PowerIndicater();
            }
            else
            {
                Debug.Log("WRONG");
                FirstWireName = "Not Selected";
            }
        }
        

    }

    void PowerIndicater()
    {
        
        for (int i = powerOn; i <= unlitPower.Length;)
        {
            Debug.Log(powerOn);
            if (unlitPower[i].GetComponent<Image>().color == Color.green)
            {
                break;
            }
            else if (randNum <= 2) 
            {
                unlitPower[i].GetComponent<Image>().color = Color.green;
                randNum++;
                powerOn++;
            }        
        }   
    }
}
