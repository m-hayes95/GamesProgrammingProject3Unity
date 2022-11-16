using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    //public float projectileSpeed;
    private float projectileThrust;
    public float damage = 5f;
    //Reference to player script
    Player thePlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        //Get rigid body and apply right movement to it
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        projectileThrust = 1000f;
        r.AddRelativeForce(Vector2.right * projectileThrust);
        //projectileSpeed = 1000f;

        //Get reference to player for power level variable
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        //Check Collision is with Enemy or not
        if(collision.gameObject.tag == "Enemy")
        {

            //If true, get enemy health script
            EnemyHealth eH = collision.gameObject.GetComponent<EnemyHealth>();

            //check if we have a referecne to the enemy's health and the player script
            if(eH != null && thePlayer != null)
            {
                //Apply TakeDamage function in Enemy Health script
                //Multiply TakeDamage function by the damage variable and Player. player power
                eH.TakeDamage(damage * thePlayer.playerPower);
                Destroy(gameObject);
            }
           
        }
        //If collision was not with enemy, Destroy projectile after set delay
        Destroy(gameObject, 1f);

       
    }

    


}
