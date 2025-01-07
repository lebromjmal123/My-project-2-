using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletdisappear : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 2f; // Time in seconds before the bullet disappears
    
    
    void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifetime);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
