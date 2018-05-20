using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class WireMiniGame : MonoBehaviour {

    public GameObject wireGame;
    public double timeLeft;
    public Text timeDisplay;
    private string FirstWireName;
    public Button[] Wires;
    public Image[] unlitPower;
    public GameObject exit;
    public GameObject retry;
    public GameObject continueButton;

    private bool blueConnected;
    private bool redConnected;
    private bool purpleConnected;
    private bool greenConnected;
    private bool gameFinished;
    [HideInInspector] public bool gameCompleted;

    public Image blueWireConnected;
    public Image greenWireConnected;
    public Image redWireConnected;
    public Image purpleWireConnected;

    private int powerOn;
    private int randNum;

    public AudioClip correctClip;
    public AudioClip incorrectClip;
    public AudioClip win;
    private AudioSource gameAudio;
    public AudioSource music;

    private string wireOneConnected;
    private string wireTwoConnected;
    private string wireThreeConnected;
    private string wireFourConnected;

    //private float[] nums = new float[3];


    // Use this for initialization
    void Start () {
        FirstWireName = "Not Selected";
        greenConnected = false;
        blueConnected = false;
        redConnected = false;
        purpleConnected = false;
        powerOn = 0;
        gameAudio = GetComponent<AudioSource>();
        gameFinished = false;
        CompleteRestart();
    }

    void OnEnable()
    {
        timeLeft = 30;
    }

    // Update is called once per frame
    void Update () {
        if(gameFinished == false)
        {
            timeLeft -= Time.deltaTime;
        }
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
            timeDisplay.text = "SYNC";
            music.enabled = false;
            continueButton.SetActive(true);
            gameFinished = true;
            gameCompleted = true;
        }

        if(timeLeft <= 0)
        {
            for (int i = 0; i < Wires.Length; i++)
            {
                Wires[i].interactable = false;
            }

            timeDisplay.text = "ERROR";
            music.enabled = false;
            retry.SetActive(true);
            exit.SetActive(true);
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
            gameAudio.clip = correctClip;
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
                gameAudio.Play();

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
                gameAudio.Play();
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
                gameAudio.Play();
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
                gameAudio.Play();
            }
            else
            {
                gameAudio.clip = incorrectClip;
                Debug.Log("WRONG");
                FirstWireName = "Not Selected";
                gameAudio.Play();
            }

            if (redConnected == true && greenConnected == false && purpleConnected == false && blueConnected == false)
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
                gameAudio.clip = win;
                gameAudio.Play();
            }
            else
            {
                gameAudio.clip = incorrectClip;
                ResetGame();
                gameAudio.Play();
            }

            ////////////////////////////////////////////////////////////////////////////
            // ATTEMPT TO RADOMISE MINIGAME WIRE ORDER // RAN OUT OF DEVELEOPMENT TIME//
            ////////////////////////////////////////////////////////////////////////////

            //if (redConnected == true && wireOneConnected == "Red")
            //{
            //    Debug.Log(" 1 CORRECT ");
            //    if (greenConnected == true && wireTwoConnected == "Green")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (purpleConnected == true && wireTwoConnected == "Purple")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (blueConnected == true && wireTwoConnected == "Blue")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();

            //            }
            //        }
            //    }
            //}
            //else if (greenConnected == true && wireOneConnected == "Green")
            //{
            //    Debug.Log(" 1 CORRECT ");
            //    if (redConnected == true && wireTwoConnected == "Red")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (purpleConnected == true && wireTwoConnected == "Purple")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (blueConnected == true && wireTwoConnected == "Blue")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //}
            //else if (purpleConnected == true && wireOneConnected == "Purple")
            //{
            //    Debug.Log(" 1 CORRECT ");
            //    if (greenConnected == true && wireTwoConnected == "Green")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (redConnected == true && wireTwoConnected == "Red")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (blueConnected == true && wireFourConnected == "Blue")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (blueConnected == true && wireThreeConnected == "Blue")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (blueConnected == true && wireTwoConnected == "Blue")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //}
            //else if (blueConnected == true && wireOneConnected == "Blue")
            //{
            //    Debug.Log(" 1 CORRECT ");
            //    if (greenConnected == true && wireTwoConnected == "Green")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (purpleConnected == true && wireTwoConnected == "Purple")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (redConnected == true && wireFourConnected == "Red")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (redConnected == true && wireThreeConnected == "Red")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //    else if (redConnected == true && wireTwoConnected == "Red")
            //    {
            //        Debug.Log(" 2 CORRECT ");
            //        if (purpleConnected == true && wireThreeConnected == "Purple")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (greenConnected == true && wireFourConnected == "Green")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //        else if (greenConnected == true && wireThreeConnected == "Green")
            //        {
            //            Debug.Log(" 3 CORRECT ");
            //            if (purpleConnected == true && wireFourConnected == "Purple")
            //            {
            //                Debug.Log(" 4 CORRECT ");
            //                gameAudio.clip = win;
            //                gameAudio.Play();
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    gameAudio.clip = incorrectClip;
            //    ResetGame();
            //    gameAudio.Play();
            //}
        }
        
    }

    void ResetGame()
    {

        greenConnected = false;
        blueConnected = false;
        redConnected = false;
        purpleConnected = false;
        powerOn = 0;
        gameFinished = false;
        music.enabled = true;
        retry.SetActive(false);
        exit.SetActive(false);
        continueButton.SetActive(false);

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

    public void CompleteRestart()
    {
        //nums = new float[4];

        //float redNum = 0, blueNum = 0, greenNum = 0, purpleNum = 0;

        //float[] order = new float[4];

        ResetGame();
        timeLeft = 30;
        music.enabled = true;
        retry.SetActive(false);
        exit.SetActive(false);
        gameFinished = false;


        ////////////////////////////////////////////////////////////////////////////
        // ATTEMPT TO RADOMISE MINIGAME WIRE ORDER // RAN OUT OF DEVELEOPMENT TIME//
        ////////////////////////////////////////////////////////////////////////////

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    nums[i] = Random.Range(0, 20);
        //}

        //redNum = nums[0];
        //blueNum = nums[1];
        //greenNum = nums[2];
        //purpleNum = nums[3];

        //if (redNum > blueNum && redNum > greenNum && redNum > purpleNum)
        //{
        //    wireFourConnected = "Red";
        //    if (blueNum > greenNum && blueNum > purpleNum)
        //    {
        //        wireThreeConnected = "Blue";
        //        if (greenNum > purpleNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > greenNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //    else if (greenNum > blueNum && greenNum > purpleNum)
        //    {
        //        wireThreeConnected = "Green";
        //        if (blueNum > purpleNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > blueNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Blue";
        //        }
        //    }
        //    else if (purpleNum > blueNum && purpleNum > greenNum)
        //    {
        //        wireThreeConnected = "Purple";
        //        if (greenNum > blueNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Blue";
        //        }
        //        else if (blueNum > greenNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //}
        //else if (blueNum > redNum && blueNum > greenNum && blueNum > purpleNum)
        //{
        //    wireFourConnected = "Blue";
        //    if (redNum > greenNum && redNum > purpleNum)
        //    {
        //        wireThreeConnected = "Red";
        //        if (greenNum > purpleNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > greenNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //    else if (greenNum > redNum && greenNum > purpleNum)
        //    {
        //        wireThreeConnected = "Green";
        //        if (redNum > purpleNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > redNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Red";
        //        }
        //    }
        //    else if (purpleNum > redNum && purpleNum > greenNum)
        //    {
        //        wireThreeConnected = "Purple";
        //        if (greenNum > redNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Red";
        //        }
        //        else if (redNum > greenNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //}
        //else if (greenNum > redNum && greenNum > blueNum && greenNum > purpleNum)
        //{
        //    wireFourConnected = "Green";
        //    if (blueNum > redNum && blueNum > purpleNum)
        //    {
        //        wireThreeConnected = "Blue";
        //        if (redNum > purpleNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > redNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Red";
        //        }
        //    }
        //    else if (redNum > blueNum && redNum > purpleNum)
        //    {
        //        wireThreeConnected = "Red";
        //        if (blueNum > purpleNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Purple";
        //        }
        //        else if (purpleNum > blueNum)
        //        {
        //            wireTwoConnected = "Purple";
        //            wireOneConnected = "Blue";
        //        }
        //    }
        //    else if (purpleNum > blueNum && purpleNum > redNum)
        //    {
        //        wireThreeConnected = "Purple";
        //        if (redNum > blueNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Blue";
        //        }
        //        else if (blueNum > redNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Red";
        //        }
        //    }
        //}
        //else if (purpleNum > redNum && purpleNum > greenNum && purpleNum > blueNum)
        //{
        //    wireFourConnected = "Purple";
        //    if (blueNum > greenNum && blueNum > redNum)
        //    {
        //        wireThreeConnected = "Blue";
        //        if (greenNum > redNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Red";
        //        }
        //        else if (redNum > greenNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //    else if (greenNum > blueNum && greenNum > redNum)
        //    {
        //        wireThreeConnected = "Green";
        //        if (blueNum > redNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Red";
        //        }
        //        else if (redNum > blueNum)
        //        {
        //            wireTwoConnected = "Red";
        //            wireOneConnected = "Blue";
        //        }
        //    }
        //    else if (redNum > blueNum && redNum > greenNum)
        //    {
        //        wireThreeConnected = "Red";
        //        if (greenNum > blueNum)
        //        {
        //            wireTwoConnected = "Green";
        //            wireOneConnected = "Blue";
        //        }
        //        else if (blueNum > greenNum)
        //        {
        //            wireTwoConnected = "Blue";
        //            wireOneConnected = "Green";
        //        }
        //    }
        //}
        //Debug.Log("1 Wire =" + wireOneConnected);
        //Debug.Log("2 Wire =" + wireTwoConnected);
        //Debug.Log("3 Wire =" + wireThreeConnected);
        //Debug.Log("4 Wire =" + wireFourConnected);
    }

    public void ExitGame()
    {
        wireGame.SetActive(false);
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
