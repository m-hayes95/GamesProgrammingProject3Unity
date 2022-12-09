using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyAI
{
    public Animator bossAnimator;
    public GameObject bossSprite;

    // Start is called before the first frame update
    void Start()
    {
        bossAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Facing();
    }

    private void MeleeAttack()
    {
        //add a wide melee attack for the boss mechanics
    }

    private void Facing()
    {
        //Get actor postion ref
        float x = transform.position.x - player.transform.position.x;

        //Turn Sprite depending on which was enemy is facing
        if (x < 0)
        {
            //Set enemy state to face foward
            enemyDirection = EnemyFacing.f;
            //Set scale of sprite to face forward
            bossSprite.transform.localScale = new Vector3(4.89f,
                bossSprite.transform.localScale.y,
                bossSprite.transform.localScale.z);
        }
        else
        {
            //Set enemy state to face backwards
            enemyDirection = EnemyFacing.b;
            //Set scale of sprite to face backwards
            bossSprite.transform.localScale = new Vector3(-4.89f,
                bossSprite.transform.localScale.y,
                bossSprite.transform.localScale.z);
        }

    }

    
}
