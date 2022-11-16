using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float enemyMaxHealth = 10f;
    public float enemyHealth;
    //Referencing Enemy health bar class
    public EnemyHealthBar healthBar;

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
        //TakeDamage(1f); Call take damage funtion with value of 1 for damage amount
        //if (Input.GetKeyDown(KeyCode.P))
        {
            //TakeDamage(1);
        }

          
    }


    public void TakeDamage(float damageAmount)
    {
        //apply damage to enemy health
        Debug.Log("Enemy Took Damage");
        enemyHealth -= damageAmount;
        

        //if HP is equal or less than 0, destroy enemy game object
        if(enemyHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
