using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    //Using Volume Detection class to create new variable
    public VolumeDetection volumeToMonitor;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //have enemy prefab look for actors with Player tag inide trigger with Combat Zone tag
        player = GameObject.FindGameObjectWithTag("Player");
        volumeToMonitor = GameObject.FindGameObjectWithTag("CombatZone").GetComponent<VolumeDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        //reference to player inside volume bool within the Volume Detection class
        if (volumeToMonitor.playerInsideVolume == true)
        {
            //Enemy to look at player
            //transform.LookAt(player.transform.position);
            //Enemy to chase player
            //transform.Translate(Vector2.right * speed * Time.deltaTime);

            //2D version of transform.LookAt(player.transform.position)
            //Look at the player position
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            //2D version of transform.Translate(Vector3.forward)
            //move right ('forward along X axis 1)
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
