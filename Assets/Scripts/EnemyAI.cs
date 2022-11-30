using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //reference to player used to find and follow, projectiles
    public GameObject player, enemyProjectileObject;
    //spawn point for enemy projectile
    public Transform enemyProjectileSpawnPointF, enemyProjectileSpawnPointB;
    //Using Volume Detection class to create new variable
    //public VolumeDetection volumeToMonitor;
    //set to public for debugging, change to private TODO!!!
    public float speed;
    public enum EnemyFacing { f, b}
    public EnemyFacing enemyDirection;
    public bool canShoot = true;
    public float shootTimer;


    //private float enemyProjectileDamage;


    // Start is called before the first frame update
    void Start()
    {
        //have enemy prefab look for actors with Player tag inide trigger with Combat Zone tag
        player = GameObject.FindGameObjectWithTag("Player");
        //volumeToMonitor = GameObject.FindGameObjectWithTag("CombatZone").GetComponent<VolumeDetection>();


    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        
        if (shootTimer >= 1.0f)
        {
            RangedAttack();

            shootTimer = 0f;
        }
        else
        {
            shootTimer += Time.deltaTime;
        }
    }

    private void ChasePlayer()
    {
        //on the x axis check if enemy is in front or behind player
        //on the y axis check if enemy is in above or below player
        float x = transform.position.x - player.transform.position.x;
        float y = transform.position.y - player.transform.position.y;

        //Check if x is less than 0, and move right. If x is more than 0 move character left
        if (x < 0)
        {
            MoveRight(1);
            enemyDirection = EnemyFacing.f;
        }

        else
        {
            MoveRight(-1);
            enemyDirection = EnemyFacing.b;
        }

        //Check if y is less than 0, and move up. If y is more than 0 move character down
        if (y < 0)
        {
            MoveUp(1);
        }

        else
        {
            MoveUp(-1);
        }

    }

    private void MoveRight(float backwards)
    {
        //clamp backwards value to either -1 of 1 to preventing putting in higher / lower numbers
        backwards = Mathf.Clamp(backwards, -1, 1);
        //checking clamp works
        //Debug.Log(backwards);
        //move forward along the X axis (Fowards = X = 1) (X, Y, Z)
        transform.Translate(backwards * speed * Time.deltaTime, 0, 0);
        //for future sprite
        //sprite variable name.transform.localScale = new Vector3(backwards, 1, 1);
    }

    private void MoveUp(float upwards)
    {
        //clamp backwards value to either -1 of 1 to preventing putting in higher / lower numbers
        upwards = Mathf.Clamp(upwards, -1, 1);
        //checking clamp works
        //Debug.Log(upwards);
        //move forward along the Y axis (Fowards = X = 1) (X, Y, Z)
        transform.Translate(0, upwards * speed * Time.deltaTime, 0);

    }

    private void RangedAttack()
    {
        
        
        switch (enemyDirection)
        {
                case EnemyFacing.f:
                    Instantiate(enemyProjectileObject, enemyProjectileSpawnPointF.transform.position, enemyProjectileSpawnPointF.transform.rotation);
                    //canShoot = false;
                    //Add delay here
                    //canShoot = true;
                    break;

                case EnemyFacing.b:
                    Instantiate(enemyProjectileObject, enemyProjectileSpawnPointB.transform.position, enemyProjectileSpawnPointB.transform.rotation);
                    break;
        }
        

        //instantiate enemy projectile used for ranged attack
        //player health - enemyProjectileDamage
        
    }
}
