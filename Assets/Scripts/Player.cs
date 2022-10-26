using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject mySprites;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h == 0)
        {
            //Idle
            myAnimator.SetBool(“IsRunning?”, false);
            mySprites.transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            //Moving right
            //myAnimator.SetBool(“name of bool used in animator controller”, true);
            mySprites.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
