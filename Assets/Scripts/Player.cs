using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Animator myAnimator;
    //references to sprite and spawn companions and projectiles
    public GameObject mySprite, followingCompanion, projectile;
    //Spawn locations for projectiles and followers
    public Transform spawnPointFollower, spawnPointN, spawnPointE, spawnPointS, spawnPointW;
    private float maxHealth, damageFromEnemyCollide;
    //needs to be public for UI manager
    public float health;
    //speed set to public for debugging, change to private
    public float speed;
    //Player Power used to multiply damage with companions collected
    public int companionsCollected, playerPower, enemiesDefeated;
    //check if boss is defeated for game win condition
    private bool bossDefeatedYes;
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

        Vector3 inputFromPlayer = new Vector3(h, v, 0);
        //use speed and time delt time to control speed
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);
        //myAnimator.SetBool("IsRunning", true);

        //check for direction of player to shoot in correct direction
        DirectionOfPlayer();

        //Call fire function to shoot projectile
        if(Input.GetButtonDown("Jump"))
        {
            Fire();
        }
       
        //Call game over menu if player dies
        if(health <= 0)
        {
            OnDeathGameOverScreen();
        }

        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
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

    public void OnDeathGameOverScreen()
    {
        //Call function when player health reaches 0 or below 0.
        //Open game over menu 
        Debug.Log("Player Has Died");
        gameManager.GetComponent<GameManager>().RestartLevel();
        Destroy(gameObject);
    }

    public void PlayerTakeDamage(float playerDamageAmount)
    {
        //apply damage to Player * enemy projectile damage value
        Debug.Log("Player took damage from Enemy");
        health -= playerDamageAmount;
    }

    public void WhenCompanionsHitTakeDamage(float companionDamageAmount)
    {
        //apply damage to player using damageToPlayer variable
        Debug.Log("Player took damage from Companion");
        health -= companionDamageAmount;
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
        if (enemiesDefeated >= 10 && !bossDefeatedYes)
        {
            //Change for different fucntion later TODO!!!
            OnDeathGameOverScreen();
        }
    }
}
