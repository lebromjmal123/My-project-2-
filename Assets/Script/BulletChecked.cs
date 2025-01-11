using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecked : MonoBehaviour
{
    
    public PlayerHealth playerHealth;
    public bool hpTrigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with a bullet
        if (other.gameObject.CompareTag("Bullet"))
        {
            hpTrigger = true;
            playerHealth.TakeDamage(10);
            Debug.Log("trigger");
            Destroy(other.gameObject);
            
        }
    }
}
