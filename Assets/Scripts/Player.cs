using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject mySprites, followingCompanion;
    public Transform spawnPoint;

    private float maxHealth, health, damageFromEnemy;
    public float speed;
    public int companionsCollected, playerPower;
    

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        speed = 10f;
        maxHealth = 10f;
        health = maxHealth;
        damageFromEnemy = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputFromPlayer = new Vector3(h, v, 0);
        
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);

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
            health -= damageFromEnemy;

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
        GameObject follower = Instantiate(followingCompanion, spawnPoint.position, Quaternion.identity) as GameObject;
    }
}
