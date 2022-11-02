using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject mySprites;
    public float speed;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        speed = 10f;
        health = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputFromPlayer = new Vector3(h, v, 0);
        
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);

        //if (h == 0)
        {
            //Idle
            //myAnimator.SetBool(“IsRunning?”, false);
            //mySprites.transform.localScale = new Vector3(1, 1, 1);
        } //else
        {
            //Moving right
            //myAnimator.SetBool(“name of bool used in animator controller”, true);
            //mySprites.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            //Player Takes Damage
            Debug.Log("Player Takes Damage");
        }
    }
}
