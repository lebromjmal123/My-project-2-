using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float thrust = 1500f;        // Forward thrust force
    public float pitchSpeed = 5f;       // Speed of the airplane's nose-up/down movement
    public float maxAltitude = 10f;     // Maximum altitude (y-position)
    public float minAltitude = 1f;      // Minimum altitude (y-position)
  
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component for physics calculations
    }

    void Update()
    {
        // Apply forward thrust and pitch control
        Fly();

        // Handle automatic shooting
        

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
