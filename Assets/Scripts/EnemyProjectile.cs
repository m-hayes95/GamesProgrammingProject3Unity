using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float enemyDamage = 5f;
    private float enemyProjectileThrust;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigid body 
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        //declare projectile thrust value
        enemyProjectileThrust = 600f;
        //apply movement *projectile thrust to it
        r.AddRelativeForce(Vector2.right * enemyProjectileThrust);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collision is with player
        if (collision.gameObject.tag == "Player")
        {
            //if yes call player take damage funciton on player script:
            collision.gameObject.GetComponent<Player>().PlayerTakeDamage(enemyDamage);
            Destroy(gameObject);
        }

        //Check if collison is with companion and call Damage Player on hit function
        //if (collision.gameObject.tag == "Companion")
        //{
            //if yes call damage player on hit function in the companion AI script:
            //collision.gameObject.GetComponent<CompanionAI>().DamagePlayerOnHit();
        //}
        //if collosion was not with enemy or companion, Destroy the projectile
        Destroy(gameObject);
    }
}
