using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bulletdisappear : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 2f; // Time in seconds before the bullet disappears
    public BulletTarget target;
    public float bulletSpeed = 10f;
    
    void Start()
    {
        target = FindAnyObjectByType<BulletTarget>();
        
        // Destroy the bullet after the specified lifetime
        //Destroy(gameObject, lifetime);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 bulletMove = (target.transform.position - transform.position).normalized;
        rb.velocity = bulletMove * bulletSpeed;
        
    }

    // Optional: You can add collision logic here if you want to destroy the bullet when it hits something
    //  void OnTriggerEnter2D(Collider2D collision)
    //  {
    //    if (collision.tag == "Player")
    //   {
    //     collision.GetComponent<PlayerHealth>().TakeDamage(20);
    //    Destroy(gameObject);
    //    Debug.Log("Touched");
    //    }
    //   }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
            Destroy(gameObject, 50);
    }
    private void Update()
    {
        
    }

}
