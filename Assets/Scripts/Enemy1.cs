using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyAI
{
    //declaring animator and sprite
    public Animator enemyRangedAnimator;
    public GameObject enemyRangedSprite;

    // Start is called before the first frame update
    void Start()
    {
        enemyRangedAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        base.Update();
        Facing();
    }

    private void Facing()
    {
        //Get actor postion ref
        float x = transform.position.x - player.transform.position.x;

        //Turn Sprite depending on which was enemy is facing
        if(x < 0)
        {
            //Set enemy state to face foward
            enemyDirection = EnemyFacing.f;
            //Set scale of sprite to face forward
            enemyRangedSprite.transform.localScale = new Vector3(2f, 
                enemyRangedSprite.transform.localScale.y, 
                enemyRangedSprite.transform.localScale.z);
        }
        else
        {
            //Set enemy state to face backwards
            enemyDirection = EnemyFacing.b;
            //Set scale of sprite to face backwards
            enemyRangedSprite.transform.localScale = new Vector3(-2f,
                enemyRangedSprite.transform.localScale.y,
                enemyRangedSprite.transform.localScale.z);
        }
        
    }
}
