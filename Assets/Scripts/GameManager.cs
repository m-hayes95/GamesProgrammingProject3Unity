using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //ref to ranged enemies
    public GameObject enemyRanged, enemyBoss;
    //ref to ranged enemy and boss spawner, and Player script
    private GameObject enemyRangedSpawner, bossEnemySpawner, player;
    private float spawnTimer;
    private bool bossHasSpawned;

    private void Start()
    {
        //assign ranged enemy and boss spawners on start up
        enemyRangedSpawner = GameObject.FindGameObjectWithTag("RangedEnemySpawner");
        bossEnemySpawner = GameObject.FindGameObjectWithTag("BossEnemySpawner");
        //assign ref to player on start up
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //spawn ranged enemies at spawn point on a timer
        if (spawnTimer >=50.0f)
        {
            Debug.Log("Ranged Enemy Spawning...");
            Instantiate(enemyRanged, enemyRangedSpawner.transform.position, enemyRangedSpawner.transform.rotation);

            spawnTimer = 0f;
        }
        else
        {
            //increase time counter by delta time
            spawnTimer += Time.deltaTime;
        }
        
        //spawn boss once Player defeats enough enemies and if the boss has not already spawned
        if (player.GetComponent<Player>().enemiesDefeated >= 3 && !bossHasSpawned)
        {
            //spawn the boss
            Instantiate(enemyBoss, bossEnemySpawner.transform.position, bossEnemySpawner.transform.rotation);
            //set bool for boss has already spawned check to true
            bossHasSpawned = true;
        }
    }

    public void RestartLevel()
    {
        Debug.Log("GAMEOVER... RESTARTING LEVEL.....");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }


   
    
    
}
