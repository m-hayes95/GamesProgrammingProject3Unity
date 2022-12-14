using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotScript : MonoBehaviour
{
    //amount the healthpot will heal for, needs to be public to update player health
    public float healValue = 5f;
    //ref to health pot pick up sound
    [SerializeField] private AudioSource healthPotPickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check trigger is with Player character
        if (collision.gameObject.tag == "Player")
        {
            //check fucntion is working
            Debug.Log("player picked up health pot");

            //play pick up sound
            healthPotPickUpSound.Play();

            //update player class function On health pot pick up with the heal value of the health pot
            collision.gameObject.GetComponent<Player>().OnHealthPotPickUp(healValue);
            //Destroy this object so it cannot be used again
            Destroy(gameObject);
        }
        
    }
}
