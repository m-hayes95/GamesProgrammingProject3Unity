using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool pause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Pause();
        }
        else Resume();
    }

    public void Resume()
    {
        //Debug.Log("Resume " + context);
        pauseMenuUI.SetActive(false);
        // Set time scale to default.
        Time.timeScale = 1f;
        pause = false;

    }
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        // Stop time with time scale.
        Time.timeScale = 0f;
        pause= true;
    }
    public void PauseQuitGame()
    {
        Application.Quit();
    }
}
