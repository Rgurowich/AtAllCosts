using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //simple main menu script//

    public void StartGame()
    {
        SceneManager.LoadScene("AAC_Start");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
