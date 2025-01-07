using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecked : MonoBehaviour
{
    public PlayerHealth playerHealth;
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerHealth.TakeDamage(10);
            Destroy(collision.gameObject); 
        }
    }
}
