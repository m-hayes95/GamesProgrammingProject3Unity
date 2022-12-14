using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCollectable : MonoBehaviour
{
    [SerializeField] private AudioSource companionCollectedSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
    // When player walks into Companion trigger, adds 1 to companions collected inventory and power level in Player Class
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Player triggered companion pick up");
            //play collected sound
            companionCollectedSound.Play();
            //call collected companions funciton on player class
            collision.gameObject.GetComponent<Player>().CollectedCompanion(1);
            Destroy(gameObject);

        }
    }
}
