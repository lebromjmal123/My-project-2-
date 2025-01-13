using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFCheck : MonoBehaviour
{
    public DestroyTowerF destroyTowerF;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyTowerF.touchedF = true;
        }
    }
}
