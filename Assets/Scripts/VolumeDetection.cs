using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDetection : MonoBehaviour
{
    //variable to add materials to object
    public Material on, off;
    Renderer r;
    //Bool used to set material to object depending on if true or false
    public bool playerInsideVolume;

    // Start is called before the first frame update
    void Start()
    {
        //Set r
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Player enters the trigger
        if (other.tag == "Player")
        {
            Debug.Log("Player has entered the combat zone");
            playerInsideVolume = true;
            r.material = on;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Player exits the trigger
        if (other.tag == "Player")
        {
            Debug.Log("Player has exited the combat zone");
            playerInsideVolume = false;
            r.material = off;
        }
    }
}
