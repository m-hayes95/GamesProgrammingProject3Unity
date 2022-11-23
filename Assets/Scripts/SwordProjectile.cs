using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    private float projectileThrust;
    public float damage = 5f;
    //Reference to player script
    Player thePlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        //Get rigid body and apply right movement * the projectile thrust variable vlaue
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        projectileThrust = 1000f;
        r.AddRelativeForce(Vector2.right * projectileThrust);

        //Get reference to player for power level variable, to multiply damage by power level
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check Collision is with Enemy or not
        if(collision.gameObject.tag == "Enemy")
        {
            //temp variable created for refereces to collisions with actors that have enemy health scripts
            EnemyHealth eH = collision.gameObject.GetComponent<EnemyHealth>();

            //check if we have a referecne to the enemy's health and the player script before applying damage
            if(eH != null && thePlayer != null)
            {
                //Apply TakeDamage function in Enemy Health script
                //Multiply TakeDamage function by the damage variable and Player script's player power
                eH.TakeDamage(damage * thePlayer.playerPower);
                //destroy projectile on impact
                Destroy(gameObject);
            }
           
        }
        //If collision was not with enemy, Destroy projectile after set delay
        Destroy(gameObject, 1f);

       
    }

    


}
