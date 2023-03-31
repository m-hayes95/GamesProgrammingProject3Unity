using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    //call animator
    public Animator followerAnimator;
    //reference to player to follow and for followers sprite
    public GameObject followerSprite;
    private GameObject player; 
    //change speed to private TODO (public used for debugging)
    private float speed = 5f;
    [SerializeField] private bool playerInsideRadius, companionInsideRadius = false;
    //value to apply damage to player when companion is hit by an enemy projectile
    private float damageToPlayer = 0.5f;

    //private CompanionAIVector2DistanceCheck companionAIVector2DistanceCheck; // Assign script to reference vector 2 distance. companionAIVector2DistanceCheck = GetComponent<CompanionAIVector2DistanceCheck>();
    private float playerDistanceCheck = 2f;
    private float distanceBetweenCompanionAndPlayer;
    private const string PLAYER = "Player";

    void Start()
    {
        // Assign player ref
        player = GameObject.FindGameObjectWithTag(PLAYER);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Assign the value of the vector 2 distance method to a variable and show value on console.
        distanceBetweenCompanionAndPlayer = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log("Distance between Companion and Player = " + distanceBetweenCompanionAndPlayer);

        // If vector2 distance value is more than the distance check, follow player.
        if (distanceBetweenCompanionAndPlayer > playerDistanceCheck)
        {
            FollowPlayer();
        }
        
        
        /* -- removed with trigger enters for refactoring purposes
        //check if companion and player is inside the acceptance radius or not
        if (playerInsideRadius == false && companionInsideRadius == false)
        {
            //if no then follow player
            FollowPlayer();
        }
        */
        
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
            //Set scale of sprite to face left
            followerSprite.transform.localScale = new Vector3(-5.5f,
            followerSprite.transform.localScale.y,
            followerSprite.transform.localScale.z);
        }

        else
        {
            FollowRight(-1);
            //Set scale of sprite to face left
            followerSprite.transform.localScale = new Vector3(5.5f,
            followerSprite.transform.localScale.y,
            followerSprite.transform.localScale.z);
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
    /* PREVIOUS CODE USED BEFORE REFACTOR!
    private void OnTriggerEnter2D(Collider2D other)
    {
        //when player enters the acceptance radius
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player too close...");
            playerInsideRadius = true;
        }

        //when companion enters the acceptance radius
        if(other.gameObject.tag == "Companion")
        {
            Debug.Log("Companion too close...");
            companionInsideRadius = true;
        }

        //Called in enemy projectile class instead

        //If the game object tag is "enemy projectile" call Damage Player on hit function
        //if(other.gameObject.tag == "EnemyProjectile")
        //{
            //DamagePlayerOnHit();
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //when player leaves the followers's acceptance radius
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Following PLayer...");
            playerInsideRadius = false;
        }

        //when the companion leaves the follower's acceptance radius
        if (other.gameObject.tag == "Following behind Companion")
        {
            companionInsideRadius = false;
        }
    } */

    public void DamagePlayerOnHit()
    {
        //apply damage to player using damageToPlayer variable

        Debug.Log("Companion Send damage to player");

        //Get temp ref to player script through game objet tag
        Player thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //when the companions are hit, call the function below on the player script,
        //to reduce the player's health by the damage to player value
        thePlayer.WhenCompanionsHitTakeDamage(damageToPlayer);
    }
}
