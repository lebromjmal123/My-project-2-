using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMarkCheck1 : MonoBehaviour
{
    public DestroyLandMark destroylandMark;
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroylandMark.touched1 = true;
        }
    }
}
