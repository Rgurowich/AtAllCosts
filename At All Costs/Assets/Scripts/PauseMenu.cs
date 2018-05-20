using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    private bool isOpen = false;

    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == false)
        {
            isOpen = true;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            isOpen = false;
            pauseMenu.SetActive(false);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
