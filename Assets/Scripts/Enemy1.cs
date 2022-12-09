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
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        //on the x axis check if enemy is in front or behind player
        //on the y axis check if enemy is in above or below player
        float x = transform.position.x - player.transform.position.x;
        float y = transform.position.y - player.transform.position.y;

        if (x <= 0)
        {
            //Enemy Is moving Right, set sprite to face right
            enemyRangedSprite.transform.localScale = new Vector3(1, 1, 1);
        }

        if (y <= 0)
        {
            //Enemy Is moving Left, set sprite to face left
            enemyRangedSprite.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
