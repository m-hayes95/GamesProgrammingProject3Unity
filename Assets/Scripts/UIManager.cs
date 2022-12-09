using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text companionsCollectedText, playerHealthText;
    public Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI text for player health and companions collected
        companionsCollectedText.text = myPlayer.companionsCollected.ToString();
        playerHealthText.text = myPlayer.health.ToString(); 
    }
}
