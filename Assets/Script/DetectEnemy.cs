using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Helicopter"))
        {
            Destroy(collision.gameObject);
        }
    }
}
