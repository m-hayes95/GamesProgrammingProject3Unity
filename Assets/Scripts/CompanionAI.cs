using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private bool playerInsideRadius;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInsideRadius == false)
        {
            FollowPlayer();
        }

        
    }

    private void FollowPlayer()
    {
        //Check player's position on x and y axis
        float x = transform.position.x - player.transform.position.x;
        float y = transform.position.y - player.transform.position.y;

        //if x is less than 0 move right, if more than 0, move left.
        if(x < 0)
        {
            FollowRight(1);
        }

        else
        {
            FollowRight(-1);
        }

        //if y is less than 0, move up and if more than 0, move down
        if(y < 0)
        {
            FollowUp(1);
        }

        else
        {
            FollowUp(-1);
        }
    }

    private void FollowRight(float backwards)
    {
        //clamp used to make sure only -1 or 1 input is recieved
        backwards = Mathf.Clamp(backwards, -1, 1);
        //Move forward along the X axis * Speed and delta time
        transform.Translate(backwards * speed * Time.deltaTime, 0, 0);
    }

    private void FollowUp(float upwards)
    {
        //clamp used to make sure only -1 or 1 input is recieved
        upwards = Mathf.Clamp(upwards, -1, 1);
        //Move forward along the Y axis * Speed and delta time
        transform.Translate(0, upwards * speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //when player enters the acceptance radius
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player too close...");
            playerInsideRadius = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        //when player leaves the acceptance radius
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Following PLayer...");
            playerInsideRadius = false;
        }
    }
}
