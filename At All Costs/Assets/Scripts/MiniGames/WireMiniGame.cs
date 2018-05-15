using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class WireMiniGame : MonoBehaviour {

    public double timeLeft;
    public Text timeDisplay;
    private string FirstWireName;
    public Button[] Wires;
    public Image[] unlitPower;

    private bool blueConnected;
    private bool redConnected;
    private bool purpleConnected;
    private bool greenConnected;

    public Image blueWireConnected;
    public Image greenWireConnected;
    public Image redWireConnected;
    public Image purpleWireConnected;

    private int powerOn;
    private int randNum;

    public AudioClip correctClip;
    public AudioClip incorrectClip;
    public AudioClip win;
    private AudioSource audio;
    public AudioSource music;

    // Use this for initialization
    void Start () {
        FirstWireName = "Not Selected";
        greenConnected = false;
        blueConnected = false;
        redConnected = false;
        purpleConnected = false;
        powerOn = 0;
        audio = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        timeLeft = 30;
        ResetGame();
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        timeDisplay.text = timeLeft.ToString("00:00");
        if(FirstWireName == "Not Selected")
        {
            for (int i = 0; i < Wires.Length; i++)
            {
                Wires[i].interactable = true;
            }
        }

        if(greenConnected == true && purpleConnected == true && blueConnected == true && redConnected == true)
        {
            timeDisplay.text = "YAAAY";
            music.enabled = false;
        }

        if(timeLeft <= 0)
        {
            for (int i = 0; i < Wires.Length; i++)
            {
                Wires[i].interactable = false;
            }

            timeDisplay.text = "FAILED";
            music.enabled = false;
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
            audio.clip = correctClip;
            string secondWireName = EventSystem.current.currentSelectedGameObject.name;
            if (FirstWireName == "TopBlue" && secondWireName == "BottomBlue" || FirstWireName == "BottomBlue" && secondWireName == "TopBlue")
            {
                Debug.Log("BLUE AND BLUE");
                FirstWireName = "Not Selected";
                blueConnected = true;
                PowerIndicater();
                Wires[2].gameObject.SetActive(false);
                Wires[4].gameObject.SetActive(false);
                blueWireConnected.gameObject.SetActive(true);
                audio.Play();

            }         
            else if (FirstWireName == "TopRed" && secondWireName == "BottomRed" || FirstWireName == "BottomRed" && secondWireName == "TopRed")
            {
                Debug.Log("RED AND RED");
                FirstWireName = "Not Selected";
                redConnected = true;
                PowerIndicater();
                Wires[3].gameObject.SetActive(false);
                Wires[5].gameObject.SetActive(false);
                redWireConnected.gameObject.SetActive(true);
                audio.Play();
            }
            else if (FirstWireName == "TopPurple" && secondWireName == "BottomPurple" || FirstWireName == "BottomPurple" && secondWireName == "TopPurple")
            {
                Debug.Log("PURPLE AND PURPLE");
                FirstWireName = "Not Selected";
                purpleConnected = true;
                PowerIndicater();
                Wires[0].gameObject.SetActive(false);
                Wires[6].gameObject.SetActive(false);
                purpleWireConnected.gameObject.SetActive(true);
                audio.Play();
            }
            else if (FirstWireName == "TopGreen" && secondWireName == "BottomGreen" || FirstWireName == "BottomGreen" && secondWireName == "TopGreen")
            {
                Debug.Log("GREEN AND GREEN");
                FirstWireName = "Not Selected";
                greenConnected = true;
                PowerIndicater();
                Wires[1].gameObject.SetActive(false);
                Wires[7].gameObject.SetActive(false);
                greenWireConnected.gameObject.SetActive(true);
                audio.Play();
            }
            else
            {
                audio.clip = incorrectClip;
                Debug.Log("WRONG");
                FirstWireName = "Not Selected";
                audio.Play();
            }

            if(redConnected == true && greenConnected == false && purpleConnected == false && blueConnected == false)
            {
                Debug.Log(" 1 CORRECT ");
            }
            else if (redConnected == true && greenConnected == true && purpleConnected == false && blueConnected == false)
            {
                Debug.Log(" 2 CORRECT ");
            }
            else if (redConnected == true && greenConnected == true && purpleConnected == true && blueConnected == false)
            {
                Debug.Log(" 3 CORRECT ");
            }
            else if (redConnected == true && greenConnected == true && purpleConnected == true && blueConnected == true)
            {
                Debug.Log(" 4 CORRECT ");
                audio.clip = win;
                audio.Play();
            }
            else
            {
                audio.clip = incorrectClip;
                ResetGame();
                audio.Play();
            }
        }
        
    }

    void ResetGame()
    {
        greenConnected = false;
        blueConnected = false;
        redConnected = false;
        purpleConnected = false;
        powerOn = 0;

        blueWireConnected.gameObject.SetActive(false);
        redWireConnected.gameObject.SetActive(false);
        greenWireConnected.gameObject.SetActive(false);
        purpleWireConnected.gameObject.SetActive(false);

        for (int i = 0; i < Wires.Length; i++)
        {
            Wires[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < unlitPower.Length; i++)
        {
            unlitPower[i].GetComponent<Image>().color = Color.gray;
        }
    }

    void PowerIndicater()
    {
        
        for (int i = powerOn; i < unlitPower.Length; powerOn++)
        {
            i = powerOn;
            if (i == 11)
            {
                break;
            }
            if (unlitPower[i].GetComponent<Image>().color == Color.green)
            {
                break;
            }
            else if (randNum <= 2) 
            {
                unlitPower[i].GetComponent<Image>().color = Color.green;
                randNum++;
            }
            else
            {
                randNum = 0;   
                break;
            }
        }   
    }
}
