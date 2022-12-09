using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartLevel()
    {
        Debug.Log("GAMEOVER... RESTARTING LEVEL.....");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }


   
    
    
}
