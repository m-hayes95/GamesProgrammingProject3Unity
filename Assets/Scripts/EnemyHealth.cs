using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //ref to player character
    private Player eHPlayerRef;
    //enemy max health
    private float enemyMaxHealth = 40f;
    //enemy current health
    [SerializeField] private float enemyHealth;
    //reference to health pot
    public GameObject healthPotDrop;
    //Referencing Enemy health bar class
    //public EnemyHealthBar healthBar;
    //ref to enemy hit sound
    [SerializeField] private AudioSource enemyHitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        //Enemies staring HP
        enemyHealth = enemyMaxHealth;
        //Find player ref
        eHPlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        //Set health bar on enemies
        //healthBar.SetHealth(enemyHealth, enemyMaxHealth); TO DO - Put back in when connecting health
    }


    public void TakeDamage(float damageAmount)
    {
        //apply damage to enemy health
        Debug.Log("Enemy Took Damage");
        enemyHealth -= damageAmount;
        //play enemy hit sound
        enemyHitSound.Play();


        //if HP is equal or less than 0, destroy enemy game object
        if (enemyHealth <= 0f)
        {
            //spawn a health pot when enemy is defeated by the player
            Instantiate(healthPotDrop, transform.position, transform.rotation);
            //call on enemy defeated function within the player class on enemy death
            eHPlayerRef.OnEnemyDefeated();
            
            Destroy(gameObject);
        }
    }

}
