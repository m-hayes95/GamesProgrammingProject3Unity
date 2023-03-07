using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAIVector2DistanceCheck : MonoBehaviour
{
    // Ref to player game object.
    [SerializeField] private GameObject player;
    // Vector.Distance value between companion and player.
    //public float vector2DistanceBetweenCompanionAndPlayer;

    private void Update()
    {
        FindVector2DistanceBetweenCompanionAndPlayer();
    }

    public void FindVector2DistanceBetweenCompanionAndPlayer()
    {
        // Assign the value of the vector 2 distance method to corresponding variable.
        Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log("Distance between Companion and Player = " + vector2DistanceBetweenCompanionAndPlayer);
    }
}
