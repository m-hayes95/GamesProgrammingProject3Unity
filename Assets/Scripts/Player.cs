using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //reference to the game manager script
    public GameManager gameManager;
    //referecne to the player animator
    public Animator myAnimator;
    //references to sprite and spawn companions and projectiles
    public GameObject mySprite, followingCompanion, projectile;
    //Spawn locations for projectiles and followers
    public Transform spawnPointFollower, spawnPointN, spawnPointE, spawnPointS, spawnPointW;
    //players max heatlh and damage taken when they collide with an enemy
    private float maxHealth, damageFromEnemyCollide;
    //needs to be public for UI manager
    public float health;
    //speed of player
    [SerializeField] private float speed;
    //Player Power used to multiply damage with companions collected
    public int companionsCollected, playerPower, enemiesDefeated;
    //check if boss is defeated for game win condition
    private bool bossDefeatedYes, playedDeathAnimation;
    
    //ref to player sound
    [SerializeField] private AudioSource playerAttackSound, playerHitSound;

    //enum used to excecute
    public enum Facing { n, e, s, w}
    public Facing facing;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        speed = 10f;
        maxHealth = 30f;
        health = maxHealth;
        damageFromEnemyCollide = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal and vertical movement using input manager
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //set h and v to a new vector 3
        Vector3 inputFromPlayer = new Vector3(h, v, 0);

        //use speed and time delt time to control speed
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);

        //myAnimator.SetBool("IsRunning", true);

        //check for direction of player to shoot in correct direction
        DirectionOfPlayer();

        //Call fire function to shoot projectile
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }

        //Call game over menu if player dies
        if (health <= 0)
        {
            OnDeathGameOverScreen();
        }
        
        // Animator not not assigning and crashing game

        // Only do the death animation once.
        //myAnimator.SetBool("isDead", false);

        // if (playedDeathAnimation == false)
        //{
            //if (Input.GetKeyDown("j"))
            //{
                //death of player

                //myAnimator.SetBool("isDead", true);
                //playedDeathAnimation = true;
            //}

        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player is colliding with an enemy

        //Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Player Takes Damage on collision with enemies
            Debug.Log("Player Takes Damage");
            health -= damageFromEnemyCollide;
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

    private void DirectionOfPlayer()
    {
        //Horizontal and vertical movement using input manager
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Check for direction, player is facing

        //If we are facing east or West
        if (h > 0)
        {
            facing = Facing.e;
            //Set scale of sprite to face left
            mySprite.transform.localScale = new Vector3(-1.7f,
                mySprite.transform.localScale.y,
                mySprite.transform.localScale.z);
           

        }
        if (h < 0)
        {
            facing = Facing.w;
            //Set scale of sprite to face right
            mySprite.transform.localScale = new Vector3(1.7f,
                mySprite.transform.localScale.y,
                mySprite.transform.localScale.z);
            
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

    private void Fire()
    {
        //check which direction the player is facing, then spawn and fire the projectile in that direction
        switch (facing)
        {
            case Facing.e:
                //shoot from Spawn Point East
                Instantiate(projectile, spawnPointE.transform.position, spawnPointE.transform.rotation);
                //play shooting sound on attack
                playerAttackSound.Play();
                break;

            case Facing.w:
                //shoot from Spawn Point West
                Instantiate(projectile, spawnPointW.transform.position, spawnPointW.transform.rotation);
                //play shooting sound on attack
                playerAttackSound.Play();
                break;
           
            case Facing.n:
                //shoot from Spawn Point North
                Instantiate(projectile, spawnPointN.transform.position, spawnPointN.transform.rotation);
                //play shooting sound on attack
                playerAttackSound.Play();
                break;

            case Facing.s:
                //shoot from Spawn Point South
                Instantiate(projectile, spawnPointS.transform.position, spawnPointS.transform.rotation);
                //play shooting sound on attack
                playerAttackSound.Play();
                break;
        }
    }

    public void OnDeathGameOverScreen()
    {
        //Call function when player health reaches 0 or below 0.
        //Open game over menu when created
        Debug.Log("Player Has Died");
        //Restart level for now
        gameManager.GetComponent<GameManager>().RestartLevel();
        //Destroy player actor
        Destroy(gameObject, 1f);
    }

    public void PlayerTakeDamage(float playerDamageAmount)
    {
        //Debug.Log("Player took damage from Enemy");
        //play hit sound
        playerHitSound.Play();
        //apply damage to Player * enemy projectile damage value
        health -= playerDamageAmount;
    }

    public void WhenCompanionsHitTakeDamage(float companionDamageAmount)
    {
        
        //Debug.Log("Player took damage from Companion");
        //apply damage to player using damageToPlayer variable
        health -= companionDamageAmount;
        //play hit sound on player
        playerHitSound.Play();
    }

    public void OnHealthPotPickUp(float healUp)
    {
        health += healUp;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void OnEnemyDefeated()
    {
        enemiesDefeated++;
        //Call restart once all eneimes are defeated
        if (enemiesDefeated >= 10)
        {
            //Change for different fucntion later TODO!!!
            OnDeathGameOverScreen();
        }
    }
}
