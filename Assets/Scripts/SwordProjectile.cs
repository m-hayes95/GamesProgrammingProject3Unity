using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D projectile;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpeed = 10f;
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
        projectileClone.velocity = transform.forward * projectileSpeed;
    }
}
