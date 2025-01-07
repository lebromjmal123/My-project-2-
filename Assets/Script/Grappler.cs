using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public SpringJoint2D springJoint;
    public float springFrequency = 2f;
    public float springDamping = 0.7f;
    public float maxRopeLength = 15f;  // Maximum rope length
    public float minRopeLength = 5f;   // Minimum rope length (when swinging)
    public float swingLengthReductionSpeed = 0.1f; // Speed at which rope shortens when swinging

    private Vector2 initialRopePosition;

    void Start()
    {
        springJoint.enabled = false;
        springJoint.frequency = springFrequency;
        springJoint.dampingRatio = springDamping;
        initialRopePosition = transform.position;  // Store initial position of the player
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Get the mouse position in world space
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // Set the starting position of the line
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);

            // Configure the spring joint
            springJoint.connectedAnchor = mousePos;
            springJoint.enabled = true;

            // Set the initial distance for the rope when it is created
            springJoint.distance = Vector2.Distance(transform.position, mousePos);

            // Enable the line renderer
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            // Disable the spring joint and line renderer
            springJoint.enabled = false;
            lineRenderer.enabled = false;
        }

        if (springJoint.enabled)
        {
            // Update the line renderer to follow the player's position
            lineRenderer.SetPosition(1, transform.position);

            // Limit the rope length to maxRopeLength when the player isn't swinging
            if (Vector2.Distance(initialRopePosition, transform.position) > maxRopeLength)
            {
                springJoint.distance = maxRopeLength;
            }

            // Reduce the length of the rope while swinging (when moving)
            if (springJoint.distance > minRopeLength && IsPlayerSwinging())
            {
                springJoint.distance -= swingLengthReductionSpeed * Time.deltaTime;
            }
        }
    }

    // Check if the player is swinging based on their velocity (or other factors like input)
    bool IsPlayerSwinging()
    {
        // You can adjust this condition based on player movement or velocity
        // Here we're checking if the player's horizontal velocity exceeds a threshold.
        float velocityThreshold = 2f;  // Minimum velocity for swinging
        return Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > velocityThreshold;
    }
}

