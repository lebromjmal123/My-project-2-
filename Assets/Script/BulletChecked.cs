using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecked : MonoBehaviour
{
    
    public PlayerHealth playerHealth;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with a bullet
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            playerHealth.TakeDamage(10);
            Debug.Log("trigger");
            Destroy(other.gameObject);
            
        }
    }
}
