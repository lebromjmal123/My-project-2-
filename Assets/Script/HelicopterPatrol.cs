using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterPatrol : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isPatrolling = false;
    public float speed;

    void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    void Update()
    {
        if (isPatrolling)
        {
            // Move the helicopter back to its original position
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);

            // Stop moving once we reach the original position
            if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
            {
                transform.position = originalPosition; // Ensure it stays at the original position
                isPatrolling = false; // Stop patrolling once the helicopter is at the original position
            }
        }
    }

    // Start patrolling (moving back to original position)
    public void StartPatrolling()
    {
        if (!isPatrolling)
        {
            isPatrolling = true; // Trigger the patrol behavior
        }
    }

    // Stop patrolling (the helicopter has been triggered to chase)
    public void StopPatrolling()
    {
        isPatrolling = false;
    }
}
