using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text companionsCollectedText, playerHealthText, enemiesDefeatedText, winConditionDisplayText;
    public Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI text for player health, companions collected and enemies defeated
        companionsCollectedText.text = myPlayer.companionsCollected.ToString();
        playerHealthText.text = myPlayer.health.ToString(); 
        enemiesDefeatedText.text = myPlayer.enemiesDefeated.ToString();

    }
}
