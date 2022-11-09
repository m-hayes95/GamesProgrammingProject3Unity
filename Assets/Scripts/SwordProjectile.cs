using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D projectile;
    public float projectileThrust;
    public float damage;
    

    // Start is called before the first frame update
    void Start()
    {
        //projectileSpeed = 1000f;
        projectileThrust = 1000f;
        //projectile = GetComponent<Rigidbody2D>();
        //projectile.AddForce(projectileThrust, 0, 0, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        //If input is activated, run void Fire code below
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }
    }

    void Fire()
    {
        //Fires Sword projectile clone game object
        Rigidbody2D projectileClone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
        //Set speed of projectile to foward position * the projectile speed variable
        //projectileClone.velocity = transform.forward * projectileSpeed;
        //projectileClone.AddRelativeForce(Vector3.forward * projectileSpeed);

        //Works but its using vector 3 positioning( forward = 0,0,1, we need the X axis to be 1), so forward dont work
        //projectileClone.AddForce(transform.up * m_Thrust);
        //projectile.AddForce(transform.forward * projectileThrust);
        //Use Vector 2 to make it work with 2d
        projectileClone.AddRelativeForce(Vector2.left * projectileThrust);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);

       
    }


}
