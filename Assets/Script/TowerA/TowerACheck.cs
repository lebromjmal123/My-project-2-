using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerACheck : MonoBehaviour
{
    public DestroyTowerA destroyTowerA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyTowerA.touchedA = true;
        }
    }
}
