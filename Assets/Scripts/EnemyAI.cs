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
        //3D/2D - enemy spins on Y axis to look at player in 2D
        //reference to player inside volume bool within the Volume Detection class
        //if (volumeToMonitor.playerInsideVolume == true)
        {
            //initial code that did not work in 2d
            //Enemy to look at player
            //transform.LookAt(player.transform.position);
            //Enemy to chase player
            //transform.Translate(Vector2.right * speed * Time.deltaTime);

            //2D version of transform.LookAt(player.transform.position)
            //Look at the player position
            //Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            //2D version of transform.Translate(Vector3.forward)
            //move right ('forward along X axis 1)
            //transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        //on tick, execute the face function below
        Face();
    }

    public void Face()
    {
        //on the x axis check if enemy is in front or behind player
        //on the y axis check if enemy is in above or below player
        float x = transform.position.x - player.transform.position.x;
        float y = transform.position.y - player.transform.position.y;

        //Check if x is less than 0, and move right. If x is more than 0 move character left
        if (x < 0)
        {
            MoveRight(1);
        }

        else
        {
            MoveRight(-1);
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

    public void MoveRight(float backwards)
    {
        //clamp backwards value to either -1 of 1 to preventing putting in higher / lower numbers
        backwards = Mathf.Clamp(backwards, -1, 1);
        //checking clamp works
        Debug.Log(backwards);
        //move forward along the X axis (Fowards = X = 1) (X, Y, Z)
        transform.Translate(backwards * speed * Time.deltaTime, 0, 0);
        //for future sprite
        //sprite variable name.transform.localScale = new Vector3(backwards, 1, 1);
    }

    public void MoveUp(float upwards)
    {
        //clamp backwards value to either -1 of 1 to preventing putting in higher / lower numbers
        upwards = Mathf.Clamp(upwards, -1, 1);
        //checking clamp works
        Debug.Log(upwards);
        //move forward along the X axis (Fowards = X = 1) (X, Y, Z)
        transform.Translate(0, upwards * speed * Time.deltaTime, 0);

    }
}
