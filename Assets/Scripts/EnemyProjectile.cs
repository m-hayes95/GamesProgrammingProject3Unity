using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float enemyDamage;
    private float enemyProjectileThrust;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigid body and apply movement * projectile thrust to it
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        enemyProjectileThrust = 600f;
        r.AddRelativeForce(Vector2.right * enemyProjectileThrust);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if collision is with player
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().PlayerTakeDamage(enemyDamage);
            Destroy(gameObject);
        }

        //Check if collison is with companion and call Damage Player on hit function
        if (collision.gameObject.tag == "Companion")
        {
            collision.gameObject.GetComponent<CompanionAI>().DamagePlayerOnHit();
        }
        //if collosion was not with enemy, Destroy projectile
        Destroy(gameObject);
    }
}
