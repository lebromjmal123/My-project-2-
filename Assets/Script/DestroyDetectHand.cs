using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDetectHand : MonoBehaviour
{
    public PointManager pointManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Touched");
            pointManager.pointCount++;
            Destroy(collision.gameObject);
        }
    }
}
