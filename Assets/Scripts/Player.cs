using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject mySprites, followingCompanion, projectile;
    public Transform spawnPointFollower, spawnPointN, spawnPointE, spawnPointS, spawnPointW;

    private float maxHealth, health, damageFromEnemyCollide;
    public float speed;
    public int companionsCollected, playerPower;
    
    public enum Facing { n, e, s, w}
    public Facing facing;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        speed = 10f;
        maxHealth = 10f;
        health = maxHealth;
        damageFromEnemyCollide = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal and vertical movement using input manager
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputFromPlayer = new Vector3(h, v, 0);
        
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);

        DirectionOfPlayer();

        if(Input.GetButtonDown("Jump"))
        {
            Fire();
        }
       
        //Animtaion switch sides
        //if (h == 0)
        {
            //Idle
            //myAnimator.SetBool(“IsRunning?”, false);
            //mySprites.transform.localScale = new Vector3(1, 1, 1);
        } //else
        {
            //Moving right
            //myAnimator.SetBool(“name of bool used in animator controller”, true);
            //mySprites.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Player Takes Damage on collision
            Debug.Log("Player Takes Damage");
            health -= damageFromEnemyCollide;

            //Destroy Player on 0 or less health
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void CollectedCompanion(int companionsPickedUp)
    {
        //when collected companion event is triggered add one to companions collected and Player power level
        //Player power level multiplies damage of player attacks
        companionsCollected += companionsPickedUp;
        Debug.Log("Player Power Increased By 1");
        playerPower += 1;
        
       
        // When player picks up companion collectable, a follwer is spawned at the spawn point position
        GameObject follower = Instantiate(followingCompanion, spawnPointFollower.position, Quaternion.identity) as GameObject;
    }

    public void DirectionOfPlayer()
    {
        //Horizontal and vertical movement using input manager
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Check for direction, player is facing

        //If we are facing east or West
        if (h > 0)
        {
            facing = Facing.e;
        }
        if (h < 0)
        {
            facing = Facing.w;
        }
        //If we are facing North or South
        if (v > 0)
        {
            facing = Facing.n;
        }
        if (v < 0)
        {
            facing = Facing.s;
        }
    }

    public void Fire()
    {
        switch (facing)
        {
            case Facing.e:
                //shoot from Spawn Point East
                Instantiate(projectile, spawnPointE.transform.position, spawnPointE.transform.rotation);
                break;

            case Facing.w:
                //shoot from Spawn Point West
                Instantiate(projectile, spawnPointW.transform.position, spawnPointW.transform.rotation);
                break;
           
            case Facing.n:
                //shoot from Spawn Point North
                Instantiate(projectile, spawnPointN.transform.position, spawnPointN.transform.rotation);
                break;

            case Facing.s:
                //shoot from Spawn Point South
                Instantiate(projectile, spawnPointS.transform.position, spawnPointS.transform.rotation);
                break;
        }
    }
}
