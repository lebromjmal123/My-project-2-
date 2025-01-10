using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;

    public PlayerHealth playerHealth;

    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
                
            }
            else
            {
                
            }

            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
                

            }

            else
            {
               
            }
        }

        else
        {
           
        }
        //else if (playerHealth.hpTrigger == true)
        // {
        //     playerHealth.StartCoroutine(Hurt());

        //}

        
            //anim.Play("Idle");
        

        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);

        }

    }
}
