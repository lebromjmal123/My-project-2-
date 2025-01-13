using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerICheck : MonoBehaviour
{
    public DestroyTowerI destroyTowerI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyTowerI.touchedI = true;
        }
    }
}
