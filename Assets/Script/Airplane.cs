using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float thrust = 1500f;        // Forward thrust force
    public float pitchSpeed = 5f;       // Speed of the airplane's nose-up/down movement
    public float maxAltitude = 10f;     // Maximum altitude (y-position)
    public float minAltitude = 1f;      // Minimum altitude (y-position)
    public GameObject bulletPrefab;     // Bullet prefab to shoot
    public float bulletSpeed = 10f;     // Bullet speed
    public float shootingCooldown = 0.5f; // Time between shots
    private Rigidbody2D rb;
    private float timeSinceLastShot = 0f; // Time tracker for shooting cooldown

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component for physics calculations
    }

    void Update()
    {
        // Apply forward thrust and pitch control
        Fly();

        // Handle automatic shooting
        timeSinceLastShot += Time.deltaTime;  // Update the time since last shot

        if (timeSinceLastShot >= shootingCooldown)
        {
            Shoot();
            timeSinceLastShot = 0f;  // Reset the shooting cooldown timer after shooting
        }

    }

    void Fly()
    {
        // Apply forward thrust to move the airplane
        rb.AddForce(transform.right * thrust * Time.deltaTime, ForceMode2D.Force);

        // Control the altitude automatically (without lift force)
        ControlAltitude();

        // Simple pitch control (nose up/down)
        ApplyPitch();
    }

    void ControlAltitude()
    {
        // Maintain altitude between min and max altitude by adjusting vertical velocity
        float currentAltitude = transform.position.y;

        if (currentAltitude < minAltitude)
        {
            // Apply upward force if below minimum altitude
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y));  // Move upward
        }
        else if (currentAltitude > maxAltitude)
        {
            // Apply downward force if above maximum altitude
            rb.velocity = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.y));  // Move downward
        }
    }

    void ApplyPitch()
    {
        // Simple constant pitch (nose-up movement)
        rb.MoveRotation(rb.rotation + pitchSpeed * Time.deltaTime);  // Rotate the airplane's sprite (Z-axis rotation)
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Instantiate the bullet at the airplane's position and in the direction it's facing
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Get the Rigidbody2D of the bullet and apply force in the direction the airplane is facing
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.right * bulletSpeed;  // Move the bullet forward
        }
    }

    void OnTrgiggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}
