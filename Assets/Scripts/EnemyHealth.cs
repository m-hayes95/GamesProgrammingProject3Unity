using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        //Enemies staring HP

        hp = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        //apply damage to enemy health
        Debug.Log("Enemy Took Damage");
        hp -= damage;

        //if HP is equal or less than 0, call the die funciton
        if(hp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
