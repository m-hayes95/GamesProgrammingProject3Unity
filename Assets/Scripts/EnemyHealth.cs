using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float enemyMaxHealth = 10f;
    //enemyhealth public for debugging, change to private TODO!!!
    public float enemyHealth;
    //reference to health pot
    public GameObject healthPotDrop;
    //Referencing Enemy health bar class
    //public EnemyHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Enemies staring HP
        enemyHealth = enemyMaxHealth;
        //Set health bar on enemies
        //healthBar.SetHealth(enemyHealth, enemyMaxHealth); TO DO - Put back in when connecting health
    }

    private void Update()
    {
      
    }


    public void TakeDamage(float damageAmount)
    {
        //apply damage to enemy health
        Debug.Log("Enemy Took Damage");
        enemyHealth -= damageAmount;
        

        //if HP is equal or less than 0, destroy enemy game object
        if(enemyHealth <= 0f)
        {
            Instantiate(healthPotDrop, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
